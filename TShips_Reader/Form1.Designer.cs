namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tShips = new System.Windows.Forms.Button();
            this.tFile = new System.Windows.Forms.Button();
            this.readTfile = new System.Windows.Forms.Button();
            this.openFileTFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileTShips = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // tShips
            // 
            this.tShips.Location = new System.Drawing.Point(12, 42);
            this.tShips.Name = "tShips";
            this.tShips.Size = new System.Drawing.Size(75, 23);
            this.tShips.TabIndex = 0;
            this.tShips.Text = "TShips";
            this.tShips.UseVisualStyleBackColor = true;
            this.tShips.Click += new System.EventHandler(this.tShips_Click);
            // 
            // tFile
            // 
            this.tFile.Location = new System.Drawing.Point(13, 13);
            this.tFile.Name = "tFile";
            this.tFile.Size = new System.Drawing.Size(75, 23);
            this.tFile.TabIndex = 1;
            this.tFile.Text = "TFile";
            this.tFile.UseVisualStyleBackColor = true;
            this.tFile.Click += new System.EventHandler(this.tFile_Click);
            // 
            // readTfile
            // 
            this.readTfile.Location = new System.Drawing.Point(95, 12);
            this.readTfile.Name = "readTfile";
            this.readTfile.Size = new System.Drawing.Size(75, 23);
            this.readTfile.TabIndex = 2;
            this.readTfile.Text = "Read Tfile";
            this.readTfile.UseVisualStyleBackColor = true;
            this.readTfile.Click += new System.EventHandler(this.readTfile_Click);
            // 
            // openFileTFile
            // 
            this.openFileTFile.FileName = "0001-L44.xml";
            this.openFileTFile.Filter = "XML (*.xml)|*.xml|Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            this.openFileTFile.Multiselect = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "All files (*.*)|*.*|Text Files (*.txt)|*.txt";
            this.saveFileDialog1.FilterIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save Page List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileTShips
            // 
            this.openFileTShips.FileName = "TShips.xml";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.readTfile);
            this.Controls.Add(this.tFile);
            this.Controls.Add(this.tShips);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tShips;
        private System.Windows.Forms.Button tFile;
        private System.Windows.Forms.Button readTfile;
        private System.Windows.Forms.OpenFileDialog openFileTFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileTShips;
    }
}

