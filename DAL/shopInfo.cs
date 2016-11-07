using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using Maticsoft.DBUtility;//Please add references

namespace CdHotelManage.DAL
{
    /// <summary>
    /// 数据访问类:shopInfo
    /// </summary>
    public partial class shopInfo
    {
        public shopInfo()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from shopInfo");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CdHotelManage.Model.shopInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into shopInfo(");
            strSql.Append("shop_Name,shop_LxMan,Shop_Telphone,Shop_chuanzen,Shop_Province,Shop_City,Shop_Area,Shop_Address,Shop_x,Shop_y,Shop_Remaker,Shop_date)");
            strSql.Append(" values (");
            strSql.Append("@shop_Name,@shop_LxMan,@Shop_Telphone,@Shop_chuanzen,@Shop_Province,@Shop_City,@Shop_Area,@Shop_Address,@Shop_x,@Shop_y,@Shop_Remaker,@Shop_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@shop_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@shop_LxMan", SqlDbType.NVarChar,50),
					new SqlParameter("@Shop_Telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@Shop_chuanzen", SqlDbType.NVarChar,50),
					new SqlParameter("@Shop_Province", SqlDbType.NVarChar,50),
					new SqlParameter("@Shop_City", SqlDbType.NVarChar,50),
					new SqlParameter("@Shop_Area", SqlDbType.NVarChar,50),
					new SqlParameter("@Shop_Address", SqlDbType.NVarChar),
					new SqlParameter("@Shop_x", SqlDbType.NVarChar,50),
					new SqlParameter("@Shop_y", SqlDbType.NVarChar,50),
					new SqlParameter("@Shop_Remaker", SqlDbType.NVarChar),
					new SqlParameter("@Shop_date", SqlDbType.DateTime)};
            parameters[0].Value = model.shop_Name;
            parameters[1].Value = model.shop_LxMan;
            parameters[2].Value = model.Shop_Telphone;
            parameters[3].Value = model.Shop_chuanzen;
            parameters[4].Value = model.Shop_Province;
            parameters[5].Value = model.Shop_City;
            parameters[6].Value = model.Shop_Area;
            parameters[7].Value = model.Shop_Address;
            parameters[8].Value = model.Shop_x;
            parameters[9].Value = model.Shop_y;
            parameters[10].Value = model.Shop_Remaker;
            parameters[11].Value = model.Shop_date;

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
        public bool Update(CdHotelManage.Model.shopInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update shopInfo set ");
            strSql.Append("shop_Name=@shop_Name,");
            strSql.Append("shop_LxMan=@shop_LxMan,");
            strSql.Append("Shop_Telphone=@Shop_Telphone,");
            strSql.Append("Shop_chuanzen=@Shop_chuanzen,");
            strSql.Append("Shop_Province=@Shop_Province,");
            strSql.Append("Shop_City=@Shop_City,");
            strSql.Append("Shop_Area=@Shop_Area,");
            strSql.Append("Shop_Address=@Shop_Address,");
            strSql.Append("Shop_x=@Shop_x,");
            strSql.Append("Shop_y=@Shop_y,");
            strSql.Append("Shop_Remaker=@Shop_Remaker,");
            strSql.Append("Shop_date=@Shop_date");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@shop_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@shop_LxMan", SqlDbType.NVarChar,50),
					new SqlParameter("@Shop_Telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@Shop_chuanzen", SqlDbType.NVarChar,50),
					new SqlParameter("@Shop_Province", SqlDbType.NVarChar,50),
					new SqlParameter("@Shop_City", SqlDbType.NVarChar,50),
					new SqlParameter("@Shop_Area", SqlDbType.NVarChar,50),
					new SqlParameter("@Shop_Address", SqlDbType.NVarChar),
					new SqlParameter("@Shop_x", SqlDbType.NVarChar,50),
					new SqlParameter("@Shop_y", SqlDbType.NVarChar,50),
					new SqlParameter("@Shop_Remaker", SqlDbType.NVarChar),
					new SqlParameter("@Shop_date", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.shop_Name;
            parameters[1].Value = model.shop_LxMan;
            parameters[2].Value = model.Shop_Telphone;
            parameters[3].Value = model.Shop_chuanzen;
            parameters[4].Value = model.Shop_Province;
            parameters[5].Value = model.Shop_City;
            parameters[6].Value = model.Shop_Area;
            parameters[7].Value = model.Shop_Address;
            parameters[8].Value = model.Shop_x;
            parameters[9].Value = model.Shop_y;
            parameters[10].Value = model.Shop_Remaker;
            parameters[11].Value = model.Shop_date;
            parameters[12].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from shopInfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
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
            strSql.Append("delete from shopInfo ");
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
        public CdHotelManage.Model.shopInfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,shop_Name,shop_LxMan,Shop_Telphone,Shop_chuanzen,Shop_Province,Shop_City,Shop_Area,Shop_Address,Shop_x,Shop_y,Shop_Remaker,Shop_date from shopInfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            CdHotelManage.Model.shopInfo model = new CdHotelManage.Model.shopInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["shop_Name"] != null && ds.Tables[0].Rows[0]["shop_Name"].ToString() != "")
                {
                    model.shop_Name = ds.Tables[0].Rows[0]["shop_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["shop_LxMan"] != null && ds.Tables[0].Rows[0]["shop_LxMan"].ToString() != "")
                {
                    model.shop_LxMan = ds.Tables[0].Rows[0]["shop_LxMan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Shop_Telphone"] != null && ds.Tables[0].Rows[0]["Shop_Telphone"].ToString() != "")
                {
                    model.Shop_Telphone = ds.Tables[0].Rows[0]["Shop_Telphone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Shop_chuanzen"] != null && ds.Tables[0].Rows[0]["Shop_chuanzen"].ToString() != "")
                {
                    model.Shop_chuanzen = ds.Tables[0].Rows[0]["Shop_chuanzen"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Shop_Province"] != null && ds.Tables[0].Rows[0]["Shop_Province"].ToString() != "")
                {
                    model.Shop_Province = ds.Tables[0].Rows[0]["Shop_Province"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Shop_City"] != null && ds.Tables[0].Rows[0]["Shop_City"].ToString() != "")
                {
                    model.Shop_City = ds.Tables[0].Rows[0]["Shop_City"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Shop_Area"] != null && ds.Tables[0].Rows[0]["Shop_Area"].ToString() != "")
                {
                    model.Shop_Area = ds.Tables[0].Rows[0]["Shop_Area"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Shop_Address"] != null && ds.Tables[0].Rows[0]["Shop_Address"].ToString() != "")
                {
                    model.Shop_Address = ds.Tables[0].Rows[0]["Shop_Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Shop_x"] != null && ds.Tables[0].Rows[0]["Shop_x"].ToString() != "")
                {
                    model.Shop_x = ds.Tables[0].Rows[0]["Shop_x"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Shop_y"] != null && ds.Tables[0].Rows[0]["Shop_y"].ToString() != "")
                {
                    model.Shop_y = ds.Tables[0].Rows[0]["Shop_y"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Shop_Remaker"] != null && ds.Tables[0].Rows[0]["Shop_Remaker"].ToString() != "")
                {
                    model.Shop_Remaker = ds.Tables[0].Rows[0]["Shop_Remaker"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Shop_date"] != null && ds.Tables[0].Rows[0]["Shop_date"].ToString() != "")
                {
                    model.Shop_date = DateTime.Parse(ds.Tables[0].Rows[0]["Shop_date"].ToString());
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
            strSql.Append("select id,shop_Name,shop_LxMan,Shop_Telphone,Shop_chuanzen,Shop_Province,Shop_City,Shop_Area,Shop_Address,Shop_x,Shop_y,Shop_Remaker,Shop_date ");
            strSql.Append(" FROM shopInfo ");
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
            strSql.Append(" id,shop_Name,shop_LxMan,Shop_Telphone,Shop_chuanzen,Shop_Province,Shop_City,Shop_Area,Shop_Address,Shop_x,Shop_y,Shop_Remaker,Shop_date ");
            strSql.Append(" FROM shopInfo ");
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
            strSql.Append("select count(1) FROM shopInfo ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from shopInfo T ");
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
            parameters[0].Value = "shopInfo";
            parameters[1].Value = "id";
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
