﻿#pragma checksum "..\..\..\Pages\DataStaff.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A3ED82A5EAB4E001F8A9E6C30E9B74B9C88FCBF3C5E0F5B53E86272AB6BD5072"
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
using knightApp.Pages;


namespace knightApp.Pages {
    
    
    /// <summary>
    /// DataStaff
    /// </summary>
    public partial class DataStaff : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\..\Pages\DataStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxLastname;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Pages\DataStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxFirstname;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Pages\DataStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxPatronymic;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Pages\DataStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxPhoneNumber;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Pages\DataStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxPosition;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\Pages\DataStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAddSporsman;
        
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
            System.Uri resourceLocater = new System.Uri("/knightApp;component/pages/datastaff.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\DataStaff.xaml"
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
            this.TBoxLastname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TBoxFirstname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TBoxPatronymic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TBoxPhoneNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TBoxPosition = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ButtonAddSporsman = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            
            #line 121 "..\..\..\Pages\DataStaff.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
