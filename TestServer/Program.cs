/*
 * Пользователь: Igor
 * Дата: 28.02.2016
 * Время: 11:34
 */
using System;

namespace TestServer
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Input an ip-address wuth port: ");
			
			string ip_addr = Console.ReadLine();
			
			TestProc.TestMessageSendReceive( ip_addr );
			TestProc.TestMessageSendReceive( ip_addr );
			TestProc.TestQuery();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}