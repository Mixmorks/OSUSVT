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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.left_blnk = new System.Windows.Forms.PictureBox();
            this.right_blnk = new System.Windows.Forms.PictureBox();
            this.emergency_lights = new System.Windows.Forms.PictureBox();
            this.horn = new System.Windows.Forms.PictureBox();
            this.camera_window = new System.Windows.Forms.PictureBox();
            this.velocity = new System.Windows.Forms.Label();
            this.label_soc = new System.Windows.Forms.Label();
            this.label_power_in = new System.Windows.Forms.Label();
            this.label_power_out = new System.Windows.Forms.Label();
            this.lights = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.left_blnk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_blnk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emergency_lights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camera_window)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lights)).BeginInit();
            this.SuspendLayout();
            // 
            // left_blnk
            // 
            this.left_blnk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.left_blnk.BackColor = System.Drawing.Color.Transparent;
            this.left_blnk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("left_blnk.BackgroundImage")));
            this.left_blnk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.left_blnk.Location = new System.Drawing.Point(2, 105);
            this.left_blnk.Name = "left_blnk";
            this.left_blnk.Size = new System.Drawing.Size(127, 217);
            this.left_blnk.TabIndex = 1;
            this.left_blnk.TabStop = false;
            this.left_blnk.Click += new System.EventHandler(this.button1_Click);
            // 
            // right_blnk
            // 
            this.right_blnk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.right_blnk.BackColor = System.Drawing.Color.Transparent;
            this.right_blnk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("right_blnk.BackgroundImage")));
            this.right_blnk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.right_blnk.Location = new System.Drawing.Point(653, 105);
            this.right_blnk.Name = "right_blnk";
            this.right_blnk.Size = new System.Drawing.Size(127, 217);
            this.right_blnk.TabIndex = 15;
            this.right_blnk.TabStop = false;
            this.right_blnk.Click += new System.EventHandler(this.button2_Click);
            // 
            // emergency_lights
            // 
            this.emergency_lights.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.emergency_lights.BackColor = System.Drawing.Color.Transparent;
            this.emergency_lights.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("emergency_lights.BackgroundImage")));
            this.emergency_lights.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.emergency_lights.InitialImage = null;
            this.emergency_lights.Location = new System.Drawing.Point(653, 405);
            this.emergency_lights.Name = "emergency_lights";
            this.emergency_lights.Size = new System.Drawing.Size(127, 83);
            this.emergency_lights.TabIndex = 16;
            this.emergency_lights.TabStop = false;
            this.emergency_lights.Text = "button3";
            this.emergency_lights.Click += new System.EventHandler(this.button3_Click);
            // 
            // horn
            // 
            this.horn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.horn.BackColor = System.Drawing.Color.Transparent;
            this.horn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("horn.BackgroundImage")));
            this.horn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.horn.Location = new System.Drawing.Point(0, 405);
            this.horn.Name = "horn";
            this.horn.Size = new System.Drawing.Size(129, 82);
            this.horn.TabIndex = 17;
            this.horn.TabStop = false;
            this.horn.Text = "button4";
            // 
            // camera_window
            // 
            this.camera_window.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.camera_window.Location = new System.Drawing.Point(128, 105);
            this.camera_window.Name = "camera_window";
            this.camera_window.Size = new System.Drawing.Size(525, 382);
            this.camera_window.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.camera_window.TabIndex = 13;
            this.camera_window.TabStop = false;
            // 
            // velocity
            // 
            this.velocity.AutoSize = true;
            this.velocity.BackColor = System.Drawing.Color.Transparent;
            this.velocity.Font = new System.Drawing.Font("Microsoft Sans Serif", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.velocity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.velocity.Location = new System.Drawing.Point(-24, -24);
            this.velocity.Name = "velocity";
            this.velocity.Size = new System.Drawing.Size(213, 152);
            this.velocity.TabIndex = 19;
            this.velocity.Text = "88";
            // 
            // label_soc
            // 
            this.label_soc.AutoSize = true;
            this.label_soc.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_soc.Location = new System.Drawing.Point(482, 9);
            this.label_soc.Name = "label_soc";
            this.label_soc.Size = new System.Drawing.Size(90, 33);
            this.label_soc.TabIndex = 20;
            this.label_soc.Text = "SOC:";
            // 
            // label_power_in
            // 
            this.label_power_in.AutoSize = true;
            this.label_power_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_power_in.Location = new System.Drawing.Point(474, 40);
            this.label_power_in.Name = "label_power_in";
            this.label_power_in.Size = new System.Drawing.Size(99, 33);
            this.label_power_in.TabIndex = 21;
            this.label_power_in.Text = "Array:";
            // 
            // label_power_out
            // 
            this.label_power_out.AutoSize = true;
            this.label_power_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_power_out.Location = new System.Drawing.Point(470, 71);
            this.label_power_out.Name = "label_power_out";
            this.label_power_out.Size = new System.Drawing.Size(103, 33);
            this.label_power_out.TabIndex = 22;
            this.label_power_out.Text = "Motor:";
            // 
            // lights
            // 
            this.lights.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lights.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lights.BackgroundImage")));
            this.lights.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lights.Location = new System.Drawing.Point(653, 322);
            this.lights.Name = "lights";
            this.lights.Size = new System.Drawing.Size(127, 83);
            this.lights.TabIndex = 23;
            this.lights.TabStop = false;
            this.lights.Click += new System.EventHandler(this.lights_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 486);
            this.Controls.Add(this.lights);
            this.Controls.Add(this.label_soc);
            this.Controls.Add(this.left_blnk);
            this.Controls.Add(this.right_blnk);
            this.Controls.Add(this.emergency_lights);
            this.Controls.Add(this.horn);
            this.Controls.Add(this.camera_window);
            this.Controls.Add(this.label_power_in);
            this.Controls.Add(this.label_power_out);
            this.Controls.Add(this.velocity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.left_blnk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_blnk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emergency_lights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camera_window)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lights)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox left_blnk;
        private System.Windows.Forms.PictureBox right_blnk;

        private System.Windows.Forms.PictureBox emergency_lights;
        private System.Windows.Forms.PictureBox lights;

        private System.Windows.Forms.PictureBox horn;
        private System.Windows.Forms.PictureBox camera_window;
        private System.Windows.Forms.Label label_soc;
        private System.Windows.Forms.Label label_power_in;
        private System.Windows.Forms.Label label_power_out;
        private System.Windows.Forms.Label velocity;
        
        
        
    }
}

