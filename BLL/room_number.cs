using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CdHotelManage.Model;
namespace CdHotelManage.BLL
{
	/// <summary>
	/// room_number
	/// </summary>
	public partial class room_number
	{
		private readonly CdHotelManage.DAL.room_number dal=new CdHotelManage.DAL.room_number();
		public room_number()
		{}
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
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CdHotelManage.Model.room_number model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CdHotelManage.Model.room_number model)
		{
			return dal.Update(model);
		}
        /// <summary>
        /// 更新一条数据2
        /// </summary>
        public bool Updates(string SQL)
        {
            return dal.Updates(SQL);
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
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.room_number GetModel(int id)
		{
			
			return dal.GetModel(id);
		}
        /// <summary>
        /// 得到一个对象实体2
        /// </summary>
        public CdHotelManage.Model.room_number GetModel(int id, string TabCell)
        {

            return dal.GetModel(id, TabCell);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public CdHotelManage.Model.room_number GetModelByCache(int id)
		{
			
			string CacheKey = "room_numberModel-" + id;
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
				catch{}
			}
			return (CdHotelManage.Model.room_number)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        public DataSet GetListed(string strWhere,string join)
		{
            return dal.GetListed(strWhere,join);
		}
        public DataSet GetProc(string str, int flo, string num, string time) {
            return dal.GetProc(str, flo, num, time);
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
		public List<CdHotelManage.Model.room_number> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CdHotelManage.Model.room_number> DataTableToList(DataTable dt)
		{
			List<CdHotelManage.Model.room_number> modelList = new List<CdHotelManage.Model.room_number>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CdHotelManage.Model.room_number model;
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
        public IList<CdHotelManage.Model.room_number> GetBookRoomPager(string sort, string order, int currentPage, int pageSize, string strWhere)
        {
            DataSet ds = dal.GetBookRoomPager(sort, order, currentPage, pageSize, strWhere);
            return DataTableToList(ds.Tables[0]);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod

        /// <summary>
        /// 是否锁房
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <returns></returns>
        public string IsSuoFang(string roomNumber) {
            return dal.IsSuoFang(roomNumber);
        }
	}
}

