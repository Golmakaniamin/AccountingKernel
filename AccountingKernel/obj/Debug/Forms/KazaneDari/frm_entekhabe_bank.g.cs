﻿#pragma checksum "..\..\..\..\Forms\KazaneDari\frm_entekhabe_bank.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7E72F0EC542D3D71C13F47B832AE3DF9"
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


namespace AccountingKernel.Forms.KazaneDari {
    
    
    /// <summary>
    /// frm_entekhabe_bank
    /// </summary>
    public partial class frm_entekhabe_bank : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\..\Forms\KazaneDari\frm_entekhabe_bank.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grd_fund;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Forms\KazaneDari\frm_entekhabe_bank.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_select;
        
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
            System.Uri resourceLocater = new System.Uri("/AccountingKernel;component/forms/kazanedari/frm_entekhabe_bank.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\KazaneDari\frm_entekhabe_bank.xaml"
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
            
            #line 4 "..\..\..\..\Forms\KazaneDari\frm_entekhabe_bank.xaml"
            ((AccountingKernel.Forms.KazaneDari.frm_entekhabe_bank)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grd_fund = ((System.Windows.Controls.DataGrid)(target));
            
            #line 6 "..\..\..\..\Forms\KazaneDari\frm_entekhabe_bank.xaml"
            this.grd_fund.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.grd_fund_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_select = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\Forms\KazaneDari\frm_entekhabe_bank.xaml"
            this.btn_select.Click += new System.Windows.RoutedEventHandler(this.btn_select_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

