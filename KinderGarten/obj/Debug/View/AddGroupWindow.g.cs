﻿#pragma checksum "..\..\..\View\AddGroupWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "528DE6FB4EB72B055632A0581AF0AB567345EFA979EF3E16B8B6268CC8DB7E37"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using KinderGarten.View;
using KinderGarten.ViewModel;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace KinderGarten.View {
    
    
    /// <summary>
    /// AddGroupWindow
    /// </summary>
    public partial class AddGroupWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\View\AddGroupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FullName;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\View\AddGroupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createEducator;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\View\AddGroupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateOfBirths;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\View\AddGroupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ExitImage;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\View\AddGroupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle minimizedBtn;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\View\AddGroupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ParentBox;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\View\AddGroupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox GroupBox;
        
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
            System.Uri resourceLocater = new System.Uri("/KinderGarten;component/view/addgroupwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\AddGroupWindow.xaml"
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
            
            #line 15 "..\..\..\View\AddGroupWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FullName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.createEducator = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\View\AddGroupWindow.xaml"
            this.createEducator.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dateOfBirths = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.ExitImage = ((System.Windows.Controls.Image)(target));
            
            #line 46 "..\..\..\View\AddGroupWindow.xaml"
            this.ExitImage.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ExitImage_MouseDown);
            
            #line default
            #line hidden
            
            #line 46 "..\..\..\View\AddGroupWindow.xaml"
            this.ExitImage.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ExitImage_MouseEnter);
            
            #line default
            #line hidden
            
            #line 46 "..\..\..\View\AddGroupWindow.xaml"
            this.ExitImage.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ExitImage_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 6:
            this.minimizedBtn = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 47 "..\..\..\View\AddGroupWindow.xaml"
            this.minimizedBtn.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Rectangle_MouseDown);
            
            #line default
            #line hidden
            
            #line 47 "..\..\..\View\AddGroupWindow.xaml"
            this.minimizedBtn.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseEnter);
            
            #line default
            #line hidden
            
            #line 47 "..\..\..\View\AddGroupWindow.xaml"
            this.minimizedBtn.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ParentBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.GroupBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
