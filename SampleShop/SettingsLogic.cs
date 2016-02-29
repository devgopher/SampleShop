/*
 * Пользователь: Igor
 * Дата: 29.02.2016
 * Время: 22:39
 */
using System;
using System.Windows.Forms;
using System.Configuration;

namespace SampleShopClient
{
	public partial class Settings : Form
	{
		public static readonly Configuration config =
			ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		
		private void Load() {
			if ( config.AppSettings.Settings["server_ip"] == null )
				return;
			if ( config.AppSettings.Settings["shop_name"] == null )
				return;
			if ( config.AppSettings.Settings["shop_address"] == null )
				return;
			if ( config.AppSettings.Settings["shop_phone"] == null )
				return;

			server_ip.Text = config.AppSettings.Settings["server_ip"].Value;
			shop_name.Text = config.AppSettings.Settings["shop_name"].Value;
			shop_address.Text = config.AppSettings.Settings["shop_address"].Value;
			shop_phone.Text = config.AppSettings.Settings["shop_phone"].Value;
			email.Text = config.AppSettings.Settings["email"].Value;
			
			if ( config.AppSettings.Settings["shop_id"] != null )
				shop_id.Text = config.AppSettings.Settings["shop_id"].Value;

		}

		
		private void Save() {
			config.AppSettings.Settings.Remove("server_ip");
			config.AppSettings.Settings.Remove("shop_name");
			config.AppSettings.Settings.Remove("shop_address");
			config.AppSettings.Settings.Remove("shop_phone");
			config.AppSettings.Settings.Remove("email");
			
			config.AppSettings.Settings.Add("server_ip", server_ip.Text.Trim());
			config.AppSettings.Settings.Add("shop_name", shop_name.Text.Trim());
			config.AppSettings.Settings.Add("shop_address", shop_address.Text.Trim());
			config.AppSettings.Settings.Add("shop_phone", shop_phone.Text.Trim());
			config.AppSettings.Settings.Add("email", email.Text.Trim());
			
			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");
		}
	}
}
