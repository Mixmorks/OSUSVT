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
            this.SuspendLayout();
            // 
            // textbox
            // 
            this.textbox.AutoSize = true;
            this.textbox.Location = new System.Drawing.Point(329, 108);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(41, 13);
            this.textbox.TabIndex = 0;
            this.textbox.Text = "textbox";
            this.textbox.Click += new System.EventHandler(this.textbox_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // portbox
            // 
            this.portbox.AutoSize = true;
            this.portbox.Location = new System.Drawing.Point(398, 108);
            this.portbox.Name = "portbox";
            this.portbox.Size = new System.Drawing.Size(47, 13);
            this.portbox.TabIndex = 2;
            this.portbox.Text = "Port Box";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 330);
            this.Controls.Add(this.portbox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textbox);
            this.Name = "mainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label portbox;
    }
}

