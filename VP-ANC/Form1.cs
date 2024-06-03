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
		}

		private void stayOnTopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!stayOnTopToolStripMenuItem.Checked)
			{
				stayOnTopToolStripMenuItem.Checked = true;
				TopMost = true;
			}
			else
			{
				stayOnTopToolStripMenuItem.Checked = false;
				TopMost = false;
			}
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

		private void ancMainWindow_Activated(object sender, EventArgs e)
		{
			theme = new AppTheme(lightToolStripMenuItem);
			Activated -= startupEvent;
		}
	}
}
