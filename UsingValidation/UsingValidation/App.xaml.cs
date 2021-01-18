﻿using System;
using UsingValidation.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsingValidation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage =  new NavigationPage(new EntryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
