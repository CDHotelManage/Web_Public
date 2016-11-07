using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
    /// <summary>
    /// 数据访问类:AddPrice
    /// </summary>
    public partial class AddPrice
    {
        public AddPrice()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("MtID", "AddPrice");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MtID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AddPrice");
            strSql.Append(" where MtID=@MtID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MtID", SqlDbType.Int,4)			};
            parameters[0].Value = MtID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CdHotelManage.Model.AddPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AddPrice(");
            strSql.Append("AddPice,ZsPice,ZsJf,IsOk,Remark)");
            strSql.Append(" values (");
            strSql.Append("@AddPice,@ZsPice,@ZsJf,@IsOk,@Remark)");
            SqlParameter[] parameters = {
					new SqlParameter("@AddPice", SqlDbType.Int,4),
					new SqlParameter("@ZsPice", SqlDbType.Int,4),
					new SqlParameter("@ZsJf", SqlDbType.Int,4),
					new SqlParameter("@IsOk", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.AddPice;
            parameters[1].Value = model.ZsPice;
            parameters[2].Value = model.ZsJf;
            parameters[3].Value = model.IsOk;
            parameters[4].Value = model.Remark;

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
        public bool Update(CdHotelManage.Model.AddPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AddPrice set ");
            strSql.Append("AddPice=@AddPice,");
            strSql.Append("ZsPice=@ZsPice,");
            strSql.Append("ZsJf=@ZsJf,");
            strSql.Append("IsOk=@IsOk,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where MtID=@MtID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AddPice", SqlDbType.Int,4),
					new SqlParameter("@ZsPice", SqlDbType.Int,4),
					new SqlParameter("@ZsJf", SqlDbType.Int,4),
					new SqlParameter("@IsOk", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@MtID", SqlDbType.Int,4)};
            parameters[0].Value = model.AddPice;
            parameters[1].Value = model.ZsPice;
            parameters[2].Value = model.ZsJf;
            parameters[3].Value = model.IsOk;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.MtID;

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
        public bool Delete(int MtID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AddPrice ");
            strSql.Append(" where MtID=@MtID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MtID", SqlDbType.Int,4)			};
            parameters[0].Value = MtID;

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
        public bool DeleteList(string MtIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AddPrice ");
            strSql.Append(" where MtID in (" + MtIDlist + ")  ");
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
        public CdHotelManage.Model.AddPrice GetModel(int MtID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MtID,AddPice,ZsPice,ZsJf,IsOk,Remark from AddPrice ");
            strSql.Append(" where MtID=@MtID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MtID", SqlDbType.Int,4)			};
            parameters[0].Value = MtID;

            CdHotelManage.Model.AddPrice model = new CdHotelManage.Model.AddPrice();
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
        public CdHotelManage.Model.AddPrice DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.AddPrice model = new CdHotelManage.Model.AddPrice();
            if (row != null)
            {
                if (row["MtID"] != null && row["MtID"].ToString() != "")
                {
                    model.MtID = int.Parse(row["MtID"].ToString());
                }
                if (row["AddPice"] != null && row["AddPice"].ToString() != "")
                {
                    model.AddPice = int.Parse(row["AddPice"].ToString());
                }
                if (row["ZsPice"] != null && row["ZsPice"].ToString() != "")
                {
                    model.ZsPice = int.Parse(row["ZsPice"].ToString());
                }
                if (row["ZsJf"] != null && row["ZsJf"].ToString() != "")
                {
                    model.ZsJf = int.Parse(row["ZsJf"].ToString());
                }
                if (row["IsOk"] != null && row["IsOk"].ToString() != "")
                {
                    if ((row["IsOk"].ToString() == "1") || (row["IsOk"].ToString().ToLower() == "true"))
                    {
                        model.IsOk = true;
                    }
                    else
                    {
                        model.IsOk = false;
                    }
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
            strSql.Append("select MtID,AddPice,ZsPice,ZsJf,IsOk,Remark ");
            strSql.Append(" FROM AddPrice ");
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
            strSql.Append(" MtID,AddPice,ZsPice,ZsJf,IsOk,Remark ");
            strSql.Append(" FROM AddPrice ");
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
            strSql.Append("select count(1) FROM AddPrice ");
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
                strSql.Append("order by T.MtID desc");
            }
            strSql.Append(")AS Row, T.*  from AddPrice T ");
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
            parameters[0].Value = "AddPrice";
            parameters[1].Value = "MtID";
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

