using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Hotel.ApplictionFactory;

namespace CdHotelManage.BLL
{
    public class AccountsUserRolesBLL
    {
        private readonly CdHotelManage.DAL.AccountsUserRolesDAL dal = new CdHotelManage.DAL.AccountsUserRolesDAL();
        public AccountsUserRolesBLL()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CdHotelManage.Model.AccountsUserRoles model)
        {
            return AccountRolesBridge.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CdHotelManage.Model.AccountsUserRoles model)
        {
            return AccountRolesBridge.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {
            //该表无主键信息，请自定义主键/条件字段
            return AccountRolesBridge.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.AccountsUserRoles GetModel(string id)
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.GetModel(id);
        }       

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        

        #endregion  Method
    }
}
