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
	/// <summary>
	/// A ststic class, that contains a set of methods for sending requests to a server
	/// </summary>
	public static class Requests
	{
		public static readonly Configuration config =
			ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		
		/// <summary>
		/// Adding a new shop
		/// </summary>
		/// <returns>Server message</returns>
		public static ServerMessage AddShop() {
			try {
				var new_cm = new ClientMessage();
				new_cm.Type = Protocol.add_shop;
				new_cm.Contents["shop_name"] = config.AppSettings.Settings["shop_name"].Value;
				new_cm.Contents["shop_phone"] = config.AppSettings.Settings["shop_phone"].Value;
				new_cm.Contents["shop_address"] = config.AppSettings.Settings["shop_address"].Value;
				new_cm.Contents["shop_email"] = config.AppSettings.Settings["shop_email"].Value;

				return RequestMessaging.Process( new_cm );
			} catch ( Exception ex ) {
				throw new SampleShopClientException( "Ошибка получения ID:"+ex.Message, ex );
			}
		}
		
		/// <summary>
		/// Getting a list of shops
		/// </summary>
		/// <returns>Server message</returns>
		public static ServerMessage GetShops() {
			try {
				var cm_shops = new ClientMessage();
				cm_shops.Type = Protocol.get_shop_list;
				return RequestMessaging.Process( cm_shops );
			} catch ( Exception ex ) {
				throw new SampleShopClientException( "Ошибка получения списка магазинов:"+ex.Message, ex );
			}
		}
		
		/// <summary>
		/// Getting a list of goodies
		/// </summary>
		/// <returns>Server message</returns>
		public static ServerMessage GetGoods() {
			try {
				var cm_goods = new ClientMessage();
				cm_goods.Type = Protocol.get_shop_list;
				return RequestMessaging.Process( cm_goods );
			} catch ( Exception ex ) {
				throw new SampleShopClientException( "Ошибка получения списка товаров:"+ex.Message, ex );
			}
		}
		
		/// <summary>
		/// Getting a list of goodies
		/// </summary>
		/// <param name="good_id">ID of good</param>
		/// <param name="new_count">New amount of goods in our shop</param>
		/// <returns>Server message</returns>
		public static ServerMessage UpdateGoodsCount( Int64 good_id, int new_count ) {
			try {
				var cm_goods = new ClientMessage();
				cm_goods.Type = Protocol.change_quantity;
				cm_goods.Contents["quantity"] = new_count.ToString();
				cm_goods.Contents["good_id"] = good_id.ToString();
				cm_goods.Contents["shop_id"] = CommonSettings.CurrentShopId.ToString();
				return RequestMessaging.Process( cm_goods );
			} catch ( Exception ex ) {
				throw new SampleShopClientException( "Ошибка получения списка товаров:"+ex.Message, ex );
			}
		}
	}
}