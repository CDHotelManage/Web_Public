using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Hotel.ApplictionFactory;

namespace CdHotelManage.BLL
{
    public class AccountsUsersBLL
    {
        public AccountsUsersBLL()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CdHotelManage.Model.AccountsUsers model)
        {
            return AccountBridge.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CdHotelManage.Model.AccountsUsers model)
        {
            return AccountBridge.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {
            //该表无主键信息，请自定义主键/条件字段
            return AccountBridge.Delete(id);
        }

        /// <summary>
        /// 根据用户名和密码检查用户
        /// </summary>
        public CdHotelManage.Model.AccountsUsers CheckUser(string username, string pwd)
        {
            return AccountBridge.CheckUser(username, pwd);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.AccountsUsers GetModel(string id)
        {
            //该表无主键信息，请自定义主键/条件字段
            return AccountBridge.GetModel(id);
        }

        public CdHotelManage.Model.AccountsUsers GetModelByName(string name)
        {
            return AccountBridge.GetModelByName(name);
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return AccountBridge.GetList(strWhere);
        }       
        

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        

        #endregion  Method

        #region  进行分页

        public int GetCount()
        {
            return AccountBridge.GetCount();

        }

        public IList<CdHotelManage.Model.AccountsUsers> GetUsersPager(string sort, string order, int currentPage, int pageSize)
        {
            return AccountBridge.GetUsersPager(sort, order, currentPage, pageSize);
        }



        #endregion


    }
}
