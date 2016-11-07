using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:room_number
	/// </summary>
	public partial class room_number
	{
		public room_number()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "room_number"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from room_number");
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
		public int Add(CdHotelManage.Model.room_number model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into room_number(");
            strSql.Append("Rn_flloeld,Rn_floor,Rn_roomNum,Rn_state,Rn_room,Rn_Type,Rn_price,Rn_remaker,Room_suod,Rn_Tobe,Rn_suo)");
			strSql.Append(" values (");
            strSql.Append("@Rn_flloeld,@Rn_floor,@Rn_roomNum,@Rn_state,@Rn_room,@Rn_Type,@Rn_price,@Rn_remaker,@Room_suod,@Rn_Tobe,@Rn_suo)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
                   new SqlParameter("@Rn_flloeld", SqlDbType.NVarChar,50),
					new SqlParameter("@Rn_floor", SqlDbType.NVarChar,10),
					new SqlParameter("@Rn_roomNum", SqlDbType.NVarChar,20),
					new SqlParameter("@Rn_state", SqlDbType.Int,4),
					new SqlParameter("@Rn_room", SqlDbType.NVarChar,50),
					new SqlParameter("@Rn_Type", SqlDbType.Int,4),
					new SqlParameter("@Rn_price", SqlDbType.Money,4),
					new SqlParameter("@Rn_remaker", SqlDbType.NVarChar,-1),
                    new SqlParameter("@Room_suod", SqlDbType.Char,10),
                    new SqlParameter("@Rn_Tobe", SqlDbType.Int,4),
                    new SqlParameter("@Rn_suo",SqlDbType.NVarChar,50)
                                        };

            parameters[0].Value = model.Rn_flloeld;
			parameters[1].Value = model.Rn_floor;
			parameters[2].Value = model.Rn_roomNum;
			parameters[3].Value = model.Rn_state;
			parameters[4].Value = model.Rn_room;
			parameters[5].Value = model.Rn_Type;
			parameters[6].Value = model.Rn_price;
            parameters[7].Value = model.Rn_remaker;
            parameters[8].Value = model.Room_suod;
            parameters[9].Value = model.Rn_Tobe;
            parameters[10].Value = model.Rn_suo;
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
		public bool Update(CdHotelManage.Model.room_number model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update room_number set ");
            strSql.Append("Rn_flloeld=@Rn_flloeld,");
			strSql.Append("Rn_floor=@Rn_floor,");
			strSql.Append("Rn_roomNum=@Rn_roomNum,");
			strSql.Append("Rn_state=@Rn_state,");
			strSql.Append("Rn_room=@Rn_room,");
			strSql.Append("Rn_Type=@Rn_Type,");
			strSql.Append("Rn_price=@Rn_price,");
			strSql.Append("Rn_remaker=@Rn_remaker,");
            strSql.Append("Room_suod=@Room_suod,");
            strSql.Append("Rn_Tobe=@Rn_Tobe,");
            strSql.Append("Rn_suo=@Rn_suo");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
                    new SqlParameter("@Rn_flloeld", SqlDbType.NVarChar,50),
					new SqlParameter("@Rn_floor", SqlDbType.NVarChar,10),
					new SqlParameter("@Rn_roomNum", SqlDbType.NVarChar,20),
					new SqlParameter("@Rn_state", SqlDbType.Int,4),
					new SqlParameter("@Rn_room", SqlDbType.NVarChar,50),
					new SqlParameter("@Rn_Type", SqlDbType.Int,4),
					new SqlParameter("@Rn_price", SqlDbType.Money,4),
					new SqlParameter("@Rn_remaker", SqlDbType.NVarChar,-1),
                    new SqlParameter("@Room_suod", SqlDbType.Char,10),
                    new SqlParameter("@Rn_Tobe", SqlDbType.Int,4),
                     new SqlParameter("@Rn_suo",SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.Rn_flloeld;
			parameters[1].Value = model.Rn_floor;
			parameters[2].Value = model.Rn_roomNum;
			parameters[3].Value = model.Rn_state;
			parameters[4].Value = model.Rn_room;
			parameters[5].Value = model.Rn_Type;
			parameters[6].Value = model.Rn_price;
			parameters[7].Value = model.Rn_remaker;
            parameters[8].Value = model.Room_suod;
            parameters[9].Value = model.Rn_Tobe;
            parameters[10].Value = model.Rn_suo;
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
        /// 更新一条数据2
        /// </summary>
        public bool Updates(string SQL)
        {
            SqlParameter[] parameters = null;
            int rows = DbHelperSQL.ExecuteSql(SQL, parameters);
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
			strSql.Append("delete from room_number ");
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
			strSql.Append("delete from room_number ");
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
		public CdHotelManage.Model.room_number GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,Rn_flloeld,Rn_floor,Rn_roomNum,Rn_state,Rn_room,Rn_Type,Rn_price,Rn_remaker,Room_suod,Rn_Tobe,Rn_suo from room_number ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			CdHotelManage.Model.room_number model=new CdHotelManage.Model.room_number();
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
        /// 得到一个对象实体2
        /// </summary>
        public CdHotelManage.Model.room_number GetModel(int id, string TabCell)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,Rn_flloeld,Rn_floor,Rn_roomNum,Rn_state,Rn_room,Rn_Type,Rn_price,Rn_remaker,Room_suod,Rn_Tobe,Rn_suo from room_number ");
            strSql.Append(" where " + TabCell + "=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            CdHotelManage.Model.room_number model = new CdHotelManage.Model.room_number();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
		public CdHotelManage.Model.room_number DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.room_number model=new CdHotelManage.Model.room_number();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
                if (row["Rn_flloeld"] != null)
                {
                    model.Rn_flloeld = row["Rn_flloeld"].ToString();
                }
				if(row["Rn_floor"]!=null)
				{
					model.Rn_floor=row["Rn_floor"].ToString();
				}
				if(row["Rn_roomNum"]!=null)
				{
					model.Rn_roomNum=row["Rn_roomNum"].ToString();
				}
				if(row["Rn_state"]!=null && row["Rn_state"].ToString()!="")
				{
					model.Rn_state=int.Parse(row["Rn_state"].ToString());
				}
				if(row["Rn_room"]!=null)
				{
					model.Rn_room=row["Rn_room"].ToString();
				}
				if(row["Rn_Type"]!=null && row["Rn_Type"].ToString()!="")
				{
					model.Rn_Type=int.Parse(row["Rn_Type"].ToString());
				}
				if(row["Rn_price"]!=null && row["Rn_price"].ToString()!="")
				{
                    model.Rn_price = Convert.ToDecimal(decimal.Parse(row["Rn_price"].ToString()));
				}
				if(row["Rn_remaker"]!=null)
				{
					model.Rn_remaker=row["Rn_remaker"].ToString();
				}
                if (row["Room_suod"] != null)
				{
                    model.Room_suod = row["Room_suod"].ToString();
				}
                if (row["Rn_Tobe"] != null && row["Rn_Tobe"].ToString() != "")
                {
                    model.Rn_Tobe = Convert.ToInt32(row["Rn_Tobe"]);
                }
                if (row["Rn_suo"] != null && row["Rn_suo"].ToString() != "")
                {
                    model.Rn_suo = row["Rn_suo"].ToString();
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
            strSql.Append("select id,Rn_flloeld,Rn_floor,Rn_roomNum,Rn_state,Rn_room,Rn_Type,Rn_price,Rn_remaker,Room_suod,Room_sort,Rn_Tobe,Rn_suo ");
			strSql.Append(" FROM room_number ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListed(string strWhere,string join)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  * ");
            strSql.Append(" FROM room_number as a "+join );
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetProc(string str,int flo,string num,string time) {
            DataSet ds = new DataSet();
            IDataParameter[] pars={
                                  new SqlParameter("@str",SqlDbType.NVarChar),
                                  new SqlParameter("@floor",SqlDbType.Int),
                                  new SqlParameter("@roomNumber",SqlDbType.NVarChar),
                                  new SqlParameter("@time",SqlDbType.NVarChar)
                                  };
            pars[0].Value = str;
            pars[1].Value = flo;
            pars[2].Value = num;
            pars[3].Value = time;
            return DbHelperSQL.RunProcedure("GetList", pars, "room_number");
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
            strSql.Append(" id,Rn_floor,Rn_flloeld,Rn_roomNum,Rn_state,Rn_room,Rn_Type,Rn_price,Rn_remaker,Room_suod,Room_sort,Rn_Tobe,Rn_suo ");
			strSql.Append(" FROM room_number ");
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
			strSql.Append("select count(1) FROM room_number ");
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
			strSql.Append(")AS Row, T.*  from room_number T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}
        public DataSet GetBookRoomPager(string sort, string order, int currentPage, int pageSize, string strWhere)
        {
            string _sql = @" select * from (select *,Row_number() over(order by " + sort + " " + order + ") as IDBookRoom from room_number " + strWhere + ") as IDWithRowNumber where IDBookRoom>=(" + currentPage + "-1)*" + pageSize + "+1 and IDBookRoom<=" + currentPage + "*" + pageSize + "";
            return DbHelperSQL.Query(_sql);
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
			parameters[0].Value = "room_number";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/


        public string IsSuoFang(string roomNumber) {
            string sql = "select Room_suod from room_number where Rn_roomNum='" + roomNumber + "'";
            object obj = DbHelperSQL.GetSingle(sql);
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod

	}
}

