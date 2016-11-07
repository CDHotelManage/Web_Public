using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;

namespace CdHotelManage.DAL
{
    public class account_goods
    {
        public account_goods()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CdHotelManage.Model.account_goods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into account_goods(");
            strSql.Append("ga_name,ga_Account,ga_number,ga_roomNumber,ga_unit,ga_num,ga_price,ga_zffs_id,ga_date,ga_people,ga_Type,ga_sum_price,ga_remker,ga_occuid,ga_sfacount,ga_isjz,ga_goodNo,ga_isys)");
            strSql.Append(" values (");
            strSql.Append("@ga_name,@ga_Account,@ga_number,@ga_roomNumber,@ga_unit,@ga_num,@ga_price,@ga_zffs_id,@ga_date,@ga_people,@ga_Type,@ga_sum_price,@ga_remker,@ga_occuid,@ga_sfacount,@ga_isjz,@ga_goodNo,@ga_isys)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ga_name", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_Account", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_number", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_roomNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_unit", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_num", SqlDbType.Int,4),
					new SqlParameter("@ga_price", SqlDbType.Decimal,9),
					new SqlParameter("@ga_zffs_id", SqlDbType.Int,4),
					new SqlParameter("@ga_date", SqlDbType.DateTime),
					new SqlParameter("@ga_people", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_Type", SqlDbType.Int,4),
					new SqlParameter("@ga_sum_price", SqlDbType.Decimal,9),
					new SqlParameter("@ga_remker", SqlDbType.NVarChar,-1),
					new SqlParameter("@ga_occuid", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_sfacount", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_isjz", SqlDbType.Int,4),
					new SqlParameter("@ga_goodNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_isys", SqlDbType.Int,4)};
            parameters[0].Value = model.ga_name;
            parameters[1].Value = model.ga_Account;
            parameters[2].Value = model.ga_number;
            parameters[3].Value = model.ga_roomNumber;
            parameters[4].Value = model.ga_unit;
            parameters[5].Value = model.ga_num;
            parameters[6].Value = model.ga_price;
            parameters[7].Value = model.ga_zffs_id;
            parameters[8].Value = model.ga_date;
            parameters[9].Value = model.ga_people;
            parameters[10].Value = model.ga_Type;
            parameters[11].Value = model.ga_sum_price;
            parameters[12].Value = model.ga_remker;
            parameters[13].Value = model.ga_occuid;
            parameters[14].Value = model.ga_sfacount;
            parameters[15].Value = model.ga_isjz;
            parameters[16].Value = model.ga_goodNo;
            parameters[17].Value = model.ga_isys;

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
        public bool Update(CdHotelManage.Model.account_goods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update account_goods set ");
            strSql.Append("ga_name=@ga_name,");
            strSql.Append("ga_Account=@ga_Account,");
            strSql.Append("ga_number=@ga_number,");
            strSql.Append("ga_roomNumber=@ga_roomNumber,");
            strSql.Append("ga_unit=@ga_unit,");
            strSql.Append("ga_num=@ga_num,");
            strSql.Append("ga_price=@ga_price,");
            strSql.Append("ga_zffs_id=@ga_zffs_id,");
            strSql.Append("ga_date=@ga_date,");
            strSql.Append("ga_people=@ga_people,");
            strSql.Append("ga_Type=@ga_Type,");
            strSql.Append("ga_sum_price=@ga_sum_price,");
            strSql.Append("ga_remker=@ga_remker,");
            strSql.Append("ga_occuid=@ga_occuid,");
            strSql.Append("ga_sfacount=@ga_sfacount,");
            strSql.Append("ga_isjz=@ga_isjz,");
            strSql.Append("ga_goodNo=@ga_goodNo,");
            strSql.Append("ga_isys=@ga_isys");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@ga_name", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_Account", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_number", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_roomNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_unit", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_num", SqlDbType.Int,4),
					new SqlParameter("@ga_price", SqlDbType.Decimal,9),
					new SqlParameter("@ga_zffs_id", SqlDbType.Int,4),
					new SqlParameter("@ga_date", SqlDbType.DateTime),
					new SqlParameter("@ga_people", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_Type", SqlDbType.Int,4),
					new SqlParameter("@ga_sum_price", SqlDbType.Decimal,9),
					new SqlParameter("@ga_remker", SqlDbType.NVarChar,-1),
					new SqlParameter("@ga_occuid", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_sfacount", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_isjz", SqlDbType.Int,4),
					new SqlParameter("@ga_goodNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_isys", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.ga_name;
            parameters[1].Value = model.ga_Account;
            parameters[2].Value = model.ga_number;
            parameters[3].Value = model.ga_roomNumber;
            parameters[4].Value = model.ga_unit;
            parameters[5].Value = model.ga_num;
            parameters[6].Value = model.ga_price;
            parameters[7].Value = model.ga_zffs_id;
            parameters[8].Value = model.ga_date;
            parameters[9].Value = model.ga_people;
            parameters[10].Value = model.ga_Type;
            parameters[11].Value = model.ga_sum_price;
            parameters[12].Value = model.ga_remker;
            parameters[13].Value = model.ga_occuid;
            parameters[14].Value = model.ga_sfacount;
            parameters[15].Value = model.ga_isjz;
            parameters[16].Value = model.ga_goodNo;
            parameters[17].Value = model.ga_isys;
            parameters[18].Value = model.id;

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
            strSql.Append("delete from account_goods ");
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
            strSql.Append("delete from account_goods ");
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
        public CdHotelManage.Model.account_goods GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ga_name,ga_Account,ga_number,ga_roomNumber,ga_unit,ga_num,ga_price,ga_zffs_id,ga_date,ga_people,ga_Type,ga_sum_price,ga_remker,ga_occuid,ga_sfacount,ga_isjz,ga_goodNo,ga_isys from account_goods ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            CdHotelManage.Model.account_goods model = new CdHotelManage.Model.account_goods();
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
        public CdHotelManage.Model.account_goods DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.account_goods model = new CdHotelManage.Model.account_goods();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["ga_name"] != null)
                {
                    model.ga_name = row["ga_name"].ToString();
                }
                if (row["ga_Account"] != null)
                {
                    model.ga_Account = row["ga_Account"].ToString();
                }
                if (row["ga_number"] != null)
                {
                    model.ga_number = row["ga_number"].ToString();
                }
                if (row["ga_roomNumber"] != null)
                {
                    model.ga_roomNumber = row["ga_roomNumber"].ToString();
                }
                if (row["ga_unit"] != null)
                {
                    model.ga_unit = row["ga_unit"].ToString();
                }
                if (row["ga_num"] != null && row["ga_num"].ToString() != "")
                {
                    model.ga_num = int.Parse(row["ga_num"].ToString());
                }
                if (row["ga_price"] != null && row["ga_price"].ToString() != "")
                {
                    model.ga_price = decimal.Parse(row["ga_price"].ToString());
                }
                if (row["ga_zffs_id"] != null && row["ga_zffs_id"].ToString() != "")
                {
                    model.ga_zffs_id = int.Parse(row["ga_zffs_id"].ToString());
                }
                if (row["ga_date"] != null && row["ga_date"].ToString() != "")
                {
                    model.ga_date = DateTime.Parse(row["ga_date"].ToString());
                }
                if (row["ga_people"] != null)
                {
                    model.ga_people = row["ga_people"].ToString();
                }
                if (row["ga_Type"] != null && row["ga_Type"].ToString() != "")
                {
                    model.ga_Type = int.Parse(row["ga_Type"].ToString());
                }
                if (row["ga_sum_price"] != null && row["ga_sum_price"].ToString() != "")
                {
                    model.ga_sum_price = decimal.Parse(row["ga_sum_price"].ToString());
                }
                if (row["ga_remker"] != null)
                {
                    model.ga_remker = row["ga_remker"].ToString();
                }
                if (row["ga_occuid"] != null)
                {
                    model.ga_occuid = row["ga_occuid"].ToString();
                }
                if (row["ga_sfacount"] != null)
                {
                    model.ga_sfacount = row["ga_sfacount"].ToString();
                }
                if (row["ga_isjz"] != null && row["ga_isjz"].ToString() != "")
                {
                    model.ga_isjz = int.Parse(row["ga_isjz"].ToString());
                }
                if (row["ga_goodNo"] != null)
                {
                    model.ga_goodNo = row["ga_goodNo"].ToString();
                }
                if (row["ga_isys"] != null && row["ga_isys"].ToString() != "")
                {
                    model.ga_isys = int.Parse(row["ga_isys"].ToString());
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
            strSql.Append("select id,ga_name,ga_Account,ga_number,ga_roomNumber,ga_unit,ga_num,ga_price,ga_zffs_id,ga_date,ga_people,ga_Type,ga_sum_price,ga_remker,ga_occuid,ga_sfacount,ga_isjz,ga_goodNo,ga_isys ");
            strSql.Append(" FROM account_goods ");
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
            strSql.Append(" id,ga_name,ga_Account,ga_number,ga_roomNumber,ga_unit,ga_num,ga_price,ga_zffs_id,ga_date,ga_people,ga_Type,ga_sum_price,ga_remker,ga_occuid,ga_sfacount,ga_isjz,ga_goodNo,ga_isys ");
            strSql.Append(" FROM account_goods ");
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
            strSql.Append("select count(1) FROM account_goods ");
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
            strSql.Append(")AS Row, T.*  from account_goods T ");
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
            parameters[0].Value = "account_goods";
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
