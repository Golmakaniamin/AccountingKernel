﻿#pragma checksum "..\..\..\..\Forms\Goodies\FrmPriceList.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BF043F8B7AA5E86CCF47CBB37648D843"
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
    /// FrmPriceList
    /// </summary>
    public partial class FrmPriceList : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\Forms\Goodies\FrmPriceList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblHeaderCommodityCode;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\..\Forms\Goodies\FrmPriceList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblHeaderCommodityCodeValue;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\..\Forms\Goodies\FrmPriceList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblHeaderCommodityTitle;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\..\Forms\Goodies\FrmPriceList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblHeaderCommodityTitleValue;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Forms\Goodies\FrmPriceList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grdPriceLists;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Forms\Goodies\FrmPriceList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridComboBoxColumn cmbCustomerType;
        
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
            System.Uri resourceLocater = new System.Uri("/AccountingKernel;component/forms/goodies/frmpricelist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\Goodies\FrmPriceList.xaml"
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
            this.lblHeaderCommodityCode = ((System.Windows.Controls.Label)(target));
            
            #line 7 "..\..\..\..\Forms\Goodies\FrmPriceList.xaml"
            this.lblHeaderCommodityCode.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.lblHeaderCommodityCode_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblHeaderCommodityCodeValue = ((System.Windows.Controls.Label)(target));
            
            #line 8 "..\..\..\..\Forms\Goodies\FrmPriceList.xaml"
            this.lblHeaderCommodityCodeValue.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.lblHeaderCommodityCodeValue_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblHeaderCommodityTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lblHeaderCommodityTitleValue = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.grdPriceLists = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            
            #line 14 "..\..\..\..\Forms\Goodies\FrmPriceList.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MenuItem_DeleteClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cmbCustomerType = ((System.Windows.Controls.DataGridComboBoxColumn)(target));
            return;
            case 8:
            
            #line 25 "..\..\..\..\Forms\Goodies\FrmPriceList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
