/*
 * Пользователь: Igor
 * Дата: 01.03.2016
 * Время: 0:06
 */
using System;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using SampleShopServer;

namespace SampleShopClient
{
	public static class Requests
	{
		public static readonly Configuration config =
			ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);	

		
		public static ServerMessage AddShop() {
			try {
				var new_cm = new ClientMessage();
				new_cm.Type = Protocol.add_shop;
				new_cm.Contents["shop_name"] = config.AppSettings.Settings["shop_name"].Value;
				new_cm.Contents["shop_phone"] = config.AppSettings.Settings["shop_phone"].Value;
				new_cm.Contents["shop_address"] = config.AppSettings.Settings["shop_address"].Value;
				new_cm.Contents["shop_email"] = config.AppSettings.Settings["shop_email"].Value;

				RequestMessaging.Process( new_cm );
			} catch ( Exception ex ) {
				MessageBox.Show( "ошибка получения ID:"+ex.Message );
			}
			return null;
		}
		
		// TODO: получение и обновление списка товаров, 
	}
}
