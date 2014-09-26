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
            this.cb_COMPort = new System.Windows.Forms.ComboBox();
            this.btn_ReloadPorts = new System.Windows.Forms.Button();
            this.btn_StartStop = new System.Windows.Forms.Button();
            this.lb_AxisValues = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cb_COMPort
            // 
            this.cb_COMPort.FormattingEnabled = true;
            this.cb_COMPort.Location = new System.Drawing.Point(12, 12);
            this.cb_COMPort.Name = "cb_COMPort";
            this.cb_COMPort.Size = new System.Drawing.Size(159, 21);
            this.cb_COMPort.TabIndex = 0;
            // 
            // btn_ReloadPorts
            // 
            this.btn_ReloadPorts.Location = new System.Drawing.Point(177, 10);
            this.btn_ReloadPorts.Name = "btn_ReloadPorts";
            this.btn_ReloadPorts.Size = new System.Drawing.Size(95, 23);
            this.btn_ReloadPorts.TabIndex = 1;
            this.btn_ReloadPorts.Text = "Reload Ports";
            this.btn_ReloadPorts.UseVisualStyleBackColor = true;
            this.btn_ReloadPorts.Click += new System.EventHandler(this.btn_ReloadPorts_Click);
            // 
            // btn_StartStop
            // 
            this.btn_StartStop.Location = new System.Drawing.Point(12, 39);
            this.btn_StartStop.Name = "btn_StartStop";
            this.btn_StartStop.Size = new System.Drawing.Size(260, 23);
            this.btn_StartStop.TabIndex = 2;
            this.btn_StartStop.Text = "Start On Selected Port";
            this.btn_StartStop.UseVisualStyleBackColor = true;
            this.btn_StartStop.Click += new System.EventHandler(this.btn_StartStop_Click);
            // 
            // lb_AxisValues
            // 
            this.lb_AxisValues.FormattingEnabled = true;
            this.lb_AxisValues.Location = new System.Drawing.Point(12, 68);
            this.lb_AxisValues.Name = "lb_AxisValues";
            this.lb_AxisValues.Size = new System.Drawing.Size(260, 186);
            this.lb_AxisValues.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lb_AxisValues);
            this.Controls.Add(this.btn_StartStop);
            this.Controls.Add(this.btn_ReloadPorts);
            this.Controls.Add(this.cb_COMPort);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_COMPort;
        private System.Windows.Forms.Button btn_ReloadPorts;
        private System.Windows.Forms.Button btn_StartStop;
        private System.Windows.Forms.ListBox lb_AxisValues;
    }
}

