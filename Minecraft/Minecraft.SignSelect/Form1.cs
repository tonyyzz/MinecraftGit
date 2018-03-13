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
			tbxCmd.Text = "";
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			Init();

			var signStr = tbxSignStr.Text.Trim();
			if (signStr.IsNullOrWhiteSpace())
			{
				lblInfo.Text = "sign不能为空";
				tbxSignStr.Focus();
				tbxSignStr.SelectAll();
				return;
			}
			var isMatch = Regex.IsMatch(signStr, @"^\d{" + (ProtocolLen.Length) + @"}$");
			if (!isMatch)
			{
				lblInfo.Text = "sign不合法";
				tbxSignStr.Focus();
				tbxSignStr.SelectAll();
				return;
			}
			var command = ProtocolHelper.GetCommand(signStr);


			tbxCmd.Text = command.ToString();

		}

		private void tbxSecondCmd_MouseEnter(object sender, EventArgs e)
		{
			if (!tbxCmd.Text.IsNullOrWhiteSpace())
			{
				tbxCmd.Focus();
				tbxCmd.SelectAll();
			}
		}
	}
}
