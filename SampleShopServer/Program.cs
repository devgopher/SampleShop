/*
 * Пользователь: igor.evdokimov
 * Дата: 11.11.2015
 * Время: 12:15
 */
using System;

namespace SampleShopServer
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("SampleShop server starting...");

            var server = new Server.Server();
            server.Start();

			// TODO: Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}