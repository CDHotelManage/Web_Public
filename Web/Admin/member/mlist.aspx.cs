using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.IO;

namespace CdHotelManage.Web.Admin.member
{
    public partial class mlist :BasePage
    {
        protected System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
        BLL.member bllm = new BLL.member();
        protected string name = string.Empty;
        
        BLL.memberType bllmt = new BLL.memberType();
        private void BindType(int typeid) {
            List<Model.memberType> listmt = bllmt.GetModelList("");
            foreach (Model.memberType item in listmt)
            {
                if (item.MtID == typeid)
                {
                    sbtext.Append("<li class=\"select\" ><span onclick='Loc(" + item.MtID + ")'>" + item.TypeName + "</span><em class=\"edit\" onclick=\"editType(this," + item.MtID + ")\"></em><em class=\"dell\" onclick='Del("+item.MtID+")'></em></li>");
                }
                else
                {
                    sbtext.Append("<li class=\"\" ><span onclick='Loc(" + item.MtID + ")'>" + item.TypeName + "</span><em class=\"edit\" onclick=\"editType(this," + item.MtID + ")\"></em><em class=\"dell\" onclick='Del(" + item.MtID + ")'></em></li>");
                }
            }
        }
        protected string GetState(int id)
        {
            BLL.memberState bllms = new BLL.memberState();
            Model.memberState models = bllms.GetModel(id);
            if (models != null)
            {
                return models.title;
            }
            return "";
        }

        private void BindInfo(int typeid) {
            string where = string.Empty;
            string s = Members.Value;
            string num = Days.Value;
            string str = "and Mid like '%" + s + "%' or Name like '%" + s + "%' or Phone like '%" + s + "%'";
            if (s == "") {
                str = string.Empty;
            }
            if (Status.SelectedValue != "-1") {
                where = "and Statid=" + Status.SelectedValue + "";
            }
            if (typeid != 0)
            {
                if (num != "")
                {
                    rep1.DataSource = bllm.GetList("Mtype=" + typeid + "" + where + " " + str + " and (MONTH(Baithday) = MONTH(GetDate())) AND  (DAY(Baithday) BETWEEN DAY(GetDate()) AND DAY(Getdate()) +" + num + ")");
                }
                else {
                    rep1.DataSource = bllm.GetList("Mtype=" + typeid + "" + where + " " + str + "");
                }
                
            }
            else
            {

                if (num != "")
                {
                    rep1.DataSource = bllm.GetList("Mtype!=0 " + where + " " + str + " and (MONTH(Baithday) = MONTH(GetDate())) AND  (DAY(Baithday) BETWEEN DAY(GetDate()) AND DAY(Getdate()) +" + num + ")");
                }
                else {
                    rep1.DataSource = bllm.GetList("Mtype!=0 " + where + " " + str + "");
                }
            }
            rep1.DataBind();
        }
        
        protected string BindCate(int id) {
            Model.memberType model = bllmt.GetModel(id);
            if (model != null) {
                return model.TypeName;
            }
            return "";
        }

        protected string Sex(bool b) {
            if (b) {
                return "女";
             }
            return "男";
        }



        BLL.card_type bllct = new BLL.card_type();
        protected string Zj(int id)
        {
            Model.card_type model = bllct.GetModel(id);
            if (model != null)
            {
                return model.ct_name;
            }
            return "";
        }

        BLL.mRecords bllmr = new BLL.mRecords();
        protected string GetJf(string id) {
            int jf = 0;
            List<Model.mRecords> listmr = bllmr.GetModelList("mmid='" + id + "' and Type=3 or Type=4 and mmid='" + id+"'");
            if (listmr.Count > 0) {
                foreach (Model.mRecords model in listmr)
                {
                    if (model.Type == 3)
                    {
                        jf += Convert.ToInt32(model.Price);
                    }
                    else {
                        jf -= Convert.ToInt32(model.Price);
                    }
                }
            }
            return jf.ToString();
        }

        protected string GetYue(string id)
        {
            int jf = 0;
            List<Model.mRecords> listmr = bllmr.GetModelList("mmid='" + id + "' and Type=1 or Type=2 and mmid='" + id+"'");
            if (listmr.Count > 0)
            {
                foreach (Model.mRecords model in listmr)
                {
                    if (model.Type == 1)
                    {
                        jf += Convert.ToInt32(model.Price);
                    }
                    else {
                        jf -= Convert.ToInt32(model.Price);
                    }
                }
            }
            return jf.ToString();
        }



        public override void SonLoad()
        {
           // 
          int typeid = 0;
          if (Request.QueryString["typeid"] != null)
          {
              typeid = Convert.ToInt32(Request.QueryString["typeid"]);
          }
          BindType(typeid);
            if (!IsPostBack) {
                BindState();
                
                BindInfo(typeid);
                
            }
        }

        protected void btnQuery_click(object sender, EventArgs e) {
            BindInfo(0);
        }

        private void BindState() {
            BLL.memberState bllsta = new BLL.memberState();
            Status.DataSource = bllsta.GetModelList("");
            Status.DataTextField = "title";
            Status.DataValueField = "msID";
            Status.DataBind();
            Status.Items.Insert(0, new ListItem("全部", "-1"));
        }

        BLL.AccountsUsersBLL blluser = new BLL.AccountsUsersBLL();
        protected string GetName(string id) {
            Model.AccountsUsers model = blluser.GetModel(id);
            return model.UserName;
        }

        protected void MemberExport_Click(object sender, EventArgs e) {
            int typeid = 0;
            if (Request.QueryString["typeid"] != null)
            {
                typeid = Convert.ToInt32(Request.QueryString["typeid"]);
            }
            string where = string.Empty;
            string s = Members.Value;
            string num = Days.Value;
            DataSet ds = new DataSet();
            string str = "and Mid like '%" + s + "%' or Name like '%" + s + "%' or Phone like '%" + s + "%'";
            if (s == "")
            {
                str = string.Empty;
            }
            if (Status.SelectedValue != "-1")
            {
                where = "and Statid=" + Status.SelectedValue + "";
            }
            if (typeid != 0)
            {
                if (num != "")
                {
                    ds = bllm.GetList("Mtype=" + typeid + "" + where + " " + str + " and (MONTH(Baithday) = MONTH(GetDate())) AND  (DAY(Baithday) BETWEEN DAY(GetDate()) AND DAY(Getdate()) +" + num + ")");
                }
                else
                {
                    ds = bllm.GetList("Mtype=" + typeid + "" + where + " " + str + "");
                }

            }
            else
            {

                if (num != "")
                {
                    ds = bllm.GetList("Mtype!=0 " + where + " " + str + " and (MONTH(Baithday) = MONTH(GetDate())) AND  (DAY(Baithday) BETWEEN DAY(GetDate()) AND DAY(Getdate()) +" + num + ")");
                }
                else
                {
                    ds = bllm.GetList("Mtype!=0 " + where + " " + str + "");
                }
            }
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Charset = "utf-7";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-7");

                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                StringWriter stringWrite = new StringWriter();
                HttpContext.Current.Response.Write(hidtable.Value.ToString());
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("111", System.Text.Encoding.UTF8) + ".xls");
                HttpContext.Current.Response.Charset = "gb2312";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                HttpContext.Current.Response.End();
            }
            catch
            {
            }
        }

        public void ToExcel(System.Web.UI.Control ctl)
        {
            
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=Excel.xls");
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
            HttpContext.Current.Response.ContentType = "application/ms-excel";//image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword 
            //ctl.Page.EnableViewState = false;
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            ctl.RenderControl(hw);
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();
        }
        protected string GetMenu(int state,string mid) {
            if (state == 0) {
                return "<a href=\"#\" onclick=\"MemberCardType(this,'"+mid+"')\">编辑</a>";
            }
            else if (state == 2) {
                return "<a href=\"#\" onclick=\"Find(this,'" + mid + "')\">找回</a>";
            }
            else if (state == 4)
            {
                return "";
            }
            else {
                return "<a href=\"#\" onclick=\"MemberCardType(this,'')\">编辑</a>";
            }
        }
    }
}