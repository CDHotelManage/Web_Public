using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:Goods
	/// </summary>
	public partial class Goods
	{
		public Goods()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Goods"); 
		}
        /// <summary>
        /// 得到最大费用编码
        /// </summary>
        public string GetMaxNumber(string stwhere)
        {
            return DbHelperSQL.GetMaxNum("Goods_number", "Goods", stwhere);
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Goods");
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
		public int Add(CdHotelManage.Model.Goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Goods(");
            strSql.Append("Goods_number,Goods_name,Goods_price,Goods_unit,Goods_state,Goods_spell,Goods_ifType,Goods_categories,Goods_Remaker,Goods_jf)");
			strSql.Append(" values (");
            strSql.Append("@Goods_number,@Goods_name,@Goods_price,@Goods_unit,@Goods_state,@Goods_spell,@Goods_ifType,@Goods_categories,@Goods_Remaker,@Goods_jf)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Goods_number", SqlDbType.NVarChar,50),
					new SqlParameter("@Goods_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Goods_price", SqlDbType.Money,8),
					new SqlParameter("@Goods_unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Goods_state", SqlDbType.NVarChar,50),
					new SqlParameter("@Goods_spell", SqlDbType.NVarChar,50), 
					new SqlParameter("@Goods_ifType", SqlDbType.Int,4),
                    new SqlParameter("@Goods_categories", SqlDbType.NVarChar,50),
					new SqlParameter("@Goods_Remaker", SqlDbType.NVarChar,50),       
                    new SqlParameter("@Goods_jf",SqlDbType.Int,4)
                                        };
            	  
            parameters[0].Value = model.Goods_number;
            parameters[1].Value = model.Goods_name;
            parameters[2].Value = model.Goods_price;
            parameters[3].Value = model.Goods_unit;
            parameters[4].Value = model.Goods_state;
            parameters[5].Value = model.Goods_spell;
            parameters[6].Value = model.Goods_ifType;
            parameters[7].Value = model.Goods_categories;
            parameters[8].Value = model.Goods_Remaker;
            parameters[9].Value = model.Goods_jf;
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
		public bool Update(CdHotelManage.Model.Goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Goods set ");
			strSql.Append("Goods_number=@Goods_number,");
			strSql.Append("Goods_name=@Goods_name,");
			strSql.Append("Goods_price=@Goods_price,");
			strSql.Append("Goods_unit=@Goods_unit,");
			strSql.Append("Goods_state=@Goods_state,");
			strSql.Append("Goods_spell=@Goods_spell,");
			strSql.Append("Goods_ifType=@Goods_ifType,");
            strSql.Append("Goods_categories=@Goods_categories,");
            strSql.Append("Goods_Remaker=@Goods_Remaker,");
            strSql.Append("Goods_jf=@Goods_jf");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@Goods_number", SqlDbType.NVarChar,50),
					new SqlParameter("@Goods_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Goods_price", SqlDbType.Money,8),
					new SqlParameter("@Goods_unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Goods_state", SqlDbType.NVarChar,50),
					new SqlParameter("@Goods_spell", SqlDbType.NVarChar,50),
					new SqlParameter("@Goods_ifType", SqlDbType.Int,4),
                    new SqlParameter("@Goods_categories", SqlDbType.NVarChar,50),
					new SqlParameter("@Goods_Remaker", SqlDbType.Int,4),
                    new SqlParameter("@Goods_jf", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.Goods_number;
			parameters[1].Value = model.Goods_name;
			parameters[2].Value = model.Goods_price;
			parameters[3].Value = model.Goods_unit;
			parameters[4].Value = model.Goods_state;
			parameters[5].Value = model.Goods_spell;
			parameters[6].Value = model.Goods_ifType;
            parameters[7].Value = model.Goods_categories;
            parameters[8].Value = model.Goods_Remaker;
            parameters[9].Value = model.Goods_jf;
			parameters[10].Value = model.id;

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
			strSql.Append("delete from Goods ");
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
			strSql.Append("delete from Goods ");
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

        public DataSet GetBookRoomPager(string sort, string order, int currentPage, int pageSize, string strWhere)
        {
            string _sql = @" select * from (select *,Row_number() over(order by " + sort + " " + order + ") as IDBookRoom from Goods " + strWhere + ") as IDWithRowNumber where IDBookRoom>=(" + currentPage + "-1)*" + pageSize + "+1 and IDBookRoom<=" + currentPage + "*" + pageSize + "";
            return DbHelperSQL.Query(_sql);
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.Goods GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,Goods_number,Goods_name,Goods_price,Goods_unit,Goods_state,Goods_spell,Goods_ifType,Goods_categories,Goods_Remaker,Goods_jf from Goods ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			CdHotelManage.Model.Goods model=new CdHotelManage.Model.Goods();
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
        public CdHotelManage.Model.Goods GetModels(string Swhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,Goods_number,Goods_name,Goods_price,Goods_unit,Goods_state,Goods_spell,Goods_ifType,Goods_categories,Goods_Remaker,Goods_jf from Goods ");
            strSql.Append(Swhere);
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            //parameters[0].Value = id;

            CdHotelManage.Model.Goods model = new CdHotelManage.Model.Goods();
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
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.Goods DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.Goods model=new CdHotelManage.Model.Goods();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["Goods_number"]!=null)
				{
					model.Goods_number=row["Goods_number"].ToString();
				}
				if(row["Goods_name"]!=null)
				{
					model.Goods_name=row["Goods_name"].ToString();
				}
				if(row["Goods_price"]!=null && row["Goods_price"].ToString()!="")
				{
					model.Goods_price=decimal.Parse(row["Goods_price"].ToString());
				}
				if(row["Goods_unit"]!=null)
				{
                    model.Goods_unit = row["Goods_unit"].ToString();
				}
				if(row["Goods_state"]!=null)
				{
					model.Goods_state=row["Goods_state"].ToString();
				}
				if(row["Goods_spell"]!=null)
				{
					model.Goods_spell=row["Goods_spell"].ToString();
				}
				if(row["Goods_ifType"]!=null && row["Goods_ifType"].ToString()!="")
				{
					model.Goods_ifType=int.Parse(row["Goods_ifType"].ToString());
				}
                if (row["Goods_categories"] != null && row["Goods_categories"].ToString() != "")
                {
                    model.Goods_categories = int.Parse(row["Goods_categories"].ToString());
                }
                if (row["Goods_Remaker"] != null)
                {
                    model.Goods_Remaker = row["Goods_Remaker"].ToString();
                }
                if (row["Goods_jf"] != null && row["Goods_jf"].ToString() != "")
                {
                    model.Goods_jf = int.Parse(row["Goods_jf"].ToString());
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
            strSql.Append("select id,Goods_number,Goods_name,Goods_price,Goods_unit,Goods_state,Goods_spell,Goods_ifType,Goods_categories,Goods_Remaker,Goods_jf ");
			strSql.Append(" FROM Goods ");
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
            strSql.Append(" id,Goods_number,Goods_name,Goods_price,Goods_unit,Goods_state,Goods_spell,Goods_ifType,Goods_categories,Goods_Remaker,Goods_jf ");
			strSql.Append(" FROM Goods ");
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
			strSql.Append("select count(1) FROM Goods ");
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
			strSql.Append(")AS Row, T.*  from Goods T ");
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
			parameters[0].Value = "Goods";
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

