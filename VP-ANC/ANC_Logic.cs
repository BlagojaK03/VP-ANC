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

	internal static class Calculate
	{
		public static void Addition()
		{
			
		}

		//TODO: Add logic to methods
		public static void Subtraction()
		{
			
		}
		public static void Multiplication()
		{

		}
		public static void Divide()
		{

		}
		public static void Modulo()
		{

		}
		public static void Factorial()
		{
			
		}
		public static void Power()
		{

		}
		public static void Root()
		{

		}
	}

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
			Color ToolStripText
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
				else if (item is RichTextBox)
				{
					RichTextBox textbox = item as RichTextBox;
					textbox.BackColor = NumBoxBackground;
					textbox.ForeColor = NumBoxText;
				}
				// Change text color in menuStrip
				else if (item is MenuStrip)
				{
					MenuStrip menu = item as MenuStrip;
					menu.ForeColor = ToolStripText;
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

			Color BG, 
				buttonBG, 
				buttonBorder,
				buttonText, 
				numBoxBG,
				numboxText, 
				toolStripText;
			switch (Current.Text)
			{
				case "Light":
					BG = Color.LightGray;
					numBoxBG = Color.GhostWhite;
					buttonBorder = Color.Silver;
					buttonBG = Color.WhiteSmoke;
					buttonText = numboxText = toolStripText = Color.Black;
					break;
				case "Dark":
					BG = Color.Black;
					numBoxBG = Color.Black;
					buttonBorder = Color.Silver;
					buttonBG = Color.DimGray;
					buttonText = numboxText = toolStripText = Color.White;
					break;
				case "Matrix":
					BG = Color.Black;
					numBoxBG = Color.Black;
					buttonBorder = Color.Green;
					buttonBG = Color.Black;
					buttonText = Color.Lime;
					numboxText = Color.Lime;
					toolStripText = Color.LawnGreen;
					break;
				case "Blackout":
					BG = Color.Black;
					numBoxBG = Color.Black;
					numboxText = Color.DimGray;
					buttonBorder = Color.DimGray;
					buttonBG = Color.Black;
					buttonText = Color.DimGray;
					toolStripText = Color.DimGray;
					break;
				case "EnEeEs":
					BG = Color.DimGray;
					numBoxBG = Color.LightGray;
					numboxText = Color.Red;
					buttonBG = Color.LightGray;
					buttonBorder = Color.Black;
					buttonText = Color.Red;
					toolStripText = Color.DarkRed;
					break;
				default:
					goto case "Light";
			}

			ApplyChanges(BG, buttonBG, buttonBorder, buttonText, numBoxBG, numboxText, toolStripText);
		}
	}
}
