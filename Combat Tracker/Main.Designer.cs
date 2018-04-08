namespace Combat_Tracker
{
    partial class Main
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CreatePNL = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.willInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.perInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cpxInput = new System.Windows.Forms.TextBox();
            this.lblcpx = new System.Windows.Forms.Label();
            this.csInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CharName = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFullBatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCombatGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterAllInCombatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllInCombatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartRound = new System.Windows.Forms.Button();
            this.CombatOrder = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 230);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(453, 406);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // CreatePNL
            // 
            this.CreatePNL.Location = new System.Drawing.Point(127, 164);
            this.CreatePNL.Name = "CreatePNL";
            this.CreatePNL.Size = new System.Drawing.Size(99, 23);
            this.CreatePNL.TabIndex = 1;
            this.CreatePNL.Text = "Create Character";
            this.CreatePNL.UseVisualStyleBackColor = true;
            this.CreatePNL.Click += new System.EventHandler(this.CreatePNL_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.willInput);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.perInput);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cpxInput);
            this.panel1.Controls.Add(this.lblcpx);
            this.panel1.Controls.Add(this.csInput);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CharName);
            this.panel1.Controls.Add(this.CreatePNL);
            this.panel1.Location = new System.Drawing.Point(15, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 189);
            this.panel1.TabIndex = 2;
            // 
            // willInput
            // 
            this.willInput.Location = new System.Drawing.Point(125, 133);
            this.willInput.Name = "willInput";
            this.willInput.Size = new System.Drawing.Size(100, 20);
            this.willInput.TabIndex = 9;
            this.willInput.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Will Power";
            // 
            // perInput
            // 
            this.perInput.Location = new System.Drawing.Point(125, 102);
            this.perInput.Name = "perInput";
            this.perInput.Size = new System.Drawing.Size(100, 20);
            this.perInput.TabIndex = 7;
            this.perInput.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Perception";
            // 
            // cpxInput
            // 
            this.cpxInput.Location = new System.Drawing.Point(125, 70);
            this.cpxInput.Name = "cpxInput";
            this.cpxInput.Size = new System.Drawing.Size(100, 20);
            this.cpxInput.TabIndex = 5;
            this.cpxInput.Text = "0";
            // 
            // lblcpx
            // 
            this.lblcpx.AutoSize = true;
            this.lblcpx.Location = new System.Drawing.Point(31, 73);
            this.lblcpx.Name = "lblcpx";
            this.lblcpx.Size = new System.Drawing.Size(45, 13);
            this.lblcpx.TabIndex = 4;
            this.lblcpx.Text = "CS CPX";
            // 
            // csInput
            // 
            this.csInput.Location = new System.Drawing.Point(125, 40);
            this.csInput.Name = "csInput";
            this.csInput.Size = new System.Drawing.Size(100, 20);
            this.csInput.TabIndex = 3;
            this.csInput.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CS Skill";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // CharName
            // 
            this.CharName.Location = new System.Drawing.Point(125, 13);
            this.CharName.Name = "CharName";
            this.CharName.Size = new System.Drawing.Size(100, 20);
            this.CharName.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.combatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(732, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFullBatchToolStripMenuItem,
            this.saveCombatGroupToolStripMenuItem,
            this.loadBatchToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveFullBatchToolStripMenuItem
            // 
            this.saveFullBatchToolStripMenuItem.Name = "saveFullBatchToolStripMenuItem";
            this.saveFullBatchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveFullBatchToolStripMenuItem.Text = "Save Full Batch";
            // 
            // saveCombatGroupToolStripMenuItem
            // 
            this.saveCombatGroupToolStripMenuItem.Name = "saveCombatGroupToolStripMenuItem";
            this.saveCombatGroupToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveCombatGroupToolStripMenuItem.Text = "Save Combat Group";
            this.saveCombatGroupToolStripMenuItem.Click += new System.EventHandler(this.saveCombatGroupToolStripMenuItem_Click);
            // 
            // loadBatchToolStripMenuItem
            // 
            this.loadBatchToolStripMenuItem.Name = "loadBatchToolStripMenuItem";
            this.loadBatchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadBatchToolStripMenuItem.Text = "Load Batch";
            this.loadBatchToolStripMenuItem.Click += new System.EventHandler(this.loadBatchToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // combatToolStripMenuItem
            // 
            this.combatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enterAllInCombatToolStripMenuItem,
            this.removeAllInCombatToolStripMenuItem});
            this.combatToolStripMenuItem.Name = "combatToolStripMenuItem";
            this.combatToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.combatToolStripMenuItem.Text = "Combat";
            // 
            // enterAllInCombatToolStripMenuItem
            // 
            this.enterAllInCombatToolStripMenuItem.Name = "enterAllInCombatToolStripMenuItem";
            this.enterAllInCombatToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.enterAllInCombatToolStripMenuItem.Text = "Enter All In Combat";
            this.enterAllInCombatToolStripMenuItem.Click += new System.EventHandler(this.enterAllInCombatToolStripMenuItem_Click);
            // 
            // removeAllInCombatToolStripMenuItem
            // 
            this.removeAllInCombatToolStripMenuItem.Name = "removeAllInCombatToolStripMenuItem";
            this.removeAllInCombatToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.removeAllInCombatToolStripMenuItem.Text = "Remove All In Combat";
            this.removeAllInCombatToolStripMenuItem.Click += new System.EventHandler(this.removeAllInCombatToolStripMenuItem_Click);
            // 
            // StartRound
            // 
            this.StartRound.Location = new System.Drawing.Point(298, 199);
            this.StartRound.Name = "StartRound";
            this.StartRound.Size = new System.Drawing.Size(155, 23);
            this.StartRound.TabIndex = 10;
            this.StartRound.Text = "Start Combat Round";
            this.StartRound.UseVisualStyleBackColor = true;
            this.StartRound.Click += new System.EventHandler(this.StartRound_Click);
            // 
            // CombatOrder
            // 
            this.CombatOrder.AutoScroll = true;
            this.CombatOrder.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CombatOrder.Location = new System.Drawing.Point(502, 37);
            this.CombatOrder.Name = "CombatOrder";
            this.CombatOrder.Size = new System.Drawing.Size(215, 599);
            this.CombatOrder.TabIndex = 12;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 648);
            this.Controls.Add(this.CombatOrder);
            this.Controls.Add(this.StartRound);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Combat Tracker";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button CreatePNL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CharName;
        private System.Windows.Forms.TextBox willInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox perInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cpxInput;
        private System.Windows.Forms.Label lblcpx;
        private System.Windows.Forms.TextBox csInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFullBatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCombatGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadBatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterAllInCombatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllInCombatToolStripMenuItem;
        private System.Windows.Forms.Button StartRound;
        private System.Windows.Forms.FlowLayoutPanel CombatOrder;
    }
}

