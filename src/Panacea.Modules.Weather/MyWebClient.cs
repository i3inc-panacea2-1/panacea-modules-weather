using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Panacea.Modules.Weather
{
    public class MyWebClient : WebClient
    {
        public static bool Timeout { get; private set; }
        private void TimerProc(object state)
        {
            Timeout = true;
            CancelAsync();
            ((Timer)state).Dispose();
        }

        public Task<string> DownloadStringTaskAsync(uint tout, Uri address)
        {

            Timeout = false;
            var task = DownloadStringTaskAsync(address);
            if (tout > 0)
            {
                new Timer(new TimerCallback(TimerProc)).Change(tout, 0);
            }
            return task;
        }
        public new void CancelAsync()
        {
            base.CancelAsync();
        }

    }
}
