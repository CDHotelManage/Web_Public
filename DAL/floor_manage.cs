using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:floor_manage
	/// </summary>
	public partial class floor_manage
	{
        public floor_manage()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("floor_id", "floor_manage");
        }
        /// <summary>
        /// 获得有房间的楼层
        /// </summary>
        /// <returns></returns>
        public DataTable GetListYou() {
            DataSet ds = new DataSet();
            string sql = "select * from floor_manage where floor_id in (select Rn_floor from room_number group by  Rn_floor)";
            return DBHelper.GetDataSet(sql);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int floor_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from floor_manage");
            strSql.Append(" where floor_id=@floor_id");
            SqlParameter[] parameters = {
					new SqlParameter("@floor_id", SqlDbType.Int,4)
			};
            parameters[0].Value = floor_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CdHotelManage.Model.floor_manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into floor_manage(");
            strSql.Append("floor_number,floor_name,floor_sorting,floor_remaker,floor_shoping)");
            strSql.Append(" values (");
            strSql.Append("@floor_number,@floor_name,@floor_sorting,@floor_remaker,@floor_shoping)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@floor_number", SqlDbType.NVarChar,50),
					new SqlParameter("@floor_name", SqlDbType.NVarChar,50),
					new SqlParameter("@floor_sorting", SqlDbType.NVarChar,50),
					new SqlParameter("@floor_remaker", SqlDbType.NVarChar),
					new SqlParameter("@floor_shoping", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.floor_number;
            parameters[1].Value = model.floor_name;
            parameters[2].Value = model.floor_sorting;
            parameters[3].Value = model.floor_remaker;
            parameters[4].Value = model.floor_shoping;

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
        public bool Update(CdHotelManage.Model.floor_manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update floor_manage set ");
            strSql.Append("floor_number=@floor_number,");
            strSql.Append("floor_name=@floor_name,");
            strSql.Append("floor_sorting=@floor_sorting,");
            strSql.Append("floor_remaker=@floor_remaker,");
            strSql.Append("floor_shoping=@floor_shoping");
            strSql.Append(" where floor_id=@floor_id");
            SqlParameter[] parameters = {
					new SqlParameter("@floor_number", SqlDbType.NVarChar,50),
					new SqlParameter("@floor_name", SqlDbType.NVarChar,50),
					new SqlParameter("@floor_sorting", SqlDbType.NVarChar,50),
					new SqlParameter("@floor_remaker", SqlDbType.NVarChar),
					new SqlParameter("@floor_shoping", SqlDbType.NVarChar,50),
					new SqlParameter("@floor_id", SqlDbType.Int,4)};
            parameters[0].Value = model.floor_number;
            parameters[1].Value = model.floor_name;
            parameters[2].Value = model.floor_sorting;
            parameters[3].Value = model.floor_remaker;
            parameters[4].Value = model.floor_shoping;
            parameters[5].Value = model.floor_id;

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
        public bool Delete(int floor_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from floor_manage ");
            strSql.Append(" where floor_id=@floor_id");
            SqlParameter[] parameters = {
					new SqlParameter("@floor_id", SqlDbType.Int,4)
			};
            parameters[0].Value = floor_id;

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
        public bool DeleteList(string floor_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from floor_manage ");
            strSql.Append(" where floor_id in (" + floor_idlist + ")  ");
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
        public CdHotelManage.Model.floor_manage GetModel(int floor_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 floor_id,floor_number,floor_name,floor_sorting,floor_remaker,floor_shoping from floor_manage ");
            strSql.Append(" where floor_id=@floor_id");
            SqlParameter[] parameters = {
					new SqlParameter("@floor_id", SqlDbType.Int,4)
			};
            parameters[0].Value = floor_id;

            CdHotelManage.Model.floor_manage model = new CdHotelManage.Model.floor_manage();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["floor_id"] != null && ds.Tables[0].Rows[0]["floor_id"].ToString() != "")
                {
                    model.floor_id = int.Parse(ds.Tables[0].Rows[0]["floor_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["floor_number"] != null && ds.Tables[0].Rows[0]["floor_number"].ToString() != "")
                {
                    model.floor_number = ds.Tables[0].Rows[0]["floor_number"].ToString();
                }
                if (ds.Tables[0].Rows[0]["floor_name"] != null && ds.Tables[0].Rows[0]["floor_name"].ToString() != "")
                {
                    model.floor_name = ds.Tables[0].Rows[0]["floor_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["floor_sorting"] != null && ds.Tables[0].Rows[0]["floor_sorting"].ToString() != "")
                {
                    model.floor_sorting = ds.Tables[0].Rows[0]["floor_sorting"].ToString();
                }
                if (ds.Tables[0].Rows[0]["floor_remaker"] != null && ds.Tables[0].Rows[0]["floor_remaker"].ToString() != "")
                {
                    model.floor_remaker = ds.Tables[0].Rows[0]["floor_remaker"].ToString();
                }
                if (ds.Tables[0].Rows[0]["floor_shoping"] != null && ds.Tables[0].Rows[0]["floor_shoping"].ToString() != "")
                {
                    model.floor_shoping = ds.Tables[0].Rows[0]["floor_shoping"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select floor_id,floor_number,floor_name,floor_sorting,floor_remaker,floor_shoping ");
            strSql.Append(" FROM floor_manage ");
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
            strSql.Append(" floor_id,floor_number,floor_name,floor_sorting,floor_remaker,floor_shoping ");
            strSql.Append(" FROM floor_manage ");
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
            strSql.Append("select count(1) FROM floor_manage ");
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
                strSql.Append("order by T.floor_id desc");
            }
            strSql.Append(")AS Row, T.*  from floor_manage T ");
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
            parameters[0].Value = "floor_manage";
            parameters[1].Value = "floor_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
	}
}

