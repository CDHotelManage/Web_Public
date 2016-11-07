using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:room_type
	/// </summary>
	public partial class room_type
	{
		public room_type()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CdHotelManage.Model.room_type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into room_type(");
            strSql.Append("room_number,room_name,room_hour,room_listedmoney,room_zmmoney,room_hourmation,room_reamker,room_image,room_ealry_price,room_Moth_price,room_Bfb)");
			strSql.Append(" values (");
            strSql.Append("@room_number,@room_name,@room_hour,@room_listedmoney,@room_zmmoney,@room_hourmation,@room_reamker,@room_image,@room_ealry_price,@room_Moth_price,@room_Bfb)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@room_number", SqlDbType.NVarChar,50),
					new SqlParameter("@room_name", SqlDbType.NVarChar,50),
					new SqlParameter("@room_hour", SqlDbType.NVarChar,50),
					new SqlParameter("@room_listedmoney", SqlDbType.Money,8),
					new SqlParameter("@room_zmmoney", SqlDbType.Money,8),
					new SqlParameter("@room_hourmation", SqlDbType.NVarChar,200),
					new SqlParameter("@room_reamker", SqlDbType.NVarChar,200),
                    new SqlParameter("@room_image", SqlDbType.NVarChar,200),
					new SqlParameter("@room_ealry_price", SqlDbType.Money,8) ,
                   	new SqlParameter("@room_Moth_price", SqlDbType.Money,8),
                                        	new SqlParameter("@room_Bfb", SqlDbType.Int,4)
                                        };
			parameters[0].Value = model.room_number;
			parameters[1].Value = model.room_name;
			parameters[2].Value = model.room_hour;
			parameters[3].Value = model.room_listedmoney;
			parameters[4].Value = model.room_zmmoney;
			parameters[5].Value = model.room_hourmation;
			parameters[6].Value = model.room_reamker;
            parameters[7].Value = model.room_image;
            parameters[8].Value = model.Room_ealry_price;
            parameters[9].Value = model.Room_Moth_price;
            parameters[10].Value = model.Room_Bfb;
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
		public bool Update(CdHotelManage.Model.room_type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update room_type set ");
			strSql.Append("room_number=@room_number,");
			strSql.Append("room_name=@room_name,");
			strSql.Append("room_hour=@room_hour,");
			strSql.Append("room_listedmoney=@room_listedmoney,");
			strSql.Append("room_zmmoney=@room_zmmoney,");
			strSql.Append("room_hourmation=@room_hourmation,");
			strSql.Append("room_reamker=@room_reamker,");
            strSql.Append("room_image=@room_image,");
            strSql.Append("room_ealry_price=@room_ealry_price,");
            strSql.Append("room_Moth_price=@room_Moth_price,");
            strSql.Append("room_Bfb=@room_Bfb");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@room_number", SqlDbType.NVarChar,50),
					new SqlParameter("@room_name", SqlDbType.NVarChar,50),
					new SqlParameter("@room_hour", SqlDbType.NVarChar,50),
					new SqlParameter("@room_listedmoney", SqlDbType.Money,8),
					new SqlParameter("@room_zmmoney", SqlDbType.Money,8),
					new SqlParameter("@room_hourmation", SqlDbType.NVarChar,200),
					new SqlParameter("@room_reamker", SqlDbType.NVarChar,200),
                    new SqlParameter("@room_image", SqlDbType.NVarChar,200),
                    new SqlParameter("@room_ealry_price", SqlDbType.Money,8),
                    new SqlParameter("@room_Moth_price", SqlDbType.Money,8),
                    new SqlParameter("@room_Bfb", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.room_number;
			parameters[1].Value = model.room_name;
			parameters[2].Value = model.room_hour;
			parameters[3].Value = model.room_listedmoney;
			parameters[4].Value = model.room_zmmoney;
			parameters[5].Value = model.room_hourmation;
			parameters[6].Value = model.room_reamker;
            parameters[7].Value = model.room_image;
            parameters[8].Value = model.Room_ealry_price;
            parameters[9].Value = model.Room_Moth_price;
            parameters[10].Value = model.Room_Bfb;
			parameters[11].Value = model.id;

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
			strSql.Append("delete from room_type ");
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
			strSql.Append("delete from room_type ");
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

        public DataSet GetBookRoomPager(string sort, string order, int currentPage, int pageSize, string strWhere)
        {
            string _sql = @" select * from (select *,Row_number() over(order by " + sort + " " + order + ") as IDBookRoom from room_type " + strWhere + ") as IDWithRowNumber where IDBookRoom>=(" + currentPage + "-1)*" + pageSize + "+1 and IDBookRoom<=" + currentPage + "*" + pageSize + "";
            return DbHelperSQL.Query(_sql);
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.room_type GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,room_number,room_name,room_hour,room_listedmoney,room_zmmoney,room_hourmation,room_reamker,room_image,room_ealry_price,room_Moth_price,room_Bfb from room_type ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			CdHotelManage.Model.room_type model=new CdHotelManage.Model.room_type();
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
		public CdHotelManage.Model.room_type DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.room_type model=new CdHotelManage.Model.room_type();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["room_number"]!=null)
				{
					model.room_number=row["room_number"].ToString();
				}
				if(row["room_name"]!=null)
				{
					model.room_name=row["room_name"].ToString();
				}
				if(row["room_hour"]!=null)
				{
					model.room_hour=row["room_hour"].ToString();
				}
				if(row["room_listedmoney"]!=null && row["room_listedmoney"].ToString()!="")
				{
                    model.room_listedmoney = decimal.Parse(row["room_listedmoney"].ToString());
				}
				if(row["room_zmmoney"]!=null && row["room_zmmoney"].ToString()!="")
				{
					model.room_zmmoney=decimal.Parse(row["room_zmmoney"].ToString());
				}
				if(row["room_hourmation"]!=null)
				{
					model.room_hourmation=row["room_hourmation"].ToString();
				}
				if(row["room_reamker"]!=null)
				{
					model.room_reamker=row["room_reamker"].ToString();
				}
                if (row["room_image"] != null)
                {
                    model.room_image = row["room_image"].ToString();
                }
                if (row["room_ealry_price"] != null && row["room_ealry_price"].ToString() != "")
                {
                    model.Room_ealry_price = decimal.Parse(row["room_ealry_price"].ToString());
                }
                if (row["room_Moth_price"] != null && row["room_Moth_price"].ToString() != "")
                {
                    model.Room_Moth_price = decimal.Parse(row["room_Moth_price"].ToString());
                }
                if (row["room_Bfb"] != null && row["room_Bfb"].ToString() != "")
                {
                    model.Room_Bfb = Convert.ToInt32(row["room_Bfb"].ToString());
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
            strSql.Append("select id,room_number,room_name,room_hour,room_listedmoney,room_zmmoney,room_hourmation,room_reamker,room_image,room_ealry_price,room_Moth_price,room_Bfb ");
			strSql.Append(" FROM room_type ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetLists(string strWhere, string joins)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,room_number,room_name,room_hour,room_listedmoney,room_zmmoney,room_hourmation,room_reamker,room_image,room_ealry_price,room_Moth_price,room_Bfb ");
            strSql.Append(" FROM room_type "+joins);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            strSql.Append(" id,room_number,room_name,room_hour,room_listedmoney,room_zmmoney,room_hourmation,room_reamker,room_image,room_ealry_price,room_Bfb ");
			strSql.Append(" FROM room_type ");
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
			strSql.Append("select count(1) FROM room_type ");
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
			strSql.Append(")AS Row, T.*  from room_type T ");
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
			parameters[0].Value = "room_type";
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

