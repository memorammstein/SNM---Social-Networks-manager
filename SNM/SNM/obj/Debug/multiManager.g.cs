﻿#pragma checksum "..\..\multiManager.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FA6CBD9200295C6E0A2240364592830D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.17929
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using SNM;
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
    /// multiManager
    /// </summary>
    public partial class multiManager : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\multiManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SNM.multiManager gridMultiManager;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\multiManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabPestañas;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\multiManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabWall;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\multiManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstWall;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\multiManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabTimeline;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\multiManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstTimeline;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\multiManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabYoutube;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\multiManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstSubscripciones;
        
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
            System.Uri resourceLocater = new System.Uri("/SNM;component/multimanager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\multiManager.xaml"
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
            this.gridMultiManager = ((SNM.multiManager)(target));
            
            #line 10 "..\..\multiManager.xaml"
            this.gridMultiManager.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.gridMultiManager_MouseUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tabPestañas = ((System.Windows.Controls.TabControl)(target));
            return;
            case 3:
            this.tabWall = ((System.Windows.Controls.TabItem)(target));
            
            #line 18 "..\..\multiManager.xaml"
            this.tabWall.KeyUp += new System.Windows.Input.KeyEventHandler(this.tabWall_KeyUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lstWall = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.tabTimeline = ((System.Windows.Controls.TabItem)(target));
            
            #line 30 "..\..\multiManager.xaml"
            this.tabTimeline.KeyUp += new System.Windows.Input.KeyEventHandler(this.tabTimeline_KeyUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lstTimeline = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.tabYoutube = ((System.Windows.Controls.TabItem)(target));
            
            #line 40 "..\..\multiManager.xaml"
            this.tabYoutube.KeyUp += new System.Windows.Input.KeyEventHandler(this.tabYoutube_KeyUp);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lstSubscripciones = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
