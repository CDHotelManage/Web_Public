using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    [Serializable]
    public partial class floor_ld
    {
        public floor_ld()
        { }
       #region Model
        private int _id;
        private string _ld_Name;
     
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ld_Name
        {
            set { _ld_Name = value; }
            get { return _ld_Name; }
        }
  
        #endregion Model

    }
   
}
