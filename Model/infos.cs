using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class infos
    {
        public infos()
        { }
        #region Model
        private int _id;
        private string _number;
        private string _type;
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
        public string number
        {
            set { _number = value; }
            get { return _number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        #endregion Model
    }
}
