namespace Minecraft.SignSelect
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSignStr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.tbxMainCmd = new System.Windows.Forms.TextBox();
            this.tbxSecondCmd = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sign：";
            // 
            // tbxSignStr
            // 
            this.tbxSignStr.Location = new System.Drawing.Point(78, 22);
            this.tbxSignStr.Name = "tbxSignStr";
            this.tbxSignStr.Size = new System.Drawing.Size(142, 21);
            this.tbxSignStr.TabIndex = 1;
            this.tbxSignStr.Text = "00101001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "MainCommand：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "SecondCommand：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "查询结果：";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(226, 20);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // tbxMainCmd
            // 
            this.tbxMainCmd.Location = new System.Drawing.Point(131, 154);
            this.tbxMainCmd.Name = "tbxMainCmd";
            this.tbxMainCmd.Size = new System.Drawing.Size(248, 21);
            this.tbxMainCmd.TabIndex = 6;
            this.tbxMainCmd.MouseEnter += new System.EventHandler(this.tbxMainCmd_MouseEnter);
            // 
            // tbxSecondCmd
            // 
            this.tbxSecondCmd.Location = new System.Drawing.Point(131, 184);
            this.tbxSecondCmd.Name = "tbxSecondCmd";
            this.tbxSecondCmd.Size = new System.Drawing.Size(247, 21);
            this.tbxSecondCmd.TabIndex = 7;
            this.tbxSecondCmd.MouseEnter += new System.EventHandler(this.tbxSecondCmd_MouseEnter);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblInfo.Location = new System.Drawing.Point(33, 61);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(53, 12);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = "提示信息";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(418, 242);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.tbxSecondCmd);
            this.Controls.Add(this.tbxMainCmd);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxSignStr);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Sign查询工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSignStr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox tbxMainCmd;
        private System.Windows.Forms.TextBox tbxSecondCmd;
        private System.Windows.Forms.Label lblInfo;
    }
}

