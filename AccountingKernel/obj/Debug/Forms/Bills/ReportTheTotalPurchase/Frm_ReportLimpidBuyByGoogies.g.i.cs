﻿#pragma checksum "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportLimpidBuyByGoogies.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3D4B98FDDA823B4F6667B67704C4FFCF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Arash.PersianDateControls;
using Microsoft.Windows.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace AccountingKernel.Forms.Bills.ReportTheTotalPurchase {
    
    
    /// <summary>
    /// ReportLimpidBuyByGoogies
    /// </summary>
    public partial class ReportLimpidBuyByGoogies : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportLimpidBuyByGoogies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbStoreS;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportLimpidBuyByGoogies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Arash.PersianDateControls.PersianDatePicker PDate;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportLimpidBuyByGoogies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Grd;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportLimpidBuyByGoogies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SumTxT;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportLimpidBuyByGoogies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SumPrice;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AccountingKernel;component/forms/bills/reportthetotalpurchase/frm_reportlimpidbu" +
                    "ybygoogies.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportLimpidBuyByGoogies.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cmbStoreS = ((System.Windows.Controls.ComboBox)(target));
            
            #line 8 "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportLimpidBuyByGoogies.xaml"
            this.cmbStoreS.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbStoreS_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PDate = ((Arash.PersianDateControls.PersianDatePicker)(target));
            
            #line 11 "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportLimpidBuyByGoogies.xaml"
            this.PDate.SelectedDateChanged += new System.Windows.RoutedEventHandler(this.PDate_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 12 "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportLimpidBuyByGoogies.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Grd = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.SumTxT = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.SumPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
