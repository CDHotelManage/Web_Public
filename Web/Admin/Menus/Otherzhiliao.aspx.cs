using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
namespace CdHotelManage.Web.Admin.Menus
{
    public partial class Otherzhiliao : System.Web.UI.Page
    {
        BLL.card_type fmcdtype = new BLL.card_type();//证件类型
        BLL.guest_source fmgeust = new BLL.guest_source();//客人来源表
        BLL.meth_pay fmmety = new BLL.meth_pay();//支付方式
        BLL.hourse_scheme fmroom = new BLL.hourse_scheme();//房价方案
        BLL.comm_unit fmunit = new BLL.comm_unit();//商品单位
        BLL.room_feature fmfea = new BLL.room_feature();//房间特征
        protected StringBuilder sbHtml = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                btnSercher_Click(null, null);
            }
        }
        /// <summary>
        /// 绑定信息
        /// </summary>
        public void BindGv()
        {
            DivHtml.InnerHtml = "";
            string Div = "";
            DataSet dt = null;

            if (txt_type.Value == "0")
            {
                dt = fmgeust.GetAllList();
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    Div += "<div class='lin'><span>" + dr["gs_name"] + "</span> <em onclick=\"BookEancel("+dr["id"].ToString()+",0)\">x</em></div>";
                }

            }
            if (txt_type.Value == "1")
            {
                dt = fmunit.GetAllList();
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    Div += "<div class='lin'><span>" + dr["unit_name"] + "</span> <em onclick=\"BookEancel(" + dr["id"].ToString() + ",1)\">x</em></div>";
                }

            }
            if (txt_type.Value == "2")
            {
                dt = fmfea.GetAllList();
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    Div += "<div class='lin'><span>" + dr["room_feature_name"] + "</span> <em onclick=\"BookEancel(" + dr["room_feature_id"].ToString() + ",2)\">x</em></div>";
                }

            }
            if (txt_type.Value == "3")
            {
                dt = fmmety.GetAllList();
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    Div += "<div class='lin'><span>" + dr["meth_pay_name"] + "</span> <em onclick=\"BookEancel(" + dr["meth_pay_id"].ToString() + ",3)\">x</em></div>";
                }
            }
            if (txt_type.Value == "4")
            {
                dt = fmcdtype.GetAllList();
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    Div += "<div class='lin'><span>" + dr["ct_name"] + "</span> <em onclick=\"BookEancel(" + dr["id"].ToString() + ",4)\">x</em></div>";
                }
            }
            if (txt_type.Value == "5")
            {
                dt = fmroom.GetAllList();
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    Div += "<div class='lin'><span>" + dr["hs_name"] + "</span> <em onclick=\"BookEancel(" + dr["id"].ToString() + ",5)\">x</em></div>";
                }
            }

            if (txt_type.Value == "7")//客户状态
            {
                BLL.customerState bllcs = new BLL.customerState();
                dt = bllcs.GetAllList();
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    Div += "<div class='lin'><span>" + dr["csName"] + "</span> <em onclick=\"BookEancel(" + dr["id"].ToString() + ",5)\">x</em></div>";
                }
            }

            if (txt_type.Value == "8")//客户类型
            {
                BLL.customerType bllct = new BLL.customerType();
                dt = bllct.GetAllList();
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    Div += "<div class='lin'><span>" + dr["ctName"] + "</span> <em onclick=\"BookEancel(" + dr["id"].ToString() + ",5)\">x</em></div>";
                }
            }


            if (txt_type.Value == "9")//客户行业
            {
                BLL.cIndustry bllci = new BLL.cIndustry();
                dt = bllci.GetAllList();
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    Div += "<div class='lin'><span>" + dr["IndustryName"] + "</span> <em onclick=\"BookEancel(" + dr["id"].ToString() + ",5)\">x</em></div>";
                }
            }


            if (txt_type.Value == "10")//协议项目类型
            {
                BLL.cpType bllct = new BLL.cpType();
                dt = bllct.GetAllList();
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    Div += "<div class='lin'><span>" + dr["ptName"] + "</span> <em onclick=\"BookEancel(" + dr["id"].ToString() + ",5)\">x</em></div>";
                }
            }
            if (txt_type.Value == "11")//系统类型
            {
                BLL.csysType bllcts = new BLL.csysType();
                dt = bllcts.GetAllList();
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    Div += "<div class='lin'><span>" + dr["stName"] + "</span> <em onclick=\"BookEancel(" + dr["id"].ToString() + ",5)\">x</em></div>";
                }
            }
            if (txt_type.Value == "12")//部门
            {
                BLL.cDepartment bllcts = new BLL.cDepartment();
                dt = bllcts.GetAllList();
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    Div += "<div class='lin'><span>" + dr["cDName"] + "</span> <em onclick=\"BookEancel(" + dr["id"].ToString() + ",5)\">x</em></div>";
                }
            }
            if (txt_type.Value == "13")//职务
            {
                BLL.cPost bllcts = new BLL.cPost();
                dt = bllcts.GetAllList();
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    Div += "<div class='lin'><span>" + dr["cpName"] + "</span> <em onclick=\"BookEancel(" + dr["id"].ToString() + ",5)\">x</em></div>";
                }
            }
            if (txt_type.Value == "14")//称呼
            {
                BLL.cCall bllcts = new BLL.cCall();
                dt = bllcts.GetAllList();
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    Div += "<div class='lin'><span>" + dr["callName"] + "</span> <em onclick=\"BookEancel(" + dr["id"].ToString() + ",5)\">x</em></div>";
                }
            }

            DivHtml.InnerHtml = Div;
        }
        /// <summary>
        /// 添加其他资料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int Result = 0;
            Model.guest_source fm = new Model.guest_source();
            Model.meth_pay fpay = new Model.meth_pay();
            Model.card_type fmtype = new Model.card_type();
            Model.hourse_scheme fmsc = new Model.hourse_scheme();
            Model.comm_unit fmcom = new Model.comm_unit();
            Model.room_feature fmture = new Model.room_feature();
            if (txt_type.Value == "0")
            {
             
                fm.gs_name = txt_name.Value;
                Result=fmgeust.Add(fm) ;
            }
            if (txt_type.Value == "1") 
            {
                fmcom.unit_name = txt_name.Value;
                Result = fmunit.Add(fmcom);
            }
            if (txt_type.Value == "2")
            {
                fmture.room_feature_name = txt_name.Value;
                Result = fmfea.Add(fmture);
            }
            if (txt_type.Value == "3")
            {
                fpay.meth_pay_name = txt_name.Value;
                Result = fmmety.Add(fpay);
            }
            if (txt_type.Value == "4")
            {
                fmtype.ct_name = txt_name.Value;
                Result = fmcdtype.Add(fmtype);
            }
            if (txt_type.Value == "5")
            {
                fmsc.hs_name = txt_name.Value;
                Result= fmroom.Add(fmsc);
            }
            if (txt_type.Value == "6")
            {

            }
            if (txt_type.Value == "7")
            {
                BLL.customerState bllcs = new BLL.customerState();
                Model.customerState model = new Model.customerState();
                model.csName = txt_name.Value;
                Result = bllcs.Add(model);
            }
            if (txt_type.Value == "8")
            {
                BLL.customerType bllcs = new BLL.customerType();
                Model.customerType model = new Model.customerType();
                model.ctName = txt_name.Value;
                Result = bllcs.Add(model);
            }
            if (txt_type.Value == "9")
            {
                BLL.cIndustry bllcs = new BLL.cIndustry();
                Model.cIndustry model = new Model.cIndustry();
                model.csName = txt_name.Value;
                Result = bllcs.Add(model);
            }
            if (txt_type.Value == "10")
            {
                BLL.cpType bllcs = new BLL.cpType();
                Model.cpType model = new Model.cpType();
                model.ptName = txt_name.Value;
                Result = bllcs.Add(model);
            }
            if (txt_type.Value == "11")
            {
                BLL.csysType bllcs = new BLL.csysType();
                Model.csysType model = new Model.csysType();
                model.stName = txt_name.Value;
                Result = bllcs.Add(model);
            }
            if (txt_type.Value == "12")
            {
                BLL.cDepartment bllcs = new BLL.cDepartment();
                Model.cDepartment model = new Model.cDepartment();
                model.cDName = txt_name.Value;
                Result = bllcs.Add(model);
            }
            if (txt_type.Value == "13")
            {

                BLL.cPost bllcs = new BLL.cPost();
                Model.cPost model = new Model.cPost();
                model.cpName = txt_name.Value;
                Result = bllcs.Add(model);
            }
            if (txt_type.Value == "14")
            {
                BLL.cCall bllcs = new BLL.cCall();
                Model.cCall model = new Model.cCall();
                model.callName = txt_name.Value;
                Result = bllcs.Add(model);
            }
            if (Result>0)
            {
                txt_name.Value = "";
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "alert('保存成功');", true);
               
            }
            else 
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "alert('保存失败');", true);
            }
            btnSercher_Click(null,null);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSercher_Click(object sender, EventArgs e)
        {
            BindGv();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btndelete_Click(object sender, EventArgs e)
        {
            bool Result=false;
            if (txt_types.Value == "0")
            {
                Result = fmgeust.Delete(Convert.ToInt32(txt_id.Value));
               
            }
            if (txt_types.Value == "1")
            {
                Result = fmunit.Delete(Convert.ToInt32(txt_id.Value));
            }
            if (txt_types.Value == "2")
            {
                Result = fmfea.Delete(Convert.ToInt32(txt_id.Value));
            }
            if (txt_types.Value == "3")
            {
                Result = fmmety.Delete(Convert.ToInt32(txt_id.Value));
            }
            if (txt_types.Value == "4")
            {
                Result = fmcdtype.Delete(Convert.ToInt32(txt_id.Value));
            }
            if (txt_types.Value == "5")
            {
                Result = fmroom.Delete(Convert.ToInt32(txt_id.Value));
            }
            if (txt_types.Value == "6")
            {

            }

            if (txt_types.Value == "7")
            {
                BLL.customerState bllcs = new BLL.customerState();
                Result = bllcs.Delete(Convert.ToInt32(txt_id.Value));
            }
            if (txt_types.Value == "8")
            {
                BLL.customerType bllcs = new BLL.customerType();
                Result = bllcs.Delete(Convert.ToInt32(txt_id.Value));
            }
            if (txt_type.Value == "9")
            {
                BLL.cIndustry bllcs = new BLL.cIndustry();
                Result = bllcs.Delete(Convert.ToInt32(txt_id.Value));
            }
            if (txt_type.Value == "10")
            {
                BLL.cpType bllcs = new BLL.cpType();
                Result = bllcs.Delete(Convert.ToInt32(txt_id.Value));
            }
            if (txt_type.Value == "11")
            {
                BLL.csysType bllcs = new BLL.csysType();
                Result = bllcs.Delete(Convert.ToInt32(txt_id.Value));
            }
            if (txt_type.Value == "12")
            {
                BLL.cDepartment bllcs = new BLL.cDepartment();
                Result = bllcs.Delete(Convert.ToInt32(txt_id.Value));
            }
            if (txt_type.Value == "13")
            {

                BLL.cPost bllcs = new BLL.cPost();
                Result = bllcs.Delete(Convert.ToInt32(txt_id.Value));
            }
            if (txt_type.Value == "14")
            {
                BLL.cCall bllcs = new BLL.cCall();
                Result = bllcs.Delete(Convert.ToInt32(txt_id.Value));
            }
            if (Result)
            {
                txt_name.Value = "";
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "alert('删除成功');", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "click", "alert('删除失败');", true);
            }
            btnSercher_Click(null, null);
        }
    }
}