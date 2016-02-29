﻿/*
 * Пользователь: Igor
 * Дата: 28.02.2016
 * Время: 22:25
 */
using System;
using System.Xml;
using System.Collections.Generic;

namespace SampleShopServer
{
	public class ServerMessage : Message
	{
		public List<Dictionary<string, string>> Contents =
			new List<Dictionary<string, string>>();
		
		public Dictionary<string, string> AddItem() {
			var new_item_dict = new Dictionary<string, string>();
			Contents.Add( new_item_dict );
			return new_item_dict;
		}
		
		/// <summary>
		/// Parses an XML document into a "Message" object
		/// </summary>
		/// <param name="in_contents"></param>
		public override void FromXML( string in_contents ) {
			try {
				XmlDocument doc = new XmlDocument();
				doc.LoadXml( in_contents );
				
				var root_element = doc.DocumentElement;
				
				Contents.Clear();
				
				XmlNode item_node = null;
				
				Dictionary<string, string> item_dict = null;
				
				foreach( XmlNode node in root_element.ChildNodes ) {
					if ( node.Name == "type" ) {
						Type = node.InnerText;
					}
					
					if ( node.Name == "item" ) {
						item_node = node;
						item_dict = new Dictionary<string, string>();
						Contents.Add( item_dict );
						break;
					}
					
					if ( node.Name == "field" && item_node != null && item_dict != null) {
						// seeking for attributes
						var node_attrs = node.Attributes;
						if (  node_attrs != null ) {
							// filling Contents dictionary
							if (node_attrs["field_name"] != null && node.InnerText != null )
								item_dict[node_attrs["field_name"].Value] = node.InnerText;
						}
					}
				}
			} catch ( XmlException xe ) {
				Logger.Logger
					.GetInstance()
					.WriteError("Error in XML parsing: "+xe.Message+": line "+xe.LinePosition);
			}
		}
		
		/// <summary>
		/// Converts a message into XML document
		/// </summary>
		/// <returns></returns>
		public override string ToXml() {
			XmlDocument new_xml = new XmlDocument();
			var root_elem = new_xml.CreateElement("root");
			string ret = String.Empty;
			
			XmlElement type = new_xml.CreateElement("type");
			type.InnerText = Type;
			root_elem.AppendChild( type );
			
			foreach ( var item_dict in Contents ) {
				XmlElement item = new_xml.CreateElement("item");
				foreach ( var key in item_dict.Keys ) {
					XmlElement chld = new_xml.CreateElement("field");
					
					var fld_name_attr = new_xml.CreateAttribute( "field_name" );
					fld_name_attr.Value = key;
					
					chld.Attributes.Append( fld_name_attr );
					chld.InnerText = item_dict[key];
					item.AppendChild( chld );
				}
				
				root_elem.AppendChild( item );
			}
			
			ret = root_elem.OuterXml;
			
			return ret;
		}
		
		public ServerMessage() {
			
		}
	}
}
