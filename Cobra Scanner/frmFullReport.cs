using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cobra_Scanner
{
    public partial class frmFullReport : Form
    {
        //create lists
        List<string> ipList = new List<string>();
        List<string> hostnameList = new List<string>();
        List<string> macList = new List<string>();

        public frmFullReport()
        {
            InitializeComponent();
        }
        
        public frmFullReport(List<string> _ipList, List<string> _hostnameList, List<string> _macList)
        {
            InitializeComponent();
            //set lists
            ipList = _ipList;
            hostnameList = _hostnameList;
            macList = _macList;

            //load it up
            onFullReportLoad();

        }

        /// <summary>
        /// Builds the report - called on form load
        ///
        /// </summary>
        public void onFullReportLoad()
        {
            //build header
            string strFullReportHeader;
            strFullReportHeader = "<HTML><HEAD><TITLE>Full Report </TITLE></HEAD>";


            //start body
            string strFullReportBody = "<BODY>";
            strFullReportBody += "<H1>All Active Clients</H1>";
            strFullReportBody += "<hr/>";
            strFullReportBody += "<br/>";

            //enter ordered list
            strFullReportBody += "<ol>";

            //loop through all items in our object list from db
            for (int counter = 0; counter < ipList.Count; counter++)
            {
                //create individual list item for ordered list
                string listItem;
                listItem = "<li>";


                //begin unordered list inside list item
                listItem += "<ul>";

                //add each piece as an item in unordered list
                listItem += "<li><b>IP: </b>" + ipList[counter].ToString() + "</li>";
                listItem += "<li><b>Hostname: </b>" + hostnameList[counter].ToString() + "</li>";
                listItem += "<li><b>Mac: </b>" + macList[counter].ToString() + "</li>";

                //close unordered list
                listItem += "</ul>";

                //close ordered list item
                listItem += "</li>";

                //add list item to body
                strFullReportBody += listItem;
            }


            //close html
            strFullReportBody += "</BODY></HTML>";

            //create html doc
            string htmlDocument = strFullReportHeader + strFullReportBody;

            //display in browser control
            webFullReport.DocumentText = htmlDocument;


        }
    }
}
