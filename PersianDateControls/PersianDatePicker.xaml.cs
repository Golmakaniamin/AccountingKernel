using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Globalization;
using Common;

namespace Arash.PersianDateControls
{
    [System.ComponentModel.DefaultEvent("SelectedDateChanged")]
    [System.ComponentModel.DefaultProperty("SelectedDate")]
    public partial class PersianDatePicker : UserControl
    {

        public PersianDate PlusMount(ref string date, int PlusMountNumber)
        {
            string[] mount = date.Split('/');
            int y = int.Parse(mount[0]);
            int m = int.Parse(mount[1]) + PlusMountNumber;
            int d = int.Parse(mount[2]);
            if (m > 12) { y += 1; m -= 12; }
            date = string.Format("{0}/{1}/{2}", y, m, d);
            return new PersianDate(y, m, d);
        }

        public PersianDate SelectedDate
        {
            get { return (Arash.PersianDate)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        public static readonly DependencyProperty SelectedDateProperty;



        public PersianDate DisplayDate
        {
            get { return (PersianDate)GetValue(DisplayDateProperty); }
            set { SetValue(DisplayDateProperty, value); }
        }

        /// <summary>
        /// the minimum date that is displayed, and can be selected
        /// </summary>
        public PersianDate DisplayDateStart
        {
            get { return (PersianDate)GetValue(DisplayDateStartProperty); }
            set { SetValue(DisplayDateStartProperty, value); }
        }
        public static readonly DependencyProperty DisplayDateStartProperty;


        /// <summary>
        /// the maximum date that is displayed, and can be selected
        /// </summary>
        public PersianDate DisplayDateEnd
        {
            get { return (PersianDate)GetValue(DisplayDateEndProperty); }
            set { SetValue(DisplayDateEndProperty, value); }
        }
        public static readonly DependencyProperty DisplayDateEndProperty;


        public string Text
        {
            get { return ((string)GetValue(TextProperty)).ToNormalDate(); }
            set { SetValue(TextProperty, value); }
        }


        public static readonly DependencyProperty TextProperty;

        //events

        public static readonly RoutedEvent SelectedDateChangedEvent;
        public event RoutedEventHandler SelectedDateChanged
        {
            add { AddHandler(SelectedDateChangedEvent, value); }
            remove { RemoveHandler(SelectedDateChangedEvent, value); }
        }

        //property changed callbacks and value coercions
        static object coerceDisplayDateEnd(DependencyObject d, object o)
        {
            var pdp = d as PersianDatePicker;
            PersianDate value = (PersianDate)o;
            if (value < pdp.DisplayDateStart)
            {
                return pdp.DisplayDateStart;
            }
            return o;
        }
        static object coerceDateToBeInRange(DependencyObject d, object o)
        {
            PersianDatePicker pdp = d as PersianDatePicker;
            PersianDate value = (PersianDate)o;
            if (value < pdp.DisplayDateStart)
            {
                return pdp.DisplayDateStart;
            }
            if (value > pdp.DisplayDateEnd)
            {
                return pdp.DisplayDateEnd;
            }
            return o;
        }

        static void selectedDateChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            PersianDatePicker pdp = o as PersianDatePicker;
            pdp.Text = e.NewValue.ToString();
            pdp.RaiseEvent(new RoutedEventArgs(SelectedDateChangedEvent, pdp));

        }

        static void displayDateChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            PersianDatePicker pd = o as PersianDatePicker;

        }
        static void textChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            PersianDatePicker pd = o as PersianDatePicker;

        }

        public static readonly DependencyProperty DisplayDateProperty;

        static PersianDatePicker()
        {
            PropertyMetadata selectedDateMetadata = new PropertyMetadata(PersianDate.Today, selectedDateChanged);
            selectedDateMetadata.CoerceValueCallback = coerceDateToBeInRange;
            SelectedDateProperty =
                DependencyProperty.Register("SelectedDate", typeof(Arash.PersianDate), typeof(PersianDatePicker), selectedDateMetadata);

            PropertyMetadata displayDateMetadata = new PropertyMetadata(PersianDate.Today, displayDateChanged);
            displayDateMetadata.CoerceValueCallback = coerceDateToBeInRange;
            DisplayDateProperty =
                DependencyProperty.Register("DisplayDate", typeof(PersianDate), typeof(PersianDatePicker), displayDateMetadata);

            PropertyMetadata textMetadata = new PropertyMetadata(PersianDate.Today.ToString(), textChanged);
            TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(PersianDatePicker), textMetadata);

            PropertyMetadata displayDateStartMetaData = new PropertyMetadata(new PersianDate());
            DisplayDateStartProperty =
                DependencyProperty.Register("DisplayDateStart", typeof(PersianDate), typeof(PersianDatePicker), displayDateStartMetaData);

            PropertyMetadata displayDateEndMetaData = new PropertyMetadata(new PersianDate(10000, 1, 1));
            displayDateEndMetaData.CoerceValueCallback = coerceDisplayDateEnd;
            DisplayDateEndProperty =
                DependencyProperty.Register("DisplayDateEnd", typeof(PersianDate), typeof(PersianDatePicker), displayDateEndMetaData);

            SelectedDateChangedEvent =
                EventManager.RegisterRoutedEvent("SelectedDateChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PersianDatePicker));
        }
        public static BitmapSource ConvertToBitmapSource(System.Drawing.Bitmap gdiPlusBitmap)
        {

            IntPtr hBitmap = gdiPlusBitmap.GetHbitmap();

            return Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

        }


        PersianCalendar persianCalendar;
        /// <summary>
        /// This readonly property gets the PersianCalendar object displayed when clicking the Calendar button.
        /// </summary>
        public PersianCalendar PersianCalendar
        {
            get { return persianCalendar; }
        }
        public PersianDatePicker()
        {
            InitializeComponent();
            persianCalendar = persianCalendarGrid.Children[0] as PersianCalendar;
            setBindings();
            this.Text = this.SelectedDate.ToString();
            this.openCalendarButtonImage.Source = ConvertToBitmapSource(Resource.openCalendarButtonImage);

            //this is for closing the popup when a date is selected using PersianCalendar
            foreach (var monthModeButton in this.persianCalendar.monthModeButtons)
            {
                monthModeButton.Click += delegate
                {
                    this.persianCalnedarPopup.IsOpen = false;
                };
            }

        }

        private void setBindings()
        {
            Binding selectedDateBinding = new Binding
            {
                Source = this.persianCalendar,
                Path = new PropertyPath("SelectedDate"),
                Mode = BindingMode.TwoWay,
            };
            this.SetBinding(SelectedDateProperty, selectedDateBinding);

            Binding displayDateBinding = new Binding
            {
                Source = this.persianCalendar,
                Path = new PropertyPath("DisplayDate"),
                Mode = BindingMode.TwoWay,
            };
            this.SetBinding(DisplayDateProperty, displayDateBinding);

            Binding textBinding = new Binding
            {
                Source = this.dateTextBox,
                Path = new PropertyPath("Text"),
                Mode = BindingMode.TwoWay,
            };
            this.SetBinding(TextProperty, textBinding);

            Binding displayDateStartBinding = new Binding
            {
                Source = this.persianCalendar,
                Path = new PropertyPath("DisplayDateStart"),
                Mode = BindingMode.TwoWay,
            };
            this.SetBinding(DisplayDateStartProperty, displayDateStartBinding);

            Binding displayDateEndBinding = new Binding
            {
                Source = this.persianCalendar,
                Path = new PropertyPath("DisplayDateEnd"),
                Mode = BindingMode.TwoWay,
            };
            this.SetBinding(DisplayDateEndProperty, displayDateEndBinding);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            persianCalnedarPopup.IsOpen = true;
        }

        void validateText()
        {
            PersianDate date;
            if (PersianDate.TryParse(dateTextBox.Text, out date))
            {
                this.SelectedDate = date;
                this.DisplayDate = date;
            }
            this.Text = this.SelectedDate.ToString();
        }

        private void dateTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            validateText();
        }

        private void dateTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                validateText();
        }

        private void openCalendarButtonImage_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void persianCalnedarPopup_Opened(object sender, EventArgs e)
        {
            this.persianCalendar.Focus();
        }
    }
}
