﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
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

namespace FIFATournamentRC
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
        public List<league> Leagues { get; set; }
        public List<Player> Players { get; set; }
        public ObservableCollection<Player> OCPlayers { get; set; }

        public static App Instance;
        public App()
        {
            Instance = this;
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            Players = new List<Player>();
            OCPlayers = new ObservableCollection<Player>();
            Leagues = new List<league>();

            OCPlayers.Add(new Player());
            OCPlayers.Add(new Player());
            OCPlayers.Add(new Player());

        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(BufferPage), args.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            SettingsPane.GetForCurrentView().CommandsRequested += App_CommandsRequested;
            // Ensure the current window is active
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

        void App_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            var about = new SettingsCommand("about", "About", (handler) =>
            {
                var settings = new Common.SettingsFlyout();
                settings.ShowFlyout(new AboutUserControl());
            });
         
            args.Request.ApplicationCommands.Add(about);
            
            var privacy = new SettingsCommand("privacy", "Privacy", (handler) =>
                {
                    var settings = new Common.SettingsFlyout();
                    settings.ShowFlyout(new PrivacyUserControl());
                });

            args.Request.ApplicationCommands.Add(privacy);
      
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

        async void CheckNetwork()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                GenerateLeague();
            }
            else
            {
                var md = new MessageDialog("No network connection found");
                md.Commands.Add(new UICommand("Try again", (UICommandInvokedHandler) =>
                {
                    CheckNetwork();
                }));

                md.Commands.Add(new UICommand("Exit", (UICommandInvokedHandler) =>
                {
                    App.Current.Exit();
                }));

                await md.ShowAsync();
            }
        }
    }
}