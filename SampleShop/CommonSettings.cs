/*
 * User: igor.evdokimov
 * Date: 01.03.2016
 * Time: 16:51
 */
using System;
using System.Configuration;

namespace SampleShopClient
{
	/// <summary>
	/// Common settings for SampleShop
	/// </summary>
	public static class CommonSettings
	{
		private static Configuration config = null;
		
		public static Configuration Config {
			get {
				if ( config == null )
					config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				return config;
			}
		}
		
		static CommonSettings() {
			if ( Config.AppSettings.Settings["shop_id"] != null )
				CurrentShopId = Int64.Parse(Config.AppSettings.Settings["shop_id"].Value);
			else
				CurrentShopId = -1;
		}
		
		public static Int64 CurrentShopId {
			get; private set;
		}
	}
}