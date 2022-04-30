using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using ArpLookup;
using System.Net;
using System.Threading;

namespace Cobra_Scanner
{
    internal class clsMacFinder
    {
        //flag
        public bool done = false;

        Thread thr;

        //lists for processing
        public List<string> macs = new List<string>();
        public List<string> ipAddresses = new List<string>();

        public clsMacFinder()
        {
            thr = new Thread(this.macFinder);
            thr.Name = "macFinder";
        }

        public void start()
        {
            thr.Start();
        }

        private void macFinder()
        {
            //set mac list equal to ip list
            macs = ipAddresses;

            //look up mac for every ip in list
            for (int counter = 0; counter < ipAddresses.Count; counter++)
            {
                //create string
                string temp = "";
                temp += ipAddresses[counter];

                //store lookup task
                var task = oneMac(ipAddresses[counter], counter);


            }


                //run on compoletion
                done = true;
            thr.Abort();
            
        }

        private async Task oneMac(string ip, int index)
        {
            //get host name
            PhysicalAddress mac = await Arp.LookupAsync(IPAddress.Parse(ip));

            //store in list
            if(mac != null)
            {
                macs[index] = mac.ToString();
            }
            else
            {
                macs[index] = "";
            }
            

        }

        public void listSetter(List<string> _ipAddresses)
        {
            //set ip list to specified list
            ipAddresses = _ipAddresses;
        }

        public List<string> returnMacs()
        {
            //return mac list
            return macs;
        }
    }
}
