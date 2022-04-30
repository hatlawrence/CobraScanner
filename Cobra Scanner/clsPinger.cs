using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Cobra_Scanner
{
    internal class clsPinger
    {
        //flag
        public bool done = false;

        //threading
        private Thread thr;

        //make lists and vars
        public List<string> ipAdddresses = new List<string>();
        private string _subnetbase = "192.168.50.";
        private int startOct = 1;
        private int endOct = 255;
        private string ip;
        private int pingtime = 1000;

        public clsPinger(string threadName)
        {
            //create thread for sweeper
            thr = new Thread(this.RunPingSweep_Async);
            thr.Name = threadName;
            _subnetbase = threadName;
            
        }

        public void start()
        {
            thr.Start();
        }

        private void RunPingSweep_Async()
        {
            //enter loop to test each address
            for (int counter = startOct; counter <= endOct; counter++)
            {
                //create ip address
                ip = _subnetbase + counter.ToString();

                //create new ping
                Ping p = new Ping();

                //store ping in asynchronous task
                var task = PingTask(p, ip);

            }

            //code to run on completion
            done = true;

            //stop the thread so we can successfully retreive the list from main form
            thr.Abort();

        }

        private async Task PingTask(System.Net.NetworkInformation.Ping myPing, string ip)
        {
            //get reply of ping using await so we run asynchronously
            var pingReply = await myPing.SendPingAsync(ip, pingtime);

            //if it is successful
            if (pingReply.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                //add this ip to list
                ipAdddresses.Add(ip);
            }
        }

        public List<string> returnAddresses()
        {
            //return the list
            return ipAdddresses;
        }
    }
}
