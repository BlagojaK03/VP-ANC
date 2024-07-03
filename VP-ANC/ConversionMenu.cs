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
						"Dec", "Bin", "Hex"
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
				case "Distance":
					options = new string[]
					{
						"km", "mi"
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
				if (double.TryParse(textBoxConverting.Text, out double number))
				{
					e.Cancel = false;
					errorProvider.SetError(textBoxConverting, null);

					//Insert logic here
				}
				else
				{
					e.Cancel = true;
					errorProvider.SetError(textBoxConverting, "Type a number!");
				}
			}
			else
			{

			}
		}

		private void buttonConvert_Click(object sender, EventArgs e)
		{

		}
	}
}
