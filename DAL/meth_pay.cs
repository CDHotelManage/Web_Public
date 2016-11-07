using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:meth_pay
	/// </summary>
	public partial class meth_pay
	{
		
        public meth_pay()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int meth_pay_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from meth_pay");
            strSql.Append(" where meth_pay_id=@meth_pay_id");
            SqlParameter[] parameters = {
					new SqlParameter("@meth_pay_id", SqlDbType.Int,4)
			};
            parameters[0].Value = meth_pay_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CdHotelManage.Model.meth_pay model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into meth_pay(");
            strSql.Append("meth_pay_name,meth_is_ya,meth_is_jie,meth_sort,remark)");
            strSql.Append(" values (");
            strSql.Append("@meth_pay_name,@meth_is_ya,@meth_is_jie,@meth_sort,@remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@meth_pay_name", SqlDbType.NVarChar,50),
					new SqlParameter("@meth_is_ya", SqlDbType.Bit,1),
					new SqlParameter("@meth_is_jie", SqlDbType.Bit,1),
					new SqlParameter("@meth_sort", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.meth_pay_name;
            parameters[1].Value = model.meth_is_ya;
            parameters[2].Value = model.meth_is_jie;
            parameters[3].Value = model.meth_sort;
            parameters[4].Value = model.remark;

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
        public bool Update(CdHotelManage.Model.meth_pay model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update meth_pay set ");
            strSql.Append("meth_pay_name=@meth_pay_name,");
            strSql.Append("meth_is_ya=@meth_is_ya,");
            strSql.Append("meth_is_jie=@meth_is_jie,");
            strSql.Append("meth_sort=@meth_sort,");
            strSql.Append("remark=@remark");
            strSql.Append(" where meth_pay_id=@meth_pay_id");
            SqlParameter[] parameters = {
					new SqlParameter("@meth_pay_name", SqlDbType.NVarChar,50),
					new SqlParameter("@meth_is_ya", SqlDbType.Bit,1),
					new SqlParameter("@meth_is_jie", SqlDbType.Bit,1),
					new SqlParameter("@meth_sort", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@meth_pay_id", SqlDbType.Int,4)};
            parameters[0].Value = model.meth_pay_name;
            parameters[1].Value = model.meth_is_ya;
            parameters[2].Value = model.meth_is_jie;
            parameters[3].Value = model.meth_sort;
            parameters[4].Value = model.remark;
            parameters[5].Value = model.meth_pay_id;

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
        public bool Delete(int meth_pay_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from meth_pay ");
            strSql.Append(" where meth_pay_id=@meth_pay_id");
            SqlParameter[] parameters = {
					new SqlParameter("@meth_pay_id", SqlDbType.Int,4)
			};
            parameters[0].Value = meth_pay_id;

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
        public bool DeleteList(string meth_pay_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from meth_pay ");
            strSql.Append(" where meth_pay_id in (" + meth_pay_idlist + ")  ");
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
        public CdHotelManage.Model.meth_pay GetModel(int meth_pay_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 meth_pay_id,meth_pay_name,meth_is_ya,meth_is_jie,meth_sort,remark from meth_pay ");
            strSql.Append(" where meth_pay_id=@meth_pay_id");
            SqlParameter[] parameters = {
					new SqlParameter("@meth_pay_id", SqlDbType.Int,4)
			};
            parameters[0].Value = meth_pay_id;

            CdHotelManage.Model.meth_pay model = new CdHotelManage.Model.meth_pay();
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
        public CdHotelManage.Model.meth_pay DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.meth_pay model = new CdHotelManage.Model.meth_pay();
            if (row != null)
            {
                if (row["meth_pay_id"] != null && row["meth_pay_id"].ToString() != "")
                {
                    model.meth_pay_id = int.Parse(row["meth_pay_id"].ToString());
                }
                if (row["meth_pay_name"] != null)
                {
                    model.meth_pay_name = row["meth_pay_name"].ToString();
                }
                if (row["meth_is_ya"] != null && row["meth_is_ya"].ToString() != "")
                {
                    if ((row["meth_is_ya"].ToString() == "1") || (row["meth_is_ya"].ToString().ToLower() == "true"))
                    {
                        model.meth_is_ya = true;
                    }
                    else
                    {
                        model.meth_is_ya = false;
                    }
                }
                if (row["meth_is_jie"] != null && row["meth_is_jie"].ToString() != "")
                {
                    if ((row["meth_is_jie"].ToString() == "1") || (row["meth_is_jie"].ToString().ToLower() == "true"))
                    {
                        model.meth_is_jie = true;
                    }
                    else
                    {
                        model.meth_is_jie = false;
                    }
                }
                if (row["meth_sort"] != null && row["meth_sort"].ToString() != "")
                {
                    model.meth_sort = int.Parse(row["meth_sort"].ToString());
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
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
            strSql.Append("select meth_pay_id,meth_pay_name,meth_is_ya,meth_is_jie,meth_sort,remark ");
            strSql.Append(" FROM meth_pay ");
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
            strSql.Append(" meth_pay_id,meth_pay_name,meth_is_ya,meth_is_jie,meth_sort,remark ");
            strSql.Append(" FROM meth_pay ");
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
            strSql.Append("select count(1) FROM meth_pay ");
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
                strSql.Append("order by T.meth_pay_id desc");
            }
            strSql.Append(")AS Row, T.*  from meth_pay T ");
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
            parameters[0].Value = "meth_pay";
            parameters[1].Value = "meth_pay_id";
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

