using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace CdHotelManage.DAL
{
    public class Commission
    {
        public Commission()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Commission");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CdHotelManage.Model.Commission model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Commission(");
            strSql.Append("Accounts,CommDesp,CommDate,CommSum,IsBack,GoodNumber,IsEveryDay,DayComm,CommRemark)");
            strSql.Append(" values (");
            strSql.Append("@Accounts,@CommDesp,@CommDate,@CommSum,@IsBack,@GoodNumber,@IsEveryDay,@DayComm,@CommRemark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Accounts", SqlDbType.NVarChar,50),
					new SqlParameter("@CommDesp", SqlDbType.NVarChar,50),
					new SqlParameter("@CommDate", SqlDbType.DateTime,3),
					new SqlParameter("@CommSum", SqlDbType.Int,4),
					new SqlParameter("@IsBack", SqlDbType.Bit,1),
					new SqlParameter("@GoodNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@IsEveryDay", SqlDbType.Bit,1),
					new SqlParameter("@DayComm", SqlDbType.Int,4),
					new SqlParameter("@CommRemark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Accounts;
            parameters[1].Value = model.CommDesp;
            parameters[2].Value = model.CommDate;
            parameters[3].Value = model.CommSum;
            parameters[4].Value = model.IsBack;
            parameters[5].Value = model.GoodNumber;
            parameters[6].Value = model.IsEveryDay;
            parameters[7].Value = model.DayComm;
            parameters[8].Value = model.CommRemark;

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
        public bool Update(CdHotelManage.Model.Commission model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Commission set ");
            strSql.Append("Accounts=@Accounts,");
            strSql.Append("CommDesp=@CommDesp,");
            strSql.Append("CommDate=@CommDate,");
            strSql.Append("CommSum=@CommSum,");
            strSql.Append("IsBack=@IsBack,");
            strSql.Append("GoodNumber=@GoodNumber,");
            strSql.Append("IsEveryDay=@IsEveryDay,");
            strSql.Append("DayComm=@DayComm,");
            strSql.Append("CommRemark=@CommRemark");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Accounts", SqlDbType.NVarChar,50),
					new SqlParameter("@CommDesp", SqlDbType.NVarChar,50),
					new SqlParameter("@CommDate", SqlDbType.DateTime,3),
					new SqlParameter("@CommSum", SqlDbType.Int,4),
					new SqlParameter("@IsBack", SqlDbType.Bit,1),
					new SqlParameter("@GoodNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@IsEveryDay", SqlDbType.Bit,1),
					new SqlParameter("@DayComm", SqlDbType.Int,4),
					new SqlParameter("@CommRemark", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Accounts;
            parameters[1].Value = model.CommDesp;
            parameters[2].Value = model.CommDate;
            parameters[3].Value = model.CommSum;
            parameters[4].Value = model.IsBack;
            parameters[5].Value = model.GoodNumber;
            parameters[6].Value = model.IsEveryDay;
            parameters[7].Value = model.DayComm;
            parameters[8].Value = model.CommRemark;
            parameters[9].Value = model.ID;

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
            strSql.Append("delete from Commission ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
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
            strSql.Append("delete from Commission ");
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
        public CdHotelManage.Model.Commission GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Accounts,CommDesp,CommDate,CommSum,IsBack,GoodNumber,IsEveryDay,DayComm,CommRemark from Commission ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            CdHotelManage.Model.Commission model = new CdHotelManage.Model.Commission();
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
        public CdHotelManage.Model.Commission DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.Commission model = new CdHotelManage.Model.Commission();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Accounts"] != null)
                {
                    model.Accounts = row["Accounts"].ToString();
                }
                if (row["CommDesp"] != null)
                {
                    model.CommDesp = row["CommDesp"].ToString();
                }
                if (row["CommDate"] != null && row["CommDate"].ToString() != "")
                {
                    model.CommDate = DateTime.Parse(row["CommDate"].ToString());
                }
                if (row["CommSum"] != null && row["CommSum"].ToString() != "")
                {
                    model.CommSum = int.Parse(row["CommSum"].ToString());
                }
                if (row["IsBack"] != null && row["IsBack"].ToString() != "")
                {
                    if ((row["IsBack"].ToString() == "1") || (row["IsBack"].ToString().ToLower() == "true"))
                    {
                        model.IsBack = true;
                    }
                    else
                    {
                        model.IsBack = false;
                    }
                }
                if (row["GoodNumber"] != null)
                {
                    model.GoodNumber = row["GoodNumber"].ToString();
                }
                if (row["IsEveryDay"] != null && row["IsEveryDay"].ToString() != "")
                {
                    if ((row["IsEveryDay"].ToString() == "1") || (row["IsEveryDay"].ToString().ToLower() == "true"))
                    {
                        model.IsEveryDay = true;
                    }
                    else
                    {
                        model.IsEveryDay = false;
                    }
                }
                if (row["DayComm"] != null && row["DayComm"].ToString() != "")
                {
                    model.DayComm = int.Parse(row["DayComm"].ToString());
                }
                if (row["CommRemark"] != null)
                {
                    model.CommRemark = row["CommRemark"].ToString();
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
            strSql.Append("select ID,Accounts,CommDesp,CommDate,CommSum,IsBack,GoodNumber,IsEveryDay,DayComm,CommRemark ");
            strSql.Append(" FROM Commission ");
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
            strSql.Append(" ID,Accounts,CommDesp,CommDate,CommSum,IsBack,GoodNumber,IsEveryDay,DayComm,CommRemark ");
            strSql.Append(" FROM Commission ");
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
            strSql.Append("select count(1) FROM Commission ");
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
            strSql.Append(")AS Row, T.*  from Commission T ");
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
            parameters[0].Value = "Commission";
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
