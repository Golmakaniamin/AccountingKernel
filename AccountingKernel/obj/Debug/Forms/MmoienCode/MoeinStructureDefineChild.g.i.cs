﻿#pragma checksum "..\..\..\..\Forms\MmoienCode\MoeinStructureDefineChild.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F053963C47B95E09F343F082C51A52DB"
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
using WPFAutoCompleteTextbox;


namespace AccountingKernel.Forms.MmoienCode {
    
    
    /// <summary>
    /// MoeinStructureDefineChild
    /// </summary>
    public partial class MoeinStructureDefineChild : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\Forms\MmoienCode\MoeinStructureDefineChild.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WPFAutoCompleteTextbox.AutoCompleteTextBox txtPrimeryGroupCode;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Forms\MmoienCode\MoeinStructureDefineChild.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrimeryGroupName;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Forms\MmoienCode\MoeinStructureDefineChild.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrimeryGroupLatinName;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Forms\MmoienCode\MoeinStructureDefineChild.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSecenderyGroupCode;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Forms\MmoienCode\MoeinStructureDefineChild.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSecenderyGroupName;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Forms\MmoienCode\MoeinStructureDefineChild.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSecenderyGroupLatinName;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Forms\MmoienCode\MoeinStructureDefineChild.xaml"
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
            System.Uri resourceLocater = new System.Uri("/AccountingKernel;component/forms/mmoiencode/moeinstructuredefinechild.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\MmoienCode\MoeinStructureDefineChild.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.txtPrimeryGroupCode = ((WPFAutoCompleteTextbox.AutoCompleteTextBox)(target));
            return;
            case 2:
            this.txtPrimeryGroupName = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\..\..\Forms\MmoienCode\MoeinStructureDefineChild.xaml"
            this.txtPrimeryGroupName.LostFocus += new System.Windows.RoutedEventHandler(this.txtPrimeryGroupName_LostFocus);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\..\Forms\MmoienCode\MoeinStructureDefineChild.xaml"
            this.txtPrimeryGroupName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtJustPersian);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtPrimeryGroupLatinName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtSecenderyGroupCode = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\..\Forms\MmoienCode\MoeinStructureDefineChild.xaml"
            this.txtSecenderyGroupCode.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumericTextBoxValidation);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtSecenderyGroupName = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\..\Forms\MmoienCode\MoeinStructureDefineChild.xaml"
            this.txtSecenderyGroupName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtJustPersian);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtSecenderyGroupLatinName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnSubmit = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Forms\MmoienCode\MoeinStructureDefineChild.xaml"
            this.btnSubmit.Click += new System.Windows.RoutedEventHandler(this.btnSubmit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

