using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class SuoSys
    {
        public SuoSys()
        { }
        #region Model
        private int _id;
        private string _suotypename;
        private bool _iscomm;
        private bool _isbacksuo;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SuoTypeName
        {
            set { _suotypename = value; }
            get { return _suotypename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsComm
        {
            set { _iscomm = value; }
            get { return _iscomm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsBackSuo
        {
            set { _isbacksuo = value; }
            get { return _isbacksuo; }
        }
        #endregion Model
    }
}
