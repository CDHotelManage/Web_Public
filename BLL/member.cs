using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CdHotelManage.Model;
namespace CdHotelManage.BLL
{
    /// <summary>
    /// member
    /// </summary>
    public partial class member
    {
        private readonly CdHotelManage.DAL.member dal = new CdHotelManage.DAL.member();
        public member()
        { }
        #region  BasicMethod

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
        public bool Exists(int Mid)
        {
            return dal.Exists(Mid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CdHotelManage.Model.member model)
        {
            return dal.Add(model);
        }

        public bool Updates(string sql) {
            return dal.Updates(sql);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CdHotelManage.Model.member model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Mid)
        {

            return dal.Delete(Mid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Midlist)
        {
            return dal.DeleteList(Midlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.member GetModel(string Mid)
        {

            return dal.GetModel(Mid);
        }

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public CdHotelManage.Model.member GetModelByCache(int Mid)
        //{

        //    string CacheKey = "memberModel-" + Mid;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(Mid);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (CdHotelManage.Model.member)objModel;
        //}

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
        public List<CdHotelManage.Model.member> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CdHotelManage.Model.member> DataTableToList(DataTable dt)
        {
            List<CdHotelManage.Model.member> modelList = new List<CdHotelManage.Model.member>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CdHotelManage.Model.member model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
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

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

