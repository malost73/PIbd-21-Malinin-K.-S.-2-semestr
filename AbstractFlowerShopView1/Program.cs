﻿using System;
using System.Windows.Forms;
using AbstractFlowerShopServiceImplementList.Implementations;
using AbstractFlowerShopServiceDAL.Interfaces;
using Unity;
using Unity.Lifetime;

namespace AbstractFlowerShopView
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve <MainForm>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ICustomerService, CustomerServiceList>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IElementService, ElementServiceList>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IBouquetService, BouquetServiceList>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IServiceMain, ServiceMainList>(new
            HierarchicalLifetimeManager());
            return currentContainer;
        }

    }
}
