using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.BLL
{
    public class infos
    {
        DAL.infos dal = new DAL.infos();
        public infos()
        { }
        #region  BasicMethod
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

        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CdHotelManage.Model.infos model)
        {
            return dal.Add(model);
        }

        #endregion  BasicMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.infos GetModel(int id)
        {

            return dal.GetModel(id);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
