using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CdHotelManage.Model;
namespace CdHotelManage.BLL
{
	/// <summary>
	/// Shift_Exc
	/// </summary>
	public partial class Shift_Exc
	{
		private readonly CdHotelManage.DAL.Shift_Exc dal=new CdHotelManage.DAL.Shift_Exc();
		public Shift_Exc()
		{}
		#region  BasicMethod


         /*获得不同类型的收款方式所产生的金额*/
        public DataSet GetAllBydays(string strWhere)
        {
            return dal.GetAllBydays(strWhere);
        }

          /// <summary>
        /// 根据条件获得所有的收款方式
        /// </summary>
        public string GeMethPayType(string strWhere)
        {
            return dal.GeMethPayType(strWhere);
        }

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
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CdHotelManage.Model.Shift_Exc model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CdHotelManage.Model.Shift_Exc model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			return dal.DeleteList(Idlist );
		}

        public int DeleteAll() {
            return dal.DeleteAll();
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.Shift_Exc GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public CdHotelManage.Model.Shift_Exc GetModelByCache(int Id)
		{
			
			string CacheKey = "Shift_ExcModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (CdHotelManage.Model.Shift_Exc)objModel;
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
		public List<CdHotelManage.Model.Shift_Exc> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CdHotelManage.Model.Shift_Exc> DataTableToList(DataTable dt)
		{
			List<CdHotelManage.Model.Shift_Exc> modelList = new List<CdHotelManage.Model.Shift_Exc>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CdHotelManage.Model.Shift_Exc model;
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

		#endregion  ExtensionMethod

        public DataSet GeMethPaySumMoney(string strWhere)
        {
           return dal.GeMethPaySumMoney(strWhere);
        }

        public IList<CdHotelManage.Model.Shift_Exc> GeMethPayMoneyPage(string sort, string order, int currentPage, int pageSize, string strWhere)
        {
            DataSet ds = dal.GeMethPayMoneyPage(sort, order, currentPage, pageSize, strWhere);
            return DataTableToList(ds.Tables[0]);
        }
	}
}

