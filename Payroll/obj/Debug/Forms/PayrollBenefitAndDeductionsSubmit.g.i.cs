﻿#pragma checksum "..\..\..\Forms\PayrollBenefitAndDeductionsSubmit.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BD0F5D13AFDCF160B81F4DDC53B14116"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// PayrollBenefitAndDeductionsSubmit
    /// </summary>
    public partial class PayrollBenefitAndDeductionsSubmit : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\Forms\PayrollBenefitAndDeductionsSubmit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\Forms\PayrollBenefitAndDeductionsSubmit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grdBenefitAndDeductionsLists;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Forms\PayrollBenefitAndDeductionsSubmit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Gridnew;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Forms\PayrollBenefitAndDeductionsSubmit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem GridEdit;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Forms\PayrollBenefitAndDeductionsSubmit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;
        
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
            System.Uri resourceLocater = new System.Uri("/Payroll;component/forms/payrollbenefitanddeductionssubmit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forms\PayrollBenefitAndDeductionsSubmit.xaml"
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
            
            #line 4 "..\..\..\Forms\PayrollBenefitAndDeductionsSubmit.xaml"
            ((AccountingKernel.PayrollBenefitAndDeductionsSubmit)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 7 "..\..\..\Forms\PayrollBenefitAndDeductionsSubmit.xaml"
            this.txtSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.grdBenefitAndDeductionsLists = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.Gridnew = ((System.Windows.Controls.MenuItem)(target));
            
            #line 12 "..\..\..\Forms\PayrollBenefitAndDeductionsSubmit.xaml"
            this.Gridnew.Click += new System.Windows.RoutedEventHandler(this.Gridnew_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.GridEdit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 13 "..\..\..\Forms\PayrollBenefitAndDeductionsSubmit.xaml"
            this.GridEdit.Click += new System.Windows.RoutedEventHandler(this.GridEdit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

