namespace SceneEditor
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCapturePB = new System.Windows.Forms.Button();
            this.btnCaptureWPC = new System.Windows.Forms.Button();
            this.lblFrame = new System.Windows.Forms.Label();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cmbBrushSize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.scrlFrame = new System.Windows.Forms.HScrollBar();
            this.cbFlatColour = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkClock = new System.Windows.Forms.CheckBox();
            this.txtFrameDelay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.radFill = new System.Windows.Forms.RadioButton();
            this.radPen = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearMask = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dmdEdit1 = new SceneEditor.DmdEdit();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkFirstBlank = new System.Windows.Forms.CheckBox();
            this.chkFirstClock = new System.Windows.Forms.CheckBox();
            this.txtFirstFrameDelay = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkLastBlank = new System.Windows.Forms.CheckBox();
            this.chkLastClock = new System.Windows.Forms.CheckBox();
            this.txtLastFrameDelay = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbClockStyle = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(247, 401);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCapturePB
            // 
            this.btnCapturePB.Location = new System.Drawing.Point(332, 153);
            this.btnCapturePB.Name = "btnCapturePB";
            this.btnCapturePB.Size = new System.Drawing.Size(90, 23);
            this.btnCapturePB.TabIndex = 5;
            this.btnCapturePB.Text = "Capture PB";
            this.btnCapturePB.UseVisualStyleBackColor = true;
            this.btnCapturePB.Click += new System.EventHandler(this.btnCapturePB_Click);
            // 
            // btnCaptureWPC
            // 
            this.btnCaptureWPC.Location = new System.Drawing.Point(428, 153);
            this.btnCaptureWPC.Name = "btnCaptureWPC";
            this.btnCaptureWPC.Size = new System.Drawing.Size(90, 23);
            this.btnCaptureWPC.TabIndex = 6;
            this.btnCaptureWPC.Text = "Capture WPC";
            this.btnCaptureWPC.UseVisualStyleBackColor = true;
            this.btnCaptureWPC.Click += new System.EventHandler(this.btnCaptureWPC_Click);
            // 
            // lblFrame
            // 
            this.lblFrame.Location = new System.Drawing.Point(6, 158);
            this.lblFrame.Name = "lblFrame";
            this.lblFrame.Size = new System.Drawing.Size(230, 22);
            this.lblFrame.TabIndex = 9;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(328, 401);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAs.TabIndex = 10;
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(93, 401);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cmbBrushSize
            // 
            this.cmbBrushSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrushSize.FormattingEnabled = true;
            this.cmbBrushSize.Items.AddRange(new object[] {
            "1",
            "3",
            "5",
            "7",
            "9",
            "11",
            "13",
            "15"});
            this.cmbBrushSize.Location = new System.Drawing.Point(396, 181);
            this.cmbBrushSize.Name = "cmbBrushSize";
            this.cmbBrushSize.Size = new System.Drawing.Size(121, 21);
            this.cmbBrushSize.TabIndex = 12;
            this.cmbBrushSize.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Pen Size";
            // 
            // scrlFrame
            // 
            this.scrlFrame.LargeChange = 1;
            this.scrlFrame.Location = new System.Drawing.Point(8, 180);
            this.scrlFrame.Maximum = 0;
            this.scrlFrame.Name = "scrlFrame";
            this.scrlFrame.Size = new System.Drawing.Size(237, 17);
            this.scrlFrame.TabIndex = 14;
            this.scrlFrame.ValueChanged += new System.EventHandler(this.scrlFrame_ValueChanged);
            // 
            // cbFlatColour
            // 
            this.cbFlatColour.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbFlatColour.Location = new System.Drawing.Point(332, 208);
            this.cbFlatColour.Name = "cbFlatColour";
            this.cbFlatColour.Size = new System.Drawing.Size(185, 24);
            this.cbFlatColour.TabIndex = 15;
            this.cbFlatColour.Text = "Flatten Colour";
            this.cbFlatColour.UseVisualStyleBackColor = true;
            this.cbFlatColour.CheckedChanged += new System.EventHandler(this.cbFlatColour_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkClock);
            this.groupBox1.Controls.Add(this.txtFrameDelay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(192, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 66);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Other Frames";
            // 
            // chkClock
            // 
            this.chkClock.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkClock.Location = new System.Drawing.Point(6, 44);
            this.chkClock.Name = "chkClock";
            this.chkClock.Size = new System.Drawing.Size(156, 17);
            this.chkClock.TabIndex = 4;
            this.chkClock.Text = "Clock On Top";
            this.chkClock.UseVisualStyleBackColor = true;
            // 
            // txtFrameDelay
            // 
            this.txtFrameDelay.Location = new System.Drawing.Point(113, 18);
            this.txtFrameDelay.MaxLength = 6;
            this.txtFrameDelay.Name = "txtFrameDelay";
            this.txtFrameDelay.Size = new System.Drawing.Size(49, 20);
            this.txtFrameDelay.TabIndex = 3;
            this.txtFrameDelay.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Frame Delay:";
            // 
            // txtFilename
            // 
            this.txtFilename.BackColor = System.Drawing.SystemColors.Window;
            this.txtFilename.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilename.Enabled = false;
            this.txtFilename.Location = new System.Drawing.Point(79, 9);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(462, 13);
            this.txtFilename.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "File name:";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 401);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 17;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(8, 209);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // radFill
            // 
            this.radFill.Appearance = System.Windows.Forms.Appearance.Button;
            this.radFill.Location = new System.Drawing.Point(81, 3);
            this.radFill.Name = "radFill";
            this.radFill.Size = new System.Drawing.Size(72, 24);
            this.radFill.TabIndex = 5;
            this.radFill.Text = "Fill";
            this.radFill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radFill.UseVisualStyleBackColor = true;
            this.radFill.CheckedChanged += new System.EventHandler(this.radFill_CheckedChanged);
            // 
            // radPen
            // 
            this.radPen.Appearance = System.Windows.Forms.Appearance.Button;
            this.radPen.Checked = true;
            this.radPen.Location = new System.Drawing.Point(3, 3);
            this.radPen.Name = "radPen";
            this.radPen.Size = new System.Drawing.Size(72, 24);
            this.radPen.TabIndex = 19;
            this.radPen.TabStop = true;
            this.radPen.Text = "Pen";
            this.radPen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radPen.UseVisualStyleBackColor = true;
            this.radPen.CheckedChanged += new System.EventHandler(this.radPen_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radFill);
            this.panel1.Controls.Add(this.radPen);
            this.panel1.Location = new System.Drawing.Point(170, 205);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 34);
            this.panel1.TabIndex = 5;
            // 
            // btnClearMask
            // 
            this.btnClearMask.Location = new System.Drawing.Point(89, 209);
            this.btnClearMask.Name = "btnClearMask";
            this.btnClearMask.Size = new System.Drawing.Size(75, 23);
            this.btnClearMask.TabIndex = 19;
            this.btnClearMask.Text = "Clear Mask";
            this.btnClearMask.UseVisualStyleBackColor = true;
            this.btnClearMask.Click += new System.EventHandler(this.btnClearMask_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dmdEdit1);
            this.groupBox2.Controls.Add(this.btnClearMask);
            this.groupBox2.Controls.Add(this.btnCapturePB);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.btnCaptureWPC);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.lblFrame);
            this.groupBox2.Controls.Add(this.cmbBrushSize);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbFlatColour);
            this.groupBox2.Controls.Add(this.scrlFrame);
            this.groupBox2.Location = new System.Drawing.Point(12, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(529, 248);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Frames";
            // 
            // dmdEdit1
            // 
            this.dmdEdit1.BrushSize = 1;
            this.dmdEdit1.IsDirty = false;
            this.dmdEdit1.Location = new System.Drawing.Point(6, 19);
            this.dmdEdit1.Name = "dmdEdit1";
            this.dmdEdit1.Size = new System.Drawing.Size(512, 128);
            this.dmdEdit1.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.chkFirstBlank);
            this.groupBox3.Controls.Add(this.chkFirstClock);
            this.groupBox3.Controls.Add(this.txtFirstFrameDelay);
            this.groupBox3.Location = new System.Drawing.Point(12, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(170, 109);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "First Frame";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Frame Delay:";
            // 
            // chkFirstBlank
            // 
            this.chkFirstBlank.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFirstBlank.Location = new System.Drawing.Point(6, 70);
            this.chkFirstBlank.Name = "chkFirstBlank";
            this.chkFirstBlank.Size = new System.Drawing.Size(158, 24);
            this.chkFirstBlank.TabIndex = 23;
            this.chkFirstBlank.TabStop = false;
            this.chkFirstBlank.Text = "Blank";
            this.chkFirstBlank.UseVisualStyleBackColor = true;
            // 
            // chkFirstClock
            // 
            this.chkFirstClock.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFirstClock.Location = new System.Drawing.Point(6, 42);
            this.chkFirstClock.Name = "chkFirstClock";
            this.chkFirstClock.Size = new System.Drawing.Size(158, 24);
            this.chkFirstClock.TabIndex = 22;
            this.chkFirstClock.TabStop = false;
            this.chkFirstClock.Text = "Clock On Top";
            this.chkFirstClock.UseVisualStyleBackColor = true;
            // 
            // txtFirstFrameDelay
            // 
            this.txtFirstFrameDelay.Location = new System.Drawing.Point(115, 18);
            this.txtFirstFrameDelay.MaxLength = 6;
            this.txtFirstFrameDelay.Name = "txtFirstFrameDelay";
            this.txtFirstFrameDelay.Size = new System.Drawing.Size(49, 20);
            this.txtFirstFrameDelay.TabIndex = 22;
            this.txtFirstFrameDelay.Text = "0";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.chkLastBlank);
            this.groupBox4.Controls.Add(this.chkLastClock);
            this.groupBox4.Controls.Add(this.txtLastFrameDelay);
            this.groupBox4.Location = new System.Drawing.Point(371, 32);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(170, 109);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Last Frame";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Frame Delay:";
            // 
            // chkLastBlank
            // 
            this.chkLastBlank.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLastBlank.Location = new System.Drawing.Point(6, 70);
            this.chkLastBlank.Name = "chkLastBlank";
            this.chkLastBlank.Size = new System.Drawing.Size(158, 24);
            this.chkLastBlank.TabIndex = 24;
            this.chkLastBlank.TabStop = false;
            this.chkLastBlank.Text = "Blank";
            this.chkLastBlank.UseVisualStyleBackColor = true;
            // 
            // chkLastClock
            // 
            this.chkLastClock.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLastClock.Location = new System.Drawing.Point(6, 42);
            this.chkLastClock.Name = "chkLastClock";
            this.chkLastClock.Size = new System.Drawing.Size(158, 24);
            this.chkLastClock.TabIndex = 22;
            this.chkLastClock.TabStop = false;
            this.chkLastClock.Text = "Clock On Top";
            this.chkLastClock.UseVisualStyleBackColor = true;
            // 
            // txtLastFrameDelay
            // 
            this.txtLastFrameDelay.Location = new System.Drawing.Point(115, 18);
            this.txtLastFrameDelay.MaxLength = 6;
            this.txtLastFrameDelay.Name = "txtLastFrameDelay";
            this.txtLastFrameDelay.Size = new System.Drawing.Size(49, 20);
            this.txtLastFrameDelay.TabIndex = 22;
            this.txtLastFrameDelay.Text = "0";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(466, 401);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmbClockStyle);
            this.groupBox5.Location = new System.Drawing.Point(192, 99);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(170, 42);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Clock Style";
            // 
            // cmbClockStyle
            // 
            this.cmbClockStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClockStyle.FormattingEnabled = true;
            this.cmbClockStyle.Items.AddRange(new object[] {
            "Standard",
            "Small Left",
            "Small Centre",
            "Small Right",
            "Small Mid Left",
            "Small Mid Right"});
            this.cmbClockStyle.Location = new System.Drawing.Point(6, 15);
            this.cmbClockStyle.Name = "cmbClockStyle";
            this.cmbClockStyle.Size = new System.Drawing.Size(156, 21);
            this.cmbClockStyle.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 433);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "DotClk - Scene Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private DmdEdit dmdEdit1;
        private System.Windows.Forms.Button btnCapturePB;
        private System.Windows.Forms.Button btnCaptureWPC;
        private System.Windows.Forms.Label lblFrame;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ComboBox cmbBrushSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar scrlFrame;
        private System.Windows.Forms.CheckBox cbFlatColour;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkClock;
        private System.Windows.Forms.TextBox txtFrameDelay;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.RadioButton radFill;
        private System.Windows.Forms.RadioButton radPen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClearMask;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkFirstBlank;
        private System.Windows.Forms.CheckBox chkFirstClock;
        private System.Windows.Forms.TextBox txtFirstFrameDelay;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkLastBlank;
        private System.Windows.Forms.CheckBox chkLastClock;
        private System.Windows.Forms.TextBox txtLastFrameDelay;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cmbClockStyle;
    }
}

