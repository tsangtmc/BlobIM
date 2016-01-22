using System.Windows.Forms;

namespace BlobIDS.GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.Label_Copyright = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "New Baseline";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(39, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 24);
            this.button2.TabIndex = 1;
            this.button2.Text = "(FIM) Check Now!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(39, 125);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Check Permissions";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(39, 167);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Update Config";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 17);
            this.label1.MaximumSize = new System.Drawing.Size(230, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Generate default baseline snapshot to configure what should be monitored and not";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 94);
            this.label2.MaximumSize = new System.Drawing.Size(230, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Execute a comparison of the blob baseline snapshot against the current state on d" +
    "emand";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(39, 343);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(129, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Hide Console/GUI";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 125);
            this.label3.MaximumSize = new System.Drawing.Size(230, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Check the current access pemissions of blob storage items";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 343);
            this.label4.MaximumSize = new System.Drawing.Size(230, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Hide this interface";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 167);
            this.label5.MaximumSize = new System.Drawing.Size(230, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Change configuration settings";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(399, 71);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 237);
            this.textBox1.TabIndex = 11;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(39, 314);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(129, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "Turn Off BlobIM";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Completely Close BlobIM";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(399, 337);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(129, 23);
            this.button7.TabIndex = 14;
            this.button7.Text = "ReadMe";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(393, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "\"Read Me\" of Instructions and limitations";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(39, 239);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(129, 23);
            this.button8.TabIndex = 16;
            this.button8.Text = "Pause BIM";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(170, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(206, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Unpause or Pause File Integrity Monitoring";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(501, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "BIM is Running";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BlobIDS.Properties.Resources.Check;
            this.pictureBox1.Location = new System.Drawing.Point(469, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 26);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(39, 269);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(129, 24);
            this.button9.TabIndex = 20;
            this.button9.Text = "Pause Heartbeat";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(40, 197);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(128, 23);
            this.button10.TabIndex = 21;
            this.button10.Text = "Update Baseline Config";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BlobIDS.Properties.Resources.add;
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(10, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 26);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::BlobIDS.Properties.Resources.checknow;
            this.pictureBox3.Location = new System.Drawing.Point(10, 94);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(26, 26);
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::BlobIDS.Properties.Resources.checknow;
            this.pictureBox4.Location = new System.Drawing.Point(10, 125);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(26, 26);
            this.pictureBox4.TabIndex = 24;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::BlobIDS.Properties.Resources.settings;
            this.pictureBox5.Location = new System.Drawing.Point(10, 166);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(26, 26);
            this.pictureBox5.TabIndex = 25;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::BlobIDS.Properties.Resources.settings;
            this.pictureBox6.Location = new System.Drawing.Point(10, 196);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(26, 26);
            this.pictureBox6.TabIndex = 26;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::BlobIDS.Properties.Resources.pause;
            this.pictureBox7.Location = new System.Drawing.Point(10, 239);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(26, 26);
            this.pictureBox7.TabIndex = 27;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::BlobIDS.Properties.Resources.pause;
            this.pictureBox8.Location = new System.Drawing.Point(10, 269);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(26, 26);
            this.pictureBox8.TabIndex = 28;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::BlobIDS.Properties.Resources.power;
            this.pictureBox9.Location = new System.Drawing.Point(10, 314);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(26, 26);
            this.pictureBox9.TabIndex = 29;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::BlobIDS.Properties.Resources.hide;
            this.pictureBox10.Location = new System.Drawing.Point(11, 343);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(26, 26);
            this.pictureBox10.TabIndex = 30;
            this.pictureBox10.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(173, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(170, 197);
            this.label11.MaximumSize = new System.Drawing.Size(230, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(209, 26);
            this.label11.TabIndex = 33;
            this.label11.Text = "Disable or Enable containers and blobs for monitoring";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(170, 269);
            this.label12.MaximumSize = new System.Drawing.Size(230, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(173, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Unpause or Pause Heartbeat alerts";
            // 
            // pictureBox12
            // 
            this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
            this.pictureBox12.Location = new System.Drawing.Point(442, 39);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(26, 26);
            this.pictureBox12.TabIndex = 35;
            this.pictureBox12.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(471, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Heartbeat is Running";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(39, 48);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(129, 24);
            this.button11.TabIndex = 37;
            this.button11.Text = "View/Convert Snapshot";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(170, 48);
            this.label14.MaximumSize = new System.Drawing.Size(230, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(227, 26);
            this.label14.TabIndex = 39;
            this.label14.Text = "View what was in storage at time of Snapshot: Choose an existing Snapshot to view" +
    "";
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = global::BlobIDS.Properties.Resources.readme1;
            this.pictureBox13.Location = new System.Drawing.Point(10, 48);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(26, 26);
            this.pictureBox13.TabIndex = 40;
            this.pictureBox13.TabStop = false;
            // 
            // Label_Copyright
            // 
            this.Label_Copyright.AutoSize = true;
            this.Label_Copyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.Label_Copyright.Location = new System.Drawing.Point(261, 363);
            this.Label_Copyright.Name = "Label_Copyright";
            this.Label_Copyright.Size = new System.Drawing.Size(306, 13);
            this.Label_Copyright.TabIndex = 42;
            this.Label_Copyright.TabStop = true;
            this.Label_Copyright.Text = "MIT Copyright (c) 2016 Microsoft Corporation. All rights reserved.";
            this.Label_Copyright.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Label_Copyright_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 375);
            this.Controls.Add(this.Label_Copyright);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "(BIM) Blob Integrity Monitor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private Button button7;
        private Label label7;
        private Button button8;
        private Label label8;
        private Label label9;
        private PictureBox pictureBox1;
        private Button button9;
        private Button button10;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private PictureBox pictureBox10;
        private Label label10;
        private Label label11;
        private Label label12;
        private PictureBox pictureBox12;
        private Label label13;
        private Button button11;
        private Label label14;
        private PictureBox pictureBox13;
        private LinkLabel Label_Copyright;
    }
}

