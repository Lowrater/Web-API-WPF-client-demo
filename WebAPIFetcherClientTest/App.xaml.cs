using ApiLibary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WebAPIFetcherClientTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //-- Reference for the C# Class libary of APIHelper to Initialize the webApi client.
            APIHelper.InitializeClient();
        }
    }
}
