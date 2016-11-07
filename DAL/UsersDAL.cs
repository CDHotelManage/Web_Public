using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:Users
	/// </summary>
	public partial class UsersDAL
	{
		public UsersDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string userid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Users");
			strSql.Append(" where userid=@userid ");
			SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.NVarChar,50)			};
			parameters[0].Value = userid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CdHotelManage.Model.Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Users(");
			strSql.Append("userid,username,passwords,user_type,pubdate)");
			strSql.Append(" values (");
			strSql.Append("@userid,@username,@passwords,@user_type,@pubdate)");
			SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
					new SqlParameter("@username", SqlDbType.NVarChar,100),
					new SqlParameter("@passwords", SqlDbType.NVarChar,100),
					new SqlParameter("@user_type", SqlDbType.Int,4),
					new SqlParameter("@pubdate", SqlDbType.DateTime)};
			parameters[0].Value = model.userid;
			parameters[1].Value = model.username;
			parameters[2].Value = model.passwords;
			parameters[3].Value = model.user_type;
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
		public bool Update(CdHotelManage.Model.Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Users set ");
			strSql.Append("username=@username,");
			strSql.Append("passwords=@passwords,");
			strSql.Append("user_type=@user_type,");
			strSql.Append("pubdate=@pubdate");
			strSql.Append(" where userid=@userid ");
			SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,100),
					new SqlParameter("@passwords", SqlDbType.NVarChar,100),
					new SqlParameter("@user_type", SqlDbType.Int,4),
					new SqlParameter("@pubdate", SqlDbType.DateTime),
					new SqlParameter("@userid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.passwords;
			parameters[2].Value = model.user_type;
			parameters[3].Value = model.pubdate;
			parameters[4].Value = model.userid;

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
        public bool UpdateInfo(CdHotelManage.Model.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append("username=@username");
            strSql.Append(" where userid=@userid ");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,100),
					new SqlParameter("@userid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.username;
            parameters[1].Value = model.userid;

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
        /// 更新密码
        /// </summary>
        public bool UpdatePwd(CdHotelManage.Model.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append("passwords=@passwords");
            strSql.Append(" where userid=@userid ");
            SqlParameter[] parameters = {
					new SqlParameter("@passwords", SqlDbType.NVarChar,100),
					new SqlParameter("@userid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.passwords;
            parameters[1].Value = model.userid;

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
		public bool Delete(string userid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where userid=@userid ");
			SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.NVarChar,50)			};
			parameters[0].Value = userid;

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
		public bool DeleteList(string useridlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where userid in ("+useridlist + ")  ");
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
        /// 根据用户名和密码返回用户
        /// </summary>
        public CdHotelManage.Model.Users GetUserByLogin(string username, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From Users Where ");
            strSql.Append("username=@username And  ");
            strSql.Append("passwords=@passwords");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,100),
					new SqlParameter("@passwords", SqlDbType.VarChar,100)};
            parameters[0].Value = username;
            parameters[1].Value = pwd;

            CdHotelManage.Model.Users model = new CdHotelManage.Model.Users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["userid"] != null && ds.Tables[0].Rows[0]["userid"].ToString() != "")
                {
                    model.userid = ds.Tables[0].Rows[0]["userid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["username"] != null && ds.Tables[0].Rows[0]["username"].ToString() != "")
                {
                    model.username = ds.Tables[0].Rows[0]["username"].ToString();
                }
                if (ds.Tables[0].Rows[0]["passwords"] != null && ds.Tables[0].Rows[0]["passwords"].ToString() != "")
                {
                    model.passwords = ds.Tables[0].Rows[0]["passwords"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_type"] != null && ds.Tables[0].Rows[0]["user_type"].ToString() != "")
                {
                    model.user_type = int.Parse(ds.Tables[0].Rows[0]["user_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pubdate"] != null && ds.Tables[0].Rows[0]["pubdate"].ToString() != "")
                {
                    model.pubdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["pubdate"].ToString());
                }
                return model;

            }
            else
            {
                return null;
            }



        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.Users GetModel(string userid)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select top 1 * from Users left join UserInfo on Users.userid=UserInfo.userID left join userType on UserInfo.typeid=userType.typeid ");
            strSql.Append(" where Users.userid=@userid ");
			SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.NVarChar,50)			};
			parameters[0].Value = userid;

			CdHotelManage.Model.Users model=new CdHotelManage.Model.Users();
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
		public CdHotelManage.Model.Users DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.Users model=new CdHotelManage.Model.Users();
			if (row != null)
			{
				if(row["userid"]!=null)
				{
					model.userid=row["userid"].ToString();
                    DAL.UserInfo dal = new UserInfo();
                    model.UserInfoModel = dal.DataRowToModel(row);
				}
				if(row["username"]!=null)
				{
					model.username=row["username"].ToString();
				}
				if(row["passwords"]!=null)
				{
					model.passwords=row["passwords"].ToString();
				}
				if(row["user_type"]!=null && row["user_type"].ToString()!="")
				{
					model.user_type=int.Parse(row["user_type"].ToString());
                    DAL.userType dal = new userType();
                    model.UserTypeModel = dal.DataRowToModel(row);
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
            strSql.Append("select * FROM Users as u inner join UserInfo as ui on u.userid=ui.userID inner join userType as ut on u.user_type=ut.typeid ");
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
			strSql.Append(" userid,username,passwords,user_type,pubdate ");
			strSql.Append(" FROM Users ");
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
			strSql.Append("select count(1) FROM Users ");
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
				strSql.Append("order by T.userid desc");
			}
			strSql.Append(")AS Row, T.*  from Users T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		

		#endregion  BasicMethod
		
	}
}

