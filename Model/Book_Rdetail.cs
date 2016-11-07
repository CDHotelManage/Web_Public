using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{

    public class Book_Rdetail
    {
        public int ID { get; set; }
        public string Book_no { get; set; }
        public int Real_type_Id { get; set; }
        public string Room_number { get; set; }
        public int Real_num { get; set; }
        public decimal Real_Price { get; set; }
        public int Real_Scheme_Id { get; set; }
        public int Ok_num { get; set; }
        public int RoomTypeID { get; set; }
        public decimal Book_Price { get; set; }
        public Model.hourse_scheme Hourse_scheme_model { get; set; }
    }
}
