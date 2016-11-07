using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class ajax : System.Web.UI.Page
    {
        BLL.room_state fmft = new BLL.room_state();
        BLL.room_number fhBll = new BLL.room_number();
        BLL.occu_infor fmoc = new BLL.occu_infor();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    string id = Request.QueryString["id"].ToString();
                    string state = Request.QueryString["state"].ToString();
                    string roomNum = Request.QueryString["room"].ToString();
                    Response.Write(GetMenu( Convert.ToInt32(state), Convert.ToInt32(id), roomNum));
                }
            }
        }
        BLL.occu_infor blloc = new BLL.occu_infor();
        protected string GetMenu(int state, int id, string Roomid)
        {
            string FtName = "";
            if (state != 0)
            {
                FtName = fmft.GetModel(state).room_state_name;

            }
            string html = "";
            try
            {
                if (id.ToString() != "")
                {
                    switch (FtName)
                    {
                        case "在住房":
                            string cf=string.Empty;
                            Model.occu_infor modelocc = blloc.GetModel(id);
                           List<Model.occu_infor> listicc = blloc.GetModelList("order_id='" + modelocc.order_id + "'");
                           if (listicc.Count > 1)
                           {
                              cf = GetHtmlDiv("拆分", "onclick=\"ChaFeng(" + id + ")\"");
                           }
                           else
                           {
                               cf = ""; 
                           }
                          
                           html += GetHtmlDiv("结账", "onclick=\"ShowTabs('结账'," + id + ")\"") + GetHtmlDiv("加开房间", "onclick=\"ShowAddRoom('加开房间'," + id + ")\"") + GetHtmlDiv("合并房间", "onclick=\"AddRoom('合并房间'," + id + ")\"") + cf + GetHtmlDiv("商品入账", "onclick=\"GoodsAdds(this," + id + ")\"") + GetHtmlDiv("费用入账", "onclick=\"CostAdds(this," + id + ")\"") + GetHtmlDiv("续住", "onclick=\"ShowTabs1('续住'," + id + ")\"") + GetHtmlDiv("换房", "onclick=\"replaceAdds(this," + id + ")\"") + GetHtmlDiv("修改在住房信息", "onclick=\"ShowTab('修改在住房信息'," + id + ",1)\"") + GetHtmlDiv("撤销在住房", "onclick=\"CheXiao(" + id + ")\"") + GetHtmlDiv("修改房态", "", true);
                            break;
                        case "脏住房":
                             string cf1=string.Empty;
                            Model.occu_infor modelocc1 = blloc.GetModel(id);
                           List<Model.occu_infor> listicc1 = blloc.GetModelList("order_id='" + modelocc1.order_id + "'");
                           if (listicc1.Count > 1)
                           {
                              
                               cf1 = GetHtmlDiv("拆分", "onclick=\"ChaFeng(" + id + ")\"");
                           }
                           else
                           {
                               cf1 = ""; 
                           }
                            
                           html += GetHtmlDiv("结账", "onclick=\"ShowTabs('结账'," + id + ")\"") + GetHtmlDiv("加开房间", "onclick=\"ShowAddRoom('加开房间'," + id + ")\"") + GetHtmlDiv("合并房间", "onclick=\"AddRoom('合并房间'," + id + ")\"") + cf1 + GetHtmlDiv("商品入账", "onclick=\"GoodsAdds(this," + id + ")\"") + GetHtmlDiv("费用入账", "onclick=\"CostAdds(this," + id + ")\"") + GetHtmlDiv("续住", "onclick=\"ShowTabs1('续住'," + id + ")\"") + GetHtmlDiv("换房", "onclick=\"replaceAdds(this," + id + ")\"") + GetHtmlDiv("修改在住房信息", "onclick=\"ShowTab('修改在住房信息'," + id + ",1)\"") + GetHtmlDiv("撤销在住房", "onclick=\"CheXiao(" + id + ")\"") + GetHtmlDiv("修改房态", "", true);

                            break;
                        case "干净房":
                            if (fhBll.GetModelList(" Rn_roomNum='"+Roomid+"'")[0].Room_suod.ToString().Trim() == "是")
                            {
                               
                                html += GetHtmlDiv("修改房态", "", true);
                            }
                            else
                            {
                                
                                html += GetHtmlDiv("开房", "onclick=\"ShowTab('在住房信息'," + id + ",0)\"") + GetHtmlDiv("修改房态", "", true);
                            }
                            break;

                        case "将到房":
                            
                            html += GetHtmlDiv("开房", "onclick=\"ShowTab('在住房信息'," + id + ",0)\"") +GetHtmlDiv("修改房态", "", true);
                            break;

                        case "脏房":
                            if (fhBll.GetModelList(" Rn_roomNum='" + Roomid + "'")[0].Room_suod.ToString().Trim() == "是")
                            {
                              
                                html += GetHtmlDiv("修改房态", "", true);
                            }
                            else
                            {
                                
                                html += GetHtmlDiv("开房", "onclick=\"ShowTab('在住房信息'," + id + ",0)\"") + GetHtmlDiv("修改房态", "", true);
                            }
                            break;
                        case "维修房":
                           
                            html += GetHtmlDiv("查看维修房", "onclick=\"ShowweixiuTabs('查看维修房'," + id + ",2);\"") + GetHtmlDiv("结束维修房", "onclick=\"cds(2," + id + ")\"");
                            break;
                        case "自用房":
                           
                            html += GetHtmlDiv("查看自用房", "onclick=\"ShowweixiuTabs('查看自用房'," + id + ",3)\"") + GetHtmlDiv("结束自用房", "onclick=\"cds(2," + id + ");\"");
                            break;
                        default:
                            html += GetHtmlDiv("修改房态", "", true);
                            break;

                    }
                }
               
            }
            catch
            {

            }
            return html;
        }

        private string GetHtmlDiv(string item,string events) {
            return "<div class=\"menu-item\" " + events + " style=\"height: 20px;\"><div class=\"menu-text\" style=\"height: 20px; line-height: 20px;\">" + item + "</div></div>";
        }

        private string GetHtmlDiv(string item, string events,bool isopen)
        {
            return "<div class=\"menu-item deif\" " + events + " style=\"height: 20px;\"><div class=\"menu-text\" style=\"height: 20px; line-height: 20px;\">" + item + "</div><div class=\"menu-rightarrow\"></div>" + UpdateState() + "</div>";
        }

        public string UpdateState() 
        {
            int state = Convert.ToInt32(Request.QueryString["state"].ToString());
            string roomNums = Request.QueryString["id"].ToString();          
             string FtName = "";
             string ullihtml = "";
             string ids = "";
            if (state != 0)
            {
                FtName = fmft.GetModel(state).room_state_name;

            }
            try
            {
                if (roomNums != "")
                {
                    switch (FtName)
                    {
                        case "在住房":
                             ids = fmoc.GetModel(Convert.ToInt32(roomNums)).room_number;
                             roomNums = fhBll.GetModelList(" Rn_roomNum='"+ids+"'")[0].id.ToString();
                             ullihtml = "<div class=\"menu\" style=\"width:120px;\"><div class=\"menu-line\" style=\"height: 224px;\"></div>" + GetHtmlDiv("设置脏房", "onclick=\"cds(5," + roomNums + ")\"") + "</div>"; 
                            break;

                        case "干净房":
                            if (fhBll.GetModel( Convert.ToInt32( roomNums)).Room_suod.ToString().Trim() == "是")
                            {
                                ullihtml = "<div class=\"menu\" style=\"width:120px;\"><div class=\"menu-line\" style=\"height: 224px;\"></div>" + GetHtmlDiv("解锁", "onclick=\"cds(4," + roomNums + ");\"") + GetHtmlDiv("设置脏房", "onclick=\"cds(0," + roomNums + ");\"") + "</div>";

                            }
                            else
                            {

                              
                                ullihtml = "<div class=\"menu\" style=\"width:120px;\"><div class=\"menu-line\" style=\"height: 224px;\"></div>" + GetHtmlDiv("锁房", " onclick=\"cds(3," + roomNums + ");\"") + GetHtmlDiv("脏房", "onclick=\"cds(0," + roomNums + ");\"") + GetHtmlDiv("维修房", "onclick=\"ShowweixiuTabs('维修原因'," + roomNums + ",0);\"") + GetHtmlDiv("自用房", "onclick=\"ShowweixiuTabs('自用房'," + roomNums + ",1);\"") + "</div>";

                            }

                            break;

                        case "将到房":
                            ullihtml = "<div class=\"menu\" style=\"width:120px;\"><div class=\"menu-line\" style=\"height: 224px;\"></div>" + GetHtmlDiv("设置干净房", "onclick=\"cds(2," + roomNums + ");\"") + "</div>";
                            break;

                        case "脏房":
                            if (fhBll.GetModel(Convert.ToInt32(roomNums)).Room_suod.ToString().Trim() == "是")
                            {
                                ullihtml = "<div class=\"menu\" style=\"width:120px;\"><div class=\"menu-line\" style=\"height: 224px;\"></div>" + GetHtmlDiv("解锁", "onclick=\"cds(4," + roomNums + ");\"") + GetHtmlDiv("设置干净房", "onclick=\"cds(2," + roomNums + ");\"") + "</div>";
                            }
                            else
                            {
                                ullihtml = "<div class=\"menu\" style=\"width:120px;\"><div class=\"menu-line\" style=\"height: 224px;\"></div>" + GetHtmlDiv("锁房", "onclick=\"cds(3," + roomNums + ");\"") + GetHtmlDiv("设置干净房", "onclick=\"cds(2," + roomNums + ");\"") + GetHtmlDiv("自用房", "onclick=\"ShowweixiuTabs('自用房'," + roomNums + ",1);\"") + GetHtmlDiv("维修房", "onclick=\"ShowweixiuTabs('维修原因'," + roomNums + ",0);\"") + "</div>";
                            }
                            break;
                        case "脏住房":
                            ullihtml = "<div class=\"menu\" style=\"width:120px;\"><div class=\"menu-line\" style=\"height: 224px;\"></div>" + GetHtmlDiv("设置干净房", "onclick=\"cds(6," + roomNums + ");\"") + "</div>";
                            break;
                        default:
                            break;

                    }
                }
                
            }
            catch { }

            return ullihtml;
        }

    
    }
}