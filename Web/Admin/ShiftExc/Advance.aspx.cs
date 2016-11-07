using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.ShiftExc
{
    public partial class Advance : BasePage
    {
        protected Model.book_room nowModel = new Model.book_room();
        BLL.book_room bllbr = new BLL.book_room();
        BLL.Book_Rdetail bllbrs = new BLL.Book_Rdetail();
        string id = string.Empty;
        protected System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
       

        //获得客人来源中文名称

        protected string GetSourceTypeName(object id)
        {
            if (id.ToString() == "")
            {
                return "";
            }
            BLL.meth_pay bllmp = new BLL.meth_pay();
            Model.meth_pay model = bllmp.GetModel(Convert.ToInt32(id.ToString()));
            return model.meth_pay_name;


        }

        //获得房型名称
        public string GetRealTypeName(object id)
        {
            if (id.ToString() == "")
            {
                return "";
            }
            BLL.room_type rtbll = new BLL.room_type();

            Model.room_type model = rtbll.GetModel(Convert.ToInt32(id.ToString()));

            if (model != null)
            {
                if (model.room_name != null)
                {
                    if (model.room_name == "")
                    {
                        return "";
                    }
                }

                return model.room_name;

            }
            return "";
        }

        private void Bind() {
           
            Dictionary<int, string> dic = new Dictionary<int, string>();
            List<Model.Book_Rdetail> listbr = bllbrs.GetListModel1("Book_no='" + id + "'");
            if (listbr != null) {
                foreach (Model.Book_Rdetail room in listbr)
                {
                    if (dic.ContainsKey(room.Real_type_Id))
                    {
                        break;
                    }
                    dic.Add(room.Real_type_Id, "true");
                    List<Model.Book_Rdetail> lists = listbr.Where(d => d.Real_type_Id == room.Real_type_Id).ToList();
                    if (lists.Count <= 1)
                    {
                        sbtext.Append(" <tr><td>" + GetRealTypeName(room.Real_type_Id) + "</td><td class=\"numbe\">1</td><td>" + room.Room_number + "</td><td>" + room.Real_Price + "</td><td>" + GetRoomStatu(room) + "</td></tr>");
                    }
                    else {
                        for (int i = 0; i < lists.Count; i++)
                        {
                            if (i == 0)
                            {
                                sbtext.Append(" <tr><td rowspan=\"" + lists.Count + "\">" + GetRealTypeName(lists[0].Real_type_Id) + "</td><td class=\"numbe\" rowspan=\"" + lists.Count + "\">" + lists.Count + "</td><td>" + lists[0].Room_number + "</td><td>" + lists[0].Real_Price + "</td><td>" + GetRoomStatu(lists[0]) + "</td></tr>");
                            }
                            else {
                                sbtext.Append(" <tr><td>" + lists[i].Room_number + "</td><td>" + lists[i].Real_Price + "</td><td>" + lists[i].Real_Price + "</td></tr>");
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获得实际费用
        /// </summary>
        /// <param name="statuid"></param>
        /// <returns></returns>
        public string GetRoomStatu(Model.Book_Rdetail model)
        {
            double price = Convert.ToDouble(model.Real_Price);
            double zk = Convert.ToDouble(model.Hourse_scheme_model.hs_Discount) * Convert.ToDouble(0.1);
            return (price * zk).ToString();
        }

        public override void SonLoad()
        {
            id = "Y2015411111326";
            if (Request["id"] != null)
            {
                id = Request["id"].ToString();
                List<Model.book_room> listbr = bllbr.GetModelList("Book_no='" + id + "'");
                if (listbr != null)
                {
                    nowModel = listbr[0];
                    if (Request["desp"] != null)
                    {
                        nowModel.deposit = Convert.ToDecimal(Request["desp"]);
                    }
                }
                Bind();
            }
        }
    }
}