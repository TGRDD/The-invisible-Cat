using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;
using TIC.Data;
using TIC.Procceses;
using TIC.Time;

namespace TICservice
{

    public partial class MainService : ServiceBase
    {
        public static List<string> ProccesNames = new List<string>();
        private static System.Timers.Timer timer = new System.Timers.Timer(10);

        private static AppConfig config = new AppConfig(ProccesNames, unlockHour: 17, lockHour: 23);
        private static TimeHandler timeHandler = new TimeHandler(config);
        private static ProccesHandler proccesHandler = new ProccesHandler(config);

        public MainService()
        {
            InitializeComponent();
        }

        protected override async void OnStart(string[] args)
        {
            FillList();

            while (true)
            {
                CheckAndExecute();
                await Task.Delay(10000);
            }
        }

        protected override void OnStop()
        {
            timer.Stop();
        }


        private static void CheckAndExecute()
        {
            if (!timeHandler.IsPlayTime())
            {
                Console.WriteLine("You are not allowed to play");
                proccesHandler.ExecuteAll();
            }
        }

        private static void FillList()
        {
            ProccesNames.Add("DDNet");
            ProccesNames.Add("DDNet Client");
            ProccesNames.Add("War Selection");
            ProccesNames.Add("SteamLauncher");
            ProccesNames.Add("GlyphEngine");
        }

        
    }
}
