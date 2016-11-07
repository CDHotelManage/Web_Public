using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:occu_infor
	/// </summary>
    public partial class occu_infor
    {
        public occu_infor()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("occ_id", "occu_infor");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int occ_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from occu_infor");
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
        public int Add(CdHotelManage.Model.occu_infor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into occu_infor(");
            strSql.Append("occ_no,order_id,occ_name,occ_with,real_type_id,room_number,real_scheme_id,source_id,mem_cardno,real_mode_id,real_price,occ_time,pre_live_day,stay_day,stay_deposit,depar_time,pha_sched,card_id,card_no,brithday,sex,family_name,address,meth_pay_id,state_id,deposit,pay_money,amount_money,amount_rece,return_money,sale_id,remark,sort,lordRoomid,continuelive,phonenum,userid,tuifaId,occ_StyDate,occ_headerImg,Occ_TfTime,gzRoom,Accounts,CpID)");
            strSql.Append(" values (");
            strSql.Append("@occ_no,@order_id,@occ_name,@occ_with,@real_type_id,@room_number,@real_scheme_id,@source_id,@mem_cardno,@real_mode_id,@real_price,@occ_time,@pre_live_day,@stay_day,@stay_deposit,@depar_time,@pha_sched,@card_id,@card_no,@brithday,@sex,@family_name,@address,@meth_pay_id,@state_id,@deposit,@pay_money,@amount_money,@amount_rece,@return_money,@sale_id,@remark,@sort,@lordRoomid,@continuelive,@phonenum,@userid,@tuifaId,@occ_StyDate,@occ_headerImg,@Occ_TfTime,@gzRoom,@Accounts,@CpID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@occ_no", SqlDbType.NVarChar,50),
					new SqlParameter("@order_id", SqlDbType.NVarChar,50),
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
					new SqlParameter("@pre_live_day", SqlDbType.Int,4),
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
					new SqlParameter("@meth_pay_id", SqlDbType.Int,4),
					new SqlParameter("@state_id", SqlDbType.Int,4),
					new SqlParameter("@deposit", SqlDbType.Money,8),
					new SqlParameter("@pay_money", SqlDbType.Money,8),
					new SqlParameter("@amount_money", SqlDbType.Money,8),
					new SqlParameter("@amount_rece", SqlDbType.Money,8),
					new SqlParameter("@return_money", SqlDbType.Money,8),
					new SqlParameter("@sale_id", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.NVarChar),
					new SqlParameter("@sort", SqlDbType.NVarChar,50),
					new SqlParameter("@lordRoomid", SqlDbType.NVarChar,50),
					new SqlParameter("@continuelive", SqlDbType.Int,4),
					new SqlParameter("@phonenum", SqlDbType.NVarChar,50),
                    new SqlParameter("@userid", SqlDbType.NVarChar,50),
                   	new SqlParameter("@tuifaId", SqlDbType.Int,4),
                   	new SqlParameter("@occ_StyDate", SqlDbType.Int,4), 
                    new SqlParameter("@occ_headerImg", SqlDbType.NVarChar,50),
                    new SqlParameter("@Occ_TfTime",SqlDbType.DateTime),
                    new SqlParameter("@gzRoom",SqlDbType.NVarChar,50),
                    new SqlParameter("@Accounts",SqlDbType.NVarChar,50),
                    new SqlParameter("@CpID",SqlDbType.Int,4)
                                        };
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
            parameters[12].Value = model.pre_live_day;
            parameters[13].Value = model.stay_day;
            parameters[14].Value = model.stay_deposit;
            parameters[15].Value = model.depar_time;
            parameters[16].Value = model.pha_sched;
            parameters[17].Value = model.card_id;
            parameters[18].Value = model.card_no;
            parameters[19].Value = model.brithday;
            parameters[20].Value = model.sex;
            parameters[21].Value = model.family_name;
            parameters[22].Value = model.address;
            parameters[23].Value = model.meth_pay_id;
            parameters[24].Value = model.state_id;
            parameters[25].Value = model.deposit;
            parameters[26].Value = model.pay_money;
            parameters[27].Value = model.amount_money;
            parameters[28].Value = model.amount_rece;
            parameters[29].Value = model.return_money;
            parameters[30].Value = model.sale_id;
            parameters[31].Value = model.remark;
            parameters[32].Value = model.sort;
            parameters[33].Value = model.lordRoomid;
            parameters[34].Value = model.continuelive;
            parameters[35].Value = model.phonenum;
            parameters[36].Value = model.Userid;
            parameters[37].Value = model.tuifaId;
            parameters[38].Value = model.Occ_StyDate;
            parameters[39].Value = model.Occ_headerImg;
            parameters[40].Value = model.Occ_TfTime;
            parameters[41].Value = model.GzRoom;
            parameters[42].Value = model.Accounts;
            parameters[43].Value = model.CpID;
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
        public bool Update(CdHotelManage.Model.occu_infor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update occu_infor set ");
            //strSql.Append("occ_no=@occ_no,");
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
            strSql.Append("pre_live_day=@pre_live_day,");
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
            strSql.Append("meth_pay_id=@meth_pay_id,");
            strSql.Append("state_id=@state_id,");
            strSql.Append("deposit=@deposit,");
            strSql.Append("pay_money=@pay_money,");
            strSql.Append("amount_money=@amount_money,");
            strSql.Append("amount_rece=@amount_rece,");
            strSql.Append("return_money=@return_money,");
            strSql.Append("sale_id=@sale_id,");
            strSql.Append("remark=@remark,");
            strSql.Append("sort=@sort,");
            strSql.Append("lordRoomid=@lordRoomid,");
            strSql.Append("continuelive=@continuelive,");
            strSql.Append("phonenum=@phonenum,");
            strSql.Append("userid=@userid,");
            strSql.Append("occ_StyDate=@occ_StyDate,");
            strSql.Append("occ_headerImg=@occ_headerImg,");
            strSql.Append("occ_TfTime=@occ_TfTime,");
            strSql.Append("gzRoom=@gzRoom,");
            strSql.Append("Accounts=@Accounts,");
            strSql.Append("CpID=@CpID");
            strSql.Append(" where occ_id=@occ_id");
            SqlParameter[] parameters = {
					//new SqlParameter("@occ_no", SqlDbType.NVarChar,50),
					new SqlParameter("@order_id", SqlDbType.NVarChar,50),
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
					new SqlParameter("@pre_live_day", SqlDbType.Int,4),
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
					new SqlParameter("@meth_pay_id", SqlDbType.Int,4),
					new SqlParameter("@state_id", SqlDbType.Int,4),
					new SqlParameter("@deposit", SqlDbType.Money,8),
					new SqlParameter("@pay_money", SqlDbType.Money,8),
					new SqlParameter("@amount_money", SqlDbType.Money,8),
					new SqlParameter("@amount_rece", SqlDbType.Money,8),
					new SqlParameter("@return_money", SqlDbType.Money,8),
					new SqlParameter("@sale_id", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.NVarChar),
					new SqlParameter("@sort", SqlDbType.NVarChar,50),
					new SqlParameter("@lordRoomid", SqlDbType.NVarChar,50),
					new SqlParameter("@continuelive", SqlDbType.Int,4),
					new SqlParameter("@phonenum", SqlDbType.NVarChar,50),
                    new SqlParameter("@userid", SqlDbType.NVarChar,50),
                    new SqlParameter("@occ_StyDate", SqlDbType.NVarChar,50),
                    new SqlParameter("@occ_headerImg", SqlDbType.NVarChar,50),
                     new SqlParameter("@Occ_TfTime",SqlDbType.DateTime),
					new SqlParameter("@occ_id", SqlDbType.Int,4),
                                        new SqlParameter("@gzRoom",SqlDbType.NVarChar,50),
                    new SqlParameter("@Accounts",SqlDbType.NVarChar,50),
                    new SqlParameter("@CpID",SqlDbType.Int,4)

                                        };
           // parameters[0].Value = model.occ_no;
            parameters[0].Value = model.order_id;
            parameters[1].Value = model.occ_name;
            parameters[2].Value = model.occ_with;
            parameters[3].Value = model.real_type_id;
            parameters[4].Value = model.room_number;
            parameters[5].Value = model.real_scheme_id;
            parameters[6].Value = model.source_id;
            parameters[7].Value = model.mem_cardno;
            parameters[8].Value = model.real_mode_id;
            parameters[9].Value = model.real_price;
            parameters[10].Value = model.occ_time;
            parameters[11].Value = model.pre_live_day;
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
            parameters[22].Value = model.meth_pay_id;
            parameters[23].Value = model.state_id;
            parameters[24].Value = model.deposit;
            parameters[25].Value = model.pay_money;
            parameters[26].Value = model.amount_money;
            parameters[27].Value = model.amount_rece;
            parameters[28].Value = model.return_money;
            parameters[29].Value = model.sale_id;
            parameters[30].Value = model.remark;
            parameters[31].Value = model.sort;
            parameters[32].Value = model.lordRoomid;
            parameters[33].Value = model.continuelive;
            parameters[34].Value = model.phonenum;
            parameters[35].Value = model.Userid;
            parameters[36].Value = model.Occ_StyDate;
            parameters[37].Value = model.Occ_headerImg;
            parameters[38].Value = model.Occ_TfTime;
            parameters[39].Value = model.occ_id;
            parameters[40].Value = model.GzRoom;
            parameters[41].Value = model.Accounts;
            parameters[42].Value = model.CpID;
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
        /// 更新一条数据2
        /// </summary>
        public bool Updates(string SQL)
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
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.occu_infor DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.occu_infor model = new CdHotelManage.Model.occu_infor();
            if (row != null)
            {
                if (row["occ_id"] != null && row["occ_id"].ToString() != "")
                {
                    model.occ_id = int.Parse(row["occ_id"].ToString());
                }
                if (row["occ_no"] != null)
                {
                    model.occ_no = row["occ_no"].ToString();
                }
                if (row["order_id"] != null && row["order_id"].ToString() != "")
                {
                    model.order_id = row["order_id"].ToString();
                }
                if (row["occ_name"] != null)
                {
                    model.occ_name = row["occ_name"].ToString();
                }
                if (row["occ_with"] != null)
                {
                    model.occ_with = row["occ_with"].ToString();
                }
                if (row["real_type_id"] != null && row["real_type_id"].ToString() != "")
                {
                    model.real_type_id = int.Parse(row["real_type_id"].ToString());
                }
                if (row["room_number"] != null)
                {
                    model.room_number = row["room_number"].ToString();
                }
                if (row["real_scheme_id"] != null && row["real_scheme_id"].ToString() != "")
                {
                    model.real_scheme_id = int.Parse(row["real_scheme_id"].ToString());
                }
                if (row["source_id"] != null && row["source_id"].ToString() != "")
                {
                    model.source_id = int.Parse(row["source_id"].ToString());
                }
                if (row["mem_cardno"] != null)
                {
                    model.mem_cardno = row["mem_cardno"].ToString();
                }
                if (row["real_mode_id"] != null && row["real_mode_id"].ToString() != "")
                {
                    model.real_mode_id = int.Parse(row["real_mode_id"].ToString());
                }
                if (row["real_price"] != null && row["real_price"].ToString() != "")
                {
                    model.real_price = decimal.Parse(row["real_price"].ToString());
                }
                if (row["occ_time"] != null && row["occ_time"].ToString() != "")
                {
                    model.occ_time = DateTime.Parse(row["occ_time"].ToString());
                }
                if (row["pre_live_day"] != null && row["pre_live_day"].ToString() != "")
                {
                    model.pre_live_day = int.Parse(row["pre_live_day"].ToString());
                }
                if (row["stay_day"] != null && row["stay_day"].ToString() != "")
                {
                    model.stay_day = int.Parse(row["stay_day"].ToString());
                }
                if (row["stay_deposit"] != null && row["stay_deposit"].ToString() != "")
                {
                    model.stay_deposit = decimal.Parse(row["stay_deposit"].ToString());
                }
                if (row["depar_time"] != null && row["depar_time"].ToString() != "")
                {
                    model.depar_time = DateTime.Parse(row["depar_time"].ToString());
                }
                if (row["pha_sched"] != null && row["pha_sched"].ToString() != "")
                {
                    model.pha_sched = DateTime.Parse(row["pha_sched"].ToString());
                }
                if (row["card_id"] != null && row["card_id"].ToString() != "")
                {
                    model.card_id = int.Parse(row["card_id"].ToString());
                }
                if (row["card_no"] != null)
                {
                    model.card_no = row["card_no"].ToString();
                }
                if (row["brithday"] != null)
                {
                    model.brithday = row["brithday"].ToString();
                }
                if (row["sex"] != null)
                {
                    model.sex = row["sex"].ToString();
                }
                if (row["family_name"] != null)
                {
                    model.family_name = row["family_name"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["meth_pay_id"] != null && row["meth_pay_id"].ToString() != "")
                {
                    model.meth_pay_id = int.Parse(row["meth_pay_id"].ToString());
                }
                if (row["state_id"] != null && row["state_id"].ToString() != "")
                {
                    model.state_id = int.Parse(row["state_id"].ToString());
                }
                if (row["deposit"] != null && row["deposit"].ToString() != "")
                {
                    model.deposit = decimal.Parse(row["deposit"].ToString());
                }
                if (row["pay_money"] != null && row["pay_money"].ToString() != "")
                {
                    model.pay_money = decimal.Parse(row["pay_money"].ToString());
                }
                if (row["amount_money"] != null && row["amount_money"].ToString() != "")
                {
                    model.amount_money = decimal.Parse(row["amount_money"].ToString());
                }
                if (row["amount_rece"] != null && row["amount_rece"].ToString() != "")
                {
                    model.amount_rece = decimal.Parse(row["amount_rece"].ToString());
                }
                if (row["return_money"] != null && row["return_money"].ToString() != "")
                {
                    model.return_money = decimal.Parse(row["return_money"].ToString());
                }
                if (row["sale_id"] != null && row["sale_id"].ToString() != "")
                {
                    model.sale_id = int.Parse(row["sale_id"].ToString());
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["sort"] != null)
                {
                    model.sort = row["sort"].ToString();
                }
                if (row["lordRoomid"] != null && row["lordRoomid"].ToString() != "")
                {
                    model.lordRoomid = (row["lordRoomid"].ToString());
                }
                if (row["phonenum"] != null && row["phonenum"].ToString() != "")
                {
                    model.phonenum = (row["phonenum"].ToString());
                }
                if (row["userid"] != null && row["userid"].ToString() != "")
                {
                    model.Userid = (row["userid"].ToString());
                }
                if (row["occ_StyDate"] != null && row["occ_StyDate"].ToString() != "")
                {
                    model.Occ_StyDate = int.Parse(row["occ_StyDate"].ToString());
                }
                if (row["occ_headerImg"] != null && row["occ_headerImg"].ToString() != "")
                {
                    model.Occ_headerImg = (row["occ_headerImg"].ToString());
                }
                if (row["occ_TfTime"] != null && row["occ_TfTime"].ToString() != "")
                {
                    model.Occ_TfTime = Convert.ToDateTime(row["Occ_TfTime"]);
                }
                if (row["gzRoom"] != null && row["gzRoom"].ToString() != "")
                {
                    model.GzRoom = row["gzRoom"].ToString();
                }
                if (row["accounts"] != null && row["accounts"].ToString() != "")
                {
                    model.Accounts = row["accounts"].ToString();
                }
                if (row["CpID"] != null && row["CpID"].ToString() != "")
                {
                    model.CpID = Convert.ToInt32(row["CpID"]);
                }


            }
            return model;
        }

        public CdHotelManage.Model.occu_infor DataRowToModel23(DataRow row)
        {
            CdHotelManage.Model.occu_infor model = new CdHotelManage.Model.occu_infor();
            if (row != null)
            {

                if (row["card_no"] != null)
                {
                    model.card_no = row["card_no"].ToString();
                }
                
                if (row["occ_name"] != null)
                {
                    model.occ_name = row["occ_name"].ToString();
                }

                if (row["c"] != null)
                {
                    model.remark = row["c"].ToString();
                }
                
            }
            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.occu_infor DataRowToModel1(DataRow row)
        {
            CdHotelManage.Model.occu_infor model = new CdHotelManage.Model.occu_infor();
            if (row != null)
            {
                if (row["occ_id"] != null && row["occ_id"].ToString() != "")
                {
                    model.occ_id = int.Parse(row["occ_id"].ToString());
                }
                if (row["occ_no"] != null)
                {
                    model.occ_no = row["occ_no"].ToString();
                }
                if (row["order_id"] != null && row["order_id"].ToString() != "")
                {
                    model.order_id = row["order_id"].ToString();
                }
                if (row["occ_name"] != null)
                {
                    model.occ_name = row["occ_name"].ToString();
                }
                if (row["occ_with"] != null)
                {
                    model.occ_with = row["occ_with"].ToString();
                }
                DAL.room_type dalrt = new room_type();
                if (row["real_type_id"] != null && row["real_type_id"].ToString() != "")
                {
                    model.real_type_id = int.Parse(row["real_type_id"].ToString());
                    model.Room_type_model = new Model.room_type();
                    model.Room_type_model = dalrt.DataRowToModel(row);
                }
                if (row["room_number"] != null)
                {
                    model.room_number = row["room_number"].ToString();
                }
                DAL.hourse_scheme dalhs = new hourse_scheme();
                if (row["real_scheme_id"] != null && row["real_scheme_id"].ToString() != "")
                {
                    model.real_scheme_id = int.Parse(row["real_scheme_id"].ToString());
                    model.Hourse_scheme_model = new Model.hourse_scheme();
                    model.Hourse_scheme_model = dalhs.DataRowToModel(row);
                }
                if (row["source_id"] != null && row["source_id"].ToString() != "")
                {
                    model.source_id = int.Parse(row["source_id"].ToString());
                }
                if (row["mem_cardno"] != null)
                {
                    model.mem_cardno = row["mem_cardno"].ToString();
                }
                DAL.real_mode dalrm = new real_mode();
                if (row["real_mode_id"] != null && row["real_mode_id"].ToString() != "")
                {
                    model.real_mode_id = int.Parse(row["real_mode_id"].ToString());
                    model.Real_mode_mode = new Model.real_mode();
                    model.Real_mode_mode = dalrm.DataRowToModel(row);
                }
                if (row["real_price"] != null && row["real_price"].ToString() != "")
                {
                    model.real_price = decimal.Parse(row["real_price"].ToString());
                }
                if (row["occ_time"] != null && row["occ_time"].ToString() != "")
                {
                    model.occ_time = DateTime.Parse(row["occ_time"].ToString());
                }
                if (row["pre_live_day"] != null && row["pre_live_day"].ToString() != "")
                {
                    model.pre_live_day = int.Parse(row["pre_live_day"].ToString());
                }
                if (row["stay_day"] != null && row["stay_day"].ToString() != "")
                {
                    model.stay_day = int.Parse(row["stay_day"].ToString());
                }
                if (row["stay_deposit"] != null && row["stay_deposit"].ToString() != "")
                {
                    model.stay_deposit = decimal.Parse(row["stay_deposit"].ToString());
                }
                if (row["depar_time"] != null && row["depar_time"].ToString() != "")
                {
                    model.depar_time = DateTime.Parse(row["depar_time"].ToString());
                }
                if (row["pha_sched"] != null && row["pha_sched"].ToString() != "")
                {
                    model.pha_sched = DateTime.Parse(row["pha_sched"].ToString());
                }
                DAL.card_type dalct = new card_type();
                if (row["card_id"] != null && row["card_id"].ToString() != "")
                {
                    model.card_id = int.Parse(row["card_id"].ToString());
                    model.Card_type_model = new Model.card_type();
                    model.Card_type_model = dalct.DataRowToModel(row);
                }
                if (row["card_no"] != null)
                {
                    model.card_no = row["card_no"].ToString();
                }
                if (row["brithday"] != null)
                {
                    model.brithday = row["brithday"].ToString();
                }
                if (row["sex"] != null)
                {
                    model.sex = row["sex"].ToString();
                }
                if (row["family_name"] != null)
                {
                    model.family_name = row["family_name"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                DAL.meth_pay dalmp = new meth_pay();
                if (row["meth_pay_id"] != null && row["meth_pay_id"].ToString() != "")
                {
                    model.meth_pay_id = int.Parse(row["meth_pay_id"].ToString());
                    model.Meth_pay_model = new Model.meth_pay();
                    model.Meth_pay_model = dalmp.DataRowToModel(row);
                }
                if (row["state_id"] != null && row["state_id"].ToString() != "")
                {
                    model.state_id = int.Parse(row["state_id"].ToString());
                }
                if (row["deposit"] != null && row["deposit"].ToString() != "")
                {
                    model.deposit = decimal.Parse(row["deposit"].ToString());
                }
                if (row["pay_money"] != null && row["pay_money"].ToString() != "")
                {
                    model.pay_money = decimal.Parse(row["pay_money"].ToString());
                }
                if (row["amount_money"] != null && row["amount_money"].ToString() != "")
                {
                    model.amount_money = decimal.Parse(row["amount_money"].ToString());
                }
                if (row["amount_rece"] != null && row["amount_rece"].ToString() != "")
                {
                    model.amount_rece = decimal.Parse(row["amount_rece"].ToString());
                }
                if (row["return_money"] != null && row["return_money"].ToString() != "")
                {
                    model.return_money = decimal.Parse(row["return_money"].ToString());
                }
                if (row["sale_id"] != null && row["sale_id"].ToString() != "")
                {
                    model.sale_id = int.Parse(row["sale_id"].ToString());
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["phonenum"] != null)
                {
                    model.phonenum = row["phonenum"].ToString();
                }
                if (row["userid"] != null)
                {
                    model.Userid = row["userid"].ToString();
                }
                if (row["sort"] != null)
                {
                    model.sort = row["sort"].ToString();
                }
                if (row["occ_StyDate"] != null && row["occ_StyDate"].ToString() != "")
                {
                    model.Occ_StyDate = int.Parse(row["occ_StyDate"].ToString());
                }
                if (row["occ_headerImg"] != null && row["occ_headerImg"].ToString() != "")
                {
                    model.Occ_headerImg = (row["occ_headerImg"].ToString());
                }
                if (row["occ_TfTime"] != null && row["occ_TfTime"].ToString() != "")
                {
                    model.Occ_TfTime = Convert.ToDateTime(row["Occ_TfTime"]);
                }
                if (row["gzRoom"] != null && row["gzRoom"].ToString() != "")
                {
                    model.GzRoom = row["gzRoom"].ToString();
                }
                if (row["accounts"] != null && row["accounts"].ToString() != "")
                {
                    model.Accounts = row["accounts"].ToString();
                }
                if (row["CpID"] != null && row["CpID"].ToString() != "")
                {
                    model.CpID = Convert.ToInt32(row["CpID"]);
                }
            }
            return model;
        }

        public DataSet GetBookRoomPager(string sort, string order, int currentPage, int pageSize, string strWhere)
        {
            string _sql = @" select * from (select *,Row_number() over(order by " + sort + " " + order + ") as IDBookRoom from occu_infor " + strWhere + ") as IDWithRowNumber where IDBookRoom>=(" + currentPage + "-1)*" + pageSize + "+1 and IDBookRoom<=" + currentPage + "*" + pageSize + "";
            return DbHelperSQL.Query(_sql);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int occ_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from occu_infor ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string occ_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from occu_infor ");
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
        public CdHotelManage.Model.occu_infor GetModel(int occ_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 occ_id,occ_no,order_id,occ_name,occ_with,real_type_id,room_number,real_scheme_id,source_id,mem_cardno,real_mode_id,real_price,occ_time,pre_live_day,stay_day,stay_deposit,depar_time,pha_sched,card_id,card_no,brithday,sex,family_name,address,meth_pay_id,state_id,deposit,pay_money,amount_money,amount_rece,return_money,sale_id,remark,sort,lordRoomid,continuelive,userid ,occ_StyDate,occ_headerImg,occ_TfTime,gzRoom,accounts,CpID from occu_infor ");
            strSql.Append(" where occ_id=@occ_id");
            SqlParameter[] parameters = {
					new SqlParameter("@occ_id", SqlDbType.Int,4)
			};
            parameters[0].Value = occ_id;

            CdHotelManage.Model.occu_infor model = new CdHotelManage.Model.occu_infor();
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
                    model.order_id = ds.Tables[0].Rows[0]["order_id"].ToString();
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
                if (ds.Tables[0].Rows[0]["pre_live_day"] != null && ds.Tables[0].Rows[0]["pre_live_day"].ToString() != "")
                {
                    model.pre_live_day = int.Parse(ds.Tables[0].Rows[0]["pre_live_day"].ToString());
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
                if (ds.Tables[0].Rows[0]["meth_pay_id"] != null && ds.Tables[0].Rows[0]["meth_pay_id"].ToString() != "")
                {
                    model.meth_pay_id = int.Parse(ds.Tables[0].Rows[0]["meth_pay_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["state_id"] != null && ds.Tables[0].Rows[0]["state_id"].ToString() != "")
                {
                    model.state_id = int.Parse(ds.Tables[0].Rows[0]["state_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["deposit"] != null && ds.Tables[0].Rows[0]["deposit"].ToString() != "")
                {
                    model.deposit = decimal.Parse(ds.Tables[0].Rows[0]["deposit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pay_money"] != null && ds.Tables[0].Rows[0]["pay_money"].ToString() != "")
                {
                    model.pay_money = decimal.Parse(ds.Tables[0].Rows[0]["pay_money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["amount_money"] != null && ds.Tables[0].Rows[0]["amount_money"].ToString() != "")
                {
                    model.amount_money = decimal.Parse(ds.Tables[0].Rows[0]["amount_money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["amount_rece"] != null && ds.Tables[0].Rows[0]["amount_rece"].ToString() != "")
                {
                    model.amount_rece = decimal.Parse(ds.Tables[0].Rows[0]["amount_rece"].ToString());
                }
                if (ds.Tables[0].Rows[0]["return_money"] != null && ds.Tables[0].Rows[0]["return_money"].ToString() != "")
                {
                    model.return_money = decimal.Parse(ds.Tables[0].Rows[0]["return_money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sale_id"] != null && ds.Tables[0].Rows[0]["sale_id"].ToString() != "")
                {
                    model.sale_id = int.Parse(ds.Tables[0].Rows[0]["sale_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["remark"] != null && ds.Tables[0].Rows[0]["remark"].ToString() != "")
                {
                    model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
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
                if (ds.Tables[0].Rows[0]["userid"] != null && ds.Tables[0].Rows[0]["userid"].ToString() != "")
                {
                    model.Userid = ds.Tables[0].Rows[0]["userid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["occ_StyDate"] != null && ds.Tables[0].Rows[0]["occ_StyDate"].ToString() != "")
                {
                    model.Occ_StyDate = int.Parse(ds.Tables[0].Rows[0]["occ_StyDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["occ_headerImg"] != null && ds.Tables[0].Rows[0]["occ_headerImg"].ToString() != "")
                {
                    model.Occ_headerImg = ds.Tables[0].Rows[0]["occ_headerImg"].ToString();
                }
                if (ds.Tables[0].Rows[0]["occ_TfTime"] != null && ds.Tables[0].Rows[0]["occ_TfTime"].ToString() != "")
                {
                    model.Occ_TfTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["occ_TfTime"]);
                }
                if (ds.Tables[0].Rows[0]["gzRoom"] != null && ds.Tables[0].Rows[0]["gzRoom"].ToString() != "")
                {
                    model.GzRoom = ds.Tables[0].Rows[0]["gzRoom"].ToString();
                }
                if (ds.Tables[0].Rows[0]["accounts"] != null && ds.Tables[0].Rows[0]["accounts"].ToString() != "")
                {
                    model.Accounts =ds.Tables[0].Rows[0]["accounts"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CpID"] != null && ds.Tables[0].Rows[0]["CpID"].ToString() != "")
                {
                    model.CpID = Convert.ToInt32(ds.Tables[0].Rows[0]["CpID"]);
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体对象2
        /// </summary>
        public CdHotelManage.Model.occu_infor GetModels(string shwhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 occ_id,occ_no,order_id,occ_name,occ_with,real_type_id,room_number,real_scheme_id,source_id,mem_cardno,real_mode_id,real_price,occ_time,pre_live_day,stay_day,stay_deposit,depar_time,pha_sched,card_id,card_no,brithday,sex,family_name,address,meth_pay_id,state_id,deposit,pay_money,amount_money,amount_rece,return_money,sale_id,remark,sort,lordRoomid,continuelive,userid,occ_StyDate,occ_headerImg,occ_TfTime,gzRoom,accounts,CpID from occu_infor ");
            strSql.Append(shwhere);
            SqlParameter[] parameters = {
					new SqlParameter("@occ_id", SqlDbType.Int,4)
			};
            //parameters[0].Value = occ_id;

            CdHotelManage.Model.occu_infor model = new CdHotelManage.Model.occu_infor();
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
                    model.order_id = ds.Tables[0].Rows[0]["order_id"].ToString();
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
                if (ds.Tables[0].Rows[0]["pre_live_day"] != null && ds.Tables[0].Rows[0]["pre_live_day"].ToString() != "")
                {
                    model.pre_live_day = int.Parse(ds.Tables[0].Rows[0]["pre_live_day"].ToString());
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
                if (ds.Tables[0].Rows[0]["meth_pay_id"] != null && ds.Tables[0].Rows[0]["meth_pay_id"].ToString() != "")
                {
                    model.meth_pay_id = int.Parse(ds.Tables[0].Rows[0]["meth_pay_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["state_id"] != null && ds.Tables[0].Rows[0]["state_id"].ToString() != "")
                {
                    model.state_id = int.Parse(ds.Tables[0].Rows[0]["state_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["deposit"] != null && ds.Tables[0].Rows[0]["deposit"].ToString() != "")
                {
                    model.deposit = decimal.Parse(ds.Tables[0].Rows[0]["deposit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pay_money"] != null && ds.Tables[0].Rows[0]["pay_money"].ToString() != "")
                {
                    model.pay_money = decimal.Parse(ds.Tables[0].Rows[0]["pay_money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["amount_money"] != null && ds.Tables[0].Rows[0]["amount_money"].ToString() != "")
                {
                    model.amount_money = decimal.Parse(ds.Tables[0].Rows[0]["amount_money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["amount_rece"] != null && ds.Tables[0].Rows[0]["amount_rece"].ToString() != "")
                {
                    model.amount_rece = decimal.Parse(ds.Tables[0].Rows[0]["amount_rece"].ToString());
                }
                if (ds.Tables[0].Rows[0]["return_money"] != null && ds.Tables[0].Rows[0]["return_money"].ToString() != "")
                {
                    model.return_money = decimal.Parse(ds.Tables[0].Rows[0]["return_money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sale_id"] != null && ds.Tables[0].Rows[0]["sale_id"].ToString() != "")
                {
                    model.sale_id = int.Parse(ds.Tables[0].Rows[0]["sale_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["remark"] != null && ds.Tables[0].Rows[0]["remark"].ToString() != "")
                {
                    model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
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
                    model.lordRoomid = ds.Tables[0].Rows[0]["continuelive"].ToString();
                }
                if (ds.Tables[0].Rows[0]["room_number"] != null && ds.Tables[0].Rows[0]["room_number"].ToString() != "")
                {
                    model.lordRoomid = ds.Tables[0].Rows[0]["room_number"].ToString();
                }
                if (ds.Tables[0].Rows[0]["userid"] != null && ds.Tables[0].Rows[0]["userid"].ToString() != "")
                {
                    model.Userid = ds.Tables[0].Rows[0]["userid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["occ_StyDate"] != null && ds.Tables[0].Rows[0]["occ_StyDate"].ToString() != "")
                {
                    model.Occ_StyDate = int.Parse(ds.Tables[0].Rows[0]["occ_StyDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["occ_headerImg"] != null && ds.Tables[0].Rows[0]["occ_headerImg"].ToString() != "")
                {
                    model.Occ_headerImg = ds.Tables[0].Rows[0]["occ_headerImg"].ToString();
                }
                if (ds.Tables[0].Rows[0]["occ_TfTime"] != null && ds.Tables[0].Rows[0]["occ_TfTime"].ToString() != "")
                {
                    model.Occ_TfTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["occ_TfTime"]);
                }
                if (ds.Tables[0].Rows[0]["gzRoom"] != null && ds.Tables[0].Rows[0]["gzRoom"].ToString() != "")
                {
                    model.GzRoom = ds.Tables[0].Rows[0]["gzRoom"].ToString();
                }
                if (ds.Tables[0].Rows[0]["accounts"] != null && ds.Tables[0].Rows[0]["accounts"].ToString() != "")
                {
                    model.Accounts = ds.Tables[0].Rows[0]["accounts"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CpID"] != null && ds.Tables[0].Rows[0]["CpID"].ToString() != "")
                {
                    model.CpID = Convert.ToInt32(ds.Tables[0].Rows[0]["CpID"]);
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
            strSql.Append("select occ_id,occ_no,order_id,occ_name,occ_with,real_type_id,room_number,real_scheme_id,source_id,mem_cardno,real_mode_id,real_price,occ_time,pre_live_day,stay_day,stay_deposit,depar_time,pha_sched,card_id,card_no,brithday,sex,family_name,address,meth_pay_id,state_id,deposit,pay_money,amount_money,amount_rece,return_money,sale_id,remark,sort,lordRoomid,userid,phonenum,occ_headerImg,occ_StyDate,occ_TfTime,gzRoom,accounts,CpID ");
            strSql.Append(" FROM occu_infor ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListNamecard(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct occ_name,card_no,count(occ_name) as c");
            strSql.Append(" FROM occu_infor ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListed(string strWhere,string join)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM occu_infor "+join);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetLists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select occ_id,occ_no,order_id,occ_name,occ_with,real_type_id,room_number,real_scheme_id,source_id,mem_cardno,real_mode_id,real_price,occ_time,pre_live_day,stay_day,stay_deposit,depar_time,pha_sched,card_id,card_no,brithday,sex,family_name,address,meth_pay_id,state_id,deposit,pay_money,amount_money,amount_rece,return_money,sale_id,remark,sort,lordRoomid,userid,phonenum,occ_headerImg,occ_StyDate,occ_TfTime,gzRoom,accounts,CpID ");
            strSql.Append(" FROM occu_infor ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" occ_id,occ_no,order_id,occ_name,occ_with,real_type_id,room_number,real_scheme_id,source_id,mem_cardno,real_mode_id,real_price,occ_time,pre_live_day,stay_day,stay_deposit,depar_time,pha_sched,card_id,card_no,brithday,sex,family_name,address,meth_pay_id,state_id,deposit,pay_money,amount_money,amount_rece,return_money,sale_id,remark,sort,userid,lordRoomid,occ_StyDate,occ_headerImg,occ_TfTime,gzRoom,accounts,CpID ");
            strSql.Append(" FROM occu_infor ");
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
            strSql.Append("select count(1) FROM occu_infor ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
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
            strSql.Append(")AS Row, T.*  from occu_infor T ");
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
            parameters[0].Value = "occu_infor";
            parameters[1].Value = "occ_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
        #region  ExtensionMethod

        #endregion  ExtensionMethod

        /// <summary>
        /// 通过日期查询当日的报表数据
        /// </summary>
        /// <param name="day"></param>
        public List<Model.occu_infor> GetDaySheet(string strTimeWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from (select * from occu_infor  where order_id in(select ga_occuid from goods_account where DATEDIFF(second ,'" + strTimeWhere + "',ga_date)>0 and DATEDIFF(second ,'" + strTimeWhere + "',ga_date)<86400 and ga_Type not in (3,4,5,6) group by ga_occuid)) as oi inner join  real_mode as rm on oi.real_mode_id=rm.real_mode_id inner join room_type as rt on oi.real_type_id=rt.id inner join card_type as ct on oi.card_id=ct.id  inner join meth_pay as mp on oi.meth_pay_id=mp.meth_pay_id  inner join hourse_scheme as hs on oi.real_scheme_id=hs.id ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<Model.occu_infor> list = new List<Model.occu_infor>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(DataRowToModel1(dr));
                }
                return list;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 通过日期查询当日的报表数据
        /// </summary>
        /// <param name="day"></param>
        public List<Model.occu_infor> GetDaySheetByOrderID(string strTimeWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from occu_infor as oi inner join real_mode as rm on oi.real_mode_id=rm.real_mode_id inner join room_type as rt on oi.real_type_id=rt.id inner join card_type as ct on oi.card_id=ct.id left join meth_pay as mp on oi.meth_pay_id=mp.meth_pay_id inner join hourse_scheme as hs on oi.real_scheme_id=hs.id");
            if (strTimeWhere.Trim() != "")
            {
                strSql.Append(" where " + strTimeWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<Model.occu_infor> list = new List<Model.occu_infor>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(DataRowToModel1(dr));
                }
                return list;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        ///通过月日查询
        /// </summary>
        /// <param name="day"></param>
        public DataSet GetDaySheetbymouth(string strTimeWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CONVERT(varchar(100), oi.occ_time,23),COUNT(*), AVG(oi.real_price),SUM(oi.real_price) from occu_infor as oi inner join real_mode as rm on oi.real_mode_id=rm.real_mode_id inner join hourse_scheme as hs on oi.real_scheme_id=hs.id inner join room_type as rt on oi.real_type_id=rt.id ");
            if (strTimeWhere.Trim() != "")
            {
                strSql.Append(" where " + strTimeWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds;
        }
    }
}

