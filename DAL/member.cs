using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
    /// <summary>
    /// 数据访问类:member
    /// </summary>
    public partial class member
    {
        public member()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Mid", "member");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from member");
            strSql.Append(" where Mid=@Mid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Mid", SqlDbType.Int,4)			};
            parameters[0].Value = Mid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.member model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into member(");
            strSql.Append("Mid,Name,Sex,Zjtype,ZjNumber,Mtype,sales,Phone,Baithday,Pwd,Likes,Address,Ramrek,Integration,IntegraDh,IntegraDj,Stored,Statid,AddDate,AddUser,XqTime)");
            strSql.Append(" values (");
            strSql.Append("@Mid,@Name,@Sex,@Zjtype,@ZjNumber,@Mtype,@sales,@Phone,@Baithday,@Pwd,@Likes,@Address,@Ramrek,@Integration,@IntegraDh,@IntegraDj,@Stored,@Statid,@AddDate,@AddUser,@XqTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@Mid", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@Zjtype", SqlDbType.Int,4),
					new SqlParameter("@ZjNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Mtype", SqlDbType.Int,4),
					new SqlParameter("@sales", SqlDbType.Int,4),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Baithday", SqlDbType.DateTime),
					new SqlParameter("@Pwd", SqlDbType.NVarChar,50),
					new SqlParameter("@Likes", SqlDbType.NVarChar,500),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Ramrek", SqlDbType.NVarChar,500),
					new SqlParameter("@Integration", SqlDbType.Int,4),
					new SqlParameter("@IntegraDh", SqlDbType.Int,4),
					new SqlParameter("@IntegraDj", SqlDbType.Int,4),
					new SqlParameter("@Stored", SqlDbType.Int,4),
					new SqlParameter("@Statid", SqlDbType.Int,4),
                                        new SqlParameter("@AddDate",SqlDbType.DateTime),
                                        new SqlParameter("@AddUser",SqlDbType.NVarChar),
                                        new SqlParameter("@XqTime",SqlDbType.DateTime)
                                        };
            parameters[0].Value = model.Mid;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Zjtype;
            parameters[4].Value = model.ZjNumber;
            parameters[5].Value = model.Mtype;
            parameters[6].Value = model.sales;
            parameters[7].Value = model.Phone;
            parameters[8].Value = model.Baithday;
            parameters[9].Value = model.Pwd;
            parameters[10].Value = model.Likes;
            parameters[11].Value = model.Address;
            parameters[12].Value = model.Ramrek;
            parameters[13].Value = model.Integration;
            parameters[14].Value = model.IntegraDh;
            parameters[15].Value = model.IntegraDj;
            parameters[16].Value = model.Stored;
            parameters[17].Value = model.Statid;
            parameters[18].Value = model.AddDate;
            parameters[19].Value = model.AddUser;
            parameters[20].Value = model.XqTime;
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

        public bool Updates(string sql) {
            int rows = DbHelperSQL.ExecuteSql(sql.ToString());
            if (rows > 0) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.member model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update member set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Zjtype=@Zjtype,");
            strSql.Append("ZjNumber=@ZjNumber,");
            strSql.Append("Mtype=@Mtype,");
            strSql.Append("sales=@sales,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Baithday=@Baithday,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("Likes=@Likes,");
            strSql.Append("Address=@Address,");
            strSql.Append("Ramrek=@Ramrek,");
            strSql.Append("Integration=@Integration,");
            strSql.Append("IntegraDh=@IntegraDh,");
            strSql.Append("IntegraDj=@IntegraDj,");
            strSql.Append("Stored=@Stored,");
            strSql.Append("Statid=@Statid,");
            strSql.Append("AddDate=@AddDate,");
            strSql.Append("addUser=@addUser,");
            strSql.Append("XqTime=@XqTime");
            strSql.Append(" where Mid=@Mid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@Zjtype", SqlDbType.Int,4),
					new SqlParameter("@ZjNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Mtype", SqlDbType.Int,4),
					new SqlParameter("@sales", SqlDbType.Int,4),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Baithday", SqlDbType.DateTime),
					new SqlParameter("@Pwd", SqlDbType.NVarChar,50),
					new SqlParameter("@Likes", SqlDbType.NVarChar,500),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Ramrek", SqlDbType.NVarChar,500),
					new SqlParameter("@Integration", SqlDbType.Int,4),
					new SqlParameter("@IntegraDh", SqlDbType.Int,4),
					new SqlParameter("@IntegraDj", SqlDbType.Int,4),
					new SqlParameter("@Stored", SqlDbType.Int,4),
					new SqlParameter("@Statid", SqlDbType.Int,4),
                    new SqlParameter("@AddDate",SqlDbType.DateTime),
                    new SqlParameter("@addUser",SqlDbType.NVarChar),
                    new SqlParameter("@XqTime",SqlDbType.DateTime),
					new SqlParameter("@Mid", SqlDbType.NVarChar,50)
                                        
                                        };
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Sex;
            parameters[2].Value = model.Zjtype;
            parameters[3].Value = model.ZjNumber;
            parameters[4].Value = model.Mtype;
            parameters[5].Value = model.sales;
            parameters[6].Value = model.Phone;
            parameters[7].Value = model.Baithday;
            parameters[8].Value = model.Pwd;
            parameters[9].Value = model.Likes;
            parameters[10].Value = model.Address;
            parameters[11].Value = model.Ramrek;
            parameters[12].Value = model.Integration;
            parameters[13].Value = model.IntegraDh;
            parameters[14].Value = model.IntegraDj;
            parameters[15].Value = model.Stored;
            parameters[16].Value = model.Statid;
            parameters[17].Value = model.AddDate;
            parameters[18].Value = model.AddUser;
            parameters[19].Value = model.XqTime;
            parameters[20].Value = model.Mid;

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
        public bool Delete(int Mid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from member ");
            strSql.Append(" where Mid=@Mid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Mid", SqlDbType.Int,4)			};
            parameters[0].Value = Mid;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Midlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from member ");
            strSql.Append(" where Mid in (" + Midlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Model.member GetModel(string Mid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Mid,Name,Sex,Zjtype,ZjNumber,Mtype,sales,Phone,Baithday,Pwd,Likes,Address,Ramrek,Integration,IntegraDh,IntegraDj,Stored,Statid,AddDate,AddUser,XqTime from member ");
            strSql.Append(" where Mid=@Mid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Mid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = Mid;

            Model.member model = new Model.member();
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
        public Model.member DataRowToModel(DataRow row)
        {
            Model.member model = new Model.member();
            if (row != null)
            {
                if (row["Mid"] != null && row["Mid"].ToString() != "")
                {
                    model.Mid = row["Mid"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Sex"] != null && row["Sex"].ToString() != "")
                {
                    if ((row["Sex"].ToString() == "1") || (row["Sex"].ToString().ToLower() == "true"))
                    {
                        model.Sex = true;
                    }
                    else
                    {
                        model.Sex = false;
                    }
                }
                if (row["Zjtype"] != null && row["Zjtype"].ToString() != "")
                {
                    model.Zjtype = int.Parse(row["Zjtype"].ToString());
                }
                if (row["ZjNumber"] != null)
                {
                    model.ZjNumber = row["ZjNumber"].ToString();
                }
                if (row["Mtype"] != null && row["Mtype"].ToString() != "")
                {
                    model.Mtype = int.Parse(row["Mtype"].ToString());
                }
                if (row["sales"] != null && row["sales"].ToString() != "")
                {
                    model.sales = int.Parse(row["sales"].ToString());
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["Baithday"] != null && row["Baithday"].ToString() != "")
                {
                    model.Baithday = DateTime.Parse(row["Baithday"].ToString());
                }
                if (row["XqTime"] != null && row["XqTime"].ToString() != "")
                {
                    model.XqTime = DateTime.Parse(row["XqTime"].ToString());
                }
                if (row["Pwd"] != null)
                {
                    model.Pwd = row["Pwd"].ToString();
                }
                if (row["Likes"] != null)
                {
                    model.Likes = row["Likes"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["Ramrek"] != null)
                {
                    model.Ramrek = row["Ramrek"].ToString();
                }
                if (row["Integration"] != null && row["Integration"].ToString() != "")
                {
                    model.Integration = int.Parse(row["Integration"].ToString());
                }
                if (row["IntegraDh"] != null && row["IntegraDh"].ToString() != "")
                {
                    model.IntegraDh = int.Parse(row["IntegraDh"].ToString());
                }
                if (row["IntegraDj"] != null && row["IntegraDj"].ToString() != "")
                {
                    model.IntegraDj = int.Parse(row["IntegraDj"].ToString());
                }
                if (row["Stored"] != null && row["Stored"].ToString() != "")
                {
                    model.Stored = int.Parse(row["Stored"].ToString());
                }
                if (row["Statid"] != null && row["Statid"].ToString() != "")
                {
                    model.Statid = int.Parse(row["Statid"].ToString());
                }
                if (row["AddDate"] != null && row["AddDate"].ToString() != "")
                {
                    model.AddDate = Convert.ToDateTime(row["AddDate"].ToString());
                }
                if (row["addUser"] != null && row["addUser"].ToString() != "")
                {
                    model.AddUser = row["addUser"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Mid,Name,Sex,Zjtype,ZjNumber,Mtype,sales,Phone,Baithday,Pwd,Likes,Address,Ramrek,Integration,IntegraDh,IntegraDj,Stored,Statid,AddDate,addUser,XqTime ");
            strSql.Append(" FROM member ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Mid,Name,Sex,Zjtype,ZjNumber,Mtype,sales,Phone,Baithday,Pwd,Likes,Address,Ramrek,Integration,IntegraDh,IntegraDj,Stored,Statid,AddDate,addUser,XqTime ");
            strSql.Append(" FROM member ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM member ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Mid desc");
            }
            strSql.Append(")AS Row, T.*  from member T ");
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
            parameters[0].Value = "member";
            parameters[1].Value = "Mid";
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

