using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CdHotelManage.Web.Admin.Menus2
{
    public partial class fjfadefalut : System.Web.UI.Page
    {
        BLL.hourse_scheme fmshif = new BLL.hourse_scheme();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGV();
                BindFX();
                Bind();
            }
        }
        BLL.room_type fxBll = new BLL.room_type();


        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnOk_Click(object sender, EventArgs e) {
            Model.hourse_scheme model = new Model.hourse_scheme();
            model.hs_room = Convert.ToInt32(ddroomtype.SelectedValue);
            model.hs_name = Hs_name.Value;
            model.hs_Discount = hs_Discount.Value;
            model.Hs_isAll = Hs_isAll.Checked;
            model.Hs_Strat = Convert.ToDateTime(Hs_Strat.Value);
            model.Hs_End = Convert.ToDateTime(Hs_End.Value);
            model.Hs_zdr = Convert.ToDecimal(Hs_zdr.Value);
            model.Hs_Reamrk = Hs_Reamrk.Value;
            if (fmshif.Add(model)>0) {
                Response.Write("<script>alert('添加成功');window.location.href='fjfadefalut.aspx'</script>");
            }
        }

        //protected void btn_del_click(object sender, EventArgs e) {
        //    if (fmshif.Delete(Convert.ToInt32(delId.Value))) {
        //        Response.Write("<script>alert('删除成功');window.location.reload();</script>");
        //    }
        //}

        protected void BtnEdit_Click(object sender, EventArgs e) {
            if (hid.Value!= "") {
                Model.hourse_scheme model = new Model.hourse_scheme();
                model.id = Convert.ToInt32(hid.Value);
                model.hs_room = Convert.ToInt32(ddroomtype.SelectedValue);
                model.hs_name = Hs_name.Value;
                model.hs_Discount = hs_Discount.Value;
                model.Hs_isAll = Hs_isAll.Checked;
                model.Hs_Strat = Convert.ToDateTime(Hs_Strat.Value);
                model.Hs_End = Convert.ToDateTime(Hs_End.Value);
                model.Hs_zdr = Convert.ToDecimal(Hs_zdr.Value);
                model.Hs_Reamrk = Hs_Reamrk.Value;
                if (fmshif.Update(model))
                {
                    Response.Write("<script>alert('修改成功');window.location.href='fjfadefalut.aspx'</script>");
                }
            }
        }

        public void Bind() {
            this.rep1.DataSource = fmshif.GetAllList();
            this.rep1.DataBind();
        }
        /// <summary>
        /// 绑定房型
        /// </summary>
        public void BindFX()
        {
            ddroomtype.DataSource = fxBll.GetAllList();

            ddroomtype.DataBind();
        }

        protected string GetIs(bool b) {
            if (b) {
                return "<input type=\"checkbox\" id=\"isAll\" checked=\"checked\"/>";
            }
            return "<input type=\"checkbox\" id=\"isAll\" >";
        }

        protected string GetFxName(string fxid) {
            BLL.room_type bllrt = new BLL.room_type();
            Model.room_type modelrt = bllrt.GetModel(Convert.ToInt32(fxid));
            if (modelrt != null)
            {
                return modelrt.room_name.ToString();
            }
            return "";
        }

        protected string GetFxPrice(string fxid) {
            BLL.room_type bllrt = new BLL.room_type();
            Model.room_type modelrt = bllrt.GetModel(Convert.ToInt32(fxid));
            if (modelrt != null) {
                return Convert.ToDecimal(modelrt.room_listedmoney).ToString("0.##");
            }
            return "";
        }

        /// <summary>
        /// 添加班次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.hourse_scheme modl = new Model.hourse_scheme();
            modl.hs_name = txt_name.Value;
            modl.hs_Discount = txt_zkfa.Value;
            if (fmshif.Add(modl) > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('保存成功！');</script>");


            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('保存失败！');</script>");

            }
            btnSeach_Click(null, null);

        }
        public void BindGV()
        {
            DivHtml.InnerHtml = "";
            string Div = "";

            DataSet dt = fmshif.GetAllList();
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                Div += "<div class='lin'><span>" + dr["hs_name"] + "<span onclick=\"OpenBc(this," + dr["id"].ToString() + ")\" style='padding-top:3px;padding-left:5px;'><img style='width:15px;height:15px;' src=\"../../images/iconbj.png\" /></span> <em onclick=\"BookEancel(" + dr["id"].ToString() + ",0)\">x</em></div>";
            }
            DivHtml.InnerHtml = Div;

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btndelete_Click(object sender, EventArgs e)
        {
            bool Result = fmshif.Delete(Convert.ToInt32(txt_id.Value));

            if (Result)
            {
                txt_name.Value = "";
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('删除成功！');</script>");

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('删除失败！');</script>");
            }
            btnSeach_Click(null, null);
        }

        protected void btnSeach_Click(object sender, EventArgs e)
        {
            BindGV();
        }
    }
}