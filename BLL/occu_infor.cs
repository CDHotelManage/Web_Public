using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CdHotelManage.Model;
namespace CdHotelManage.BLL
{
	/// <summary>
	/// occu_infor
	/// </summary>
	public partial class occu_infor
	{
		private readonly CdHotelManage.DAL.occu_infor dal=new CdHotelManage.DAL.occu_infor();
		public occu_infor()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CdHotelManage.Model.occu_infor model)
		{
			return dal.Add(model);
		}
        public List<Model.occu_infor> GetDaySheet(string strTimeWhere)
        {
            return dal.GetDaySheet(strTimeWhere);
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CdHotelManage.Model.occu_infor model)
		{
			return dal.Update(model);
		}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Updates(string sql)
        {
            return dal.Updates(sql);
        }
        /// <summary>
        /// 删除一条数据2
        /// </summary>
        public bool Deletes(string SQl)
        {

            return dal.Deletes(SQl);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int occ_id)
		{
			
			return dal.Delete(occ_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string occ_idlist )
		{
			return dal.DeleteList(occ_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.occu_infor GetModel(int occ_id)
		{
			
			return dal.GetModel(occ_id);
		}
        /// <summary>
        /// 得到一个对象实体2
        /// </summary>
        public CdHotelManage.Model.occu_infor GetModels(string shwhere)
        {

            return dal.GetModels(shwhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListed(string strWhere, string join)
        {
            return dal.GetListed(strWhere, join);
        }
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public CdHotelManage.Model.occu_infor GetModelByCache(int occ_id)
		{
			
			string CacheKey = "occu_inforModel-" + occ_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(occ_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (CdHotelManage.Model.occu_infor)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        public DataSet GetLists(string strWhere)
        {
            return dal.GetLists(strWhere);
        }
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CdHotelManage.Model.occu_infor> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CdHotelManage.Model.occu_infor> GetModelListNamecard(string strWhere)
        {
            DataSet ds = dal.GetListNamecard(strWhere);
            return DataTableToList23(ds.Tables[0]);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CdHotelManage.Model.occu_infor> DataTableToList(DataTable dt)
		{
			List<CdHotelManage.Model.occu_infor> modelList = new List<CdHotelManage.Model.occu_infor>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CdHotelManage.Model.occu_infor model;
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
        public List<CdHotelManage.Model.occu_infor> DataTableToList23(DataTable dt)
        {
            List<CdHotelManage.Model.occu_infor> modelList = new List<CdHotelManage.Model.occu_infor>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CdHotelManage.Model.occu_infor model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel23(dt.Rows[n]);
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        public IList<CdHotelManage.Model.occu_infor> GetBookRoomPager(string sort, string order, int currentPage, int pageSize, string strWhere)
        {
            DataSet ds = dal.GetBookRoomPager(sort, order, currentPage, pageSize, strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        ///通过月日查询
        /// </summary>
        /// <param name="day"></param>
        public DataSet GetDaySheetbymouth(string strTimeWhere)
        {
            return dal.GetDaySheetbymouth(strTimeWhere);
        }
        /// <summary>
        /// 通过日期查询当日的报表数据
        /// </summary>
        /// <param name="day"></param>
        public List<Model.occu_infor> GetDaySheetByOrderID(string strTimeWhere)
        {
            return dal.GetDaySheetByOrderID(strTimeWhere);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

