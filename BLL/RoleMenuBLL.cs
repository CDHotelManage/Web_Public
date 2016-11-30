using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CdHotelManage.Model;
using Hotel.ApplictionFactory;

namespace CdHotelManage.BLL
{
	/// <summary>
	/// RoleMenu
	/// </summary>
	public partial class RoleMenuBLL
	{
		private readonly CdHotelManage.DAL.RoleMenuDAL dal=new CdHotelManage.DAL.RoleMenuDAL();
		public RoleMenuBLL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CdHotelManage.Model.RoleMenu model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CdHotelManage.Model.RoleMenu model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(int RoleID)
		{
			//该表无主键信息，请自定义主键/条件字段
            return dal.Delete(RoleID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.RoleMenu GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public CdHotelManage.Model.RoleMenu GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "RoleMenuModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (CdHotelManage.Model.RoleMenu)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string roleId)
		{
			return RoleMenuBridge.GetList(roleId);
		}

        public DataSet GetList(string meunuPId,string roleId)
        {            
            return RoleMenuBridge.GetList(meunuPId, roleId);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetSingleOrderByMenuId(string meunuPId, string roleId)
		{
			return RoleMenuBridge.GetSingleOrderByMenuId(meunuPId, roleId);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CdHotelManage.Model.RoleMenu> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CdHotelManage.Model.RoleMenu> DataTableToList(DataTable dt)
		{
			List<CdHotelManage.Model.RoleMenu> modelList = new List<CdHotelManage.Model.RoleMenu>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CdHotelManage.Model.RoleMenu model;
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

		#endregion  BasicMethod
		#region  ExtensionMethod
        public bool DeleteALL(int roleid)
        {
            return dal.DeleteALL(roleid);
        }
		#endregion  ExtensionMethod
	}
}

