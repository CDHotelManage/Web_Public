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
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(CdHotelManage.Model.FtSet model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(CdHotelManage.Model.FtSet model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// �õ�һ������ʵ��
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

