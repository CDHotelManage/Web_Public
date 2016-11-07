using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CdHotelManage.Model;
namespace CdHotelManage.BLL
{
	/// <summary>
	/// goods_account
	/// </summary>
	public partial class goods_account
	{
		private readonly CdHotelManage.DAL.goods_account dal=new CdHotelManage.DAL.goods_account();
		public goods_account()
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
        public DataTable GetDsBySql(string sql) {
            return dal.GetDsBySql(sql);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CdHotelManage.Model.goods_account model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CdHotelManage.Model.goods_account model)
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
        /// 删除一条数据2
        /// </summary>
        public bool Deletes(string swhere)
        {

            return dal.Deletes(swhere);
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
        public CdHotelManage.Model.goods_account GetModels1(int id)
        {
            return dal.GetModels1(id);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.goods_account GetModel(int id)
		{
			
			return dal.GetModel(id);
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.goods_account GetModels(string stwhere)
        {

            return dal.GetModels(stwhere);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public CdHotelManage.Model.goods_account GetModelByCache(int id)
		{
			
			string CacheKey = "goods_accountModel-" + id;
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
			return (CdHotelManage.Model.goods_account)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        //修改是否交班状态
        public int Updatesis(string uid)
        {
            return dal.Updatesis(uid);
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
		public List<CdHotelManage.Model.goods_account> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
            if (ds.Tables[0].Rows.Count <= 0) { return null; }
			return DataTableToList(ds.Tables[0]);
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CdHotelManage.Model.goods_account> GetModelList1(string strWhere)
        {
            return dal.GetListByWhere(strWhere);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CdHotelManage.Model.goods_account> DataTableToList(DataTable dt)
		{
			List<CdHotelManage.Model.goods_account> modelList = new List<CdHotelManage.Model.goods_account>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CdHotelManage.Model.goods_account model;
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
        /// 根据条件获得所有的收款方式
        /// </summary>
        public string GeMethPayType(string strWhere)
        {
            return dal.GeMethPayType(strWhere);
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

        /// <summary>
        /// 获得支付方式和总现金
        /// </summary>
        public DataSet GeMethPaySumMoney(string strWhere,int istrue)
        {
            return dal.GeMethPaySumMoney(strWhere,istrue);

        }

        //获得明细支付方式和现金
        public DataSet GeMethPayMoney(string strWhere)
        {
            return dal.GeMethPayMoney(strWhere);
        }

         //根据时间和支付方式查询明细
        public DataSet GetMethPayMoneyPage1(string sort, string order, int currentPage, int pageSize, string strWhere)
        {
            return dal.GetMethPayMoneyPage1(sort, order, currentPage, pageSize, strWhere);
        }

        //获得明细支付方式和现金
        public IList<CdHotelManage.Model.goods_account> GetMethPayMoneyPage(string sort, string order, int currentPage, int pageSize, string strWhere)
        {
            DataSet ds = dal.GetMethPayMoneyPage(sort, order, currentPage, pageSize, strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        public DataSet GetSumInfo(string strWhere)
        {
            return dal.GetSumInfo(strWhere);
        }
        public DataSet GoodsQX(string SQL)
        {
            return dal.GoodsQX(SQL);
        }

        public int ShiftDelete(string id)
        {
            return dal.ShiftDelete(id);
        }
        public DataTable GetGoodsFh1(string roomnuber, string whee)
        {
            return dal.GetGoodsFh1(roomnuber, whee);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
        public DataTable GetGoodsFh(string roomnuber,string whee) {
            return dal.GetGoodsFh(roomnuber, whee);
        }
        public List<Model.goods_account> GetListOut(string strWhere) {
            return dal.GetListOut(strWhere);
        }


        public string GetAllByday(string strWhere) {
            return dal.GetAllByday(strWhere);
        }

        public DataSet GetAllBydays(string strWhere)
        {
            return dal.GetAllBydays(strWhere);
        }
	}
}

