﻿#pragma checksum "..\..\..\..\Forms\saleMaly\frm_grouh.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2E43C45293AF51802CC26CEC37EFBFFA"
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


namespace AccountingKernel.Forms.saleMaly {
    
    
    /// <summary>
    /// frm_grouh
    /// </summary>
    public partial class frm_grouh : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\..\Forms\saleMaly\frm_grouh.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_search;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\..\Forms\saleMaly\frm_grouh.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPrint;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Forms\saleMaly\frm_grouh.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnExel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Forms\saleMaly\frm_grouh.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnDel;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Forms\saleMaly\frm_grouh.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEdit;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Forms\saleMaly\frm_grouh.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnNew;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Forms\saleMaly\frm_grouh.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grid_grouh;
        
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
            System.Uri resourceLocater = new System.Uri("/AccountingKernel;component/forms/salemaly/frm_grouh.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\saleMaly\frm_grouh.xaml"
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
            this.txt_search = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.BtnPrint = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.BtnExel = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.BtnDel = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.BtnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Forms\saleMaly\frm_grouh.xaml"
            this.BtnEdit.Click += new System.Windows.RoutedEventHandler(this.BtnEdit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnNew = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Forms\saleMaly\frm_grouh.xaml"
            this.BtnNew.Click += new System.Windows.RoutedEventHandler(this.BtnNew_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.grid_grouh = ((System.Windows.Controls.DataGrid)(target));
            
            #line 35 "..\..\..\..\Forms\saleMaly\frm_grouh.xaml"
            this.grid_grouh.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.doubleClick);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 38 "..\..\..\..\Forms\saleMaly\frm_grouh.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MenuItem_Register);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 39 "..\..\..\..\Forms\saleMaly\frm_grouh.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MenuItem_Edit);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 40 "..\..\..\..\Forms\saleMaly\frm_grouh.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MenuItem_Delete);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 42 "..\..\..\..\Forms\saleMaly\frm_grouh.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MenuItem_saleMaly);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
