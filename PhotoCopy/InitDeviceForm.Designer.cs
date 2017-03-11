namespace PhotoCopy
{
    partial class InitDeviceForm
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
            this.buttonChooseSource = new System.Windows.Forms.Button();
            this.buttonChooseDestination = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelSource = new System.Windows.Forms.Label();
            this.labelDestination = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonChooseSource
            // 
            this.buttonChooseSource.Location = new System.Drawing.Point(20, 74);
            this.buttonChooseSource.Name = "buttonChooseSource";
            this.buttonChooseSource.Size = new System.Drawing.Size(280, 23);
            this.buttonChooseSource.TabIndex = 0;
            this.buttonChooseSource.Text = "Choose source folder";
            this.buttonChooseSource.UseVisualStyleBackColor = true;
            this.buttonChooseSource.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonChooseDestination
            // 
            this.buttonChooseDestination.Location = new System.Drawing.Point(20, 131);
            this.buttonChooseDestination.Name = "buttonChooseDestination";
            this.buttonChooseDestination.Size = new System.Drawing.Size(280, 23);
            this.buttonChooseDestination.TabIndex = 1;
            this.buttonChooseDestination.Text = "Choose destination folder";
            this.buttonChooseDestination.UseVisualStyleBackColor = true;
            this.buttonChooseDestination.Click += new System.EventHandler(this.buttonChooseDestination_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(113, 185);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(184, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Confirm";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(20, 38);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(280, 20);
            this.textBoxName.TabIndex = 3;
            this.textBoxName.Text = "My device";
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(20, 100);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(0, 13);
            this.labelSource.TabIndex = 4;
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(20, 157);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(0, 13);
            this.labelDestination.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Device name";
            // 
            // InitDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 224);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelDestination);
            this.Controls.Add(this.labelSource);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonChooseDestination);
            this.Controls.Add(this.buttonChooseSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InitDeviceForm";
            this.ShowIcon = false;
            this.Text = "Device settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChooseSource;
        private System.Windows.Forms.Button buttonChooseDestination;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.Label label1;
    }
}