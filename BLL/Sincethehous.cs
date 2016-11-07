using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CdHotelManage.Model;
namespace CdHotelManage.BLL
{
    /// <summary>
    /// Sincethehous
    /// </summary>
    public partial class Sincethehous
    {
        private readonly CdHotelManage.DAL.Sincethehous dal = new CdHotelManage.DAL.Sincethehous();
        public Sincethehous()
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
        public int Add(CdHotelManage.Model.Sincethehous model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CdHotelManage.Model.Sincethehous model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update2(string Sql)
        {
            return dal.Updates(Sql);
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
        public CdHotelManage.Model.Sincethehous GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CdHotelManage.Model.Sincethehous GetModelByCache(int id)
        {

            string CacheKey = "SincethehousModel-" + id;
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
            return (CdHotelManage.Model.Sincethehous)objModel;
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
        public List<CdHotelManage.Model.Sincethehous> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CdHotelManage.Model.Sincethehous> DataTableToList(DataTable dt)
        {
            List<CdHotelManage.Model.Sincethehous> modelList = new List<CdHotelManage.Model.Sincethehous>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CdHotelManage.Model.Sincethehous model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CdHotelManage.Model.Sincethehous();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["hs_Numberno"] != null && dt.Rows[n]["hs_Numberno"].ToString() != "")
                    {
                        model.hs_Numberno = dt.Rows[n]["hs_Numberno"].ToString();
                    }
                    if (dt.Rows[n]["hs_room"] != null && dt.Rows[n]["hs_room"].ToString() != "")
                    {
                        model.hs_room = dt.Rows[n]["hs_room"].ToString();
                    }
                    if (dt.Rows[n]["hs_yuany"] != null && dt.Rows[n]["hs_yuany"].ToString() != "")
                    {
                        model.hs_yuany = dt.Rows[n]["hs_yuany"].ToString();
                    }
                    if (dt.Rows[n]["hs_date"] != null && dt.Rows[n]["hs_date"].ToString() != "")
                    {
                        model.hs_date = DateTime.Parse(dt.Rows[n]["hs_date"].ToString());
                    }
                    if (dt.Rows[n]["hs_ksDate"] != null && dt.Rows[n]["hs_ksDate"].ToString() != "")
                    {
                        model.hs_ksDate = DateTime.Parse(dt.Rows[n]["hs_ksDate"].ToString());
                    }
                    if (dt.Rows[n]["hs_ylDate"] != null && dt.Rows[n]["hs_ylDate"].ToString() != "")
                    {
                        model.hs_ylDate = dt.Rows[n]["hs_ylDate"].ToString();
                    }
                    if (dt.Rows[n]["hs_Documentno"] != null && dt.Rows[n]["hs_Documentno"].ToString() != "")
                    {
                        model.hs_Documentno = dt.Rows[n]["hs_Documentno"].ToString();
                    }
                    if (dt.Rows[n]["hs_type"] != null && dt.Rows[n]["hs_type"].ToString() != "")
                    {
                        model.hs_type = int.Parse(dt.Rows[n]["hs_type"].ToString());
                    }
                    if (dt.Rows[n]["hs_people"] != null && dt.Rows[n]["hs_people"].ToString() != "")
                    {
                        model.hs_people = dt.Rows[n]["hs_people"].ToString();
                    }
                    if (dt.Rows[n]["hs_Result"] != null && dt.Rows[n]["hs_Result"].ToString() != "")
                    {
                        model.hs_Result = dt.Rows[n]["hs_Result"].ToString();
                    }
                    if (dt.Rows[n]["hs_remaker"] != null && dt.Rows[n]["hs_remaker"].ToString() != "")
                    {
                        model.hs_remaker = dt.Rows[n]["hs_remaker"].ToString();
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

