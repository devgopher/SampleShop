/*
 * Пользователь: Igor
 * Дата: 01.03.2016
 * Время: 0:06
 */
using System;
using System.Windows.Forms;
using SampleShopServer;

namespace SampleShopClient
{
	/// <summary>
	/// Description of Requests.
	/// </summary>
	public static class Requests
	{
		public static ServerMessage GetNewId() {
			try {
				
			} catch ( Exception ex ) {
				MessageBox.Show( "ошибка получения ID:"+ex.Message );
			}
		}
	}
}
