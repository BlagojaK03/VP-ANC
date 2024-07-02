using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_ANC
{
	public partial class extraOperationsMenu : UserControl
	{
		public EventHandler unaryOperations;
		public EventHandler binaryOperations;
		public extraOperationsMenu()
		{
			InitializeComponent();
		}

		private void UnaryButtonClicked(object sender, EventArgs e)
		{
			unaryOperations.Invoke(sender, e);
		}
		private void BinaryButtonClicked(object sender, EventArgs e)
		{
			binaryOperations.Invoke(sender, e);
		}
	}
}
