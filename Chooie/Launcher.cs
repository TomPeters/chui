﻿using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Owin.Hosting;
using Chooie.SignalR;

namespace Chooie
{
    public class Launcher
    {
        private const string SignalRUrl = "http://+:8080/";

        public static void Main(string[] args)
        {
            try
            {
                new UrlAclConfigurer().ConfigureUrl(SignalRUrl);
                WebApp.Start<SignalRStartup>(SignalRUrl);

                var applicationContext = new ChooieApplicationContext();
                Application.Run(applicationContext);
            }
            catch (Exception ex)
            {
                var file = new StreamWriter("log.txt");
                file.WriteLine(ex.Message);
                file.WriteLine(ex.StackTrace);
                file.WriteLine(ex.InnerException.Message);
                file.Close();
            }
        }
    }
}