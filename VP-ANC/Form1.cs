using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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
		string operation, binaryOperation;
		bool isSecondOperand;
		string OperationText;

		public ancMainWindow()
		{
			InitializeComponent();
			themes = new Dictionary<string, ToolStripMenuItem>();
			foreach (ToolStripMenuItem item in themeToolStripMenuItem.DropDownItems)
			{
				themes[item.Text] = item;
			}
			startupEvent = new EventHandler(ancMainWindow_Activated);
			extraOperationsMenu1.BringToFront();
			isSecondOperand = false;
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
			if (operation == null || !isSecondOperand)
			{
				MessageBox.Show("Equals button is for binary operations only", "ANC - Warning");
				return;
			}
			Y = Convert.ToDouble(numberBox.Text);
			currentOperationText.Text = OperationText + $"{Y} = ";
			numberBox.Text = Calculator.Calculate(X, binaryOperation ?? operation, Y).ToString();
		}

		private void NumberButtonClicked(object sender, EventArgs e)
		{
			// Make sure this method is used by buttons
			if (sender is Button)
			{
				Button button = sender as Button;
				if (numberBox.Text.Length >= 14)
					return;
				numberBox.Text = (numberBox.Text == "0") ? button.Text : numberBox.Text + button.Text;
			}
		}

		private void SpecialNumberButtonClicked(object sender, EventArgs e)
		{
			if (sender is Button)
			{
				Button button = sender as Button;
				switch (button.Text)
				{
					case "e":
						numberBox.Text = Math.E.ToString("N08"); 
						break;
					case "𝝿":
						numberBox.Text = Math.PI.ToString("N08");
						break;
				}
			}
		}

		private void BinaryOperatorButtonClicked(object sender, EventArgs e)
		{
			if (isSecondOperand)
			{
				MessageBox.Show("Only one binary operation is allowed.", "ANC - Warning");
				return;
			}
			if (sender is Button)
			{
				Button button = sender as Button;
				X = Convert.ToDouble(numberBox.Text);
				switch (button.Text)
				{
					case "x^y":
						OperationText = $"{X}^";
						operation = "^";
						break;
					case "nrt(x)":
						OperationText = $"{X}-root of ";
						operation = "root";
						break;
					case "nCr":
						OperationText = $"Class {X} combination of ";
						operation = button.Text;
						break;
					case "nPr":
						OperationText = $"Class {X} permutation of ";
						operation = button.Text;
						break;
					case "log":
						OperationText = $"log({X}), base ";
						operation = button.Text;
						break;
					default:
						OperationText = $"{X} {button.Text} ";
						operation = button.Text;
						break;
				}
				currentOperationText.Text = OperationText;
				currentOperationText.Visible = true;
				numberBox.Text = "0";
				isSecondOperand = true;
			}
		}

		private void UnaryOperatorButtonClicked(object sender, EventArgs e)
		{
			// Unary operations calculate result immediately
			if (sender is Button)
			{
				Button button = sender as Button;
				if (!isSecondOperand)
				{
					X = double.Parse(numberBox.Text);
					operation = button.Text;
					OperationText = (operation == "!") ? $"{X}! =" : $"{operation}({X})";
					currentOperationText.Text = OperationText;
					currentOperationText.Visible = true;
					numberBox.Text = Calculator.Calculate(X, operation).ToString();
				} 
				else
				{
					Y = double.Parse(numberBox.Text);
					binaryOperation = operation;
					operation = button.Text;
					numberBox.Text = Calculator.Calculate(Y, operation).ToString();
				}
				
			}
		}

		private void buttonDecimal_Click(object sender, EventArgs e)
		{
			string DecimalSeparator = CultureInfo
				.CurrentCulture
				.NumberFormat
				.NumberDecimalSeparator;
			if (numberBox.Text.Contains(DecimalSeparator))
				return;
			numberBox.Text += DecimalSeparator;
		}

		private void clearEntryButton_Click(object sender, EventArgs e)
		{
			numberBox.Text = "0";
		}

		private void clearButton_Click(object sender, EventArgs e)
		{
			X = Y = double.NaN;
			operation = null;
			binaryOperation = null;
			numberBox.Text = "0";
			currentOperationText.Visible = false;
			isSecondOperand = false;
		}

		private void extraOperationsButton_Click(object sender, EventArgs e)
		{
			if (extraOperationsMenu1.Visible)
			{
				extraOperationsMenu1.Hide();
				extraOperationsButton.Text = "2nd";
			}
			else
			{
				extraOperationsMenu1.Show();
				extraOperationsButton.Text = "1st";
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AboutBox1().ShowDialog();
		}

		private void btnBackspace_Click(object sender, EventArgs e)
		{
			if (numberBox.Text.Length <= 1) numberBox.Text = "0";
			else numberBox.Text = numberBox.Text.Substring(0, numberBox.Text.Length - 1);
		}

		private void btnSignFlip_Click(object sender, EventArgs e)
		{
			numberBox.Text = (Convert.ToDouble(numberBox.Text) * -1).ToString();
		}

		// This event activates on start-up to apply default (light) theme and events,
		// then is removed to prevent it from activating after each interaction with the form or its controls
		private void ancMainWindow_Activated(object sender, EventArgs e)
		{
			theme = new AppTheme(lightToolStripMenuItem);
			extraOperationsMenu1.unaryOperations += UnaryOperatorButtonClicked;
			extraOperationsMenu1.binaryOperations += BinaryOperatorButtonClicked;
			Activated -= startupEvent;
		}

		private void ConversionMenu_Activate(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem)
			{
				string type = (sender as ToolStripMenuItem).Text;
				new ConversionMenu(type).Show();
			}
		}
	}
}
