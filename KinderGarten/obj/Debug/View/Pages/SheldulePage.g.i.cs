﻿#pragma checksum "..\..\..\..\View\Pages\SheldulePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5763BADBE06D7366197B75EA3376F00C8A28480639D6B80FA5879CD322ABE7D5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using KinderGarten.View.Pages;
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


namespace KinderGarten.View.Pages {
    
    
    /// <summary>
    /// SheldulePage
    /// </summary>
    public partial class SheldulePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 14 "..\..\..\..\View\Pages\SheldulePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grids;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\View\Pages\SheldulePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ScheduleDG;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\View\Pages\SheldulePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\..\View\Pages\SheldulePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker searchDate;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\View\Pages\SheldulePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PrintButton;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\..\View\Pages\SheldulePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SearchGroups;
        
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
            System.Uri resourceLocater = new System.Uri("/KinderGarten;component/view/pages/sheldulepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Pages\SheldulePage.xaml"
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
            this.Grids = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.ScheduleDG = ((System.Windows.Controls.DataGrid)(target));
            
            #line 15 "..\..\..\..\View\Pages\SheldulePage.xaml"
            this.ScheduleDG.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.ScheduleDG_LoadingRow);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\..\..\View\Pages\SheldulePage.xaml"
            this.AddBtn.Click += new System.Windows.RoutedEventHandler(this.AddBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.searchDate = ((System.Windows.Controls.DatePicker)(target));
            
            #line 125 "..\..\..\..\View\Pages\SheldulePage.xaml"
            this.searchDate.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.searchDate_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.PrintButton = ((System.Windows.Controls.Button)(target));
            
            #line 126 "..\..\..\..\View\Pages\SheldulePage.xaml"
            this.PrintButton.Click += new System.Windows.RoutedEventHandler(this.PrintButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SearchGroups = ((System.Windows.Controls.ComboBox)(target));
            
            #line 151 "..\..\..\..\View\Pages\SheldulePage.xaml"
            this.SearchGroups.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SearchGroups_SelectionChanged);
            
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
            case 3:
            
            #line 39 "..\..\..\..\View\Pages\SheldulePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 70 "..\..\..\..\View\Pages\SheldulePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.deleteSchedule_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

