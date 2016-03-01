/*
 * Пользователь: Igor
 * Дата: 27.02.2016
 * Время: 21:19
 */
using System;
using System.Windows.Forms;
using System.Configuration;

namespace SampleShop
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			if ( IsConfigured() )
				Application.Run(new SampleShopClient.MainForm());
			else {
				Application.Run(new SampleShopClient.Settings());
			}
		}
		
		private static bool IsConfigured() {
			var aset = ConfigurationManager.AppSettings["server_ip"];
			return aset != null;
		}
	}
}
