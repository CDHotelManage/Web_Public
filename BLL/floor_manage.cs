using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CdHotelManage.Model;
namespace CdHotelManage.BLL
{
	/// <summary>
	/// floor_manage
	/// </summary>
	public partial class floor_manage
	{
        private readonly CdHotelManage.DAL.floor_manage dal = new CdHotelManage.DAL.floor_manage();
        public floor_manage()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int floor_id)
        {
            return dal.Exists(floor_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CdHotelManage.Model.floor_manage model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CdHotelManage.Model.floor_manage model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int floor_id)
        {

            return dal.Delete(floor_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string floor_idlist)
        {
            return dal.DeleteList(floor_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.floor_manage GetModel(int floor_id)
        {

            return dal.GetModel(floor_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CdHotelManage.Model.floor_manage GetModelByCache(int floor_id)
        {

            string CacheKey = "floor_manageModel-" + floor_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(floor_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CdHotelManage.Model.floor_manage)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

       /// <summary>
        /// 获得有房间的楼层
        /// </summary>
        /// <returns></returns>
        public DataTable GetListYou() {
            return dal.GetListYou();
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
        public List<CdHotelManage.Model.floor_manage> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CdHotelManage.Model.floor_manage> DataTableToList(DataTable dt)
        {
            List<CdHotelManage.Model.floor_manage> modelList = new List<CdHotelManage.Model.floor_manage>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CdHotelManage.Model.floor_manage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CdHotelManage.Model.floor_manage();
                    if (dt.Rows[n]["floor_id"] != null && dt.Rows[n]["floor_id"].ToString() != "")
                    {
                        model.floor_id = int.Parse(dt.Rows[n]["floor_id"].ToString());
                    }
                    if (dt.Rows[n]["floor_number"] != null && dt.Rows[n]["floor_number"].ToString() != "")
                    {
                        model.floor_number = dt.Rows[n]["floor_number"].ToString();
                    }
                    if (dt.Rows[n]["floor_name"] != null && dt.Rows[n]["floor_name"].ToString() != "")
                    {
                        model.floor_name = dt.Rows[n]["floor_name"].ToString();
                    }
                    if (dt.Rows[n]["floor_sorting"] != null && dt.Rows[n]["floor_sorting"].ToString() != "")
                    {
                        model.floor_sorting = dt.Rows[n]["floor_sorting"].ToString();
                    }
                    if (dt.Rows[n]["floor_remaker"] != null && dt.Rows[n]["floor_remaker"].ToString() != "")
                    {
                        model.floor_remaker = dt.Rows[n]["floor_remaker"].ToString();
                    }
                    if (dt.Rows[n]["floor_shoping"] != null && dt.Rows[n]["floor_shoping"].ToString() != "")
                    {
                        model.floor_shoping = dt.Rows[n]["floor_shoping"].ToString();
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

