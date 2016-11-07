using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
    /// <summary>
    /// 数据访问类:Sincethehous
    /// </summary>
    public partial class Sincethehous
    {
        public Sincethehous()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sincethehous");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CdHotelManage.Model.Sincethehous model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sincethehous(");
            strSql.Append("hs_Numberno,hs_room,hs_yuany,hs_date,hs_ksDate,hs_ylDate,hs_Documentno,hs_type,hs_people,hs_Result,hs_remaker)");
            strSql.Append(" values (");
            strSql.Append("@hs_Numberno,@hs_room,@hs_yuany,@hs_date,@hs_ksDate,@hs_ylDate,@hs_Documentno,@hs_type,@hs_people,@hs_Result,@hs_remaker)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@hs_Numberno", SqlDbType.NVarChar,50),
					new SqlParameter("@hs_room", SqlDbType.NVarChar,50),
					new SqlParameter("@hs_yuany", SqlDbType.NVarChar),
					new SqlParameter("@hs_date", SqlDbType.DateTime),
					new SqlParameter("@hs_ksDate", SqlDbType.DateTime),
					new SqlParameter("@hs_ylDate", SqlDbType.NVarChar,50),
					new SqlParameter("@hs_Documentno", SqlDbType.NVarChar,50),
					new SqlParameter("@hs_type", SqlDbType.Int,4),
					new SqlParameter("@hs_people", SqlDbType.NVarChar,50),
					new SqlParameter("@hs_Result", SqlDbType.NVarChar),
					new SqlParameter("@hs_remaker", SqlDbType.NVarChar)};
            parameters[0].Value = model.hs_Numberno;
            parameters[1].Value = model.hs_room;
            parameters[2].Value = model.hs_yuany;
            parameters[3].Value = model.hs_date;
            parameters[4].Value = model.hs_ksDate;
            parameters[5].Value = model.hs_ylDate;
            parameters[6].Value = model.hs_Documentno;
            parameters[7].Value = model.hs_type;
            parameters[8].Value = model.hs_people;
            parameters[9].Value = model.hs_Result;
            parameters[10].Value = model.hs_remaker;

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
        public bool Update(CdHotelManage.Model.Sincethehous model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sincethehous set ");
            strSql.Append("hs_Numberno=@hs_Numberno,");
            strSql.Append("hs_room=@hs_room,");
            strSql.Append("hs_yuany=@hs_yuany,");
            strSql.Append("hs_date=@hs_date,");
            strSql.Append("hs_ksDate=@hs_ksDate,");
            strSql.Append("hs_ylDate=@hs_ylDate,");
            strSql.Append("hs_Documentno=@hs_Documentno,");
            strSql.Append("hs_type=@hs_type,");
            strSql.Append("hs_people=@hs_people,");
            strSql.Append("hs_Result=@hs_Result,");
            strSql.Append("hs_remaker=@hs_remaker");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@hs_Numberno", SqlDbType.NVarChar,50),
					new SqlParameter("@hs_room", SqlDbType.NVarChar,50),
					new SqlParameter("@hs_yuany", SqlDbType.NVarChar),
					new SqlParameter("@hs_date", SqlDbType.DateTime),
					new SqlParameter("@hs_ksDate", SqlDbType.DateTime),
					new SqlParameter("@hs_ylDate", SqlDbType.NVarChar,50),
					new SqlParameter("@hs_Documentno", SqlDbType.NVarChar,50),
					new SqlParameter("@hs_type", SqlDbType.Int,4),
					new SqlParameter("@hs_people", SqlDbType.NVarChar,50),
					new SqlParameter("@hs_Result", SqlDbType.NVarChar),
					new SqlParameter("@hs_remaker", SqlDbType.NVarChar),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.hs_Numberno;
            parameters[1].Value = model.hs_room;
            parameters[2].Value = model.hs_yuany;
            parameters[3].Value = model.hs_date;
            parameters[4].Value = model.hs_ksDate;
            parameters[5].Value = model.hs_ylDate;
            parameters[6].Value = model.hs_Documentno;
            parameters[7].Value = model.hs_type;
            parameters[8].Value = model.hs_people;
            parameters[9].Value = model.hs_Result;
            parameters[10].Value = model.hs_remaker;
            parameters[11].Value = model.id;

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
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sincethehous ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sincethehous ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public CdHotelManage.Model.Sincethehous GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,hs_Numberno,hs_room,hs_yuany,hs_date,hs_ksDate,hs_ylDate,hs_Documentno,hs_type,hs_people,hs_Result,hs_remaker from Sincethehous ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            CdHotelManage.Model.Sincethehous model = new CdHotelManage.Model.Sincethehous();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["hs_Numberno"] != null && ds.Tables[0].Rows[0]["hs_Numberno"].ToString() != "")
                {
                    model.hs_Numberno = ds.Tables[0].Rows[0]["hs_Numberno"].ToString();
                }
                if (ds.Tables[0].Rows[0]["hs_room"] != null && ds.Tables[0].Rows[0]["hs_room"].ToString() != "")
                {
                    model.hs_room = ds.Tables[0].Rows[0]["hs_room"].ToString();
                }
                if (ds.Tables[0].Rows[0]["hs_yuany"] != null && ds.Tables[0].Rows[0]["hs_yuany"].ToString() != "")
                {
                    model.hs_yuany = ds.Tables[0].Rows[0]["hs_yuany"].ToString();
                }
                if (ds.Tables[0].Rows[0]["hs_date"] != null && ds.Tables[0].Rows[0]["hs_date"].ToString() != "")
                {
                    model.hs_date = DateTime.Parse(ds.Tables[0].Rows[0]["hs_date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["hs_ksDate"] != null && ds.Tables[0].Rows[0]["hs_ksDate"].ToString() != "")
                {
                    model.hs_ksDate = DateTime.Parse(ds.Tables[0].Rows[0]["hs_ksDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["hs_ylDate"] != null && ds.Tables[0].Rows[0]["hs_ylDate"].ToString() != "")
                {
                    model.hs_ylDate = ds.Tables[0].Rows[0]["hs_ylDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["hs_Documentno"] != null && ds.Tables[0].Rows[0]["hs_Documentno"].ToString() != "")
                {
                    model.hs_Documentno = ds.Tables[0].Rows[0]["hs_Documentno"].ToString();
                }
                if (ds.Tables[0].Rows[0]["hs_type"] != null && ds.Tables[0].Rows[0]["hs_type"].ToString() != "")
                {
                    model.hs_type = int.Parse(ds.Tables[0].Rows[0]["hs_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["hs_people"] != null && ds.Tables[0].Rows[0]["hs_people"].ToString() != "")
                {
                    model.hs_people = ds.Tables[0].Rows[0]["hs_people"].ToString();
                }
                if (ds.Tables[0].Rows[0]["hs_Result"] != null && ds.Tables[0].Rows[0]["hs_Result"].ToString() != "")
                {
                    model.hs_Result = ds.Tables[0].Rows[0]["hs_Result"].ToString();
                }
                if (ds.Tables[0].Rows[0]["hs_remaker"] != null && ds.Tables[0].Rows[0]["hs_remaker"].ToString() != "")
                {
                    model.hs_remaker = ds.Tables[0].Rows[0]["hs_remaker"].ToString();
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
            strSql.Append("select id,hs_Numberno,hs_room,hs_yuany,hs_date,hs_ksDate,hs_ylDate,hs_Documentno,hs_type,hs_people,hs_Result,hs_remaker ");
            strSql.Append(" FROM Sincethehous ");
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
            strSql.Append(" id,hs_Numberno,hs_room,hs_yuany,hs_date,hs_ksDate,hs_ylDate,hs_Documentno,hs_type,hs_people,hs_Result,hs_remaker ");
            strSql.Append(" FROM Sincethehous ");
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
            strSql.Append("select count(1) FROM Sincethehous ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from Sincethehous T ");
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
            parameters[0].Value = "Sincethehous";
            parameters[1].Value = "id";
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

