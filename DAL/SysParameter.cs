using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace CdHotelManage.DAL
{
    public class SysParameter
    {
        public SysParameter()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CdHotelManage.Model.SysParamter model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SysParamter(");
            strSql.Append("CancellMin,IsDeposit,Deposit,IsEarlyRoom,EarlyStart,EarlyEnd,EarlyOutTime,EarlyFee,EarlyFeeSel,EarlyOutTimes,EarlyFeeTwo,DayOutTime,DayFee,DayFeeTwo,DayTime,istype,ysTime,isOcczf,isCy,MarkSuo)");
			strSql.Append(" values (");
            strSql.Append("@CancellMin,@IsDeposit,@Deposit,@IsEarlyRoom,@EarlyStart,@EarlyEnd,@EarlyOutTime,@EarlyFee,@EarlyFeeSel,@EarlyOutTimes,@EarlyFeeTwo,@DayOutTime,@DayFee,@DayFeeTwo,@DayTime,@istype,@ysTime,@isOcczf,@isCy,@MarkSuo)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CancellMin", SqlDbType.Int,4),
					new SqlParameter("@IsDeposit", SqlDbType.Bit,1),
					new SqlParameter("@Deposit", SqlDbType.Decimal,5),
					new SqlParameter("@IsEarlyRoom", SqlDbType.Bit,1),
					new SqlParameter("@EarlyStart", SqlDbType.Time,5),
					new SqlParameter("@EarlyEnd", SqlDbType.Time,5),
					new SqlParameter("@EarlyOutTime", SqlDbType.Time,5),
					new SqlParameter("@EarlyFee", SqlDbType.Int,4),
					new SqlParameter("@EarlyFeeSel", SqlDbType.Int,4),
					new SqlParameter("@EarlyOutTimes", SqlDbType.Time,5),
					new SqlParameter("@EarlyFeeTwo", SqlDbType.Int,4),
					new SqlParameter("@DayOutTime", SqlDbType.Time,5),
					new SqlParameter("@DayFee", SqlDbType.Int,4),
					new SqlParameter("@DayFeeTwo", SqlDbType.Time,5),
					new SqlParameter("@DayTime", SqlDbType.Time,5),
                    new SqlParameter("@istype", SqlDbType.Bit,1),
                    new SqlParameter("@ysTime", SqlDbType.Time,5),
                    new SqlParameter("@isOcczf", SqlDbType.Bit,1),
            new SqlParameter("@isCy", SqlDbType.Bit,1),
            new SqlParameter("@MarkSuo",SqlDbType.NVarChar,50)
                                        };
			parameters[0].Value = model.CancellMin;
			parameters[1].Value = model.IsDeposit;
			parameters[2].Value = model.Deposit;
			parameters[3].Value = model.IsEarlyRoom;
			parameters[4].Value = model.EarlyStart;
			parameters[5].Value = model.EarlyEnd;
			parameters[6].Value = model.EarlyOutTime;
			parameters[7].Value = model.EarlyFee;
			parameters[8].Value = model.EarlyFeeSel;
			parameters[9].Value = model.EarlyOutTimes;
			parameters[10].Value = model.EarlyFeeTwo;
			parameters[11].Value = model.DayOutTime;
			parameters[12].Value = model.DayFee;
			parameters[13].Value = model.DayFeeTwo;
			parameters[14].Value = model.DayTime;
            parameters[15].Value = model.Istype;
            parameters[16].Value = model.YsTime;
            parameters[17].Value = model.IsOcczf;
            parameters[18].Value = model.IsCy;
            parameters[19].Value = model.MarkSuo;
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
		public bool Update(CdHotelManage.Model.SysParamter model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SysParamter set ");
			strSql.Append("CancellMin=@CancellMin,");
			strSql.Append("IsDeposit=@IsDeposit,");
			strSql.Append("Deposit=@Deposit,");
			strSql.Append("IsEarlyRoom=@IsEarlyRoom,");
			strSql.Append("EarlyStart=@EarlyStart,");
			strSql.Append("EarlyEnd=@EarlyEnd,");
			strSql.Append("EarlyOutTime=@EarlyOutTime,");
			strSql.Append("EarlyFee=@EarlyFee,");
			strSql.Append("EarlyFeeSel=@EarlyFeeSel,");
			strSql.Append("EarlyOutTimes=@EarlyOutTimes,");
			strSql.Append("EarlyFeeTwo=@EarlyFeeTwo,");
			strSql.Append("DayOutTime=@DayOutTime,");
			strSql.Append("DayFee=@DayFee,");
			strSql.Append("DayFeeTwo=@DayFeeTwo,");
			strSql.Append("DayTime=@DayTime,");
            strSql.Append("istype=@istype,");
            strSql.Append("ysTime=@ysTime,");
            strSql.Append("isOcczf=@isOcczf,");
            strSql.Append("isCy=@isCy,");
            strSql.Append("MarkSuo=@MarkSuo");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@CancellMin", SqlDbType.Int,4),
					new SqlParameter("@IsDeposit", SqlDbType.Bit,1),
					new SqlParameter("@Deposit", SqlDbType.Decimal,5),
					new SqlParameter("@IsEarlyRoom", SqlDbType.Bit,1),
					new SqlParameter("@EarlyStart", SqlDbType.Time,5),
					new SqlParameter("@EarlyEnd", SqlDbType.Time,5),
					new SqlParameter("@EarlyOutTime", SqlDbType.Time,5),
					new SqlParameter("@EarlyFee", SqlDbType.Int,4),
					new SqlParameter("@EarlyFeeSel", SqlDbType.Int,4),
					new SqlParameter("@EarlyOutTimes", SqlDbType.Time,5),
					new SqlParameter("@EarlyFeeTwo", SqlDbType.Int,4),
					new SqlParameter("@DayOutTime", SqlDbType.Time,5),
					new SqlParameter("@DayFee", SqlDbType.Int,4),
					new SqlParameter("@DayFeeTwo", SqlDbType.Time,5),
					new SqlParameter("@DayTime", SqlDbType.Time,5),
                    new SqlParameter("@istype", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4),
                                        new SqlParameter("@ysTime", SqlDbType.Time,5),
                    new SqlParameter("@isOcczf", SqlDbType.Bit,1),
            new SqlParameter("@isCy", SqlDbType.Bit,1),
             new SqlParameter("@MarkSuo",SqlDbType.NVarChar,50)
                                        
                                        };
			parameters[0].Value = model.CancellMin;
			parameters[1].Value = model.IsDeposit;
			parameters[2].Value = model.Deposit;
			parameters[3].Value = model.IsEarlyRoom;
			parameters[4].Value = model.EarlyStart;
			parameters[5].Value = model.EarlyEnd;
			parameters[6].Value = model.EarlyOutTime;
			parameters[7].Value = model.EarlyFee;
			parameters[8].Value = model.EarlyFeeSel;
			parameters[9].Value = model.EarlyOutTimes;
			parameters[10].Value = model.EarlyFeeTwo;
			parameters[11].Value = model.DayOutTime;
			parameters[12].Value = model.DayFee;
			parameters[13].Value = model.DayFeeTwo;
			parameters[14].Value = model.DayTime;
            parameters[15].Value = model.Istype;
			parameters[16].Value = model.id;
            parameters[17].Value = model.YsTime;
            parameters[18].Value = model.IsOcczf;
            parameters[19].Value = model.IsCy;
            parameters[20].Value = model.MarkSuo;
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
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.SysParamter GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,CancellMin,IsDeposit,Deposit,IsEarlyRoom,EarlyStart,EarlyEnd,EarlyOutTime,EarlyFee,EarlyFeeSel,EarlyOutTimes,EarlyFeeTwo,DayOutTime,DayFee,DayFeeTwo,DayTime,istype,ysTime,isOcczf,isCy,MarkSuo from SysParamter ");
			
			CdHotelManage.Model.SysParamter model=new CdHotelManage.Model.SysParamter();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
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
		public CdHotelManage.Model.SysParamter DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.SysParamter model=new CdHotelManage.Model.SysParamter();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["CancellMin"]!=null && row["CancellMin"].ToString()!="")
				{
					model.CancellMin=int.Parse(row["CancellMin"].ToString());
				}
				if(row["IsDeposit"]!=null && row["IsDeposit"].ToString()!="")
				{
					if((row["IsDeposit"].ToString()=="1")||(row["IsDeposit"].ToString().ToLower()=="true"))
					{
						model.IsDeposit=true;
					}
					else
					{
						model.IsDeposit=false;
					}
				}
				if(row["Deposit"]!=null && row["Deposit"].ToString()!="")
				{
					model.Deposit=decimal.Parse(row["Deposit"].ToString());
				}
				if(row["IsEarlyRoom"]!=null && row["IsEarlyRoom"].ToString()!="")
				{
					if((row["IsEarlyRoom"].ToString()=="1")||(row["IsEarlyRoom"].ToString().ToLower()=="true"))
					{
						model.IsEarlyRoom=true;
					}
					else
					{
						model.IsEarlyRoom=false;
					}
				}
				if(row["EarlyStart"]!=null && row["EarlyStart"].ToString()!="")
				{
					model.EarlyStart=TimeSpan.Parse(row["EarlyStart"].ToString());
				}
				if(row["EarlyEnd"]!=null && row["EarlyEnd"].ToString()!="")
				{
                    model.EarlyEnd = TimeSpan.Parse(row["EarlyEnd"].ToString());
				}
				if(row["EarlyOutTime"]!=null && row["EarlyOutTime"].ToString()!="")
				{
                    model.EarlyOutTime = TimeSpan.Parse(row["EarlyOutTime"].ToString());
				}
				if(row["EarlyFee"]!=null && row["EarlyFee"].ToString()!="")
				{
					model.EarlyFee=int.Parse(row["EarlyFee"].ToString());
				}
				if(row["EarlyFeeSel"]!=null && row["EarlyFeeSel"].ToString()!="")
				{
					model.EarlyFeeSel=int.Parse(row["EarlyFeeSel"].ToString());
				}
				if(row["EarlyOutTimes"]!=null && row["EarlyOutTimes"].ToString()!="")
				{
                    model.EarlyOutTimes = TimeSpan.Parse(row["EarlyOutTimes"].ToString());
				}
				if(row["EarlyFeeTwo"]!=null && row["EarlyFeeTwo"].ToString()!="")
				{
					model.EarlyFeeTwo=int.Parse(row["EarlyFeeTwo"].ToString());
				}
				if(row["DayOutTime"]!=null && row["DayOutTime"].ToString()!="")
				{
                    model.DayOutTime = TimeSpan.Parse(row["DayOutTime"].ToString());
				}
				if(row["DayFee"]!=null && row["DayFee"].ToString()!="")
				{
					model.DayFee=int.Parse(row["DayFee"].ToString());
				}
				if(row["DayFeeTwo"]!=null && row["DayFeeTwo"].ToString()!="")
				{
                    model.DayFeeTwo = TimeSpan.Parse(row["DayFeeTwo"].ToString());
				}
				if(row["DayTime"]!=null && row["DayTime"].ToString()!="")
				{
                    model.DayTime = TimeSpan.Parse(row["DayTime"].ToString());
				}
                if (row["istype"] != null && row["istype"].ToString() != "")
                {
                    model.Istype = Convert.ToBoolean(row["istype"]);
                }

                if (row["ysTime"] != null && row["ysTime"].ToString() != "")
                {
                    model.YsTime = TimeSpan.Parse(row["ysTime"].ToString());
                }
                if (row["isOcczf"] != null && row["isOcczf"].ToString() != "")
                {
                    model.IsOcczf = Convert.ToBoolean(row["isOcczf"]);
                }
                if (row["isCy"] != null && row["isCy"].ToString() != "")
                {
                    model.IsCy = Convert.ToBoolean(row["isCy"]);
                }
                if (row["MarkSuo"] != null && row["MarkSuo"].ToString() != "")
                {
                    model.MarkSuo = row["MarkSuo"].ToString();
                }
			}
			return model;
		}

		#endregion  BasicMethod
	}
}

