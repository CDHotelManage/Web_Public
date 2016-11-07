using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace CdHotelManage.DAL
{
    public class ZD_hourse
    {
        public ZD_hourse()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "ZD_hourse");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ZD_hourse");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CdHotelManage.Model.ZD_hourse model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ZD_hourse(");
            strSql.Append("ID,latest,Buffer,tixing,beigin,endtime)");
            strSql.Append(" values (");
            strSql.Append("@ID,@latest,@Buffer,@tixing,@beigin,@endtime)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@latest", SqlDbType.Time,5),
					new SqlParameter("@Buffer", SqlDbType.Int,4),
					new SqlParameter("@tixing", SqlDbType.Int,4),
					new SqlParameter("@beigin", SqlDbType.Time,5),
					new SqlParameter("@endtime", SqlDbType.Time,5)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.latest;
            parameters[2].Value = model.Buffer;
            parameters[3].Value = model.tixing;
            parameters[4].Value = model.beigin;
            parameters[5].Value = model.endtime;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(CdHotelManage.Model.ZD_hourse model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ZD_hourse set ");
            strSql.Append("latest=@latest,");
            strSql.Append("Buffer=@Buffer,");
            strSql.Append("tixing=@tixing,");
            strSql.Append("beigin=@beigin,");
            strSql.Append("endtime=@endtime");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@latest", SqlDbType.Time,5),
					new SqlParameter("@Buffer", SqlDbType.Int,4),
					new SqlParameter("@tixing", SqlDbType.Int,4),
					new SqlParameter("@beigin", SqlDbType.Time,5),
					new SqlParameter("@endtime", SqlDbType.Time,5),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.latest;
            parameters[1].Value = model.Buffer;
            parameters[2].Value = model.tixing;
            parameters[3].Value = model.beigin;
            parameters[4].Value = model.endtime;
            parameters[5].Value = model.ID;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ZD_hourse ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ZD_hourse ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public CdHotelManage.Model.ZD_hourse GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,latest,Buffer,tixing,beigin,endtime from ZD_hourse ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

            CdHotelManage.Model.ZD_hourse model = new CdHotelManage.Model.ZD_hourse();
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
        public CdHotelManage.Model.ZD_hourse DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.ZD_hourse model = new CdHotelManage.Model.ZD_hourse();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["latest"] != null && row["latest"].ToString() != "")
                {
                    model.latest = TimeSpan.Parse(row["latest"].ToString());
                }
                if (row["Buffer"] != null && row["Buffer"].ToString() != "")
                {
                    model.Buffer = int.Parse(row["Buffer"].ToString());
                }
                if (row["tixing"] != null && row["tixing"].ToString() != "")
                {
                    model.tixing = int.Parse(row["tixing"].ToString());
                }
                if (row["beigin"] != null && row["beigin"].ToString() != "")
                {
                    model.beigin = TimeSpan.Parse(row["beigin"].ToString());
                }
                if (row["endtime"] != null && row["endtime"].ToString() != "")
                {
                    model.endtime = TimeSpan.Parse(row["endtime"].ToString());
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
            strSql.Append("select ID,latest,Buffer,tixing,beigin,endtime ");
            strSql.Append(" FROM ZD_hourse ");
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
            strSql.Append(" ID,latest,Buffer,tixing,beigin,endtime ");
            strSql.Append(" FROM ZD_hourse ");
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
            strSql.Append("select count(1) FROM ZD_hourse ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from ZD_hourse T ");
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
            parameters[0].Value = "ZD_hourse";
            parameters[1].Value = "ID";
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
