﻿#pragma checksum "..\..\..\Pages\DataTeams.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "464A04FFA73549A2532F34FA1033ADFC97E000AFAB07A59AFF9A93FE700BCEF8"
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
    /// DataTeams
    /// </summary>
    public partial class DataTeams : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\..\Pages\DataTeams.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxId;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Pages\DataTeams.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxName;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Pages\DataTeams.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListAthletesInTeam;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Pages\DataTeams.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBoxTransferNumber;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Pages\DataTeams.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonPDFSportsman;
        
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
            System.Uri resourceLocater = new System.Uri("/knightApp;component/pages/datateams.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\DataTeams.xaml"
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
            
            #line 10 "..\..\..\Pages\DataTeams.xaml"
            ((knightApp.Pages.DataTeams)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\Pages\DataTeams.xaml"
            ((knightApp.Pages.DataTeams)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.Page_Unloaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TBoxId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ListAthletesInTeam = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.CBoxTransferNumber = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.ButtonPDFSportsman = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\Pages\DataTeams.xaml"
            this.ButtonPDFSportsman.Click += new System.Windows.RoutedEventHandler(this.ButtonPDFTeam_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 99 "..\..\..\Pages\DataTeams.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
