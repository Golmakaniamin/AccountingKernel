﻿#pragma checksum "..\..\..\..\Forms\user_personel\frm_tarifePersonnele.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2D011D4AEDCBA16A47000A1CBF508DB3"
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


namespace AccountingKernel.Forms.user_personel {
    
    
    /// <summary>
    /// frm_tarifePersonnele
    /// </summary>
    public partial class frm_tarifePersonnele : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\Forms\user_personel\frm_tarifePersonnele.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_name;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\..\Forms\user_personel\frm_tarifePersonnele.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_family;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Forms\user_personel\frm_tarifePersonnele.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_code;
        
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
            System.Uri resourceLocater = new System.Uri("/AccountingKernel;component/forms/user_personel/frm_tarifepersonnele.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\user_personel\frm_tarifePersonnele.xaml"
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
            this.txt_name = ((System.Windows.Controls.TextBox)(target));
            
            #line 9 "..\..\..\..\Forms\user_personel\frm_tarifePersonnele.xaml"
            this.txt_name.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txt_name_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_family = ((System.Windows.Controls.TextBox)(target));
            
            #line 10 "..\..\..\..\Forms\user_personel\frm_tarifePersonnele.xaml"
            this.txt_family.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txt_family_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txt_code = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\..\..\Forms\user_personel\frm_tarifePersonnele.xaml"
            this.txt_code.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txt_code_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 12 "..\..\..\..\Forms\user_personel\frm_tarifePersonnele.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

