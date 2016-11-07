using System;
using System.Data;
using System.Collections.Generic;
using CdHotelManage.Model;
namespace CdHotelManage.BLL
{
    /// <summary>
    /// FtSet
    /// </summary>
    public partial class FtSet
    {
        private readonly CdHotelManage.DAL.FtSet dal = new CdHotelManage.DAL.FtSet();
        public FtSet()
        { }
        #region  BasicMethod
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
        public int Add(CdHotelManage.Model.FtSet model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CdHotelManage.Model.FtSet model)
        {
            return dal.Update(model);
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
        public CdHotelManage.Model.FtSet GetModel(int id)
        {

            return dal.GetModel(id);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

