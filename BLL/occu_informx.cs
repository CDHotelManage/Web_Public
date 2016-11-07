using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CdHotelManage.Model;
using CdHotelManage.DAL;
namespace CdHotelManage.BLL
{
    /// <summary>
    /// occu_informx
    /// </summary>
    public partial class occu_informx
    {
        private readonly CdHotelManage.DAL.occu_informx dal = new CdHotelManage.DAL.occu_informx();
        public occu_informx()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int occ_id)
        {
            return dal.Exists(occ_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CdHotelManage.Model.occu_informx model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CdHotelManage.Model.occu_informx model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int occ_id)
        {

            return dal.Delete(occ_id);
        }
        /// <summary>
        /// 删除一条数据2
        /// </summary>
        public bool Deletes(string SQl)
        {

            return dal.Deletes(SQl);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string occ_idlist)
        {
            return dal.DeleteList(occ_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.occu_informx GetModel(int occ_id)
        {

            return dal.GetModel(occ_id);
        }

      
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CdHotelManage.Model.book_room GetModelByCache(int book_id)
        {

            string CacheKey = "occu_informxModel-" + book_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(book_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CdHotelManage.Model.book_room)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CdHotelManage.Model.occu_informx> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CdHotelManage.Model.occu_informx> DataTableToList(DataTable dt)
        {
            List<CdHotelManage.Model.occu_informx> modelList = new List<CdHotelManage.Model.occu_informx>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CdHotelManage.Model.occu_informx model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CdHotelManage.Model.occu_informx();
                    if (dt.Rows[n]["occ_id"] != null && dt.Rows[n]["occ_id"].ToString() != "")
                    {
                        model.occ_id = int.Parse(dt.Rows[n]["occ_id"].ToString());
                    }
                    if (dt.Rows[n]["occ_no"] != null && dt.Rows[n]["occ_no"].ToString() != "")
                    {
                        model.occ_no = dt.Rows[n]["occ_no"].ToString();
                    }
                    if (dt.Rows[n]["order_id"] != null && dt.Rows[n]["order_id"].ToString() != "")
                    {
                        model.order_id = int.Parse(dt.Rows[n]["order_id"].ToString());
                    }
                    if (dt.Rows[n]["occ_name"] != null && dt.Rows[n]["occ_name"].ToString() != "")
                    {
                        model.occ_name = dt.Rows[n]["occ_name"].ToString();
                    }
                    if (dt.Rows[n]["occ_with"] != null && dt.Rows[n]["occ_with"].ToString() != "")
                    {
                        model.occ_with = dt.Rows[n]["occ_with"].ToString();
                    }
                    if (dt.Rows[n]["real_type_id"] != null && dt.Rows[n]["real_type_id"].ToString() != "")
                    {
                        model.real_type_id = int.Parse(dt.Rows[n]["real_type_id"].ToString());
                    }
                    if (dt.Rows[n]["room_number"] != null && dt.Rows[n]["room_number"].ToString() != "")
                    {
                        model.room_number = dt.Rows[n]["room_number"].ToString();
                    }
                    if (dt.Rows[n]["real_scheme_id"] != null && dt.Rows[n]["real_scheme_id"].ToString() != "")
                    {
                        model.real_scheme_id = int.Parse(dt.Rows[n]["real_scheme_id"].ToString());
                    }
                    if (dt.Rows[n]["source_id"] != null && dt.Rows[n]["source_id"].ToString() != "")
                    {
                        model.source_id = int.Parse(dt.Rows[n]["source_id"].ToString());
                    }
                    if (dt.Rows[n]["mem_cardno"] != null && dt.Rows[n]["mem_cardno"].ToString() != "")
                    {
                        model.mem_cardno = dt.Rows[n]["mem_cardno"].ToString();
                    }
                    if (dt.Rows[n]["real_mode_id"] != null && dt.Rows[n]["real_mode_id"].ToString() != "")
                    {
                        model.real_mode_id = int.Parse(dt.Rows[n]["real_mode_id"].ToString());
                    }
                    if (dt.Rows[n]["real_price"] != null && dt.Rows[n]["real_price"].ToString() != "")
                    {
                        model.real_price = decimal.Parse(dt.Rows[n]["real_price"].ToString());
                    }
                    if (dt.Rows[n]["occ_time"] != null && dt.Rows[n]["occ_time"].ToString() != "")
                    {
                        model.occ_time = DateTime.Parse(dt.Rows[n]["occ_time"].ToString());
                    }
                    if (dt.Rows[n]["stay_day"] != null && dt.Rows[n]["stay_day"].ToString() != "")
                    {
                        model.stay_day = int.Parse(dt.Rows[n]["stay_day"].ToString());
                    }
                    if (dt.Rows[n]["stay_deposit"] != null && dt.Rows[n]["stay_deposit"].ToString() != "")
                    {
                        model.stay_deposit = decimal.Parse(dt.Rows[n]["stay_deposit"].ToString());
                    }
                    if (dt.Rows[n]["depar_time"] != null && dt.Rows[n]["depar_time"].ToString() != "")
                    {
                        model.depar_time = DateTime.Parse(dt.Rows[n]["depar_time"].ToString());
                    }
                    if (dt.Rows[n]["pha_sched"] != null && dt.Rows[n]["pha_sched"].ToString() != "")
                    {
                        model.pha_sched = DateTime.Parse(dt.Rows[n]["pha_sched"].ToString());
                    }
                    if (dt.Rows[n]["card_id"] != null && dt.Rows[n]["card_id"].ToString() != "")
                    {
                        model.card_id = int.Parse(dt.Rows[n]["card_id"].ToString());
                    }
                    if (dt.Rows[n]["card_no"] != null && dt.Rows[n]["card_no"].ToString() != "")
                    {
                        model.card_no = dt.Rows[n]["card_no"].ToString();
                    }
                    if (dt.Rows[n]["brithday"] != null && dt.Rows[n]["brithday"].ToString() != "")
                    {
                        model.brithday = dt.Rows[n]["brithday"].ToString();
                    }
                    if (dt.Rows[n]["sex"] != null && dt.Rows[n]["sex"].ToString() != "")
                    {
                        model.sex = dt.Rows[n]["sex"].ToString();
                    }
                    if (dt.Rows[n]["family_name"] != null && dt.Rows[n]["family_name"].ToString() != "")
                    {
                        model.family_name = dt.Rows[n]["family_name"].ToString();
                    }
                    if (dt.Rows[n]["address"] != null && dt.Rows[n]["address"].ToString() != "")
                    {
                        model.address = dt.Rows[n]["address"].ToString();
                    }
                    if (dt.Rows[n]["state_id"] != null && dt.Rows[n]["state_id"].ToString() != "")
                    {
                        model.state_id = int.Parse(dt.Rows[n]["state_id"].ToString());
                    }
                    if (dt.Rows[n]["deposit"] != null && dt.Rows[n]["deposit"].ToString() != "")
                    {
                        model.deposit = decimal.Parse(dt.Rows[n]["deposit"].ToString());
                    }
                    if (dt.Rows[n]["amount_money"] != null && dt.Rows[n]["amount_money"].ToString() != "")
                    {
                        model.amount_money = decimal.Parse(dt.Rows[n]["amount_money"].ToString());
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = dt.Rows[n]["sort"].ToString();
                    }
                    if (dt.Rows[n]["lordRoomid"] != null && dt.Rows[n]["lordRoomid"].ToString() != "")
                    {
                        model.lordRoomid = dt.Rows[n]["lordRoomid"].ToString();
                    }
                    if (dt.Rows[n]["continuelive"] != null && dt.Rows[n]["continuelive"].ToString() != "")
                    {
                        model.continuelive = int.Parse(dt.Rows[n]["continuelive"].ToString());
                    }
                    if (dt.Rows[n]["phonenum"] != null && dt.Rows[n]["phonenum"].ToString() != "")
                    {
                        model.phonenum = dt.Rows[n]["phonenum"].ToString();
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
    }
}

