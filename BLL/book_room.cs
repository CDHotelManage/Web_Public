using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CdHotelManage.Model;
using CdHotelManage.DAL;
namespace CdHotelManage.BLL
{
	/// <summary>
	/// book_room
	/// </summary>
	public partial class book_room
	{
		private readonly CdHotelManage.DAL.book_room dal=new CdHotelManage.DAL.book_room();
		public book_room()
		{}
		#region  BasicMethod

        public  Model.book_room GetRealNum(int state_id)
        {
            return dal.GetRealNum(state_id);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CdHotelManage.Model.book_room model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CdHotelManage.Model.book_room model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int book_id)
		{
			
			return dal.Delete(book_id);
		}

        /// <summary>
        /// 根据条件删除
        /// </summary>
        public bool DeletebyWhere(string strWhere)
        {
            return dal.DeletebyWhere(strWhere);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string book_idlist )
		{
			return dal.DeleteList(book_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.book_room GetModel(int book_id)
		{
			
			return dal.GetModel(book_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public CdHotelManage.Model.book_room GetModelByCache(int book_id)
		{
			
			string CacheKey = "book_roomModel-" + book_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(book_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (CdHotelManage.Model.book_room)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CdHotelManage.Model.book_room> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CdHotelManage.Model.book_room> DataTableToList(DataTable dt)
		{
			List<CdHotelManage.Model.book_room> modelList = new List<CdHotelManage.Model.book_room>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CdHotelManage.Model.book_room model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

        public IList<CdHotelManage.Model.book_room> GetBookRoomPager(string sort, string order, int currentPage, int pageSize, string strWhere)
        {
            DataSet ds = dal.GetBookRoomPager(sort, order, currentPage, pageSize,strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        public int GetBookRecordCount(string strWhere)
        {
            return dal.GetBookRecordCount(strWhere);
        }

        //public int GetSumRealRoom(string sort, string order, int currentPage, int pageSize, string strWhere)
        //{
        //    return dal.GetSumRealRoom(sort, order, currentPage, pageSize, strWhere);
        //}
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
       
	}
}

