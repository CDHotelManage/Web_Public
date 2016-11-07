﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
    /// <summary>
    /// 数据访问类:memberState
    /// </summary>
    public partial class memberState
    {
        public memberState()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("msID", "memberState");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int msID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from memberState");
            strSql.Append(" where msID=@msID ");
            SqlParameter[] parameters = {
					new SqlParameter("@msID", SqlDbType.Int,4)			};
            parameters[0].Value = msID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.memberState model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into memberState(");
            strSql.Append("msID,title,Remark)");
            strSql.Append(" values (");
            strSql.Append("@msID,@title,@Remark)");
            SqlParameter[] parameters = {
					new SqlParameter("@msID", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.msID;
            parameters[1].Value = model.title;
            parameters[2].Value = model.Remark;

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
        public bool Update(Model.memberState model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update memberState set ");
            strSql.Append("title=@title,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where msID=@msID ");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@msID", SqlDbType.Int,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.msID;

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
        public bool Delete(int msID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from memberState ");
            strSql.Append(" where msID=@msID ");
            SqlParameter[] parameters = {
					new SqlParameter("@msID", SqlDbType.Int,4)			};
            parameters[0].Value = msID;

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
        public bool DeleteList(string msIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from memberState ");
            strSql.Append(" where msID in (" + msIDlist + ")  ");
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
        public Model.memberState GetModel(int msID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 msID,title,Remark from memberState ");
            strSql.Append(" where msID=@msID ");
            SqlParameter[] parameters = {
					new SqlParameter("@msID", SqlDbType.Int,4)			};
            parameters[0].Value = msID;

            Model.memberState model = new Model.memberState();
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
        public Model.memberState DataRowToModel(DataRow row)
        {
            Model.memberState model = new Model.memberState();
            if (row != null)
            {
                if (row["msID"] != null && row["msID"].ToString() != "")
                {
                    model.msID = int.Parse(row["msID"].ToString());
                }
                if (row["title"] != null)
                {
                    model.title = row["title"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
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
            strSql.Append("select msID,title,Remark ");
            strSql.Append(" FROM memberState ");
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
            strSql.Append(" msID,title,Remark ");
            strSql.Append(" FROM memberState ");
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
            strSql.Append("select count(1) FROM memberState ");
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
                strSql.Append("order by T.msID desc");
            }
            strSql.Append(")AS Row, T.*  from memberState T ");
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
            parameters[0].Value = "memberState";
            parameters[1].Value = "msID";
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

