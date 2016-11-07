using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:Menu
	/// </summary>
	public partial class MenuDAL
	{
		public MenuDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("menu_id", "Menu"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int menu_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Menu");
			strSql.Append(" where menu_id=@menu_id");
			SqlParameter[] parameters = {
					new SqlParameter("@menu_id", SqlDbType.Int,4)
			};
			parameters[0].Value = menu_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CdHotelManage.Model.Menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Menu(");
			strSql.Append("title,parent_id,url,imgurl,sortId,isable)");
			strSql.Append(" values (");
			strSql.Append("@title,@parent_id,@url,@imgurl,@sortId,@isable)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@parent_id", SqlDbType.Int,4),
					new SqlParameter("@url", SqlDbType.NVarChar,500),
					new SqlParameter("@imgurl", SqlDbType.NVarChar,200),
					new SqlParameter("@sortId", SqlDbType.Int,4),
					new SqlParameter("@isable", SqlDbType.Bit,1)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.parent_id;
			parameters[2].Value = model.url;
			parameters[3].Value = model.imgurl;
			parameters[4].Value = model.sortId;
			parameters[5].Value = model.isable;

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
		public bool Update(CdHotelManage.Model.Menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Menu set ");
			strSql.Append("title=@title,");
			strSql.Append("parent_id=@parent_id,");
			strSql.Append("url=@url,");
			strSql.Append("imgurl=@imgurl,");
			strSql.Append("sortId=@sortId,");
			strSql.Append("isable=@isable");
			strSql.Append(" where menu_id=@menu_id");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@parent_id", SqlDbType.Int,4),
					new SqlParameter("@url", SqlDbType.NVarChar,500),
					new SqlParameter("@imgurl", SqlDbType.NVarChar,200),
					new SqlParameter("@sortId", SqlDbType.Int,4),
					new SqlParameter("@isable", SqlDbType.Bit,1),
					new SqlParameter("@menu_id", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.parent_id;
			parameters[2].Value = model.url;
			parameters[3].Value = model.imgurl;
			parameters[4].Value = model.sortId;
			parameters[5].Value = model.isable;
			parameters[6].Value = model.menu_id;

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
		public bool Delete(int menu_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Menu ");
			strSql.Append(" where menu_id=@menu_id");
			SqlParameter[] parameters = {
					new SqlParameter("@menu_id", SqlDbType.Int,4)
			};
			parameters[0].Value = menu_id;

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
		public bool DeleteList(string menu_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Menu ");
			strSql.Append(" where menu_id in ("+menu_idlist + ")  ");
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
		public CdHotelManage.Model.Menu GetModel(int menu_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 menu_id,title,parent_id,url,imgurl,sortId,isable from Menu ");
			strSql.Append(" where menu_id=@menu_id");
			SqlParameter[] parameters = {
					new SqlParameter("@menu_id", SqlDbType.Int,4)
			};
			parameters[0].Value = menu_id;

			CdHotelManage.Model.Menu model=new CdHotelManage.Model.Menu();
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
		public CdHotelManage.Model.Menu DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.Menu model=new CdHotelManage.Model.Menu();
			if (row != null)
			{
				if(row["menu_id"]!=null && row["menu_id"].ToString()!="")
				{
					model.menu_id=int.Parse(row["menu_id"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["parent_id"]!=null && row["parent_id"].ToString()!="")
				{
					model.parent_id=int.Parse(row["parent_id"].ToString());
				}
				if(row["url"]!=null)
				{
					model.url=row["url"].ToString();
				}
				if(row["imgurl"]!=null)
				{
					model.imgurl=row["imgurl"].ToString();
				}
				if(row["sortId"]!=null && row["sortId"].ToString()!="")
				{
					model.sortId=int.Parse(row["sortId"].ToString());
				}
				if(row["isable"]!=null && row["isable"].ToString()!="")
				{
					if((row["isable"].ToString()=="1")||(row["isable"].ToString().ToLower()=="true"))
					{
						model.isable=true;
					}
					else
					{
						model.isable=false;
					}
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
			strSql.Append("select menu_id,title,parent_id,url,imgurl,sortId,isable ");
			strSql.Append(" FROM Menu ");
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
			strSql.Append(" menu_id,title,parent_id,url,imgurl,sortId,isable ");
			strSql.Append(" FROM Menu ");
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
			strSql.Append("select count(1) FROM Menu ");
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
				strSql.Append("order by T.menu_id desc");
			}
			strSql.Append(")AS Row, T.*  from Menu T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		

		#endregion  BasicMethod
		#region  ExtensionMethod
        //分页获取菜单
        public DataSet GetMenuPager(string sort, string order, int currentPage, int pageSize, int id)
        {
            string _sql = @" select  *
                                from (select *,Row_number() over(order by " + sort + " " + order + ") as IDRank from Menu where parent_id=" + id + ") as IDWithRowNumber where IDRank>=(" + currentPage + "-1)*" + pageSize + "+1 and IDRank<=" + currentPage + "*" + pageSize + "";

            return DbHelperSQL.Query(_sql);
        }

        //根据数组查询菜单
        public DataSet GetMenulist(string menu_id)
        {
            string sql = "select * from Menu where menu_id in (" + menu_id + ") order by sortId asc";
            return DbHelperSQL.Query(sql);
        }
		#endregion  ExtensionMethod
	}
}

