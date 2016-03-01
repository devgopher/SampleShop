/*
 * User: igor.evdokimov
 * Date: 01.03.2016
 * Time: 10:19
 */
namespace SampleShopClient
{
	partial class OtherShops
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridView shops_and_goodies;
		private System.Windows.Forms.DataGridViewTextBoxColumn GoodName;
		private System.Windows.Forms.DataGridViewTextBoxColumn GoodQuantity;
		private System.Windows.Forms.DataGridViewTextBoxColumn shop_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn shop_address;
		private System.Windows.Forms.DataGridViewTextBoxColumn shop_phone;
		private System.Windows.Forms.DataGridViewTextBoxColumn shop_email;
		private System.Windows.Forms.Button button2;
		
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
			this.shops_and_goodies = new System.Windows.Forms.DataGridView();
			this.button2 = new System.Windows.Forms.Button();
			this.GoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GoodQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.shop_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.shop_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.shop_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.shop_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.shops_and_goodies)).BeginInit();
			this.SuspendLayout();
			// 
			// shops_and_goodies
			// 
			this.shops_and_goodies.AllowUserToAddRows = false;
			this.shops_and_goodies.AllowUserToDeleteRows = false;
			this.shops_and_goodies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.shops_and_goodies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.shops_and_goodies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.GoodName,
			this.GoodQuantity,
			this.shop_name,
			this.shop_address,
			this.shop_phone,
			this.shop_email});
			this.shops_and_goodies.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.shops_and_goodies.Location = new System.Drawing.Point(12, 12);
			this.shops_and_goodies.MultiSelect = false;
			this.shops_and_goodies.Name = "shops_and_goodies";
			this.shops_and_goodies.Size = new System.Drawing.Size(607, 386);
			this.shops_and_goodies.TabIndex = 3;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(11, 403);
			this.button2.Margin = new System.Windows.Forms.Padding(2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(108, 21);
			this.button2.TabIndex = 4;
			this.button2.Text = "Обновить инфо";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// GoodName
			// 
			this.GoodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.GoodName.HeaderText = "Название товара";
			this.GoodName.Name = "GoodName";
			this.GoodName.ReadOnly = true;
			this.GoodName.Width = 110;
			// 
			// GoodQuantity
			// 
			this.GoodQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.GoodQuantity.HeaderText = "Кол-во";
			this.GoodQuantity.Name = "GoodQuantity";
			this.GoodQuantity.ReadOnly = true;
			this.GoodQuantity.Width = 66;
			// 
			// shop_name
			// 
			this.shop_name.HeaderText = "Магазин";
			this.shop_name.Name = "ShopName";
			this.shop_name.ReadOnly = true;
			// 
			// shop_address
			// 
			this.shop_address.HeaderText = "Адрес";
			this.shop_address.Name = "ShopAddress";
			this.shop_address.ReadOnly = true;
			// 
			// shop_phone
			// 
			this.shop_phone.HeaderText = "Тел.";
			this.shop_phone.Name = "ShopPhone";
			this.shop_phone.ReadOnly = true;
			// 
			// shop_email
			// 
			this.shop_email.HeaderText = "Email";
			this.shop_email.Name = "ShopEmail";
			this.shop_email.ReadOnly = true;
			// 
			// OtherShops
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(633, 435);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.shops_and_goodies);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "OtherShops";
			this.Text = "Товары в других магазинах";
			((System.ComponentModel.ISupportInitialize)(this.shops_and_goodies)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
