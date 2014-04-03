namespace main
{
    partial class mainForm
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
            this.textbox = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.portbox = new System.Windows.Forms.Label();
            this.conupdate = new System.Windows.Forms.Label();
            this.latitude = new System.Windows.Forms.Label();
            this.longitude = new System.Windows.Forms.Label();
            this.satcount = new System.Windows.Forms.Label();
            this.velocity = new System.Windows.Forms.Label();
            this.altitude = new System.Windows.Forms.Label();
            this.bearing = new System.Windows.Forms.Label();
            this.nos = new System.Windows.Forms.Label();
            this.eow = new System.Windows.Forms.Label();
            this.camera_window = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.camera_window)).BeginInit();
            this.SuspendLayout();
            // 
            // textbox
            // 
            this.textbox.Location = new System.Drawing.Point(0, 0);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(100, 23);
            this.textbox.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // portbox
            // 
            this.portbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.portbox.AutoSize = true;
            this.portbox.Location = new System.Drawing.Point(17, 145);
            this.portbox.Name = "portbox";
            this.portbox.Size = new System.Drawing.Size(47, 13);
            this.portbox.TabIndex = 2;
            this.portbox.Text = "Port Box";
            // 
            // conupdate
            // 
            this.conupdate.AutoSize = true;
            this.conupdate.Location = new System.Drawing.Point(17, 187);
            this.conupdate.Name = "conupdate";
            this.conupdate.Size = new System.Drawing.Size(92, 13);
            this.conupdate.TabIndex = 3;
            this.conupdate.Text = "Constant Updates";
            // 
            // latitude
            // 
            this.latitude.AutoSize = true;
            this.latitude.Location = new System.Drawing.Point(14, 9);
            this.latitude.Name = "latitude";
            this.latitude.Size = new System.Drawing.Size(41, 13);
            this.latitude.TabIndex = 4;
            this.latitude.Text = "latitude";
            // 
            // longitude
            // 
            this.longitude.AutoSize = true;
            this.longitude.Location = new System.Drawing.Point(14, 23);
            this.longitude.Name = "longitude";
            this.longitude.Size = new System.Drawing.Size(50, 13);
            this.longitude.TabIndex = 5;
            this.longitude.Text = "longitude";
            // 
            // satcount
            // 
            this.satcount.AutoSize = true;
            this.satcount.Location = new System.Drawing.Point(14, 36);
            this.satcount.Name = "satcount";
            this.satcount.Size = new System.Drawing.Size(48, 13);
            this.satcount.TabIndex = 6;
            this.satcount.Text = "satcount";
            // 
            // velocity
            // 
            this.velocity.AutoSize = true;
            this.velocity.Location = new System.Drawing.Point(14, 49);
            this.velocity.Name = "velocity";
            this.velocity.Size = new System.Drawing.Size(43, 13);
            this.velocity.TabIndex = 7;
            this.velocity.Text = "velocity";
            // 
            // altitude
            // 
            this.altitude.AutoSize = true;
            this.altitude.Location = new System.Drawing.Point(14, 62);
            this.altitude.Name = "altitude";
            this.altitude.Size = new System.Drawing.Size(41, 13);
            this.altitude.TabIndex = 8;
            this.altitude.Text = "altitude";
            // 
            // bearing
            // 
            this.bearing.AutoSize = true;
            this.bearing.Location = new System.Drawing.Point(14, 75);
            this.bearing.Name = "bearing";
            this.bearing.Size = new System.Drawing.Size(42, 13);
            this.bearing.TabIndex = 9;
            this.bearing.Text = "bearing";
            // 
            // nos
            // 
            this.nos.AutoSize = true;
            this.nos.Location = new System.Drawing.Point(14, 88);
            this.nos.Name = "nos";
            this.nos.Size = new System.Drawing.Size(24, 13);
            this.nos.TabIndex = 10;
            this.nos.Text = "nos";
            // 
            // eow
            // 
            this.eow.AutoSize = true;
            this.eow.Location = new System.Drawing.Point(14, 101);
            this.eow.Name = "eow";
            this.eow.Size = new System.Drawing.Size(27, 13);
            this.eow.TabIndex = 11;
            this.eow.Text = "eow";
            // 
            // camera_window
            // 
            this.camera_window.Location = new System.Drawing.Point(304, 9);
            this.camera_window.Name = "camera_window";
            this.camera_window.Size = new System.Drawing.Size(474, 309);
            this.camera_window.TabIndex = 13;
            this.camera_window.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(177, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(177, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 330);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.camera_window);
            this.Controls.Add(this.eow);
            this.Controls.Add(this.nos);
            this.Controls.Add(this.bearing);
            this.Controls.Add(this.altitude);
            this.Controls.Add(this.velocity);
            this.Controls.Add(this.satcount);
            this.Controls.Add(this.longitude);
            this.Controls.Add(this.latitude);
            this.Controls.Add(this.conupdate);
            this.Controls.Add(this.portbox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textbox);
            this.Name = "mainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.camera_window)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label portbox;
        private System.Windows.Forms.Label conupdate;
        private System.Windows.Forms.Label latitude;
        private System.Windows.Forms.Label longitude;
        private System.Windows.Forms.Label satcount;
        private System.Windows.Forms.Label velocity;
        private System.Windows.Forms.Label altitude;
        private System.Windows.Forms.Label bearing;
        private System.Windows.Forms.Label nos;
        private System.Windows.Forms.Label eow;
        private System.Windows.Forms.PictureBox camera_window;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
    }
}

