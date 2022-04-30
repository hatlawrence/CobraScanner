using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cobra_Scanner
{
    internal class clsHostFinder
    {
        //flag
        public bool done = false;

        //thread
        private Thread thr;


        //make lists and vars
        public List<string> hostnames = new List<string>();
        public List<string> ipAddresses = new List<string>();

        public clsHostFinder()
        {
            thr = new Thread(this.hostSweeper);
            thr.Name = "hostSweeper";

        }

        public void start()
        {
            thr.Start();
        }

        private void hostSweeper()
        {
            

            //look up hostname for every ip in list
            for (int counter = 0; counter < ipAddresses.Count; counter++)
            {
                //create host entry from index
                //create string
                string temp = "";
                temp += ipAddresses[counter];

                //create ip
                IPAddress tempAddress = IPAddress.Parse(temp);

                //create host entry obj
                IPHostEntry tempHost = new IPHostEntry();

                //lookup task
                var task = oneHost(tempAddress, tempHost, counter);


            }

            //code to run on completion
            done = true;
            thr.Abort();

        }

        private async Task oneHost(IPAddress address, IPHostEntry hostname, int index)
        {
            hostnames[index] = "";
            hostname = await Dns.GetHostEntryAsync(address.ToString()).ConfigureAwait(false);

            if (hostname.HostName.ToString() != null)
            {
                hostnames[index] = hostname.HostName.ToString();
                Console.WriteLine(hostname.HostName.ToString());
            }
            else
            {
                //not found
                hostnames[index] = "";
            }

        }


        public void listSetter(List<string> _ipAddresses)
        {
            //set ip list to specified list
            ipAddresses = _ipAddresses;

            //set hostname list equal to ip list
            hostnames = _ipAddresses;

        }

        public List<string> returnHosts()
        {
            //give hostnames back
            return hostnames;
        }
    }
}
