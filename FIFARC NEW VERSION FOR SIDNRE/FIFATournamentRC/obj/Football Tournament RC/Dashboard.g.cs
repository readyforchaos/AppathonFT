﻿

#pragma checksum "C:\Users\Andy\Desktop\FIFATournamentRC\FIFATournamentRC\Dashboard.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BBAB1342BD5A709978B3F1434174437E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIFATournamentRC
{
    partial class Dashboard : global::FIFATournamentRC.Common.LayoutAwarePage, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 108 "..\..\Dashboard.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnSwap_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 87 "..\..\Dashboard.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.MatchList_Selected;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 79 "..\..\Dashboard.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.Player1TeamSubstract_Tapped;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 70 "..\..\Dashboard.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.Player1TeamPlus_Tapped;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 61 "..\..\Dashboard.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.Player2TeamSubstract_Tapped;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 55 "..\..\Dashboard.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.Player2TeamPlus_Tapped;
                 #line default
                 #line hidden
                break;
            case 7:
                #line 41 "..\..\Dashboard.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.MatchList_Selected;
                 #line default
                 #line hidden
                break;
            case 8:
                #line 50 "..\..\Dashboard.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnMatch_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


