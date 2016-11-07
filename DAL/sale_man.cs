using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:sale_man
	/// </summary>
	public partial class sale_man
	{
		public sale_man()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("sale_man_id", "sale_man"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int sale_man_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sale_man");
			strSql.Append(" where sale_man_id=@sale_man_id");
			SqlParameter[] parameters = {
					new SqlParameter("@sale_man_id", SqlDbType.Int,4)
			};
			parameters[0].Value = sale_man_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CdHotelManage.Model.sale_man model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sale_man(");
			strSql.Append("sale_man_name,sale_man_money)");
			strSql.Append(" values (");
			strSql.Append("@sale_man_name,@sale_man_money)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@sale_man_name", SqlDbType.NVarChar,50),
					new SqlParameter("@sale_man_money", SqlDbType.Money,8)};
			parameters[0].Value = model.sale_man_name;
			parameters[1].Value = model.sale_man_money;

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
		public bool Update(CdHotelManage.Model.sale_man model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sale_man set ");
			strSql.Append("sale_man_name=@sale_man_name,");
			strSql.Append("sale_man_money=@sale_man_money");
			strSql.Append(" where sale_man_id=@sale_man_id");
			SqlParameter[] parameters = {
					new SqlParameter("@sale_man_name", SqlDbType.NVarChar,50),
					new SqlParameter("@sale_man_money", SqlDbType.Money,8),
					new SqlParameter("@sale_man_id", SqlDbType.Int,4)};
			parameters[0].Value = model.sale_man_name;
			parameters[1].Value = model.sale_man_money;
			parameters[2].Value = model.sale_man_id;

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
		public bool Delete(int sale_man_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sale_man ");
			strSql.Append(" where sale_man_id=@sale_man_id");
			SqlParameter[] parameters = {
					new SqlParameter("@sale_man_id", SqlDbType.Int,4)
			};
			parameters[0].Value = sale_man_id;

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
		public bool DeleteList(string sale_man_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sale_man ");
			strSql.Append(" where sale_man_id in ("+sale_man_idlist + ")  ");
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
		public CdHotelManage.Model.sale_man GetModel(int sale_man_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sale_man_id,sale_man_name,sale_man_money from sale_man ");
			strSql.Append(" where sale_man_id=@sale_man_id");
			SqlParameter[] parameters = {
					new SqlParameter("@sale_man_id", SqlDbType.Int,4)
			};
			parameters[0].Value = sale_man_id;

			CdHotelManage.Model.sale_man model=new CdHotelManage.Model.sale_man();
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
		public CdHotelManage.Model.sale_man DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.sale_man model=new CdHotelManage.Model.sale_man();
			if (row != null)
			{
				if(row["sale_man_id"]!=null && row["sale_man_id"].ToString()!="")
				{
					model.sale_man_id=int.Parse(row["sale_man_id"].ToString());
				}
				if(row["sale_man_name"]!=null)
				{
					model.sale_man_name=row["sale_man_name"].ToString();
				}
				if(row["sale_man_money"]!=null && row["sale_man_money"].ToString()!="")
				{
					model.sale_man_money=decimal.Parse(row["sale_man_money"].ToString());
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
			strSql.Append("select sale_man_id,sale_man_name,sale_man_money ");
			strSql.Append(" FROM sale_man ");
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
			strSql.Append(" sale_man_id,sale_man_name,sale_man_money ");
			strSql.Append(" FROM sale_man ");
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
			strSql.Append("select count(1) FROM sale_man ");
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
				strSql.Append("order by T.sale_man_id desc");
			}
			strSql.Append(")AS Row, T.*  from sale_man T ");
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
			parameters[0].Value = "sale_man";
			parameters[1].Value = "sale_man_id";
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

