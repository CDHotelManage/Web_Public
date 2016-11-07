using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:room_type_image
	/// </summary>
	public partial class room_type_imageDAL
	{
		public room_type_imageDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string imgid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from room_type_image");
			strSql.Append(" where imgid=@imgid ");
			SqlParameter[] parameters = {
					new SqlParameter("@imgid", SqlDbType.NVarChar,50)			};
			parameters[0].Value = imgid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CdHotelManage.Model.room_type_image model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into room_type_image(");
			strSql.Append("imgid,typeid,imgurl,sortId,pubdate)");
			strSql.Append(" values (");
			strSql.Append("@imgid,@typeid,@imgurl,@sortId,@pubdate)");
			SqlParameter[] parameters = {
					new SqlParameter("@imgid", SqlDbType.NVarChar,50),
					new SqlParameter("@typeid", SqlDbType.Int,4),
					new SqlParameter("@imgurl", SqlDbType.NVarChar,200),
					new SqlParameter("@sortId", SqlDbType.Int,4),
					new SqlParameter("@pubdate", SqlDbType.DateTime)};
			parameters[0].Value = model.imgid;
			parameters[1].Value = model.typeid;
			parameters[2].Value = model.imgurl;
			parameters[3].Value = model.sortId;
			parameters[4].Value = model.pubdate;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(CdHotelManage.Model.room_type_image model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update room_type_image set ");
			strSql.Append("typeid=@typeid,");
			strSql.Append("imgurl=@imgurl,");
			strSql.Append("sortId=@sortId,");
			strSql.Append("pubdate=@pubdate");
			strSql.Append(" where imgid=@imgid ");
			SqlParameter[] parameters = {
					new SqlParameter("@typeid", SqlDbType.Int,4),
					new SqlParameter("@imgurl", SqlDbType.NVarChar,200),
					new SqlParameter("@sortId", SqlDbType.Int,4),
					new SqlParameter("@pubdate", SqlDbType.DateTime),
					new SqlParameter("@imgid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.typeid;
			parameters[1].Value = model.imgurl;
			parameters[2].Value = model.sortId;
			parameters[3].Value = model.pubdate;
			parameters[4].Value = model.imgid;

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
		public bool Delete(string imgid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from room_type_image ");
			strSql.Append(" where imgid=@imgid ");
			SqlParameter[] parameters = {
					new SqlParameter("@imgid", SqlDbType.NVarChar,50)			};
			parameters[0].Value = imgid;

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
		public bool DeleteList(string imgidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from room_type_image ");
			strSql.Append(" where imgid in ("+imgidlist + ")  ");
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
		public CdHotelManage.Model.room_type_image GetModel(string imgid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 imgid,typeid,imgurl,sortId,pubdate from room_type_image ");
			strSql.Append(" where imgid=@imgid ");
			SqlParameter[] parameters = {
					new SqlParameter("@imgid", SqlDbType.NVarChar,50)			};
			parameters[0].Value = imgid;

			CdHotelManage.Model.room_type_image model=new CdHotelManage.Model.room_type_image();
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
		public CdHotelManage.Model.room_type_image DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.room_type_image model=new CdHotelManage.Model.room_type_image();
			if (row != null)
			{
				if(row["imgid"]!=null)
				{
					model.imgid=row["imgid"].ToString();
				}
				if(row["typeid"]!=null && row["typeid"].ToString()!="")
				{
					model.typeid=int.Parse(row["typeid"].ToString());
				}
				if(row["imgurl"]!=null)
				{
					model.imgurl=row["imgurl"].ToString();
				}
				if(row["sortId"]!=null && row["sortId"].ToString()!="")
				{
					model.sortId=int.Parse(row["sortId"].ToString());
				}
				if(row["pubdate"]!=null && row["pubdate"].ToString()!="")
				{
					model.pubdate=DateTime.Parse(row["pubdate"].ToString());
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
			strSql.Append("select imgid,typeid,imgurl,sortId,pubdate ");
			strSql.Append(" FROM room_type_image ");
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
			strSql.Append(" imgid,typeid,imgurl,sortId,pubdate ");
			strSql.Append(" FROM room_type_image ");
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
			strSql.Append("select count(1) FROM room_type_image ");
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
				strSql.Append("order by T.imgid desc");
			}
			strSql.Append(")AS Row, T.*  from room_type_image T ");
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
			parameters[0].Value = "room_type_image";
			parameters[1].Value = "imgid";
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

