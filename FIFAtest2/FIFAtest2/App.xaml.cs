﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Backend;
using Backend.Xml;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace FIFAtest2
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        /// 
        public List<league> Leagues { get; set; }
        public List<Player> Players { get; set; }

        public static App Instance;
        public App()
        {
            Instance = this;
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            Players = new List<Player>();
            Players.Add(new Player("anders"));
            Players.Add(new Player("SindreKING"));
            //Players.Add(new Player("MarkuScrub"));
            //Players.Add(new Player("LeftEye"));
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                GenerateLeague();
            }
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            // Do not repeat app initialization when already running, just ensure that
            // the window is active
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
            {
                Window.Current.Activate();
                return;
            }

            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                //TODO: Load state from previously suspended application
            }

            // Create a Frame to act navigation context and navigate to the first page
            var rootFrame = new Frame();
            if (!rootFrame.Navigate(typeof(MainPage)))
            {
                throw new Exception("Failed to create initial page");
            }

            // Place the frame in the current Window and ensure that it is active
            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        void GenerateLeague()
        {
            Leagues = new List<league>();
            for (int i = 1; i <= 32; i++)
            {
                league temp = ObjectSerializer.FromXML<league>("http://fifaapi.com/league/" + i + ".xml");
                Leagues.Add(temp);
            }
        }
    }
}
