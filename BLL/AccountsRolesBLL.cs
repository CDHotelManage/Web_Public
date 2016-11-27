using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Hotel.ApplictionFactory;

namespace CdHotelManage.BLL
{
    public class AccountsRolesBLL
    {
        public AccountsRolesBLL()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CdHotelManage.Model.AccountsRoles model)
        {
            return RolesBridge.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CdHotelManage.Model.AccountsRoles model)
        {
            return RolesBridge.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            //该表无主键信息，请自定义主键/条件字段
            return RolesBridge.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.AccountsRoles GetModel(int id)
        {
            //该表无主键信息，请自定义主键/条件字段
            return RolesBridge.GetModel(id);
        }        

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return RolesBridge.GetMaxId();
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return RolesBridge.GetList(strWhere);
        }

        public DataSet GetListByTitle(string title)
        {
            return RolesBridge.GetListByTitle(title);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return RolesBridge.GetList(Top, strWhere, filedOrder);
        }
        

        #endregion  Method
    }
}
