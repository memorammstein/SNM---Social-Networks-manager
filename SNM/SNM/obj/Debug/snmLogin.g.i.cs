﻿#pragma checksum "..\..\snmLogin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5A21DC001AC0B3865E7B0849A3067943"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.239
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace SNM {
    
    
    /// <summary>
    /// snmLogin
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class snmLogin : System.Windows.Controls.Grid, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\snmLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stkSNMlogin;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\snmLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image SNMbannerImg;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\snmLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stkNetworks;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\snmLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image iconFacebookImg;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\snmLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image iconTwitterImg;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\snmLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image iconYoutubeImg;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SNM;component/snmlogin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\snmLogin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.stkSNMlogin = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.SNMbannerImg = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.stkNetworks = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.iconFacebookImg = ((System.Windows.Controls.Image)(target));
            
            #line 11 "..\..\snmLogin.xaml"
            this.iconFacebookImg.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.iconFacebookImg_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.iconTwitterImg = ((System.Windows.Controls.Image)(target));
            
            #line 12 "..\..\snmLogin.xaml"
            this.iconTwitterImg.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.iconTwitterImg_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.iconYoutubeImg = ((System.Windows.Controls.Image)(target));
            
            #line 13 "..\..\snmLogin.xaml"
            this.iconYoutubeImg.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.iconYoutubeImg_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

