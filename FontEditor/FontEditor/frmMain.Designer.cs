namespace WindowsFormsApplication1
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
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbMask = new System.Windows.Forms.RadioButton();
            this.rbDot = new System.Windows.Forms.RadioButton();
            this.cbColour = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFillMask = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnClearDots = new System.Windows.Forms.Button();
            this.btnClearMask = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblKerning = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.scrlChar = new System.Windows.Forms.HScrollBar();
            this.btnNewChar = new System.Windows.Forms.Button();
            this.lblAsciiCode = new System.Windows.Forms.Label();
            this.btnDelChar = new System.Windows.Forms.Button();
            this.lblAsciiChar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblFileDetails = new System.Windows.Forms.Label();
            this.fontEdit1 = new WindowsFormsApplication1.FontEdit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 3;
            this.hScrollBar1.Location = new System.Drawing.Point(3, 16);
            this.hScrollBar1.Maximum = 20;
            this.hScrollBar1.Minimum = 3;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(268, 17);
            this.hScrollBar1.TabIndex = 0;
            this.hScrollBar1.Value = 3;
            this.hScrollBar1.ValueChanged += new System.EventHandler(this.hScrollBar1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbMask);
            this.panel1.Controls.Add(this.rbDot);
            this.panel1.Location = new System.Drawing.Point(6, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 29);
            this.panel1.TabIndex = 4;
            // 
            // rbMask
            // 
            this.rbMask.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbMask.Location = new System.Drawing.Point(86, 3);
            this.rbMask.Name = "rbMask";
            this.rbMask.Size = new System.Drawing.Size(77, 23);
            this.rbMask.TabIndex = 1;
            this.rbMask.Text = "Mask";
            this.rbMask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbMask.UseVisualStyleBackColor = true;
            this.rbMask.CheckedChanged += new System.EventHandler(this.rbDotMask_CheckChanged);
            // 
            // rbDot
            // 
            this.rbDot.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDot.Checked = true;
            this.rbDot.Location = new System.Drawing.Point(3, 3);
            this.rbDot.Name = "rbDot";
            this.rbDot.Size = new System.Drawing.Size(77, 24);
            this.rbDot.TabIndex = 0;
            this.rbDot.TabStop = true;
            this.rbDot.Text = "Dot";
            this.rbDot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbDot.UseVisualStyleBackColor = true;
            this.rbDot.CheckedChanged += new System.EventHandler(this.rbDotMask_CheckChanged);
            // 
            // cbColour
            // 
            this.cbColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColour.FormattingEnabled = true;
            this.cbColour.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cbColour.Location = new System.Drawing.Point(450, 12);
            this.cbColour.Name = "cbColour";
            this.cbColour.Size = new System.Drawing.Size(121, 21);
            this.cbColour.TabIndex = 1;
            this.cbColour.SelectedIndexChanged += new System.EventHandler(this.cbColour_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFillMask);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btnClearDots);
            this.groupBox1.Controls.Add(this.btnClearMask);
            this.groupBox1.Controls.Add(this.hScrollBar1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.cbColour);
            this.groupBox1.Location = new System.Drawing.Point(12, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paint";
            // 
            // btnFillMask
            // 
            this.btnFillMask.Location = new System.Drawing.Point(339, 39);
            this.btnFillMask.Name = "btnFillMask";
            this.btnFillMask.Size = new System.Drawing.Size(75, 23);
            this.btnFillMask.TabIndex = 6;
            this.btnFillMask.Text = "Fill Mask";
            this.btnFillMask.UseVisualStyleBackColor = true;
            this.btnFillMask.Click += new System.EventHandler(this.btnFillMask_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(480, 43);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Flatten Colour";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnClearDots
            // 
            this.btnClearDots.Location = new System.Drawing.Point(177, 39);
            this.btnClearDots.Name = "btnClearDots";
            this.btnClearDots.Size = new System.Drawing.Size(75, 23);
            this.btnClearDots.TabIndex = 2;
            this.btnClearDots.Text = "Clear Dots";
            this.btnClearDots.UseVisualStyleBackColor = true;
            this.btnClearDots.Click += new System.EventHandler(this.btnClearDots_Click);
            // 
            // btnClearMask
            // 
            this.btnClearMask.Location = new System.Drawing.Point(258, 39);
            this.btnClearMask.Name = "btnClearMask";
            this.btnClearMask.Size = new System.Drawing.Size(75, 23);
            this.btnClearMask.TabIndex = 3;
            this.btnClearMask.Text = "Clear Mask";
            this.btnClearMask.UseVisualStyleBackColor = true;
            this.btnClearMask.Click += new System.EventHandler(this.btnClearMask_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblKerning);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblHeight);
            this.groupBox2.Controls.Add(this.lblWidth);
            this.groupBox2.Controls.Add(this.scrlChar);
            this.groupBox2.Controls.Add(this.btnNewChar);
            this.groupBox2.Controls.Add(this.lblAsciiCode);
            this.groupBox2.Controls.Add(this.btnDelChar);
            this.groupBox2.Controls.Add(this.lblAsciiChar);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 81);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Character";
            // 
            // lblKerning
            // 
            this.lblKerning.Location = new System.Drawing.Point(412, 16);
            this.lblKerning.Name = "lblKerning";
            this.lblKerning.Size = new System.Drawing.Size(103, 13);
            this.lblKerning.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(365, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Kerning:";
            // 
            // lblHeight
            // 
            this.lblHeight.Location = new System.Drawing.Point(230, 34);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(103, 13);
            this.lblHeight.TabIndex = 10;
            // 
            // lblWidth
            // 
            this.lblWidth.Location = new System.Drawing.Point(230, 16);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(103, 13);
            this.lblWidth.TabIndex = 9;
            // 
            // scrlChar
            // 
            this.scrlChar.LargeChange = 1;
            this.scrlChar.Location = new System.Drawing.Point(9, 51);
            this.scrlChar.Maximum = 0;
            this.scrlChar.Name = "scrlChar";
            this.scrlChar.Size = new System.Drawing.Size(403, 17);
            this.scrlChar.TabIndex = 0;
            this.scrlChar.ValueChanged += new System.EventHandler(this.scrlChar_ValueChanged);
            // 
            // btnNewChar
            // 
            this.btnNewChar.Location = new System.Drawing.Point(415, 51);
            this.btnNewChar.Name = "btnNewChar";
            this.btnNewChar.Size = new System.Drawing.Size(75, 23);
            this.btnNewChar.TabIndex = 0;
            this.btnNewChar.Text = "New/Amend";
            this.btnNewChar.UseVisualStyleBackColor = true;
            this.btnNewChar.Click += new System.EventHandler(this.btnNewChar_Click);
            // 
            // lblAsciiCode
            // 
            this.lblAsciiCode.Location = new System.Drawing.Point(89, 34);
            this.lblAsciiCode.Name = "lblAsciiCode";
            this.lblAsciiCode.Size = new System.Drawing.Size(82, 13);
            this.lblAsciiCode.TabIndex = 6;
            // 
            // btnDelChar
            // 
            this.btnDelChar.Location = new System.Drawing.Point(496, 51);
            this.btnDelChar.Name = "btnDelChar";
            this.btnDelChar.Size = new System.Drawing.Size(75, 23);
            this.btnDelChar.TabIndex = 2;
            this.btnDelChar.Text = "Delete";
            this.btnDelChar.UseVisualStyleBackColor = true;
            this.btnDelChar.Click += new System.EventHandler(this.btnDelChar_Click);
            // 
            // lblAsciiChar
            // 
            this.lblAsciiChar.Location = new System.Drawing.Point(89, 16);
            this.lblAsciiChar.Name = "lblAsciiChar";
            this.lblAsciiChar.Size = new System.Drawing.Size(82, 13);
            this.lblAsciiChar.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Height:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ascii Character:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ascii Code:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(433, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(514, 3);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "Convert...";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New...";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(93, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblFileDetails
            // 
            this.lblFileDetails.Location = new System.Drawing.Point(174, 8);
            this.lblFileDetails.Name = "lblFileDetails";
            this.lblFileDetails.Size = new System.Drawing.Size(253, 18);
            this.lblFileDetails.TabIndex = 7;
            // 
            // fontEdit1
            // 
            this.fontEdit1.DotColour = ((ushort)(15));
            this.fontEdit1.Dots = null;
            this.fontEdit1.DotSide = 7;
            this.fontEdit1.IsDirty = false;
            this.fontEdit1.Location = new System.Drawing.Point(12, 197);
            this.fontEdit1.Mask = null;
            this.fontEdit1.Mode = WindowsFormsApplication1.FontEdit.DrawMode.DOT;
            this.fontEdit1.Name = "fontEdit1";
            this.fontEdit1.Size = new System.Drawing.Size(150, 150);
            this.fontEdit1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 523);
            this.Controls.Add(this.lblFileDetails);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fontEdit1);
            this.Name = "MainForm";
            this.Text = "Font Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontEdit fontEdit1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbMask;
        private System.Windows.Forms.RadioButton rbDot;
        private System.Windows.Forms.ComboBox cbColour;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClearDots;
        private System.Windows.Forms.Button btnClearMask;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar scrlChar;
        private System.Windows.Forms.Button btnNewChar;
        private System.Windows.Forms.Button btnDelChar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblFileDetails;
        private System.Windows.Forms.Label lblKerning;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblAsciiCode;
        private System.Windows.Forms.Label lblAsciiChar;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnFillMask;
    }
}

