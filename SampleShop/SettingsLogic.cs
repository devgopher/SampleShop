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
		private void Load() {
			if ( CommonSettings.Config.AppSettings.Settings["server_ip"] == null )
				return;
			if ( CommonSettings.Config.AppSettings.Settings["shop_name"] == null )
				return;
			if ( CommonSettings.Config.AppSettings.Settings["shop_address"] == null )
				return;
			if ( CommonSettings.Config.AppSettings.Settings["shop_phone"] == null )
				return;

			server_ip.Text = CommonSettings.Config.AppSettings.Settings["server_ip"].Value;
			shop_name.Text = CommonSettings.Config.AppSettings.Settings["shop_name"].Value;
			shop_address.Text = CommonSettings.Config.AppSettings.Settings["shop_address"].Value;
			shop_phone.Text = CommonSettings.Config.AppSettings.Settings["shop_phone"].Value;
			email.Text = CommonSettings.Config.AppSettings.Settings["email"].Value;
			
			if ( CommonSettings.Config.AppSettings.Settings["shop_id"] != null )
				shop_id.Text = CommonSettings.Config.AppSettings.Settings["shop_id"].Value;

		}

		
		private void Save() {
			CommonSettings.Config.AppSettings.Settings.Remove("server_ip");
			CommonSettings.Config.AppSettings.Settings.Remove("shop_name");
			CommonSettings.Config.AppSettings.Settings.Remove("shop_address");
			CommonSettings.Config.AppSettings.Settings.Remove("shop_phone");
			CommonSettings.Config.AppSettings.Settings.Remove("email");
			
			CommonSettings.Config.AppSettings.Settings.Add("server_ip", server_ip.Text.Trim());
			CommonSettings.Config.AppSettings.Settings.Add("shop_name", shop_name.Text.Trim());
			CommonSettings.Config.AppSettings.Settings.Add("shop_address", shop_address.Text.Trim());
			CommonSettings.Config.AppSettings.Settings.Add("shop_phone", shop_phone.Text.Trim());
			CommonSettings.Config.AppSettings.Settings.Add("email", email.Text.Trim());
			
			CommonSettings.Config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");
		}
	}
}
