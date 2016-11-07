using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:goods_account
	/// </summary>
	public partial class goods_account
	{
		public goods_account()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "goods_account"); 
		}
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int ga_Maxnumber()
        {
            return DbHelperSQL.GetMaxID("ga_number", "goods_account");
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from goods_account");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CdHotelManage.Model.goods_account model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into goods_account(");
            strSql.Append("ga_name,ga_number,ga_roomNumber,ga_unit,ga_num,ga_price,ga_zffs_id,ga_date,ga_people,ga_Type,ga_sum_price,ga_remker,ga_occuid,ga_sfacount,ga_isjz,ga_goodNo,ga_isys,Ga_Account,ga_jsfs)");
			strSql.Append(" values (");
            strSql.Append("@ga_name,@ga_number,@ga_roomNumber,@ga_unit,@ga_num,@ga_price,@ga_zffs_id,@ga_date,@ga_people,@ga_Type,@ga_sum_price,@ga_remker,@ga_occuid,@ga_sfacount,@ga_isjz,@ga_goodNo,@ga_isys,@Ga_Account,@ga_jsfs)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ga_name", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_number", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_roomNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_unit", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_num", SqlDbType.Int,4),
					new SqlParameter("@ga_price", SqlDbType.Decimal,4),
					new SqlParameter("@ga_zffs_id", SqlDbType.Int,4),
					new SqlParameter("@ga_date", SqlDbType.DateTime),
					new SqlParameter("@ga_people", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_Type", SqlDbType.Int,4),
					new SqlParameter("@ga_sum_price", SqlDbType.Decimal,4),
					new SqlParameter("@ga_remker", SqlDbType.NVarChar,-1),	
                    new SqlParameter("@ga_occuid", SqlDbType.NVarChar,50),
                    new SqlParameter("@ga_isjz", SqlDbType.Int,4),
                    new SqlParameter("@ga_sfacount", SqlDbType.NVarChar,50),
                     new SqlParameter("@ga_goodNo", SqlDbType.NVarChar,50),
                                        new SqlParameter("@ga_isys", SqlDbType.Int,4),
                                        new SqlParameter("@Ga_Account",SqlDbType.NVarChar,50),
                                        new SqlParameter("@ga_jsfs",SqlDbType.Int,4)
                                        };

			parameters[0].Value = model.ga_name;
			parameters[1].Value = model.ga_number;
			parameters[2].Value = model.ga_roomNumber;
			parameters[3].Value = model.ga_unit;
			parameters[4].Value = model.ga_num;
			parameters[5].Value = model.ga_price;
			parameters[6].Value = model.ga_zffs_id;
			parameters[7].Value = model.ga_date;
			parameters[8].Value = model.ga_people;
			parameters[9].Value = model.ga_Type;
			parameters[10].Value = model.ga_sum_price;
			parameters[11].Value = model.ga_remker;
            parameters[12].Value = model.ga_occuid;
            parameters[13].Value = model.ga_isjz;
            parameters[14].Value = model.ga_sfacount;
            parameters[15].Value = model.Ga_goodNo;
            parameters[16].Value = model.ga_isys;
            parameters[17].Value = model.Ga_Account;
            parameters[18].Value = model.ga_jsfs;
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
		public bool Update(CdHotelManage.Model.goods_account model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update goods_account set ");
			strSql.Append("ga_name=@ga_name,");
			strSql.Append("ga_number=@ga_number,");
			strSql.Append("ga_roomNumber=@ga_roomNumber,");
			strSql.Append("ga_unit=@ga_unit,");
			strSql.Append("ga_num=@ga_num,");
			strSql.Append("ga_price=@ga_price,");
			strSql.Append("ga_zffs_id=@ga_zffs_id,");
			strSql.Append("ga_date=@ga_date,");
			strSql.Append("ga_people=@ga_people,");
			strSql.Append("ga_Type=@ga_Type,");
			strSql.Append("ga_sum_price=@ga_sum_price,");
			strSql.Append("ga_remker=@ga_remker,");
            strSql.Append("ga_occuid=@ga_occuid,");
            strSql.Append("ga_sfacount=@ga_sfacount,");
            strSql.Append("ga_isjz=@ga_isjz,");
            strSql.Append("ga_goodNo=@ga_goodNo,");
            strSql.Append("ga_isys=@ga_isys,");
            strSql.Append("Ga_Account=@Ga_Account,");
            strSql.Append("ga_jsfs=@ga_jsfs");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@ga_name", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_number", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_roomNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_unit", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_num", SqlDbType.Int,4),
					new SqlParameter("@ga_price", SqlDbType.Decimal,4),
					new SqlParameter("@ga_zffs_id", SqlDbType.Int,4),
					new SqlParameter("@ga_date", SqlDbType.DateTime),
					new SqlParameter("@ga_people", SqlDbType.NVarChar,50),
					new SqlParameter("@ga_Type", SqlDbType.Int,4),
					new SqlParameter("@ga_sum_price", SqlDbType.Decimal,4),
					new SqlParameter("@ga_remker", SqlDbType.NVarChar,-1),
                    new SqlParameter("@ga_occuid", SqlDbType.NVarChar,50),
                    new SqlParameter("@ga_sfacount", SqlDbType.NVarChar,50),
                    new SqlParameter("@ga_isjz", SqlDbType.Int,4),
                    new SqlParameter("@ga_goodNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ga_isys", SqlDbType.Int,4),
                    new SqlParameter("@Ga_Account",SqlDbType.NVarChar,50),
                    new SqlParameter("@ga_jsfs",SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.ga_name;
			parameters[1].Value = model.ga_number;
			parameters[2].Value = model.ga_roomNumber;
			parameters[3].Value = model.ga_unit;
			parameters[4].Value = model.ga_num;
			parameters[5].Value = model.ga_price;
			parameters[6].Value = model.ga_zffs_id;
			parameters[7].Value = model.ga_date;
			parameters[8].Value = model.ga_people;
			parameters[9].Value = model.ga_Type;
			parameters[10].Value = model.ga_sum_price;
			parameters[11].Value = model.ga_remker;
            parameters[12].Value = model.ga_occuid;
            parameters[13].Value = model.ga_sfacount;
            parameters[14].Value = model.ga_isjz;
            parameters[15].Value = model.Ga_goodNo;
            parameters[16].Value = model.ga_isys;
            parameters[17].Value = model.Ga_Account;
            parameters[18].Value = model.ga_jsfs;
			parameters[19].Value = model.id;
            
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from goods_account ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
        /// 删除一条数据2
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from goods_account ");
            strSql.Append(" where " + idlist + "");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public CdHotelManage.Model.goods_account GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,ga_name,ga_number,ga_roomNumber,ga_unit,ga_num,ga_price,ga_zffs_id,ga_date,ga_people,ga_Type,ga_sum_price,ga_remker,ga_occuid,ga_sfacount,ga_isjz,ga_goodNo,ga_isys,ga_Account,ga_jsfs from goods_account ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			CdHotelManage.Model.goods_account model=new CdHotelManage.Model.goods_account();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel1(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.goods_account GetModels1(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ga_name,ga_number,ga_roomNumber,ga_unit,ga_num,ga_price,ga_zffs_id,ga_date,ga_people,ga_Type,ga_sum_price,ga_remker,ga_occuid,ga_sfacount,ga_isjz,ga_goodNo,ga_isys,ga_Account,ga_jsfs from goods_account ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            CdHotelManage.Model.goods_account model = new CdHotelManage.Model.goods_account();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel1(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.goods_account GetModels(string sthwere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ga_name,ga_number,ga_roomNumber,ga_unit,ga_num,ga_price,ga_zffs_id,CONVERT(varchar(100), ga_date, 20) as ga_date,ga_people,ga_Type,ga_sum_price,ga_remker,ga_sfacount,ga_isjz,ga_goodNo,ga_isys,ga_Account,ga_jsfs from goods_account ");
            strSql.Append(sthwere);
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            //parameters[0].Value = id;

            CdHotelManage.Model.goods_account model = new CdHotelManage.Model.goods_account();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModels(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.goods_account DataRowToModel1(DataRow row)
        {
            CdHotelManage.Model.goods_account model = new CdHotelManage.Model.goods_account();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["ga_name"] != null)
                {
                    model.ga_name = row["ga_name"].ToString();
                }
                if (row["ga_number"] != null)
                {
                    model.ga_number = row["ga_number"].ToString();
                }
                if (row["ga_roomNumber"] != null && row["ga_roomNumber"].ToString() != "")
                {
                    model.ga_roomNumber = row["ga_roomNumber"].ToString();
                }
                if (row["ga_unit"] != null)
                {
                    model.ga_unit = row["ga_unit"].ToString();
                }
                if (row["ga_num"] != null && row["ga_num"].ToString() != "")
                {
                    model.ga_num = int.Parse(row["ga_num"].ToString());
                }
                if (row["ga_price"] != null && row["ga_price"].ToString() != "")
                {
                    model.ga_price = decimal.Parse(row["ga_price"].ToString());
                }
                if (row["ga_zffs_id"] != null && row["ga_zffs_id"].ToString() != "")
                {
                    model.ga_zffs_id = int.Parse(row["ga_zffs_id"].ToString());
                }
                if (row["ga_date"] != null && row["ga_date"].ToString() != "")
                {
                    model.ga_date = DateTime.Parse(row["ga_date"].ToString());
                }
                if (row["ga_people"] != null)
                {
                    model.ga_people = row["ga_people"].ToString();
                }
                if (row["ga_Type"] != null && row["ga_Type"].ToString() != "")
                {
                    model.ga_Type = int.Parse(row["ga_Type"].ToString());
                }
                if (row["ga_GoodNo"] != null && row["ga_GoodNo"].ToString() != "")
                {
                    model.Ga_goodNo = row["ga_GoodNo"].ToString();
                }
                if (row["ga_occuid"] != null && row["ga_occuid"].ToString() != "")
                {
                    model.ga_occuid = row["ga_occuid"].ToString();
                }
                if (row["ga_sum_price"] != null && row["ga_sum_price"].ToString() != "")
                {
                    model.ga_sum_price = decimal.Parse(row["ga_sum_price"].ToString());
                }
                if (row["ga_remker"] != null)
                {
                    model.ga_remker = row["ga_remker"].ToString();
                }

                if (row["ga_sfacount"] != null && row["ga_sfacount"].ToString() != "")
                {
                    model.ga_sfacount = row["ga_sfacount"].ToString();
                }
                if (row["ga_isjz"] != null && row["ga_isjz"].ToString() != "")
                {
                    model.ga_isjz = Convert.ToInt32(row["ga_isjz"]);
                }
                if (row["ga_isys"] != null && row["ga_isys"].ToString() != "")
                {
                    model.ga_isys = Convert.ToInt32(row["ga_isys"]);
                }
                if (row["ga_Account"] != null && row["ga_Account"].ToString() != "")
                {
                    model.Ga_Account = row["ga_Account"].ToString();
                }
                if (row["ga_jsfs"] != null && row["ga_jsfs"].ToString() != "")
                {
                    model.ga_jsfs = Convert.ToInt32(row["ga_jsfs"]);
                }
            }
            return model;
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.goods_account DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.goods_account model=new CdHotelManage.Model.goods_account();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["ga_name"]!=null)
				{
					model.ga_name=row["ga_name"].ToString();
				}
				if(row["ga_number"]!=null)
				{
					model.ga_number=row["ga_number"].ToString();
				}
				if(row["ga_roomNumber"]!=null && row["ga_roomNumber"].ToString()!="")
				{
					model.ga_roomNumber=row["ga_roomNumber"].ToString();
				}
				if(row["ga_unit"]!=null)
				{
					model.ga_unit=row["ga_unit"].ToString();
				}
				if(row["ga_num"]!=null && row["ga_num"].ToString()!="")
				{
					model.ga_num=int.Parse(row["ga_num"].ToString());
				}
				if(row["ga_price"]!=null && row["ga_price"].ToString()!="")
				{
					model.ga_price=decimal.Parse(row["ga_price"].ToString());
				}
                DAL.meth_pay dalmp = new meth_pay();
				if(row["ga_zffs_id"]!=null && row["ga_zffs_id"].ToString()!="")
				{
					model.ga_zffs_id=int.Parse(row["ga_zffs_id"].ToString());
                    model.Meth_pay_model = new Model.meth_pay();
                    model.Meth_pay_model = dalmp.DataRowToModel(row);
				}
				if(row["ga_date"]!=null && row["ga_date"].ToString()!="")
				{
					model.ga_date=DateTime.Parse(row["ga_date"].ToString());
				}
				if(row["ga_people"]!=null)
				{
					model.ga_people=row["ga_people"].ToString();
				}
				if(row["ga_Type"]!=null && row["ga_Type"].ToString()!="")
				{
					model.ga_Type=int.Parse(row["ga_Type"].ToString());
				}
                if (row["ga_GoodNo"] != null && row["ga_GoodNo"].ToString() != "")
                {
                    model.Ga_goodNo = row["ga_GoodNo"].ToString();
                }
                if (row["ga_occuid"] != null && row["ga_occuid"].ToString() != "")
                {
                    model.ga_occuid = row["ga_occuid"].ToString();
                }
				if(row["ga_sum_price"]!=null && row["ga_sum_price"].ToString()!="")
				{
					model.ga_sum_price=decimal.Parse(row["ga_sum_price"].ToString());
				}
				if(row["ga_remker"]!=null)
				{
					model.ga_remker=row["ga_remker"].ToString();
				}

                if (row["ga_sfacount"] != null && row["ga_sfacount"].ToString() != "")
                {
                    model.ga_sfacount = row["ga_sfacount"].ToString();
                }
                if (row["ga_isjz"] != null && row["ga_isjz"].ToString() != "")
                {
                    model.ga_isjz = Convert.ToInt32(row["ga_isjz"]);
                }
                if (row["ga_isys"] != null && row["ga_isys"].ToString() != "")
                {
                    model.ga_isys = Convert.ToInt32(row["ga_isys"]);
                }
                if (row["ga_Account"] != null && row["ga_Account"].ToString() != "")
                {
                    model.Ga_Account = row["ga_Account"].ToString();
                }
                if (row["ga_jsfs"] != null && row["ga_jsfs"].ToString() != "")
                {
                    model.ga_jsfs = Convert.ToInt32(row["ga_jsfs"]);
                }
			}
			return model;
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.goods_account DataRowToModels(DataRow row)
        {
            CdHotelManage.Model.goods_account model = new CdHotelManage.Model.goods_account();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["ga_name"] != null)
                {
                    model.ga_name = row["ga_name"].ToString();
                }
                if (row["ga_number"] != null)
                {
                    model.ga_number = row["ga_number"].ToString();
                }
                if (row["ga_roomNumber"] != null && row["ga_roomNumber"].ToString() != "")
                {
                    model.ga_roomNumber = row["ga_roomNumber"].ToString();
                }
                if (row["ga_unit"] != null)
                {
                    model.ga_unit = row["ga_unit"].ToString();
                }
                if (row["ga_num"] != null && row["ga_num"].ToString() != "")
                {
                    model.ga_num = int.Parse(row["ga_num"].ToString());
                }
                if (row["ga_price"] != null && row["ga_price"].ToString() != "")
                {
                    model.ga_price = decimal.Parse(row["ga_price"].ToString());
                }
                if (row["ga_zffs_id"] != null && row["ga_zffs_id"].ToString() != "")
                {
                    model.ga_zffs_id = int.Parse(row["ga_zffs_id"].ToString());
                }
                if (row["ga_date"] != null && row["ga_date"].ToString() != "")
                {
                    model.ga_date = Convert.ToDateTime(row["ga_date"].ToString());
                }
                if (row["ga_people"] != null)
                {
                    model.ga_people = row["ga_people"].ToString();
                }
                if (row["ga_Type"] != null && row["ga_Type"].ToString() != "")
                {
                    model.ga_Type = int.Parse(row["ga_Type"].ToString());
                }
                if (row["ga_sum_price"] != null && row["ga_sum_price"].ToString() != "")
                {
                    model.ga_sum_price = decimal.Parse(row["ga_sum_price"].ToString());
                }
                if (row["ga_remker"] != null)
                {
                    model.ga_remker = row["ga_remker"].ToString();
                }
                if (row["ga_sfacount"] != null && row["ga_sfacount"].ToString() != "")
                {
                    model.ga_sfacount = row["ga_sfacount"].ToString();
                }
                if (row["ga_isjz"] != null && row["ga_isjz"].ToString() != "")
                {
                    model.ga_isjz = Convert.ToInt32(row["ga_isjz"]);
                }
                if (row["ga_goodNo"] != null && row["ga_goodNo"].ToString() != "")
                {
                    model.Ga_goodNo = row["ga_goodNo"].ToString();
                }
                if (row["ga_isys"] != null && row["ga_isys"].ToString() != "")
                {
                    model.ga_isys = Convert.ToInt32(row["ga_isys"]);
                }
                if (row["ga_Account"] != null && row["ga_Account"].ToString() != "")
                {
                    model.Ga_Account = row["ga_Account"].ToString();
                }
                if (row["ga_jsfs"] != null && row["ga_jsfs"].ToString() != "")
                {
                    model.ga_jsfs = Convert.ToInt32(row["ga_jsfs"]);
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.goods_account> GetListByWhere(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ga_name,ga_number,ga_roomNumber,ga_unit,ga_num,ga_price,ga_zffs_id,ga_date,ga_people,ga_Type,ga_sum_price,ga_remker,ga_sfacount,ga_occuid,ga_isjz,ga_goodNo,ga_isys,ga_Account,ga_jsfs ");
            strSql.Append(" FROM goods_account ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds=DbHelperSQL.Query(strSql.ToString());
            List<Model.goods_account> list=null;
            if(ds!=null){
                list = new List<Model.goods_account>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Model.goods_account model = DataRowToModel1(dr);
                    list.Add(model);
                }

            }
            return list;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,ga_name,ga_number,ga_roomNumber,ga_unit,ga_num,ga_price,ga_zffs_id,ga_date,ga_people,ga_Type,ga_sum_price,ga_remker,ga_sfacount,ga_isjz,ga_goodNo,ga_isys,ga_Account,ga_jsfs ");
			strSql.Append(" FROM goods_account ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" id,ga_name,ga_number,ga_roomNumber,ga_unit,ga_num,ga_price,ga_zffs_id,ga_date,ga_people,ga_Type,ga_sum_price,ga_remker,ga_sfacount,ga_isjz,ga_goodNo,ga_isys,ga_Account,ga_jsfs ");
			strSql.Append(" FROM goods_account ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM goods_account ");
			if(strWhere.Trim()!="")
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from goods_account T ");
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
			parameters[0].Value = "goods_account";
			parameters[1].Value = "id";
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

        /// <summary>
        /// 根据ID获得支付方式和总现金
        /// </summary>
        public DataSet GeMethPaySumMoney(string strWhere,int istrue)
        {
            string strSql = "select b.meth_pay_id, b.meth_pay_name, sum(a.ga_price) as ga_sum_price  from goods_account a inner join meth_pay b on a.ga_zffs_id = b.meth_pay_id  where a.ga_people  = '" + strWhere + "' and ga_price!='0' and ga_Type!=111 and a.ga_zffs_id!=11 and a.ga_zffs_id!=10 and ga_isjz=" + istrue + " group by b.meth_pay_name,b.meth_pay_id ";

            return DbHelperSQL.Query(strSql.ToString());
        }

         /// <summary>
        /// 根据条件获得所有的收款方式
        /// </summary>
        public string GeMethPayType(string strWhere)
        {
            System.Text.StringBuilder strSql = new StringBuilder();
            strSql.Append("select ga_zffs_id from goods_account");
            System.Text.StringBuilder sbMeth = new StringBuilder();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = new DataSet();
           ds= DbHelperSQL.Query(strSql.ToString());
           if (ds.Tables[0].Rows.Count > 0) {
               foreach (DataRow dr in ds.Tables[0].Rows)
               {
                   sbMeth.Append(dr["ga_zffs_id"] + ",");
               }
           }
           return sbMeth.ToString();
        }

        //根据登录ID和支付方式查询明细
        public DataSet GeMethPayMoney(string strWhere)
        {
            string strSql = "select *  from goods_account  " + strWhere + " ";

            return DbHelperSQL.Query(strSql.ToString());
        }

        //根据用户登录ID获取所有的信息
        public DataSet GetSumInfo(string strWhere)
        {
            string strSql = "select *  from goods_account  where ga_people = '" + strWhere + "' and ga_isjz=0 and ga_Type in(3,4,5,7,6,110)";

            return DbHelperSQL.Query(strSql.ToString());
        }
        //欠费
        //根据用户登录ID获取所有的信息
        public DataSet GoodsQX(string SQL)
        {

            return DbHelperSQL.Query(SQL.ToString());
        }
        //修改是否交班状态
        public int Updatesis(string uid)
        {
            string strSql = "update goods_account set ga_isjz=1 where ga_people = '" + uid + "' and ga_isjz=0";

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        //根据时间和支付方式查询明细
        public DataSet GetMethPayMoneyPage(string sort, string order, int currentPage, int pageSize, string strWhere)
        {
            string strSql = @" select * from (select *,Row_number() over(order by " + sort + " " + order + ") as IDGoodCountRoom from goods_account " + strWhere + " and ga_isjz=0 and ga_Type!=111 and ga_price!='0' and ga_zffs_id!=11) as IDWithRowNumber inner join meth_pay as mp on mp.meth_pay_id=IDWithRowNumber.ga_zffs_id where IDGoodCountRoom>=(" + currentPage + "-1)*" + pageSize + "+1 and IDGoodCountRoom<=" + currentPage + "*" + pageSize + "";

            return DbHelperSQL.Query(strSql.ToString());
        }

        //根据时间和支付方式查询明细
        public DataSet GetMethPayMoneyPage1(string sort, string order, int currentPage, int pageSize, string strWhere)
        {
            string strSql = @" select * from (select *,Row_number() over(order by " + sort + " " + order + ") as IDGoodCountRoom from goods_account " + strWhere + " and ga_Type=110) as IDWithRowNumber inner join meth_pay as mp on mp.meth_pay_id=IDWithRowNumber.ga_zffs_id where IDGoodCountRoom>=(" + currentPage + "-1)*" + pageSize + "+1 and IDGoodCountRoom<=" + currentPage + "*" + pageSize + "";

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public int ShiftDelete(string id)
        {

            string strSql = "delete from goods_account  where ga_people = '" + id + "' ";
            return DbHelperSQL.ExecuteSql(strSql);

        }


        public DataTable GetDsBySql(string sql) {
            return DBHelper.GetDataSet(sql);
        }

        public DataTable GetGoodsFh1(string roomnuber, string whee)
        {
            string strSql = "select SUM(ga_sum_price) from goods_account where ga_Type in(8,9,10,101,11) and ga_roomNumber='" + roomnuber + "' " + whee + "";
            DataSet ds = DbHelperSQL.Query(strSql);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public DataTable GetGoodsFh(string roomnuber,string whee) {
            string strSql = "select SUM(ga_sum_price) from goods_account where ga_Type in(1,0) and ga_roomNumber='" + roomnuber + "' " + whee + "";
            DataSet ds = DbHelperSQL.Query(strSql);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            else {
                return null;
            }
        }

        public List<Model.goods_account> GetListOut(string strWhere) {
            System.Text.StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from goods_account as ga left join meth_pay as mp on ga.ga_zffs_id=mp.meth_pay_id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<Model.goods_account> list = new List<Model.goods_account>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(DataRowToModel(dr));
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        public string GetAllByday(string strWhere) {
            System.Text.StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(ga_sum_price) from goods_account ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null) {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            return "";
        }

        /*获得不同类型的收款方式所产生的金额*/
        public DataSet GetAllBydays(string strWhere)
        {
            System.Text.StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(ga_price),ga_zffs_id from goods_account");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null)
            {
                return ds;
            }
            return null;
        }
	}
}

