using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Maticsoft.Common;
using CdHotelManage.DAL;
namespace CdHotelManage.BLL
{
    /// <summary>
    /// shopInfo
    /// </summary>
    public partial class shopInfo
    {
        private readonly CdHotelManage.DAL.shopInfo dal = new CdHotelManage.DAL.shopInfo();
        public shopInfo()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CdHotelManage.Model.shopInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CdHotelManage.Model.shopInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.shopInfo GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CdHotelManage.Model.shopInfo GetModelByCache(int id)
        {

            string CacheKey = "shopInfoModel-" + id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CdHotelManage.Model.shopInfo)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CdHotelManage.Model.shopInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CdHotelManage.Model.shopInfo> DataTableToList(DataTable dt)
        {
            List<CdHotelManage.Model.shopInfo> modelList = new List<CdHotelManage.Model.shopInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CdHotelManage.Model.shopInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CdHotelManage.Model.shopInfo();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["shop_Name"] != null && dt.Rows[n]["shop_Name"].ToString() != "")
                    {
                        model.shop_Name = dt.Rows[n]["shop_Name"].ToString();
                    }
                    if (dt.Rows[n]["shop_LxMan"] != null && dt.Rows[n]["shop_LxMan"].ToString() != "")
                    {
                        model.shop_LxMan = dt.Rows[n]["shop_LxMan"].ToString();
                    }
                    if (dt.Rows[n]["Shop_Telphone"] != null && dt.Rows[n]["Shop_Telphone"].ToString() != "")
                    {
                        model.Shop_Telphone = dt.Rows[n]["Shop_Telphone"].ToString();
                    }
                    if (dt.Rows[n]["Shop_chuanzen"] != null && dt.Rows[n]["Shop_chuanzen"].ToString() != "")
                    {
                        model.Shop_chuanzen = dt.Rows[n]["Shop_chuanzen"].ToString();
                    }
                    if (dt.Rows[n]["Shop_Province"] != null && dt.Rows[n]["Shop_Province"].ToString() != "")
                    {
                        model.Shop_Province = dt.Rows[n]["Shop_Province"].ToString();
                    }
                    if (dt.Rows[n]["Shop_City"] != null && dt.Rows[n]["Shop_City"].ToString() != "")
                    {
                        model.Shop_City = dt.Rows[n]["Shop_City"].ToString();
                    }
                    if (dt.Rows[n]["Shop_Area"] != null && dt.Rows[n]["Shop_Area"].ToString() != "")
                    {
                        model.Shop_Area = dt.Rows[n]["Shop_Area"].ToString();
                    }
                    if (dt.Rows[n]["Shop_Address"] != null && dt.Rows[n]["Shop_Address"].ToString() != "")
                    {
                        model.Shop_Address = dt.Rows[n]["Shop_Address"].ToString();
                    }
                    if (dt.Rows[n]["Shop_x"] != null && dt.Rows[n]["Shop_x"].ToString() != "")
                    {
                        model.Shop_x = dt.Rows[n]["Shop_x"].ToString();
                    }
                    if (dt.Rows[n]["Shop_y"] != null && dt.Rows[n]["Shop_y"].ToString() != "")
                    {
                        model.Shop_y = dt.Rows[n]["Shop_y"].ToString();
                    }
                    if (dt.Rows[n]["Shop_Remaker"] != null && dt.Rows[n]["Shop_Remaker"].ToString() != "")
                    {
                        model.Shop_Remaker = dt.Rows[n]["Shop_Remaker"].ToString();
                    }
                    if (dt.Rows[n]["Shop_date"] != null && dt.Rows[n]["Shop_date"].ToString() != "")
                    {
                        model.Shop_date = DateTime.Parse(dt.Rows[n]["Shop_date"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}
