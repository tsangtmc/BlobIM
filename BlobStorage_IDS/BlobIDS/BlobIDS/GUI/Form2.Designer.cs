namespace BlobIDS.GUI
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.HTML = new System.Windows.Forms.Button();
            this.RawText = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CSV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HTML
            // 
            this.HTML.Location = new System.Drawing.Point(22, 32);
            this.HTML.Name = "HTML";
            this.HTML.Size = new System.Drawing.Size(75, 23);
            this.HTML.TabIndex = 0;
            this.HTML.Text = "HTML";
            this.HTML.UseVisualStyleBackColor = true;
            this.HTML.Click += new System.EventHandler(this.HTML_Click);
            // 
            // RawText
            // 
            this.RawText.Location = new System.Drawing.Point(184, 32);
            this.RawText.Name = "RawText";
            this.RawText.Size = new System.Drawing.Size(75, 23);
            this.RawText.TabIndex = 1;
            this.RawText.Text = "Raw Text";
            this.RawText.UseVisualStyleBackColor = true;
            this.RawText.Click += new System.EventHandler(this.RawText_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(41, 13);
            this.label14.MaximumSize = new System.Drawing.Size(230, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(199, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "Choose a format to view the snapshot in:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Choose a Snapshot File";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // CSV
            // 
            this.CSV.Location = new System.Drawing.Point(103, 32);
            this.CSV.Name = "CSV";
            this.CSV.Size = new System.Drawing.Size(75, 23);
            this.CSV.TabIndex = 41;
            this.CSV.Text = "CSV";
            this.CSV.UseVisualStyleBackColor = true;
            this.CSV.Click += new System.EventHandler(this.CSV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 66);
            this.label1.MaximumSize = new System.Drawing.Size(230, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 26);
            this.label1.TabIndex = 42;
            this.label1.Text = "[Converting]: Once view of a snapshot is created it can be saved for later viewin" +
    "g.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 100);
            this.label2.MaximumSize = new System.Drawing.Size(230, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 26);
            this.label2.TabIndex = 43;
            this.label2.Text = "[Note]: however that only the \"Raw Text\" can be consumed\\used by Blob Integrity M" +
    "onitor.";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 139);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CSV);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.RawText);
            this.Controls.Add(this.HTML);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "View/Convert Snapshot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button HTML;
        private System.Windows.Forms.Button RawText;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button CSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}