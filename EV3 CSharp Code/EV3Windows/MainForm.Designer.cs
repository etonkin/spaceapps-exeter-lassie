namespace EV3Windows
{
    partial class MainForm
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
            this.buttonFlashLeds = new System.Windows.Forms.Button();
            this.comPortsComboBox = new System.Windows.Forms.ComboBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonAlright = new System.Windows.Forms.Button();
            this.buttonRotate = new System.Windows.Forms.Button();
            this.buttonWave = new System.Windows.Forms.Button();
            this.buttonBrakesOff = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.buttonLedOff = new System.Windows.Forms.Button();
            this.buttonRunAway = new System.Windows.Forms.Button();
            this.buttonPushImage = new System.Windows.Forms.Button();
            this.labelRed = new System.Windows.Forms.Label();
            this.labelBlue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonFlashLeds
            // 
            this.buttonFlashLeds.Location = new System.Drawing.Point(224, 122);
            this.buttonFlashLeds.Name = "buttonFlashLeds";
            this.buttonFlashLeds.Size = new System.Drawing.Size(75, 23);
            this.buttonFlashLeds.TabIndex = 0;
            this.buttonFlashLeds.Text = "LED";
            this.buttonFlashLeds.UseVisualStyleBackColor = true;
            this.buttonFlashLeds.Click += new System.EventHandler(this.button1_Click);
            // 
            // comPortsComboBox
            // 
            this.comPortsComboBox.FormattingEnabled = true;
            this.comPortsComboBox.Location = new System.Drawing.Point(12, 122);
            this.comPortsComboBox.Name = "comPortsComboBox";
            this.comPortsComboBox.Size = new System.Drawing.Size(121, 21);
            this.comPortsComboBox.TabIndex = 1;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(12, 12);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(553, 104);
            this.outputTextBox.TabIndex = 2;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(143, 122);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(334, 122);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "MOTORS";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(143, 240);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 41);
            this.button4.TabIndex = 5;
            this.button4.Text = "TO DISPLAY";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(11, 242);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(122, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "Hallo Dave";
            // 
            // buttonAlright
            // 
            this.buttonAlright.Location = new System.Drawing.Point(490, 180);
            this.buttonAlright.Name = "buttonAlright";
            this.buttonAlright.Size = new System.Drawing.Size(75, 23);
            this.buttonAlright.TabIndex = 7;
            this.buttonAlright.Text = "ALRIGHT";
            this.buttonAlright.UseVisualStyleBackColor = true;
            this.buttonAlright.Click += new System.EventHandler(this.buttonAlright_Click);
            // 
            // buttonRotate
            // 
            this.buttonRotate.Location = new System.Drawing.Point(490, 151);
            this.buttonRotate.Name = "buttonRotate";
            this.buttonRotate.Size = new System.Drawing.Size(75, 23);
            this.buttonRotate.TabIndex = 8;
            this.buttonRotate.Text = "ROTATE";
            this.buttonRotate.UseVisualStyleBackColor = true;
            this.buttonRotate.Click += new System.EventHandler(this.buttonRotate_Click);
            // 
            // buttonWave
            // 
            this.buttonWave.Location = new System.Drawing.Point(490, 122);
            this.buttonWave.Name = "buttonWave";
            this.buttonWave.Size = new System.Drawing.Size(75, 23);
            this.buttonWave.TabIndex = 9;
            this.buttonWave.Text = "WAVE";
            this.buttonWave.UseVisualStyleBackColor = true;
            this.buttonWave.Click += new System.EventHandler(this.buttonWave_Click);
            // 
            // buttonBrakesOff
            // 
            this.buttonBrakesOff.Location = new System.Drawing.Point(334, 233);
            this.buttonBrakesOff.Name = "buttonBrakesOff";
            this.buttonBrakesOff.Size = new System.Drawing.Size(75, 36);
            this.buttonBrakesOff.TabIndex = 10;
            this.buttonBrakesOff.Text = "BRAKES OFF";
            this.buttonBrakesOff.UseVisualStyleBackColor = true;
            this.buttonBrakesOff.Click += new System.EventHandler(this.buttonBrakesOff_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(143, 144);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(75, 23);
            this.buttonDisconnect.TabIndex = 11;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // buttonLedOff
            // 
            this.buttonLedOff.Location = new System.Drawing.Point(224, 144);
            this.buttonLedOff.Name = "buttonLedOff";
            this.buttonLedOff.Size = new System.Drawing.Size(75, 23);
            this.buttonLedOff.TabIndex = 12;
            this.buttonLedOff.Text = "LED OFF";
            this.buttonLedOff.UseVisualStyleBackColor = true;
            this.buttonLedOff.Click += new System.EventHandler(this.buttonLedOff_Click);
            // 
            // buttonRunAway
            // 
            this.buttonRunAway.Location = new System.Drawing.Point(334, 151);
            this.buttonRunAway.Name = "buttonRunAway";
            this.buttonRunAway.Size = new System.Drawing.Size(75, 23);
            this.buttonRunAway.TabIndex = 13;
            this.buttonRunAway.Text = "RUN AWAY";
            this.buttonRunAway.UseVisualStyleBackColor = true;
            this.buttonRunAway.Click += new System.EventHandler(this.buttonRunAway_Click);
            // 
            // buttonPushImage
            // 
            this.buttonPushImage.Location = new System.Drawing.Point(490, 233);
            this.buttonPushImage.Name = "buttonPushImage";
            this.buttonPushImage.Size = new System.Drawing.Size(75, 38);
            this.buttonPushImage.TabIndex = 14;
            this.buttonPushImage.Text = "PUSH IMAGE";
            this.buttonPushImage.UseVisualStyleBackColor = true;
            this.buttonPushImage.Click += new System.EventHandler(this.buttonPushImage_Click);
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.Location = new System.Drawing.Point(140, 190);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(93, 13);
            this.labelRed.TabIndex = 15;
            this.labelRed.Text = "RedRemoteSignal";
            // 
            // labelBlue
            // 
            this.labelBlue.AutoSize = true;
            this.labelBlue.Location = new System.Drawing.Point(254, 190);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(94, 13);
            this.labelBlue.TabIndex = 16;
            this.labelBlue.Text = "BlueRemoteSignal";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 331);
            this.Controls.Add(this.labelBlue);
            this.Controls.Add(this.labelRed);
            this.Controls.Add(this.buttonPushImage);
            this.Controls.Add(this.buttonRunAway);
            this.Controls.Add(this.buttonLedOff);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonBrakesOff);
            this.Controls.Add(this.buttonWave);
            this.Controls.Add(this.buttonRotate);
            this.Controls.Add(this.buttonAlright);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.comPortsComboBox);
            this.Controls.Add(this.buttonFlashLeds);
            this.Name = "MainForm";
            this.Text = "EV3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFlashLeds;
        private System.Windows.Forms.ComboBox comPortsComboBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonAlright;
        private System.Windows.Forms.Button buttonRotate;
        private System.Windows.Forms.Button buttonWave;
        private System.Windows.Forms.Button buttonBrakesOff;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Button buttonLedOff;
        private System.Windows.Forms.Button buttonRunAway;
        private System.Windows.Forms.Button buttonPushImage;
        private System.Windows.Forms.Label labelRed;
        private System.Windows.Forms.Label labelBlue;
    }
}

