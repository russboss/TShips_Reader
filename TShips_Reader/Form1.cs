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
        bool DEBUG = false;
        private String [] tFileDir;
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
            result = openFileTFile.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                tFileDir = openFileTFile.FileNames;
                for (int i = 0; i < tFileDir.Length; i++)
                {
                    Console.WriteLine(tFileDir[i]);
                }
            }
        }

        private void tShips_Click(object sender, EventArgs e)
        {
                if(TFile != null){
                    Console.WriteLine("Exists");
                }
                else
                {
                    Console.WriteLine("DNE");
                }

        }

        private void readTfile_Click(object sender, EventArgs e)
        {

            if (result == DialogResult.OK) // Test result.
            {
                
                string[] file = openFileTFile.FileNames;
                bool[] err = new bool[file.Length];
                string str = "";
                string OK = "OK",FAIL="FAIL";
                //add openfile for reading p422
                //string file = openFileDialog1.FileName;
                
                for (int i= 0; i < file.Length; i++ )
                {
                    
                    err[i] = readFileIntoStructure(file[i]);
                    if (err[i] == true){
                        str = OK;
                    }else{
                        str = FAIL;
                    }
                    Console.WriteLine("file: " + file[i] +" - " + str );
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(saveFileDialog1.ShowDialog() == DialogResult.OK){
                //File.WriteAllText(fileName, textToWrite);
                File.WriteAllText(saveFileDialog1.FileName, TFile.printPageList() );

            }
            
            Console.WriteLine("DONE");

        }

        private bool readFileIntoStructure(string file)
        {
            int i = 0;
            string temp = "";
            try
            {
                if (File.Exists(file))
                {
                    int lastPage = 0;
                    String lastPageTitle = "";
                    string[] lines, lineTemp = null;
                    lines = File.ReadAllLines(file);
                    for (i = 0; i < lines.Length; i++)
                    {
                        //string[] newString = ip.Split(new[] { ",\u000B" }, StringSplitOptions.RemoveEmptyEntries);
                        //lineTemp = lines[i].Split(';');
                        //
                        lineTemp = lines[i].Split(new[] { "<", " id=\"", "\" title=\"", "\" descr=\"", "\">", "/t>", "/page", ">" }, StringSplitOptions.RemoveEmptyEntries);


                        if (DEBUG == true)
                        {
                            temp = "";
                            for (int j = 0; j < lineTemp.Length; j++)
                            {
                                temp += lineTemp[j] + "|";
                            }
                            Console.WriteLine(i + "/" + lines.Length + " line: " + temp);
                        }
                        if (lineTemp.Length > 2)//try to remove all blank lines from processing//not working
                        {
                            if (lineTemp[0].Equals("page", StringComparison.InvariantCultureIgnoreCase))
                            {
                                //begin with page --new page
                                int page = Convert.ToInt32(lineTemp[1]);
                                //Console.WriteLine("add Page: " + page + " " + lineTemp[2]);
                                lastPage = page;
                                lastPageTitle = lineTemp[2];
                                TFile.addPage(page, lineTemp[2]);
                            }
                            else if (lineTemp[1].Equals("t", StringComparison.InvariantCultureIgnoreCase))
                            {
                                //begin with t data entry in stored page
                                //Console.WriteLine(lastPage +" "+ lineTemp[1]);
                                if (lineTemp.Length > 3)
                                {
                                    int id = Convert.ToInt32(lineTemp[2]);
                                    //  0         1    2     3
                                    //    <t id="200">stuff<  /t>

                                    //Console.WriteLine("add Data " + lastPage + " " + lineTemp[2]);

                                    TFile.addData(lastPage, lastPageTitle, id, lineTemp[3]);
                                }
                                else
                                {
                                    int id = Convert.ToInt32(lineTemp[2]);
                                    //  0         1    2     3
                                    //    <t id="200">stuff<  /t>
                                    //Console.WriteLine("add Data " + lastPage + " " + lineTemp[2]);

                                    TFile.addData(lastPage, lastPageTitle, id, "");

                                }

                            }
                            else
                            {
                                //who knows thow it out
                            }
                        }
                    }

                    //Console.WriteLine(" Page List:\n" + TFile.printPageList());

                    /*
                    if(saveFileDialog1.ShowDialog() == DialogResult.OK){
                        //File.WriteAllText(fileName, textToWrite);
                        File.WriteAllText(saveFileDialog1.FileName, TFile.printPageList() );
                    }
                    */
                    //Console.WriteLine("DONE");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception err)
            {
                if (DEBUG == true)
                {
                    Console.WriteLine(err + " \ni:" + i + "\nline: " + temp);
                }
                return false;
            }


        }

    }
}
