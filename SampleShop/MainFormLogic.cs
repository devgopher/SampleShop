/*
 * Пользователь: Igor
 * Дата: 02.03.2016
 * Время: 1:08
 */
using System;
using System.Windows.Forms;
using System.Linq;
using SampleShopServer;

namespace SampleShopClient
{
	/// <summary>
	/// Description of MainFormLogic.
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Updates an information in datagrid
		/// </summary>
		private void UpdateInfo() {
			ServerMessage goods = Requests.GetGoods();
			goods = Requests.GetGoods();
			ServerMessage shops = Requests.GetShops();
			
			
			current_shop_goodies.Rows.Clear();
			
			if ( goods != null && shops != null ) {
				foreach ( var good_pars in goods.Contents ) {
					foreach ( var shop_pars in shops.Contents ) {
						int row_index = current_shop_goodies.Rows.Add();
						if ( good_pars["shop_id"].Equals( shop_pars["shop_id"] )  &&
						    shop_pars["shop_id"] == CommonSettings.CurrentShopId.ToString()) {
							current_shop_goodies.Rows[row_index].Cells["GoodName"].Value = good_pars["good_name"];
							current_shop_goodies.Rows[row_index].Cells["GoodQuantity"].Value = good_pars["good_count"];
						}
					}
				}
			}
		}
	}
}
