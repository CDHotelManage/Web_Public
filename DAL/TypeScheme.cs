using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace CdHotelManage.DAL
{
    public class TypeScheme
    {
        public TypeScheme()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("typeID", "TypeScheme");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int typeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TypeScheme");
            strSql.Append(" where typeID=@typeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@typeID", SqlDbType.Int,4)			};
            parameters[0].Value = typeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CdHotelManage.Model.TypeScheme model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TypeScheme(");
            strSql.Append("typeID,Earlyapart,EarlyapartAddP,EarlyInsufficient,EarlyInExceed,EarlyInAddPri)");
            strSql.Append(" values (");
            strSql.Append("@typeID,@Earlyapart,@EarlyapartAddP,@EarlyInsufficient,@EarlyInExceed,@EarlyInAddPri)");
            SqlParameter[] parameters = {
					new SqlParameter("@typeID", SqlDbType.Int,4),
					new SqlParameter("@Earlyapart", SqlDbType.Int,4),
					new SqlParameter("@EarlyapartAddP", SqlDbType.Int,4),
					new SqlParameter("@EarlyInsufficient", SqlDbType.Int,4),
					new SqlParameter("@EarlyInExceed", SqlDbType.Int,4),
					new SqlParameter("@EarlyInAddPri", SqlDbType.Decimal,5)};
            parameters[0].Value = model.typeID;
            parameters[1].Value = model.Earlyapart;
            parameters[2].Value = model.EarlyapartAddP;
            parameters[3].Value = model.EarlyInsufficient;
            parameters[4].Value = model.EarlyInExceed;
            parameters[5].Value = model.EarlyInAddPri;

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
        public bool Update(CdHotelManage.Model.TypeScheme model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TypeScheme set ");
            strSql.Append("Earlyapart=@Earlyapart,");
            strSql.Append("EarlyapartAddP=@EarlyapartAddP,");
            strSql.Append("EarlyInsufficient=@EarlyInsufficient,");
            strSql.Append("EarlyInExceed=@EarlyInExceed,");
            strSql.Append("EarlyInAddPri=@EarlyInAddPri");
            strSql.Append(" where typeID=@typeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Earlyapart", SqlDbType.Int,4),
					new SqlParameter("@EarlyapartAddP", SqlDbType.Int,4),
					new SqlParameter("@EarlyInsufficient", SqlDbType.Int,4),
					new SqlParameter("@EarlyInExceed", SqlDbType.Int,4),
					new SqlParameter("@EarlyInAddPri", SqlDbType.Decimal,5),
					new SqlParameter("@typeID", SqlDbType.Int,4)};
            parameters[0].Value = model.Earlyapart;
            parameters[1].Value = model.EarlyapartAddP;
            parameters[2].Value = model.EarlyInsufficient;
            parameters[3].Value = model.EarlyInExceed;
            parameters[4].Value = model.EarlyInAddPri;
            parameters[5].Value = model.typeID;

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
        public bool Delete(int typeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TypeScheme ");
            strSql.Append(" where typeID=@typeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@typeID", SqlDbType.Int,4)			};
            parameters[0].Value = typeID;

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
        public bool DeleteList(string typeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TypeScheme ");
            strSql.Append(" where typeID in (" + typeIDlist + ")  ");
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
        public CdHotelManage.Model.TypeScheme GetModel(int typeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 typeID,Earlyapart,EarlyapartAddP,EarlyInsufficient,EarlyInExceed,EarlyInAddPri from TypeScheme ");
            strSql.Append(" where typeID=@typeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@typeID", SqlDbType.Int,4)			};
            parameters[0].Value = typeID;

            CdHotelManage.Model.TypeScheme model = new CdHotelManage.Model.TypeScheme();
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
        public CdHotelManage.Model.TypeScheme DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.TypeScheme model = new CdHotelManage.Model.TypeScheme();
            if (row != null)
            {
                if (row["typeID"] != null && row["typeID"].ToString() != "")
                {
                    model.typeID = int.Parse(row["typeID"].ToString());
                }
                if (row["Earlyapart"] != null && row["Earlyapart"].ToString() != "")
                {
                    model.Earlyapart = int.Parse(row["Earlyapart"].ToString());
                }
                if (row["EarlyapartAddP"] != null && row["EarlyapartAddP"].ToString() != "")
                {
                    model.EarlyapartAddP = int.Parse(row["EarlyapartAddP"].ToString());
                }
                if (row["EarlyInsufficient"] != null && row["EarlyInsufficient"].ToString() != "")
                {
                    model.EarlyInsufficient = int.Parse(row["EarlyInsufficient"].ToString());
                }
                if (row["EarlyInExceed"] != null && row["EarlyInExceed"].ToString() != "")
                {
                    model.EarlyInExceed = int.Parse(row["EarlyInExceed"].ToString());
                }
                if (row["EarlyInAddPri"] != null && row["EarlyInAddPri"].ToString() != "")
                {
                    model.EarlyInAddPri = decimal.Parse(row["EarlyInAddPri"].ToString());
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
            strSql.Append("select typeID,Earlyapart,EarlyapartAddP,EarlyInsufficient,EarlyInExceed,EarlyInAddPri ");
            strSql.Append(" FROM TypeScheme ");
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
            strSql.Append(" typeID,Earlyapart,EarlyapartAddP,EarlyInsufficient,EarlyInExceed,EarlyInAddPri ");
            strSql.Append(" FROM TypeScheme ");
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
            strSql.Append("select count(1) FROM TypeScheme ");
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
                strSql.Append("order by T.typeID desc");
            }
            strSql.Append(")AS Row, T.*  from TypeScheme T ");
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
            parameters[0].Value = "TypeScheme";
            parameters[1].Value = "typeID";
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
