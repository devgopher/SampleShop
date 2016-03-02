/*
 * Пользователь: Igor
 * Дата: 29.02.2016
 * Время: 23:43
 */
using System;
using System.Net;
using System.Text;
using System.IO;
using SampleShopServer;

namespace SampleShopClient
{
	/// <summary>
	/// A class for sending/receiving messages of Message
	/// </summary>
	public static class RequestMessaging
	{
		private static string server_ip =
			CommonSettings.Config.AppSettings.Settings["server_ip"].Value;
		private const int max_ba_length = 100000;
		
		/// <summary>
		/// A method for sending of the client message and receiving server message
		/// </summary>
		/// <param name="msg">Client message</param>
		/// <returns>Server message</returns>
		public static ServerMessage Process( ClientMessage msg )  {
			var request = SendRequest( msg );
			var response = GetResponse( request );
			if ( response != null ) {
				string response_text = GetResponseText( response );
				return RequestMessaging.ProcessResponseText( response_text );
			} else
				throw new SampleShopClientException( " Can't get a server response! " );
		}
		
		/// <summary>
		/// Gets a body of HttpWebResponse
		/// </summary>
		/// <param name="response">Server response</param>
		/// <returns>Text</returns>
		private static string GetResponseText( HttpWebResponse response ) {
			var resp_stream = response.GetResponseStream();
			var rec_bytes = new byte[max_ba_length];
			string ret = String.Empty;

			while (resp_stream.Read( rec_bytes, 0, 10000 ) > 0 ) {
				ret += Encoding.UTF8.GetString( rec_bytes );
			}
			return ret.Replace("\0","");
		}
		
		/// <summary>
		/// Converts server response text to a ServerMessage object
		/// </summary>
		/// <param name="contents">A text of response</param>
		/// <returns>ServerMessage</returns>
		private static ServerMessage ProcessResponseText( string contents ) {
			if ( contents != String.Empty )
				System.Windows.Forms.Clipboard.SetText( contents );
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
		
		/// <summary>
		/// Sends a message to a server
		/// </summary>
		/// <param name="msg">Client message</param>
		/// <returns>Web request</returns>
		private static HttpWebRequest SendRequest( ClientMessage msg ) {
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
				
				return web_request;
			} catch ( Exception ex ) {
				throw new SampleShopClientException("Ошибка отсылки запроса на сервер: "+ex.Message, ex);
			}
		}
		
		/// <summary>
		/// Get's an answer from a server
		/// </summary>
		/// <param name="web_request">Request</param>
		/// <returns>Server response</returns>
		private static HttpWebResponse GetResponse( HttpWebRequest web_request ) {
			return (HttpWebResponse)web_request.GetResponse();
		}
	}
}
