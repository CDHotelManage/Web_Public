using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class ExceedScheme
    {
        public ExceedScheme()
        { }
        #region Model
        private int _typeroom;
        private int? _gracetime;
        private int? _earlyapart;
        private decimal? _earlyapartaddp;
        private int? _earlyinsufficient;
        private int? _earlyinexceed;
        private decimal? _earlyinaddpri;
        /// <summary>
        /// 
        /// </summary>
        public int TypeRoom
        {
            set { _typeroom = value; }
            get { return _typeroom; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? GraceTime
        {
            set { _gracetime = value; }
            get { return _gracetime; }
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
        public decimal? EarlyapartAddP
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
