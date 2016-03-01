/*
 * Пользователь: Igor
 * Дата: 27.02.2016
 * Время: 21:19
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SampleShopClient
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		void SettingsClick(object sender, EventArgs e)
		{
			var settings_form = new Settings();
			settings_form.Show();
		}
		
		void CurrentShopGoodiesCellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			var sender_grid = sender as DataGridView;
			if ( sender_grid != null )
			{
				if ( sender_grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 ) {
					var selected_row = sender_grid.Rows[e.RowIndex];
					if ( selected_row.Cells["good_id"].Value != null ) {
						// обрабатываем нажатие кнопки в ячейке
						var other_shops= new OtherShops( Int64.Parse(selected_row.Cells["good_id"].Value.ToString()));
						other_shops.Show();
					}
				}
			}
		}
	}
}
