using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace CdHotelManage.DAL
{
    /// <summary>
    /// 数据访问类:memberType
    /// </summary>
    public partial class memberType
    {
        public memberType()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MtID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from memberType");
            strSql.Append(" where MtID=@MtID");
            SqlParameter[] parameters = {
					new SqlParameter("@MtID", SqlDbType.Int,4)
			};
            parameters[0].Value = MtID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// 
        public int Add(CdHotelManage.Model.memberType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into memberType(");
            strSql.Append("TypeName,typePrice,Limit,LimitValue,IntegraIs,IsConsump,IsFz,IsXf,XfPrice,XfConsump,IsLive,LiveNum,LiveConsump,IsTx,IsDeaflut,IsUpgrade,ConsumpSum,UpLive,IsDeduction,Isout,OutHour,OutZD,FirstPrice,StaPrice,XqTime,MachJf)");
            strSql.Append(" values (");
            strSql.Append("@TypeName,@typePrice,@Limit,@LimitValue,@IntegraIs,@IsConsump,@IsFz,@IsXf,@XfPrice,@XfConsump,@IsLive,@LiveNum,@LiveConsump,@IsTx,@IsDeaflut,@IsUpgrade,@ConsumpSum,@UpLive,@IsDeduction,@Isout,@OutHour,@OutZD,@FirstPrice,@StaPrice,@XqTime,@MachJf)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@typePrice", SqlDbType.Int,4),
					new SqlParameter("@Limit", SqlDbType.Bit,1),
					new SqlParameter("@LimitValue", SqlDbType.Int,4),
					new SqlParameter("@IntegraIs", SqlDbType.Bit,1),
					new SqlParameter("@IsConsump", SqlDbType.Bit,1),
					new SqlParameter("@IsFz", SqlDbType.Bit,1),
					new SqlParameter("@IsXf", SqlDbType.Bit,1),
					new SqlParameter("@XfPrice", SqlDbType.Int,4),
					new SqlParameter("@XfConsump", SqlDbType.Int,4),
					new SqlParameter("@IsLive", SqlDbType.Bit,1),
					new SqlParameter("@LiveNum", SqlDbType.Int,4),
					new SqlParameter("@LiveConsump", SqlDbType.Int,4),
					new SqlParameter("@IsTx", SqlDbType.Bit,1),
					new SqlParameter("@IsDeaflut", SqlDbType.Bit,1),
					new SqlParameter("@IsUpgrade", SqlDbType.Bit,1),
					new SqlParameter("@ConsumpSum", SqlDbType.Int,4),
					new SqlParameter("@UpLive", SqlDbType.Int,4),
					new SqlParameter("@IsDeduction", SqlDbType.Bit,1),
					new SqlParameter("@Isout", SqlDbType.Bit,1),
					new SqlParameter("@OutHour", SqlDbType.Int,4),
					new SqlParameter("@OutZD", SqlDbType.Int,4),
					new SqlParameter("@FirstPrice", SqlDbType.Int,4),
                                        new SqlParameter("@StaPrice",SqlDbType.Int,4),
                                        new SqlParameter("@XqTime",SqlDbType.DateTime,4),
                                        new SqlParameter("@MachJf",SqlDbType.DateTime,4)
                                        };
            parameters[0].Value = model.TypeName;
            parameters[1].Value = model.typePrice;
            parameters[2].Value = model.Limit;
            parameters[3].Value = model.LimitValue;
            parameters[4].Value = model.IntegraIs;
            parameters[5].Value = model.IsConsump;
            parameters[6].Value = model.IsFz;
            parameters[7].Value = model.IsXf;
            parameters[8].Value = model.XfPrice;
            parameters[9].Value = model.XfConsump;
            parameters[10].Value = model.IsLive;
            parameters[11].Value = model.LiveNum;
            parameters[12].Value = model.LiveConsump;
            parameters[13].Value = model.IsTx;
            parameters[14].Value = model.IsDeaflut;
            parameters[15].Value = model.IsUpgrade;
            parameters[16].Value = model.ConsumpSum;
            parameters[17].Value = model.UpLive;
            parameters[18].Value = model.IsDeduction;
            parameters[19].Value = model.Isout;
            parameters[20].Value = model.OutHour;
            parameters[21].Value = model.OutZD;
            parameters[22].Value = model.FirstPrice;
            parameters[23].Value = model.StaPrice;
            parameters[24].Value = model.XqTime;
            parameters[25].Value = model.MachJf;
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
        public bool Update(Model.memberType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update memberType set ");
            strSql.Append("TypeName=@TypeName,");
            strSql.Append("typePrice=@typePrice,");
            strSql.Append("Limit=@Limit,");
            strSql.Append("LimitValue=@LimitValue,");
            strSql.Append("IntegraIs=@IntegraIs,");
            strSql.Append("IsConsump=@IsConsump,");
            strSql.Append("IsFz=@IsFz,");
            strSql.Append("IsXf=@IsXf,");
            strSql.Append("XfPrice=@XfPrice,");
            strSql.Append("XfConsump=@XfConsump,");
            strSql.Append("IsLive=@IsLive,");
            strSql.Append("LiveNum=@LiveNum,");
            strSql.Append("LiveConsump=@LiveConsump,");
            strSql.Append("IsTx=@IsTx,");
            strSql.Append("IsDeaflut=@IsDeaflut,");
            strSql.Append("IsUpgrade=@IsUpgrade,");
            strSql.Append("ConsumpSum=@ConsumpSum,");
            strSql.Append("UpLive=@UpLive,");
            strSql.Append("IsDeduction=@IsDeduction,");
            strSql.Append("Isout=@Isout,");
            strSql.Append("OutHour=@OutHour,");
            strSql.Append("OutZD=@OutZD,");
            strSql.Append("FirstPrice=@FirstPrice,");
            strSql.Append("StaPrice=@StaPrice,");
            strSql.Append("XqTime=@XqTime,");
            strSql.Append("MachJf=@MachJf");
            strSql.Append(" where MtID=@MtID");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@typePrice", SqlDbType.Int,4),
					new SqlParameter("@Limit", SqlDbType.Bit,1),
					new SqlParameter("@LimitValue", SqlDbType.Int,4),
					new SqlParameter("@IntegraIs", SqlDbType.Bit,1),
					new SqlParameter("@IsConsump", SqlDbType.Bit,1),
					new SqlParameter("@IsFz", SqlDbType.Bit,1),
					new SqlParameter("@IsXf", SqlDbType.Bit,1),
					new SqlParameter("@XfPrice", SqlDbType.Int,4),
					new SqlParameter("@XfConsump", SqlDbType.Int,4),
					new SqlParameter("@IsLive", SqlDbType.Bit,1),
					new SqlParameter("@LiveNum", SqlDbType.Int,4),
					new SqlParameter("@LiveConsump", SqlDbType.Int,4),
					new SqlParameter("@IsTx", SqlDbType.Bit,1),
					new SqlParameter("@IsDeaflut", SqlDbType.Bit,1),
					new SqlParameter("@IsUpgrade", SqlDbType.Bit,1),
					new SqlParameter("@ConsumpSum", SqlDbType.Int,4),
					new SqlParameter("@UpLive", SqlDbType.Int,4),
					new SqlParameter("@IsDeduction", SqlDbType.Bit,1),
					new SqlParameter("@Isout", SqlDbType.Bit,1),
					new SqlParameter("@OutHour", SqlDbType.Int,4),
					new SqlParameter("@OutZD", SqlDbType.Int,4),
					new SqlParameter("@FirstPrice", SqlDbType.Int,4),
                    new SqlParameter("@StaPrice", SqlDbType.Int,4),
                    new SqlParameter("@XqTime",SqlDbType.DateTime,4),
                    new SqlParameter("@MachJf",SqlDbType.Int,4),
					new SqlParameter("@MtID", SqlDbType.Int,4)};
            parameters[0].Value = model.TypeName;
            parameters[1].Value = model.typePrice;
            parameters[2].Value = model.Limit;
            parameters[3].Value = model.LimitValue;
            parameters[4].Value = model.IntegraIs;
            parameters[5].Value = model.IsConsump;
            parameters[6].Value = model.IsFz;
            parameters[7].Value = model.IsXf;
            parameters[8].Value = model.XfPrice;
            parameters[9].Value = model.XfConsump;
            parameters[10].Value = model.IsLive;
            parameters[11].Value = model.LiveNum;
            parameters[12].Value = model.LiveConsump;
            parameters[13].Value = model.IsTx;
            parameters[14].Value = model.IsDeaflut;
            parameters[15].Value = model.IsUpgrade;
            parameters[16].Value = model.ConsumpSum;
            parameters[17].Value = model.UpLive;
            parameters[18].Value = model.IsDeduction;
            parameters[19].Value = model.Isout;
            parameters[20].Value = model.OutHour;
            parameters[21].Value = model.OutZD;
            parameters[22].Value = model.FirstPrice;
            parameters[23].Value = model.StaPrice;
            parameters[24].Value = model.XqTime;
            parameters[25].Value = model.MachJf;
            parameters[26].Value = model.MtID;

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
        public bool Delete(string MtID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from memberType ");
            strSql.Append(" where MtID=@MtID");
            SqlParameter[] parameters = {
					new SqlParameter("@MtID", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = MtID;

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
        public bool DeleteList(string MtIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from memberType ");
            strSql.Append(" where MtID in (" + MtIDlist + ")  ");
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
        public Model.memberType GetModel(int MtID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MtID,TypeName,typePrice,Limit,LimitValue,IntegraIs,IsConsump,IsFz,IsXf,XfPrice,XfConsump,IsLive,LiveNum,LiveConsump,IsTx,IsDeaflut,IsUpgrade,ConsumpSum,UpLive,IsDeduction,Isout,OutHour,OutZD,FirstPrice,StaPrice,XqTime,MachJf from memberType ");
            strSql.Append(" where MtID=@MtID");
            SqlParameter[] parameters = {
					new SqlParameter("@MtID", SqlDbType.Int,4)
			};
            parameters[0].Value = MtID;

            Model.memberType model = new Model.memberType();
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
        public Model.memberType DataRowToModel(DataRow row)
        {
            Model.memberType model = new Model.memberType();
            if (row != null)
            {
                if (row["MtID"] != null && row["MtID"].ToString() != "")
                {
                    model.MtID = int.Parse(row["MtID"].ToString());
                }
                if (row["TypeName"] != null)
                {
                    model.TypeName = row["TypeName"].ToString();
                }
                if (row["typePrice"] != null && row["typePrice"].ToString() != "")
                {
                    model.typePrice = int.Parse(row["typePrice"].ToString());
                }
                if (row["Limit"] != null && row["Limit"].ToString() != "")
                {
                    if ((row["Limit"].ToString() == "1") || (row["Limit"].ToString().ToLower() == "true"))
                    {
                        model.Limit = true;
                    }
                    else
                    {
                        model.Limit = false;
                    }
                }
                if (row["LimitValue"] != null && row["LimitValue"].ToString() != "")
                {
                    model.LimitValue = int.Parse(row["LimitValue"].ToString());
                }
                if (row["IntegraIs"] != null && row["IntegraIs"].ToString() != "")
                {
                    if ((row["IntegraIs"].ToString() == "1") || (row["IntegraIs"].ToString().ToLower() == "true"))
                    {
                        model.IntegraIs = true;
                    }
                    else
                    {
                        model.IntegraIs = false;
                    }
                }
                if (row["IsConsump"] != null && row["IsConsump"].ToString() != "")
                {
                    if ((row["IsConsump"].ToString() == "1") || (row["IsConsump"].ToString().ToLower() == "true"))
                    {
                        model.IsConsump = true;
                    }
                    else
                    {
                        model.IsConsump = false;
                    }
                }
                if (row["IsFz"] != null && row["IsFz"].ToString() != "")
                {
                    if ((row["IsFz"].ToString() == "1") || (row["IsFz"].ToString().ToLower() == "true"))
                    {
                        model.IsFz = true;
                    }
                    else
                    {
                        model.IsFz = false;
                    }
                }
                if (row["IsXf"] != null && row["IsXf"].ToString() != "")
                {
                    if ((row["IsXf"].ToString() == "1") || (row["IsXf"].ToString().ToLower() == "true"))
                    {
                        model.IsXf = true;
                    }
                    else
                    {
                        model.IsXf = false;
                    }
                }
                if (row["XfPrice"] != null && row["XfPrice"].ToString() != "")
                {
                    model.XfPrice = int.Parse(row["XfPrice"].ToString());
                }
                if (row["XfConsump"] != null && row["XfConsump"].ToString() != "")
                {
                    model.XfConsump = int.Parse(row["XfConsump"].ToString());
                }
                if (row["IsLive"] != null && row["IsLive"].ToString() != "")
                {
                    if ((row["IsLive"].ToString() == "1") || (row["IsLive"].ToString().ToLower() == "true"))
                    {
                        model.IsLive = true;
                    }
                    else
                    {
                        model.IsLive = false;
                    }
                }
                if (row["LiveNum"] != null && row["LiveNum"].ToString() != "")
                {
                    model.LiveNum = int.Parse(row["LiveNum"].ToString());
                }
                if (row["LiveConsump"] != null && row["LiveConsump"].ToString() != "")
                {
                    model.LiveConsump = int.Parse(row["LiveConsump"].ToString());
                }
                if (row["StaPrice"] != null && row["StaPrice"].ToString() != "")
                {
                    model.StaPrice = int.Parse(row["StaPrice"].ToString());
                }
                if (row["IsTx"] != null && row["IsTx"].ToString() != "")
                {
                    if ((row["IsTx"].ToString() == "1") || (row["IsTx"].ToString().ToLower() == "true"))
                    {
                        model.IsTx = true;
                    }
                    else
                    {
                        model.IsTx = false;
                    }
                }
                if (row["IsDeaflut"] != null && row["IsDeaflut"].ToString() != "")
                {
                    if ((row["IsDeaflut"].ToString() == "1") || (row["IsDeaflut"].ToString().ToLower() == "true"))
                    {
                        model.IsDeaflut = true;
                    }
                    else
                    {
                        model.IsDeaflut = false;
                    }
                }
                if (row["IsUpgrade"] != null && row["IsUpgrade"].ToString() != "")
                {
                    if ((row["IsUpgrade"].ToString() == "1") || (row["IsUpgrade"].ToString().ToLower() == "true"))
                    {
                        model.IsUpgrade = true;
                    }
                    else
                    {
                        model.IsUpgrade = false;
                    }
                }
                if (row["ConsumpSum"] != null && row["ConsumpSum"].ToString() != "")
                {
                    model.ConsumpSum = int.Parse(row["ConsumpSum"].ToString());
                }
                if (row["UpLive"] != null && row["UpLive"].ToString() != "")
                {
                    model.UpLive = int.Parse(row["UpLive"].ToString());
                }
                if (row["IsDeduction"] != null && row["IsDeduction"].ToString() != "")
                {
                    if ((row["IsDeduction"].ToString() == "1") || (row["IsDeduction"].ToString().ToLower() == "true"))
                    {
                        model.IsDeduction = true;
                    }
                    else
                    {
                        model.IsDeduction = false;
                    }
                }
                if (row["Isout"] != null && row["Isout"].ToString() != "")
                {
                    if ((row["Isout"].ToString() == "1") || (row["Isout"].ToString().ToLower() == "true"))
                    {
                        model.Isout = true;
                    }
                    else
                    {
                        model.Isout = false;
                    }
                }
                if (row["OutHour"] != null && row["OutHour"].ToString() != "")
                {
                    model.OutHour = int.Parse(row["OutHour"].ToString());
                }
                if (row["OutZD"] != null && row["OutZD"].ToString() != "")
                {
                    model.OutZD = int.Parse(row["OutZD"].ToString());
                }
                if (row["FirstPrice"] != null && row["FirstPrice"].ToString() != "")
                {
                    model.FirstPrice = int.Parse(row["FirstPrice"].ToString());
                }
                if (row["XqTime"] != null && row["XqTime"].ToString() != "")
                {
                    model.XqTime = DateTime.Parse(row["XqTime"].ToString());
                }

                if (row["MachJf"] != null && row["MachJf"].ToString() != "")
                {
                    model.MachJf =int.Parse(row["MachJf"].ToString());
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
            strSql.Append("select MtID,TypeName,typePrice,Limit,LimitValue,IntegraIs,IsConsump,IsFz,IsXf,XfPrice,XfConsump,IsLive,LiveNum,LiveConsump,IsTx,IsDeaflut,IsUpgrade,ConsumpSum,UpLive,IsDeduction,Isout,OutHour,OutZD,FirstPrice,StaPrice,XqTime,MachJf ");
            strSql.Append(" FROM memberType ");
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
            strSql.Append(" MtID,TypeName,typePrice,Limit,LimitValue,IntegraIs,IsConsump,IsFz,IsXf,XfPrice,XfConsump,IsLive,LiveNum,LiveConsump,IsTx,IsDeaflut,IsUpgrade,ConsumpSum,UpLive,IsDeduction,Isout,OutHour,OutZD,FirstPrice,StaPrice,XqTime,MachJf ");
            strSql.Append(" FROM memberType ");
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
            strSql.Append("select count(1) FROM memberType ");
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
                strSql.Append("order by T.MtID desc");
            }
            strSql.Append(")AS Row, T.*  from memberType T ");
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
            parameters[0].Value = "memberType";
            parameters[1].Value = "MtID";
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

