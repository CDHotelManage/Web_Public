using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Data;

namespace CdHotelManage.Web.Admin
{
    public abstract class BasePage:System.Web.UI.Page,System.Web.SessionState.IRequiresSessionState
    {
        Model.AccountsUsers userNow = null;
        public Model.AccountsUsers UserNow
        {
            get
            {
                //if (userNow == null)
                //{
                //    userNow = Session["User"] as Model.AccountsUsers;
                //}
                return userNow;
            }
            set { userNow = value; }
        }

        BLL.print bllp = new BLL.print();

        private List<Model.print> listPrint = null;
        public List<Model.print> ListPrint
        {
            get { return bllp.GetModelList(""); }
        }
        BLL.infos bllif = new BLL.infos();
        BLL.shopInfo bllsi = new BLL.shopInfo();
        Model.shopInfo modelsi = new Model.shopInfo();

        public Model.shopInfo Modelsi
        {
            get { return modelsi; }
            set { modelsi = value; }
        }

        public List<Model.occu_infor> ListOcc { get; set; }

        BLL.occu_infor fmmx = new BLL.occu_infor();
        BLL.room_number brbll = new BLL.room_number();
        Dictionary<string, string> dicstr = new Dictionary<string, string>();
        Dictionary<string, string> dicCz = new Dictionary<string, string>();
        string str1 = string.Empty;
        BLL.goods_account bllga = new BLL.goods_account();
        BLL.FtSet bllfs = new BLL.FtSet();
        DataSet dstable = new DataSet();
        /// <summary>
        /// 绑定是否催帐
        /// </summary>
        private void Bind() {
            try
            {
                Model.FtSet modelfs = bllfs.GetModel(1);
                DataSet dts = brbll.GetList("Rn_state in(2,7)");
                foreach (DataRow drs in dts.Tables[0].Rows)
                {
                    string a = drs["Rn_roomNum"].ToString();
                    Model.occu_infor modelocc = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + a + "'");
                    if (modelocc != null)
                    {
                        str1 = "state_id=0 and u.sa < " + modelocc.real_price + " and";
                        if (modelfs.showday)
                        {
                            str1 = "state_id=0 and u.sa < " + Convert.ToInt32(modelfs.daynum) * modelocc.real_price + " and";
                        }
                        else
                        {
                            str1 = "";
                        }
                        if (modelfs.showyue)
                        {
                            str1 += " u.sa<" + modelfs.moneyNum + " and";
                        }
                        dstable = brbll.GetProc(str1, 5, a, DateTime.Now.ToString());
                        //dstable = brBll.GetListed("", "inner join( select * from occu_infor as oi inner join (select SUM(ga_price)-SUM(ga_sum_price) as sa,ga_occuid as t from goods_account where ga_isys=1  group by ga_occuid) as u on u.t =oi.order_id where " + str1 + " datediff(D,[depar_time],'" + DateTime.Now.ToString() + "')=0) as uio on uio.room_number=a.Rn_roomNum and  Rn_floor=" + dr["floor_id"].ToString() + " and room_number='" + a + "'");
                        if (dstable.Tables[0].Rows.Count > 0)
                        {
                            if (!dicCz.ContainsKey(a))
                            {
                                dicCz.Add(a, "1");
                            }
                        }
                    }
                }
                Session["iscz"] = dicCz;
            }
            catch (Exception ex)
            {
                
                throw;
            }
           
        }

        private void Bind2() {
            int index = 0;
            ListOcc = fmmx.GetModelList("occ_with='否' and state_id=0");
            if (ListOcc.Count > 0)
            {


                foreach (Model.occu_infor item in ListOcc)
                {
                    List<Model.occu_infor> listocc1 = fmmx.GetModelList("order_id='" + fmmx.GetModels(" where occ_with='否' and occ_no!='' and state_id=0 and room_number='" + item.room_number + "'").order_id + "' and occ_no!='' and state_id=0");
                    if (listocc1.Count > 1)
                    {
                        if (dicstr.ContainsKey(item.room_number.ToString()))
                        { //如果包含
                            //LFimg = dicstr[drs["Rn_roomNum"].ToString()];
                        }
                        else
                        {
                            index++;
                            foreach (Model.occu_infor i1 in listocc1)
                            {
                                if (!dicstr.ContainsKey(i1.room_number))
                                {
                                    dicstr.Add(i1.room_number, "<img src='/admin/images/" + index + ".png' />");
                                }
                            }
                        }
                    }
                }
            }
            Session["dic"] = dicstr;
        }

        /// <summary>
        /// 验证方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e) {
            string url = Request.Url.ToString();
            try
            {
                Thread t = new Thread(new ThreadStart(Bind));
                Thread t1 = new Thread(new ThreadStart(Bind2));
                t.Start();
                t1.Start();
                t.Join();
                t1.Join();
            }
            catch (Exception ex)
            {

                throw;
            }
            

            List<Model.shopInfo> listif = bllsi.GetModelList("");
            if (listif.Count > 0) {
                modelsi = listif[0];
            }
            if ( Request.Cookies["User"] == null)
            {
                //Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('您还没有登录！');window.location='/Admin/login.aspx';</script>");
                Response.Write("<script>alert('您还没有登录!');window.location='/Admin/login.aspx';</*script>");
                Response.End();
            }
            else {
                //Session["User"] = UserNow;
                string uid=Request.Cookies["User"].Value;
                UserNow = bllu.GetModel(uid);
            }
            SonLoad();
        }
        BLL.AccountsUsersBLL bllu = new BLL.AccountsUsersBLL();
        public abstract void SonLoad();
    }
}