using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CdHotelManage.Model;
namespace CdHotelManage.BLL
{
	/// <summary>
	/// Users
	/// </summary>
	public partial class UsersBLL
	{
        private readonly CdHotelManage.DAL.UsersDAL dal = new CdHotelManage.DAL.UsersDAL();
		public UsersBLL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string userid)
		{
			return dal.Exists(userid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CdHotelManage.Model.Users model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CdHotelManage.Model.Users model)
		{
			return dal.Update(model);
		}

         /// <summary>
        /// 更新一条数据(手机端)
        /// </summary>
        public bool UpdateInfo(CdHotelManage.Model.Users model)
        {
            return dal.UpdateInfo(model);
        }
        /// <summary>
        /// 更新密码
        /// </summary>
        public bool UpdatePwd(CdHotelManage.Model.Users model)
        {
            return dal.UpdatePwd(model);
        }

        /// <summary>
        /// 根据用户名和密码检查用户
        /// </summary>
        public CdHotelManage.Model.Users CheckUser(string username, string pwd)
        {
            return dal.GetUserByLogin(username, pwd);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string userid)
		{
			
			return dal.Delete(userid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string useridlist )
		{
			return dal.DeleteList(useridlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.Users GetModel(string userid)
		{
			
			return dal.GetModel(userid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public CdHotelManage.Model.Users GetModelByCache(string userid)
		{
			
			string CacheKey = "UsersModel-" + userid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(userid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (CdHotelManage.Model.Users)objModel;
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
		public List<CdHotelManage.Model.Users> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CdHotelManage.Model.Users> DataTableToList(DataTable dt)
		{
			List<CdHotelManage.Model.Users> modelList = new List<CdHotelManage.Model.Users>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CdHotelManage.Model.Users model;
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
		
	}
}

