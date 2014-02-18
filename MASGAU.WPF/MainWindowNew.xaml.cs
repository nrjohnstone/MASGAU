﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using MVC.Communication;
using MVC.WPF;
using SMJ.WPF.Effects;
using Translator;
using Translator.WPF;
using MASGAU.Helpers;
namespace MASGAU.Main {
    /// <summary>
    /// Interaction logic for MainWindowNew.xaml
    /// </summary>
    public partial class MainWindowNew : NewWindow, IWindow {
        MainProgramHandler masgau;
        NotifierIcon notifier;

        public MainWindowNew() {
            InitializeComponent();

            ribbon.SelectedIndex = 0;

            gamesLst.TemplateItem = new GameListViewItem();
            ArchiveList.TemplateItem = new ArchiveListViewItem();


            notifier = new NotifierIcon(this);
            this.AllowDrop = true;
            this.Drop += new System.Windows.DragEventHandler(MainWindowNew_Drop);

            VersionLabel.Content = Strings.GetLabelString("MASGAUAboutVersion", Core.ProgramVersion.ToString());

            if (Core.Ready)
                this.DataContext = Core.settings;

            TranslationHelpers.translateWindow(this);

            //if (SynchronizationContext.Current == null)
            //    SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext(this.Dispatcher));
            //_context = SynchronizationContext.Current;

            //CommunicationHandler.addReceiver(this);

            WPFCommunicationHelpers.default_progress_color = progress.Foreground;

            // Insert code required on object creation below this point.

            appMenu.SmallImageSource = this.Icon;

            this.Loaded += new System.Windows.RoutedEventHandler(WindowLoaded);
            this.Closing += new CancelEventHandler(Window_Closing);
            this.SourceInitialized += new EventHandler(WindowSourceInitialized);

            AllUsersModeButton.ToolTip = Strings.GetToolTipString("AllUserModeButton");
            SingleUserModeButton.ToolTip = Strings.GetToolTipString("SingleUserModeButton");


            masgau = new MainProgramHandler(new Location.LocationsHandler());
            setupJumpList();
        }

        #region Window event handlers
        void Window_Closing(object sender, CancelEventArgs e) {
            _available = false;
        }
        #endregion

        #region Program handler setup
        protected virtual void WindowLoaded(object sender, System.Windows.RoutedEventArgs e) {
            if (!Core.Ready) {
                this.Close();
                return;
            }

            switch (Core.settings.WindowState) {
                case global::Config.WindowState.Iconified:
                    this.ShowInTaskbar = false;
                    this.Visibility = System.Windows.Visibility.Hidden;
                    break;
            }

            setUpProgramHandler();
        }
        protected virtual void WindowSourceInitialized(object sender, EventArgs e) {
            WinMaximizeHelper.AttachHandler(this);
        }
        protected virtual void setUpProgramHandler() {
            this.Title = masgau.program_title;
            disableInterface();
            gamesLst.DataContext = Games.DetectedGames;
            gamesLst.Model = Games.DetectedGames;

            AllUsersModeButton.DataContext = masgau;


            ArchiveList.DataContext = null;



            masgau.RunWorkerCompleted += new RunWorkerCompletedEventHandler(setup);
            masgau.RunWorkerAsync();
        }

        protected virtual void setup(object sender, RunWorkerCompletedEventArgs e) {
            this.enableInterface();
            if (e.Error != null) {
                this.Close();
            }


            bindSettingsControls();


            OpenBackupFolder.DataContext = Core.settings;
            OpenBackupFolderTwo.DataContext = Core.settings;
            monitorStatusLabel.DataContext = Core.monitor;

            setupSteamButton();
            populateAltPaths();
            setupMonitorIcon();

            if (!Core.initialized) {
                MVC.Translator.TranslatingMessageHandler.SendException(new TranslateableException("CriticalSettingsFailure"));
                this.Close();
            }
            this.Title = masgau.program_title;
            addGameSetup();
            this.checkUpdates();
        }
        #endregion

        #region About stuff

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
        }

        #endregion


        private void RibbonButton_Click(object sender, RoutedEventArgs e) {
            redetectGames();
        }


        private void ExitButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Window_Closing_1(object sender, CancelEventArgs e) {

            cancelWorkers();
            notifier.Visible = false;
            notifier.Dispose();
        }



        private void endOfOperations() {
            ProgressHandler.restoreMessage();
            ProgressHandler.value = 0;
            enableInterface();
        }


        private void OpenBackupFolder_Click(object sender, RoutedEventArgs e) {
            Core.openBackupPath();
        }

        private void ChangeBackupFolder_Click(object sender, RoutedEventArgs e) {
            if (this.changeBackupPath())
                askRefreshGames("RefreshForChangedBackupPath");
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

        }


        public void updateWindowState() {
            if (!this.ShowInTaskbar)
                Core.settings.WindowState = global::Config.WindowState.Iconified;
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e) {
            toggleMinimize();
            updateWindowState();
        }

        private void maximizeButton_Click(object sender, RoutedEventArgs e) {
            if (this.WindowState == System.Windows.WindowState.Maximized) {
                this.WindowState = System.Windows.WindowState.Normal;
            } else {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            updateWindowState();

        }

        private void closeButton_Click(object sender, RoutedEventArgs e) {
            this.toggleVisibility();
            notifier.sendBalloon(Strings.GetMessageString("RunningInTray"));
        }

        private void SingleUserModeButton_Click(object sender, RoutedEventArgs e) {
            if (!System.IO.File.Exists(Core.ExecutableName)) {
                this.showTranslatedError("FileNotFoundCritical", Core.ExecutableName);
                return;
            }

            toggleVisibility();
            if (SecurityHandler.elevation(Core.ExecutableName, "-allusers", false) == ElevationResult.Success)
                this.Close();
            else
                toggleVisibility();
        }

        private void AllUsersModeButton_Click(object sender, RoutedEventArgs e) {
            if (!System.IO.File.Exists(Core.ExecutableName)) {
                this.showTranslatedError("FileNotFoundCritical", Core.ExecutableName);
                return;
            }


            toggleVisibility();
            if (SecurityHandler.runExe(Core.ExecutableName, "", false, false) == ElevationResult.Success)
                this.Close();
            else
                toggleVisibility();

        }

        private void gameSaveLink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e) {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        protected void openSubWindow(System.Windows.Controls.Grid grid) {
            ribbon.IsEnabled = false;
            GameGrid.IsEnabled = false;
            ArchiveGrid.IsEnabled = false;
            FadeEffect fade = new FadeInEffect(timing);
            fade.Start(grid);

        }
        protected void closeSubWindow(System.Windows.Controls.Grid grid) {
            FadeEffect fade = new FadeOutEffect(timing);
            fade.Start(grid);
            ribbon.IsEnabled = true;
            GameGrid.IsEnabled = true;
            ArchiveGrid.IsEnabled = true;

        }

        private void AboutButton_Click(object sender, RoutedEventArgs e) {
            openSubWindow(AboutGrid);

        }

        private void AboutCloseButton_Click(object sender, RoutedEventArgs e) {
            closeSubWindow(AboutGrid);

        }

        private void RibbonMenuItem_Click(object sender, RoutedEventArgs e) {

        }

        private void PurgeGameButton_Click(object sender, RoutedEventArgs e) {
            Games.purgeGames(gamesLst.SelectedItems, purgeDone);
        }
        protected virtual void purgeDone(object sender, RunWorkerCompletedEventArgs e) {
            if (((bool)e.Result) == true) {
                this.askRefreshGames("RefreshForPurge");

            }
        }

        private void PurgeGameArchivesButton_Click(object sender, RoutedEventArgs e) {

        }

        private void ReportButton_Click(object sender, RoutedEventArgs e) {
            ReportProblemWindow prob = new ReportProblemWindow(this);
            prob.ShowDialog();
        }



    }
}
