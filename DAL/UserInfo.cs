using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace CdHotelManage.DAL
{
    public class UserInfo
    {
        public UserInfo()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string userID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserInfo");
			strSql.Append(" where userID=@userID ");
			SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = userID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CdHotelManage.Model.UserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserInfo(");
			strSql.Append("userID,cardID,sex,cardTypeID,cardValue,typeid,xiaoshou,phone,bairthday,xihao,address,meark,manageID,truename)");
			strSql.Append(" values (");
			strSql.Append("@userID,@cardID,@sex,@cardTypeID,@cardValue,@typeid,@xiaoshou,@phone,@bairthday,@xihao,@address,@meark,@manageID,@truename)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.NVarChar,50),
					new SqlParameter("@cardID", SqlDbType.NChar,10),
					new SqlParameter("@sex", SqlDbType.Bit,1),
					new SqlParameter("@cardTypeID", SqlDbType.Int,4),
					new SqlParameter("@cardValue", SqlDbType.NVarChar,50),
					new SqlParameter("@typeid", SqlDbType.Int,4),
					new SqlParameter("@xiaoshou", SqlDbType.NVarChar,50),
					new SqlParameter("@phone", SqlDbType.NVarChar,50),
					new SqlParameter("@bairthday", SqlDbType.Date,3),
					new SqlParameter("@xihao", SqlDbType.NVarChar,100),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@meark", SqlDbType.NVarChar,-1),
					new SqlParameter("@manageID", SqlDbType.Int,4),
                    new SqlParameter("@truename", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.userID;
			parameters[1].Value = model.cardID;
			parameters[2].Value = model.sex;
			parameters[3].Value = model.cardTypeID;
			parameters[4].Value = model.cardValue;
			parameters[5].Value = model.typeid;
			parameters[6].Value = model.xiaoshou;
			parameters[7].Value = model.phone;
			parameters[8].Value = model.bairthday;
			parameters[9].Value = model.xihao;
			parameters[10].Value = model.address;
			parameters[11].Value = model.meark;
			parameters[12].Value = model.manageID;
            parameters[13].Value = model.Truename;

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
		public bool Update(CdHotelManage.Model.UserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserInfo set ");
			strSql.Append("cardID=@cardID,");
			strSql.Append("sex=@sex,");
			strSql.Append("cardTypeID=@cardTypeID,");
			strSql.Append("cardValue=@cardValue,");
			strSql.Append("typeid=@typeid,");
			strSql.Append("xiaoshou=@xiaoshou,");
			strSql.Append("phone=@phone,");
			strSql.Append("bairthday=@bairthday,");
			strSql.Append("xihao=@xihao,");
			strSql.Append("address=@address,");
			strSql.Append("meark=@meark,");
            strSql.Append("truename=@truename,");
			strSql.Append("manageID=@manageID");
            strSql.Append(" where userID=@userID");
			SqlParameter[] parameters = {
					new SqlParameter("@cardID", SqlDbType.NChar,10),
					new SqlParameter("@sex", SqlDbType.Bit,1),
					new SqlParameter("@cardTypeID", SqlDbType.Int,4),
					new SqlParameter("@cardValue", SqlDbType.NVarChar,50),
					new SqlParameter("@typeid", SqlDbType.Int,4),
					new SqlParameter("@xiaoshou", SqlDbType.NVarChar,50),
					new SqlParameter("@phone", SqlDbType.NVarChar,50),
					new SqlParameter("@bairthday", SqlDbType.Date,3),
					new SqlParameter("@xihao", SqlDbType.NVarChar,100),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@meark", SqlDbType.NVarChar,-1),
                    new SqlParameter("@truename", SqlDbType.NVarChar,50),
					new SqlParameter("@manageID", SqlDbType.Int,4),
					new SqlParameter("@userID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.cardID;
			parameters[1].Value = model.sex;
			parameters[2].Value = model.cardTypeID;
			parameters[3].Value = model.cardValue;
			parameters[4].Value = model.typeid;
			parameters[5].Value = model.xiaoshou;
			parameters[6].Value = model.phone;
			parameters[7].Value = model.bairthday;
			parameters[8].Value = model.xihao;
			parameters[9].Value = model.address;
			parameters[10].Value = model.meark;
            parameters[11].Value = model.Truename;
			parameters[12].Value = model.manageID;
			parameters[13].Value = model.userID;

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
        /// 更新一条数据(手机端)
        /// </summary>
        public bool UpdateInfo(CdHotelManage.Model.UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set ");
            strSql.Append("phone=@phone,");
            strSql.Append("bairthday=@bairthday,");
            strSql.Append("truename=@truename");
            strSql.Append(" where userID=@userID");
            SqlParameter[] parameters = {
					new SqlParameter("@phone", SqlDbType.NVarChar,50),
					new SqlParameter("@bairthday", SqlDbType.Date,3),
					new SqlParameter("@truename", SqlDbType.NVarChar,50),
					new SqlParameter("@userID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.phone;
            parameters[1].Value = model.bairthday;
            parameters[2].Value = model.Truename;
            parameters[3].Value = model.userID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserInfo ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

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
		public bool Delete(string userID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserInfo ");
			strSql.Append(" where userID=@userID ");
			SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = userID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserInfo ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public CdHotelManage.Model.UserInfo GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,userID,cardID,sex,cardTypeID,cardValue,typeid,xiaoshou,phone,bairthday,xihao,address,meark,manageID,truename from UserInfo ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			CdHotelManage.Model.UserInfo model=new CdHotelManage.Model.UserInfo();
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
		public CdHotelManage.Model.UserInfo DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.UserInfo model=new CdHotelManage.Model.UserInfo();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["userID"]!=null)
				{
					model.userID=row["userID"].ToString();
				}
				if(row["cardID"]!=null)
				{
					model.cardID=row["cardID"].ToString();
				}
				if(row["sex"]!=null && row["sex"].ToString()!="")
				{
					if((row["sex"].ToString()=="1")||(row["sex"].ToString().ToLower()=="true"))
					{
						model.sex=true;
					}
					else
					{
						model.sex=false;
					}
				}
				if(row["cardTypeID"]!=null && row["cardTypeID"].ToString()!="")
				{
					model.cardTypeID=int.Parse(row["cardTypeID"].ToString());
				}
				if(row["cardValue"]!=null)
				{
					model.cardValue=row["cardValue"].ToString();
				}
				if(row["typeid"]!=null && row["typeid"].ToString()!="")
				{
					model.typeid=int.Parse(row["typeid"].ToString());
				}
				if(row["xiaoshou"]!=null)
				{
					model.xiaoshou=row["xiaoshou"].ToString();
				}
				if(row["phone"]!=null && row["phone"].ToString()!="")
				{
					model.phone=row["phone"].ToString();
				}
				if(row["bairthday"]!=null && row["bairthday"].ToString()!="")
				{
					model.bairthday=DateTime.Parse(row["bairthday"].ToString());
				}
				if(row["xihao"]!=null)
				{
					model.xihao=row["xihao"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["meark"]!=null)
				{
					model.meark=row["meark"].ToString();
				}
				if(row["manageID"]!=null && row["manageID"].ToString()!="")
				{
					model.manageID=int.Parse(row["manageID"].ToString());
				}
                if (row["truename"] != null)
                {
                    model.Truename = row["truename"].ToString();
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
			strSql.Append("select ID,userID,cardID,sex,cardTypeID,cardValue,typeid,xiaoshou,phone,bairthday,xihao,address,meark,manageID,truename ");
			strSql.Append(" FROM UserInfo ");
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
			strSql.Append(" ID,userID,cardID,sex,cardTypeID,cardValue,typeid,xiaoshou,phone,bairthday,xihao,address,meark,manageID,truename ");
			strSql.Append(" FROM UserInfo ");
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
			strSql.Append("select count(1) FROM UserInfo ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from UserInfo T ");
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
			parameters[0].Value = "UserInfo";
			parameters[1].Value = "ID";
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
