/*
 * User: igor.evdokimov
 * Date: 01.03.2016
 * Time: 10:19
 */
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace SampleShopClient
{
	/// <summary>
	/// Description of OtherShops.
	/// </summary>
	public partial class OtherShops : Form
	{
		readonly Int64 good_id = 0;
		Int64 current_shop_id = 0;		
		
		public void GetShopId() {
			current_shop_id = Int64.Parse(Settings.config.AppSettings.Settings["shop_id"].Value);
		}
		
		public OtherShops( Int64 _good_id  )
		{
			InitializeComponent();
			GetShopId();
		}
	}
}
