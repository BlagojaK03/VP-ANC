using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_ANC
{
	// This class handles the mathematics

	internal static class Calculator
	{
		private static ulong Factorial(ulong number)
		{
			if (number <= 2) {
				return number;
			}
			ulong result = 1;
			for (ulong i = number; i >= 2; i--)
			{
				result *= i;
			}

			return result;
		}

		public static double Calculate(double X, string operation, double Y = 0)
		{
			double result = 0;
			switch (operation)
			{
				case "+":
					result = X + Y;
					break;
				case "-":
					result = X - Y;
					break;
				case "x":
					result = X * Y;
					break;
				case "/":
					result = X / Y;
					break;
				case "mod":
					result = X % Y;
					break;
				case "^":
					result = Math.Pow(X, Y);
					break;
				case "root":
					result = Math.Pow(Y, 1 / X);
					break;
				case "sin":
					result = Math.Sin(X);
					break;
				case "cos":
					result = Math.Cos(X);
					break;
				case "tan":
					result = Math.Tan(X);
					break;
				case "cot":
					result = (Math.Cos(X) / Math.Sin(X));
					break;
				case "!":
					result = Factorial((ulong)X);
					break;
				case "arcsin":
					result = Math.Asin(X);
					break;
				case "arccos":
					result = Math.Acos(X);
					break;
				case "arctan":
					result = Math.Atan(X);
					break;
				case "arccot":
					result = Math.Atan(1 / X);
					break;
				case "sec":
					result = 1 / Math.Cos(X);
					break;
				case "csc":
					result = 1 / Math.Sin(X);
					break;
				case "arcsec":
					result = Math.Acos(1 / X);
					break;
				case "arccsc":
					result = Math.Asin(1 / X);
					break;
				case "log":
					result = Math.Log(X, Y);
					break;
				case "ln":
					result = Math.Log(X);
					break;
				case "nPr":
					result = Factorial((ulong)X) / Factorial((ulong)(X-Y));
					break;
				case "nCr":
					result = Factorial((ulong)X) / (Factorial((ulong)Y) * Factorial((ulong)(X - Y)));
					break;
				default:
					MessageBox.Show("Operation not implemented!", "ANC - Error");
					break;
			}

			return result;
		}
	}

	// Class for the app's appearance
	internal class AppTheme
	{
		ToolStripMenuItem Current;
		public AppTheme(ToolStripMenuItem tsmi)
		{
			Current = tsmi;
			ChangeTheme(tsmi);
		}

		private void ApplyChanges(
			Color Background,
			Color ButtonBackground,
			Color ButtonBorder,
			Color ButtonText,
			Color NumBoxBackground,
			Color NumBoxText,
			Color MenuStripText
		)
		{
			Form.ActiveForm.BackColor = Background;
			foreach (var item in Form.ActiveForm.Controls)
			{
				// Change appearance of buttons
				if (item is Button)
				{
					Button button = item as Button;
					button.BackColor = ButtonBackground;
					button.ForeColor = ButtonText;
					button.FlatAppearance.BorderColor = ButtonBorder;
					button.FlatAppearance.BorderSize = 2;
					button.FlatStyle = FlatStyle.Flat;
				}
				// Change appearance of numberBox
				else if (item is TextBox)
				{
					TextBox textbox = item as TextBox;
					textbox.BackColor = NumBoxBackground;
					textbox.ForeColor = NumBoxText;
				}
				// Change text color in menuStrip
				else if (item is MenuStrip)
				{
					MenuStrip menu = item as MenuStrip;
					menu.ForeColor = MenuStripText;
				}
				// Change appreance of extraOperationsMenu
				else if (item is extraOperationsMenu)
				{
					extraOperationsMenu extra = item as extraOperationsMenu;
					extra.BackColor = Background;
                    foreach (Button button in extra.Controls)
                    {
						button.BackColor = ButtonBackground;
						button.ForeColor = ButtonText;
						button.FlatAppearance.BorderColor = ButtonBorder;
						button.FlatAppearance.BorderSize = 2;
						button.FlatStyle = FlatStyle.Flat;
					}
                }
				// Change text color for labels
				else if (item is Label)
				{
					Label label = item as Label;
					label.ForeColor = MenuStripText;
				}
			}

		}

		public void ChangeTheme(ToolStripMenuItem tsmi)
		{
			if (Current == tsmi && Current.Checked)
			{
				return;
			}

			Current.Checked = false;
			Current = tsmi;
			Current.Checked = true;

			// Create a theme using the following variables
			Color BG, 
				buttonBG, 
				buttonBorder,
				buttonText, 
				numBoxBG,
				numboxText, 
				menuStripText;
			switch (Current.Text)
			{
				case "Light":
					BG = Color.LightGray;
					numBoxBG = Color.GhostWhite;
					buttonBorder = Color.Silver;
					buttonBG = Color.WhiteSmoke;
					buttonText = numboxText = menuStripText = Color.Black;
					break;
				case "Dark":
					BG = Color.Black;
					numBoxBG = Color.Black;
					buttonBorder = Color.Silver;
					buttonBG = Color.DimGray;
					buttonText = numboxText = menuStripText = Color.White;
					break;
				case "Matrix":
					BG = Color.Black;
					numBoxBG = Color.Black;
					buttonBorder = Color.Green;
					buttonBG = Color.Black;
					buttonText = Color.Lime;
					numboxText = Color.Lime;
					menuStripText = Color.LawnGreen;
					break;
				case "Blackout":
					BG = Color.Black;
					numBoxBG = Color.Black;
					numboxText = Color.DimGray;
					buttonBorder = Color.DimGray;
					buttonBG = Color.Black;
					buttonText = Color.DimGray;
					menuStripText = Color.DimGray;
					break;
				case "EnEeEs":
					BG = Color.DimGray;
					numBoxBG = Color.LightGray;
					numboxText = Color.Red;
					buttonBG = Color.LightGray;
					buttonBorder = Color.Black;
					buttonText = Color.Red;
					menuStripText = Color.DarkRed;
					break;
				default:
					goto case "Light";
			}

			ApplyChanges(BG, buttonBG, buttonBorder, buttonText, numBoxBG, numboxText, menuStripText);
		}
	}
	// Class for the conversion tool
	internal static class Converter
	{
		public static string ConvertNumberFormat(string Converting, double Number, string Converted)
		{
			Tuple<string, string> ConversionPair = new Tuple<string, string>(Converting, Converted);
			switch (ConversionPair)
			{
				

			}
			return null;
		}
	}
}
