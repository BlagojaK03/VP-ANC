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
				try
				{ numberBox.Text = Calculator.Calculate(X, operation, Y).ToString(); }

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "ANC - Error!");
					return;
				}
			}
		}

		private void NumberButtonClicked(object sender, EventArgs e)
		{
			// Make sure that this method is used by buttons
			if (sender is Button)
			{
				Button button = sender as Button;
				numberBox.Text = (numberBox.Text == "0") ? button.Text : numberBox.Text + button.Text;
			}
		}

		private void BinaryOperatorButtonClicked(object sender, EventArgs e)
		{
			if (sender is Button)
			{
				Button button = sender as Button;
				string binaryOperator;
				switch (button.Text)
				{
					case "x^n":
						binaryOperator = " ^ ";
						break;
					case "nrt(x)":
						binaryOperator = "-root of "; 
						break;
					default:
						binaryOperator = $" {button.Text} ";
						break;
				}
				numberBox.Text += binaryOperator;
			}
		}

		private void UnaryOperatorButtonClicked(object sender, EventArgs e)
		{
			if (sender is Button)
			{
				Button button = sender as Button;
				switch (button.Text)
				{
					case "!":
						numberBox.Text += "!";
						break;
					default:
						numberBox.Text = $"{button.Text}({numberBox.Text})";
						break;
				}
			}
		}

		private void buttonDecimal_Click(object sender, EventArgs e)
		{
			if (numberBox.Text.Contains("."))
				return;
			numberBox.Text += ".";
		}

		private void ancMainWindow_Activated(object sender, EventArgs e)
		{
			theme = new AppTheme(lightToolStripMenuItem);
			Activated -= startupEvent;
		}
	}
}
