﻿#pragma checksum "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FACCAFF439CA3C1A85A437F64176EA55"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AccountingKernel.Class;
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


namespace AccountingKernel.Forms.SotoheTafsili {
    
    
    /// <summary>
    /// ManageTafsiliGroup
    /// </summary>
    public partial class ManageTafsiliGroup : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 8 "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPrint;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnExel;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnDel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEdit;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnNew;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView trvMenu;
        
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
            System.Uri resourceLocater = new System.Uri("/AccountingKernel;component/forms/sotohetafsili/managetafsiligroup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml"
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
            
            #line 8 "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml"
            this.txtSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnPrint = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.BtnExel = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml"
            this.BtnExel.Click += new System.Windows.RoutedEventHandler(this.BtnExel_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnDel = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml"
            this.BtnDel.Click += new System.Windows.RoutedEventHandler(this.delete_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml"
            this.BtnEdit.Click += new System.Windows.RoutedEventHandler(this.edit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnNew = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml"
            this.BtnNew.Click += new System.Windows.RoutedEventHandler(this.new_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.trvMenu = ((System.Windows.Controls.TreeView)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 8:
            
            #line 41 "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.new_Click);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 42 "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.edit_Click);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 43 "..\..\..\..\Forms\SotoheTafsili\ManageTafsiliGroup.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.delete_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

