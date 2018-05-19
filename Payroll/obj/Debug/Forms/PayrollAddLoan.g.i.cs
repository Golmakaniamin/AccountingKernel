﻿#pragma checksum "..\..\..\Forms\PayrollAddLoan.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EC9C4A1AAB39FC155D4E17D4B363FFD9"
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
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace AccountingKernel {
    
    
    /// <summary>
    /// PayrollAddLoan
    /// </summary>
    public partial class PayrollAddLoan : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\Forms\PayrollAddLoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLoanCode;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\Forms\PayrollAddLoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Arash.PersianDateControls.PersianDatePicker pdcPaymentDate;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Forms\PayrollAddLoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLoanPrice;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Forms\PayrollAddLoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewLoan;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Forms\PayrollAddLoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grdLoan;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Forms\PayrollAddLoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem GridLoanDetail;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Forms\PayrollAddLoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSubmit;
        
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
            System.Uri resourceLocater = new System.Uri("/Payroll;component/forms/payrolladdloan.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forms\PayrollAddLoan.xaml"
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
            this.txtLoanCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.pdcPaymentDate = ((Arash.PersianDateControls.PersianDatePicker)(target));
            return;
            case 3:
            this.txtLoanPrice = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\..\Forms\PayrollAddLoan.xaml"
            this.txtLoanPrice.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtLoanPrice_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnNewLoan = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Forms\PayrollAddLoan.xaml"
            this.btnNewLoan.Click += new System.Windows.RoutedEventHandler(this.btnNewLoan_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.grdLoan = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.GridLoanDetail = ((System.Windows.Controls.MenuItem)(target));
            
            #line 17 "..\..\..\Forms\PayrollAddLoan.xaml"
            this.GridLoanDetail.Click += new System.Windows.RoutedEventHandler(this.GridLoanDetail_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnSubmit = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Forms\PayrollAddLoan.xaml"
            this.btnSubmit.Click += new System.Windows.RoutedEventHandler(this.btnSubmit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
