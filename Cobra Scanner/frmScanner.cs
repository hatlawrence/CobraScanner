using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;

namespace Cobra_Scanner
{
    public partial class frmScanner : Form
    {
        /// <summary>
        /// Adjustable variable for length of time to wait for hostname responses
        /// </summary>
        //time to wait for host name lookups (max 55 seconds)
        public static int hostnameWaitTime = 15;
        public frmScanner()
        {
            
            InitializeComponent();
            // If directory does not exist, create it
            if (!Directory.Exists(clsFilePath.directoryRoot))
            {
                Directory.CreateDirectory(clsFilePath.directoryRoot);
            }
            lstSubnets.Items.Add("");
        }

        /// <summary>
        /// Function to load the subnets from the text file
        /// </summary>
        public void loadSubnets()
        {
            //clear the list box
            lstSubnets.Items.Clear();

            //counter to throw warning about MAC for multi-subnet networks
            int subnetcounter = 0;

            //load the subnets into the list box from c:\ITS\subnets.txt
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor


                StreamReader textfile = new StreamReader(clsFilePath.subnetFilePath);


                //Read first line
                line = textfile.ReadLine();



                //Continue to read until you reach end of file
                while (line != null)
                {
                    //add line to list box
                    lstSubnets.Items.Add(line);

                    //get next line
                    line = textfile.ReadLine();

                    //counter up
                    subnetcounter += 1;



                }

                //close subnet doc
                textfile.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }

            //show warning if there is more than 1
            if (subnetcounter > 1)
            {
                string multiMessage = "Multiple subnets are being scanned. MAC address may not be accurate for clients on a different subnet.";
                MessageBox.Show(multiMessage);
            }

            //set prog bar
            pgbScanner.Minimum = 0;
            pgbScanner.Value = 0;
            pgbScanner.Maximum = lstSubnets.Items.Count;
        }

        /// <summary>
        /// Method for scanning all of the subnets and getting ip addresses
        /// Uses clsPinger
        /// </summary>
        /// <param name="subnetBase"></param>
        public void scanSubnets(string subnetBase)
        {
            //create scanner
            clsPinger pingsweeper = new clsPinger(subnetBase);
            pingsweeper.start();

            while (pingsweeper.done == false)
            {
                //do nothing
            }

            //wait to make sure list populated
            //501 ms because ping time is 500ms in clsPinger
            //updated to 1000 for now
            Thread.Sleep(1001);

            //create list
            List<string> ipaddresses = new List<string>();

            //get list from scanner
            ipaddresses = pingsweeper.returnAddresses();

            //enter loop
            for (int counter = 0; counter < ipaddresses.Count; counter++)
            {
                //create row
                DataGridViewRow row = (DataGridViewRow)dgvHosts.Rows[0].Clone();

                //add data
                row.Cells[0].Value = ipaddresses[counter];

                //add to datagridview
                dgvHosts.Rows.Add(row);

                //refresh
                dgvHosts.Refresh();
            }
        }

        /// <summary>
        /// Method that calls all of the scanner methods and also updates the progress bar
        /// </summary>
        public void scanNetwork()
        {
            //prog bar reset
            pgbScanner.Refresh();
            pgbScanner.Value = 0;

            //keep track of time
            Stopwatch tracker = new Stopwatch();
            tracker.Start();

            //reset
            pgbScanner.Value = 1;
            dgvHosts.Rows.Clear();

            for (int counter = 0; counter < lstSubnets.Items.Count; counter++)
            {
                //cycle through indexes
                lstSubnets.SelectedIndex = counter;

                //set progress bar value to one above counter, save 1
                if (counter < (lstSubnets.Items.Count - 1))
                {
                    if (pgbScanner.Value < pgbScanner.Maximum)
                    {
                        pgbScanner.Value = pgbScanner.Value + 1;
                    }

                }


                //refresh bar
                pgbScanner.Refresh();

                //calculate percentage for prog bar
                double progPerc = 100 * (((double)pgbScanner.Value - 1) / (double)pgbScanner.Maximum);

                //format correctly
                progPerc = Math.Truncate(100 * progPerc) / 100;

                //add text to label
                lblProg.Text = "IP scanning " + progPerc.ToString() + "%...";

                //refresh label text
                lblProg.Refresh();

                //get subnet base
                string subnetstring = lstSubnets.Items[counter].ToString();

                //send subnet base and start scan
                scanSubnets(subnetstring);

            }
            //add text to label
            lblProg.Text = "Getting hostnames (we wait for response for " + hostnameWaitTime.ToString() + " seconds)...";

            //refresh label text
            lblProg.Refresh();

            //get hostnames
            getHostNames();

            //move progress
            if (pgbScanner.Value < pgbScanner.Maximum)
            {
                pgbScanner.Value = pgbScanner.Value + 1;
            }

            //refresh bar
            pgbScanner.Refresh();

            //add text to label
            lblProg.Text = "Getting macs...";

            //refresh label text
            lblProg.Refresh();

            //get macs
            getMacs();

            //stop timer
            tracker.Stop();

            //get timespan
            TimeSpan elapsedHostScanTime = tracker.Elapsed;

            //format time string
            string totalTime = String.Format("{0:00} hours, {1:00} minutes,{2:00}.{3:00} seconds!",
            elapsedHostScanTime.Hours, elapsedHostScanTime.Minutes, elapsedHostScanTime.Seconds,
            elapsedHostScanTime.Milliseconds / 10);

            //create message box string
            int hostCount = 0;
            hostCount = (dgvHosts.Rows.Count - 1);
            string finishedMessage = hostCount.ToString();
            finishedMessage += " hosts scanned in " + totalTime;
            finishedMessage += "\nCobra Quick.";

            //add text to label
            lblProg.Text = "Done!";

            //set prog bar to max
            pgbScanner.Value = pgbScanner.Maximum;

            //deselect index
            lstSubnets.SelectedIndex = -1;

            //show user
            MessageBox.Show(finishedMessage);

        }

        /// <summary>
        /// Method to get all of the hostnames based on active IP addresses
        /// Uses clsHostFinder
        /// </summary>
        public void getHostNames()
        {

            //get list of IPS
            List<string> ipList = new List<string>();

            //dump ips
            for (int counter = 0; counter < (dgvHosts.Rows.Count - 1); counter++)
            {
                string line = "";
                if (dgvHosts.Rows[counter].Cells[0].Value.ToString() != null)
                {
                    line += dgvHosts.Rows[counter].Cells[0].Value.ToString();
                    ipList.Add(line);
                }

            }

            //create sweeper
            clsHostFinder hostSweeper = new clsHostFinder();

            //set list
            hostSweeper.listSetter(ipList);

            //run scanner
            hostSweeper.start();

            //send out requests and wait for all of them to be sent
            while (hostSweeper.done == false)
            {
                //nothing
            }

            //wait for hostname requests to come back
            int msHostnameWaitTime = hostnameWaitTime * 1000;
            Thread.Sleep(msHostnameWaitTime);

            //get hostname list
            List<string> hostNames = new List<string>();
            hostNames = hostSweeper.returnHosts();

            //dump host names
            for (int counter = 0; counter < hostNames.Count; counter++)
            {
                dgvHosts.Rows[counter].Cells[1].Value = hostNames[counter];

            }

        }

        /// <summary>
        /// Method to get all of the MAC addresses based on IP
        /// Uses clsMacFinder
        /// </summary>
        public void getMacs()
        {
            //get list of IPS
            List<string> ipList = new List<string>();

            //dump ips
            for (int counter = 0; counter < (dgvHosts.Rows.Count - 1); counter++)
            {
                string line = "";
                line += dgvHosts.Rows[counter].Cells[0].Value.ToString();
                ipList.Add(line);
            }

            //create mac finder
            clsMacFinder macSweeper = new clsMacFinder();

            //set list
            macSweeper.listSetter(ipList);

            //run scanner
            macSweeper.start();

            //wait for completion//wait for completeion
            while (macSweeper.done == false)
            {
                //nothing
            }
            //wait for 50 ms - not long - we are just scannign local ARP tables
            Thread.Sleep(50);

            //get list
            List<string> macs = new List<string>();
            macs = macSweeper.returnMacs();

            //dump macs
            for (int counter = 0; counter < macs.Count; counter++)
            {
                dgvHosts.Rows[counter].Cells[2].Value = macs[counter];

            }
        }

        /// <summary>
        /// Method to add a log entry based on functions performed
        /// </summary>
        /// <param name="userAction"></param>
        public void AddLogEntry(string userAction)
        {
            //method for adding log entries

            //add data and time to entry
            userAction = DateTime.Now.ToString("f") + " | " + userAction;


            //access file and add line with new entry
            using (StreamWriter myW = File.AppendText(clsFilePath.logFilePath))
            {
                myW.WriteLine(userAction);
            }

        }

        /// <summary>
        /// Method for exporting a CSV of the data to the working folder
        /// </summary>
        public void saveCSV()
        {
            if (dgvHosts.Rows.Count > 1)
            {
                //create writer
                StreamWriter textFile = new StreamWriter(clsFilePath.csvFilePath);

                //create column headers
                string columnHeaders = "IP Address, Hostname, MAC";

                //write header line
                textFile.WriteLine(columnHeaders);

                for (int counter = 0; counter < (dgvHosts.Rows.Count - 1); counter++)
                {
                    //get data from row and store in string with commas separating
                    string rowData = dgvHosts.Rows[counter].Cells[0].Value.ToString() + ", " + dgvHosts.Rows[counter].Cells[1].Value.ToString() + ", " + dgvHosts.Rows[counter].Cells[2].Value.ToString();


                    //write line
                    textFile.WriteLine(rowData);
                }

                //close it
                textFile.Close();

                //confirm save
                MessageBox.Show("CSV Saved");
            }
            else
            {
                MessageBox.Show("Empty table...");
            }

        }

        /// <summary>
        /// Method for generating the html report with the data
        /// </summary>
        public void generateReport()
        {
            //create all lists
            List<string> ipReportList = new List<string>();
            List<string> hostnameReportList = new List<string>();
            List<string> macReportList = new List<string>();

            //get list of ips
            for (int counter = 0; counter < (dgvHosts.Rows.Count - 1); counter++)
            {
                //get data from row and store in string with commas separating
                string rowData = "";
                rowData += dgvHosts.Rows[counter].Cells[0].Value.ToString(); 

                //add to list
                ipReportList.Add(rowData);
                
            }

            //get list of hostnames
            for (int counter = 0; counter < (dgvHosts.Rows.Count - 1); counter++)
            {
                //get data from row and store in string with commas separating
                string rowData = "";
                rowData += dgvHosts.Rows[counter].Cells[1].Value.ToString();
                


                //add to list
                hostnameReportList.Add(rowData);
            }

            //get list of macs
            for (int counter = 0; counter < (dgvHosts.Rows.Count - 1); counter++)
            {
                //get data from row and store in string with commas separating
                string rowData = "";
                rowData += dgvHosts.Rows[counter].Cells[2].Value.ToString();


                //add to list
                macReportList.Add(rowData);

            }

            //pass lists to report window and open it
            frmFullReport frmFullReportDisp = new frmFullReport(ipReportList, hostnameReportList, macReportList);
            frmFullReportDisp.ShowDialog();


        }


        private void frmScanner_Load(object sender, EventArgs e)
        {
            //load subnets on startup
            loadSubnets();

            //log action
            AddLogEntry("Application started");
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            //log action
            AddLogEntry("Scan started");

            //scan for IPs, hostnames, macs
            scanNetwork();


            //log action
            AddLogEntry("Scan completed");



        }

        private void btnFullReport_Click(object sender, EventArgs e)
        {
            //get data for report and open window
            generateReport();

            //log action
            AddLogEntry("Full report created");
        }

        

        private void btnLog_Click(object sender, EventArgs e)
        {
            frmLog logForm = new frmLog();
            logForm.ShowDialog();

            //log action
            AddLogEntry("Log opened");
        }

        private void btnSubnets_Click(object sender, EventArgs e)
        {
            frmSubnets subnetsForm = new frmSubnets();
            subnetsForm.ShowDialog();
            loadSubnets();

            //log action
            AddLogEntry("Subnet edit menu opened");
        }

        private void btnRefreshSubnets_Click(object sender, EventArgs e)
        {
            //load subnets on refresh click
            loadSubnets();

            //log action
            //log action
            AddLogEntry("Subnets refreshed");
        }

        private void btnSaveCSV_Click(object sender, EventArgs e)
        {
            //save csv
            saveCSV();

            //log action
            AddLogEntry("CSV saved");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvHosts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
