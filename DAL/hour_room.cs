using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:hour_room
	/// </summary>
	public partial class hour_room
	{
		public hour_room()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "hour_room"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from hour_room");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CdHotelManage.Model.hour_room model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into hour_room(");
            strSql.Append("hs_room_id,hs_name,hs_start_long,hs_start_price,hs_add_time,hs_add_price,hs_min_time,hs_min_price,hs_max_time,hs_type_id,hs_jgtype_id,hs_source_id,lostTime,MtID)");
			strSql.Append(" values (");
            strSql.Append("@hs_room_id,@hs_name,@hs_start_long,@hs_start_price,@hs_add_time,@hs_add_price,@hs_min_time,@hs_min_price,@hs_max_time,@hs_type_id,@hs_jgtype_id,@hs_source_id,@lostTime,@MtID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@hs_room_id", SqlDbType.Int,4),
					new SqlParameter("@hs_name", SqlDbType.NVarChar,50),
					new SqlParameter("@hs_start_long", SqlDbType.NVarChar,20),
					new SqlParameter("@hs_start_price", SqlDbType.Money,8),
					new SqlParameter("@hs_add_time", SqlDbType.NVarChar,20),
					new SqlParameter("@hs_add_price", SqlDbType.Money,8),
					new SqlParameter("@hs_min_time", SqlDbType.NVarChar,20),
					new SqlParameter("@hs_min_price", SqlDbType.Money,8),
					new SqlParameter("@hs_max_time", SqlDbType.NVarChar,20),
					new SqlParameter("@hs_type_id", SqlDbType.Int,4),
					new SqlParameter("@hs_jgtype_id", SqlDbType.Int,4),
					new SqlParameter("@hs_source_id", SqlDbType.Int,4),
                                        new SqlParameter("@lostTime", SqlDbType.Time,4),
                                        new SqlParameter("@MtID",SqlDbType.Int,4)
                                        };
			parameters[0].Value = model.hs_room_id;
			parameters[1].Value = model.hs_name;
			parameters[2].Value = model.hs_start_long;
			parameters[3].Value = model.hs_start_price;
			parameters[4].Value = model.hs_add_time;
			parameters[5].Value = model.hs_add_price;
			parameters[6].Value = model.hs_min_time;
			parameters[7].Value = model.hs_min_price;
			parameters[8].Value = model.hs_max_time;
			parameters[9].Value = model.hs_type_id;
			parameters[10].Value = model.hs_jgtype_id;
			parameters[11].Value = model.hs_source_id;
            parameters[12].Value = model.LostTime;
            parameters[13].Value = model.MtID;
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CdHotelManage.Model.hour_room model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update hour_room set ");
			strSql.Append("hs_room_id=@hs_room_id,");
			strSql.Append("hs_name=@hs_name,");
			strSql.Append("hs_start_long=@hs_start_long,");
			strSql.Append("hs_start_price=@hs_start_price,");
			strSql.Append("hs_add_time=@hs_add_time,");
			strSql.Append("hs_add_price=@hs_add_price,");
			strSql.Append("hs_min_time=@hs_min_time,");
			strSql.Append("hs_min_price=@hs_min_price,");
			strSql.Append("hs_max_time=@hs_max_time,");
			strSql.Append("hs_type_id=@hs_type_id,");
			strSql.Append("hs_jgtype_id=@hs_jgtype_id,");
			strSql.Append("hs_source_id=@hs_source_id,");
            strSql.Append("lostTime=@lostTime,");
            strSql.Append("MtID=@MtID");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@hs_room_id", SqlDbType.Int,4),
					new SqlParameter("@hs_name", SqlDbType.NVarChar,50),
					new SqlParameter("@hs_start_long", SqlDbType.NVarChar,20),
					new SqlParameter("@hs_start_price", SqlDbType.Money,8),
					new SqlParameter("@hs_add_time", SqlDbType.NVarChar,20),
					new SqlParameter("@hs_add_price", SqlDbType.Money,8),
					new SqlParameter("@hs_min_time", SqlDbType.NVarChar,20),
					new SqlParameter("@hs_min_price", SqlDbType.Money,8),
					new SqlParameter("@hs_max_time", SqlDbType.NVarChar,20),
					new SqlParameter("@hs_type_id", SqlDbType.Int,4),
					new SqlParameter("@hs_jgtype_id", SqlDbType.Int,4),
					new SqlParameter("@hs_source_id", SqlDbType.Int,4),
                    new SqlParameter("@lostTime", SqlDbType.Time,4),
                    new SqlParameter("@MtID",SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.hs_room_id;
			parameters[1].Value = model.hs_name;
			parameters[2].Value = model.hs_start_long;
			parameters[3].Value = model.hs_start_price;
			parameters[4].Value = model.hs_add_time;
			parameters[5].Value = model.hs_add_price;
			parameters[6].Value = model.hs_min_time;
			parameters[7].Value = model.hs_min_price;
			parameters[8].Value = model.hs_max_time;
			parameters[9].Value = model.hs_type_id;
			parameters[10].Value = model.hs_jgtype_id;
			parameters[11].Value = model.hs_source_id;
            parameters[12].Value = model.LostTime;
            parameters[13].Value = model.MtID;
			parameters[14].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from hour_room ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from hour_room ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.hour_room GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,hs_room_id,hs_name,hs_start_long,hs_start_price,hs_add_time,hs_add_price,hs_min_time,hs_min_price,hs_max_time,hs_type_id,hs_jgtype_id,hs_source_id,lostTime,MtID from hour_room ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			CdHotelManage.Model.hour_room model=new CdHotelManage.Model.hour_room();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.hour_room DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.hour_room model=new CdHotelManage.Model.hour_room();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["hs_room_id"]!=null && row["hs_room_id"].ToString()!="")
				{
					model.hs_room_id=int.Parse(row["hs_room_id"].ToString());
				}
				if(row["hs_name"]!=null)
				{
					model.hs_name=row["hs_name"].ToString();
				}
				if(row["hs_start_long"]!=null)
				{
					model.hs_start_long=row["hs_start_long"].ToString();
				}
				if(row["hs_start_price"]!=null && row["hs_start_price"].ToString()!="")
				{
					model.hs_start_price=decimal.Parse(row["hs_start_price"].ToString());
				}
				if(row["hs_add_time"]!=null)
				{
					model.hs_add_time=row["hs_add_time"].ToString();
				}
				if(row["hs_add_price"]!=null && row["hs_add_price"].ToString()!="")
				{
					model.hs_add_price=decimal.Parse(row["hs_add_price"].ToString());
				}
				if(row["hs_min_time"]!=null)
				{
					model.hs_min_time=row["hs_min_time"].ToString();
				}
				if(row["hs_min_price"]!=null && row["hs_min_price"].ToString()!="")
				{
					model.hs_min_price=decimal.Parse(row["hs_min_price"].ToString());
				}
				if(row["hs_max_time"]!=null)
				{
					model.hs_max_time=row["hs_max_time"].ToString();
				}
				if(row["hs_type_id"]!=null && row["hs_type_id"].ToString()!="")
				{
					model.hs_type_id=int.Parse(row["hs_type_id"].ToString());
				}
				if(row["hs_jgtype_id"]!=null && row["hs_jgtype_id"].ToString()!="")
				{
					model.hs_jgtype_id=int.Parse(row["hs_jgtype_id"].ToString());
				}
				if(row["hs_source_id"]!=null && row["hs_source_id"].ToString()!="")
				{
					model.hs_source_id=int.Parse(row["hs_source_id"].ToString());
				}
                if (row["lostTime"] != null && row["lostTime"].ToString() != "")
                {
                    model.LostTime = TimeSpan.Parse(row["lostTime"].ToString());
                }
                if (row["MtID"] != null && row["MtID"].ToString() != "")
                {
                    model.MtID = Convert.ToInt32(row["MtID"].ToString());
                }
                
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,hs_room_id,hs_name,hs_start_long,hs_start_price,hs_add_time,hs_add_price,hs_min_time,hs_min_price,hs_max_time,hs_type_id,hs_jgtype_id,hs_source_id,lostTime,MtID ");
			strSql.Append(" FROM hour_room ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" id,hs_room_id,hs_name,hs_start_long,hs_start_price,hs_add_time,hs_add_price,hs_min_time,hs_min_price,hs_max_time,hs_type_id,hs_jgtype_id,hs_source_id,lostTime,MtID ");
			strSql.Append(" FROM hour_room ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM hour_room ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from hour_room T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "hour_room";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

