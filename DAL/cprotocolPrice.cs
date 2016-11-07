using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
   public  class cprotocolPrice
    {
        public cprotocolPrice()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from cprotocolPrice");
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
        public int Add(CdHotelManage.Model.cprotocolPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into cprotocolPrice(");
            strSql.Append("Accounts,RoomType,Price,protoPrice,mothPrice,zdPrice,lcPrice,Breakfast,commission,CpID)");
            strSql.Append(" values (");
            strSql.Append("@Accounts,@RoomType,@Price,@protoPrice,@mothPrice,@zdPrice,@lcPrice,@Breakfast,@commission,@CpID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Accounts", SqlDbType.NVarChar,50),
					new SqlParameter("@RoomType", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Int,4),
					new SqlParameter("@protoPrice", SqlDbType.Int,4),
					new SqlParameter("@mothPrice", SqlDbType.Int,4),
					new SqlParameter("@zdPrice", SqlDbType.Float,4),
					new SqlParameter("@lcPrice", SqlDbType.Int,4),
					new SqlParameter("@Breakfast", SqlDbType.Int,4),
					new SqlParameter("@commission", SqlDbType.Int,4),
                    new SqlParameter("@CpID",SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.Accounts;
            parameters[1].Value = model.RoomType;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.protoPrice;
            parameters[4].Value = model.mothPrice;
            parameters[5].Value = model.zdPrice;
            parameters[6].Value = model.lcPrice;
            parameters[7].Value = model.Breakfast;
            parameters[8].Value = model.commission;
            parameters[9].Value = model.CpID;
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
        public bool Update(CdHotelManage.Model.cprotocolPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update cprotocolPrice set ");
            strSql.Append("Accounts=@Accounts,");
            strSql.Append("RoomType=@RoomType,");
            strSql.Append("Price=@Price,");
            strSql.Append("protoPrice=@protoPrice,");
            strSql.Append("mothPrice=@mothPrice,");
            strSql.Append("zdPrice=@zdPrice,");
            strSql.Append("lcPrice=@lcPrice,");
            strSql.Append("Breakfast=@Breakfast,");
            strSql.Append("commission=@commission,");
            strSql.Append("CpID=@CpID");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Accounts", SqlDbType.NVarChar,50),
					new SqlParameter("@RoomType", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Int,4),
					new SqlParameter("@protoPrice", SqlDbType.Int,4),
					new SqlParameter("@mothPrice", SqlDbType.Int,4),
					new SqlParameter("@zdPrice", SqlDbType.Float,4),
					new SqlParameter("@lcPrice", SqlDbType.Int,4),
					new SqlParameter("@Breakfast", SqlDbType.Int,4),
					new SqlParameter("@commission", SqlDbType.Int,4),
                    new SqlParameter("@CpID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Accounts;
            parameters[1].Value = model.RoomType;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.protoPrice;
            parameters[4].Value = model.mothPrice;
            parameters[5].Value = model.zdPrice;
            parameters[6].Value = model.lcPrice;
            parameters[7].Value = model.Breakfast;
            parameters[8].Value = model.commission;
            parameters[9].Value = model.CpID;
            parameters[10].Value = model.ID;

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
            strSql.Append("delete from cprotocolPrice ");
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
            strSql.Append("delete from cprotocolPrice ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteWhere(string sql)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(sql);
            
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
        public CdHotelManage.Model.cprotocolPrice GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Accounts,RoomType,Price,protoPrice,mothPrice,zdPrice,lcPrice,Breakfast,commission,CpID from cprotocolPrice ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            CdHotelManage.Model.cprotocolPrice model = new CdHotelManage.Model.cprotocolPrice();
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
        public CdHotelManage.Model.cprotocolPrice DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.cprotocolPrice model = new CdHotelManage.Model.cprotocolPrice();
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
                if (row["RoomType"] != null && row["RoomType"].ToString() != "")
                {
                    model.RoomType = int.Parse(row["RoomType"].ToString());
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = int.Parse(row["Price"].ToString());
                }
                if (row["protoPrice"] != null && row["protoPrice"].ToString() != "")
                {
                    model.protoPrice = int.Parse(row["protoPrice"].ToString());
                }
                if (row["mothPrice"] != null && row["mothPrice"].ToString() != "")
                {
                    model.mothPrice = int.Parse(row["mothPrice"].ToString());
                }
                if (row["zdPrice"] != null && row["zdPrice"].ToString() != "")
                {
                    model.zdPrice = float.Parse(row["zdPrice"].ToString());
                }
                if (row["lcPrice"] != null && row["lcPrice"].ToString() != "")
                {
                    model.lcPrice = int.Parse(row["lcPrice"].ToString());
                }
                if (row["Breakfast"] != null && row["Breakfast"].ToString() != "")
                {
                    model.Breakfast = int.Parse(row["Breakfast"].ToString());
                }
                if (row["commission"] != null && row["commission"].ToString() != "")
                {
                    model.commission = int.Parse(row["commission"].ToString());
                }
                if (row["CpID"] != null && row["CpID"].ToString() != "")
                {
                    model.CpID = int.Parse(row["CpID"].ToString());
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
            strSql.Append("select ID,Accounts,RoomType,Price,protoPrice,mothPrice,zdPrice,lcPrice,Breakfast,commission,CpID ");
            strSql.Append(" FROM cprotocolPrice ");
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
            strSql.Append(" ID,Accounts,RoomType,Price,protoPrice,mothPrice,zdPrice,lcPrice,Breakfast,commission,CpID ");
            strSql.Append(" FROM cprotocolPrice ");
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
            strSql.Append("select count(1) FROM cprotocolPrice ");
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
            strSql.Append(")AS Row, T.*  from cprotocolPrice T ");
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
            parameters[0].Value = "cprotocolPrice";
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
