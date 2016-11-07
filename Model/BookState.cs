using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class BookState
    {
        public BookState()
        { }
        #region Model
        private int _id;
        private string _statname;
        private string _reamrk;
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
        public string statName
        {
            set { _statname = value; }
            get { return _statname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Reamrk
        {
            set { _reamrk = value; }
            get { return _reamrk; }
        }
        #endregion Model
    }
}
