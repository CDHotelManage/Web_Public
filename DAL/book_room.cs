using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using CdHotelManage.Model;

namespace CdHotelManage.DAL
{
	/// <summary>
	/// 数据访问类:book_room
	/// </summary>
	public partial class book_room
	{
		public book_room()
		{}
		#region  BasicMethod

        private static int GetCountBySql(string _sql)
        {

            int count = 0;
            try
            {
                count = int.Parse(DbHelperSQL.GetSingle(_sql).ToString());
            }
            catch (Exception)
            {

                throw;
            }
            return count;
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CdHotelManage.Model.book_room model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into book_room(");
            strSql.Append("book_no,book_Name,tele_no,onli_no,guar_way,mem_cardno,time_to,time_from,real_time,source_id,meth_pay_id,deposit,real_type_id,real_scheme_id,real_price,state_id,real_num,remark,userid,room_number,Accounts,CpID)");
			strSql.Append(" values (");
            strSql.Append("@book_no,@book_Name,@tele_no,@onli_no,@guar_way,@mem_cardno,@time_to,@time_from,@real_time,@source_id,@meth_pay_id,@deposit,@real_type_id,@real_scheme_id,@real_price,@state_id,@real_num,@remark,@userid,@room_number,@Accounts,@CpID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@book_no", SqlDbType.NVarChar,20),
					new SqlParameter("@book_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@tele_no", SqlDbType.NVarChar,20),
					new SqlParameter("@onli_no", SqlDbType.NVarChar,20),
					new SqlParameter("@guar_way", SqlDbType.NVarChar,20),
					new SqlParameter("@mem_cardno", SqlDbType.NVarChar,50),
					new SqlParameter("@time_to", SqlDbType.DateTime),
					new SqlParameter("@time_from", SqlDbType.DateTime),
					new SqlParameter("@real_time", SqlDbType.DateTime),
					new SqlParameter("@source_id", SqlDbType.Int,4),
					new SqlParameter("@meth_pay_id", SqlDbType.Int,4),
					new SqlParameter("@deposit", SqlDbType.Money,8),
					new SqlParameter("@real_type_id", SqlDbType.Int,4),
					new SqlParameter("@real_scheme_id", SqlDbType.Int,4),
					new SqlParameter("@real_price", SqlDbType.Money,8),
					new SqlParameter("@state_id", SqlDbType.Int,4),
					new SqlParameter("@real_num", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
                    new SqlParameter("@userid", SqlDbType.NVarChar,50),
                    new SqlParameter("@room_number", SqlDbType.NVarChar,20),
                                        new SqlParameter("@Accounts",SqlDbType.NVarChar,50),
                                        new SqlParameter("@CpID",SqlDbType.Int,4)
                                        };
            
			parameters[0].Value = model.book_no;
			parameters[1].Value = model.book_Name;
			parameters[2].Value = model.tele_no;
			parameters[3].Value = model.onli_no;
			parameters[4].Value = model.guar_way;
			parameters[5].Value = model.mem_cardno;
			parameters[6].Value = model.time_to;
			parameters[7].Value = model.time_from;
			parameters[8].Value = model.real_time;
			parameters[9].Value = model.source_id;
			parameters[10].Value = model.meth_pay_id;
			parameters[11].Value = model.deposit;
			parameters[12].Value = model.real_type_id;
			parameters[13].Value = model.real_scheme_id;
			parameters[14].Value = model.real_price;
			parameters[15].Value = model.state_id;
			parameters[16].Value = model.real_num;
			parameters[17].Value = model.remark;
            parameters[18].Value = model.Userid;
            parameters[19].Value = model.room_number;
            parameters[20].Value = model.Accounts;
            parameters[21].Value = model.CpID;
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
		public bool Update(CdHotelManage.Model.book_room model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update book_room set ");
			strSql.Append("book_no=@book_no,");
			strSql.Append("book_Name=@book_Name,");
			strSql.Append("tele_no=@tele_no,");
			strSql.Append("onli_no=@onli_no,");
			strSql.Append("guar_way=@guar_way,");
			strSql.Append("mem_cardno=@mem_cardno,");
			strSql.Append("time_to=@time_to,");
			strSql.Append("time_from=@time_from,");
			strSql.Append("real_time=@real_time,");
			strSql.Append("source_id=@source_id,");
			strSql.Append("meth_pay_id=@meth_pay_id,");
			strSql.Append("deposit=@deposit,");
			strSql.Append("real_type_id=@real_type_id,");
			strSql.Append("real_scheme_id=@real_scheme_id,");
			strSql.Append("real_price=@real_price,");
			strSql.Append("state_id=@state_id,");
			strSql.Append("real_num=@real_num,");
			strSql.Append("remark=@remark,");
            strSql.Append("userid=@userid,");
            strSql.Append("room_number=@room_number,");
            strSql.Append("back_deposit=@back_deposit,");
            strSql.Append("Accounts=@Accounts,");
            strSql.Append("CpID=@CpID");
			strSql.Append(" where book_id=@book_id");
			SqlParameter[] parameters = {
					new SqlParameter("@book_no", SqlDbType.NVarChar,20),
					new SqlParameter("@book_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@tele_no", SqlDbType.NVarChar,20),
					new SqlParameter("@onli_no", SqlDbType.NVarChar,20),
					new SqlParameter("@guar_way", SqlDbType.NVarChar,20),
					new SqlParameter("@mem_cardno", SqlDbType.NVarChar,50),
					new SqlParameter("@time_to", SqlDbType.DateTime),
					new SqlParameter("@time_from", SqlDbType.DateTime),
					new SqlParameter("@real_time", SqlDbType.DateTime),
					new SqlParameter("@source_id", SqlDbType.Int,4),
					new SqlParameter("@meth_pay_id", SqlDbType.Int,4),
					new SqlParameter("@deposit", SqlDbType.Money,8),
					new SqlParameter("@real_type_id", SqlDbType.Int,4),
					new SqlParameter("@real_scheme_id", SqlDbType.Int,4),
					new SqlParameter("@real_price", SqlDbType.Money,8),
					new SqlParameter("@state_id", SqlDbType.Int,4),
					new SqlParameter("@real_num", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
                    new SqlParameter("@userid", SqlDbType.NVarChar,50),
                    new SqlParameter("@room_number", SqlDbType.NVarChar,20),
                    new SqlParameter("@back_deposit", SqlDbType.Money,8),
					new SqlParameter("@book_id", SqlDbType.Int,4),
                                        new SqlParameter("@Accounts",SqlDbType.NVarChar,50),
                                        new SqlParameter("@CpID",SqlDbType.Int,4)};
			parameters[0].Value = model.book_no;
			parameters[1].Value = model.book_Name;
			parameters[2].Value = model.tele_no;
			parameters[3].Value = model.onli_no;
			parameters[4].Value = model.guar_way;
			parameters[5].Value = model.mem_cardno;
			parameters[6].Value = model.time_to;
			parameters[7].Value = model.time_from;
			parameters[8].Value = model.real_time;
			parameters[9].Value = model.source_id;
			parameters[10].Value = model.meth_pay_id;
			parameters[11].Value = model.deposit;
			parameters[12].Value = model.real_type_id;
			parameters[13].Value = model.real_scheme_id;
			parameters[14].Value = model.real_price;
			parameters[15].Value = model.state_id;
			parameters[16].Value = model.real_num;
			parameters[17].Value = model.remark;
            parameters[18].Value = model.Userid;
            parameters[19].Value = model.room_number;
            parameters[20].Value = model.back_deposit;
			parameters[21].Value = model.book_id;
            parameters[22].Value = model.Accounts;
            parameters[23].Value = model.CpID;
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int book_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from book_room ");
			strSql.Append(" where book_id=@book_id");
			SqlParameter[] parameters = {
					new SqlParameter("@book_id", SqlDbType.Int,4)
			};
			parameters[0].Value = book_id;

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
        /// 根据条件删除
        /// </summary>
        public bool DeletebyWhere(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from book_room ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string book_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from book_room ");
			strSql.Append(" where book_id in ("+book_idlist + ")  ");
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
		public CdHotelManage.Model.book_room GetModel(int book_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 book_id,book_no,book_Name,tele_no,onli_no,guar_way,mem_cardno,time_to,time_from,real_time,source_id,meth_pay_id,deposit,real_type_id,real_scheme_id,real_price,state_id,real_num,remark,userid,room_number,back_deposit,Accounts,CpID from book_room ");
			strSql.Append(" where book_id=@book_id");
			SqlParameter[] parameters = {
					new SqlParameter("@book_id", SqlDbType.Int,4)
			};
			parameters[0].Value = book_id;

			CdHotelManage.Model.book_room model=new CdHotelManage.Model.book_room();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
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
		public CdHotelManage.Model.book_room DataRowToModel(DataRow row)
		{
			CdHotelManage.Model.book_room model=new CdHotelManage.Model.book_room();
			if (row != null)
			{
				if(row["book_id"]!=null && row["book_id"].ToString()!="")
				{
					model.book_id=int.Parse(row["book_id"].ToString());
				}
				if(row["book_no"]!=null && row["book_no"].ToString()!="")
				{
					model.book_no=row["book_no"].ToString();
				}
				if(row["book_Name"]!=null)
				{
					model.book_Name=row["book_Name"].ToString();
				}
				if(row["tele_no"]!=null)
				{
					model.tele_no=row["tele_no"].ToString();
				}
				if(row["onli_no"]!=null)
				{
					model.onli_no=row["onli_no"].ToString();
				}
				if(row["guar_way"]!=null)
				{
					model.guar_way=row["guar_way"].ToString();
				}
				if(row["mem_cardno"]!=null)
				{
					model.mem_cardno=row["mem_cardno"].ToString();
				}
				if(row["time_to"]!=null && row["time_to"].ToString()!="")
				{
					model.time_to=DateTime.Parse(row["time_to"].ToString());
				}
				if(row["time_from"]!=null && row["time_from"].ToString()!="")
				{
					model.time_from=DateTime.Parse(row["time_from"].ToString());
				}
				if(row["real_time"]!=null && row["real_time"].ToString()!="")
				{
					model.real_time=DateTime.Parse(row["real_time"].ToString());
				}
				if(row["source_id"]!=null && row["source_id"].ToString()!="")
				{
					model.source_id=int.Parse(row["source_id"].ToString());
				}
				if(row["meth_pay_id"]!=null && row["meth_pay_id"].ToString()!="")
				{
					model.meth_pay_id=int.Parse(row["meth_pay_id"].ToString());
				}
				if(row["deposit"]!=null && row["deposit"].ToString()!="")
				{
					model.deposit=decimal.Parse(row["deposit"].ToString());
				}
				if(row["real_type_id"]!=null && row["real_type_id"].ToString()!="")
				{
					model.real_type_id=int.Parse(row["real_type_id"].ToString());
				}
				if(row["real_scheme_id"]!=null && row["real_scheme_id"].ToString()!="")
				{
					model.real_scheme_id=int.Parse(row["real_scheme_id"].ToString());
				}
				if(row["real_price"]!=null && row["real_price"].ToString()!="")
				{
					model.real_price=decimal.Parse(row["real_price"].ToString());
				}
				if(row["state_id"]!=null && row["state_id"].ToString()!="")
				{
					model.state_id=int.Parse(row["state_id"].ToString());
				}
				if(row["real_num"]!=null && row["real_num"].ToString()!="")
				{
					model.real_num=int.Parse(row["real_num"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
                if (row["userid"] != null)
                {
                    model.Userid = row["userid"].ToString();
                }
                if (row["room_number"] != null)
                {
                    model.room_number = row["room_number"].ToString();
                }

                if (row["back_deposit"] != null && row["back_deposit"].ToString() != "")
                {
                    model.back_deposit = decimal.Parse(row["back_deposit"].ToString());
                }
                if (row["Accounts"] != null && row["Accounts"].ToString() != "")
                {
                    model.Accounts = row["Accounts"].ToString();
                }
                if (row["CpID"] != null && row["CpID"].ToString() != "")
                {
                    model.CpID = Convert.ToInt32(row["CpID"].ToString());
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select book_id,book_no,book_Name,tele_no,onli_no,guar_way,mem_cardno,time_to,time_from,real_time,source_id,meth_pay_id,deposit,real_type_id,real_scheme_id,real_price,state_id,real_num,remark,userid,room_number,back_deposit,Accounts,CpID ");
			strSql.Append(" FROM book_room ");
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
            strSql.Append(" book_id,book_no,book_Name,tele_no,onli_no,guar_way,mem_cardno,time_to,time_from,real_time,source_id,meth_pay_id,deposit,real_type_id,real_scheme_id,real_price,state_id,real_num,remark,userid,room_number,back_deposit,Accounts,CpID ");
			strSql.Append(" FROM book_room ");
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
			strSql.Append("select count(1) FROM book_room ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(strWhere);
			}
            return GetCountBySql(strSql.ToString());
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
				strSql.Append("order by T.book_id desc");
			}
			strSql.Append(")AS Row, T.*  from book_room T ");
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
			parameters[0].Value = "book_room";
			parameters[1].Value = "book_id";
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

        //以标识列获得对象
        public  Model.book_room GetRealNum(int state_id)
        {


            string sql = "SELECT REAL_NUM FROM " + "book_room" + " WHERE state_id = @state_id";
            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@state_id", state_id));
                if (reader.Read())
                {
                    Model.book_room model = new Model.book_room();

                    model.real_num = (int)reader["real_num"];//外键

                    reader.Close();

                    return model;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }


        public DataSet GetBookRoomPager(string sort, string order, int currentPage, int pageSize, string strWhere)
        {
            string _sql = @" select * from (select *,Row_number() over(order by " + sort + " " + order + ") as IDBookRoom from book_room " + strWhere + ") as IDWithRowNumber where IDBookRoom>=(" + currentPage + "-1)*" + pageSize + "+1 and IDBookRoom<=" + currentPage + "*" + pageSize + "";
            return DbHelperSQL.Query(_sql);
        }

        /// <summary>
        /// 获取预定房间总数
        /// </summary>
        public int GetBookRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(real_num) FROM book_room ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return GetCountBySql(strSql.ToString());
        }

        //获取当页房间数
        //public int GetSumRealRoom(string sort, string order, int currentPage, int pageSize, string strWhere)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    string _sql = @"select sum(real_num) from (select *,Row_number() over(order by " + sort + " " + order + ") as IDBookRoom from book_room " + strWhere + ") as IDWithRowNumber where IDBookRoom>=(" + currentPage + "-1)*" + pageSize + "+1 and IDBookRoom<=" + currentPage + "*" + pageSize + "");
        //     //if (strWhere.Trim() != "")
        //     //{
        //     //    strSql.Append(strWhere);
        //     //}
        //     return GetCountBySql(_sql.ToString());
        //}
        

	}
}

