using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CdHotelManage.BLL
{
    public class AccountsUsersBLL
    {
        private readonly CdHotelManage.DAL.AccountsUsersDAL dal = new CdHotelManage.DAL.AccountsUsersDAL();
        public AccountsUsersBLL()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CdHotelManage.Model.AccountsUsers model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CdHotelManage.Model.AccountsUsers model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.Delete(id);
        }

        /// <summary>
        /// 根据用户名和密码检查用户
        /// </summary>
        public CdHotelManage.Model.AccountsUsers CheckUser(string username, string pwd)
        {
            return dal.GetUserByLogin(username, pwd);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.AccountsUsers GetModel(string id)
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.GetModel(id);
        }

        public CdHotelManage.Model.AccountsUsers GetModelByName(string name)
        {
            return dal.GetModelByName(name);
        }
        /// <summary>
        /// 根据编号得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.AccountsUsers GetModelByNum(string num)
        {
            return dal.GetModelByNum(num);
        }
        /// <summary>
        /// 查找最大编号
        /// </summary>
        /// <summary>
        /// 
        public string GetMaxNum()
        {
            return dal.GetMaxNum();
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public OA.Model.Accounts_Users GetModelByCache()
        //{
        //    //该表无主键信息，请自定义主键/条件字段
        //    string CacheKey = "Accounts_UsersModel-" ;
        //    object objModel = OA.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel();
        //            if (objModel != null)
        //            {
        //                int ModelCache = OA.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                OA.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (OA.Model.Accounts_Users)objModel;
        //}

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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CdHotelManage.Model.AccountsUsers> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CdHotelManage.Model.AccountsUsers> DataTableToList(DataTable dt)
        {
            List<CdHotelManage.Model.AccountsUsers> modelList = new List<CdHotelManage.Model.AccountsUsers>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CdHotelManage.Model.AccountsUsers model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CdHotelManage.Model.AccountsUsers();
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = dt.Rows[n]["UserID"].ToString();
                    }
                    if (dt.Rows[n]["UserName"] != null && dt.Rows[n]["UserName"].ToString() != "")
                    {
                        model.UserName = dt.Rows[n]["UserName"].ToString();
                    }
                    if (dt.Rows[n]["Password"] != null && dt.Rows[n]["Password"].ToString() != "")
                    {
                        model.Password = dt.Rows[n]["Password"].ToString();
                    }
                    if (dt.Rows[n]["TrueName"] != null && dt.Rows[n]["TrueName"].ToString() != "")
                    {
                        model.TrueName = dt.Rows[n]["TrueName"].ToString();
                    }
                    if (dt.Rows[n]["Sex"] != null && dt.Rows[n]["Sex"].ToString() != "")
                    {
                        model.Sex = dt.Rows[n]["Sex"].ToString();
                    }
                    if (dt.Rows[n]["Phone"] != null && dt.Rows[n]["Phone"].ToString() != "")
                    {
                        model.Phone = dt.Rows[n]["Phone"].ToString();
                    }
                    if (dt.Rows[n]["Email"] != null && dt.Rows[n]["Email"].ToString() != "")
                    {
                        model.Email = dt.Rows[n]["Email"].ToString();
                    }
                    if (dt.Rows[n]["EmployeeID"] != null && dt.Rows[n]["EmployeeID"].ToString() != "")
                    {
                        model.EmployeeID = int.Parse(dt.Rows[n]["EmployeeID"].ToString());
                    }
                    if (dt.Rows[n]["DepartmentID"] != null && dt.Rows[n]["DepartmentID"].ToString() != "")
                    {
                        model.DepartmentID = dt.Rows[n]["DepartmentID"].ToString();
                    }
                    if (dt.Rows[n]["Activity"] != null && dt.Rows[n]["Activity"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Activity"].ToString() == "1") || (dt.Rows[n]["Activity"].ToString().ToLower() == "true"))
                        {
                            model.Activity = true;
                        }
                        else
                        {
                            model.Activity = false;
                        }
                    }
                    if (dt.Rows[n]["UserType"] != null && dt.Rows[n]["UserType"].ToString() != "")
                    {
                        model.UserType = dt.Rows[n]["UserType"].ToString();
                    }
                    if (dt.Rows[n]["Style"] != null && dt.Rows[n]["Style"].ToString() != "")
                    {
                        model.Style = int.Parse(dt.Rows[n]["Style"].ToString());
                    }
                    modelList.Add(model);
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method

        #region  进行分页

        public int GetCount()
        {
            return dal.GetCount();

        }

        public IList<CdHotelManage.Model.AccountsUsers> GetUsersPager(string sort, string order, int currentPage, int pageSize)
        {
            DataSet ds = dal.GetUsersPager(sort, order, currentPage, pageSize);
            return DataTableToList(ds.Tables[0]);
        }



        #endregion


    }
}
