﻿#pragma checksum "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1523D716AA79BF0EEC6266D0B94C788A"
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


namespace AccountingKernel.Forms.Goodies {
    
    
    /// <summary>
    /// FrmUnitCount
    /// </summary>
    public partial class FrmUnitCount : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtCode;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtTitle;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPrint;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnExel;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnDel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEdit;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnNew;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grdUnitCount;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridComboBoxColumn cmbSecondUnit;
        
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
            System.Uri resourceLocater = new System.Uri("/AccountingKernel;component/forms/goodies/groups/frmunitcount.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
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
            this.txtCode = ((System.Windows.Controls.Label)(target));
            
            #line 7 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
            this.txtCode.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtCode_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
            this.txtSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnPrint = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
            this.BtnPrint.Click += new System.Windows.RoutedEventHandler(this.BtnPrint_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnExel = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
            this.BtnExel.Click += new System.Windows.RoutedEventHandler(this.BtnExel_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnDel = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
            this.BtnDel.Click += new System.Windows.RoutedEventHandler(this.BtnDel_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnEdit = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.BtnNew = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.grdUnitCount = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            
            #line 40 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MenuItem_DeleteClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.cmbSecondUnit = ((System.Windows.Controls.DataGridComboBoxColumn)(target));
            return;
            case 12:
            
            #line 51 "..\..\..\..\..\Forms\Goodies\Groups\FrmUnitCount.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

