﻿#pragma checksum "..\..\..\..\Forms\tankhah\frm_cheque_sabt.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DA5EC715F1F59166524A96F7E9271DC1"
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


namespace AccountingKernel.Forms.tankhah {
    
    
    /// <summary>
    /// frm_cheque_sabt
    /// </summary>
    public partial class frm_cheque_sabt : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Forms\tankhah\frm_cheque_sabt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnu_reg;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Forms\tankhah\frm_cheque_sabt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnu_edit;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Forms\tankhah\frm_cheque_sabt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnu_remove;
        
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
            System.Uri resourceLocater = new System.Uri("/AccountingKernel;component/forms/tankhah/frm_cheque_sabt.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\tankhah\frm_cheque_sabt.xaml"
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
            this.mnu_reg = ((System.Windows.Controls.MenuItem)(target));
            
            #line 21 "..\..\..\..\Forms\tankhah\frm_cheque_sabt.xaml"
            this.mnu_reg.Click += new System.Windows.RoutedEventHandler(this.mnu_reg_Click_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mnu_edit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 22 "..\..\..\..\Forms\tankhah\frm_cheque_sabt.xaml"
            this.mnu_edit.Click += new System.Windows.RoutedEventHandler(this.mnu_edit_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.mnu_remove = ((System.Windows.Controls.MenuItem)(target));
            
            #line 23 "..\..\..\..\Forms\tankhah\frm_cheque_sabt.xaml"
            this.mnu_remove.Click += new System.Windows.RoutedEventHandler(this.mnu_rem_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

