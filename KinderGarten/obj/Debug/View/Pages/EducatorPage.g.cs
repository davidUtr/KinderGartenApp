﻿#pragma checksum "..\..\..\..\View\Pages\EducatorPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E0D9CA36C078C710D44C863F9D7943C02E12CCF79487366A37C4007EE7B470E3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using KinderGarten.Model;
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
    /// EducatorPage
    /// </summary>
    public partial class EducatorPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 13 "..\..\..\..\View\Pages\EducatorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal KinderGarten.View.EducatorPage mainWindow;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\View\Pages\EducatorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grids;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\View\Pages\EducatorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ScheduleDG;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\View\Pages\EducatorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\View\Pages\EducatorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchText;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\..\View\Pages\EducatorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PrintButton;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\..\View\Pages\EducatorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LWTeachers;
        
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
            System.Uri resourceLocater = new System.Uri("/KinderGarten;component/view/pages/educatorpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Pages\EducatorPage.xaml"
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
            this.mainWindow = ((KinderGarten.View.EducatorPage)(target));
            return;
            case 2:
            this.Grids = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.ScheduleDG = ((System.Windows.Controls.DataGrid)(target));
            
            #line 18 "..\..\..\..\View\Pages\EducatorPage.xaml"
            this.ScheduleDG.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.ScheduleDG_LoadingRow);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\..\View\Pages\EducatorPage.xaml"
            this.ScheduleDG.Loaded += new System.Windows.RoutedEventHandler(this.ScheduleDG_Loaded);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\..\View\Pages\EducatorPage.xaml"
            this.AddBtn.Click += new System.Windows.RoutedEventHandler(this.AddBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SearchText = ((System.Windows.Controls.TextBox)(target));
            
            #line 117 "..\..\..\..\View\Pages\EducatorPage.xaml"
            this.SearchText.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchText_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PrintButton = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\..\..\View\Pages\EducatorPage.xaml"
            this.PrintButton.Click += new System.Windows.RoutedEventHandler(this.PrintButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.LWTeachers = ((System.Windows.Controls.ListView)(target));
            
            #line 143 "..\..\..\..\View\Pages\EducatorPage.xaml"
            this.LWTeachers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LWTeachers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            
            #line 29 "..\..\..\..\View\Pages\EducatorPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 60 "..\..\..\..\View\Pages\EducatorPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.deleteTeacher_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

