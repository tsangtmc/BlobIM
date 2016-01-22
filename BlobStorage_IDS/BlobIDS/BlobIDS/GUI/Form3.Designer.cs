namespace BlobIDS.GUI
{
    partial class Form3
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
            this.Doc = new System.Windows.Forms.Button();
            this.PDF = new System.Windows.Forms.Button();
            this.RawText = new System.Windows.Forms.Button();
            this.HTML = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Doc
            // 
            this.Doc.Location = new System.Drawing.Point(171, 31);
            this.Doc.Name = "Doc";
            this.Doc.Size = new System.Drawing.Size(75, 23);
            this.Doc.TabIndex = 46;
            this.Doc.Text = "Word Doc";
            this.Doc.UseVisualStyleBackColor = true;
            this.Doc.Click += new System.EventHandler(this.Doc_Click);
            // 
            // PDF
            // 
            this.PDF.Location = new System.Drawing.Point(93, 31);
            this.PDF.Name = "PDF";
            this.PDF.Size = new System.Drawing.Size(75, 23);
            this.PDF.TabIndex = 45;
            this.PDF.Text = "PDF";
            this.PDF.UseVisualStyleBackColor = true;
            this.PDF.Click += new System.EventHandler(this.PDF_Click);
            // 
            // RawText
            // 
            this.RawText.Location = new System.Drawing.Point(252, 31);
            this.RawText.Name = "RawText";
            this.RawText.Size = new System.Drawing.Size(75, 23);
            this.RawText.TabIndex = 44;
            this.RawText.Text = "Text File";
            this.RawText.UseVisualStyleBackColor = true;
            this.RawText.Click += new System.EventHandler(this.RawText_Click);
            // 
            // HTML
            // 
            this.HTML.Location = new System.Drawing.Point(12, 31);
            this.HTML.Name = "HTML";
            this.HTML.Size = new System.Drawing.Size(75, 23);
            this.HTML.TabIndex = 43;
            this.HTML.Text = "HTML";
            this.HTML.UseVisualStyleBackColor = true;
            this.HTML.Click += new System.EventHandler(this.HTML_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 9);
            this.label14.MaximumSize = new System.Drawing.Size(230, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(197, 13);
            this.label14.TabIndex = 47;
            this.label14.Text = "Choose a format to view the ReadMe in:";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 63);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Doc);
            this.Controls.Add(this.PDF);
            this.Controls.Add(this.RawText);
            this.Controls.Add(this.HTML);
            this.Name = "Form3";
            this.Text = "ReadMe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Doc;
        private System.Windows.Forms.Button PDF;
        private System.Windows.Forms.Button RawText;
        private System.Windows.Forms.Button HTML;
        private System.Windows.Forms.Label label14;

    }
}