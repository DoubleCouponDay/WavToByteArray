﻿#pragma checksum "..\..\..\UserInputPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E86D649637EB442D321E9F4DDAE5446E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using WAV2ByteArray;


namespace WAV2ByteArray {
    
    
    /// <summary>
    /// UserInputPage
    /// </summary>
    public partial class UserInputPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\UserInputPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid UserInputGrid;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\UserInputPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox FilesList;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\UserInputPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBoxItem AddressBar_1;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\UserInputPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FindAddressButton_1;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\UserInputPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewFileButton;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\UserInputPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveFileButton;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UserInputPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ConvertButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WAV2ByteArray;component/userinputpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserInputPage.xaml"
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
            this.UserInputGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.FilesList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.AddressBar_1 = ((System.Windows.Controls.ListBoxItem)(target));
            return;
            case 4:
            this.FindAddressButton_1 = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\UserInputPage.xaml"
            this.FindAddressButton_1.Click += new System.Windows.RoutedEventHandler(this.ClickFindAddress);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NewFileButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\UserInputPage.xaml"
            this.NewFileButton.Click += new System.Windows.RoutedEventHandler(this.ClickNewBar);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RemoveFileButton = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\UserInputPage.xaml"
            this.RemoveFileButton.Click += new System.Windows.RoutedEventHandler(this.ClickRemoveBar);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ConvertButton = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\UserInputPage.xaml"
            this.ConvertButton.Click += new System.Windows.RoutedEventHandler(this.ClickConvert);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
