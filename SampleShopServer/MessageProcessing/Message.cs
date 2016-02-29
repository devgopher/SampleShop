/*
 * Пользователь: Igor
 * Дата: 28.02.2016
 * Время: 22:22
 */
using System;

namespace SampleShopServer
{
	public abstract class Message {
		public string Type {
			get; set;
		}
		
		public abstract void FromXML( string in_contents );
		public abstract string ToXml();
	}
}
