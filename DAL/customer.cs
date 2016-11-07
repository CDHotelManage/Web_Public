using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace CdHotelManage.DAL
{
    public class customer
    {
        public customer()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string accounts)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from customer");
            strSql.Append(" where accounts=@accounts ");
            SqlParameter[] parameters = {
					new SqlParameter("@accounts", SqlDbType.NVarChar,50)			};
            parameters[0].Value = accounts;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CdHotelManage.Model.customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into customer(");
            strSql.Append("accounts,cName,sysType,cusType,cusDesy,cusNumber,contacts,cPhone,Cstate,sales,prosceniumIss,Ishire,area,City,Contsrr,Shiji,Email,ybNum,Address,companyPhone,Fax,homepage,Csource,cindustry,Ischalk,limit,Remark,AddDate,editUser,verifyUser,isVerify,Hotel,Details,occNum,NoShow,xqBook,Pming,IsXz)");
            strSql.Append(" values (");
            strSql.Append("@accounts,@cName,@sysType,@cusType,@cusDesy,@cusNumber,@contacts,@cPhone,@Cstate,@sales,@prosceniumIss,@Ishire,@area,@City,@Contsrr,@Shiji,@Email,@ybNum,@Address,@companyPhone,@Fax,@homepage,@Csource,@cindustry,@Ischalk,@limit,@Remark,@AddDate,@editUser,@verifyUser,@isVerify,@Hotel,@Details,@occNum,@NoShow,@xqBook,@Pming,@IsXz)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@accounts", SqlDbType.NVarChar,50),
					new SqlParameter("@cName", SqlDbType.NVarChar,50),
					new SqlParameter("@sysType", SqlDbType.Int,4),
					new SqlParameter("@cusType", SqlDbType.Int,4),
					new SqlParameter("@cusDesy", SqlDbType.NVarChar,50),
					new SqlParameter("@cusNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@contacts", SqlDbType.NVarChar,50),
					new SqlParameter("@cPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Cstate", SqlDbType.Int,4),
					new SqlParameter("@sales", SqlDbType.Int,4),
					new SqlParameter("@prosceniumIss", SqlDbType.Bit,1),
					new SqlParameter("@Ishire", SqlDbType.Bit,1),
					new SqlParameter("@area", SqlDbType.NVarChar,50),
					new SqlParameter("@City", SqlDbType.NVarChar,20),
					new SqlParameter("@Contsrr", SqlDbType.NVarChar,20),
					new SqlParameter("@Shiji", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@ybNum", SqlDbType.NVarChar,20),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@companyPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@homepage", SqlDbType.NVarChar,50),
					new SqlParameter("@Csource", SqlDbType.Int,4),
					new SqlParameter("@cindustry", SqlDbType.Int,4),
					new SqlParameter("@Ischalk", SqlDbType.Bit,1),
					new SqlParameter("@limit", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@editUser", SqlDbType.NVarChar,50),
					new SqlParameter("@verifyUser", SqlDbType.Int,4),
					new SqlParameter("@isVerify", SqlDbType.Bit,1),
					new SqlParameter("@Hotel", SqlDbType.NVarChar,50),
					new SqlParameter("@Details", SqlDbType.NVarChar,500),
					new SqlParameter("@occNum", SqlDbType.Int,4),
					new SqlParameter("@NoShow", SqlDbType.Int,4),
					new SqlParameter("@xqBook", SqlDbType.Int,4),
					new SqlParameter("@Pming", SqlDbType.Int,4),
                                        new SqlParameter("@IsXz",SqlDbType.Bit)
                                        };
            parameters[0].Value = model.accounts;
            parameters[1].Value = model.cName;
            parameters[2].Value = model.sysType;
            parameters[3].Value = model.cusType;
            parameters[4].Value = model.cusDesy;
            parameters[5].Value = model.cusNumber;
            parameters[6].Value = model.contacts;
            parameters[7].Value = model.cPhone;
            parameters[8].Value = model.Cstate;
            parameters[9].Value = model.sales;
            parameters[10].Value = model.prosceniumIss;
            parameters[11].Value = model.Ishire;
            parameters[12].Value = model.area;
            parameters[13].Value = model.City;
            parameters[14].Value = model.Contsrr;
            parameters[15].Value = model.Shiji;
            parameters[16].Value = model.Email;
            parameters[17].Value = model.ybNum;
            parameters[18].Value = model.Address;
            parameters[19].Value = model.companyPhone;
            parameters[20].Value = model.Fax;
            parameters[21].Value = model.homepage;
            parameters[22].Value = model.Csource;
            parameters[23].Value = model.cindustry;
            parameters[24].Value = model.Ischalk;
            parameters[25].Value = model.limit;
            parameters[26].Value = model.Remark;
            parameters[27].Value = model.AddDate;
            parameters[28].Value = model.editUser;
            parameters[29].Value = model.verifyUser;
            parameters[30].Value = model.isVerify;
            parameters[31].Value = model.Hotel;
            parameters[32].Value = model.Details;
            parameters[33].Value = model.occNum;
            parameters[34].Value = model.NoShow;
            parameters[35].Value = model.xqBook;
            parameters[36].Value = model.Pming;
            parameters[37].Value = model.IsXz;
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
        public bool Update(CdHotelManage.Model.customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update customer set ");
            strSql.Append("cName=@cName,");
            strSql.Append("sysType=@sysType,");
            strSql.Append("cusType=@cusType,");
            strSql.Append("cusDesy=@cusDesy,");
            strSql.Append("cusNumber=@cusNumber,");
            strSql.Append("contacts=@contacts,");
            strSql.Append("cPhone=@cPhone,");
            strSql.Append("Cstate=@Cstate,");
            strSql.Append("sales=@sales,");
            strSql.Append("prosceniumIss=@prosceniumIss,");
            strSql.Append("Ishire=@Ishire,");
            strSql.Append("area=@area,");
            strSql.Append("City=@City,");
            strSql.Append("Contsrr=@Contsrr,");
            strSql.Append("Shiji=@Shiji,");
            strSql.Append("Email=@Email,");
            strSql.Append("ybNum=@ybNum,");
            strSql.Append("Address=@Address,");
            strSql.Append("companyPhone=@companyPhone,");
            strSql.Append("Fax=@Fax,");
            strSql.Append("homepage=@homepage,");
            strSql.Append("Csource=@Csource,");
            strSql.Append("cindustry=@cindustry,");
            strSql.Append("Ischalk=@Ischalk,");
            strSql.Append("limit=@limit,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("AddDate=@AddDate,");
            strSql.Append("editUser=@editUser,");
            strSql.Append("verifyUser=@verifyUser,");
            strSql.Append("isVerify=@isVerify,");
            strSql.Append("Hotel=@Hotel,");
            strSql.Append("Details=@Details,");
            strSql.Append("occNum=@occNum,");
            strSql.Append("NoShow=@NoShow,");
            strSql.Append("xqBook=@xqBook,");
            strSql.Append("Pming=@Pming,");
            strSql.Append("IsXz=@IsXz");
            strSql.Append(" where accounts=@accounts");
            SqlParameter[] parameters = {
					new SqlParameter("@cName", SqlDbType.NVarChar,50),
					new SqlParameter("@sysType", SqlDbType.Int,4),
					new SqlParameter("@cusType", SqlDbType.Int,4),
					new SqlParameter("@cusDesy", SqlDbType.NVarChar,50),
					new SqlParameter("@cusNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@contacts", SqlDbType.NVarChar,50),
					new SqlParameter("@cPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Cstate", SqlDbType.Int,4),
					new SqlParameter("@sales", SqlDbType.Int,4),
					new SqlParameter("@prosceniumIss", SqlDbType.Bit,1),
					new SqlParameter("@Ishire", SqlDbType.Bit,1),
					new SqlParameter("@area", SqlDbType.NVarChar,50),
					new SqlParameter("@City", SqlDbType.NVarChar,20),
					new SqlParameter("@Contsrr", SqlDbType.NVarChar,20),
					new SqlParameter("@Shiji", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@ybNum", SqlDbType.NVarChar,20),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@companyPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@homepage", SqlDbType.NVarChar,50),
					new SqlParameter("@Csource", SqlDbType.Int,4),
					new SqlParameter("@cindustry", SqlDbType.Int,4),
					new SqlParameter("@Ischalk", SqlDbType.Bit,1),
					new SqlParameter("@limit", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@editUser", SqlDbType.NVarChar,50),
					new SqlParameter("@verifyUser", SqlDbType.Int,4),
					new SqlParameter("@isVerify", SqlDbType.Bit,1),
					new SqlParameter("@Hotel", SqlDbType.NVarChar,50),
					new SqlParameter("@Details", SqlDbType.NVarChar,500),
					new SqlParameter("@occNum", SqlDbType.Int,4),
					new SqlParameter("@NoShow", SqlDbType.Int,4),
					new SqlParameter("@xqBook", SqlDbType.Int,4),
					new SqlParameter("@Pming", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@accounts", SqlDbType.NVarChar,50),
                                        new SqlParameter("@IsXz",SqlDbType.Bit)
                                        };
            parameters[0].Value = model.cName;
            parameters[1].Value = model.sysType;
            parameters[2].Value = model.cusType;
            parameters[3].Value = model.cusDesy;
            parameters[4].Value = model.cusNumber;
            parameters[5].Value = model.contacts;
            parameters[6].Value = model.cPhone;
            parameters[7].Value = model.Cstate;
            parameters[8].Value = model.sales;
            parameters[9].Value = model.prosceniumIss;
            parameters[10].Value = model.Ishire;
            parameters[11].Value = model.area;
            parameters[12].Value = model.City;
            parameters[13].Value = model.Contsrr;
            parameters[14].Value = model.Shiji;
            parameters[15].Value = model.Email;
            parameters[16].Value = model.ybNum;
            parameters[17].Value = model.Address;
            parameters[18].Value = model.companyPhone;
            parameters[19].Value = model.Fax;
            parameters[20].Value = model.homepage;
            parameters[21].Value = model.Csource;
            parameters[22].Value = model.cindustry;
            parameters[23].Value = model.Ischalk;
            parameters[24].Value = model.limit;
            parameters[25].Value = model.Remark;
            parameters[26].Value = model.AddDate;
            parameters[27].Value = model.editUser;
            parameters[28].Value = model.verifyUser;
            parameters[29].Value = model.isVerify;
            parameters[30].Value = model.Hotel;
            parameters[31].Value = model.Details;
            parameters[32].Value = model.occNum;
            parameters[33].Value = model.NoShow;
            parameters[34].Value = model.xqBook;
            parameters[35].Value = model.Pming;
            parameters[36].Value = model.ID;
            parameters[37].Value = model.accounts;
            parameters[38].Value = model.IsXz;
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
            strSql.Append("delete from customer ");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string accounts)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from customer ");
            strSql.Append(" where accounts=@accounts ");
            SqlParameter[] parameters = {
					new SqlParameter("@accounts", SqlDbType.NVarChar,50)			};
            parameters[0].Value = accounts;

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
            strSql.Append("delete from customer ");
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
        public CdHotelManage.Model.customer GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,accounts,cName,sysType,cusType,cusDesy,cusNumber,contacts,cPhone,Cstate,sales,prosceniumIss,Ishire,area,City,Contsrr,Shiji,Email,ybNum,Address,companyPhone,Fax,homepage,Csource,cindustry,Ischalk,limit,Remark,AddDate,editUser,verifyUser,isVerify,Hotel,Details,occNum,NoShow,xqBook,Pming,IsXz from customer ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            CdHotelManage.Model.customer model = new CdHotelManage.Model.customer();
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
        public CdHotelManage.Model.customer DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.customer model = new CdHotelManage.Model.customer();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["accounts"] != null)
                {
                    model.accounts = row["accounts"].ToString();
                }
                if (row["cName"] != null)
                {
                    model.cName = row["cName"].ToString();
                }
                if (row["sysType"] != null && row["sysType"].ToString() != "")
                {
                    model.sysType = int.Parse(row["sysType"].ToString());
                }
                if (row["cusType"] != null && row["cusType"].ToString() != "")
                {
                    model.cusType = int.Parse(row["cusType"].ToString());
                }
                if (row["cusDesy"] != null)
                {
                    model.cusDesy = row["cusDesy"].ToString();
                }
                if (row["cusNumber"] != null)
                {
                    model.cusNumber = row["cusNumber"].ToString();
                }
                if (row["contacts"] != null)
                {
                    model.contacts = row["contacts"].ToString();
                }
                if (row["cPhone"] != null)
                {
                    model.cPhone = row["cPhone"].ToString();
                }
                if (row["Cstate"] != null && row["Cstate"].ToString() != "")
                {
                    model.Cstate = int.Parse(row["Cstate"].ToString());
                }
                if (row["sales"] != null && row["sales"].ToString() != "")
                {
                    model.sales = int.Parse(row["sales"].ToString());
                }
                if (row["prosceniumIss"] != null && row["prosceniumIss"].ToString() != "")
                {
                    if ((row["prosceniumIss"].ToString() == "1") || (row["prosceniumIss"].ToString().ToLower() == "true"))
                    {
                        model.prosceniumIss = true;
                    }
                    else
                    {
                        model.prosceniumIss = false;
                    }
                }
                if (row["Ishire"] != null && row["Ishire"].ToString() != "")
                {
                    if ((row["Ishire"].ToString() == "1") || (row["Ishire"].ToString().ToLower() == "true"))
                    {
                        model.Ishire = true;
                    }
                    else
                    {
                        model.Ishire = false;
                    }
                }
                if (row["area"] != null)
                {
                    model.area = row["area"].ToString();
                }
                if (row["City"] != null)
                {
                    model.City = row["City"].ToString();
                }
                if (row["Contsrr"] != null)
                {
                    model.Contsrr = row["Contsrr"].ToString();
                }
                if (row["Shiji"] != null)
                {
                    model.Shiji = row["Shiji"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["ybNum"] != null)
                {
                    model.ybNum = row["ybNum"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["companyPhone"] != null)
                {
                    model.companyPhone = row["companyPhone"].ToString();
                }
                if (row["Fax"] != null)
                {
                    model.Fax = row["Fax"].ToString();
                }
                if (row["homepage"] != null)
                {
                    model.homepage = row["homepage"].ToString();
                }
                if (row["Csource"] != null && row["Csource"].ToString() != "")
                {
                    model.Csource = int.Parse(row["Csource"].ToString());
                }
                if (row["cindustry"] != null && row["cindustry"].ToString() != "")
                {
                    model.cindustry = int.Parse(row["cindustry"].ToString());
                }
                if (row["Ischalk"] != null && row["Ischalk"].ToString() != "")
                {
                    if ((row["Ischalk"].ToString() == "1") || (row["Ischalk"].ToString().ToLower() == "true"))
                    {
                        model.Ischalk = true;
                    }
                    else
                    {
                        model.Ischalk = false;
                    }
                }
                if (row["limit"] != null && row["limit"].ToString() != "")
                {
                    model.limit = int.Parse(row["limit"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["AddDate"] != null && row["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(row["AddDate"].ToString());
                }
                if (row["editUser"] != null)
                {
                    model.editUser = row["editUser"].ToString();
                }
                if (row["verifyUser"] != null && row["verifyUser"].ToString() != "")
                {
                    model.verifyUser = int.Parse(row["verifyUser"].ToString());
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
                if (row["Hotel"] != null)
                {
                    model.Hotel = row["Hotel"].ToString();
                }
                if (row["Details"] != null)
                {
                    model.Details = row["Details"].ToString();
                }
                if (row["occNum"] != null && row["occNum"].ToString() != "")
                {
                    model.occNum = int.Parse(row["occNum"].ToString());
                }
                if (row["NoShow"] != null && row["NoShow"].ToString() != "")
                {
                    model.NoShow = int.Parse(row["NoShow"].ToString());
                }
                if (row["xqBook"] != null && row["xqBook"].ToString() != "")
                {
                    model.xqBook = int.Parse(row["xqBook"].ToString());
                }
                if (row["Pming"] != null && row["Pming"].ToString() != "")
                {
                    model.Pming = int.Parse(row["Pming"].ToString());
                }
                if (row["IsXz"] != null && row["IsXz"].ToString() != "")
                {
                    model.IsXz = Convert.ToBoolean(row["IsXz"]);
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
            strSql.Append("select ID,accounts,cName,sysType,cusType,cusDesy,cusNumber,contacts,cPhone,Cstate,sales,prosceniumIss,Ishire,area,City,Contsrr,Shiji,Email,ybNum,Address,companyPhone,Fax,homepage,Csource,cindustry,Ischalk,limit,Remark,AddDate,editUser,verifyUser,isVerify,Hotel,Details,occNum,NoShow,xqBook,Pming,IsXz ");
            strSql.Append(" FROM customer ");
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
            strSql.Append(" ID,accounts,cName,sysType,cusType,cusDesy,cusNumber,contacts,cPhone,Cstate,sales,prosceniumIss,Ishire,area,City,Contsrr,Shiji,Email,ybNum,Address,companyPhone,Fax,homepage,Csource,cindustry,Ischalk,limit,Remark,AddDate,editUser,verifyUser,isVerify,Hotel,Details,occNum,NoShow,xqBook,Pming,IsXz ");
            strSql.Append(" FROM customer ");
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
            strSql.Append("select count(1) FROM customer ");
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
            strSql.Append(")AS Row, T.*  from customer T ");
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
            parameters[0].Value = "customer";
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


        public Model.customer GetAccounts(string accounts)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,accounts,cName,sysType,cusType,cusDesy,cusNumber,contacts,cPhone,Cstate,sales,prosceniumIss,Ishire,area,City,Contsrr,Shiji,Email,ybNum,Address,companyPhone,Fax,homepage,Csource,cindustry,Ischalk,limit,Remark,AddDate,editUser,verifyUser,isVerify,Hotel,Details,occNum,NoShow,xqBook,Pming,IsXz  ");
            strSql.Append(" FROM customer where accounts='" + accounts + "'");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                Model.customer modelcus = DataRowToModel(ds.Tables[0].Rows[0]);
                return modelcus;
            }
            return null;
        }

    }
}
