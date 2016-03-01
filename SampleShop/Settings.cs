/*
 * Пользователь: Igor
 * Дата: 29.02.2016
 * Время: 22:28
 */
using System;
using System.Windows.Forms;

namespace SampleShopClient
{
	/// <summary>
	/// Description of Settings.
	/// </summary>
	public partial class Settings : Form
	{
		public Settings()
		{
			InitializeComponent();
			Load();
		}
		
		void Save_buttonClick(object sender, EventArgs e)
		{
			Save();			
			this.Close();
		}
	}
}
