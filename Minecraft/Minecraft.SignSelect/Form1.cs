using Minecraft.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft.SignSelect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            lblInfo.Text = "";
            tbxMainCmd.Text = "";
            tbxSecondCmd.Text = "";
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Init();

            var signStr = tbxSignStr.Text.Trim();
            if (string.IsNullOrWhiteSpace(signStr))
            {
                lblInfo.Text = "sign不能为空";
                tbxSignStr.Focus();
                tbxSignStr.SelectAll();
                return;
            }
            var isMatch = Regex.IsMatch(signStr, @"^\d{" + (ProtocolLen.Main + ProtocolLen.Second) + @"}$");
            if (!isMatch)
            {
                lblInfo.Text = "sign不合法";
                tbxSignStr.Focus();
                tbxSignStr.SelectAll();
                return;
            }
            var mainStr = signStr.Substring(0, ProtocolLen.Main);
            var secondStr = signStr.Substring(ProtocolLen.Main);

            int mainInt = Convert.ToInt32(mainStr);
            int secondInt = Convert.ToInt32(secondStr);

            MainCommand mainCommand = (MainCommand)mainInt;
            SecondCommand secondCommand = (SecondCommand)secondInt;

            tbxMainCmd.Text = mainCommand.ToString();
            tbxSecondCmd.Text = secondCommand.ToString();

        }

        private void tbxMainCmd_MouseEnter(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(tbxMainCmd.Text))
            {
                tbxMainCmd.Focus();
                tbxMainCmd.SelectAll();
            }
        }

        private void tbxSecondCmd_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbxSecondCmd.Text))
            {
                tbxSecondCmd.Focus();
                tbxSecondCmd.SelectAll();
            }
        }
    }
}
