/*
 * Пользователь: Igor
 * Дата: 29.02.2016
 * Время: 22:28
 */
namespace SampleShopClient
{
	partial class Settings
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button save_button;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox shop_name;
		private System.Windows.Forms.TextBox shop_address;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox shop_phone;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox shop_id;
		private System.Windows.Forms.TextBox server_ip;
		private System.Windows.Forms.TextBox shop_email;
		private System.Windows.Forms.Label label6;

		
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
			this.save_button = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.shop_name = new System.Windows.Forms.TextBox();
			this.shop_address = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.shop_phone = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.shop_id = new System.Windows.Forms.TextBox();
			this.server_ip = new System.Windows.Forms.TextBox();
			this.shop_email = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// save_button
			// 
			this.save_button.Location = new System.Drawing.Point(264, 151);
			this.save_button.Margin = new System.Windows.Forms.Padding(2);
			this.save_button.Name = "save_button";
			this.save_button.Size = new System.Drawing.Size(70, 24);
			this.save_button.TabIndex = 0;
			this.save_button.Text = "Сохранить";
			this.save_button.UseVisualStyleBackColor = true;
			this.save_button.Click += new System.EventHandler(this.Save_buttonClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 26);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Название магазина:";
			// 
			// shop_name
			// 
			this.shop_name.Location = new System.Drawing.Point(135, 24);
			this.shop_name.Margin = new System.Windows.Forms.Padding(2);
			this.shop_name.Name = "shop_name";
			this.shop_name.Size = new System.Drawing.Size(200, 20);
			this.shop_name.TabIndex = 2;
			// 
			// shop_address
			// 
			this.shop_address.Location = new System.Drawing.Point(135, 46);
			this.shop_address.Margin = new System.Windows.Forms.Padding(2);
			this.shop_address.Name = "shop_address";
			this.shop_address.Size = new System.Drawing.Size(200, 20);
			this.shop_address.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 49);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 19);
			this.label2.TabIndex = 3;
			this.label2.Text = "Адрес:";
			// 
			// shop_phone
			// 
			this.shop_phone.Location = new System.Drawing.Point(135, 69);
			this.shop_phone.Margin = new System.Windows.Forms.Padding(2);
			this.shop_phone.Name = "shop_phone";
			this.shop_phone.Size = new System.Drawing.Size(200, 20);
			this.shop_phone.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 72);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 19);
			this.label3.TabIndex = 5;
			this.label3.Text = "Телефон:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(9, 3);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(110, 19);
			this.label4.TabIndex = 7;
			this.label4.Text = "ID:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(9, 117);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(110, 19);
			this.label5.TabIndex = 9;
			this.label5.Text = "IP:port";
			// 
			// shop_id
			// 
			this.shop_id.Location = new System.Drawing.Point(135, 1);
			this.shop_id.Margin = new System.Windows.Forms.Padding(2);
			this.shop_id.Name = "shop_id";
			this.shop_id.ReadOnly = true;
			this.shop_id.Size = new System.Drawing.Size(200, 20);
			this.shop_id.TabIndex = 10;
			// 
			// server_ip
			// 
			this.server_ip.Location = new System.Drawing.Point(135, 115);
			this.server_ip.Margin = new System.Windows.Forms.Padding(2);
			this.server_ip.Name = "server_ip";
			this.server_ip.Size = new System.Drawing.Size(200, 20);
			this.server_ip.TabIndex = 11;
			// 
			// shop_email
			// 
			this.shop_email.Location = new System.Drawing.Point(135, 92);
			this.shop_email.Margin = new System.Windows.Forms.Padding(2);
			this.shop_email.Name = "shop_email";
			this.shop_email.Size = new System.Drawing.Size(200, 20);
			this.shop_email.TabIndex = 13;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(9, 94);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(110, 19);
			this.label6.TabIndex = 12;
			this.label6.Text = "Email:";
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(338, 177);
			this.Controls.Add(this.shop_email);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.server_ip);
			this.Controls.Add(this.shop_id);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.shop_phone);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.shop_address);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.shop_name);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.save_button);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Settings";
			this.Text = "Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
