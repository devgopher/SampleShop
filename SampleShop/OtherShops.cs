/*
 * User: igor.evdokimov
 * Date: 01.03.2016
 * Time: 10:19
 */
using System;
using System.Windows.Forms;

namespace SampleShopClient
{
	/// <summary>
	/// Description of OtherShops.
	/// </summary>
	public partial class OtherShops : Form
	{
		readonly Int64 good_id = 0;
		
		public OtherShops( Int64 _good_id  )
		{
			InitializeComponent();
			good_id = _good_id;
		}
		void Button2Click(object sender, EventArgs e)
		{
			UpdateInfo();
		}
		
		void OtherShopsLoad(object sender, EventArgs e)
		{
			UpdateInfo();
		}
	}
}