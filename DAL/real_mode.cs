using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:real_mode
	/// </summary>
	public partial class real_mode
	{
		public real_mode()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("real_mode_id", "real_mode"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int real_mode_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from real_mode");
			strSql.Append(" where real_mode_id=@real_mode_id");
			SqlParameter[] parameters = {
					new SqlParameter("@real_mode_id", SqlDbType.Int,4)
			};
			parameters[0].Value = real_mode_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CdHotelManage.Model.real_mode model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into real_mode(");
			strSql.Append("real_mode_name,remark)");
			strSql.Append(" values (");
			strSql.Append("@real_mode_name,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@real_mode_name", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1)};
			parameters[0].Value = model.real_mode_name;
			parameters[1].Value = model.remark;

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
		public bool Update(CdHotelManage.Model.real_mode model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update real_mode set ");
			strSql.Append("real_mode_name=@real_mode_name,");
			strSql.Append("remark=@remark");
			strSql.Append(" where real_mode_id=@real_mode_id");
			SqlParameter[] parameters = {
					new SqlParameter("@real_mode_name", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@real_mode_id", SqlDbType.Int,4)};
			parameters[0].Value = model.real_mode_name;
			parameters[1].Value = model.remark;
			parameters[2].Value = model.real_mode_id;

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
		public bool Delete(int real_mode_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from real_mode ");
			strSql.Append(" where real_mode_id=@real_mode_id");
			SqlParameter[] parameters = {
					new SqlParameter("@real_mode_id", SqlDbType.Int,4)
			};
			parameters[0].Value = real_mode_id;

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
		public bool DeleteList(string real_mode_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from real_mode ");
			strSql.Append(" where real_mode_id in ("+real_mode_idlist + ")  ");
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
		public CdHotelManage.Model.real_mode GetModel(int real_mode_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 real_mode_id,real_mode_name,remark from real_mode ");
			strSql.Append(" where real_mode_id=@real_mode_id");
			SqlParameter[] parameters = {
					new SqlParameter("@real_mode_id", SqlDbType.Int,4)
			};
			parameters[0].Value = real_mode_id;

			CdHotelManage.Model.real_mode model=new CdHotelManage.Model.real_mode();
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
		public CdHotelManage.Model.real_mode DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.real_mode model=new CdHotelManage.Model.real_mode();
			if (row != null)
			{
				if(row["real_mode_id"]!=null && row["real_mode_id"].ToString()!="")
				{
					model.real_mode_id=int.Parse(row["real_mode_id"].ToString());
				}
				if(row["real_mode_name"]!=null)
				{
					model.real_mode_name=row["real_mode_name"].ToString();
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
			strSql.Append("select real_mode_id,real_mode_name,remark ");
			strSql.Append(" FROM real_mode ");
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
			strSql.Append(" real_mode_id,real_mode_name,remark ");
			strSql.Append(" FROM real_mode ");
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
			strSql.Append("select count(1) FROM real_mode ");
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
				strSql.Append("order by T.real_mode_id desc");
			}
			strSql.Append(")AS Row, T.*  from real_mode T ");
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
			parameters[0].Value = "real_mode";
			parameters[1].Value = "real_mode_id";
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

