﻿#pragma checksum "..\..\..\..\Forms\saleMaly\frm_saleMaly.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1E1DCE9BC6523B9F18670DC3929CF576"
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
    /// frm_saleMaly
    /// </summary>
    public partial class frm_saleMaly : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\..\Forms\saleMaly\frm_saleMaly.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_search;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\..\Forms\saleMaly\frm_saleMaly.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPrint;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Forms\saleMaly\frm_saleMaly.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnExel;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Forms\saleMaly\frm_saleMaly.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnDel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Forms\saleMaly\frm_saleMaly.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEdit;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Forms\saleMaly\frm_saleMaly.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnNew;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Forms\saleMaly\frm_saleMaly.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grd_grouh;
        
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
            System.Uri resourceLocater = new System.Uri("/AccountingKernel;component/forms/salemaly/frm_salemaly.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\saleMaly\frm_saleMaly.xaml"
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
            
            #line 4 "..\..\..\..\Forms\saleMaly\frm_saleMaly.xaml"
            ((AccountingKernel.Forms.saleMaly.frm_saleMaly)(target)).Initialized += new System.EventHandler(this.Window_Initialized_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_search = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.BtnPrint = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.BtnExel = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.BtnDel = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.BtnEdit = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.BtnNew = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\Forms\saleMaly\frm_saleMaly.xaml"
            this.BtnNew.Click += new System.Windows.RoutedEventHandler(this.BtnNew_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.grd_grouh = ((System.Windows.Controls.DataGrid)(target));
            
            #line 34 "..\..\..\..\Forms\saleMaly\frm_saleMaly.xaml"
            this.grd_grouh.Initialized += new System.EventHandler(this.initialize);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\..\Forms\saleMaly\frm_saleMaly.xaml"
            this.grd_grouh.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.mouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 37 "..\..\..\..\Forms\saleMaly\frm_saleMaly.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MenuItem_Register);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 38 "..\..\..\..\Forms\saleMaly\frm_saleMaly.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MenuItem_Edit);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 39 "..\..\..\..\Forms\saleMaly\frm_saleMaly.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MenuItem_Delete);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

