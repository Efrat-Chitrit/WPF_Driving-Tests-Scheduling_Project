﻿#pragma checksum "..\..\TraineeWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D2F00B1F8E99EA639E4C8F6A3FF73DA5E8ED2F4F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PLWPF;
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


namespace PLWPF {
    
    
    /// <summary>
    /// TraineeWindow
    /// </summary>
    public partial class TraineeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\TraineeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label trainee;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\TraineeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TraineeAddButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\TraineeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TraineeDeleteButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\TraineeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TraineeUpdateButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\TraineeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TraineeSearchButton;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/traineewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TraineeWindow.xaml"
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
            this.trainee = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.TraineeAddButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\TraineeWindow.xaml"
            this.TraineeAddButton.Click += new System.Windows.RoutedEventHandler(this.TraineeAddButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TraineeDeleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\TraineeWindow.xaml"
            this.TraineeDeleteButton.Click += new System.Windows.RoutedEventHandler(this.TraineeDeleteButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TraineeUpdateButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\TraineeWindow.xaml"
            this.TraineeUpdateButton.Click += new System.Windows.RoutedEventHandler(this.TraineeUpdateButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TraineeSearchButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\TraineeWindow.xaml"
            this.TraineeSearchButton.Click += new System.Windows.RoutedEventHandler(this.TraineeSearchButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

