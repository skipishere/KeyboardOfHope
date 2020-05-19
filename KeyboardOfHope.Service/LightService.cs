using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardOfHope.Service
{
    public partial class LightService : ServiceBase
    {
        //private string _baseUrl = "http://localhost:12345/";
        private string _baseUrl = "http://*:8345/";
        private IDisposable _lightServer;

        public LightService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _lightServer = WebApp.Start<Startup>(_baseUrl);
        }

        protected override void OnStop()
        {
            if (_lightServer != null)
            {
                _lightServer.Dispose();
            }
        }
    }
}
