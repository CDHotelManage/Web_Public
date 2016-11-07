using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:Repair
	/// </summary>
	public partial class Repair
	{
		public Repair()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("repair_id", "Repair"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int repair_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Repair");
			strSql.Append(" where repair_id=@repair_id");
			SqlParameter[] parameters = {
					new SqlParameter("@repair_id", SqlDbType.Int,4)
			};
			parameters[0].Value = repair_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CdHotelManage.Model.Repair model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Repair(");
			strSql.Append("repair_name,repair_time,repair_man,repair_num,repair_remark)");
			strSql.Append(" values (");
			strSql.Append("@repair_name,@repair_time,@repair_man,@repair_num,@repair_remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@repair_name", SqlDbType.NVarChar,50),
					new SqlParameter("@repair_time", SqlDbType.DateTime),
					new SqlParameter("@repair_man", SqlDbType.NVarChar,50),
					new SqlParameter("@repair_num", SqlDbType.Int,4),
					new SqlParameter("@repair_remark", SqlDbType.NVarChar,-1)};
			parameters[0].Value = model.repair_name;
			parameters[1].Value = model.repair_time;
			parameters[2].Value = model.repair_man;
			parameters[3].Value = model.repair_num;
			parameters[4].Value = model.repair_remark;

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
		public bool Update(CdHotelManage.Model.Repair model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Repair set ");
			strSql.Append("repair_name=@repair_name,");
			strSql.Append("repair_time=@repair_time,");
			strSql.Append("repair_man=@repair_man,");
			strSql.Append("repair_num=@repair_num,");
			strSql.Append("repair_remark=@repair_remark");
			strSql.Append(" where repair_id=@repair_id");
			SqlParameter[] parameters = {
					new SqlParameter("@repair_name", SqlDbType.NVarChar,50),
					new SqlParameter("@repair_time", SqlDbType.DateTime),
					new SqlParameter("@repair_man", SqlDbType.NVarChar,50),
					new SqlParameter("@repair_num", SqlDbType.Int,4),
					new SqlParameter("@repair_remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@repair_id", SqlDbType.Int,4)};
			parameters[0].Value = model.repair_name;
			parameters[1].Value = model.repair_time;
			parameters[2].Value = model.repair_man;
			parameters[3].Value = model.repair_num;
			parameters[4].Value = model.repair_remark;
			parameters[5].Value = model.repair_id;

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
		public bool Delete(int repair_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Repair ");
			strSql.Append(" where repair_id=@repair_id");
			SqlParameter[] parameters = {
					new SqlParameter("@repair_id", SqlDbType.Int,4)
			};
			parameters[0].Value = repair_id;

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
		public bool DeleteList(string repair_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Repair ");
			strSql.Append(" where repair_id in ("+repair_idlist + ")  ");
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
		public CdHotelManage.Model.Repair GetModel(int repair_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 repair_id,repair_name,repair_time,repair_man,repair_num,repair_remark from Repair ");
			strSql.Append(" where repair_id=@repair_id");
			SqlParameter[] parameters = {
					new SqlParameter("@repair_id", SqlDbType.Int,4)
			};
			parameters[0].Value = repair_id;

			CdHotelManage.Model.Repair model=new CdHotelManage.Model.Repair();
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
		public CdHotelManage.Model.Repair DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.Repair model=new CdHotelManage.Model.Repair();
			if (row != null)
			{
				if(row["repair_id"]!=null && row["repair_id"].ToString()!="")
				{
					model.repair_id=int.Parse(row["repair_id"].ToString());
				}
				if(row["repair_name"]!=null)
				{
					model.repair_name=row["repair_name"].ToString();
				}
				if(row["repair_time"]!=null && row["repair_time"].ToString()!="")
				{
					model.repair_time=DateTime.Parse(row["repair_time"].ToString());
				}
				if(row["repair_man"]!=null)
				{
					model.repair_man=row["repair_man"].ToString();
				}
				if(row["repair_num"]!=null && row["repair_num"].ToString()!="")
				{
					model.repair_num=int.Parse(row["repair_num"].ToString());
				}
				if(row["repair_remark"]!=null)
				{
					model.repair_remark=row["repair_remark"].ToString();
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
			strSql.Append("select repair_id,repair_name,repair_time,repair_man,repair_num,repair_remark ");
			strSql.Append(" FROM Repair ");
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
			strSql.Append(" repair_id,repair_name,repair_time,repair_man,repair_num,repair_remark ");
			strSql.Append(" FROM Repair ");
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
			strSql.Append("select count(1) FROM Repair ");
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
				strSql.Append("order by T.repair_id desc");
			}
			strSql.Append(")AS Row, T.*  from Repair T ");
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
			parameters[0].Value = "Repair";
			parameters[1].Value = "repair_id";
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

