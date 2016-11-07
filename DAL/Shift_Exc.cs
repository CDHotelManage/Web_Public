using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:Shift_Exc
	/// </summary>
	public partial class Shift_Exc
	{
		public Shift_Exc()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "Shift_Exc"); 
		}


        /*获得不同类型的收款方式所产生的金额*/
        public DataSet GetAllBydays(string strWhere)
        {
            System.Text.StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(ga_price),ga_zffs_id from Shift_Exc");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null)
            {
                return ds;
            }
            return null;
        }


        /// <summary>
        /// 根据条件获得所有的收款方式
        /// </summary>
        public string GeMethPayType(string strWhere)
        {
            System.Text.StringBuilder strSql = new StringBuilder();
            strSql.Append("select ga_zffs_id from Shift_Exc");
            System.Text.StringBuilder sbMeth = new StringBuilder();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = new DataSet();
            ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sbMeth.Append(dr["ga_zffs_id"] + ",");
                }
            }
            return sbMeth.ToString();
        }


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shift_Exc");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CdHotelManage.Model.Shift_Exc model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shift_Exc(");
            strSql.Append("UserId,Good_Account_Id,meth_pay_id,shift_id,shift_state,shift_money,shift_dateTime,ga_name,ga_number,ga_unit,ga_num,ga_price,ga_zffs_id,ga_date,ga_Type,ga_sum_price,Remark,ga_roomNumber)");
			strSql.Append(" values (");
            strSql.Append("@UserId,@Good_Account_Id,@meth_pay_id,@shift_id,@shift_state,@shift_money,@shift_dateTime,@ga_name,@ga_number,@ga_unit,@ga_num,@ga_price,@ga_zffs_id,@ga_date,@ga_Type,@ga_sum_price,@Remark,@ga_roomNumber)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Good_Account_Id", SqlDbType.Int,4),
					new SqlParameter("@meth_pay_id", SqlDbType.Int,4),
					new SqlParameter("@shift_id", SqlDbType.Int,4),
					new SqlParameter("@shift_state", SqlDbType.NVarChar,50),
					new SqlParameter("@shift_money", SqlDbType.Money,8),
					new SqlParameter("@shift_dateTime", SqlDbType.DateTime),
					new SqlParameter("@ga_name", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_number", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_unit", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_num", SqlDbType.Int,4),
					new SqlParameter("@ga_price", SqlDbType.Money,8),
					new SqlParameter("@ga_zffs_id", SqlDbType.Int,4),
					new SqlParameter("@ga_date", SqlDbType.DateTime),
					new SqlParameter("@ga_Type", SqlDbType.Int,4),
					new SqlParameter("@ga_sum_price", SqlDbType.Money,8),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
                    new SqlParameter("@ga_roomNumber", SqlDbType.NVarChar,50),};
           
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.Good_Account_Id;
			parameters[2].Value = model.meth_pay_id;
			parameters[3].Value = model.shift_id;
			parameters[4].Value = model.shift_state;
			parameters[5].Value = model.shift_money;
			parameters[6].Value = model.shift_dateTime;
			parameters[7].Value = model.ga_name;
			parameters[8].Value = model.ga_number;
			parameters[9].Value = model.ga_unit;
			parameters[10].Value = model.ga_num;
			parameters[11].Value = model.ga_price;
			parameters[12].Value = model.ga_zffs_id;
			parameters[13].Value = model.ga_date;
			parameters[14].Value = model.ga_Type;
			parameters[15].Value = model.ga_sum_price;
			parameters[16].Value = model.Remark;
            parameters[17].Value = model.ga_roomNumber;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(CdHotelManage.Model.Shift_Exc model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shift_Exc set ");
			strSql.Append("UserId=@UserId,");
			strSql.Append("Good_Account_Id=@Good_Account_Id,");
			strSql.Append("meth_pay_id=@meth_pay_id,");
			strSql.Append("shift_id=@shift_id,");
			strSql.Append("shift_state=@shift_state,");
			strSql.Append("shift_money=@shift_money,");
			strSql.Append("shift_dateTime=@shift_dateTime,");
			strSql.Append("ga_name=@ga_name,");
			strSql.Append("ga_number=@ga_number,");
			strSql.Append("ga_unit=@ga_unit,");
			strSql.Append("ga_num=@ga_num,");
			strSql.Append("ga_price=@ga_price,");
			strSql.Append("ga_zffs_id=@ga_zffs_id,");
			strSql.Append("ga_date=@ga_date,");
			strSql.Append("ga_Type=@ga_Type,");
			strSql.Append("ga_sum_price=@ga_sum_price,");
			strSql.Append("Remark=@Remark");
            strSql.Append("ga_roomNumber=@ga_roomNumber");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Good_Account_Id", SqlDbType.Int,4),
					new SqlParameter("@meth_pay_id", SqlDbType.Int,4),
					new SqlParameter("@shift_id", SqlDbType.Int,4),
					new SqlParameter("@shift_state", SqlDbType.NVarChar,50),
					new SqlParameter("@shift_money", SqlDbType.Money,8),
					new SqlParameter("@shift_dateTime", SqlDbType.DateTime),
					new SqlParameter("@ga_name", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_number", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_unit", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_num", SqlDbType.Int,4),
					new SqlParameter("@ga_price", SqlDbType.Money,8),
					new SqlParameter("@ga_zffs_id", SqlDbType.Int,4),
					new SqlParameter("@ga_date", SqlDbType.DateTime),
					new SqlParameter("@ga_Type", SqlDbType.Int,4),
					new SqlParameter("@ga_sum_price", SqlDbType.Money,8),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
                    new SqlParameter("@ga_roomNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.Good_Account_Id;
			parameters[2].Value = model.meth_pay_id;
			parameters[3].Value = model.shift_id;
			parameters[4].Value = model.shift_state;
			parameters[5].Value = model.shift_money;
			parameters[6].Value = model.shift_dateTime;
			parameters[7].Value = model.ga_name;
			parameters[8].Value = model.ga_number;
			parameters[9].Value = model.ga_unit;
			parameters[10].Value = model.ga_num;
			parameters[11].Value = model.ga_price;
			parameters[12].Value = model.ga_zffs_id;
			parameters[13].Value = model.ga_date;
			parameters[14].Value = model.ga_Type;
			parameters[15].Value = model.ga_sum_price;
			parameters[16].Value = model.Remark;
            parameters[17].Value = model.ga_roomNumber;
			parameters[18].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shift_Exc ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shift_Exc ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

        public int DeleteAll() {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shift_Exc ");
            return  DbHelperSQL.ExecuteSql(strSql.ToString());
            
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.Shift_Exc GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 Id,UserId,Good_Account_Id,meth_pay_id,shift_id,shift_state,shift_money,shift_dateTime,ga_name,ga_number,ga_unit,ga_num,ga_price,ga_zffs_id,ga_date,ga_Type,ga_sum_price,Remark,ga_roomNumber from Shift_Exc ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			CdHotelManage.Model.Shift_Exc model=new CdHotelManage.Model.Shift_Exc();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public CdHotelManage.Model.Shift_Exc DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.Shift_Exc model=new CdHotelManage.Model.Shift_Exc();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(row["UserId"].ToString());
				}
				if(row["Good_Account_Id"]!=null && row["Good_Account_Id"].ToString()!="")
				{
					model.Good_Account_Id=int.Parse(row["Good_Account_Id"].ToString());
				}
				if(row["meth_pay_id"]!=null && row["meth_pay_id"].ToString()!="")
				{
					model.meth_pay_id=int.Parse(row["meth_pay_id"].ToString());
				}
				if(row["shift_id"]!=null && row["shift_id"].ToString()!="")
				{
					model.shift_id=int.Parse(row["shift_id"].ToString());
				}
				if(row["shift_state"]!=null)
				{
					model.shift_state=row["shift_state"].ToString();
				}
				if(row["shift_money"]!=null && row["shift_money"].ToString()!="")
				{
					model.shift_money=decimal.Parse(row["shift_money"].ToString());
				}
				if(row["shift_dateTime"]!=null && row["shift_dateTime"].ToString()!="")
				{
					model.shift_dateTime=DateTime.Parse(row["shift_dateTime"].ToString());
				}
				if(row["ga_name"]!=null)
				{
					model.ga_name=row["ga_name"].ToString();
				}
				if(row["ga_number"]!=null)
				{
					model.ga_number=row["ga_number"].ToString();
				}
				if(row["ga_unit"]!=null)
				{
					model.ga_unit=row["ga_unit"].ToString();
				}
				if(row["ga_num"]!=null && row["ga_num"].ToString()!="")
				{
					model.ga_num=int.Parse(row["ga_num"].ToString());
				}
				if(row["ga_price"]!=null && row["ga_price"].ToString()!="")
				{
					model.ga_price=decimal.Parse(row["ga_price"].ToString());
				}
				if(row["ga_zffs_id"]!=null && row["ga_zffs_id"].ToString()!="")
				{
					model.ga_zffs_id=int.Parse(row["ga_zffs_id"].ToString());
				}
				if(row["ga_date"]!=null && row["ga_date"].ToString()!="")
				{
					model.ga_date=DateTime.Parse(row["ga_date"].ToString());
				}
				if(row["ga_Type"]!=null && row["ga_Type"].ToString()!="")
				{
					model.ga_Type=int.Parse(row["ga_Type"].ToString());
				}
				if(row["ga_sum_price"]!=null && row["ga_sum_price"].ToString()!="")
				{
					model.ga_sum_price=decimal.Parse(row["ga_sum_price"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
                if (row["ga_roomNumber"] != null)
                {
                    model.ga_roomNumber = row["ga_roomNumber"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select Id,UserId,Good_Account_Id,meth_pay_id,shift_id,shift_state,shift_money,shift_dateTime,ga_name,ga_number,ga_unit,ga_num,ga_price,ga_zffs_id,ga_date,ga_Type,ga_sum_price,Remark,ga_roomNumber ");
			strSql.Append(" FROM Shift_Exc ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" Id,UserId,Good_Account_Id,meth_pay_id,shift_id,shift_state,shift_money,shift_dateTime,ga_name,ga_number,ga_unit,ga_num,ga_price,ga_zffs_id,ga_date,ga_Type,ga_sum_price,Remark,ga_roomNumber ");
			strSql.Append(" FROM Shift_Exc ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Shift_Exc ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from Shift_Exc T ");
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
			parameters[0].Value = "Shift_Exc";
			parameters[1].Value = "Id";
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


        /// <summary>
        /// 根据ID获得支付方式和总现金
        /// </summary>
        public DataSet GeMethPaySumMoney(string strWhere)
        {
            string strSql = "select b.meth_pay_id, b.meth_pay_name, sum(a.ga_price) as ga_sum_price  from Shift_Exc a inner join meth_pay b on a.ga_zffs_id = b.meth_pay_id  " + strWhere + " group by b.meth_pay_name,b.meth_pay_id ";

            return DbHelperSQL.Query(strSql.ToString());
        }

        //根据登录ID和支付方式查询明细
        public DataSet GeMethPayMoney(string strWhere)
        {
            string strSql = "select *  from goods_account  " + strWhere + " ";

            return DbHelperSQL.Query(strSql.ToString());
        }

        //根据条件查询支付明细并且进行分页
        public DataSet GeMethPayMoneyPage(string sort, string order, int currentPage, int pageSize, string strWhere)
        {
            string _sql = @" select * from (select *,Row_number() over(order by " + sort + " " + order + ") as IDShift_Exc from Shift_Exc " + strWhere + ") as IDWithRowNumber where IDShift_Exc>=(" + currentPage + "-1)*" + pageSize + "+1 and IDShift_Exc<=" + currentPage + "*" + pageSize + "";
            return DbHelperSQL.Query(_sql);
        }

	}
}

