﻿

#pragma checksum "C:\Users\Andy\Documents\GitHub\AppathonFT\FIFAtest2\FIFAtest2\AddPlayers.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6E800F5218F84E2163899DBB4294F18F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace FIFAtest2
{
    partial class BasicPage1 : FIFAtest2.Common.LayoutAwarePage, IComponentConnector
    {
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 114 "..\..\AddPlayers.xaml"
                ((Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Continue;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 101 "..\..\AddPlayers.xaml"
                ((Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Add;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 76 "..\..\AddPlayers.xaml"
                ((Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GoBack;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


