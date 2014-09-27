namespace VirtualSerialJoystick
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
            this.components = new System.ComponentModel.Container();
            this.cb_COMPort = new System.Windows.Forms.ComboBox();
            this.btn_ReloadPorts = new System.Windows.Forms.Button();
            this.btn_StartStop = new System.Windows.Forms.Button();
            this.tv_Axes = new System.Windows.Forms.TreeView();
            this.cms_TreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddNewBinding = new System.Windows.Forms.ToolStripMenuItem();
            this.tt_TreeView = new System.Windows.Forms.ToolTip(this.components);
            this.btn_SaveConfig = new System.Windows.Forms.Button();
            this.btn_loadConfig = new System.Windows.Forms.Button();
            this.cms_TreeView.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_COMPort
            // 
            this.cb_COMPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_COMPort.FormattingEnabled = true;
            this.cb_COMPort.Location = new System.Drawing.Point(12, 12);
            this.cb_COMPort.Name = "cb_COMPort";
            this.cb_COMPort.Size = new System.Drawing.Size(189, 21);
            this.cb_COMPort.TabIndex = 0;
            // 
            // btn_ReloadPorts
            // 
            this.btn_ReloadPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ReloadPorts.Location = new System.Drawing.Point(207, 10);
            this.btn_ReloadPorts.Name = "btn_ReloadPorts";
            this.btn_ReloadPorts.Size = new System.Drawing.Size(95, 23);
            this.btn_ReloadPorts.TabIndex = 1;
            this.btn_ReloadPorts.Text = "Reload Ports";
            this.btn_ReloadPorts.UseVisualStyleBackColor = true;
            this.btn_ReloadPorts.Click += new System.EventHandler(this.btn_ReloadPorts_Click);
            // 
            // btn_StartStop
            // 
            this.btn_StartStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_StartStop.Location = new System.Drawing.Point(12, 39);
            this.btn_StartStop.Name = "btn_StartStop";
            this.btn_StartStop.Size = new System.Drawing.Size(290, 23);
            this.btn_StartStop.TabIndex = 2;
            this.btn_StartStop.Text = "Start On Selected Port";
            this.btn_StartStop.UseVisualStyleBackColor = true;
            this.btn_StartStop.Click += new System.EventHandler(this.btn_StartStop_Click);
            // 
            // tv_Axes
            // 
            this.tv_Axes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_Axes.ContextMenuStrip = this.cms_TreeView;
            this.tv_Axes.Location = new System.Drawing.Point(12, 68);
            this.tv_Axes.Name = "tv_Axes";
            this.tv_Axes.ShowNodeToolTips = true;
            this.tv_Axes.Size = new System.Drawing.Size(290, 291);
            this.tv_Axes.TabIndex = 3;
            this.tt_TreeView.SetToolTip(this.tv_Axes, "This is the current binding configuration.\r\nRight-click on a binding to edit para" +
        "meters.\r\nRight-click on the background to add a new binding.");
            this.tv_Axes.VisibleChanged += new System.EventHandler(this.tv_Axes_VisibleChanged);
            // 
            // cms_TreeView
            // 
            this.cms_TreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNewBinding});
            this.cms_TreeView.Name = "cms_TreeView";
            this.cms_TreeView.Size = new System.Drawing.Size(168, 26);
            // 
            // btnAddNewBinding
            // 
            this.btnAddNewBinding.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddNewBinding.Name = "btnAddNewBinding";
            this.btnAddNewBinding.Size = new System.Drawing.Size(167, 22);
            this.btnAddNewBinding.Text = "Add New Binding";
            this.btnAddNewBinding.Click += new System.EventHandler(this.btnAddNewBinding_Click);
            // 
            // btn_SaveConfig
            // 
            this.btn_SaveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SaveConfig.Location = new System.Drawing.Point(207, 365);
            this.btn_SaveConfig.Name = "btn_SaveConfig";
            this.btn_SaveConfig.Size = new System.Drawing.Size(95, 23);
            this.btn_SaveConfig.TabIndex = 4;
            this.btn_SaveConfig.Text = "Save Bindings";
            this.btn_SaveConfig.UseVisualStyleBackColor = true;
            this.btn_SaveConfig.Click += new System.EventHandler(this.btn_SaveConfig_Click);
            // 
            // btn_loadConfig
            // 
            this.btn_loadConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_loadConfig.Location = new System.Drawing.Point(101, 365);
            this.btn_loadConfig.Name = "btn_loadConfig";
            this.btn_loadConfig.Size = new System.Drawing.Size(100, 23);
            this.btn_loadConfig.TabIndex = 5;
            this.btn_loadConfig.Text = "Load Bindings";
            this.btn_loadConfig.UseVisualStyleBackColor = true;
            this.btn_loadConfig.Click += new System.EventHandler(this.btn_loadConfig_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 400);
            this.Controls.Add(this.btn_loadConfig);
            this.Controls.Add(this.btn_SaveConfig);
            this.Controls.Add(this.tv_Axes);
            this.Controls.Add(this.btn_StartStop);
            this.Controls.Add(this.btn_ReloadPorts);
            this.Controls.Add(this.cb_COMPort);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.cms_TreeView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_COMPort;
        private System.Windows.Forms.Button btn_ReloadPorts;
        private System.Windows.Forms.Button btn_StartStop;
        private System.Windows.Forms.TreeView tv_Axes;
        private System.Windows.Forms.ContextMenuStrip cms_TreeView;
        private System.Windows.Forms.ToolStripMenuItem btnAddNewBinding;
        private System.Windows.Forms.ToolTip tt_TreeView;
        private System.Windows.Forms.Button btn_SaveConfig;
        private System.Windows.Forms.Button btn_loadConfig;
    }
}

