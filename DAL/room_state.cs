using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using CdHotelManage.Model;
namespace CdHotelManage.DAL
{
    /// <summary>
    /// 数据访问类:room_state
    /// </summary>
    public partial class room_state
    {
        public room_state()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("room_state_id", "room_state");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int room_state_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from room_state");
            strSql.Append(" where room_state_id=@room_state_id");
            SqlParameter[] parameters = {
					new SqlParameter("@room_state_id", SqlDbType.Int,4)
			};
            parameters[0].Value = room_state_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CdHotelManage.Model.room_state model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into room_state(");
            strSql.Append("room_state_name,Room_suod,remark,Room_color)");
            strSql.Append(" values (");
            strSql.Append("@room_state_name,@remark,@Room_color)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@room_state_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@Room_suod", SqlDbType.Char,10),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
                                        new SqlParameter("@Room_color", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = model.room_state_name;
            parameters[1].Value = model.Room_suod;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.Room_color;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(CdHotelManage.Model.room_state model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update room_state set ");
            strSql.Append("room_state_name=@room_state_name,Room_suod=@Room_suod,Room_color=@Room_color,");
            strSql.Append("remark=@remark");
            strSql.Append(" where room_state_id=@room_state_id");
            SqlParameter[] parameters = {
					new SqlParameter("@room_state_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@Room_suod", SqlDbType.Char,10),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@room_state_id", SqlDbType.Int,4),
                                        new SqlParameter("@Room_color", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.room_state_name;
            parameters[1].Value = model.Room_suod;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.room_state_id;
            parameters[4].Value = model.Room_color;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int room_state_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from room_state ");
            strSql.Append(" where room_state_id=@room_state_id");
            SqlParameter[] parameters = {
					new SqlParameter("@room_state_id", SqlDbType.Int,4)
			};
            parameters[0].Value = room_state_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string room_state_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from room_state ");
            strSql.Append(" where room_state_id in (" + room_state_idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public CdHotelManage.Model.room_state GetModel(int room_state_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 room_state_id,room_state_name,remark,Room_suod,Room_color from room_state ");
            strSql.Append(" where room_state_id=@room_state_id");
            SqlParameter[] parameters = {
					new SqlParameter("@room_state_id", SqlDbType.Int,4)
			};
            parameters[0].Value = room_state_id;

            CdHotelManage.Model.room_state model = new CdHotelManage.Model.room_state();
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
        public CdHotelManage.Model.room_state DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.room_state model = new CdHotelManage.Model.room_state();
            if (row != null)
            {
                if (row["room_state_id"] != null && row["room_state_id"].ToString() != "")
                {
                    model.room_state_id = int.Parse(row["room_state_id"].ToString());
                }
                if (row["Room_suod"] != null)
                {
                    model.Room_suod = row["Room_suod"].ToString();
                }
                
                if (row["room_state_name"] != null)
                {
                    model.room_state_name = row["room_state_name"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["Room_color"] != null && row["Room_color"].ToString() != "")
                {
                    model.Room_color = row["Room_color"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select room_state_id,room_state_name,Room_suod,remark,Room_color ");
            strSql.Append(" FROM room_state ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" room_state_id,room_state_name,Room_suod,remark,Room_color ");
            strSql.Append(" FROM room_state ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM room_state ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.room_state_id desc");
            }
            strSql.Append(")AS Row, T.*  from room_state T ");
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
            parameters[0].Value = "room_state";
            parameters[1].Value = "room_state_id";
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

        //以标识列获得对象
        //以主键查询
        public  CdHotelManage.Model.room_state GetRoomStateByRoomStateId(int RoomStateId)
        {
            string sql = "SELECT * FROM " + "room_state" + " WHERE room_state_id = @RoomStateId";
            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@RoomStateId", RoomStateId));
                if (reader.Read())
                {
                    CdHotelManage.Model.room_state model = new CdHotelManage.Model.room_state();
                    model.room_state_id = (int)reader["room_state_id"];
                    model.room_state_name = (string)reader["room_state_name"];
                    reader.Close();

                    return model;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }			
    }
}

