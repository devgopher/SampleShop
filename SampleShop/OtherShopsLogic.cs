/*
 * User: igor.evdokimov
 * Date: 01.03.2016
 * Time: 11:48
 */
using System;
using System.Windows.Forms;
using System.Linq;
using SampleShopServer;

namespace SampleShopClient
{
	public partial class OtherShops : Form
	{	
		/// <summary>
		/// Updates an information in datagrid
		/// </summary>
		private void UpdateInfo() {
			ServerMessage goods_cnt = Requests.GetGoodsQuantity();
			goods_cnt = Requests.GetGoodsQuantity();
			shops_and_goodies.Rows.Clear();
			
			if ( goods_cnt  != null ) {
				foreach ( var gc_pars in goods_cnt.Contents ) {
					if ( gc_pars["shop_id"] != CommonSettings.CurrentShopId.ToString()) {
						int row_index = shops_and_goodies.Rows.Add();
						shops_and_goodies.Rows[row_index].Cells["GoodName"].Value = gc_pars["good_name"];
						shops_and_goodies.Rows[row_index].Cells["GoodQuantity"].Value = gc_pars["good_count"];
						shops_and_goodies.Rows[row_index].Cells["ShopName"].Value = gc_pars["shop_name"];
						shops_and_goodies.Rows[row_index].Cells["ShopPhone"].Value = gc_pars["shop_phone"];
						shops_and_goodies.Rows[row_index].Cells["ShopEmail"].Value = gc_pars["shop_email"];
						shops_and_goodies.Rows[row_index].Cells["ShopAddress"].Value = gc_pars["shop_address"];
					}
				}
			}
		}
	}
}