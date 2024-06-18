using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIC.Data;

namespace TIC.Time
{
    internal class TimeHandler
    {
        TimeZoneInfo timeZone;
        string timeZoneId = "Russian Standard Time";

        public int UnlockHour;
        public int LockHour;

        public TimeHandler(AppConfig config)
        {
            UnlockHour = config.UnlockHour;
            LockHour = config.LockHour;

            timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        }

        public bool IsPlayTime()
        {

            DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, timeZone);

            return currentTime.Hour >= UnlockHour && currentTime.Hour <= LockHour;
        }
    }
}
