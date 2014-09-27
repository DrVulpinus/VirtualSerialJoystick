namespace VirtualSerialJoystick
{
    partial class AddNewBindingDialog
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
            this.cb_BindType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nud_InputIndex = new System.Windows.Forms.NumericUpDown();
            this.pnl_SpecialConfigs = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_BindingName = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_InputIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_BindType
            // 
            this.cb_BindType.FormattingEnabled = true;
            this.cb_BindType.Items.AddRange(new object[] {
            "Axis",
            "Button"});
            this.cb_BindType.Location = new System.Drawing.Point(8, 64);
            this.cb_BindType.Name = "cb_BindType";
            this.cb_BindType.Size = new System.Drawing.Size(195, 21);
            this.cb_BindType.TabIndex = 0;
            this.cb_BindType.SelectedIndexChanged += new System.EventHandler(this.cb_BindType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Type of Binding:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Set the Input Index:";
            // 
            // nud_InputIndex
            // 
            this.nud_InputIndex.Location = new System.Drawing.Point(8, 104);
            this.nud_InputIndex.Maximum = new decimal(new int[] {
            145,
            0,
            0,
            0});
            this.nud_InputIndex.Name = "nud_InputIndex";
            this.nud_InputIndex.Size = new System.Drawing.Size(195, 20);
            this.nud_InputIndex.TabIndex = 3;
            // 
            // pnl_SpecialConfigs
            // 
            this.pnl_SpecialConfigs.Location = new System.Drawing.Point(8, 130);
            this.pnl_SpecialConfigs.Name = "pnl_SpecialConfigs";
            this.pnl_SpecialConfigs.Size = new System.Drawing.Size(195, 136);
            this.pnl_SpecialConfigs.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Binding Name:";
            // 
            // tb_BindingName
            // 
            this.tb_BindingName.Location = new System.Drawing.Point(8, 25);
            this.tb_BindingName.Name = "tb_BindingName";
            this.tb_BindingName.Size = new System.Drawing.Size(195, 20);
            this.tb_BindingName.TabIndex = 6;
            this.tb_BindingName.TextChanged += new System.EventHandler(this.tb_BindingName_TextChanged);
            // 
            // btn_Add
            // 
            this.btn_Add.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Add.Enabled = false;
            this.btn_Add.Location = new System.Drawing.Point(47, 272);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 7;
            this.btn_Add.Text = "Add Binding";
            this.btn_Add.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(128, 272);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // AddNewBindingDialog
            // 
            this.AcceptButton = this.btn_Add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(215, 307);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.tb_BindingName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnl_SpecialConfigs);
            this.Controls.Add(this.nud_InputIndex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_BindType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddNewBindingDialog";
            this.Text = "AddNewBindingDialog";
            this.Load += new System.EventHandler(this.AddNewBindingDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_InputIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_BindType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud_InputIndex;
        private System.Windows.Forms.Panel pnl_SpecialConfigs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_BindingName;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Cancel;
    }
}