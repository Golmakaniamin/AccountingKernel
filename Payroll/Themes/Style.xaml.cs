using System.Windows;
using System.Windows.Input;


namespace ExceptionWin
{
	/// <summary>
	/// Interaction logic for Style.xaml
	/// </summary>
	public partial class Style : ResourceDictionary
	{
		public Style()
	
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the MouseLeftButtonDown event. This event handler is used here to facilitate
        /// dragging of the Window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LayoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var window = (Window)((FrameworkElement)sender).TemplatedParent;
            window.DragMove();
        }

        /// <summary>
        /// Fires when the user clicks the Close button on the window's custom title bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Close(object sender, RoutedEventArgs e)
        {
            var window = (Window)((FrameworkElement)sender).TemplatedParent;
            window.Close();
        }

        private void btnMinimize_Click_1(object sender, RoutedEventArgs e)
        {
            var window = (Window)((FrameworkElement)sender).TemplatedParent;
            window.WindowState = WindowState.Minimized;
        }

        private void btnMinimizeNew_Copy_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {

        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {

        }
	}
}