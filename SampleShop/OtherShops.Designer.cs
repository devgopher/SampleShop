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
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGridViewTextBoxColumn ShopName;
		private System.Windows.Forms.DataGridViewTextBoxColumn ShopAddress;
		private System.Windows.Forms.DataGridViewTextBoxColumn ShopPhone;
		private System.Windows.Forms.DataGridViewTextBoxColumn ShopEmail;
		
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
			this.GoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GoodQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ShopName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ShopAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ShopPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ShopEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button2 = new System.Windows.Forms.Button();
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
			this.ShopName,
			this.ShopAddress,
			this.ShopPhone,
			this.ShopEmail});
			this.shops_and_goodies.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.shops_and_goodies.Location = new System.Drawing.Point(12, 12);
			this.shops_and_goodies.MultiSelect = false;
			this.shops_and_goodies.Name = "shops_and_goodies";
			this.shops_and_goodies.Size = new System.Drawing.Size(607, 386);
			this.shops_and_goodies.TabIndex = 3;
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
			// ShopName
			// 
			this.ShopName.HeaderText = "Магазин";
			this.ShopName.Name = "ShopName";
			this.ShopName.ReadOnly = true;
			// 
			// ShopAddress
			// 
			this.ShopAddress.HeaderText = "Адрес";
			this.ShopAddress.Name = "ShopAddress";
			this.ShopAddress.ReadOnly = true;
			// 
			// ShopPhone
			// 
			this.ShopPhone.HeaderText = "Тел.";
			this.ShopPhone.Name = "ShopPhone";
			this.ShopPhone.ReadOnly = true;
			// 
			// ShopEmail
			// 
			this.ShopEmail.HeaderText = "Email";
			this.ShopEmail.Name = "ShopEmail";
			this.ShopEmail.ReadOnly = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(11, 403);
			this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(108, 21);
			this.button2.TabIndex = 4;
			this.button2.Text = "Обновить инфо";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
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
			this.Load += new System.EventHandler(this.OtherShopsLoad);
			((System.ComponentModel.ISupportInitialize)(this.shops_and_goodies)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
