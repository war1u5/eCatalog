#pragma checksum "..\..\WindowAfterLoginStudent.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E94DF069A9E751426116D9A9EA5F97A617854BE7033926B5A34BB8E581EBD408"
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
using eCatalog;
using eCatalog.MVVM.ViewModel;


namespace eCatalog {
    
    
    /// <summary>
    /// WindowAfterLoginStudent
    /// </summary>
    public partial class WindowAfterLoginStudent : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\WindowAfterLoginStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border myBackground;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\WindowAfterLoginStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock WelcomeText;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\WindowAfterLoginStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MinimizeBtn;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\WindowAfterLoginStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitBtn1;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\WindowAfterLoginStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton NoteBtn;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\WindowAfterLoginStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton DetaliiBtn;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\WindowAfterLoginStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton DarkBtn;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\WindowAfterLoginStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton LogoutBtn;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\WindowAfterLoginStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border MenuBorder;
        
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
            System.Uri resourceLocater = new System.Uri("/eCatalog;component/windowafterloginstudent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowAfterLoginStudent.xaml"
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
            this.myBackground = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.WelcomeText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.MinimizeBtn = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\WindowAfterLoginStudent.xaml"
            this.MinimizeBtn.Click += new System.Windows.RoutedEventHandler(this.MinimizeBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ExitBtn1 = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\WindowAfterLoginStudent.xaml"
            this.ExitBtn1.Click += new System.Windows.RoutedEventHandler(this.ExitBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NoteBtn = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.DetaliiBtn = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.DarkBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 111 "..\..\WindowAfterLoginStudent.xaml"
            this.DarkBtn.Click += new System.Windows.RoutedEventHandler(this.DarkBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.LogoutBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 119 "..\..\WindowAfterLoginStudent.xaml"
            this.LogoutBtn.Click += new System.Windows.RoutedEventHandler(this.LogoutBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.MenuBorder = ((System.Windows.Controls.Border)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

