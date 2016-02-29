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
	public class RequestMessaging
	{
		private string server_ip =
			Settings.config.AppSettings.Settings["server_ip"].Value;
		
		private ServerMessage ProcessRequest( string request_contents ) {
			if ( request_contents.Contains("<root>") &&
			    request_contents.Contains("</root>"))
			{
				var start_xml = request_contents.IndexOf("<root>");
				var length = request_contents.IndexOf("</root>")+7-
					request_contents.IndexOf("<root>");
				var xml = request_contents.Substring( start_xml, length );
				
				ServerMessage msg = new ServerMessage();
				msg.FromXML( xml );
				return msg;
			}
			return null;
		}
		
		public HttpWebResponse MakeRequest( SampleShopServer.Message msg ) {
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
