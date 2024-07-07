using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_ANC
{
	public partial class ConversionMenu : Form
	{
		readonly string ConversionType;
		public ConversionMenu(string type)
		{
			InitializeComponent();
			string[] options;
			switch (type)
			{
				case "Number Format":
					options = new string[]
					{
						"Dec", "Bin", "Hex", "Oct"
					};
					break;
				case "Temperature":
					options = new string[] 
					{
						"C", "F", "K"
					};
					break;
				case "Mass":
					options = new string[]
					{
						"kg", "lbs", "stone"
					};
					break;
				case "Length":
					options = new string[]
					{
						"km", "cm", "mi", "ft"
					};
					break;
				default:
					options = null;
					break;
			}
			comboBoxConverting.Items.AddRange(options);
			comboBoxConverted.Items.AddRange(options);
			ConversionType = type;
			Text += $" - {type}";
			
		}

		private void textBoxConverting_Validating(object sender, CancelEventArgs e)
		{
			if (ConversionType != "Number Format")
			{
				if (double.TryParse(textBoxConverting.Text, out double _))
				{
					e.Cancel = false;
					errorProvider.SetError(textBoxConverting, null);
				}
				else
				{
					e.Cancel = true;
					errorProvider.SetError(textBoxConverting, "Type a decimal number!");
				}
			}
			else // ConversionType == "Number Format"
			{
				bool isValidInput = false;
				string Allowed;
				string Input = textBoxConverting.Text;
				
				switch (comboBoxConverting.Text)
				{
					case "Hex":
						Allowed = "0123456789abcdef";
						break;
					case "Oct":
						Allowed = "01234567";
						break;
					case "Bin":
						Allowed = "01";
						break;
					default: // case "Dec"
						Allowed = "0123456789";
						break;
				}

				foreach (char Digit in Input)
				{
					if (Allowed.IndexOf(char.ToLower(Digit)) == -1)
					{
						isValidInput = false;
						break;
					}
					isValidInput = true;
				}

				if (isValidInput)
				{
					e.Cancel = false;
					errorProvider.SetError(textBoxConverting, null);
				}
				else
				{
					e.Cancel = true;
					errorProvider.SetError(textBoxConverting, "Type a valid number!");
				}
			}
		}

		private void buttonConvert_Click(object sender, EventArgs e)
		{
			if (comboBoxConverting.Text == "" || comboBoxConverted.Text == "")
			{
				MessageBox.Show("Combo boxes cannot be blank!", "ANC - Error");
				return; 
			}
			switch (ConversionType)
			{
				case "Number Format":
					textBoxConverted.Text = Converter.ConvertNumberFormat(textBoxConverting.Text, comboBoxConverting.Text, comboBoxConverted.Text);
					break;
				case "Temperature":
					textBoxConverted.Text = Converter.ConvertTemperature(double.Parse(textBoxConverting.Text), comboBoxConverting.Text, comboBoxConverted.Text).ToString();
					break;
				case "Mass":
					textBoxConverted.Text = Converter.ConvertMass(double.Parse(textBoxConverting.Text), comboBoxConverting.Text, comboBoxConverted.Text).ToString();
					break;
				case "Length":
					textBoxConverted.Text = Converter.ConvertLength(double.Parse(textBoxConverting.Text), comboBoxConverting.Text, comboBoxConverted.Text).ToString();
					break;
			}
		}

		public void ApplyTheme(Color bg, Color btnBG, Color btnFG, Color ctbBG, Color ctbFG, Color btnBorder)
		{
			BackColor = bg;
			foreach (var item in Controls)
			{
				if (item is Button)
				{
					Button button = item as Button;
					button.BackColor = btnBG;
					button.ForeColor = btnFG;
					button.FlatStyle = FlatStyle.Flat;
					button.FlatAppearance.BorderColor = btnBorder;
					button.FlatAppearance.BorderSize = 2;
				}
				else if (item is TextBox)
				{
					TextBox textBox = item as TextBox;
					textBox.BackColor = ctbBG;
					textBox.ForeColor = ctbFG;
				}
				else if (item is ComboBox)
				{
					ComboBox comboBox = item as ComboBox;
					comboBox.BackColor = ctbBG;
					comboBox.ForeColor = ctbFG;
				}
			}
		}

		private void ConversionMenu_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = false;
		}
	}
}
