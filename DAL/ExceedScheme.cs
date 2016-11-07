using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace CdHotelManage.DAL
{
    public class ExceedScheme
    {
        public ExceedScheme()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("TypeRoom", "ExceedScheme");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TypeRoom)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ExceedScheme");
            strSql.Append(" where TypeRoom=@TypeRoom ");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeRoom", SqlDbType.Int,4)			};
            parameters[0].Value = TypeRoom;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CdHotelManage.Model.ExceedScheme model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ExceedScheme(");
            strSql.Append("TypeRoom,GraceTime,Earlyapart,EarlyapartAddP,EarlyInsufficient,EarlyInExceed,EarlyInAddPri)");
            strSql.Append(" values (");
            strSql.Append("@TypeRoom,@GraceTime,@Earlyapart,@EarlyapartAddP,@EarlyInsufficient,@EarlyInExceed,@EarlyInAddPri)");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeRoom", SqlDbType.Int,4),
					new SqlParameter("@GraceTime", SqlDbType.Int,4),
					new SqlParameter("@Earlyapart", SqlDbType.Int,4),
					new SqlParameter("@EarlyapartAddP", SqlDbType.Decimal,5),
					new SqlParameter("@EarlyInsufficient", SqlDbType.Int,4),
					new SqlParameter("@EarlyInExceed", SqlDbType.Int,4),
					new SqlParameter("@EarlyInAddPri", SqlDbType.Decimal,5)};
            parameters[0].Value = model.TypeRoom;
            parameters[1].Value = model.GraceTime;
            parameters[2].Value = model.Earlyapart;
            parameters[3].Value = model.EarlyapartAddP;
            parameters[4].Value = model.EarlyInsufficient;
            parameters[5].Value = model.EarlyInExceed;
            parameters[6].Value = model.EarlyInAddPri;

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
        public bool Update(CdHotelManage.Model.ExceedScheme model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ExceedScheme set ");
            strSql.Append("GraceTime=@GraceTime,");
            strSql.Append("Earlyapart=@Earlyapart,");
            strSql.Append("EarlyapartAddP=@EarlyapartAddP,");
            strSql.Append("EarlyInsufficient=@EarlyInsufficient,");
            strSql.Append("EarlyInExceed=@EarlyInExceed,");
            strSql.Append("EarlyInAddPri=@EarlyInAddPri");
            strSql.Append(" where TypeRoom=@TypeRoom ");
            SqlParameter[] parameters = {
					new SqlParameter("@GraceTime", SqlDbType.Int,4),
					new SqlParameter("@Earlyapart", SqlDbType.Int,4),
					new SqlParameter("@EarlyapartAddP", SqlDbType.Decimal,5),
					new SqlParameter("@EarlyInsufficient", SqlDbType.Int,4),
					new SqlParameter("@EarlyInExceed", SqlDbType.Int,4),
					new SqlParameter("@EarlyInAddPri", SqlDbType.Decimal,5),
					new SqlParameter("@TypeRoom", SqlDbType.Int,4)};
            parameters[0].Value = model.GraceTime;
            parameters[1].Value = model.Earlyapart;
            parameters[2].Value = model.EarlyapartAddP;
            parameters[3].Value = model.EarlyInsufficient;
            parameters[4].Value = model.EarlyInExceed;
            parameters[5].Value = model.EarlyInAddPri;
            parameters[6].Value = model.TypeRoom;

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
        public bool Delete(int TypeRoom)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ExceedScheme ");
            strSql.Append(" where TypeRoom=@TypeRoom ");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeRoom", SqlDbType.Int,4)			};
            parameters[0].Value = TypeRoom;

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
        public bool DeleteList(string TypeRoomlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ExceedScheme ");
            strSql.Append(" where TypeRoom in (" + TypeRoomlist + ")  ");
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
        public CdHotelManage.Model.ExceedScheme GetModel(int TypeRoom)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TypeRoom,GraceTime,Earlyapart,EarlyapartAddP,EarlyInsufficient,EarlyInExceed,EarlyInAddPri from ExceedScheme ");
            strSql.Append(" where TypeRoom=@TypeRoom ");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeRoom", SqlDbType.Int,4)			};
            parameters[0].Value = TypeRoom;

            CdHotelManage.Model.ExceedScheme model = new CdHotelManage.Model.ExceedScheme();
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
        public CdHotelManage.Model.ExceedScheme DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.ExceedScheme model = new CdHotelManage.Model.ExceedScheme();
            if (row != null)
            {
                if (row["TypeRoom"] != null && row["TypeRoom"].ToString() != "")
                {
                    model.TypeRoom = int.Parse(row["TypeRoom"].ToString());
                }
                if (row["GraceTime"] != null && row["GraceTime"].ToString() != "")
                {
                    model.GraceTime = int.Parse(row["GraceTime"].ToString());
                }
                if (row["Earlyapart"] != null && row["Earlyapart"].ToString() != "")
                {
                    model.Earlyapart = int.Parse(row["Earlyapart"].ToString());
                }
                if (row["EarlyapartAddP"] != null && row["EarlyapartAddP"].ToString() != "")
                {
                    model.EarlyapartAddP = decimal.Parse(row["EarlyapartAddP"].ToString());
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
            strSql.Append("select TypeRoom,GraceTime,Earlyapart,EarlyapartAddP,EarlyInsufficient,EarlyInExceed,EarlyInAddPri ");
            strSql.Append(" FROM ExceedScheme ");
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
            strSql.Append(" TypeRoom,GraceTime,Earlyapart,EarlyapartAddP,EarlyInsufficient,EarlyInExceed,EarlyInAddPri ");
            strSql.Append(" FROM ExceedScheme ");
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
            strSql.Append("select count(1) FROM ExceedScheme ");
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
                strSql.Append("order by T.TypeRoom desc");
            }
            strSql.Append(")AS Row, T.*  from ExceedScheme T ");
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
            parameters[0].Value = "ExceedScheme";
            parameters[1].Value = "TypeRoom";
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
