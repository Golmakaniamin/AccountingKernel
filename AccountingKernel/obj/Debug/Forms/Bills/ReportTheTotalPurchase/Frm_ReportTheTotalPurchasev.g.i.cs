﻿#pragma checksum "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportTheTotalPurchasev.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "16538D29DD53CB6ABBFCC5D1F3D6D70E"
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
    /// Frm_ReportTheTotalPurchasev
    /// </summary>
    public partial class Frm_ReportTheTotalPurchasev : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportTheTotalPurchasev.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Arash.PersianDateControls.PersianDatePicker PDate1;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportTheTotalPurchasev.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Arash.PersianDateControls.PersianDatePicker PDate2;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportTheTotalPurchasev.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/AccountingKernel;component/forms/bills/reportthetotalpurchase/frm_reportthetotal" +
                    "purchasev.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportTheTotalPurchasev.xaml"
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
            
            #line 7 "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportTheTotalPurchasev.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PDate1 = ((Arash.PersianDateControls.PersianDatePicker)(target));
            
            #line 9 "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportTheTotalPurchasev.xaml"
            this.PDate1.SelectedDateChanged += new System.Windows.RoutedEventHandler(this.PDate1_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PDate2 = ((Arash.PersianDateControls.PersianDatePicker)(target));
            
            #line 11 "..\..\..\..\..\Forms\Bills\ReportTheTotalPurchase\Frm_ReportTheTotalPurchasev.xaml"
            this.PDate2.SelectedDateChanged += new System.Windows.RoutedEventHandler(this.PDate2_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

