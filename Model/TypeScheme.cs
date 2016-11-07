using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class TypeScheme
    {
        public TypeScheme()
        { }
        #region Model
        private int _typeid;
        private int? _earlyapart;
        private int? _earlyapartaddp;
        private int? _earlyinsufficient;
        private int? _earlyinexceed;
        private decimal? _earlyinaddpri;
        /// <summary>
        /// 
        /// </summary>
        public int typeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Earlyapart
        {
            set { _earlyapart = value; }
            get { return _earlyapart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? EarlyapartAddP
        {
            set { _earlyapartaddp = value; }
            get { return _earlyapartaddp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? EarlyInsufficient
        {
            set { _earlyinsufficient = value; }
            get { return _earlyinsufficient; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? EarlyInExceed
        {
            set { _earlyinexceed = value; }
            get { return _earlyinexceed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? EarlyInAddPri
        {
            set { _earlyinaddpri = value; }
            get { return _earlyinaddpri; }
        }
        #endregion Model
    }
}
