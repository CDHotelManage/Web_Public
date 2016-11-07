using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:order_infor
	/// </summary>
	public partial class order_infor
	{
		public order_infor()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("order_id", "order_infor"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int order_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from order_infor");
			strSql.Append(" where order_id=@order_id");
			SqlParameter[] parameters = {
					new SqlParameter("@order_id", SqlDbType.Int,4)
			};
			parameters[0].Value = order_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CdHotelManage.Model.order_infor model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into order_infor(");
			strSql.Append("order_no,room_id,occ_id,order_money,return_money,order_state,order_time,remark)");
			strSql.Append(" values (");
			strSql.Append("@order_no,@room_id,@occ_id,@order_money,@return_money,@order_state,@order_time,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,50),
					new SqlParameter("@room_id", SqlDbType.NVarChar,50),
					new SqlParameter("@occ_id", SqlDbType.Int,4),
					new SqlParameter("@order_money", SqlDbType.Money,8),
					new SqlParameter("@return_money", SqlDbType.Money,8),
					new SqlParameter("@order_state", SqlDbType.NVarChar,50),
					new SqlParameter("@order_time", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1)};
			parameters[0].Value = model.order_no;
			parameters[1].Value = model.room_id;
			parameters[2].Value = model.occ_id;
			parameters[3].Value = model.order_money;
			parameters[4].Value = model.return_money;
			parameters[5].Value = model.order_state;
			parameters[6].Value = model.order_time;
			parameters[7].Value = model.remark;

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
		public bool Update(CdHotelManage.Model.order_infor model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update order_infor set ");
			strSql.Append("order_no=@order_no,");
			strSql.Append("room_id=@room_id,");
			strSql.Append("occ_id=@occ_id,");
			strSql.Append("order_money=@order_money,");
			strSql.Append("return_money=@return_money,");
			strSql.Append("order_state=@order_state,");
			strSql.Append("order_time=@order_time,");
			strSql.Append("remark=@remark");
			strSql.Append(" where order_id=@order_id");
			SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,50),
					new SqlParameter("@room_id", SqlDbType.NVarChar,50),
					new SqlParameter("@occ_id", SqlDbType.Int,4),
					new SqlParameter("@order_money", SqlDbType.Money,8),
					new SqlParameter("@return_money", SqlDbType.Money,8),
					new SqlParameter("@order_state", SqlDbType.NVarChar,50),
					new SqlParameter("@order_time", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@order_id", SqlDbType.Int,4)};
			parameters[0].Value = model.order_no;
			parameters[1].Value = model.room_id;
			parameters[2].Value = model.occ_id;
			parameters[3].Value = model.order_money;
			parameters[4].Value = model.return_money;
			parameters[5].Value = model.order_state;
			parameters[6].Value = model.order_time;
			parameters[7].Value = model.remark;
			parameters[8].Value = model.order_id;

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
		public bool Delete(int order_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from order_infor ");
			strSql.Append(" where order_id=@order_id");
			SqlParameter[] parameters = {
					new SqlParameter("@order_id", SqlDbType.Int,4)
			};
			parameters[0].Value = order_id;

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
		public bool DeleteList(string order_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from order_infor ");
			strSql.Append(" where order_id in ("+order_idlist + ")  ");
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
		public CdHotelManage.Model.order_infor GetModel(int order_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 order_id,order_no,room_id,occ_id,order_money,return_money,order_state,order_time,remark from order_infor ");
			strSql.Append(" where order_id=@order_id");
			SqlParameter[] parameters = {
					new SqlParameter("@order_id", SqlDbType.Int,4)
			};
			parameters[0].Value = order_id;

			CdHotelManage.Model.order_infor model=new CdHotelManage.Model.order_infor();
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
		public CdHotelManage.Model.order_infor DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.order_infor model=new CdHotelManage.Model.order_infor();
			if (row != null)
			{
				if(row["order_id"]!=null && row["order_id"].ToString()!="")
				{
					model.order_id=int.Parse(row["order_id"].ToString());
				}
				if(row["order_no"]!=null)
				{
					model.order_no=row["order_no"].ToString();
				}
				if(row["room_id"]!=null && row["room_id"].ToString()!="")
				{
					model.room_id=row["room_id"].ToString();
				}
				if(row["occ_id"]!=null && row["occ_id"].ToString()!="")
				{
					model.occ_id=int.Parse(row["occ_id"].ToString());
				}
				if(row["order_money"]!=null && row["order_money"].ToString()!="")
				{
					model.order_money=decimal.Parse(row["order_money"].ToString());
				}
				if(row["return_money"]!=null && row["return_money"].ToString()!="")
				{
					model.return_money=decimal.Parse(row["return_money"].ToString());
				}
				if(row["order_state"]!=null)
				{
					model.order_state=row["order_state"].ToString();
				}
				if(row["order_time"]!=null && row["order_time"].ToString()!="")
				{
					model.order_time=DateTime.Parse(row["order_time"].ToString());
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
			strSql.Append("select order_id,order_no,room_id,occ_id,order_money,return_money,order_state,order_time,remark ");
			strSql.Append(" FROM order_infor ");
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
			strSql.Append(" order_id,order_no,room_id,occ_id,order_money,return_money,order_state,order_time,remark ");
			strSql.Append(" FROM order_infor ");
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
			strSql.Append("select count(1) FROM order_infor ");
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
				strSql.Append("order by T.order_id desc");
			}
			strSql.Append(")AS Row, T.*  from order_infor T ");
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
			parameters[0].Value = "order_infor";
			parameters[1].Value = "order_id";
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

