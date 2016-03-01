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
		
		private void Load() {
			UpdateInfo();
		}
		
		private void UpdateInfo() {
			var cm_goods = new ClientMessage();
			var cm_shops = new ClientMessage();
			cm_goods.Type = Protocol.get_good_list;
			cm_shops.Type = Protocol.get_shop_list;
			
			ServerMessage goods = RequestMessaging.Process( cm_goods );
			ServerMessage shops = RequestMessaging.Process( cm_shops );
			
			shops_and_goodies.Rows.Clear();
			
			if ( goods != null && shops != null ) {
				foreach ( var good_pars in goods.Contents ) {
					foreach ( var shop_pars in shops.Contents ) {
						int row_index = shops_and_goodies.Rows.Add();
						if ( good_pars["shop_id"].Equals( shop_pars["shop_id"] )  && Int64.Parse(shop_pars["shop_id"]) != current_shop_id ) {
							shops_and_goodies.Rows[row_index].Cells["GoodName"].Value = good_pars["good_name"];
							shops_and_goodies.Rows[row_index].Cells["GoodQuantity"].Value = good_pars["good_count"];
							shops_and_goodies.Rows[row_index].Cells["ShopName"].Value = good_pars["shop_name"];
							shops_and_goodies.Rows[row_index].Cells["ShopPhone"].Value = good_pars["shop_phone"];
							shops_and_goodies.Rows[row_index].Cells["ShopEmail"].Value = good_pars["shop_email"];
							shops_and_goodies.Rows[row_index].Cells["ShopAddress"].Value = good_pars["shop_address"];
						}
					}
				}
			}
		}
	}
}
