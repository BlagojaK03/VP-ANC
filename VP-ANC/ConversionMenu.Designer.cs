﻿namespace VP_ANC
{
	partial class ConversionMenu
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.textBoxConverting = new System.Windows.Forms.TextBox();
			this.textBoxConverted = new System.Windows.Forms.TextBox();
			this.comboBoxConverting = new System.Windows.Forms.ComboBox();
			this.comboBoxConverted = new System.Windows.Forms.ComboBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.buttonConvert = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// textBoxConverting
			// 
			this.textBoxConverting.Location = new System.Drawing.Point(13, 13);
			this.textBoxConverting.Name = "textBoxConverting";
			this.textBoxConverting.Size = new System.Drawing.Size(100, 20);
			this.textBoxConverting.TabIndex = 0;
			this.textBoxConverting.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxConverting_Validating);
			// 
			// textBoxConverted
			// 
			this.textBoxConverted.Location = new System.Drawing.Point(13, 49);
			this.textBoxConverted.Name = "textBoxConverted";
			this.textBoxConverted.ReadOnly = true;
			this.textBoxConverted.Size = new System.Drawing.Size(100, 20);
			this.textBoxConverted.TabIndex = 1;
			// 
			// comboBoxConverting
			// 
			this.comboBoxConverting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxConverting.FormattingEnabled = true;
			this.comboBoxConverting.Location = new System.Drawing.Point(119, 13);
			this.comboBoxConverting.Name = "comboBoxConverting";
			this.comboBoxConverting.Size = new System.Drawing.Size(71, 21);
			this.comboBoxConverting.Sorted = true;
			this.comboBoxConverting.TabIndex = 2;
			// 
			// comboBoxConverted
			// 
			this.comboBoxConverted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxConverted.FormattingEnabled = true;
			this.comboBoxConverted.Location = new System.Drawing.Point(119, 49);
			this.comboBoxConverted.Name = "comboBoxConverted";
			this.comboBoxConverted.Size = new System.Drawing.Size(71, 21);
			this.comboBoxConverted.TabIndex = 3;
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// buttonConvert
			// 
			this.buttonConvert.Location = new System.Drawing.Point(161, 156);
			this.buttonConvert.Name = "buttonConvert";
			this.buttonConvert.Size = new System.Drawing.Size(75, 23);
			this.buttonConvert.TabIndex = 4;
			this.buttonConvert.Text = "Convert";
			this.buttonConvert.UseVisualStyleBackColor = true;
			this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
			// 
			// ConversionMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 201);
			this.Controls.Add(this.buttonConvert);
			this.Controls.Add(this.comboBoxConverted);
			this.Controls.Add(this.comboBoxConverting);
			this.Controls.Add(this.textBoxConverted);
			this.Controls.Add(this.textBoxConverting);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ConversionMenu";
			this.Text = "Conversion Menu";
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxConverting;
		private System.Windows.Forms.TextBox textBoxConverted;
		private System.Windows.Forms.ComboBox comboBoxConverting;
		private System.Windows.Forms.ComboBox comboBoxConverted;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.Button buttonConvert;
	}
}