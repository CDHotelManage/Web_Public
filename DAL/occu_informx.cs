﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
    /// <summary>
    /// 数据访问类:occu_informx
    /// </summary>
    public partial class occu_informx
    {
        public occu_informx()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int occ_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from occu_informx");
            strSql.Append(" where occ_id=@occ_id");
            SqlParameter[] parameters = {
					new SqlParameter("@occ_id", SqlDbType.Int,4)
			};
            parameters[0].Value = occ_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CdHotelManage.Model.occu_informx model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into occu_informx(");
            strSql.Append("occ_no,order_id,occ_name,occ_with,real_type_id,room_number,real_scheme_id,source_id,mem_cardno,real_mode_id,real_price,occ_time,stay_day,stay_deposit,depar_time,pha_sched,card_id,card_no,brithday,sex,family_name,address,state_id,deposit,amount_money,sort,lordRoomid,continuelive,phonenum)");
            strSql.Append(" values (");
            strSql.Append("@occ_no,@order_id,@occ_name,@occ_with,@real_type_id,@room_number,@real_scheme_id,@source_id,@mem_cardno,@real_mode_id,@real_price,@occ_time,@stay_day,@stay_deposit,@depar_time,@pha_sched,@card_id,@card_no,@brithday,@sex,@family_name,@address,@state_id,@deposit,@amount_money,@sort,@lordRoomid,@continuelive,@phonenum)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@occ_no", SqlDbType.NVarChar,50),
					new SqlParameter("@order_id", SqlDbType.Int,4),
					new SqlParameter("@occ_name", SqlDbType.NVarChar,20),
					new SqlParameter("@occ_with", SqlDbType.NVarChar,10),
					new SqlParameter("@real_type_id", SqlDbType.Int,4),
					new SqlParameter("@room_number", SqlDbType.NVarChar,10),
					new SqlParameter("@real_scheme_id", SqlDbType.Int,4),
					new SqlParameter("@source_id", SqlDbType.Int,4),
					new SqlParameter("@mem_cardno", SqlDbType.NVarChar,50),
					new SqlParameter("@real_mode_id", SqlDbType.Int,4),
					new SqlParameter("@real_price", SqlDbType.Money,8),
					new SqlParameter("@occ_time", SqlDbType.DateTime),
					new SqlParameter("@stay_day", SqlDbType.Int,4),
					new SqlParameter("@stay_deposit", SqlDbType.Money,8),
					new SqlParameter("@depar_time", SqlDbType.DateTime),
					new SqlParameter("@pha_sched", SqlDbType.DateTime),
					new SqlParameter("@card_id", SqlDbType.Int,4),
					new SqlParameter("@card_no", SqlDbType.NVarChar,50),
					new SqlParameter("@brithday", SqlDbType.NVarChar,20),
					new SqlParameter("@sex", SqlDbType.NVarChar,1),
					new SqlParameter("@family_name", SqlDbType.NVarChar,20),
					new SqlParameter("@address", SqlDbType.NVarChar,50),
					new SqlParameter("@state_id", SqlDbType.Int,4),
					new SqlParameter("@deposit", SqlDbType.Money,8),
					new SqlParameter("@amount_money", SqlDbType.Money,8),
					new SqlParameter("@sort", SqlDbType.NVarChar,50),
					new SqlParameter("@lordRoomid", SqlDbType.NVarChar,50),
					new SqlParameter("@continuelive", SqlDbType.Int,4),
					new SqlParameter("@phonenum", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.occ_no;
            parameters[1].Value = model.order_id;
            parameters[2].Value = model.occ_name;
            parameters[3].Value = model.occ_with;
            parameters[4].Value = model.real_type_id;
            parameters[5].Value = model.room_number;
            parameters[6].Value = model.real_scheme_id;
            parameters[7].Value = model.source_id;
            parameters[8].Value = model.mem_cardno;
            parameters[9].Value = model.real_mode_id;
            parameters[10].Value = model.real_price;
            parameters[11].Value = model.occ_time;
            parameters[12].Value = model.stay_day;
            parameters[13].Value = model.stay_deposit;
            parameters[14].Value = model.depar_time;
            parameters[15].Value = model.pha_sched;
            parameters[16].Value = model.card_id;
            parameters[17].Value = model.card_no;
            parameters[18].Value = model.brithday;
            parameters[19].Value = model.sex;
            parameters[20].Value = model.family_name;
            parameters[21].Value = model.address;
            parameters[22].Value = model.state_id;
            parameters[23].Value = model.deposit;
            parameters[24].Value = model.amount_money;
            parameters[25].Value = model.sort;
            parameters[26].Value = model.lordRoomid;
            parameters[27].Value = model.continuelive;
            parameters[28].Value = model.phonenum;

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
        public bool Update(CdHotelManage.Model.occu_informx model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update occu_informx set ");
            strSql.Append("occ_no=@occ_no,");
            strSql.Append("order_id=@order_id,");
            strSql.Append("occ_name=@occ_name,");
            strSql.Append("occ_with=@occ_with,");
            strSql.Append("real_type_id=@real_type_id,");
            strSql.Append("room_number=@room_number,");
            strSql.Append("real_scheme_id=@real_scheme_id,");
            strSql.Append("source_id=@source_id,");
            strSql.Append("mem_cardno=@mem_cardno,");
            strSql.Append("real_mode_id=@real_mode_id,");
            strSql.Append("real_price=@real_price,");
            strSql.Append("occ_time=@occ_time,");
            strSql.Append("stay_day=@stay_day,");
            strSql.Append("stay_deposit=@stay_deposit,");
            strSql.Append("depar_time=@depar_time,");
            strSql.Append("pha_sched=@pha_sched,");
            strSql.Append("card_id=@card_id,");
            strSql.Append("card_no=@card_no,");
            strSql.Append("brithday=@brithday,");
            strSql.Append("sex=@sex,");
            strSql.Append("family_name=@family_name,");
            strSql.Append("address=@address,");
            strSql.Append("state_id=@state_id,");
            strSql.Append("deposit=@deposit,");
            strSql.Append("amount_money=@amount_money,");
            strSql.Append("sort=@sort,");
            strSql.Append("lordRoomid=@lordRoomid,");
            strSql.Append("continuelive=@continuelive,");
            strSql.Append("phonenum=@phonenum");
            strSql.Append(" where occ_id=@occ_id");
            SqlParameter[] parameters = {
					new SqlParameter("@occ_no", SqlDbType.NVarChar,50),
					new SqlParameter("@order_id", SqlDbType.Int,4),
					new SqlParameter("@occ_name", SqlDbType.NVarChar,20),
					new SqlParameter("@occ_with", SqlDbType.NVarChar,10),
					new SqlParameter("@real_type_id", SqlDbType.Int,4),
					new SqlParameter("@room_number", SqlDbType.NVarChar,10),
					new SqlParameter("@real_scheme_id", SqlDbType.Int,4),
					new SqlParameter("@source_id", SqlDbType.Int,4),
					new SqlParameter("@mem_cardno", SqlDbType.NVarChar,50),
					new SqlParameter("@real_mode_id", SqlDbType.Int,4),
					new SqlParameter("@real_price", SqlDbType.Money,8),
					new SqlParameter("@occ_time", SqlDbType.DateTime),
					new SqlParameter("@stay_day", SqlDbType.Int,4),
					new SqlParameter("@stay_deposit", SqlDbType.Money,8),
					new SqlParameter("@depar_time", SqlDbType.DateTime),
					new SqlParameter("@pha_sched", SqlDbType.DateTime),
					new SqlParameter("@card_id", SqlDbType.Int,4),
					new SqlParameter("@card_no", SqlDbType.NVarChar,50),
					new SqlParameter("@brithday", SqlDbType.NVarChar,20),
					new SqlParameter("@sex", SqlDbType.NVarChar,1),
					new SqlParameter("@family_name", SqlDbType.NVarChar,20),
					new SqlParameter("@address", SqlDbType.NVarChar,50),
					new SqlParameter("@state_id", SqlDbType.Int,4),
					new SqlParameter("@deposit", SqlDbType.Money,8),
					new SqlParameter("@amount_money", SqlDbType.Money,8),
					new SqlParameter("@sort", SqlDbType.NVarChar,50),
					new SqlParameter("@lordRoomid", SqlDbType.NVarChar,50),
					new SqlParameter("@continuelive", SqlDbType.Int,4),
					new SqlParameter("@phonenum", SqlDbType.NVarChar,50),
					new SqlParameter("@occ_id", SqlDbType.Int,4)};
            parameters[0].Value = model.occ_no;
            parameters[1].Value = model.order_id;
            parameters[2].Value = model.occ_name;
            parameters[3].Value = model.occ_with;
            parameters[4].Value = model.real_type_id;
            parameters[5].Value = model.room_number;
            parameters[6].Value = model.real_scheme_id;
            parameters[7].Value = model.source_id;
            parameters[8].Value = model.mem_cardno;
            parameters[9].Value = model.real_mode_id;
            parameters[10].Value = model.real_price;
            parameters[11].Value = model.occ_time;
            parameters[12].Value = model.stay_day;
            parameters[13].Value = model.stay_deposit;
            parameters[14].Value = model.depar_time;
            parameters[15].Value = model.pha_sched;
            parameters[16].Value = model.card_id;
            parameters[17].Value = model.card_no;
            parameters[18].Value = model.brithday;
            parameters[19].Value = model.sex;
            parameters[20].Value = model.family_name;
            parameters[21].Value = model.address;
            parameters[22].Value = model.state_id;
            parameters[23].Value = model.deposit;
            parameters[24].Value = model.amount_money;
            parameters[25].Value = model.sort;
            parameters[26].Value = model.lordRoomid;
            parameters[27].Value = model.continuelive;
            parameters[28].Value = model.phonenum;
            parameters[29].Value = model.occ_id;

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
        public bool Delete(int occ_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from occu_informx ");
            strSql.Append(" where occ_id=@occ_id");
            SqlParameter[] parameters = {
					new SqlParameter("@occ_id", SqlDbType.Int,4)
			};
            parameters[0].Value = occ_id;

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
        public bool Deletes(string SQL)
        {
            SqlParameter[] parameters = null;
            int rows = DbHelperSQL.ExecuteSql(SQL, parameters);
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
        public bool DeleteList(string occ_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from occu_informx ");
            strSql.Append(" where occ_id in (" + occ_idlist + ")  ");
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
        public CdHotelManage.Model.occu_informx GetModel(int occ_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 occ_id,occ_no,order_id,occ_name,occ_with,real_type_id,room_number,real_scheme_id,source_id,mem_cardno,real_mode_id,real_price,occ_time,stay_day,stay_deposit,depar_time,pha_sched,card_id,card_no,brithday,sex,family_name,address,state_id,deposit,amount_money,sort,lordRoomid,continuelive,phonenum from occu_informx ");
            strSql.Append(" where occ_id=@occ_id");
            SqlParameter[] parameters = {
					new SqlParameter("@occ_id", SqlDbType.Int,4)
			};
            parameters[0].Value = occ_id;

            CdHotelManage.Model.occu_informx model = new CdHotelManage.Model.occu_informx();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["occ_id"] != null && ds.Tables[0].Rows[0]["occ_id"].ToString() != "")
                {
                    model.occ_id = int.Parse(ds.Tables[0].Rows[0]["occ_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["occ_no"] != null && ds.Tables[0].Rows[0]["occ_no"].ToString() != "")
                {
                    model.occ_no = ds.Tables[0].Rows[0]["occ_no"].ToString();
                }
                if (ds.Tables[0].Rows[0]["order_id"] != null && ds.Tables[0].Rows[0]["order_id"].ToString() != "")
                {
                    model.order_id = int.Parse(ds.Tables[0].Rows[0]["order_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["occ_name"] != null && ds.Tables[0].Rows[0]["occ_name"].ToString() != "")
                {
                    model.occ_name = ds.Tables[0].Rows[0]["occ_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["occ_with"] != null && ds.Tables[0].Rows[0]["occ_with"].ToString() != "")
                {
                    model.occ_with = ds.Tables[0].Rows[0]["occ_with"].ToString();
                }
                if (ds.Tables[0].Rows[0]["real_type_id"] != null && ds.Tables[0].Rows[0]["real_type_id"].ToString() != "")
                {
                    model.real_type_id = int.Parse(ds.Tables[0].Rows[0]["real_type_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["room_number"] != null && ds.Tables[0].Rows[0]["room_number"].ToString() != "")
                {
                    model.room_number = ds.Tables[0].Rows[0]["room_number"].ToString();
                }
                if (ds.Tables[0].Rows[0]["real_scheme_id"] != null && ds.Tables[0].Rows[0]["real_scheme_id"].ToString() != "")
                {
                    model.real_scheme_id = int.Parse(ds.Tables[0].Rows[0]["real_scheme_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["source_id"] != null && ds.Tables[0].Rows[0]["source_id"].ToString() != "")
                {
                    model.source_id = int.Parse(ds.Tables[0].Rows[0]["source_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mem_cardno"] != null && ds.Tables[0].Rows[0]["mem_cardno"].ToString() != "")
                {
                    model.mem_cardno = ds.Tables[0].Rows[0]["mem_cardno"].ToString();
                }
                if (ds.Tables[0].Rows[0]["real_mode_id"] != null && ds.Tables[0].Rows[0]["real_mode_id"].ToString() != "")
                {
                    model.real_mode_id = int.Parse(ds.Tables[0].Rows[0]["real_mode_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["real_price"] != null && ds.Tables[0].Rows[0]["real_price"].ToString() != "")
                {
                    model.real_price = decimal.Parse(ds.Tables[0].Rows[0]["real_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["occ_time"] != null && ds.Tables[0].Rows[0]["occ_time"].ToString() != "")
                {
                    model.occ_time = DateTime.Parse(ds.Tables[0].Rows[0]["occ_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["stay_day"] != null && ds.Tables[0].Rows[0]["stay_day"].ToString() != "")
                {
                    model.stay_day = int.Parse(ds.Tables[0].Rows[0]["stay_day"].ToString());
                }
                if (ds.Tables[0].Rows[0]["stay_deposit"] != null && ds.Tables[0].Rows[0]["stay_deposit"].ToString() != "")
                {
                    model.stay_deposit = decimal.Parse(ds.Tables[0].Rows[0]["stay_deposit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["depar_time"] != null && ds.Tables[0].Rows[0]["depar_time"].ToString() != "")
                {
                    model.depar_time = DateTime.Parse(ds.Tables[0].Rows[0]["depar_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pha_sched"] != null && ds.Tables[0].Rows[0]["pha_sched"].ToString() != "")
                {
                    model.pha_sched = DateTime.Parse(ds.Tables[0].Rows[0]["pha_sched"].ToString());
                }
                if (ds.Tables[0].Rows[0]["card_id"] != null && ds.Tables[0].Rows[0]["card_id"].ToString() != "")
                {
                    model.card_id = int.Parse(ds.Tables[0].Rows[0]["card_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["card_no"] != null && ds.Tables[0].Rows[0]["card_no"].ToString() != "")
                {
                    model.card_no = ds.Tables[0].Rows[0]["card_no"].ToString();
                }
                if (ds.Tables[0].Rows[0]["brithday"] != null && ds.Tables[0].Rows[0]["brithday"].ToString() != "")
                {
                    model.brithday = ds.Tables[0].Rows[0]["brithday"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sex"] != null && ds.Tables[0].Rows[0]["sex"].ToString() != "")
                {
                    model.sex = ds.Tables[0].Rows[0]["sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["family_name"] != null && ds.Tables[0].Rows[0]["family_name"].ToString() != "")
                {
                    model.family_name = ds.Tables[0].Rows[0]["family_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["address"] != null && ds.Tables[0].Rows[0]["address"].ToString() != "")
                {
                    model.address = ds.Tables[0].Rows[0]["address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["state_id"] != null && ds.Tables[0].Rows[0]["state_id"].ToString() != "")
                {
                    model.state_id = int.Parse(ds.Tables[0].Rows[0]["state_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["deposit"] != null && ds.Tables[0].Rows[0]["deposit"].ToString() != "")
                {
                    model.deposit = decimal.Parse(ds.Tables[0].Rows[0]["deposit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["amount_money"] != null && ds.Tables[0].Rows[0]["amount_money"].ToString() != "")
                {
                    model.amount_money = decimal.Parse(ds.Tables[0].Rows[0]["amount_money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort"] != null && ds.Tables[0].Rows[0]["sort"].ToString() != "")
                {
                    model.sort = ds.Tables[0].Rows[0]["sort"].ToString();
                }
                if (ds.Tables[0].Rows[0]["lordRoomid"] != null && ds.Tables[0].Rows[0]["lordRoomid"].ToString() != "")
                {
                    model.lordRoomid = ds.Tables[0].Rows[0]["lordRoomid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["continuelive"] != null && ds.Tables[0].Rows[0]["continuelive"].ToString() != "")
                {
                    model.continuelive = int.Parse(ds.Tables[0].Rows[0]["continuelive"].ToString());
                }
                if (ds.Tables[0].Rows[0]["phonenum"] != null && ds.Tables[0].Rows[0]["phonenum"].ToString() != "")
                {
                    model.phonenum = ds.Tables[0].Rows[0]["phonenum"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select occ_id,occ_no,order_id,occ_name,occ_with,real_type_id,room_number,real_scheme_id,source_id,mem_cardno,real_mode_id,real_price,occ_time,stay_day,stay_deposit,depar_time,pha_sched,card_id,card_no,brithday,sex,family_name,address,state_id,deposit,amount_money,sort,lordRoomid,continuelive,phonenum ");
            strSql.Append(" FROM occu_informx ");
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
            strSql.Append(" occ_id,occ_no,order_id,occ_name,occ_with,real_type_id,room_number,real_scheme_id,source_id,mem_cardno,real_mode_id,real_price,occ_time,stay_day,stay_deposit,depar_time,pha_sched,card_id,card_no,brithday,sex,family_name,address,state_id,deposit,amount_money,sort,lordRoomid,continuelive,phonenum ");
            strSql.Append(" FROM occu_informx ");
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
            strSql.Append("select count(1) FROM occu_informx ");
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
                strSql.Append("order by T.occ_id desc");
            }
            strSql.Append(")AS Row, T.*  from occu_informx T ");
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
            parameters[0].Value = "occu_informx";
            parameters[1].Value = "occ_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}
