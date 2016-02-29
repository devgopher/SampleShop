/*
 * Пользователь: Igor
 * Дата: 27.02.2016
 * Время: 22:13
 */
using System;
using Npgsql;
using System.Data;

namespace SampleShopServer.Model
{
	/// <summary>
	/// Description of Database.
	/// </summary>
	public class DatabaseInteraction
	{
		private readonly string db_name = "SampleShop";
		private readonly string rdms_address = "127.0.0.1";
		private readonly string user = "shop_server";
		private readonly string password = "12345678";
		private NpgsqlConnection _connection = null;
		private readonly Logger.Logger logger = Logger.Logger.GetInstance();
		
		public DatabaseInteraction()
		{
		}
		
		private NpgsqlConnection CreateConn() {
			var conn_str = @"User ID="+user+";Password="+password+";"+
				"Host="+rdms_address+";Port=5432;"+
				"Database="+db_name+";Timeout=1024;";
			
			try {
				var conn = new NpgsqlConnection( conn_str );
				return conn;
			} catch ( NpgsqlException ex ) {
				logger.WriteError( "Error creating a connection: "+ex.Message );
			}
			
			return null;
		}
		
		public NpgsqlConnection Connection {
			get {
				if ( _connection == null )
					_connection = CreateConn();
				return _connection;
			}
		}
		
		public IDbTransaction BeginTransaction() {
			return Connection.BeginTransaction();
		}

		public void CommitTransaction( IDbTransaction tr ) {
			tr.Commit();
		}
		
		public void RollbackTransaction( IDbTransaction tr ) {
			tr.Rollback();
		}
		
		public DataSet ExecuteSelect( string query, IDbTransaction tr = null ) {
			DataSet ret_ds = new DataSet();
			try {
				NpgsqlCommand cmd = new NpgsqlCommand( query, Connection, (NpgsqlTransaction)tr );
				NpgsqlDataAdapter nda = new NpgsqlDataAdapter( cmd );
				nda.Fill( ret_ds );
			} catch ( NpgsqlException ex ) {
				logger.WriteError( "Error executing a query: "+ex.Message );
			}
			
			return ret_ds;
		}
		
		public bool ExecuteModify( string query, IDbTransaction tr = null ) {
			try {
				NpgsqlCommand cmd = new NpgsqlCommand( query, Connection, (NpgsqlTransaction)tr );
				int ret_cnt = cmd.ExecuteNonQuery();
				return ret_cnt > 0;
			} catch ( NpgsqlException ex ) {
				logger.WriteError( "Error executing a query: "+ex.Message );
			}
			return false;
		}
		
		public Int64 GetLastId( string table_name,
		                       IDbTransaction tr ) {
			try {
				var query =	"SELECT MAX(id) FROM \""+
					table_name+"\"";
				
				var rt_dataset = ExecuteSelect( query, tr );
				
				if ( rt_dataset.Tables.Count > 0 ) {
					if ( rt_dataset.Tables[0].Rows.Count > 0 ) {
						var ret_val = rt_dataset.Tables[0].Rows[0][0].ToString();
						return Int64.Parse( ret_val );
					}
				}
			} catch ( NpgsqlException ex ) {
				logger.WriteError( "Error executing a query: "+ex.Message );
			}
			return 0;
		}
	}
}
