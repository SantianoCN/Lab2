﻿#pragma checksum "..\..\..\..\Pages\ViewPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B5FBC5C2E06EBB9BCBCDED4DBA117AF8F6EAD365"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
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
using TsaregorodtsevLab2.Pages;


namespace TsaregorodtsevLab2.Pages {
    
    
    /// <summary>
    /// ViewPage
    /// </summary>
    public partial class ViewPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\Pages\ViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame ViewMenuFrame;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Pages\ViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame ViewDishFrame;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Pages\ViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame ViewDishTypeFrame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TsaregorodtsevLab2;component/pages/viewpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\ViewPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 13 "..\..\..\..\Pages\ViewPage.xaml"
            ((System.Windows.Controls.TabItem)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateMenu);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ViewMenuFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 3:
            
            #line 17 "..\..\..\..\Pages\ViewPage.xaml"
            ((System.Windows.Controls.TabItem)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateDish);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ViewDishFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 5:
            
            #line 21 "..\..\..\..\Pages\ViewPage.xaml"
            ((System.Windows.Controls.TabItem)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateDishesType);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ViewDishTypeFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

