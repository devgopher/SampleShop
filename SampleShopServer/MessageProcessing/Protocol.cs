/*
 * Пользователь: Igor
 * Дата: 27.02.2016
 * Время: 23:32
 */
using System;
using System.Xml;
using System.Collections.Generic;

namespace SampleShopServer
{
	/// <summary>
	/// SimpleShop protocol messages
	/// </summary>
	public static class Protocol
	{
		#region ClientRequestTypes
		public const string add_shop = "ADDSHOP";
		public const string mod_shop = "MODSHOP";
		public const string change_quantity = "CHGQUAN";
		public const string get_shop_list = "GETSHOPS";
		public const string get_good_list = "GETGOODS";
		public const string get_good_quantity = "GETGOODCNT";
		#endregion
		
		#region ServerResponseTypes
		public const string common_response = "COMMRESP";
		public const string success_response = "SUCCRESP";
		public const string error_response = "ERRRESP";
		#endregion
	}
}
