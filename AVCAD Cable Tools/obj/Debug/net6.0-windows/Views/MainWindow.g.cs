#pragma checksum "..\..\..\..\Views\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D0A712FBD2B9EAECAA265B9E4116F9AD4BB201F7"
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
using System.Windows.Controls.Ribbon;
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


namespace AVCAD.Views {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AVCAD.Views.MainWindow MainProgramWindow;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame CableListFrame;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame CableTypesFrame;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame CableReelsFrame;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame SettingsFrame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AVCAD Cable Tools;component/views/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MainProgramWindow = ((AVCAD.Views.MainWindow)(target));
            return;
            case 2:
            this.CableListFrame = ((System.Windows.Controls.Frame)(target));
            
            #line 16 "..\..\..\..\Views\MainWindow.xaml"
            this.CableListFrame.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(this.CableListFrame_LoadCompleted);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CableTypesFrame = ((System.Windows.Controls.Frame)(target));
            
            #line 20 "..\..\..\..\Views\MainWindow.xaml"
            this.CableTypesFrame.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(this.CableTypesFrame_LoadCompleted);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CableReelsFrame = ((System.Windows.Controls.Frame)(target));
            
            #line 25 "..\..\..\..\Views\MainWindow.xaml"
            this.CableReelsFrame.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(this.CableReelsFrame_LoadCompleted);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SettingsFrame = ((System.Windows.Controls.Frame)(target));
            
            #line 28 "..\..\..\..\Views\MainWindow.xaml"
            this.SettingsFrame.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(this.SettingsFrame_LoadCompleted);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

