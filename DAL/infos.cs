using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;

namespace CdHotelManage.DAL
{
    public class infos
    {
        public infos()
        { }
        #region  BasicMethod
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from info ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from info ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public CdHotelManage.Model.infos GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,number,type from info ");
            CdHotelManage.Model.infos model = new CdHotelManage.Model.infos();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CdHotelManage.Model.infos model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into info(");
            strSql.Append("number,type)");
            strSql.Append(" values (");
            strSql.Append("@number,@type)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@number", SqlDbType.NVarChar,50),
					new SqlParameter("@type", SqlDbType.NVarChar,5000)};
            parameters[0].Value = model.number;
            parameters[1].Value = model.type;

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
        #endregion  BasicMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.infos DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.infos model = new CdHotelManage.Model.infos();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["number"] != null)
                {
                    model.number = row["number"].ToString();
                }
                if (row["type"] != null)
                {
                    model.type = row["type"].ToString();
                }
            }
            return model;
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
