﻿#pragma checksum "..\..\..\Pages\AddTournament.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0C38129D68BC65C762CCA856EBB87C58DB64FC9D47831A5F35326C0B6D7C0142"
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
    /// AddTournament
    /// </summary>
    public partial class AddTournament : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\Pages\AddTournament.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxName;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Pages\AddTournament.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBoxCity;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Pages\AddTournament.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBoxStreet;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Pages\AddTournament.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxHomeNumber;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Pages\AddTournament.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxStart;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Pages\AddTournament.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxEnd;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Pages\AddTournament.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBoxSortOfSport;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\Pages\AddTournament.xaml"
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
            System.Uri resourceLocater = new System.Uri("/knightApp;component/pages/addtournament.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\AddTournament.xaml"
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
            this.TBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.CBoxCity = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.CBoxStreet = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.TBoxHomeNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TBoxStart = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TBoxEnd = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.CBoxSortOfSport = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.ButtonAddSporsman = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\Pages\AddTournament.xaml"
            this.ButtonAddSporsman.Click += new System.Windows.RoutedEventHandler(this.ButtonAddTournament_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 114 "..\..\..\Pages\AddTournament.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
