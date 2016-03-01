/*
 * Пользователь: Igor
 * Дата: 27.02.2016
 * Время: 21:19
 */
namespace SampleShopClient
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button settings;
		private System.Windows.Forms.Button update_info;
		private System.Windows.Forms.DataGridView current_shop_goodies;
		private System.Windows.Forms.DataGridViewTextBoxColumn GoodName;
		private System.Windows.Forms.DataGridViewTextBoxColumn GoodQuantity;
		private System.Windows.Forms.DataGridViewButtonColumn LookInOtherShops;
		private System.Windows.Forms.DataGridViewTextBoxColumn good_id;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.settings = new System.Windows.Forms.Button();
			this.update_info = new System.Windows.Forms.Button();
			this.current_shop_goodies = new System.Windows.Forms.DataGridView();
			this.GoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.good_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GoodQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LookInOtherShops = new System.Windows.Forms.DataGridViewButtonColumn();
			((System.ComponentModel.ISupportInitialize)(this.current_shop_goodies)).BeginInit();
			this.SuspendLayout();
			// 
			// settings
			// 
			this.settings.Location = new System.Drawing.Point(1, 363);
			this.settings.Margin = new System.Windows.Forms.Padding(2);
			this.settings.Name = "settings";
			this.settings.Size = new System.Drawing.Size(77, 21);
			this.settings.TabIndex = 0;
			this.settings.Text = "Настройки";
			this.settings.UseVisualStyleBackColor = true;
			this.settings.Click += new System.EventHandler(this.SettingsClick);
			// 
			// update_info
			// 
			this.update_info.Location = new System.Drawing.Point(82, 363);
			this.update_info.Margin = new System.Windows.Forms.Padding(2);
			this.update_info.Name = "update_info";
			this.update_info.Size = new System.Drawing.Size(108, 21);
			this.update_info.TabIndex = 1;
			this.update_info.Text = "Обновить инфо";
			this.update_info.UseVisualStyleBackColor = true;
			// 
			// current_shop_goodies
			// 
			this.current_shop_goodies.AllowUserToAddRows = false;
			this.current_shop_goodies.AllowUserToDeleteRows = false;
			this.current_shop_goodies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.current_shop_goodies.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.current_shop_goodies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.current_shop_goodies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.GoodName,
			this.good_id,
			this.GoodQuantity,
			this.LookInOtherShops});
			this.current_shop_goodies.Location = new System.Drawing.Point(1, 2);
			this.current_shop_goodies.MultiSelect = false;
			this.current_shop_goodies.Name = "current_shop_goodies";
			this.current_shop_goodies.Size = new System.Drawing.Size(607, 356);
			this.current_shop_goodies.TabIndex = 2;
			this.current_shop_goodies.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CurrentShopGoodiesCellContentClick);
			this.current_shop_goodies.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CurrentShopGoodiesCellValueChanged);
			// 
			// GoodName
			// 
			this.GoodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.GoodName.HeaderText = "Название товара";
			this.GoodName.Name = "GoodName";
			this.GoodName.ReadOnly = true;
			this.GoodName.Width = 110;
			// 
			// good_id
			// 
			this.good_id.HeaderText = "ID товара";
			this.good_id.Name = "GoodId";
			this.good_id.ReadOnly = true;
			// 
			// GoodQuantity
			// 
			this.GoodQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.GoodQuantity.HeaderText = "Кол-во";
			this.GoodQuantity.Name = "GoodQuantity";
			this.GoodQuantity.Width = 66;
			// 
			// LookInOtherShops
			// 
			this.LookInOtherShops.HeaderText = "Др. магазины";
			this.LookInOtherShops.Name = "LookInOtherShops";
			this.LookInOtherShops.ReadOnly = true;
			this.LookInOtherShops.Text = "Др. магазины";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(610, 387);
			this.Controls.Add(this.current_shop_goodies);
			this.Controls.Add(this.update_info);
			this.Controls.Add(this.settings);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainForm";
			this.Text = "SampleShop";
			((System.ComponentModel.ISupportInitialize)(this.current_shop_goodies)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
