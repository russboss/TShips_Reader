using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private String tFileDir;
        private DialogResult result;
        private PageHandler TFile;
        public Form1()
        {
            InitializeComponent();

            TFile = new PageHandler();
            //init pageHandler
        }

        private void tFile_Click(object sender, EventArgs e)
        {
            //openFileDialog1 is added via [Design] as component
            result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                tFileDir = openFileDialog1.FileName;

                Console.WriteLine(tFileDir);
            }
        }

        private void tShips_Click(object sender, EventArgs e)
        {

        }

        private void readTfile_Click(object sender, EventArgs e)
        {


            Console.WriteLine("Hello");
            if (result == DialogResult.OK) // Test result.
            {

                string file = openFileDialog1.FileName;

                Console.WriteLine("file: {0}", file);
                try
                {
                    int lastPage = 0;
                    String lastPageTitle = "";
                    string[] lines, lineTemp = null;
                    lines = File.ReadAllLines(file);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        //string[] newString = ip.Split(new[] { ",\u000B" }, StringSplitOptions.RemoveEmptyEntries);
                        //lineTemp = lines[i].Split(';');

                        lineTemp = lines[i].Split(new[] { "<", " <", " id=\"", "\" title=\"", "\" descr=\"", "\">", "/t>", "/page", ">" }, StringSplitOptions.RemoveEmptyEntries);



                        String temp = "";
                        for (int j = 0; j < lineTemp.Length; j++)
                        {
                            temp += lineTemp[j] + "|";
                        }
                        Console.WriteLine(temp);
                        if (lineTemp != null)//try to remove all blank lines from processing//not working
                        {
                            if (lineTemp[0].Equals("page", StringComparison.InvariantCultureIgnoreCase))
                            {
                                //begin with page --new page
                                int page = Convert.ToInt32(lineTemp[1]);
                                Console.WriteLine("add Page" + page + " " + lineTemp[2]);
                                lastPage = page;
                                lastPageTitle = lineTemp[2];
                                TFile.addPage(page, lineTemp[2]);
                            }
                            else if (lineTemp[0].Equals("t", StringComparison.InvariantCultureIgnoreCase))
                            {
                                //begin with t data entry in stored page
                                int id = Convert.ToInt32(lineTemp[1]);
                                Console.WriteLine("add Page" + id + " " + lineTemp[2]);

                                TFile.addData(lastPage, lastPageTitle, id, lineTemp[2]);
                            }
                            else
                            {
                                //who knows thow it out
                            }
                        }
                    }
                }
                catch (IOException)
                {
                }
            }

        }


    }
}
