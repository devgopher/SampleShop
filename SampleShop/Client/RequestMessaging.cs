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
		private const int max_ba_length = 1048576;
		
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
			resp_stream.Read( rec_bytes, 0, (int)response.ContentLength );
			return Encoding.UTF8.GetString( rec_bytes );
		}
		
		/// <summary>
		/// Converts server response text to a ServerMessage object
		/// </summary>
		/// <param name="contents">A text of response</param>
		/// <returns>ServerMessage</returns>
		private static ServerMessage ProcessResponseText( string contents ) {
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
		/// <param name="timeout">Timeout, sec</param>
		/// <returns>Server response</returns>
		private static HttpWebResponse GetResponse( HttpWebRequest web_request, int timeout = 20 ) {
			DateTime dt_now = DateTime.Now;
			while (!web_request.HaveResponse) {
				if ( (DateTime.Now - dt_now).TotalSeconds >= timeout ) {
					throw new SampleShopClientException( "Timeout expired while waiting for a server response! " );
				}
			}
			return (HttpWebResponse)web_request.GetResponse();
		}
	}
}
