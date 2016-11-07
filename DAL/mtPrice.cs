using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace CdHotelManage.DAL
{
    public class mtPrice
    {
        public mtPrice()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from mtPrice");
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
        public int Add(CdHotelManage.Model.mtPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into mtPrice(");
            strSql.Append("MTID,RoomType,Price,Dayprice,zdPrice,lcPrice,mothPrice)");
            strSql.Append(" values (");
            strSql.Append("@MTID,@RoomType,@Price,@Dayprice,@zdPrice,@lcPrice,@mothPrice)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MTID", SqlDbType.Int,4),
					new SqlParameter("@RoomType", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Int,4),
					new SqlParameter("@Dayprice", SqlDbType.Int,4),
					new SqlParameter("@zdPrice", SqlDbType.Float,4),
					new SqlParameter("@lcPrice", SqlDbType.Int,4),
					new SqlParameter("@mothPrice", SqlDbType.NChar,10)};
            parameters[0].Value = model.MTID;
            parameters[1].Value = model.RoomType;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.Dayprice;
            parameters[4].Value = model.zdPrice;
            parameters[5].Value = model.lcPrice;
            parameters[6].Value = model.mothPrice;

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
        public bool Update(CdHotelManage.Model.mtPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mtPrice set ");
            strSql.Append("MTID=@MTID,");
            strSql.Append("RoomType=@RoomType,");
            strSql.Append("Price=@Price,");
            strSql.Append("Dayprice=@Dayprice,");
            strSql.Append("zdPrice=@zdPrice,");
            strSql.Append("lcPrice=@lcPrice,");
            strSql.Append("mothPrice=@mothPrice");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@MTID", SqlDbType.Int,4),
					new SqlParameter("@RoomType", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Int,4),
					new SqlParameter("@Dayprice", SqlDbType.Int,4),
					new SqlParameter("@zdPrice", SqlDbType.Float,4),
					new SqlParameter("@lcPrice", SqlDbType.Int,4),
					new SqlParameter("@mothPrice", SqlDbType.NChar,10),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.MTID;
            parameters[1].Value = model.RoomType;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.Dayprice;
            parameters[4].Value = model.zdPrice;
            parameters[5].Value = model.lcPrice;
            parameters[6].Value = model.mothPrice;
            parameters[7].Value = model.ID;

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
            strSql.Append("delete from mtPrice ");
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
            strSql.Append("delete from mtPrice ");
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
        public CdHotelManage.Model.mtPrice GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,MTID,RoomType,Price,Dayprice,zdPrice,lcPrice,mothPrice from mtPrice ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            CdHotelManage.Model.mtPrice model = new CdHotelManage.Model.mtPrice();
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
        public CdHotelManage.Model.mtPrice DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.mtPrice model = new CdHotelManage.Model.mtPrice();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["MTID"] != null && row["MTID"].ToString() != "")
                {
                    model.MTID = int.Parse(row["MTID"].ToString());
                }
                if (row["RoomType"] != null && row["RoomType"].ToString() != "")
                {
                    model.RoomType = int.Parse(row["RoomType"].ToString());
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = int.Parse(row["Price"].ToString());
                }
                if (row["Dayprice"] != null && row["Dayprice"].ToString() != "")
                {
                    model.Dayprice = int.Parse(row["Dayprice"].ToString());
                }
                if (row["zdPrice"] != null && row["zdPrice"].ToString() != "")
                {
                    model.zdPrice =  float.Parse(row["zdPrice"].ToString());
                }
                if (row["lcPrice"] != null && row["lcPrice"].ToString() != "")
                {
                    model.lcPrice = int.Parse(row["lcPrice"].ToString());
                }
                if (row["mothPrice"] != null)
                {
                    model.mothPrice = row["mothPrice"].ToString();
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
            strSql.Append("select ID,MTID,RoomType,Price,Dayprice,zdPrice,lcPrice,mothPrice ");
            strSql.Append(" FROM mtPrice ");
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
            strSql.Append(" ID,MTID,RoomType,Price,Dayprice,zdPrice,lcPrice,mothPrice ");
            strSql.Append(" FROM mtPrice ");
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
            strSql.Append("select count(1) FROM mtPrice ");
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
            strSql.Append(")AS Row, T.*  from mtPrice T ");
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
            parameters[0].Value = "mtPrice";
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
