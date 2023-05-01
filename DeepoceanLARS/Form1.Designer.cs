namespace DeepoceanLARS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            txtaccX = new TextBox();
            txtaccY = new TextBox();
            txtaccZ = new TextBox();
            panel1 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            panel2 = new Panel();
            label8 = new Label();
            txtRange = new TextBox();
            label7 = new Label();
            panel3 = new Panel();
            txtCUSV = new TextBox();
            txtCROV = new TextBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            panel4 = new Panel();
            txtaccUSVz = new TextBox();
            txtaccUSVy = new TextBox();
            txtaccUSVx = new TextBox();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            btnStart = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(65, 439);
            richTextBox1.Margin = new Padding(4);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(766, 320);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 396);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(318, 396);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // txtaccX
            // 
            txtaccX.BackColor = Color.White;
            txtaccX.ForeColor = SystemColors.WindowText;
            txtaccX.Location = new Point(89, 72);
            txtaccX.Margin = new Padding(4);
            txtaccX.Name = "txtaccX";
            txtaccX.Size = new Size(155, 31);
            txtaccX.TabIndex = 3;
            txtaccX.TextChanged += txtaccX_TextChanged;
            // 
            // txtaccY
            // 
            txtaccY.Location = new Point(89, 114);
            txtaccY.Margin = new Padding(4);
            txtaccY.Name = "txtaccY";
            txtaccY.Size = new Size(155, 31);
            txtaccY.TabIndex = 4;
            txtaccY.TextChanged += txtaccY_TextChanged;
            // 
            // txtaccZ
            // 
            txtaccZ.Location = new Point(89, 155);
            txtaccZ.Margin = new Padding(4);
            txtaccZ.Name = "txtaccZ";
            txtaccZ.Size = new Size(155, 31);
            txtaccZ.TabIndex = 5;
            txtaccZ.TextChanged += txtaccZ_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtaccX);
            panel1.Controls.Add(txtaccZ);
            panel1.Controls.Add(txtaccY);
            panel1.Location = new Point(68, 71);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(291, 220);
            panel1.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(72, 22);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(139, 25);
            label6.TabIndex = 9;
            label6.Text = "Angles for ROV:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 155);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(46, 25);
            label5.TabIndex = 8;
            label5.Text = "Yaw:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 114);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(59, 25);
            label4.TabIndex = 7;
            label4.Text = "Pitch: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 76);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(50, 25);
            label3.TabIndex = 6;
            label3.Text = "Roll: ";
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // panel2
            // 
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtRange);
            panel2.Controls.Add(label7);
            panel2.Location = new Point(851, 41);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(312, 156);
            panel2.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(235, 80);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(28, 25);
            label8.TabIndex = 11;
            label8.Text = "m";
            // 
            // txtRange
            // 
            txtRange.BackColor = Color.White;
            txtRange.ForeColor = SystemColors.WindowText;
            txtRange.Location = new Point(71, 76);
            txtRange.Margin = new Padding(4);
            txtRange.Name = "txtRange";
            txtRange.Size = new Size(155, 31);
            txtRange.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(26, 22);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(252, 25);
            label7.TabIndex = 7;
            label7.Text = "Range between ROV and USV:";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtCUSV);
            panel3.Controls.Add(txtCROV);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label9);
            panel3.Location = new Point(1202, 58);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(208, 194);
            panel3.TabIndex = 8;
            // 
            // txtCUSV
            // 
            txtCUSV.BackColor = Color.Red;
            txtCUSV.ForeColor = SystemColors.WindowText;
            txtCUSV.Location = new Point(86, 124);
            txtCUSV.Margin = new Padding(4);
            txtCUSV.Name = "txtCUSV";
            txtCUSV.Size = new Size(39, 31);
            txtCUSV.TabIndex = 13;
            // 
            // txtCROV
            // 
            txtCROV.BackColor = Color.Red;
            txtCROV.ForeColor = SystemColors.WindowText;
            txtCROV.Location = new Point(86, 82);
            txtCROV.Margin = new Padding(4);
            txtCROV.Name = "txtCROV";
            txtCROV.Size = new Size(39, 31);
            txtCROV.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(28, 128);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(49, 25);
            label11.TabIndex = 10;
            label11.Text = "USV:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(28, 86);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(52, 25);
            label10.TabIndex = 9;
            label10.Text = "ROV:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(52, 14);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(106, 25);
            label9.TabIndex = 8;
            label9.Text = "Connection:";
            // 
            // panel4
            // 
            panel4.Controls.Add(txtaccUSVz);
            panel4.Controls.Add(txtaccUSVy);
            panel4.Controls.Add(txtaccUSVx);
            panel4.Controls.Add(label15);
            panel4.Controls.Add(label14);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(label12);
            panel4.Location = new Point(377, 71);
            panel4.Margin = new Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new Size(276, 220);
            panel4.TabIndex = 9;
            // 
            // txtaccUSVz
            // 
            txtaccUSVz.Location = new Point(71, 152);
            txtaccUSVz.Margin = new Padding(4);
            txtaccUSVz.Name = "txtaccUSVz";
            txtaccUSVz.Size = new Size(155, 31);
            txtaccUSVz.TabIndex = 11;
            // 
            // txtaccUSVy
            // 
            txtaccUSVy.Location = new Point(71, 114);
            txtaccUSVy.Margin = new Padding(4);
            txtaccUSVy.Name = "txtaccUSVy";
            txtaccUSVy.Size = new Size(155, 31);
            txtaccUSVy.TabIndex = 10;
            // 
            // txtaccUSVx
            // 
            txtaccUSVx.BackColor = Color.White;
            txtaccUSVx.ForeColor = SystemColors.WindowText;
            txtaccUSVx.Location = new Point(71, 72);
            txtaccUSVx.Margin = new Padding(4);
            txtaccUSVx.Name = "txtaccUSVx";
            txtaccUSVx.Size = new Size(155, 31);
            txtaccUSVx.TabIndex = 10;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(67, 22);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(136, 25);
            label15.TabIndex = 10;
            label15.Text = "Angles for USV:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(13, 158);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(46, 25);
            label14.TabIndex = 10;
            label14.Text = "Yaw:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(13, 117);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(59, 25);
            label13.TabIndex = 10;
            label13.Text = "Pitch: ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(13, 76);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(50, 25);
            label12.TabIndex = 10;
            label12.Text = "Roll: ";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(989, 435);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(290, 34);
            btnStart.TabIndex = 10;
            btnStart.Text = "Start recovery";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1455, 802);
            Controls.Add(btnStart);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private Label label1;
        private Label label2;
        private TextBox txtaccX;
        private TextBox txtaccY;
        private TextBox txtaccZ;
        private Panel panel1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Panel panel2;
        private Label label8;
        private TextBox txtRange;
        private Label label7;
        private Panel panel3;
        private TextBox txtCUSV;
        private TextBox txtCROV;
        private Label label11;
        private Label label10;
        private Label label9;
        private Panel panel4;
        private TextBox txtaccUSVz;
        private TextBox txtaccUSVy;
        private TextBox txtaccUSVx;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Button btnStart;
    }
}