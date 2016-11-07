using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class CzPay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                //string mid = Request.QueryString["mid"];
                //Bind(mid);
            }
        }
        BLL.member bllme = new BLL.member();
        void Bind(string id) {
            Model.member model = bllme.GetModel(id);
            GetSumJf(id.ToString());
            CardNo.Value = model.Mid.ToString();
            CategoryName.InnerText = GetTypeName(Convert.ToInt32(model.Mtype));
            Name.InnerText = model.Name;
            UsableAmount.InnerText = czyue.ToString();
            Amount.Value = Request.QueryString["desp"];
            pwd.Value = model.Pwd;
        }

        protected void btnSave_Click(object sender, EventArgs e) {
            Model.member modelmem= bllme.GetModel(CardNo.Value);
            string password = modelmem.Pwd;
            if (Convert.ToInt32(UsableAmount.InnerText) > 0)
            {
                if (Convert.ToInt32(Amount.Value) - Convert.ToInt32(UsableAmount.InnerText) > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('余额不足！！');parent.window.location.reload();</script>");
                }
                else
                {
                    if (password != pwd.Value)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('密码错误！！');</script>");
                    }
                    else
                    {
                        //Model.mRecords modelrm = new Model.mRecords();
                        //modelrm.Type = 2;
                        //modelrm.mmid = CardNo.Value;
                        //modelrm.Price = Convert.ToInt32(Amount.Value);
                        //modelrm.Remark = "交了压金";
                        //if (bllrm.Add(modelrm) > 0)
                        //{
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'>parent.Window_Close();</script>");
                        //}
                    }
                }
            }
            else {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('余额不足！！');</script>");
            }
        }
        BLL.mRecords bllrm = new BLL.mRecords();
        BLL.mRecords bllmr = new BLL.mRecords();
        private string GetTypeName(int id)
        {
            BLL.memberType bllmt = new BLL.memberType();
            if (id == 0)
            {
                return "";
            }
            return bllmt.GetModel(id).TypeName;
        }

        int sumjf = 0;//总积分
        int duihua = 0;//兑换积分
        int shengyu = 0;//剩余积分
        int dongjie = 0;//冻结积分
        int czsum = 0;//总存储值
        int xfsum = 0;//消费储值
        int czyue = 0;//储值谫
        int xfnum = 0;//消费次数
        int xfall = 0;//消费金额
        #region 获得总积分等等
        /// <summary>
        /// 获得总积分
        /// </summary>
        private void GetSumJf(string mid)
        {
            List<Model.mRecords> listmr = bllmr.GetModelList("mmid='" + mid + "'");
            if (listmr.Count > 0)
            {
                foreach (Model.mRecords model in listmr)
                {
                    if (model.Type == 1) //
                    {
                        czsum += Convert.ToInt32(model.Price);
                    }
                    if (model.Type == 2)
                    {
                        xfsum += Convert.ToInt32(model.Price);
                        xfnum++;
                    }
                    if (model.Type == 3)
                    {
                        sumjf += Convert.ToInt32(model.Price);
                    }
                    if (model.Type == 4)
                    {
                        duihua += Convert.ToInt32(model.Price);
                    }
                }

                czyue = czsum - xfsum;
                shengyu = sumjf - duihua;
            }
        }
        #endregion
    }
}