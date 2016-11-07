using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:cost_type
	/// </summary>
	public partial class cost_type
	{
		public cost_type()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "cost_type"); 
		}
        /// <summary>
        /// 得到最大费用编码
        /// </summary>
        public string GetMaxNumber(string stwhere)
        {
            return DbHelperSQL.GetMaxNum("ct_number", "cost_type", stwhere);
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from cost_type");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CdHotelManage.Model.cost_type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into cost_type(");
			strSql.Append("ct_number,ct_name,ct_iftype,ct_remark,ct_money,ct_categories)");
			strSql.Append(" values (");
			strSql.Append("@ct_number,@ct_name,@ct_iftype,@ct_remark,@ct_money,@ct_categories)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ct_number", SqlDbType.NVarChar,50),
					new SqlParameter("@ct_name", SqlDbType.NVarChar,50),
					new SqlParameter("@ct_iftype", SqlDbType.Int,4),
					new SqlParameter("@ct_remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@ct_money", SqlDbType.Money,8),
					new SqlParameter("@ct_categories", SqlDbType.Int,4)};
			parameters[0].Value = model.ct_number;
			parameters[1].Value = model.ct_name;
			parameters[2].Value = model.ct_iftype;
			parameters[3].Value = model.ct_remark;
			parameters[4].Value = model.ct_money;
			parameters[5].Value = model.ct_categories;

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
		public bool Update(CdHotelManage.Model.cost_type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update cost_type set ");
			strSql.Append("ct_number=@ct_number,");
			strSql.Append("ct_name=@ct_name,");
			strSql.Append("ct_iftype=@ct_iftype,");
			strSql.Append("ct_remark=@ct_remark,");
			strSql.Append("ct_money=@ct_money,");
			strSql.Append("ct_categories=@ct_categories");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@ct_number", SqlDbType.NVarChar,50),
					new SqlParameter("@ct_name", SqlDbType.NVarChar,50),
					new SqlParameter("@ct_iftype", SqlDbType.Int,4),
					new SqlParameter("@ct_remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@ct_money", SqlDbType.Money,8),
					new SqlParameter("@ct_categories", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.ct_number;
			parameters[1].Value = model.ct_name;
			parameters[2].Value = model.ct_iftype;
			parameters[3].Value = model.ct_remark;
			parameters[4].Value = model.ct_money;
			parameters[5].Value = model.ct_categories;
			parameters[6].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from cost_type ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from cost_type ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public CdHotelManage.Model.cost_type GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,ct_number,ct_name,ct_iftype,ct_remark,ct_money,ct_categories from cost_type ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			CdHotelManage.Model.cost_type model=new CdHotelManage.Model.cost_type();
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
        public CdHotelManage.Model.cost_type GetModels(string swhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ct_number,ct_name,ct_iftype,ct_remark,ct_money,ct_categories from cost_type ");
            strSql.Append(" swhere");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};

            CdHotelManage.Model.cost_type model = new CdHotelManage.Model.cost_type();
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
        /// 获得数据列表
        /// </summary>
       

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.cost_type DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.cost_type model=new CdHotelManage.Model.cost_type();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["ct_number"]!=null)
				{
					model.ct_number=row["ct_number"].ToString();
				}
				if(row["ct_name"]!=null)
				{
					model.ct_name=row["ct_name"].ToString();
				}
				if(row["ct_iftype"]!=null && row["ct_iftype"].ToString()!="")
				{
					model.ct_iftype=int.Parse(row["ct_iftype"].ToString());
				}
				if(row["ct_remark"]!=null)
				{
					model.ct_remark=row["ct_remark"].ToString();
				}
				if(row["ct_money"]!=null && row["ct_money"].ToString()!="")
				{
					model.ct_money=decimal.Parse(row["ct_money"].ToString());
				}
				if(row["ct_categories"]!=null && row["ct_categories"].ToString()!="")
				{
					model.ct_categories=int.Parse(row["ct_categories"].ToString());
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
			strSql.Append("select id,ct_number,ct_name,ct_iftype,ct_remark,ct_money,ct_categories ");
			strSql.Append(" FROM cost_type ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        public DataSet GetBookRoomPager(string sort, string order, int currentPage, int pageSize, string strWhere)
        {
            string _sql = @" select * from (select *,Row_number() over(order by " + sort + " " + order + ") as IDBookRoom from cost_type " + strWhere + ") as IDWithRowNumber where IDBookRoom>=(" + currentPage + "-1)*" + pageSize + "+1 and IDBookRoom<=" + currentPage + "*" + pageSize + "";
            return DbHelperSQL.Query(_sql);
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
			strSql.Append(" id,ct_number,ct_name,ct_iftype,ct_remark,ct_money,ct_categories ");
			strSql.Append(" FROM cost_type ");
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
			strSql.Append("select count(1) FROM cost_type ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from cost_type T ");
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
			parameters[0].Value = "cost_type";
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

