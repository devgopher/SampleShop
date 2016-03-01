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
			try {
				var cfg = CommonSettings.Config;
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
				shop_email.Text = CommonSettings.Config.AppSettings.Settings["shop_email"].Value;
				
				if ( CommonSettings.Config.AppSettings.Settings["shop_id"] != null )
					shop_id.Text = CommonSettings.Config.AppSettings.Settings["shop_id"].Value;
				else
					shop_id.Text = "-1";
			} catch ( Exception ex ) {
				MessageBox.Show(ex.Message);
			}
		}
		
		/// <summary>
		/// Saves new settings
		/// </summary>
		private void Save() {
			try {
				CommonSettings.Config.AppSettings.Settings.Remove("server_ip");
				CommonSettings.Config.AppSettings.Settings.Remove("shop_name");
				CommonSettings.Config.AppSettings.Settings.Remove("shop_address");
				CommonSettings.Config.AppSettings.Settings.Remove("shop_phone");
				CommonSettings.Config.AppSettings.Settings.Remove("shop_email");
				
				CommonSettings.Config.AppSettings.Settings.Add("server_ip", server_ip.Text.Trim());
				CommonSettings.Config.AppSettings.Settings.Add("shop_name", shop_name.Text.Trim());
				CommonSettings.Config.AppSettings.Settings.Add("shop_address", shop_address.Text.Trim());
				CommonSettings.Config.AppSettings.Settings.Add("shop_phone", shop_phone.Text.Trim());
				CommonSettings.Config.AppSettings.Settings.Add("shop_email", shop_email.Text.Trim());

				CommonSettings.Config.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection("appSettings");
				
				
				// если наш магазин еще не занесен в БД на сервере и у нас нет ID,
				// сделаем соотв. запрос...
				if ( shop_id.Text == "-1" ) {
					var id_msg = Requests.AddShop();
					if ( id_msg != null ) {
						CommonSettings.Config.AppSettings.Settings.Remove("shop_id");
						CommonSettings.Config.AppSettings.Settings.Add("shop_id", (id_msg.Contents[0])["shop_id"].ToString());
						CommonSettings.Config.Save(ConfigurationSaveMode.Modified);
						ConfigurationManager.RefreshSection("appSettings");
					}
				} else {
					Requests.ModShop();
				}
			} catch ( Exception ex ) {
				MessageBox.Show(ex.Message);
			}
		}
	}
}
