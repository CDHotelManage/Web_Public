using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CdHotelManage.Web.Admin.customer
{
    public partial class AcountInfos : BasePage
    {

          public int ids
        {

            get { return (int)ViewState["ids"]; }

            set { ViewState["ids"] = value; }

        }
        public string hidids
        {

            get { return (string)ViewState["hidids"]; }

            set { ViewState["hidids"] = value; }

        }
        public string hidid
        {

            get { return (string)ViewState["hidid"]; }

            set { ViewState["hidid"] = value; }

        }
        public string occno
        {

            get { return (string)ViewState["occno"]; }

            set { ViewState["occno"] = value; }

        }
        public string orderid
        {

            get { return (string)ViewState["orderid"]; }

            set { ViewState["orderid"] = value; }

        }
        public string occid
        {

            get { return (string)ViewState["occid"]; }

            set { ViewState["occid"] = value; }

        }
        BLL.meth_pay fmzffs = new BLL.meth_pay();
        BLL.goods_account fmrz = new BLL.goods_account();
        BLL.occu_infor fmOc = new BLL.occu_infor();
        BLL.room_number fmroom = new BLL.room_number();
        BLL.AccountsUsersBLL fmuser = new BLL.AccountsUsersBLL();
  
        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdds_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            string sql = "";
            string Strsql = "";
            int count = 0;
            for (int i = 0; i < GrdCostRoom.Rows.Count; i++)
            {
                CheckBox cbxCheck = GrdCostRoom.Rows[i].FindControl("cbxCheck") as CheckBox;
                if (cbxCheck.Checked)
                {
                    if (cbxCheck.Enabled == true)
                    {
                        HiddenField hidNewsId = GrdCostRoom.Rows[i].FindControl("hidId") as HiddenField;
                        if (occid == "")
                        {
                            occid = hidNewsId.Value;
                        }
                        else
                        {
                            occid += "," + hidNewsId.Value;
                        }

                        sql = " update room_number set Rn_state=4 where Rn_roomNum='" + fmOc.GetModel(Convert.ToInt32(hidNewsId.Value)).room_number + "' ";
                        Helper.AddRoom(fmOc.GetModel(Convert.ToInt32(hidNewsId.Value)).room_number);
                        fmroom.Updates(sql);
                    }
                    count++;
                }
            }

            strSQL = "update occu_infor set state_id=3 where occ_id in (" + occid + ")";
            fmOc.Updates(strSQL);
          
            if (GrdCostRoom.Rows.Count == count)
            {
                Strsql = "update goods_account set ga_sfacount='是' where ga_occuid ='" + fmOc.GetModel(ids).order_id + "' ";
                if (!Helper.IsJz(fmOc.GetModel(ids).order_id))
                {
                string[] txtzffs = txt_zhfsMoney.Value.Split('|');
                if (hidcs.Value == "0")
                {
                    Model.goods_account model = new Model.goods_account();
                    model.ga_people = UserNow.UserID;
                   // model.ga_zffs_id = 1;
                   // model.ga_price = Convert.ToInt32( txt_bcysMoneys.Value);
                    model.ga_price = Convert.ToDecimal("-" + txt_bcysMoneys.Value);
                    model.ga_sfacount = "是";
                    model.ga_name = "结账退款";
                    model.ga_occuid = fmOc.GetModel(ids).order_id;
                    model.ga_sum_price = 0;
                    model.ga_Type = 6;
                    //fmrz.GetMaxId();
                    model.ga_number = System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "");
                    model.ga_date = System.DateTime.Now;
                    model.ga_roomNumber = fmOc.GetModel(ids).room_number.ToString();
                    fmrz.Add(model);

                }
                else if (hidcs.Value == "1")
                
                {

                    for (int j = 0; j < txtzffs.Length - 1; j++)
                    {
                        Model.goods_account model = new Model.goods_account();
                        model.ga_people = UserNow.UserID;
                        model.ga_zffs_id = Convert.ToInt32(txtzffs[j].Split('#')[0]);
                        model.ga_price = Convert.ToDecimal(txtzffs[j].Split('#')[1]);
                        model.ga_sfacount = "是";
                        model.ga_name = "结账收款";
                        model.ga_occuid = fmOc.GetModel(ids).order_id; 
                        model.ga_sum_price =0;
                        model.ga_Type = 4;
                        
                        //fmrz.GetMaxId();
                        model.ga_number = System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "");
                        model.ga_date = System.DateTime.Now;
                        model.ga_roomNumber =fmOc.GetModel(ids).room_number.ToString();
                        fmrz.Add(model);

                    }
                }
                
                    if (fmrz.Updates(Strsql))
                    {
                        // Maticsoft.Common.MessageBox.ShowAndRedirect(this, "！", "");
                        string strqwl = "update occu_infor set tuifaId=2 where occ_id in (" + occid + ")";
                        fmOc.Updates(strqwl);
                        Helper.AddRoom(fmOc.GetModel(ids).room_number);
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>if(confirm('结账成功，是否打结账单')){ PrintJz(this," + orderid + ");}else{ShowTabs('房态图');}</script>");
                    }
                }
                else {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>Erroc();</script>");
                }
            }
            else
            {
             

                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "退房成功！", "");
                string strqwl = "update occu_infor set tuifaId=1,continuelive=1 where occ_id in (" + ids + ")";
                fmOc.Updates(strqwl);
                //ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('退房成功');parent.Window_Close();</script>");

              
            }
        }
        /// <summary>
        /// 绑定支付方式
        /// </summary>
        public void BindZFFS()
        {
            DataSet dt = fmzffs.GetAllList();
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                hid_zfName.Value += dr["meth_pay_id"].ToString() + "," + dr["meth_pay_name"].ToString() + ";";
            }
            DDlZffs.DataSource = fmzffs.GetList("meth_is_ya=1");
            DDlZffs.DataBind();
            this.DDlZffs.Items.RemoveAt(0);

        }
        public void BindInfo()
        {
            Model.occu_infor mod = new Model.occu_infor();
            txt_roomNum.Value = fmOc.GetModel(ids).room_number;
            txtrzDate.InnerText = (fmOc.GetModel(ids).occ_time).ToString();
            txt_name.InnerText = (fmOc.GetModel(ids).occ_name).ToString();
            // txt_rzdate.Value = System.DateTime.Now.ToString();
        }
        /// <summary>
        /// 绑定入账信息
        /// </summary>
        public void BindGv()
        {
            int count = 0;
            double Money = 0;
            double ysMoney = 0;
            DataSet dt = fmrz.GetList(" ga_occuid in ('" + orderid + "')");
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
               
                if (dr["ga_Type"].ToString() == "0")
                {
                    dr["ga_remker"] = "消费（商品入账）";
                }
                if (dr["ga_Type"].ToString() == "1")
                {
                    dr["ga_remker"] = "消费（费用入账）" + "," + dr["ga_remker"].ToString();
                }
                if (dr["ga_Type"].ToString() == "3")
                {
                    dr["ga_remker"] = "续住押金";
                }
                if (dr["ga_Type"].ToString() == "4")
                {
                    dr["ga_remker"] = "结账（入账）";
                }
                if (dr["ga_Type"].ToString() == "5")
                {
                    dr["ga_remker"] = "退款（入账）";
                }
                try
                {
                    Money += double.Parse(dr["ga_price"].ToString());

                    ysMoney += double.Parse(dr["ga_sum_price"].ToString());
                }
                catch { }
                count++;
            }

            txt_xfMoneys.Value = txt_xfMoney.Value = ysMoney.ToString();
            txt_ysMoneys.Value = txt_ysMoney.Value = Money.ToString();
            txt_bcysMoneys.Value = txt_bcysMoney.Value = (double.Parse(txt_xfMoney.Value) - double.Parse(txt_ysMoney.Value)).ToString();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        #region 根据ID转换成中文名
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

        //获得客人来源中文名称

        public string GetSourceTypeName(object id)
        {
            try
            {
                if (id.ToString() == "")
                {
                    return "";
                }
                BLL.guest_source gsbll = new BLL.guest_source();
                Model.guest_source model = gsbll.GetModel(Convert.ToInt32(id.ToString()));
                return model.gs_name;
            }
            catch (Exception)
            {
                return "";
            }


        }

        //获得房间状态中文名称
        public string GetRoomStateName(object id)
        {
            if (id.ToString() == " ")
            {
                return "";
            }
            else
            {
                switch ( Convert.ToInt32(id))
                {
                    case 0:
                        return "在住客人";
                    case 3:
                        return "已退房";
                    case 4:
                        return "挂单客人";
                    default:
                        return "";
                }
            }

        }

       


        #endregion
        /// <summary>
        /// 退房绑定
        /// </summary>
        public void BandTF()
        {
            int count = 0;
            string roomsName = "";
            //and tuifaId in(" + hidid + ") 
            //and tuifaId in(0,1)
            string a = fmOc.GetModel(ids).lordRoomid;
            DataSet dt = fmOc.GetList(" occ_with='否' and order_id='" + orderid + "'  ");
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                if (dr["lordRoomid"].ToString() == dr["room_number"].ToString())
                {
                    dr["lordRoomid"] = "主";
                }
                else 
                {
                    dr["lordRoomid"] = "从";
                }

                if (dr["state_id"].ToString() == "3")
                {
                    dr["mem_cardno"] = "已退房";
                }
                if (dr["state_id"].ToString() == "0")
                {
                    dr["mem_cardno"] = "在住";
                }
                count++;
                //if (hidids == "" ||hidids==null)
                //{
                //    hidids = dr["order_id"].ToString();
                //    //hidid = dr["occ_id"].ToString();
                //}
                //else 
                //{
                //    hidids += "," + dr["order_id"].ToString();
                //   // hidid =","+ dr["occ_id"].ToString();
                //}
                txt_num.InnerText = count.ToString();
                if (roomsName == "")
                {
                    roomsName = dr["room_number"].ToString();
                }
                else 
                {
                    roomsName += "," + dr["room_number"].ToString();
                    
                }
                sboption.Append("<option value='" + dr["room_number"] + "'>" + dr["room_number"] + "</option>");
                roomNumed.InnerText = roomsName;
            }
            if (count > 2)
            {
                btngd.Attributes.Add("display", "block");
               
            }
            GrdCostRoom.DataSource = dt;
            GrdCostRoom.DataBind();
            for (int i = 0; i < GrdCostRoom.Rows.Count; i++)
            {
                CheckBox cbxCheck = GrdCostRoom.Rows[i].FindControl("cbxCheck") as CheckBox;
                HiddenField hidNewsId = GrdCostRoom.Rows[i].FindControl("hidId") as HiddenField;
                if (fmOc.GetModel(Convert.ToInt32(hidNewsId.Value)).state_id == 3 || fmOc.GetModel(Convert.ToInt32(hidNewsId.Value)).state_id == 2)
                {
                    cbxCheck.Enabled = false;
                    cbxCheck.Checked = true;
                }

            }
        }
        protected System.Text.StringBuilder sboption = new System.Text.StringBuilder();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnserch_Click(object sender, EventArgs e)
        {
            BandTF();
            BindGv();
           
        }
        /// <summary>
        /// 挂单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btngd_Click(object sender, EventArgs e)
        {
            string strSQL = "update occu_infor set state_id=4 where occ_id in (" + ids + ")";
            string sql = " update room_number set Rn_state=4 where Rn_roomNum='" + fmOc.GetModel(ids).room_number + "' ";
          //  fmroom.Updates(sql);
            if (fmOc.Updates(strSQL)&& fmroom.Updates(sql)) 
            {
                //Maticsoft.Common.MessageBox.ShowAndRedirect(this, "挂单成功！", "");
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('挂单成功');parent.document.getElementById('btnsercher').click();parent.Window_Close();</script>");

            }
        }
        //获得支付方式
        public string GetKffsName(string id)
        {
            try
            {
                Model.meth_pay model = fmzffs.GetModel(Convert.ToInt32(id.ToString()));
                return model.meth_pay_name;
            }
            catch 
            {
                return "";
            }

        }

        public string GetRoomReal(object id)
        {
            try
            {
                if (id.ToString() == " ")
                {
                    return "";
                }
                else
                {

                    BLL.real_mode rsbll = new BLL.real_mode();
                    Model.real_mode model = rsbll.GetModel(Convert.ToInt32(id.ToString()));
                    return model.real_mode_name;
                }
            }
            catch (Exception ex)
            {
                return "";
            }

        }
        public string GetUserName(string ides) 
        {
            Model.AccountsUsers modes = fmuser.GetModel(ides.ToString());
            return modes.UserName;
        }
        BLL.occu_infor blloc = new BLL.occu_infor();
        BLL.room_number bllrn = new BLL.room_number();
        protected Model.occu_infor prooccmodle = new Model.occu_infor();
        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                //ids = Convert.ToInt32(Request.QueryString["id"]);
                string id = Request.QueryString["id"];
                ids = blloc.GetModelList("order_id='" + id + "'")[0].occ_id;
                txt_hidid.Value = ids.ToString();
                Model.occu_infor modelocc = fmOc.GetModel(ids);
                if (modelocc == null)
                {
                    Model.room_number modelrn = bllrn.GetModel(ids);
                    modelocc = blloc.GetModelList("room_number='" + modelrn.Rn_roomNum + "' and state_id=0")[0];
                }
                prooccmodle = modelocc;
                occno = modelocc.occ_no.ToString();
                orderid = modelocc.order_id.ToString();
                orderids.Value = orderid;
                btnserch_Click(null, null);
                BindZFFS();
                BindInfo();
                occid = "";
                hidids = "";
                txt_id.Value = ids.ToString();
                try
                {
                    txt_ysqje.Value = fmrz.GetModels(" where ga_occuid='" + occno + "'").ga_price.ToString();
                }
                catch
                {
                    txt_ysqje.Value = "0.00";
                }
            }
        }
    }
}
