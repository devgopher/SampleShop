/*
 * Пользователь: Igor
 * Дата: 28.02.2016
 * Время: 13:17
 */
using System;
using System.Data;


namespace SampleShopServer
{
	/// <summary>
	/// Processing client messages
	/// </summary>
	public static class MessageProcessing
	{
		private static Logger.Logger logger =
			Logger.Logger.GetInstance();
		
		private static DataTable SelectShopsList( ClientMessage msg ) {
			string query = "SELECT id shop_id, \"Name\" shop_name, \"Phone\" shop_phone, " +
				"\"Address\" shop_address, \"Email\" shop_email" +
				" FROM \"Shops\"";
			
			try {
				var dbint = new Model.DatabaseInteraction();
				dbint.Connection.Open();
				var ds = dbint.ExecuteSelect( query );
				
				if ( ds.Tables.Count > 0 ) {
					dbint.Connection.Close();
					return ds.Tables[0];
				} else
					dbint.Connection.Close();
				
			} catch ( Exception ex ) {
				logger.WriteError( "Error while selecting record: "+ex.Message );
			}
			return null;
		}
		
		private static DataTable SelectGoodsList( ClientMessage msg ) {
			string query = "SELECT gds.id good_id, gds.\"Name\" good_name, "+
				" sps.\"Name\" shop_name, gis.\"Count\" good_count, sps.id shop_id"+
				" FROM \"GoodsInShops\" gis, \"Goods\" gds, \"Shops\" sps " +
				" WHERE gis.\"Good_id\" = gds.id AND " +
				" gis.\"Shop_id\" = sps.id";
			
			try {
				var dbint = new Model.DatabaseInteraction();
				dbint.Connection.Open();
				var ds = dbint.ExecuteSelect( query );
				
				if ( ds.Tables.Count > 0 ) {
					dbint.Connection.Close();
					return ds.Tables[0];
				} else
					dbint.Connection.Close();
				
			} catch ( Exception ex ) {
				logger.WriteError( "Error while selecting record: "+ex.Message );
			}
			return null;
		}
		
		private static bool UpdateGoodsCountRequest( ClientMessage msg ) {
			string query = "UPDATE \"GoodsInShops\"  SET " +
				"\"Count\"='"+msg.Contents["quantity"]+"'" +
				" WHERE \"Shop_id\" = "+msg.Contents["shop_id"] +
				" AND \"Good_id\" = "+msg.Contents["good_id"];
			
			var dbint = new Model.DatabaseInteraction();
			dbint.Connection.Open();
			var transaction = dbint.BeginTransaction();
			
			try {
				var succ = dbint.ExecuteModify( query, transaction );
				dbint.CommitTransaction( transaction );
				dbint.Connection.Close();
				return succ;
			} catch ( Exception ex ) {
				logger.WriteError( "Error while updating a record: "+ex.Message );
				dbint.RollbackTransaction( transaction );
			}
			return false;
		}

		private static bool UpdateShopRequest( ClientMessage msg ) {
			string query = "UPDATE \"Shops\"  SET " +
				"\"Name\"='"+msg.Contents["shop_name"]+"', " +
				"\"Phone\"='"+msg.Contents["shop_phone"]+"', " +
				"\"Address\"='"+msg.Contents["shop_address"]+"'," +
				"\"Email\"='"+msg.Contents["shop_email"]+
				" WHERE id = "+msg.Contents["shop_id"];
			
			var dbint = new Model.DatabaseInteraction();
			dbint.Connection.Open();
			var transaction = dbint.BeginTransaction();
			
			try {
				var succ = dbint.ExecuteModify( query, transaction );
				dbint.CommitTransaction( transaction );
				dbint.Connection.Close();
				return succ;
			} catch ( Exception ex ) {
				logger.WriteError( "Error while adding a new shop: "+ex.Message );
				dbint.RollbackTransaction( transaction );
			}
			return false;
		}
		
		private static Int64 AddShopRequest( ClientMessage msg ) {
			Int64 ret_new_id = 0;
			string query = "INSERT INTO \"Shops\"( "+
				"id, \"Name\", \"Phone\", \"Address\", \"Email\")"+
				"VALUES ((SELECT max(id) + 1 FROM \"Shops\"), "+
				"'"+msg.Contents["shop_name"]+"', " +
				"'"+msg.Contents["shop_phone"]+"', " +
				"'"+msg.Contents["shop_address"]+"'," +
				"'"+msg.Contents["shop_email"]+"')";
			
			var dbint = new Model.DatabaseInteraction();
			dbint.Connection.Open();
			var transaction = dbint.BeginTransaction();
			
			try {
				var succ = dbint.ExecuteModify( query, transaction );
				if ( succ )
					ret_new_id = dbint.GetLastId( "Shops", transaction );
				else {
					dbint.RollbackTransaction( transaction );
					logger.WriteError("Error while modifying data occured!");
				}
				dbint.CommitTransaction( transaction );
				dbint.Connection.Close();
			} catch ( Exception ex ) {
				logger.WriteError( "Error while adding a new shop: "+ex.Message );
				dbint.RollbackTransaction( transaction );
			}
			
			return ret_new_id;
		}
		
		public static ServerMessage ProcessMessage( ClientMessage msg ) {
			try {
				DataTable process_dt = null;
				ServerMessage resp_msg = new ServerMessage();
				
				switch( msg.Type ) {
					case Protocol.add_shop:
						Int64 new_shop_id = AddShopRequest( msg );
						resp_msg.Type = Protocol.common_response;
						resp_msg.AddItem()["shop_id"] = new_shop_id.ToString();
						return resp_msg;
					case Protocol.change_quantity:
						resp_msg = ResponseMessage( UpdateGoodsCountRequest( msg ) );						
						return resp_msg;
					case Protocol.mod_shop:
						resp_msg = ResponseMessage( UpdateShopRequest( msg ) );
						return resp_msg;
					case Protocol.get_shop_list:
						process_dt = SelectShopsList( msg );
						break;
					case Protocol.get_good_list:
						process_dt = SelectGoodsList( msg );
						break;
				}
				
				if ( process_dt != null ) {
					resp_msg = ResponseMessage( process_dt );
				}
				return resp_msg;
			} catch ( Exception ex ) {
				logger.WriteError("Error in message processing: "+ex.Message);
			}
			return null;
		}
		
		public static ServerMessage ResponseMessage( bool success ) {
			ServerMessage resp_msg = new ServerMessage();
			resp_msg.Type = Protocol.success_response;
			resp_msg.AddItem()["result"] = success.ToString();			
			return resp_msg;
		}
		
		public static ServerMessage ResponseMessage( DataTable input_dt ) {
			ServerMessage resp_msg = new ServerMessage();
			resp_msg.Type = Protocol.common_response;
			
			foreach ( DataRow row in input_dt.Rows ) {
				var item_dict = resp_msg.AddItem();
				foreach ( DataColumn col in input_dt.Columns ) {
					item_dict[col.ColumnName] = row[col].ToString();
				}
			}
			
			return resp_msg;
		}
	}
}
