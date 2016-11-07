using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
    /// <summary>
    /// 数据访问类:hourse_scheme
    /// </summary>
    public partial class hourse_scheme
    {
        public hourse_scheme()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from hourse_scheme");
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
        public int Add(CdHotelManage.Model.hourse_scheme model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into hourse_scheme(");
            strSql.Append("hs_room,hs_name,hs_psmoney,hs_Discount,hs_type,hs_jgtype,hs_source_id,Hs_isAll,Hs_Strat,Hs_End,Hs_zdr,Hs_Reamrk)");
            strSql.Append(" values (");
            strSql.Append("@hs_room,@hs_name,@hs_psmoney,@hs_Discount,@hs_type,@hs_jgtype,@hs_source_id,@Hs_isAll,@Hs_Strat,@Hs_End,@Hs_zdr,@Hs_Reamrk)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@hs_room", SqlDbType.Int,4),
					new SqlParameter("@hs_name", SqlDbType.NVarChar,50),
					new SqlParameter("@hs_psmoney", SqlDbType.Money,8),
					new SqlParameter("@hs_Discount", SqlDbType.NVarChar,10),
					new SqlParameter("@hs_type", SqlDbType.Int,4),
					new SqlParameter("@hs_jgtype", SqlDbType.Int,4),
					new SqlParameter("@hs_source_id", SqlDbType.Int,4),
					new SqlParameter("@Hs_isAll", SqlDbType.Bit,1),
					new SqlParameter("@Hs_Strat", SqlDbType.DateTime),
					new SqlParameter("@Hs_End", SqlDbType.DateTime),
					new SqlParameter("@Hs_zdr", SqlDbType.Money,8),
					new SqlParameter("@Hs_Reamrk", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.hs_room;
            parameters[1].Value = model.hs_name;
            parameters[2].Value = model.hs_psmoney;
            parameters[3].Value = model.hs_Discount;
            parameters[4].Value = model.hs_type;
            parameters[5].Value = model.hs_jgtype;
            parameters[6].Value = model.hs_source_id;
            parameters[7].Value = model.Hs_isAll;
            parameters[8].Value = model.Hs_Strat;
            parameters[9].Value = model.Hs_End;
            parameters[10].Value = model.Hs_zdr;
            parameters[11].Value = model.Hs_Reamrk;

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
        public bool Update(CdHotelManage.Model.hourse_scheme model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update hourse_scheme set ");
            strSql.Append("hs_room=@hs_room,");
            strSql.Append("hs_name=@hs_name,");
            strSql.Append("hs_psmoney=@hs_psmoney,");
            strSql.Append("hs_Discount=@hs_Discount,");
            strSql.Append("hs_type=@hs_type,");
            strSql.Append("hs_jgtype=@hs_jgtype,");
            strSql.Append("hs_source_id=@hs_source_id,");
            strSql.Append("Hs_isAll=@Hs_isAll,");
            strSql.Append("Hs_Strat=@Hs_Strat,");
            strSql.Append("Hs_End=@Hs_End,");
            strSql.Append("Hs_zdr=@Hs_zdr,");
            strSql.Append("Hs_Reamrk=@Hs_Reamrk");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@hs_room", SqlDbType.Int,4),
					new SqlParameter("@hs_name", SqlDbType.NVarChar,50),
					new SqlParameter("@hs_psmoney", SqlDbType.Money,8),
					new SqlParameter("@hs_Discount", SqlDbType.NVarChar,10),
					new SqlParameter("@hs_type", SqlDbType.Int,4),
					new SqlParameter("@hs_jgtype", SqlDbType.Int,4),
					new SqlParameter("@hs_source_id", SqlDbType.Int,4),
					new SqlParameter("@Hs_isAll", SqlDbType.Bit,1),
					new SqlParameter("@Hs_Strat", SqlDbType.DateTime),
					new SqlParameter("@Hs_End", SqlDbType.DateTime),
					new SqlParameter("@Hs_zdr", SqlDbType.Money,8),
					new SqlParameter("@Hs_Reamrk", SqlDbType.NVarChar,500),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.hs_room;
            parameters[1].Value = model.hs_name;
            parameters[2].Value = model.hs_psmoney;
            parameters[3].Value = model.hs_Discount;
            parameters[4].Value = model.hs_type;
            parameters[5].Value = model.hs_jgtype;
            parameters[6].Value = model.hs_source_id;
            parameters[7].Value = model.Hs_isAll;
            parameters[8].Value = model.Hs_Strat;
            parameters[9].Value = model.Hs_End;
            parameters[10].Value = model.Hs_zdr;
            parameters[11].Value = model.Hs_Reamrk;
            parameters[12].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from hourse_scheme ");
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
            strSql.Append("delete from hourse_scheme ");
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
        public CdHotelManage.Model.hourse_scheme GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,hs_room,hs_name,hs_psmoney,hs_Discount,hs_type,hs_jgtype,hs_source_id,Hs_isAll,Hs_Strat,Hs_End,Hs_zdr,Hs_Reamrk from hourse_scheme ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            CdHotelManage.Model.hourse_scheme model = new CdHotelManage.Model.hourse_scheme();
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
        public CdHotelManage.Model.hourse_scheme DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.hourse_scheme model = new CdHotelManage.Model.hourse_scheme();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["hs_room"] != null && row["hs_room"].ToString() != "")
                {
                    model.hs_room = int.Parse(row["hs_room"].ToString());
                }
                if (row["hs_name"] != null)
                {
                    model.hs_name = row["hs_name"].ToString();
                }
                if (row["hs_psmoney"] != null && row["hs_psmoney"].ToString() != "")
                {
                    model.hs_psmoney = decimal.Parse(row["hs_psmoney"].ToString());
                }
                if (row["hs_Discount"] != null)
                {
                    model.hs_Discount = row["hs_Discount"].ToString();
                }
                if (row["hs_type"] != null && row["hs_type"].ToString() != "")
                {
                    model.hs_type = int.Parse(row["hs_type"].ToString());
                }
                if (row["hs_jgtype"] != null && row["hs_jgtype"].ToString() != "")
                {
                    model.hs_jgtype = int.Parse(row["hs_jgtype"].ToString());
                }
                if (row["hs_source_id"] != null && row["hs_source_id"].ToString() != "")
                {
                    model.hs_source_id = int.Parse(row["hs_source_id"].ToString());
                }
                if (row["Hs_isAll"] != null && row["Hs_isAll"].ToString() != "")
                {
                    if ((row["Hs_isAll"].ToString() == "1") || (row["Hs_isAll"].ToString().ToLower() == "true"))
                    {
                        model.Hs_isAll = true;
                    }
                    else
                    {
                        model.Hs_isAll = false;
                    }
                }
                if (row["Hs_Strat"] != null && row["Hs_Strat"].ToString() != "")
                {
                    model.Hs_Strat = DateTime.Parse(row["Hs_Strat"].ToString());
                }
                if (row["Hs_End"] != null && row["Hs_End"].ToString() != "")
                {
                    model.Hs_End = DateTime.Parse(row["Hs_End"].ToString());
                }
                if (row["Hs_zdr"] != null && row["Hs_zdr"].ToString() != "")
                {
                    model.Hs_zdr = decimal.Parse(row["Hs_zdr"].ToString());
                }
                if (row["Hs_Reamrk"] != null)
                {
                    model.Hs_Reamrk = row["Hs_Reamrk"].ToString();
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
            strSql.Append("select id,hs_room,hs_name,hs_psmoney,hs_Discount,hs_type,hs_jgtype,hs_source_id,Hs_isAll,Hs_Strat,Hs_End,Hs_zdr,Hs_Reamrk ");
            strSql.Append(" FROM hourse_scheme ");
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
            strSql.Append(" id,hs_room,hs_name,hs_psmoney,hs_Discount,hs_type,hs_jgtype,hs_source_id,Hs_isAll,Hs_Strat,Hs_End,Hs_zdr,Hs_Reamrk ");
            strSql.Append(" FROM hourse_scheme ");
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
            strSql.Append("select count(1) FROM hourse_scheme ");
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
            strSql.Append(")AS Row, T.*  from hourse_scheme T ");
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
            parameters[0].Value = "hourse_scheme";
            parameters[1].Value = "id";
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

