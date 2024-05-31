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
			Color ButtonText,
			Color NumBoxBackground,
			Color NumBoxText,
			Color ToolStripBackground,
			Color ToolStripText
		)
		{

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
		}
	}
}
