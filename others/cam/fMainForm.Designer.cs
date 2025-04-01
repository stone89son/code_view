namespace CSoftwareConfirmADB
{
    partial class fMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMainForm));
            this.dgvPhonePass = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbKouteiName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbKiShu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbModel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRepairNo = new System.Windows.Forms.TextBox();
            this.txtImei = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lbResult = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.試験ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中断ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cAM確認位置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.色確認位置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.ptbCamera = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhonePass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.panel7.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCamera)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPhonePass
            // 
            this.dgvPhonePass.AccessibleName = "Table";
            this.dgvPhonePass.Location = new System.Drawing.Point(84, 100);
            this.dgvPhonePass.Name = "dgvPhonePass";
            this.dgvPhonePass.Size = new System.Drawing.Size(286, 156);
            this.dgvPhonePass.TabIndex = 46;
            this.dgvPhonePass.Text = "0";
            this.dgvPhonePass.DrawCell += new Syncfusion.WinForms.DataGrid.Events.DrawCellEventHandler(this.dgvPhonePass_DrawCell);
            // 
            // sfDataGrid1
            // 
            this.sfDataGrid1.AccessibleName = "Table";
            this.sfDataGrid1.Location = new System.Drawing.Point(102, 37);
            this.sfDataGrid1.Name = "sfDataGrid1";
            this.sfDataGrid1.Size = new System.Drawing.Size(197, 74);
            this.sfDataGrid1.TabIndex = 51;
            this.sfDataGrid1.Text = "0";
            this.sfDataGrid1.DrawCell += new Syncfusion.WinForms.DataGrid.Events.DrawCellEventHandler(this.sfDataGrid1_DrawCell);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(10, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 29);
            this.label5.TabIndex = 52;
            this.label5.Text = "確認項目";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.rtbStatus);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.txtRepairNo);
            this.panel2.Controls.Add(this.txtImei);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1184, 239);
            this.panel2.TabIndex = 55;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(473, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 53);
            this.button1.TabIndex = 88;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtbStatus
            // 
            this.rtbStatus.BackColor = System.Drawing.SystemColors.Control;
            this.rtbStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbStatus.ForeColor = System.Drawing.Color.Purple;
            this.rtbStatus.Location = new System.Drawing.Point(123, 192);
            this.rtbStatus.Margin = new System.Windows.Forms.Padding(6);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbStatus.Size = new System.Drawing.Size(810, 42);
            this.rtbStatus.TabIndex = 87;
            this.rtbStatus.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbKouteiName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lbKiShu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbModel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(812, 79);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "作業前確認";
            // 
            // lbKouteiName
            // 
            this.lbKouteiName.AutoSize = true;
            this.lbKouteiName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKouteiName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbKouteiName.Location = new System.Drawing.Point(132, 33);
            this.lbKouteiName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbKouteiName.Name = "lbKouteiName";
            this.lbKouteiName.Size = new System.Drawing.Size(146, 25);
            this.lbKouteiName.TabIndex = 72;
            this.lbKouteiName.Text = "lbKouteiName";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(40, 33);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 25);
            this.label7.TabIndex = 73;
            this.label7.Text = "工程名：";
            // 
            // lbKiShu
            // 
            this.lbKiShu.AutoSize = true;
            this.lbKiShu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKiShu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbKiShu.Location = new System.Drawing.Point(345, 33);
            this.lbKiShu.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbKiShu.Name = "lbKiShu";
            this.lbKiShu.Size = new System.Drawing.Size(83, 25);
            this.lbKiShu.TabIndex = 54;
            this.lbKiShu.Text = "lbKishu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(274, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 55;
            this.label3.Text = "機種：";
            // 
            // lbModel
            // 
            this.lbModel.AutoSize = true;
            this.lbModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbModel.Location = new System.Drawing.Point(641, 33);
            this.lbModel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(88, 25);
            this.lbModel.TabIndex = 58;
            this.lbModel.Text = "lbModel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(560, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 59;
            this.label4.Text = "Model：";
            // 
            // txtRepairNo
            // 
            this.txtRepairNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepairNo.Location = new System.Drawing.Point(123, 102);
            this.txtRepairNo.Margin = new System.Windows.Forms.Padding(6);
            this.txtRepairNo.Name = "txtRepairNo";
            this.txtRepairNo.Size = new System.Drawing.Size(267, 40);
            this.txtRepairNo.TabIndex = 85;
            this.txtRepairNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRepairNo_KeyDown);
            // 
            // txtImei
            // 
            this.txtImei.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImei.Location = new System.Drawing.Point(124, 148);
            this.txtImei.Margin = new System.Windows.Forms.Padding(6);
            this.txtImei.Name = "txtImei";
            this.txtImei.Size = new System.Drawing.Size(267, 40);
            this.txtImei.TabIndex = 84;
            this.txtImei.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIMEI_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 155);
            this.label1.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 83;
            this.label1.Text = "IMEI：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 112);
            this.label6.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 25);
            this.label6.TabIndex = 82;
            this.label6.Text = "修理番号：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.picResult);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(984, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 215);
            this.panel3.TabIndex = 55;
            // 
            // picResult
            // 
            this.picResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.picResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picResult.Location = new System.Drawing.Point(53, 62);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(120, 120);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picResult.TabIndex = 43;
            this.picResult.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lbResult);
            this.panel7.Location = new System.Drawing.Point(53, 25);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(120, 38);
            this.panel7.TabIndex = 42;
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.lbResult.ForeColor = System.Drawing.Color.White;
            this.lbResult.Location = new System.Drawing.Point(23, 1);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(70, 31);
            this.lbResult.TabIndex = 0;
            this.lbResult.Text = "結果";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.試験ToolStripMenuItem,
            this.設定ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 89;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 試験ToolStripMenuItem
            // 
            this.試験ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.中断ToolStripMenuItem});
            this.試験ToolStripMenuItem.Name = "試験ToolStripMenuItem";
            this.試験ToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.試験ToolStripMenuItem.Text = "試験";
            // 
            // 中断ToolStripMenuItem
            // 
            this.中断ToolStripMenuItem.Name = "中断ToolStripMenuItem";
            this.中断ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.中断ToolStripMenuItem.Text = "中断";
            this.中断ToolStripMenuItem.Click += new System.EventHandler(this.中断ToolStripMenuItem_Click);
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cAM確認位置ToolStripMenuItem,
            this.色確認位置ToolStripMenuItem});
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.設定ToolStripMenuItem.Text = "設定";
            // 
            // cAM確認位置ToolStripMenuItem
            // 
            this.cAM確認位置ToolStripMenuItem.Name = "cAM確認位置ToolStripMenuItem";
            this.cAM確認位置ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.cAM確認位置ToolStripMenuItem.Text = "CAM確認位置";
            this.cAM確認位置ToolStripMenuItem.Click += new System.EventHandler(this.cAM確認位置ToolStripMenuItem_Click);
            // 
            // 色確認位置ToolStripMenuItem
            // 
            this.色確認位置ToolStripMenuItem.Name = "色確認位置ToolStripMenuItem";
            this.色確認位置ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.色確認位置ToolStripMenuItem.Text = "色確認位置";
            this.色確認位置ToolStripMenuItem.Click += new System.EventHandler(this.色確認位置ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 239);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel8);
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 522);
            this.splitContainer1.SplitterDistance = 687;
            this.splitContainer1.TabIndex = 56;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(687, 482);
            this.panel5.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.ptbCamera);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 174);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(687, 308);
            this.panel9.TabIndex = 53;
            // 
            // ptbCamera
            // 
            this.ptbCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbCamera.Location = new System.Drawing.Point(0, 0);
            this.ptbCamera.Name = "ptbCamera";
            this.ptbCamera.Size = new System.Drawing.Size(687, 308);
            this.ptbCamera.TabIndex = 0;
            this.ptbCamera.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sfDataGrid1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 174);
            this.panel1.TabIndex = 52;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(687, 40);
            this.panel4.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dgvPhonePass);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 40);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(493, 482);
            this.panel8.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(493, 40);
            this.panel6.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(9, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 29);
            this.label2.TabIndex = 49;
            this.label2.Text = "結果履歴";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            // 
            // fMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "fMainForm";
            this.Text = "初期化２_V0.05 2022/09/09";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMainForm_FormClosing);
            this.Load += new System.EventHandler(this.fMainForm_Load);
            this.Shown += new System.EventHandler(this.fMainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhonePass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbCamera)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgvPhonePass;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbKouteiName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbKiShu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRepairNo;
        private System.Windows.Forms.TextBox txtImei;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtbStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 試験ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中断ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cAM確認位置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 色確認位置ToolStripMenuItem;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ptbCamera;
        private System.ComponentModel.BackgroundWorker bgWorker;
    }
}

