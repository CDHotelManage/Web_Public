using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.member
{
    public partial class mAddType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                XqTime.Value = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
                FirstPrice.Value = "0";
                if (Request.QueryString["type"] == "edit")
                {
                    Bind();
                    Btn_mtPrice.Style.Add("display", "block");
                }
                BindMCategory();
            }
        }

        private void BindMCategory() {
             List<Model.memberType> listmt =null;
            if (Request.QueryString["id"]!= null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                listmt = bllmt.GetModelList("MtID!=" + id);
            }
            else {
                listmt = bllmt.GetModelList("");
            }
            MCategory.DataSource = listmt;
            MCategory.DataTextField = "TypeName";
            MCategory.DataValueField = "MtID";
            MCategory.DataBind();
            MCategory.Items.Insert(0, new ListItem("", "0"));
           
        }

        private void Bind() {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Model.memberType modelty= bllmt.GetModel(id);
            mtid.Value = modelty.MtID.ToString();
            Name.Value = modelty.TypeName;
            CardFee.Value = modelty.typePrice.ToString();
            Limitcke.Checked = modelty.Limit;
            Expire.Value = modelty.LimitValue.ToString();
            ScoreChk.Checked = modelty.IntegraIs;
            SEnable2.Checked = modelty.IsConsump;
            Score_1.Checked = modelty.IsFz;
            Score_2.Checked = modelty.IsXf;
            Rule_x.Value = modelty.XfPrice.ToString();
            Rule_y.Value = modelty.XfConsump.ToString();
            SEnable1.Checked = modelty.IsLive;
            ScoreType_x.Value = modelty.LiveNum.ToString();
            ScoreType_y.Value = modelty.LiveConsump.ToString();
            IsAddScore.Checked = modelty.IsTx;
            defaultPrice.Checked = modelty.IsDeaflut;
            UpEnable.Checked = modelty.IsUpgrade;
            UpScore.Value = modelty.ConsumpSum.ToString();
            IsReduceScore.Checked = modelty.IsDeduction;
            RoomMin.Checked = modelty.Isout;
            DayRoomHour.Value = modelty.OutHour.ToString();
            HourRoomMin.Value = modelty.OutZD.ToString();
            FirstPrice.Value = modelty.FirstPrice.ToString();
            ThePrice.Value = modelty.StaPrice.ToString();
            XqTime.Value = modelty.XqTime.ToString();
            machJf.Value = modelty.MachJf.ToString();
            if (modelty.UpLive == 0)
            {
               
            }
            else
            {
                MCategory.SelectedValue = modelty.UpLive.ToString();
            }
        }

        BLL.memberType bllmt = new BLL.memberType();


        protected void BtnSave_Click(object sender, EventArgs e)
        {
            
            Model.memberType modelty = new Model.memberType();
            modelty.TypeName = Name.Value;
            modelty.typePrice = Convert.ToInt32(CardFee.Value);
            modelty.Limit = Limitcke.Checked;
            if (Expire.Value == "")
            {
                modelty.LimitValue = null;
            }
            else
            {
                modelty.LimitValue = Convert.ToInt32(Expire.Value);
            }
            modelty.IntegraIs = ScoreChk.Checked;
            modelty.IsConsump = SEnable2.Checked;
            modelty.IsFz = Score_1.Checked;
            modelty.IsXf = Score_2.Checked;
            if (Rule_x.Value == "")
            {
                modelty.XfPrice = null;
            }
            else
            {
                modelty.XfPrice = Convert.ToInt32(Rule_x.Value);
            }
            if (Rule_y.Value == "")
            {
                modelty.XfConsump = null;
            }
            else
            {
                modelty.XfConsump = Convert.ToInt32(Rule_y.Value);
            }
            modelty.IsLive = SEnable1.Checked;
            if (ScoreType_x.Value == "")
            {
                modelty.LiveNum = null;
            }
            else
            {
                modelty.LiveNum = Convert.ToInt32(ScoreType_x.Value);
            }
            if (ScoreType_y.Value == "")
            {
                modelty.LiveConsump = null;
            }
            else
            {
                modelty.LiveConsump = Convert.ToInt32(ScoreType_y.Value);
            }

            if (machJf.Value == "")
            {
                modelty.MachJf = null;
            }
            else {
                modelty.MachJf = Convert.ToInt32(machJf.Value);
            }

            modelty.UpLive = Convert.ToInt32(MCategory.SelectedValue);
            modelty.IsTx = IsAddScore.Checked;
            modelty.IsDeaflut = defaultPrice.Checked;
            //差一个金额
            modelty.IsUpgrade = UpEnable.Checked;
            if (UpScore.Value == "")
            {
                modelty.ConsumpSum = null;
            }
            else
            {
                modelty.ConsumpSum = Convert.ToInt32(UpScore.Value);
            }
            if (ThePrice.Value == "")
            {
                modelty.StaPrice = null;
            }
            else {
                modelty.StaPrice = Convert.ToInt32(ThePrice.Value);
            }
            modelty.IsDeduction = IsReduceScore.Checked;
            modelty.Isout = RoomMin.Checked;
            if (DayRoomHour.Value == "")
            {
                modelty.OutHour = null;
            }
            else
            {
                modelty.OutHour = Convert.ToInt32(DayRoomHour.Value);
            }
            if (HourRoomMin.Value == "")
            {
                modelty.OutZD = null;
            }
            else
            {
                modelty.OutZD = Convert.ToInt32(HourRoomMin.Value);
            }
            if (FirstPrice.Value == "")
            {
                modelty.FirstPrice = null;
            }
            else
            {
                modelty.FirstPrice = Convert.ToInt32(FirstPrice.Value);
            }
            modelty.XqTime = Convert.ToDateTime(XqTime.Value);
            if (Request.QueryString["type"] == "add")
            {
                int res=bllmt.Add(modelty);
                if (res > 0)
                {
                    BLL.room_type bllrt = new BLL.room_type();
                    List<Model.room_type> listrt = bllrt.GetModelList("");
                    if (listrt.Count > 0) {
                        foreach (Model.room_type item in listrt)
                        {
                            Model.mtPrice modelmt = new Model.mtPrice();
                            modelmt.RoomType = item.id;
                            modelmt.zdPrice = 1;
                            modelmt.Price = Convert.ToInt32(item.room_listedmoney);
                            modelmt.Dayprice = Convert.ToInt32(item.room_listedmoney);
                            modelmt.lcPrice = Convert.ToInt32(item.room_listedmoney);
                            modelmt.MTID = res;
                            BLL.mtPrice bllm = new BLL.mtPrice();
                            bllm.Add(modelmt);
                        }
                    }

                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('保存成功');parent.window.location.reload();</script>");
                }
            }
            else {
                modelty.MtID = Convert.ToInt32(Request.QueryString["id"]);
                if (bllmt.Update(modelty)) {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('修改成功');parent.window.location.reload();</script>");
                }

            }
        }
    }
}