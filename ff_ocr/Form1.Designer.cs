namespace ff_ocr {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pbEnemy1 = new System.Windows.Forms.PictureBox();
            this.timerRecognize = new System.Windows.Forms.Timer(this.components);
            this.grpEnemy1 = new System.Windows.Forms.GroupBox();
            this.txtEnemy1 = new System.Windows.Forms.RichTextBox();
            this.grpEnemy2 = new System.Windows.Forms.GroupBox();
            this.txtEnemy2 = new System.Windows.Forms.RichTextBox();
            this.pbEnemy2 = new System.Windows.Forms.PictureBox();
            this.txtEnemy3 = new System.Windows.Forms.RichTextBox();
            this.pbEnemy3 = new System.Windows.Forms.PictureBox();
            this.grpEnemy3 = new System.Windows.Forms.GroupBox();
            this.pbCapture = new System.Windows.Forms.PictureBox();
            this.grpCapture = new System.Windows.Forms.GroupBox();
            this.lblCaptureStatus = new System.Windows.Forms.Label();
            this.btnSetCaptureData = new System.Windows.Forms.Button();
            this.txtCaptureHeight = new System.Windows.Forms.TextBox();
            this.txtCaptureWidth = new System.Windows.Forms.TextBox();
            this.txtCaptureY = new System.Windows.Forms.TextBox();
            this.txtCaptureX = new System.Windows.Forms.TextBox();
            this.lblCaptureHeight = new System.Windows.Forms.Label();
            this.lblCaptureWidth = new System.Windows.Forms.Label();
            this.lblCaptureY = new System.Windows.Forms.Label();
            this.lblCaptureX = new System.Windows.Forms.Label();
            this.timerClearCaptureStatus = new System.Windows.Forms.Timer(this.components);
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtUniqueStrings = new System.Windows.Forms.RichTextBox();
            this.txtAddManualString = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAddManualStringStatus = new System.Windows.Forms.Label();
            this.btnAddManualString = new System.Windows.Forms.Button();
            this.timerClearAddManualStringStatus = new System.Windows.Forms.Timer(this.components);
            this.btnClearUniqueStrings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy1)).BeginInit();
            this.grpEnemy1.SuspendLayout();
            this.grpEnemy2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy3)).BeginInit();
            this.grpEnemy3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapture)).BeginInit();
            this.grpCapture.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(227, 289);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // pbEnemy1
            // 
            this.pbEnemy1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbEnemy1.Location = new System.Drawing.Point(6, 19);
            this.pbEnemy1.Name = "pbEnemy1";
            this.pbEnemy1.Size = new System.Drawing.Size(128, 128);
            this.pbEnemy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEnemy1.TabIndex = 1;
            this.pbEnemy1.TabStop = false;
            // 
            // timerRecognize
            // 
            this.timerRecognize.Enabled = true;
            this.timerRecognize.Interval = 1;
            this.timerRecognize.Tick += new System.EventHandler(this.timerRecognize_Tick);
            // 
            // grpEnemy1
            // 
            this.grpEnemy1.BackColor = System.Drawing.SystemColors.Control;
            this.grpEnemy1.Controls.Add(this.txtEnemy1);
            this.grpEnemy1.Controls.Add(this.pbEnemy1);
            this.grpEnemy1.Location = new System.Drawing.Point(692, 12);
            this.grpEnemy1.Name = "grpEnemy1";
            this.grpEnemy1.Size = new System.Drawing.Size(388, 272);
            this.grpEnemy1.TabIndex = 5;
            this.grpEnemy1.TabStop = false;
            this.grpEnemy1.Text = "Enemy 1";
            // 
            // txtEnemy1
            // 
            this.txtEnemy1.Location = new System.Drawing.Point(140, 19);
            this.txtEnemy1.Name = "txtEnemy1";
            this.txtEnemy1.Size = new System.Drawing.Size(240, 247);
            this.txtEnemy1.TabIndex = 2;
            this.txtEnemy1.Text = "";
            // 
            // grpEnemy2
            // 
            this.grpEnemy2.BackColor = System.Drawing.SystemColors.Control;
            this.grpEnemy2.Controls.Add(this.txtEnemy2);
            this.grpEnemy2.Controls.Add(this.pbEnemy2);
            this.grpEnemy2.Location = new System.Drawing.Point(692, 290);
            this.grpEnemy2.Name = "grpEnemy2";
            this.grpEnemy2.Size = new System.Drawing.Size(388, 272);
            this.grpEnemy2.TabIndex = 6;
            this.grpEnemy2.TabStop = false;
            this.grpEnemy2.Text = "Enemy 2";
            // 
            // txtEnemy2
            // 
            this.txtEnemy2.Location = new System.Drawing.Point(140, 19);
            this.txtEnemy2.Name = "txtEnemy2";
            this.txtEnemy2.Size = new System.Drawing.Size(240, 247);
            this.txtEnemy2.TabIndex = 3;
            this.txtEnemy2.Text = "";
            // 
            // pbEnemy2
            // 
            this.pbEnemy2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbEnemy2.Location = new System.Drawing.Point(6, 19);
            this.pbEnemy2.Name = "pbEnemy2";
            this.pbEnemy2.Size = new System.Drawing.Size(128, 128);
            this.pbEnemy2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEnemy2.TabIndex = 2;
            this.pbEnemy2.TabStop = false;
            // 
            // txtEnemy3
            // 
            this.txtEnemy3.Location = new System.Drawing.Point(140, 19);
            this.txtEnemy3.Name = "txtEnemy3";
            this.txtEnemy3.Size = new System.Drawing.Size(240, 247);
            this.txtEnemy3.TabIndex = 2;
            this.txtEnemy3.Text = "";
            // 
            // pbEnemy3
            // 
            this.pbEnemy3.Location = new System.Drawing.Point(6, 19);
            this.pbEnemy3.Name = "pbEnemy3";
            this.pbEnemy3.Size = new System.Drawing.Size(128, 128);
            this.pbEnemy3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEnemy3.TabIndex = 1;
            this.pbEnemy3.TabStop = false;
            // 
            // grpEnemy3
            // 
            this.grpEnemy3.BackColor = System.Drawing.SystemColors.Control;
            this.grpEnemy3.Controls.Add(this.txtEnemy3);
            this.grpEnemy3.Controls.Add(this.pbEnemy3);
            this.grpEnemy3.Location = new System.Drawing.Point(692, 568);
            this.grpEnemy3.Name = "grpEnemy3";
            this.grpEnemy3.Size = new System.Drawing.Size(388, 272);
            this.grpEnemy3.TabIndex = 6;
            this.grpEnemy3.TabStop = false;
            this.grpEnemy3.Text = "Enemy 3";
            // 
            // pbCapture
            // 
            this.pbCapture.Location = new System.Drawing.Point(9, 58);
            this.pbCapture.Name = "pbCapture";
            this.pbCapture.Size = new System.Drawing.Size(426, 208);
            this.pbCapture.TabIndex = 7;
            this.pbCapture.TabStop = false;
            // 
            // grpCapture
            // 
            this.grpCapture.BackColor = System.Drawing.SystemColors.Control;
            this.grpCapture.Controls.Add(this.lblCaptureStatus);
            this.grpCapture.Controls.Add(this.btnSetCaptureData);
            this.grpCapture.Controls.Add(this.txtCaptureHeight);
            this.grpCapture.Controls.Add(this.txtCaptureWidth);
            this.grpCapture.Controls.Add(this.txtCaptureY);
            this.grpCapture.Controls.Add(this.txtCaptureX);
            this.grpCapture.Controls.Add(this.lblCaptureHeight);
            this.grpCapture.Controls.Add(this.lblCaptureWidth);
            this.grpCapture.Controls.Add(this.lblCaptureY);
            this.grpCapture.Controls.Add(this.lblCaptureX);
            this.grpCapture.Controls.Add(this.pbCapture);
            this.grpCapture.Location = new System.Drawing.Point(245, 12);
            this.grpCapture.Name = "grpCapture";
            this.grpCapture.Size = new System.Drawing.Size(441, 272);
            this.grpCapture.TabIndex = 8;
            this.grpCapture.TabStop = false;
            this.grpCapture.Text = "Capture";
            // 
            // lblCaptureStatus
            // 
            this.lblCaptureStatus.AutoSize = true;
            this.lblCaptureStatus.Location = new System.Drawing.Point(6, 42);
            this.lblCaptureStatus.Name = "lblCaptureStatus";
            this.lblCaptureStatus.Size = new System.Drawing.Size(0, 13);
            this.lblCaptureStatus.TabIndex = 17;
            // 
            // btnSetCaptureData
            // 
            this.btnSetCaptureData.Location = new System.Drawing.Point(381, 17);
            this.btnSetCaptureData.Name = "btnSetCaptureData";
            this.btnSetCaptureData.Size = new System.Drawing.Size(54, 23);
            this.btnSetCaptureData.TabIndex = 16;
            this.btnSetCaptureData.Text = "&Set";
            this.btnSetCaptureData.UseVisualStyleBackColor = true;
            this.btnSetCaptureData.Click += new System.EventHandler(this.btnSetCaptureData_Click);
            // 
            // txtCaptureHeight
            // 
            this.txtCaptureHeight.Location = new System.Drawing.Point(308, 19);
            this.txtCaptureHeight.Name = "txtCaptureHeight";
            this.txtCaptureHeight.Size = new System.Drawing.Size(49, 20);
            this.txtCaptureHeight.TabIndex = 15;
            this.txtCaptureHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // txtCaptureWidth
            // 
            this.txtCaptureWidth.Location = new System.Drawing.Point(206, 19);
            this.txtCaptureWidth.Name = "txtCaptureWidth";
            this.txtCaptureWidth.Size = new System.Drawing.Size(49, 20);
            this.txtCaptureWidth.TabIndex = 14;
            this.txtCaptureWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // txtCaptureY
            // 
            this.txtCaptureY.Location = new System.Drawing.Point(107, 19);
            this.txtCaptureY.Name = "txtCaptureY";
            this.txtCaptureY.Size = new System.Drawing.Size(49, 20);
            this.txtCaptureY.TabIndex = 13;
            this.txtCaptureY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // txtCaptureX
            // 
            this.txtCaptureX.Location = new System.Drawing.Point(29, 19);
            this.txtCaptureX.Name = "txtCaptureX";
            this.txtCaptureX.Size = new System.Drawing.Size(49, 20);
            this.txtCaptureX.TabIndex = 12;
            this.txtCaptureX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblCaptureHeight
            // 
            this.lblCaptureHeight.AutoSize = true;
            this.lblCaptureHeight.Location = new System.Drawing.Point(261, 22);
            this.lblCaptureHeight.Name = "lblCaptureHeight";
            this.lblCaptureHeight.Size = new System.Drawing.Size(41, 13);
            this.lblCaptureHeight.TabIndex = 11;
            this.lblCaptureHeight.Text = "Height:";
            // 
            // lblCaptureWidth
            // 
            this.lblCaptureWidth.AutoSize = true;
            this.lblCaptureWidth.Location = new System.Drawing.Point(162, 22);
            this.lblCaptureWidth.Name = "lblCaptureWidth";
            this.lblCaptureWidth.Size = new System.Drawing.Size(38, 13);
            this.lblCaptureWidth.TabIndex = 10;
            this.lblCaptureWidth.Text = "Width:";
            // 
            // lblCaptureY
            // 
            this.lblCaptureY.AutoSize = true;
            this.lblCaptureY.Location = new System.Drawing.Point(84, 22);
            this.lblCaptureY.Name = "lblCaptureY";
            this.lblCaptureY.Size = new System.Drawing.Size(17, 13);
            this.lblCaptureY.TabIndex = 9;
            this.lblCaptureY.Text = "Y:";
            // 
            // lblCaptureX
            // 
            this.lblCaptureX.AutoSize = true;
            this.lblCaptureX.Location = new System.Drawing.Point(6, 22);
            this.lblCaptureX.Name = "lblCaptureX";
            this.lblCaptureX.Size = new System.Drawing.Size(17, 13);
            this.lblCaptureX.TabIndex = 8;
            this.lblCaptureX.Text = "X:";
            // 
            // timerClearCaptureStatus
            // 
            this.timerClearCaptureStatus.Interval = 3000;
            this.timerClearCaptureStatus.Tick += new System.EventHandler(this.timerClearCaptureStatus_Tick);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(12, 307);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(227, 20);
            this.txtTime.TabIndex = 9;
            // 
            // txtUniqueStrings
            // 
            this.txtUniqueStrings.Location = new System.Drawing.Point(12, 333);
            this.txtUniqueStrings.Name = "txtUniqueStrings";
            this.txtUniqueStrings.Size = new System.Drawing.Size(227, 290);
            this.txtUniqueStrings.TabIndex = 10;
            this.txtUniqueStrings.Text = "";
            // 
            // txtAddManualString
            // 
            this.txtAddManualString.Location = new System.Drawing.Point(6, 19);
            this.txtAddManualString.Name = "txtAddManualString";
            this.txtAddManualString.Size = new System.Drawing.Size(214, 20);
            this.txtAddManualString.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.lblAddManualStringStatus);
            this.groupBox1.Controls.Add(this.btnAddManualString);
            this.groupBox1.Controls.Add(this.txtAddManualString);
            this.groupBox1.Location = new System.Drawing.Point(13, 656);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 98);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add manual string:";
            // 
            // lblAddManualStringStatus
            // 
            this.lblAddManualStringStatus.AutoSize = true;
            this.lblAddManualStringStatus.Location = new System.Drawing.Point(87, 47);
            this.lblAddManualStringStatus.Name = "lblAddManualStringStatus";
            this.lblAddManualStringStatus.Size = new System.Drawing.Size(0, 13);
            this.lblAddManualStringStatus.TabIndex = 13;
            // 
            // btnAddManualString
            // 
            this.btnAddManualString.Location = new System.Drawing.Point(6, 42);
            this.btnAddManualString.Name = "btnAddManualString";
            this.btnAddManualString.Size = new System.Drawing.Size(75, 23);
            this.btnAddManualString.TabIndex = 12;
            this.btnAddManualString.Text = "&Add";
            this.btnAddManualString.UseVisualStyleBackColor = true;
            this.btnAddManualString.Click += new System.EventHandler(this.btnAddManualString_Click);
            // 
            // timerClearAddManualStringStatus
            // 
            this.timerClearAddManualStringStatus.Interval = 5000;
            this.timerClearAddManualStringStatus.Tick += new System.EventHandler(this.timerClearAddManualStringStatus_Tick);
            // 
            // btnClearUniqueStrings
            // 
            this.btnClearUniqueStrings.Location = new System.Drawing.Point(12, 629);
            this.btnClearUniqueStrings.Name = "btnClearUniqueStrings";
            this.btnClearUniqueStrings.Size = new System.Drawing.Size(227, 23);
            this.btnClearUniqueStrings.TabIndex = 13;
            this.btnClearUniqueStrings.Text = "&Clear";
            this.btnClearUniqueStrings.UseVisualStyleBackColor = true;
            this.btnClearUniqueStrings.Click += new System.EventHandler(this.btnClearUniqueStrings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1096, 848);
            this.Controls.Add(this.btnClearUniqueStrings);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtUniqueStrings);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.grpCapture);
            this.Controls.Add(this.grpEnemy3);
            this.Controls.Add(this.grpEnemy2);
            this.Controls.Add(this.grpEnemy1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy1)).EndInit();
            this.grpEnemy1.ResumeLayout(false);
            this.grpEnemy2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy3)).EndInit();
            this.grpEnemy3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCapture)).EndInit();
            this.grpCapture.ResumeLayout(false);
            this.grpCapture.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pbEnemy1;
        private System.Windows.Forms.Timer timerRecognize;
        private System.Windows.Forms.GroupBox grpEnemy1;
        private System.Windows.Forms.RichTextBox txtEnemy1;
        private System.Windows.Forms.GroupBox grpEnemy2;
        private System.Windows.Forms.RichTextBox txtEnemy2;
        private System.Windows.Forms.PictureBox pbEnemy2;
        private System.Windows.Forms.RichTextBox txtEnemy3;
        private System.Windows.Forms.PictureBox pbEnemy3;
        private System.Windows.Forms.GroupBox grpEnemy3;
        private System.Windows.Forms.PictureBox pbCapture;
        private System.Windows.Forms.GroupBox grpCapture;
        private System.Windows.Forms.TextBox txtCaptureHeight;
        private System.Windows.Forms.TextBox txtCaptureWidth;
        private System.Windows.Forms.TextBox txtCaptureY;
        private System.Windows.Forms.TextBox txtCaptureX;
        private System.Windows.Forms.Label lblCaptureHeight;
        private System.Windows.Forms.Label lblCaptureWidth;
        private System.Windows.Forms.Label lblCaptureY;
        private System.Windows.Forms.Label lblCaptureX;
        private System.Windows.Forms.Button btnSetCaptureData;
        private System.Windows.Forms.Label lblCaptureStatus;
        private System.Windows.Forms.Timer timerClearCaptureStatus;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.RichTextBox txtUniqueStrings;
        private System.Windows.Forms.TextBox txtAddManualString;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddManualString;
        private System.Windows.Forms.Label lblAddManualStringStatus;
        private System.Windows.Forms.Timer timerClearAddManualStringStatus;
        private System.Windows.Forms.Button btnClearUniqueStrings;
    }
}

