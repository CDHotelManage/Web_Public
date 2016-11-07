using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace CdHotelManage.DAL
{
    public class Contacts
    {
        public Contacts()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Contacts");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CdHotelManage.Model.Contacts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Contacts(");
            strSql.Append("Accounts,cName,Sex,Bearthday,editUser,addDatetime,Appellation,department,officPhone,Phone,Address,zipcode,Mail,familyPhone,Likes,Remark,Post)");
            strSql.Append(" values (");
            strSql.Append("@Accounts,@cName,@Sex,@Bearthday,@editUser,@addDatetime,@Appellation,@department,@officPhone,@Phone,@Address,@zipcode,@Mail,@familyPhone,@Likes,@Remark,@Post)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Accounts", SqlDbType.NVarChar,50),
					new SqlParameter("@cName", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@Bearthday", SqlDbType.DateTime),
					new SqlParameter("@editUser", SqlDbType.NVarChar,50),
					new SqlParameter("@addDatetime", SqlDbType.DateTime),
					new SqlParameter("@Appellation", SqlDbType.Int,4),
					new SqlParameter("@department", SqlDbType.Int,4),
					new SqlParameter("@officPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@zipcode", SqlDbType.NVarChar,20),
					new SqlParameter("@Mail", SqlDbType.NVarChar,20),
					new SqlParameter("@familyPhone", SqlDbType.NVarChar,20),
					new SqlParameter("@Likes", SqlDbType.NVarChar,100),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
                                        new SqlParameter("@Post",SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.Accounts;
            parameters[1].Value = model.cName;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Bearthday;
            parameters[4].Value = model.editUser;
            parameters[5].Value = model.addDatetime;
            parameters[6].Value = model.Appellation;
            parameters[7].Value = model.department;
            parameters[8].Value = model.officPhone;
            parameters[9].Value = model.Phone;
            parameters[10].Value = model.Address;
            parameters[11].Value = model.zipcode;
            parameters[12].Value = model.Mail;
            parameters[13].Value = model.familyPhone;
            parameters[14].Value = model.Likes;
            parameters[15].Value = model.Remark;
            parameters[16].Value = model.Post;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(CdHotelManage.Model.Contacts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Contacts set ");
            strSql.Append("Accounts=@Accounts,");
            strSql.Append("cName=@cName,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Bearthday=@Bearthday,");
            strSql.Append("editUser=@editUser,");
            strSql.Append("addDatetime=@addDatetime,");
            strSql.Append("Appellation=@Appellation,");
            strSql.Append("department=@department,");
            strSql.Append("officPhone=@officPhone,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Address=@Address,");
            strSql.Append("zipcode=@zipcode,");
            strSql.Append("Mail=@Mail,");
            strSql.Append("familyPhone=@familyPhone,");
            strSql.Append("Likes=@Likes,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Post=@Post");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Accounts", SqlDbType.NVarChar,50),
					new SqlParameter("@cName", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@Bearthday", SqlDbType.DateTime),
					new SqlParameter("@editUser", SqlDbType.NVarChar,50),
					new SqlParameter("@addDatetime", SqlDbType.DateTime),
					new SqlParameter("@Appellation", SqlDbType.Int,4),
					new SqlParameter("@department", SqlDbType.Int,4),
					new SqlParameter("@officPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@zipcode", SqlDbType.NVarChar,20),
					new SqlParameter("@Mail", SqlDbType.NVarChar,20),
					new SqlParameter("@familyPhone", SqlDbType.NVarChar,20),
					new SqlParameter("@Likes", SqlDbType.NVarChar,100),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
                    new SqlParameter("@Post",SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Accounts;
            parameters[1].Value = model.cName;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Bearthday;
            parameters[4].Value = model.editUser;
            parameters[5].Value = model.addDatetime;
            parameters[6].Value = model.Appellation;
            parameters[7].Value = model.department;
            parameters[8].Value = model.officPhone;
            parameters[9].Value = model.Phone;
            parameters[10].Value = model.Address;
            parameters[11].Value = model.zipcode;
            parameters[12].Value = model.Mail;
            parameters[13].Value = model.familyPhone;
            parameters[14].Value = model.Likes;
            parameters[15].Value = model.Remark;
            parameters[16].Value = model.Post;
            parameters[17].Value = model.ID;

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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Contacts ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Contacts ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public CdHotelManage.Model.Contacts GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Accounts,cName,Sex,Bearthday,editUser,addDatetime,Appellation,department,officPhone,Phone,Address,zipcode,Mail,familyPhone,Likes,Remark,Post from Contacts ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            CdHotelManage.Model.Contacts model = new CdHotelManage.Model.Contacts();
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
        public CdHotelManage.Model.Contacts DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.Contacts model = new CdHotelManage.Model.Contacts();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Accounts"] != null)
                {
                    model.Accounts = row["Accounts"].ToString();
                }
                if (row["cName"] != null)
                {
                    model.cName = row["cName"].ToString();
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
                if (row["Bearthday"] != null && row["Bearthday"].ToString() != "")
                {
                    model.Bearthday = DateTime.Parse(row["Bearthday"].ToString());
                }
                if (row["editUser"] != null && row["editUser"].ToString() != "")
                {
                    model.editUser = row["editUser"].ToString();
                }
                if (row["addDatetime"] != null && row["addDatetime"].ToString() != "")
                {
                    model.addDatetime = DateTime.Parse(row["addDatetime"].ToString());
                }
                if (row["Appellation"] != null && row["Appellation"].ToString() != "")
                {
                    model.Appellation = int.Parse(row["Appellation"].ToString());
                }
                if (row["department"] != null && row["department"].ToString() != "")
                {
                    model.department = int.Parse(row["department"].ToString());
                }
                if (row["officPhone"] != null)
                {
                    model.officPhone = row["officPhone"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["zipcode"] != null)
                {
                    model.zipcode = row["zipcode"].ToString();
                }
                if (row["Mail"] != null)
                {
                    model.Mail = row["Mail"].ToString();
                }
                if (row["familyPhone"] != null)
                {
                    model.familyPhone = row["familyPhone"].ToString();
                }
                if (row["Likes"] != null)
                {
                    model.Likes = row["Likes"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Post"] != null && row["Post"].ToString() != "")
                {
                    model.Post = int.Parse(row["Post"].ToString());
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
            strSql.Append("select ID,Accounts,cName,Sex,Bearthday,editUser,addDatetime,Appellation,department,officPhone,Phone,Address,zipcode,Mail,familyPhone,Likes,Remark,Post ");
            strSql.Append(" FROM Contacts ");
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
            strSql.Append(" ID,Accounts,cName,Sex,Bearthday,editUser,addDatetime,Appellation,department,officPhone,Phone,Address,zipcode,Mail,familyPhone,Likes,Remark,Post ");
            strSql.Append(" FROM Contacts ");
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
            strSql.Append("select count(1) FROM Contacts ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from Contacts T ");
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
            parameters[0].Value = "Contacts";
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
