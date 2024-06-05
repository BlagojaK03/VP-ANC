using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_ANC
{
	public partial class ancMainWindow : Form
	{
		AppTheme theme;
		Dictionary<string, ToolStripMenuItem> themes;
		EventHandler startupEvent;
		double X, Y;
		string operation;
		bool secondOperator;

		public ancMainWindow()
		{
			InitializeComponent();
			themes = new Dictionary<string, ToolStripMenuItem>();
			foreach (ToolStripMenuItem item in themeToolStripMenuItem.DropDownItems)
			{
				themes[item.Text] = item;
			}
			startupEvent = new EventHandler(ancMainWindow_Activated);
			Activated += startupEvent;
			secondOperator = false;
		}

		private void stayOnTopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!stayOnTopToolStripMenuItem.Checked)
			{
				stayOnTopToolStripMenuItem.Checked = true;
			}
			else
			{
				stayOnTopToolStripMenuItem.Checked = false;
			}

			TopMost = stayOnTopToolStripMenuItem.Checked;
		}

		private void githubToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://github.com/BlagojaK03/VP-ANC");
		}

		private void themeToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			string selectedItem = e.ClickedItem.Text;
			theme.ChangeTheme(themes[selectedItem]);
		}

		private void btnEquals_Click(object sender, EventArgs e)
		{
			if (operation == "!")
			{
				numberBox.Text = Calculator.Factorial((ulong)X).ToString();
			}
			else
			{
				numberBox.Text = Calculator.Calculate(X, operation, Y).ToString();
			}
		}


		//TODO: Which args to use???
		private void numberButtonClicked(object sender, MouseEventArgs e)
		{
			// numberBox.Text = (numberBox.Text == "0")? button.Text : numberBox.Text + button.Text;
		}

		private void btnFactorial_Click(object sender, EventArgs e)
		{
			X = double.Parse(numberBox.Text);
			operation = "!";
			numberBox.Text += operation;
		}

		private void ancMainWindow_Activated(object sender, EventArgs e)
		{
			theme = new AppTheme(lightToolStripMenuItem);
			Activated -= startupEvent;
		}
	}
}
