/*
 * Пользователь: Igor
 * Дата: 28.02.2016
 * Время: 11:18
 */
using System;
using System.Net;
using System.Text;
using System.Data;
using SampleShopServer;
using SampleShopServer.Model;

namespace TestServer
{
	/// <summary>
	/// Description of TestProc
	/// </summary>
	public static class TestProc
	{
		public static void TestMessageSendReceive(string ip_addr) {
			ClientMessage send_msg = new ClientMessage();
			send_msg.Contents["shop_id"] = 127.ToString();
			send_msg.Contents["good_id"] = 10.ToString();
			send_msg.Contents["quantity"] = 102.ToString();
			send_msg.Type = Protocol.change_quantity;
			var xml = send_msg.ToXml()+"\r\n\r\n";
			var xml_bytes = Encoding.UTF8.GetBytes( xml );
			
			HttpWebRequest hw = (HttpWebRequest)WebRequest.Create("http://"+ip_addr);
			hw.Credentials = CredentialCache.DefaultCredentials;
			hw.UserAgent = "TestAgent";
			hw.Method = "POST";
			hw.KeepAlive = true;
			hw.ContentLength = xml_bytes.Length;
			var hw_stream = hw.GetRequestStream();
			hw_stream.Write( xml_bytes, 0, xml_bytes.Length );
			hw_stream.Close();
			
			while (!hw.HaveResponse) {
			}
			
			HttpWebResponse resp = (HttpWebResponse)hw.GetResponse();

			byte[] resp_buffer = new byte[16000];
			var resp_stream = resp.GetResponseStream();
			
			while(resp_stream.Read( resp_buffer, 0, resp_buffer.Length ) > 0)
			{
				
			}
			
			var resp_string = Encoding.UTF8.GetString( resp_buffer );
			
			Console.WriteLine("Respond: "+resp_string);
			
		}
		
		public static void TestQuery() {
			DatabaseInteraction db = new DatabaseInteraction();
			var ret = db.ExecuteSelect("select * from \"Shops\"");
			Console.WriteLine("Tables count: "+ret.Tables.Count);
			foreach ( DataTable tbl in ret.Tables ) {
				Console.WriteLine("Table name: "+tbl.TableName);
				Console.WriteLine("Table cols count: "+tbl.Columns.Count);
				Console.WriteLine("Table rows count: "+tbl.Rows.Count);
			}
		}
	}
}