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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpEnemy1 = new System.Windows.Forms.GroupBox();
            this.txtEnemy1 = new System.Windows.Forms.RichTextBox();
            this.grpEnemy2 = new System.Windows.Forms.GroupBox();
            this.txtEnemy2 = new System.Windows.Forms.RichTextBox();
            this.pbEnemy2 = new System.Windows.Forms.PictureBox();
            this.txtEnemy3 = new System.Windows.Forms.RichTextBox();
            this.pbEnemy3 = new System.Windows.Forms.PictureBox();
            this.grpEnemy3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy1)).BeginInit();
            this.grpEnemy1.SuspendLayout();
            this.grpEnemy2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy3)).BeginInit();
            this.grpEnemy3.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(227, 550);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // pbEnemy1
            // 
            this.pbEnemy1.Location = new System.Drawing.Point(6, 19);
            this.pbEnemy1.Name = "pbEnemy1";
            this.pbEnemy1.Size = new System.Drawing.Size(128, 128);
            this.pbEnemy1.TabIndex = 1;
            this.pbEnemy1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // grpEnemy1
            // 
            this.grpEnemy1.Controls.Add(this.txtEnemy1);
            this.grpEnemy1.Controls.Add(this.pbEnemy1);
            this.grpEnemy1.Location = new System.Drawing.Point(245, 12);
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
            this.grpEnemy2.Controls.Add(this.txtEnemy2);
            this.grpEnemy2.Controls.Add(this.pbEnemy2);
            this.grpEnemy2.Location = new System.Drawing.Point(245, 290);
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
            this.pbEnemy2.Location = new System.Drawing.Point(6, 19);
            this.pbEnemy2.Name = "pbEnemy2";
            this.pbEnemy2.Size = new System.Drawing.Size(128, 128);
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
            this.pbEnemy3.TabIndex = 1;
            this.pbEnemy3.TabStop = false;
            // 
            // grpEnemy3
            // 
            this.grpEnemy3.Controls.Add(this.txtEnemy3);
            this.grpEnemy3.Controls.Add(this.pbEnemy3);
            this.grpEnemy3.Location = new System.Drawing.Point(639, 12);
            this.grpEnemy3.Name = "grpEnemy3";
            this.grpEnemy3.Size = new System.Drawing.Size(388, 272);
            this.grpEnemy3.TabIndex = 6;
            this.grpEnemy3.TabStop = false;
            this.grpEnemy3.Text = "Enemy 3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 578);
            this.Controls.Add(this.grpEnemy3);
            this.Controls.Add(this.grpEnemy2);
            this.Controls.Add(this.grpEnemy1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy1)).EndInit();
            this.grpEnemy1.ResumeLayout(false);
            this.grpEnemy2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy3)).EndInit();
            this.grpEnemy3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pbEnemy1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox grpEnemy1;
        private System.Windows.Forms.RichTextBox txtEnemy1;
        private System.Windows.Forms.GroupBox grpEnemy2;
        private System.Windows.Forms.RichTextBox txtEnemy2;
        private System.Windows.Forms.PictureBox pbEnemy2;
        private System.Windows.Forms.RichTextBox txtEnemy3;
        private System.Windows.Forms.PictureBox pbEnemy3;
        private System.Windows.Forms.GroupBox grpEnemy3;
    }
}

