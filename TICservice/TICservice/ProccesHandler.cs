using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TIC.Data;


namespace TIC.Procceses
{
    internal class ProccesHandler
    {
        public List<string> ProccesNames;

        public ProccesHandler() 
        { 
            ProccesNames = new List<string>();
        }

        public ProccesHandler(AppConfig appConfig) 
        { 
            ProccesNames = appConfig.ProccesNames;
        }

        public void ExecuteAll()
        {
            foreach (string ProccesName in ProccesNames)
            {
                Execute(ProccesName);
            }
        }

        public void Execute(string ProccesName)
        {
            Process[] proc = Process.GetProcessesByName(ProccesName);

            if (proc == null) return;

            foreach (var procInfo in proc)
            {
                procInfo.Kill();
            }
        }
    }
}
