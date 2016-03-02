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
			
			ServerMessage goods_cnt = Requests.GetGoodsQuantity();
			goods_cnt = Requests.GetGoodsQuantity();
			current_shop_goodies.Rows.Clear();
			
			if ( goods_cnt  != null ) {
				foreach ( var gc_pars in goods_cnt.Contents ) {
					if ( gc_pars["shop_id"] == CommonSettings.CurrentShopId.ToString()) {
						int row_index = current_shop_goodies.Rows.Add();
						current_shop_goodies.Rows[row_index].Cells[GoodName.Name].Value = gc_pars["good_name"];
						current_shop_goodies.Rows[row_index].Cells[GoodId.Name].Value = gc_pars["good_id"];
						current_shop_goodies.Rows[row_index].Cells[GoodQuantity.Name].Value = gc_pars["good_count"];
					}
				}
			}
		}
	}
}
