﻿using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using MinecraftLauncher.Helpers;
using MinecraftLauncher.Pages;
using ModuleLauncher.Re.Authenticators;
using ModuleLauncher.Re.Models.Authenticators;
using ModuleLauncher.Re.Utils.Extensions;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MinecraftLauncher.Control
{
    public sealed partial class LoginDialog : ContentDialog
    {
        public LoginDialog()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter && !string.IsNullOrEmpty(Username.Text) && !string.IsNullOrEmpty(Password.Password))
            {
                ContentDialog_PrimaryButtonClick(sender as ContentDialog, null);
            }
        }

        [Obsolete]
        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            MojangAuthenticator Mojang = new(Username.Text, Password.Password);
            AuthenticateResult Result = await Mojang.Authenticate();
            if (await Result.Validate())
            {
                SettingsHelper.Set("AccessToken", Result.AccessToken);
                SettingsHelper.Set("ClientToken", Result.ClientToken);
                if (UIHelper.MainPage != null)
                {
                    UIHelper.MainPage.UserNames = Result.Name;
                }
            }
        }
    }
}
