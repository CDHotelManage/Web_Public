using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CdHotelManage.Model;
using Hotel.ApplictionFactory;

namespace CdHotelManage.BLL
{
	/// <summary>
	/// Menu
	/// </summary>
	public partial class MenuBLL
	{
		private readonly CdHotelManage.DAL.MenuDAL dal=new CdHotelManage.DAL.MenuDAL();
		public MenuBLL()
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
		public bool Exists(int menu_id)
		{
			return dal.Exists(menu_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CdHotelManage.Model.Menu model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CdHotelManage.Model.Menu model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int menu_id)
		{
			
			return dal.Delete(menu_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string menu_idlist )
		{
			return dal.DeleteList(menu_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.Menu GetModel(int menu_id)
		{
			
			return MenuBridge.GetModel(menu_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public CdHotelManage.Model.Menu GetModelByCache(int menu_id)
		{
			
			string CacheKey = "MenuModel-" + menu_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(menu_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (CdHotelManage.Model.Menu)objModel;
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
		public List<CdHotelManage.Model.Menu> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CdHotelManage.Model.Menu> DataTableToList(DataTable dt)
		{
			List<CdHotelManage.Model.Menu> modelList = new List<CdHotelManage.Model.Menu>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CdHotelManage.Model.Menu model;
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
		

		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataSet GetMenuPager(string sort, string order, int currentPage, int pageSize, int id)
        {
            return dal.GetMenuPager(sort, order, currentPage, pageSize, id);
        }

        //根据数组查询菜单
        public DataSet GetMenulist(string menu_id)
        {

            return MenuBridge.GetMenulist(menu_id);
        }
		#endregion  ExtensionMethod
	}
}

