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
	public partial class ancMainWindow : Form
	{
		public ancMainWindow()
		{
			InitializeComponent();
		}

		private void ancMainWindow_Load(object sender, EventArgs e)
		{
			MessageBox.Show("Welcome!\nThe goal is simple: use this calculator to get 5 as a result!", "A Normal Calculator - ANC");
		}

		private void ancMainWindow_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '5') { throw new FiveOnKeyboardPressedException("You Did It!!"); }
		}
	}
}
