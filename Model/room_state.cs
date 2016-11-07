using System;
namespace CdHotelManage.Model
{
    /// <summary>
    /// room_state:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class room_state
    {
        public room_state()
        { }
        #region Model
        private int _room_state_id;
        private string _room_state_name;
        private string _remark;
        private string _room_suod;

        public string Room_suod
        {
            get { return _room_suod; }
            set { _room_suod = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int room_state_id
        {
            set { _room_state_id = value; }
            get { return _room_state_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string room_state_name
        {
            set { _room_state_name = value; }
            get { return _room_state_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

        public string Room_color { get; set; }

    }
}

