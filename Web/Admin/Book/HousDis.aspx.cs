using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Book
{
    public partial class HousDis : BasePage
    {
        Model.book_room brModel = new Model.book_room();
        BLL.book_room brBll = new BLL.book_room();
        BLL.guest_source gsBll = new BLL.guest_source();
        BLL.room_type rtBll = new BLL.room_type();
        BLL.meth_pay mpBll = new BLL.meth_pay();
        BLL.Book_Rdetail bllbr = new BLL.Book_Rdetail();
        int id;
        string bookno;
        protected System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
        
        /// <summary>
        /// 绑定详细信息
        /// </summary>
        private void Bind()
        {
            List<Model.Book_Rdetail> lists = bllbr.GetListModel1("Book_no='" + bookno + "'");
            Dictionary<int, string> dic = new Dictionary<int, string>();
            if (lists != null)
            {
                foreach (Model.Book_Rdetail item in lists)
                {
                    if (dic.ContainsKey(item.Real_type_Id))
                    {
                        continue;
                    }
                    dic.Add(item.Real_type_Id, "true");
                    List<Model.Book_Rdetail> list = lists.Where(d => d.Real_type_Id == item.Real_type_Id).ToList();
                    if (list.Count > 1)
                    {
                        //item = lists[0];
                        sbtext.Append("<div class=\"addyd bg_gray paddingdi\"  book_no=" + item.Book_no + " price=" + item.Real_Price + " fangan="+item.Real_Scheme_Id+"><span class=\"typeid\" >房型：</span><span class=\"fx\" typeid=" + item.Real_type_Id + ">" + GetRealTypeName(item.Real_type_Id) + "</span><span>房数：</span><span class=\"fs\" Room_number=" + list.Count + ">" + list.Count + "</span><span>房号：</span><span class=\"oknumber\">" + GetSum(list) + "</span><div class=\"rnumdiv\"><input type=\"text\" class=\"txtFh\"><div class=\"rnumlist\"><ul>" + Getrum(item) + "</ul></div></div><input name=\"分房\"  type=\"button\" value=\"快速分房\"  class=\"button_green\" /></div>");
                    }
                    else
                    {
                        if (item.Room_number== null)
                        {
                            sbtext.Append("<div class=\"addyd bg_gray paddingdi\" book_no=" + item.Book_no + " price=" + item.Real_Price + " fangan=" + item.Real_Scheme_Id + " ><span>房型：</span><span class=\"fx\" typeid=" + item.Real_type_Id + ">" + GetRealTypeName(item.Real_type_Id) + "</span><span>房数：</span><span class=\"fs\">" + item.Real_num + "</span><span>房号：</span><span class=\"oknumber\"></span><div class=\"rnumdiv\"><input type=\"text\" class=\"txtFh\"><div class=\"rnumlist\"><ul>" + Getrum(item) + "</ul></div></div><input name=\"分房\"  type=\"button\" value=\"快速分房\"  class=\"button_green\" /></div>");
                        }
                        else {
                            sbtext.Append("<div class=\"addyd bg_gray paddingdi\" book_no=" + item.Book_no + " price=" + item.Real_Price + " fangan=" + item.Real_Scheme_Id + " ><span>房型：</span><span class=\"fx\" typeid=" + item.Real_type_Id + ">" + GetRealTypeName(item.Real_type_Id) + "</span><span>房数：</span><span class=\"fs\">" + item.Real_num + "</span><span>房号：</span><span class=\"oknumber\"><a class=\"oka\">" + item.Room_number + "</a></span><div class=\"rnumdiv\"><input type=\"text\" class=\"txtFh\"><div class=\"rnumlist\"><ul>" + Getrum(item) + "</ul></div></div><input name=\"分房\"  type=\"button\" value=\"快速分房\"  class=\"button_green\" /></div>");
                        }
                    }
                }
            }
        }

        BLL.room_number bllrn = new BLL.room_number();
        private string Getrum(Model.Book_Rdetail model)
        {
            System.Text.StringBuilder sba1 = new System.Text.StringBuilder();
            List<Model.room_number> listbr = bllrn.GetModelList("Rn_room=" + model.Real_type_Id);
            foreach (var item in listbr)
            {
                sba1.Append("<li>" + item.Rn_roomNum + "</li>");
            }
            return sba1.ToString();
        }

        /// <summary>
        /// 获得已经选择了的房间号
        /// </summary>
        /// <returns></returns>
        private string GetSum(List<Model.Book_Rdetail> list)
        {
            int sum = 0;
            System.Text.StringBuilder sba = new System.Text.StringBuilder();
            foreach (Model.Book_Rdetail model in list)
            {
                if (model.Room_number != null)
                {
                        sba.Append("<a class=\"oka\">" + model.Room_number + "</a>");
                }
            }
            return sba.ToString();
        }

        public void BookShow()
        {
            brModel = brBll.GetModel(Convert.ToInt32(id));
            //预定人
            this.lbname.Text = brModel.book_Name;
            //号码
            this.lbtele.Text = brModel.tele_no;

            //客人来源
            Model.guest_source gsModel = gsBll.GetModel(Convert.ToInt32(brModel.source_id));
            this.lbsource.Text = gsModel.gs_name;

            //房型
            Model.room_type rtModel = rtBll.GetModel(Convert.ToInt32(brModel.real_type_id));

            //可退订金
            this.lbdeposit.Text = (Convert.ToDouble(brModel.deposit)).ToString();

            //来店时间
            this.lbtimeto.Text = brModel.time_to.ToString();

            //离店时间
            this.lbtimefrom.Text = brModel.time_from.ToString();

            //绑定房型下拉

        }

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

        public override void SonLoad()
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    id = Convert.ToInt32(Request.Params["id"]);
                    BookShow();
                }
                if (Request.Params["bookno"] != null && Request.Params["bookno"].Trim() != "")
                {
                    bookno = Request.Params["bookno"].ToString();
                }
                Bind();
            }
        }
    }
}