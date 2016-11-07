using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using CdHotelManage.Model;

namespace CdHotelManage.DAL
{
    public class Book_Rdetail
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Book_no,Real_type_Id,Room_number,Real_num,Real_Price,Real_Scheme_Id,Ok_num,Room_typeid,Book_Price ");
            strSql.Append(" FROM Book_Rdetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<Model.Book_Rdetail> GetListModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            List<Model.Book_Rdetail> list = new List<Model.Book_Rdetail>();
            strSql.Append("select Id,Book_no,Real_type_Id,Room_number,Real_num,Real_Price,Real_Scheme_Id,Ok_num,Room_typeid,Book_Price ");
            strSql.Append(" FROM Book_Rdetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Model.Book_Rdetail model = DataRowToModel(dr);
                list.Add(model);
            }
            return list;
        }

        public List<Model.Book_Rdetail> GetListModel1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            List<Model.Book_Rdetail> list = new List<Model.Book_Rdetail>();
            strSql.Append("select * ");
            strSql.Append(" FROM Book_Rdetail as br inner join hourse_scheme as hs on br.Real_Scheme_Id=hs.id");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Model.Book_Rdetail model = DataRowToModel1(dr);
                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.Book_Rdetail DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.Book_Rdetail model = new CdHotelManage.Model.Book_Rdetail();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.ID = int.Parse(row["Id"].ToString());
                }
                if (row["Book_no"] != null && row["Book_no"].ToString() != "")
                {
                    model.Book_no = row["Book_no"].ToString();
                }
                if (row["Real_type_Id"] != null && row["Real_type_Id"].ToString() != "")
                {
                    model.Real_type_Id = int.Parse(row["Real_type_Id"].ToString());
                }
                if (row["Room_number"] != null && row["Room_number"].ToString() != "")
                {
                    model.Room_number = row["Room_number"].ToString();
                }
                if (row["Real_num"] != null && row["Real_num"].ToString() != "")
                {
                    model.Real_num = int.Parse(row["Real_num"].ToString());
                }
                if (row["Real_Price"] != null && row["Real_Price"].ToString() != "")
                {
                    model.Real_Price = Convert.ToDecimal(row["Real_Price"].ToString());
                }
                if (row["Real_Scheme_Id"] != null && row["Real_Scheme_Id"].ToString() != "")
                {
                    model.Real_Scheme_Id = int.Parse(row["Real_Scheme_Id"].ToString());
                }
                if (row["Ok_num"] != null && row["Ok_num"].ToString() != "")
                {
                    model.Ok_num = int.Parse(row["Ok_num"].ToString());
                }
                if (row["Room_typeid"] != null && row["Room_typeid"].ToString() != "")
                {
                    model.RoomTypeID = int.Parse(row["Room_typeid"].ToString());
                }
                if (row["Book_Price"] != null && row["Book_Price"].ToString() != "")
                {
                    model.Book_Price = Convert.ToDecimal(row["Book_Price"].ToString());
                }
            }
            return model;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.Book_Rdetail DataRowToModel1(DataRow row)
        {
            CdHotelManage.Model.Book_Rdetail model = new CdHotelManage.Model.Book_Rdetail();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.ID = int.Parse(row["Id"].ToString());
                }
                if (row["Book_no"] != null && row["Book_no"].ToString() != "")
                {
                    model.Book_no = row["Book_no"].ToString();
                }
                if (row["Real_type_Id"] != null && row["Real_type_Id"].ToString() != "")
                {
                    model.Real_type_Id = int.Parse(row["Real_type_Id"].ToString());
                }
                if (row["Room_number"] != null && row["Room_number"].ToString() != "")
                {
                    model.Room_number = row["Room_number"].ToString();
                }
                if (row["Real_num"] != null && row["Real_num"].ToString() != "")
                {
                    model.Real_num = int.Parse(row["Real_num"].ToString());
                }
                if (row["Real_Price"] != null && row["Real_Price"].ToString() != "")
                {
                    model.Real_Price = Convert.ToDecimal(row["Real_Price"].ToString());
                }
                DAL.hourse_scheme dalhs = new hourse_scheme();
                if (row["Real_Scheme_Id"] != null && row["Real_Scheme_Id"].ToString() != "")
                {
                    model.Real_Scheme_Id = int.Parse(row["Real_Scheme_Id"].ToString());
                    model.Hourse_scheme_model = new Model.hourse_scheme();
                    model.Hourse_scheme_model = dalhs.DataRowToModel(row);
                }
                if (row["Ok_num"] != null && row["Ok_num"].ToString() != "")
                {
                    model.Ok_num = int.Parse(row["Ok_num"].ToString());
                }
                if (row["Room_typeid"] != null && row["Room_typeid"].ToString() != "")
                {
                    model.RoomTypeID = int.Parse(row["Room_typeid"].ToString());
                }
                if (row["Book_Price"] != null && row["Book_Price"].ToString() != "")
                {
                    model.Book_Price = Convert.ToDecimal(row["Book_Price"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Book_Rdetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Book_Rdetail(");
            strSql.Append("Book_no,Real_type_Id,Room_number,Real_num,Real_Price,Real_Scheme_Id,Ok_num,Room_typeid,Book_Price)");
            strSql.Append(" values (");
            strSql.Append("@Book_no,@Real_type_Id,@Room_number,@Real_num,@Real_Price,@Real_Scheme_Id,@Ok_num,@Room_typeid,@Book_Price)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Book_no", SqlDbType.NVarChar,20),
					new SqlParameter("@Real_type_Id", SqlDbType.Int,4),
					new SqlParameter("@Room_number", SqlDbType.NVarChar,20),
					new SqlParameter("@Real_num", SqlDbType.Int,4),
					new SqlParameter("@Real_Price", SqlDbType.Money,8),
					new SqlParameter("@Real_Scheme_Id", SqlDbType.Int,4),
					new SqlParameter("@Ok_num", SqlDbType.Int,4),
					new SqlParameter("@Room_typeid", SqlDbType.Int,4),
                                        new SqlParameter("@Book_Price",SqlDbType.Money,8)
                                        };
            parameters[0].Value = model.Book_no;
            parameters[1].Value = model.Real_type_Id;
            parameters[2].Value = model.Room_number;
            parameters[3].Value = model.Real_num;
            parameters[4].Value = model.Real_Price;
            parameters[5].Value = model.Real_Scheme_Id;
            parameters[6].Value = model.Ok_num;
            parameters[7].Value = model.RoomTypeID;
            parameters[8].Value = model.Book_Price;
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
        public bool Update(Model.Book_Rdetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Book_Rdetail set ");
            strSql.Append("Book_no=@Book_no,");
            strSql.Append("Real_type_Id=@Real_type_Id,");
            strSql.Append("Room_number=@Room_number,");
            strSql.Append("Real_num=@Real_num,");
            strSql.Append("Real_Price=@Real_Price,");
            strSql.Append("Real_Scheme_Id=@Real_Scheme_Id,");
            strSql.Append("Ok_num=@Ok_num,");
            strSql.Append("Room_typeid=@Room_typeid,");
            strSql.Append("Book_Price=@Book_Price");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Book_no", SqlDbType.NVarChar,20),
					new SqlParameter("@Real_type_Id", SqlDbType.Int,4),
					new SqlParameter("@Room_number", SqlDbType.NVarChar,20),
					new SqlParameter("@Real_num", SqlDbType.Int,4),
					new SqlParameter("@Real_Price", SqlDbType.Money,8),
					new SqlParameter("@Real_Scheme_Id", SqlDbType.Int,4),
					new SqlParameter("@Ok_num", SqlDbType.Int,4),
                    new SqlParameter("@Room_typeid", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4),
                                        new SqlParameter("@Book_Price",SqlDbType.Money,8)
                                        };
            parameters[0].Value = model.Book_no;
            parameters[1].Value = model.Real_type_Id;
            parameters[2].Value = model.Room_number;
            parameters[3].Value = model.Real_num;
            parameters[4].Value = model.Real_Price;
            parameters[5].Value = model.Real_Scheme_Id;
            parameters[6].Value = model.Ok_num;
            parameters[7].Value = model.RoomTypeID;
            parameters[8].Value = model.ID;
            parameters[9].Value = model.Book_Price;
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Book_Rdetail ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

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
        /// 根据条件删除数据
        /// </summary>
        public bool DeletebyWhere(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Book_Rdetail ");
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
        /// 计算已开房数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetAllNum(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(real_num) from Book_Rdetail ");
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
        
    }
}
