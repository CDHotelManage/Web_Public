using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.BLL
{
    public class SysParameter
    {
        private readonly CdHotelManage.DAL.SysParameter dal = new CdHotelManage.DAL.SysParameter();
        public SysParameter()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CdHotelManage.Model.SysParamter model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CdHotelManage.Model.SysParamter model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CdHotelManage.Model.SysParamter GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
