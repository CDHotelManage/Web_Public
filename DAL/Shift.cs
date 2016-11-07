using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:Shift
	/// </summary>
	public partial class Shift
	{
		public Shift()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("shift_id", "Shift"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int shift_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shift");
			strSql.Append(" where shift_id=@shift_id");
			SqlParameter[] parameters = {
					new SqlParameter("@shift_id", SqlDbType.Int,4)
			};
			parameters[0].Value = shift_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CdHotelManage.Model.Shift model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shift(");
			strSql.Append("user_id,goods_account_id,shfit_name,remark)");
			strSql.Append(" values (");
			strSql.Append("@user_id,@goods_account_id,@shfit_name,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@goods_account_id", SqlDbType.Int,4),
					new SqlParameter("@shfit_name", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.goods_account_id;
			parameters[2].Value = model.shfit_name;
			parameters[3].Value = model.remark;

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
		public bool Update(CdHotelManage.Model.Shift model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shift set ");
			strSql.Append("user_id=@user_id,");
			strSql.Append("goods_account_id=@goods_account_id,");
			strSql.Append("shfit_name=@shfit_name,");
			strSql.Append("remark=@remark");
			strSql.Append(" where shift_id=@shift_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@goods_account_id", SqlDbType.Int,4),
					new SqlParameter("@shfit_name", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@shift_id", SqlDbType.Int,4)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.goods_account_id;
			parameters[2].Value = model.shfit_name;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.shift_id;

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
		public bool Delete(int shift_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shift ");
			strSql.Append(" where shift_id=@shift_id");
			SqlParameter[] parameters = {
					new SqlParameter("@shift_id", SqlDbType.Int,4)
			};
			parameters[0].Value = shift_id;

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
		public bool DeleteList(string shift_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shift ");
			strSql.Append(" where shift_id in ("+shift_idlist + ")  ");
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


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.Shift GetModel(int shift_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 shift_id,user_id,goods_account_id,shfit_name,remark from Shift ");
			strSql.Append(" where shift_id=@shift_id");
			SqlParameter[] parameters = {
					new SqlParameter("@shift_id", SqlDbType.Int,4)
			};
			parameters[0].Value = shift_id;

			CdHotelManage.Model.Shift model=new CdHotelManage.Model.Shift();
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
		public CdHotelManage.Model.Shift DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.Shift model=new CdHotelManage.Model.Shift();
			if (row != null)
			{
				if(row["shift_id"]!=null && row["shift_id"].ToString()!="")
				{
					model.shift_id=int.Parse(row["shift_id"].ToString());
				}
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(row["user_id"].ToString());
				}
				if(row["goods_account_id"]!=null && row["goods_account_id"].ToString()!="")
				{
					model.goods_account_id=int.Parse(row["goods_account_id"].ToString());
				}
				if(row["shfit_name"]!=null)
				{
					model.shfit_name=row["shfit_name"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
			strSql.Append("select shift_id,user_id,goods_account_id,shfit_name,remark ");
			strSql.Append(" FROM Shift ");
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
			strSql.Append(" shift_id,user_id,goods_account_id,shfit_name,remark ");
			strSql.Append(" FROM Shift ");
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
			strSql.Append("select count(1) FROM Shift ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
				strSql.Append("order by T.shift_id desc");
			}
			strSql.Append(")AS Row, T.*  from Shift T ");
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
			parameters[0].Value = "Shift";
			parameters[1].Value = "shift_id";
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

