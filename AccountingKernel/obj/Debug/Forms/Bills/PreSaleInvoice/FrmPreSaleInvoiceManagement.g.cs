﻿#pragma checksum "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4924BCF0C7EC4CD0582DC19B682C3D8C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace AccountingKernel.Forms.Bills.PreSaleInvoice {
    
    
    /// <summary>
    /// FrmPreSaleInvoiceManagement
    /// </summary>
    public partial class FrmPreSaleInvoiceManagement : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPrint;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnExel;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnDel;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEdit;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnNew;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
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
            System.Uri resourceLocater = new System.Uri("/AccountingKernel;component/forms/bills/presaleinvoice/frmpresaleinvoicemanagemen" +
                    "t.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
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
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 7 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
            this.txtSearch.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtSearch_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnPrint = ((System.Windows.Controls.Button)(target));
            
            #line 8 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
            this.BtnPrint.Click += new System.Windows.RoutedEventHandler(this.BtnPrint_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnExel = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
            this.BtnExel.Click += new System.Windows.RoutedEventHandler(this.BtnExel_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnDel = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
            this.BtnDel.Click += new System.Windows.RoutedEventHandler(this.BtnDel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
            this.BtnEdit.Click += new System.Windows.RoutedEventHandler(this.BtnEdit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnNew = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
            this.BtnNew.Click += new System.Windows.RoutedEventHandler(this.BtnNew_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 33 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
            this.DataGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.DataGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 37 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MenuItem_NewClick);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 38 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MenuItem_EditClick);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 39 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MenuItem_DeleteClick);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 42 "..\..\..\..\..\Forms\Bills\PreSaleInvoice\FrmPreSaleInvoiceManagement.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MenuItem_IssueSaleInvoice);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

