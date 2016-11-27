using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;

namespace CdHotelManage.DAL
{
    public class AccountsRolesDAL
    {
        public AccountsRolesDAL()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CdHotelManage.Model.AccountsRoles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_Roles(");
            strSql.Append("RoleID,title,Description)");
            strSql.Append(" values (");
            strSql.Append("@RoleID,@title,@Description)");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
                    new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@Description", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Description;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(CdHotelManage.Model.AccountsRoles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_Roles set ");
            strSql.Append("title=@title, ");
            strSql.Append("Description=@Description");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
                    new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@Description", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Description;

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
        public bool Delete(int id)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_Roles ");
            strSql.Append(" where  RoleID=@RoleID");
            SqlParameter[] parameters = {
                                            new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
            parameters[0].Value = id;
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
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("RoleID", "Accounts_Roles");
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
            strSql.Append(" RoleID,title,Description ");
            strSql.Append(" FROM Accounts_Roles ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        
        #endregion  Method
    }
}
