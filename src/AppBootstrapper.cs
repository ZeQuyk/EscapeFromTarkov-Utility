﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Caliburn.Micro;
using EscapeFromTarkov.Utility.Services;
using EscapeFromTarkov.Utility.ViewModels;

namespace EscapeFromTarkov.Utility
{
    class AppBootstrapper : BootstrapperBase
    {
        private SimpleContainer container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            this.container = new SimpleContainer();
            container.PerRequest<ShellViewModel, ShellViewModel>();
            container.PerRequest<MapSelectorViewModel, MapSelectorViewModel>();
            container.PerRequest<MapViewModel, MapViewModel>();
            container.PerRequest<IMapsService, MapsService>();
            container.Singleton<IWindowManager, WindowManager>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}
