using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC.Data
{
    internal struct AppConfig
    {
        public List<string> ProccesNames;
        public int UnlockHour;
        public int LockHour;

        public AppConfig(List<string> proccesNames, int unlockHour, int lockHour)
        {
            ProccesNames = proccesNames;
            UnlockHour = unlockHour;
            LockHour = lockHour;
        }
    }
}
