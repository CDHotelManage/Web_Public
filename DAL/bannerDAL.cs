using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:banner
	/// </summary>
	public partial class bannerDAL
	{
		public bannerDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string banner_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from banner");
			strSql.Append(" where banner_id=@banner_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@banner_id", SqlDbType.NVarChar,50)			};
			parameters[0].Value = banner_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CdHotelManage.Model.banner model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into banner(");
			strSql.Append("banner_id,title,imgurl,sortId,pubdate)");
			strSql.Append(" values (");
			strSql.Append("@banner_id,@title,@imgurl,@sortId,@pubdate)");
			SqlParameter[] parameters = {
					new SqlParameter("@banner_id", SqlDbType.NVarChar,50),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@imgurl", SqlDbType.NVarChar,200),
					new SqlParameter("@sortId", SqlDbType.Int,4),
					new SqlParameter("@pubdate", SqlDbType.DateTime)};
			parameters[0].Value = model.banner_id;
			parameters[1].Value = model.title;
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
		public bool Update(CdHotelManage.Model.banner model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update banner set ");
			strSql.Append("title=@title,");
			strSql.Append("imgurl=@imgurl,");
			strSql.Append("sortId=@sortId,");
			strSql.Append("pubdate=@pubdate");
			strSql.Append(" where banner_id=@banner_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@imgurl", SqlDbType.NVarChar,200),
					new SqlParameter("@sortId", SqlDbType.Int,4),
					new SqlParameter("@pubdate", SqlDbType.DateTime),
					new SqlParameter("@banner_id", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.imgurl;
			parameters[2].Value = model.sortId;
			parameters[3].Value = model.pubdate;
			parameters[4].Value = model.banner_id;

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
		public bool Delete(string banner_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from banner ");
			strSql.Append(" where banner_id=@banner_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@banner_id", SqlDbType.NVarChar,50)			};
			parameters[0].Value = banner_id;

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
		public bool DeleteList(string banner_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from banner ");
			strSql.Append(" where banner_id in ("+banner_idlist + ")  ");
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
		public CdHotelManage.Model.banner GetModel(string banner_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 banner_id,title,imgurl,sortId,pubdate from banner ");
			strSql.Append(" where banner_id=@banner_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@banner_id", SqlDbType.NVarChar,50)			};
			parameters[0].Value = banner_id;

			CdHotelManage.Model.banner model=new CdHotelManage.Model.banner();
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
		public CdHotelManage.Model.banner DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.banner model=new CdHotelManage.Model.banner();
			if (row != null)
			{
				if(row["banner_id"]!=null)
				{
					model.banner_id=row["banner_id"].ToString();
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
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
			strSql.Append("select banner_id,title,imgurl,sortId,pubdate ");
			strSql.Append(" FROM banner ");
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
			strSql.Append(" banner_id,title,imgurl,sortId,pubdate ");
			strSql.Append(" FROM banner ");
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
			strSql.Append("select count(1) FROM banner ");
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
				strSql.Append("order by T.banner_id desc");
			}
			strSql.Append(")AS Row, T.*  from banner T ");
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
			parameters[0].Value = "banner";
			parameters[1].Value = "banner_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="order"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public DataSet GetBannerPager(string sort, string order, int currentPage, int pageSize)
        {
            string _sql = @" select  *
                                from (select *,Row_number() over(order by " + sort + " " + order + ") as IDRank from banner ) as IDWithRowNumber where IDRank>=(" + currentPage + "-1)*" + pageSize + "+1 and IDRank<=" + currentPage + "*" + pageSize + "";

            return DbHelperSQL.Query(_sql);
        }
		#endregion  ExtensionMethod
	}
}

