﻿#pragma checksum "..\..\..\..\Forms\tankhah\frm_entekhabe_personnel_.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8CE98D6608ADFC194C5369916781F591"
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
    /// frm_entekhabe_personnel_
    /// </summary>
    public partial class frm_entekhabe_personnel_ : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\Forms\tankhah\frm_entekhabe_personnel_.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grid_personnel;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Forms\tankhah\frm_entekhabe_personnel_.xaml"
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
            System.Uri resourceLocater = new System.Uri("/AccountingKernel;component/forms/tankhah/frm_entekhabe_personnel_.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\tankhah\frm_entekhabe_personnel_.xaml"
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
            
            #line 4 "..\..\..\..\Forms\tankhah\frm_entekhabe_personnel_.xaml"
            ((AccountingKernel.Forms.tankhah.frm_entekhabe_personnel_)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid_personnel = ((System.Windows.Controls.DataGrid)(target));
            
            #line 9 "..\..\..\..\Forms\tankhah\frm_entekhabe_personnel_.xaml"
            this.grid_personnel.Loaded += new System.Windows.RoutedEventHandler(this.grid_personnel_Loaded);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\..\Forms\tankhah\frm_entekhabe_personnel_.xaml"
            this.grid_personnel.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.grid_personnel_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_select = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\Forms\tankhah\frm_entekhabe_personnel_.xaml"
            this.btn_select.Click += new System.Windows.RoutedEventHandler(this.btn_select_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

