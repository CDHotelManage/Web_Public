using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:room_feature
	/// </summary>
	public partial class room_feature
	{
		public room_feature()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("room_feature_id", "room_feature"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int room_feature_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from room_feature");
			strSql.Append(" where room_feature_id=@room_feature_id");
			SqlParameter[] parameters = {
					new SqlParameter("@room_feature_id", SqlDbType.Int,4)
			};
			parameters[0].Value = room_feature_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CdHotelManage.Model.room_feature model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into room_feature(");
			strSql.Append("room_feature_name,remark)");
			strSql.Append(" values (");
			strSql.Append("@room_feature_name,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@room_feature_name", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1)};
			parameters[0].Value = model.room_feature_name;
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
		public bool Update(CdHotelManage.Model.room_feature model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update room_feature set ");
			strSql.Append("room_feature_name=@room_feature_name,");
			strSql.Append("remark=@remark");
			strSql.Append(" where room_feature_id=@room_feature_id");
			SqlParameter[] parameters = {
					new SqlParameter("@room_feature_name", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@room_feature_id", SqlDbType.Int,4)};
			parameters[0].Value = model.room_feature_name;
			parameters[1].Value = model.remark;
			parameters[2].Value = model.room_feature_id;

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
		public bool Delete(int room_feature_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from room_feature ");
			strSql.Append(" where room_feature_id=@room_feature_id");
			SqlParameter[] parameters = {
					new SqlParameter("@room_feature_id", SqlDbType.Int,4)
			};
			parameters[0].Value = room_feature_id;

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
		public bool DeleteList(string room_feature_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from room_feature ");
			strSql.Append(" where room_feature_id in ("+room_feature_idlist + ")  ");
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
		public CdHotelManage.Model.room_feature GetModel(int room_feature_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 room_feature_id,room_feature_name,remark from room_feature ");
			strSql.Append(" where room_feature_id=@room_feature_id");
			SqlParameter[] parameters = {
					new SqlParameter("@room_feature_id", SqlDbType.Int,4)
			};
			parameters[0].Value = room_feature_id;

			CdHotelManage.Model.room_feature model=new CdHotelManage.Model.room_feature();
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
		public CdHotelManage.Model.room_feature DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.room_feature model=new CdHotelManage.Model.room_feature();
			if (row != null)
			{
				if(row["room_feature_id"]!=null && row["room_feature_id"].ToString()!="")
				{
					model.room_feature_id=int.Parse(row["room_feature_id"].ToString());
				}
				if(row["room_feature_name"]!=null)
				{
					model.room_feature_name=row["room_feature_name"].ToString();
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
			strSql.Append("select room_feature_id,room_feature_name,remark ");
			strSql.Append(" FROM room_feature ");
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
			strSql.Append(" room_feature_id,room_feature_name,remark ");
			strSql.Append(" FROM room_feature ");
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
			strSql.Append("select count(1) FROM room_feature ");
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
				strSql.Append("order by T.room_feature_id desc");
			}
			strSql.Append(")AS Row, T.*  from room_feature T ");
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
			parameters[0].Value = "room_feature";
			parameters[1].Value = "room_feature_id";
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

