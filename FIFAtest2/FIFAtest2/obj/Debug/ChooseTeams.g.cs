﻿

#pragma checksum "C:\Users\aa206\Documents\GitHub\AppathonFT\FIFAtest2\FIFAtest2\ChooseTeams.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FC3FC425E862E0257B32E45C27D1E1E5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIFAtest2
{
    partial class BasicPage2 : global::FIFAtest2.Common.LayoutAwarePage, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 74 "..\..\ChooseTeams.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GenerateFixtures;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 41 "..\..\ChooseTeams.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GoBack;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 70 "..\..\ChooseTeams.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.LeagueListSelected;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 71 "..\..\ChooseTeams.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.ClubListSelected;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


