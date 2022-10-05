﻿using Microsoft.UI.Xaml;
using UMCLauncher.Helpers;
using UMCLauncher.Pages;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UMCLauncher
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public BackdropHelper Backdrop;

        public MainWindow()
        {
            InitializeComponent();
            Backdrop = new BackdropHelper(this);
            UIHelper.MainWindow = this;
            MainPage MainPage = new();
            Content = MainPage;
            SetBackdrop();
        }

        private void SetBackdrop()
        {
            BackdropType type = SettingsHelper.Get<BackdropType>(SettingsHelper.SelectedBackdrop);
            Backdrop.SetBackdrop(type);
        }
    }
}
