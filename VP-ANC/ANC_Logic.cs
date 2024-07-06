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
		private static double Factorial(double number)
		{
			// the argument is rounded to avoid calculating factorial on a real number instead of a whole
			if (number <= 2) {
				return number;
			}
			double result = 1;
			for (double i = number; i >= 2; i--)
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
					result = Factorial(Math.Round(X));
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
					double numerator = Factorial(Math.Round(X)),
						denominator = Factorial(Math.Round(X-Y));
					result = numerator / denominator;
					break;
				case "nCr":
					double numerator_nCr = Factorial(Math.Round(X)),
						denominator_nCr = Factorial(Math.Round(Y)) * Factorial(Math.Round(X - Y));
					result = numerator_nCr / denominator_nCr; 
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
		public static string ConvertNumberFormat(string Number, string ConvertingFrom, string ConvertingTo)
		{
			if (ConvertingFrom == ConvertingTo)
				return Number;

			long InitialNumber;
			switch (ConvertingFrom)
			{
				case "Bin":
					InitialNumber = Convert.ToInt64(Number, 2);
					break;
				case "Hex":
					InitialNumber = Convert.ToInt64(Number, 16);
					break;
				case "Oct":
					InitialNumber = Convert.ToInt64(Number, 8);
					break;
				default: // Decimal
					InitialNumber = Convert.ToInt64(Number, 10);
					break;
			}
			
			string Result;
			switch (ConvertingTo)
			{
				case "Hex":
					Result = InitialNumber.ToString("X");
					break;
				case "Bin":
					Result = Convert.ToString(InitialNumber, 2);
					break;
				case "Oct":
					Result = Convert.ToString(InitialNumber, 8);
					break;
				default: // Decimal
					Result = InitialNumber.ToString();
					break;
			}
			return Result;
		}
		// The code below could be better :p
		public static double ConvertTemperature(double Temperature, string ConvertingFrom, string ConvertingTo)
		{
			if (ConvertingFrom == ConvertingTo) return Temperature;

			double Result = 0;
			Tuple<string, string> pair = new Tuple<string, string>(ConvertingFrom, ConvertingTo);

			switch (pair)
			{
				case var caseCF when caseCF.Item1 == "C" && caseCF.Item2 == "F":
					Result = (Temperature * 9 / 5) + 32;
					break;
				case var caseFC when caseFC.Item1 == "F" && caseFC.Item2 == "C":
					Result = (Temperature - 32) * 5 / 9;
					break;
				case var caseCK when caseCK.Item1 == "C" && caseCK.Item2 == "K":
					Result = Temperature + 273.15;
					break;
				case var caseKC when caseKC.Item1 == "K" && caseKC.Item2 == "C":
					Result = Temperature - 273.15;
					break;
				case var caseFK when caseFK.Item1 == "F" && caseFK.Item2 == "K":
					Result = (Temperature - 32) * 5 / 9 + 273.15;
					break;
				case var caseKF when caseKF.Item1 == "K" && caseKF.Item2 == "F":
					Result = (Temperature - 273.15) * 9 / 5 + 32;
					break;
			}
			return Result;
		}
		public static double ConvertMass(double Mass, string ConvertingFrom, string ConvertingTo)
		{
			if (ConvertingFrom == ConvertingTo) return Mass;

			double Result = 0;
			Tuple<string, string> pair = new Tuple<string, string>(ConvertingFrom, ConvertingTo);

			switch (pair)
			{
				case var caseKP when caseKP.Item1 == "kg" && caseKP.Item2 == "lbs":
					Result = Mass * 2.205;
					break;
				case var casePK when casePK.Item1 == "lbs" && casePK.Item2 == "kg":
					Result = Mass / 2.205;
					break;
				case var caseKS when caseKS.Item1 == "kg" && caseKS.Item2 == "stone":
					Result = Mass / 6.35;
					break;
				case var caseSK when caseSK.Item1 == "stone" && caseSK.Item2 == "kg":
					Result = Mass * 6.35;
					break;
				case var casePS when casePS.Item1 == "lbs" && casePS.Item2 == "stone":
					Result = Mass / 14;
					break;
				case var caseSP when caseSP.Item1 == "stone" && caseSP.Item2 == "lbs":
					Result = Mass * 14;
					break;
			}
			return Result;
		}
		public static double ConvertLength(double Length, string ConvertingFrom, string ConvertingTo)
		{
			if (ConvertingFrom == ConvertingTo) return Length;

			double Result = 0;
			Tuple<string, string> pair = new Tuple<string, string>(ConvertingFrom, ConvertingTo);

			switch (pair)
			{
				case var caseKmCm when caseKmCm.Item1 == "km" && caseKmCm.Item2 == "cm":
					Result = Length * 100000;
					break;
				case var caseCmKm when caseCmKm.Item1 == "cm" && caseCmKm.Item2 == "km":
					Result = Length / 100000;
					break;
				case var caseKmMi when caseKmMi.Item1 == "km" && caseKmMi.Item2 == "mi":
					Result = Length / 1.60934;
					break;
				case var caseMiKm when caseMiKm.Item1 == "mi" && caseMiKm.Item2 == "km":
					Result = Length * 1.60934;
					break;
				case var caseKmFt when caseKmFt.Item1 == "km" && caseKmFt.Item2 == "ft":
					Result = Length * 3280.84;
					break;
				case var caseFtKm when caseFtKm.Item1 == "ft" && caseFtKm.Item2 == "km":
					Result = Length / 3280.84;
					break;
				case var caseCmMi when caseCmMi.Item1 == "cm" && caseCmMi.Item2 == "mi":
					Result = Length / 160934;
					break;
				case var caseMiCm when caseMiCm.Item1 == "mi" && caseMiCm.Item2 == "cm":
					Result = Length * 160934;
					break;
				case var caseCmFt when caseCmFt.Item1 == "cm" && caseCmFt.Item2 == "ft":
					Result = Length / 30.48;
					break;
				case var caseFtCm when caseFtCm.Item1 == "ft" && caseFtCm.Item2 == "cm":
					Result = Length * 30.48;
					break;
				case var caseMiFt when caseMiFt.Item1 == "mi" && caseMiFt.Item2 == "ft":
					Result = Length * 5280;
					break;
				case var caseFtMi when caseFtMi.Item1 == "ft" && caseFtMi.Item2 == "mi":
					Result = Length / 5280;
					break;
			}
			return Result;
		}
	}
}
