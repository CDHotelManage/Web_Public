using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace CdHotelManage.DAL
{
    public class cprotocol
    {
        public cprotocol()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from cprotocol");
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
        public int Add(CdHotelManage.Model.cprotocol model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into cprotocol(");
            strSql.Append("Accounts,Ptheme,pType,PNumber,ishire,term,period,breakfast,Commission,Dayhire,prohire,signatory,companysignatory,roomNumber,Isdiscount,discount,Remark,isVerify,editUser,verifyUser,Details)");
            strSql.Append(" values (");
            strSql.Append("@Accounts,@Ptheme,@pType,@PNumber,@ishire,@term,@period,@breakfast,@Commission,@Dayhire,@prohire,@signatory,@companysignatory,@roomNumber,@Isdiscount,@discount,@Remark,@isVerify,@editUser,@verifyUser,@Details)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Accounts", SqlDbType.NVarChar,50),
					new SqlParameter("@Ptheme", SqlDbType.NVarChar,50),
					new SqlParameter("@pType", SqlDbType.Int,4),
					new SqlParameter("@PNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@ishire", SqlDbType.Bit,1),
					new SqlParameter("@term", SqlDbType.DateTime),
					new SqlParameter("@period", SqlDbType.DateTime),
					new SqlParameter("@breakfast", SqlDbType.Int,4),
					new SqlParameter("@Commission", SqlDbType.Int,4),
					new SqlParameter("@Dayhire", SqlDbType.Bit,1),
					new SqlParameter("@prohire", SqlDbType.Bit,1),
					new SqlParameter("@signatory", SqlDbType.NVarChar,50),
					new SqlParameter("@companysignatory", SqlDbType.NVarChar,50),
					new SqlParameter("@roomNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Isdiscount", SqlDbType.Bit,1),
					new SqlParameter("@discount", SqlDbType.Float,8),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@isVerify", SqlDbType.Bit,1),
					new SqlParameter("@editUser", SqlDbType.NVarChar,50),
					new SqlParameter("@verifyUser", SqlDbType.Int,4),
					new SqlParameter("@Details", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.Accounts;
            parameters[1].Value = model.Ptheme;
            parameters[2].Value = model.pType;
            parameters[3].Value = model.PNumber;
            parameters[4].Value = model.ishire;
            parameters[5].Value = model.term;
            parameters[6].Value = model.period;
            parameters[7].Value = model.breakfast;
            parameters[8].Value = model.Commission;
            parameters[9].Value = model.Dayhire;
            parameters[10].Value = model.prohire;
            parameters[11].Value = model.signatory;
            parameters[12].Value = model.companysignatory;
            parameters[13].Value = model.roomNumber;
            parameters[14].Value = model.Isdiscount;
            parameters[15].Value = model.discount;
            parameters[16].Value = model.Remark;
            parameters[17].Value = model.isVerify;
            parameters[18].Value = model.editUser;
            parameters[19].Value = model.verifyUser;
            parameters[20].Value = model.Details;

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
        public bool Update(CdHotelManage.Model.cprotocol model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update cprotocol set ");
            strSql.Append("Accounts=@Accounts,");
            strSql.Append("Ptheme=@Ptheme,");
            strSql.Append("pType=@pType,");
            strSql.Append("PNumber=@PNumber,");
            strSql.Append("ishire=@ishire,");
            strSql.Append("term=@term,");
            strSql.Append("period=@period,");
            strSql.Append("breakfast=@breakfast,");
            strSql.Append("Commission=@Commission,");
            strSql.Append("Dayhire=@Dayhire,");
            strSql.Append("prohire=@prohire,");
            strSql.Append("signatory=@signatory,");
            strSql.Append("companysignatory=@companysignatory,");
            strSql.Append("roomNumber=@roomNumber,");
            strSql.Append("Isdiscount=@Isdiscount,");
            strSql.Append("discount=@discount,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("isVerify=@isVerify,");
            strSql.Append("editUser=@editUser,");
            strSql.Append("verifyUser=@verifyUser,");
            strSql.Append("Details=@Details");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Accounts", SqlDbType.NVarChar,50),
					new SqlParameter("@Ptheme", SqlDbType.NVarChar,50),
					new SqlParameter("@pType", SqlDbType.Int,4),
					new SqlParameter("@PNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@ishire", SqlDbType.Bit,1),
					new SqlParameter("@term", SqlDbType.DateTime),
					new SqlParameter("@period", SqlDbType.DateTime),
					new SqlParameter("@breakfast", SqlDbType.Int,4),
					new SqlParameter("@Commission", SqlDbType.Int,4),
					new SqlParameter("@Dayhire", SqlDbType.Bit,1),
					new SqlParameter("@prohire", SqlDbType.Bit,1),
					new SqlParameter("@signatory", SqlDbType.NVarChar,50),
					new SqlParameter("@companysignatory", SqlDbType.NVarChar,50),
					new SqlParameter("@roomNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Isdiscount", SqlDbType.Bit,1),
					new SqlParameter("@discount", SqlDbType.Float,8),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@isVerify", SqlDbType.Bit,1),
					new SqlParameter("@editUser", SqlDbType.NVarChar,50),
					new SqlParameter("@verifyUser", SqlDbType.Int,4),
					new SqlParameter("@Details", SqlDbType.NVarChar,500),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Accounts;
            parameters[1].Value = model.Ptheme;
            parameters[2].Value = model.pType;
            parameters[3].Value = model.PNumber;
            parameters[4].Value = model.ishire;
            parameters[5].Value = model.term;
            parameters[6].Value = model.period;
            parameters[7].Value = model.breakfast;
            parameters[8].Value = model.Commission;
            parameters[9].Value = model.Dayhire;
            parameters[10].Value = model.prohire;
            parameters[11].Value = model.signatory;
            parameters[12].Value = model.companysignatory;
            parameters[13].Value = model.roomNumber;
            parameters[14].Value = model.Isdiscount;
            parameters[15].Value = model.discount;
            parameters[16].Value = model.Remark;
            parameters[17].Value = model.isVerify;
            parameters[18].Value = model.editUser;
            parameters[19].Value = model.verifyUser;
            parameters[20].Value = model.Details;
            parameters[21].Value = model.ID;

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
            strSql.Append("delete from cprotocol ");
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
            strSql.Append("delete from cprotocol ");
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
        public CdHotelManage.Model.cprotocol GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Accounts,Ptheme,pType,PNumber,ishire,term,period,breakfast,Commission,Dayhire,prohire,signatory,companysignatory,roomNumber,Isdiscount,discount,Remark,isVerify,editUser,verifyUser,Details from cprotocol ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            CdHotelManage.Model.cprotocol model = new CdHotelManage.Model.cprotocol();
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
        public CdHotelManage.Model.cprotocol DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.cprotocol model = new CdHotelManage.Model.cprotocol();
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
                if (row["Ptheme"] != null)
                {
                    model.Ptheme = row["Ptheme"].ToString();
                }
                if (row["pType"] != null && row["pType"].ToString() != "")
                {
                    model.pType = int.Parse(row["pType"].ToString());
                }
                if (row["PNumber"] != null)
                {
                    model.PNumber = row["PNumber"].ToString();
                }
                if (row["ishire"] != null && row["ishire"].ToString() != "")
                {
                    if ((row["ishire"].ToString() == "1") || (row["ishire"].ToString().ToLower() == "true"))
                    {
                        model.ishire = true;
                    }
                    else
                    {
                        model.ishire = false;
                    }
                }
                if (row["term"] != null && row["term"].ToString() != "")
                {
                    model.term = DateTime.Parse(row["term"].ToString());
                }
                if (row["period"] != null && row["period"].ToString() != "")
                {
                    model.period = DateTime.Parse(row["period"].ToString());
                }
                if (row["breakfast"] != null && row["breakfast"].ToString() != "")
                {
                    model.breakfast = int.Parse(row["breakfast"].ToString());
                }
                if (row["Commission"] != null && row["Commission"].ToString() != "")
                {
                    model.Commission = int.Parse(row["Commission"].ToString());
                }
                if (row["Dayhire"] != null && row["Dayhire"].ToString() != "")
                {
                    if ((row["Dayhire"].ToString() == "1") || (row["Dayhire"].ToString().ToLower() == "true"))
                    {
                        model.Dayhire = true;
                    }
                    else
                    {
                        model.Dayhire = false;
                    }
                }
                if (row["prohire"] != null && row["prohire"].ToString() != "")
                {
                    if ((row["prohire"].ToString() == "1") || (row["prohire"].ToString().ToLower() == "true"))
                    {
                        model.prohire = true;
                    }
                    else
                    {
                        model.prohire = false;
                    }
                }
                if (row["signatory"] != null)
                {
                    model.signatory = row["signatory"].ToString();
                }
                if (row["companysignatory"] != null)
                {
                    model.companysignatory = row["companysignatory"].ToString();
                }
                if (row["roomNumber"] != null)
                {
                    model.roomNumber = row["roomNumber"].ToString();
                }
                if (row["Isdiscount"] != null && row["Isdiscount"].ToString() != "")
                {
                    if ((row["Isdiscount"].ToString() == "1") || (row["Isdiscount"].ToString().ToLower() == "true"))
                    {
                        model.Isdiscount = true;
                    }
                    else
                    {
                        model.Isdiscount = false;
                    }
                }
                if (row["discount"] != null && row["discount"].ToString() != "")
                {
                    model.discount = decimal.Parse(row["discount"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["isVerify"] != null && row["isVerify"].ToString() != "")
                {
                    if ((row["isVerify"].ToString() == "1") || (row["isVerify"].ToString().ToLower() == "true"))
                    {
                        model.isVerify = true;
                    }
                    else
                    {
                        model.isVerify = false;
                    }
                }
                if (row["editUser"] != null && row["editUser"].ToString() != "")
                {
                    model.editUser =row["editUser"].ToString();
                }
                if (row["verifyUser"] != null && row["verifyUser"].ToString() != "")
                {
                    model.verifyUser = int.Parse(row["verifyUser"].ToString());
                }
                if (row["Details"] != null)
                {
                    model.Details = row["Details"].ToString();
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
            strSql.Append("select ID,Accounts,Ptheme,pType,PNumber,ishire,term,period,breakfast,Commission,Dayhire,prohire,signatory,companysignatory,roomNumber,Isdiscount,discount,Remark,isVerify,editUser,verifyUser,Details ");
            strSql.Append(" FROM cprotocol ");
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
            strSql.Append(" ID,Accounts,Ptheme,pType,PNumber,ishire,term,period,breakfast,Commission,Dayhire,prohire,signatory,companysignatory,roomNumber,Isdiscount,discount,Remark,isVerify,editUser,verifyUser,Details ");
            strSql.Append(" FROM cprotocol ");
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
            strSql.Append("select count(1) FROM cprotocol ");
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
            strSql.Append(")AS Row, T.*  from cprotocol T ");
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
            parameters[0].Value = "cprotocol";
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
