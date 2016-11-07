using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CdHotelManage.Model;
using CdHotelManage.DAL;

namespace CdHotelManage.BLL
{
    public class Book_Rdetail
    {
        private readonly CdHotelManage.DAL.Book_Rdetail dal=new CdHotelManage.DAL.Book_Rdetail();
        public Book_Rdetail()
		{}

        public List<Model.Book_Rdetail> GetListModel1(string strWhere)
        {
            return dal.GetListModel1(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public List<Model.Book_Rdetail> GetListModel(string strWhere) {
            return dal.GetListModel(strWhere);
        }

         /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Book_Rdetail model)
        {
            return dal.Add(model);
        }

         /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Book_Rdetail model)
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {
            return dal.Delete(Id);
        }

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        public bool DeletebyWhere(string strWhere)
        {
            return dal.DeletebyWhere(strWhere);
        }

         /// <summary>
        /// 计算已开房数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetAllNum(string strWhere)
        {
            return dal.GetAllNum(strWhere);
        }
    }
}
