/*
 * Пользователь: Igor
 * Дата: 29.02.2016
 * Время: 23:43
 */
using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using SampleShopServer;

namespace SampleShopClient
{
	/// <summary>
	/// Description of RequestMessaging.
	/// </summary>
	public static class RequestMessaging
	{
		private static string server_ip =
			Settings.config.AppSettings.Settings["server_ip"].Value;
		private const int max_ba_length = 1048576;
		
		private static string GetResponseText( ClientMessage msg ) {
			var response = RequestMessaging.GetResponseOnMessage( msg );
			var resp_stream = response.GetResponseStream();
			var rec_bytes = new byte[max_ba_length];
			resp_stream.Read( rec_bytes, 0, rec_bytes.Length );
			return Encoding.UTF8.GetString( rec_bytes );
		}
		
		public static ServerMessage Process( ClientMessage msg )  {			
			var response = GetResponseOnMessage( msg );
			if ( response != null ) {								
				string response_text = GetResponseText( msg );
				return RequestMessaging.ProcessResponseText( response_text );
			}
			return null;
		}
		
		public static ServerMessage ProcessResponseText( string contents ) {
			if ( contents.Contains("<root>") &&
			    contents.Contains("</root>"))
			{
				var start_xml = contents.IndexOf("<root>");
				var length = contents.IndexOf("</root>")+7-
					contents.IndexOf("<root>");
				var xml = contents.Substring( start_xml, length );
				
				var msg = new ServerMessage();
				msg.FromXML( xml );
				return msg;
			}
			return null;
		}
		
		public static HttpWebResponse GetResponseOnMessage( ClientMessage msg ) {
			try {
				HttpWebRequest web_request;
				
				string xml_message = msg.ToXml();
				byte[] xml_bytes = Encoding.UTF8.GetBytes( xml_message );
				
				web_request = (HttpWebRequest)WebRequest.Create("http://"+server_ip);
				web_request.Credentials = CredentialCache.DefaultCredentials;
				web_request.UserAgent = "TestAgent";
				web_request.Method = "POST";
				web_request.KeepAlive = true;
				web_request.ContentLength = xml_bytes.Length;
				var hw_stream = web_request.GetRequestStream();
				hw_stream.Write( xml_bytes, 0, xml_bytes.Length );
				hw_stream.Close();
				
				return (HttpWebResponse)web_request.GetResponse();
			} catch ( Exception ex ) {
				MessageBox.Show("Ошибка отсылки запроса на сервер: "+ex.Message);
			}
			return null;
		}
		
	}
}
