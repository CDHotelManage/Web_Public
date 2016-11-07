using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace CdHotelManage.Web.Admin.Menus
{
    public partial class Setup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Model.room_state> list = bllrs.GetModelList("room_state_name!='取消'");
            if (list.Count > 0)
            {
                foreach (Model.room_state model in list)
                {
                    sb.Append("<span class='titespan'>" + model.room_state_name + "背景颜色</span><input ids=\"" + model.room_state_id + "\" type=\"text\" style=\"width:100px;\" class=\"color\" value=" + model.Room_color + "/></br>");
                }
            }
            if (!IsPostBack) {
                Bind();
            }
        }

        private void Bind() {
            Model.FtSet modelfs = bllfs.GetModel(1);
            Lwidth.Value = modelfs.Lwidth.ToString();
            Lhieght.Value=modelfs.Lhieght.ToString();
            Lfontf.Value = modelfs.Lfontf;
            Fontsize.Value=modelfs.Fontsize.ToString();
            Lmargin.Value=modelfs.Lmargin.ToString();
            Backcolor.Value=modelfs.Backcolor;
            Bordercolor.Value=modelfs.Bordercolor;
            showType.Checked = modelfs.showType;
            showPrice.Checked = modelfs.showPrice;
            orderLC.Checked=modelfs.orderLC;
            ftNum.Value=modelfs.ftNum.ToString();
            zzShowType.Checked=modelfs.zzShowType;
            zzShowPrice.Checked=modelfs.zzShowPrice;
             showFormTime.Checked=modelfs.showFormTime;
            showLFico.Checked=modelfs.showLFico;
            showBmico.Checked=modelfs.showBmico;
           showyjb.Checked=modelfs.showyjb ;
            showday.Checked=modelfs.showday;
            daynum.Value=modelfs.daynum.ToString();
            showyue.Checked=modelfs.showyue;
            moneyNum.Value=modelfs.moneyNum.ToString();
            showcf.Checked=modelfs.showcf;
            showThem.Checked=modelfs.showThem;
             Themtext.Value=modelfs.Themtext;
             showMember.Checked=modelfs.showMember;
            modelfs.memberText = memberText.Value;
             showXy.Checked=modelfs.showXy;
            showYuli.Checked=modelfs.showYuli;
             yuliDay.Checked=modelfs.yuliDay;
            showDayTime.Checked=modelfs.showDayTime;
            dayNumYl.Value=modelfs.dayNumYl.ToString();
            Showxz.Checked=modelfs.showxz;
            showSf.Checked=modelfs.showSf;
            showYuee.Checked=modelfs.showYuee;
            Showzdftime.Checked=modelfs.Showzdftime;
            Showbooktime.Checked=modelfs.Showbooktime;
            Showzf.Checked=modelfs.Showzf;
            Showlc.Checked=modelfs.Showlc;
            showPeoNum.Checked=modelfs.showPeoNum;
            showRk.Checked=modelfs.showRk;
            showWupi.Checked=modelfs.showWupi;
            Showyz.Checked=modelfs.Showyz ;
            Showmf.Checked=modelfs.Showmf;
             Showzdf.Checked=modelfs.Showzdf;
             numSize.Value = modelfs.numSize.ToString();
             numColor.Value = modelfs.numColor.ToString();
             fxSize.Value = modelfs.fxSize.ToString();
             fxColor.Value = modelfs.fxColor.ToString();
             yueSize.Value = modelfs.yueSize.ToString();
             yueColor.Value = modelfs.yueColor.ToString();
             nameSize.Value = modelfs.nameSize.ToString();
             nameColor.Value = modelfs.nameColor.ToString();
             priceSize.Value = modelfs.priceSize.ToString();
             priceColor.Value = modelfs.priceColor.ToString();
             TotimeSize.Value = modelfs.TotimeSize.ToString();
             TotimeColor.Value = modelfs.TotimeColor.ToString();
             zdSize.Value = modelfs.zdSize.ToString();
             zdColor.Value = modelfs.zdColor.ToString();
             icoColor.Value = modelfs.icoColor.ToString();
             
        }
        protected System.Text.StringBuilder sb = new System.Text.StringBuilder();
        BLL.room_state bllrs = new BLL.room_state();
        BLL.FtSet bllfs = new BLL.FtSet();
        System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOk_Click(object sender, EventArgs e) {
            if (File.Exists(Server.MapPath("~/style/toom.css")))//如果存在文件
            {
                Model.FtSet modelfs = new Model.FtSet();
                modelfs.id = 1;
                modelfs.Lwidth = Convert.ToInt32(Lwidth.Value);
                modelfs.Lhieght = Convert.ToInt32(Lhieght.Value);
                modelfs.Lfontf = Lfontf.Value;
                modelfs.Fontsize = Convert.ToInt32(Fontsize.Value);
                modelfs.Lmargin = Convert.ToInt32(Lmargin.Value);
                modelfs.Backcolor = Backcolor.Value;
                modelfs.Bordercolor = Bordercolor.Value;
                modelfs.showType = Convert.ToBoolean(showType.Checked);
                modelfs.showPrice = Convert.ToBoolean(showPrice.Checked);
                modelfs.orderLC = Convert.ToBoolean(orderLC.Checked);
                modelfs.ftNum = Convert.ToInt32(ftNum.Value);
                modelfs.zzShowType = Convert.ToBoolean(zzShowType.Checked);
                modelfs.zzShowPrice = Convert.ToBoolean(zzShowPrice.Checked);
                modelfs.showFormTime = Convert.ToBoolean(showFormTime.Checked);
                modelfs.showLFico = Convert.ToBoolean(showLFico.Checked);
                modelfs.showBmico = Convert.ToBoolean(showBmico.Checked);
                modelfs.showyjb = Convert.ToBoolean(showyjb.Checked);
                modelfs.showday = Convert.ToBoolean(showday.Checked);
                modelfs.daynum = Convert.ToInt32(daynum.Value);
                modelfs.showyue = Convert.ToBoolean(showyue.Checked);
                modelfs.moneyNum = Convert.ToInt32(moneyNum.Value);
                modelfs.showcf = Convert.ToBoolean(showcf.Checked);
                modelfs.showThem = Convert.ToBoolean(showThem.Checked);
                modelfs.Themtext = Themtext.Value;
                modelfs.showMember = Convert.ToBoolean(showMember.Checked);
                modelfs.memberText = memberText.Value;
                modelfs.showXy = Convert.ToBoolean(showXy.Checked);
                modelfs.showYuli = Convert.ToBoolean(showYuli.Checked);
                modelfs.yuliDay = Convert.ToBoolean(yuliDay.Checked);
                modelfs.showDayTime = Convert.ToBoolean(showDayTime.Checked);
                modelfs.dayNumYl = Convert.ToInt32(dayNumYl.Value);
                modelfs.showxz = Convert.ToBoolean(Showxz.Checked);
                modelfs.showSf = Convert.ToBoolean(showSf.Checked);
                modelfs.showYuee = Convert.ToBoolean(showYuee.Checked);
                modelfs.Showzdftime = Convert.ToBoolean(Showzdftime.Checked);
                modelfs.Showbooktime = Convert.ToBoolean(Showbooktime.Checked);
                modelfs.Showzf = Convert.ToBoolean(Showzf.Checked);
                modelfs.Showlc = Convert.ToBoolean(Showlc.Checked);
                modelfs.showPeoNum = Convert.ToBoolean(showPeoNum.Checked);
                modelfs.showRk = Convert.ToBoolean(showRk.Checked);
                modelfs.showWupi = Convert.ToBoolean(showWupi.Checked);
                modelfs.Showyz = Convert.ToBoolean(Showyz.Checked);
                modelfs.Showmf = Convert.ToBoolean(Showmf.Checked);
                modelfs.Showzdf = Convert.ToBoolean(Showzdf.Checked);
                modelfs.numSize = Convert.ToInt32(numSize.Value);
                modelfs.numColor = numColor.Value;
                modelfs.fxSize = Convert.ToInt32(fxSize.Value);
                modelfs.fxColor = fxColor.Value;
                modelfs.yueSize = Convert.ToInt32(yueSize.Value);
                modelfs.yueColor = yueColor.Value;
                modelfs.nameSize = Convert.ToInt32(nameSize.Value);
                modelfs.nameColor = nameColor.Value;
                modelfs.priceSize = Convert.ToInt32(priceSize.Value);
                modelfs.priceColor = priceColor.Value;
                modelfs.TotimeSize = Convert.ToInt32(TotimeSize.Value);
                modelfs.TotimeColor = TotimeColor.Value;
                modelfs.zdSize = Convert.ToInt32(zdSize.Value);
                modelfs.zdColor = zdColor.Value;
                modelfs.icoColor = Convert.ToInt32(icoColor.Value);
                bllfs.Update(modelfs);
                
                Appe(modelfs);
            }
            else {
                File.Create(MapPath("~/style/toom.css"));//创建该CSS文件
            }
        }

        private void Appe(Model.FtSet modelfs)
        {
            List<Model.room_state> list = bllrs.GetModelList("room_state_name!='取消'");
            File.WriteAllText(Server.MapPath("~/style/toom.css"), "");
            sbtext.Append(".main li{ width:" + modelfs.Lwidth + "px; height:" + modelfs.Lhieght + "px; margin:" + modelfs.Lmargin / 2 + "px; }");
            sbtext.Append(".ycan{background:#" + modelfs.Backcolor + ";font-family:" + modelfs.Lfontf + ";font-size:" + modelfs.Fontsize + ";}");
            sbtext.Append("body .hidli li:hover{border-color: #" + modelfs.Bordercolor + " !important;box-shadow:1px 1px 1px rgba(0, 0, 0, 0.075) inset, 0px 0px 8px #" + modelfs.Bordercolor + ");}");
            /*添加房间颜色的*/
            foreach (Model.room_state item in list)
            {
                sbtext.Append("." + item.Room_suod + "{background:#" + item.Room_color.Trim() + ";}");//将到房
            }
            /*空房显示房间类型*/
            if (!modelfs.showType)
            {
                sbtext.Append(".bgblue .fxhrj{display:none;}");
            }
            else
            {
                sbtext.Append(".bgblue .fxhrj{display:;margin:0;}");
            }
            /*空房显示价格*/
            if (!modelfs.showPrice)
            {
                sbtext.Append(".bgblue .youfu{display:none;}");
            }
            else
            {
                sbtext.Append(".bgblue .youfu{display:;margin:0;}");
            }

            /*住客房显示房间类型*/
            if (!modelfs.zzShowType)
            {
                sbtext.Append(".bgorange .fxhrj{display:none;}");
            }
            else
            {
                sbtext.Append(".bgorange .fxhrj{display:;}");
            }
            /*在住房间显示价格*/
            if (!modelfs.zzShowType)
            {
                sbtext.Append(".bgorange .youfu{display:none;}");
            }
            else
            {
                sbtext.Append(".bgorange .youfu{display:;margin:0;}");
            }

            /*房号的大小和颜色*/
            sbtext.Append(".span01{ font-size:" + modelfs.numSize + "px;color:#" + modelfs.numColor + "}");
            /*房行的大小和颜色*/
            sbtext.Append(".fxhrj{ font-size:" + modelfs.fxSize + "px;color:#" + modelfs.fxColor + "}");
            /*姓名的大小和颜色*/
            sbtext.Append(".zuofu{ font-size:" + modelfs.nameSize + "px;color:#" + modelfs.nameColor + "}");
            /*价格的大小和颜色*/
            sbtext.Append(".youfu{ font-size:" + modelfs.priceSize + "px;color:#" + modelfs.priceColor + "}");
            /*余额的大小和颜色*/
            sbtext.Append(".dayu{ font-size:" + modelfs.yueSize + "px;color:#" + modelfs.yueColor + "}");
            /*图标的大小和颜色*/
            sbtext.Append("body .hidli li img{width:" + modelfs.icoColor + "px;}");
            /*来店时间的大小和颜色*/
            if (!modelfs.showFormTime)
            {
                sbtext.Append(".totime{ display:none;}");
            }
            else
            {
                sbtext.Append(".totime{ display:block; font-size:" + modelfs.TotimeSize + "px;color:#" + modelfs.TotimeColor + ";}");
            }
            /*是否显示联防图标*/
            if (!modelfs.showLFico)
            {
                sbtext.Append(".lfico{display:none;}");
            }
            else
            {
                sbtext.Append(".lfico{display:inline-block;}");
            }
            /*是否显示欠费图标*/
            if (!modelfs.showcf)
            {
                sbtext.Append(".qianfei{display:none;}");
            }
            else
            {
                sbtext.Append(".qianfei{display:inline-block;}");
            }
            /*是否显示续住图标*/
            if (!modelfs.showxz)
            {
                sbtext.Append(".xuzhu{display:none;}");
            }
            else
            {
                sbtext.Append(".xuzhu{display:inline-block;}");
            }
            /*是否显示锁房图标*/
            if (!modelfs.showSf)
            {
                sbtext.Append(".suofang{display:none;}");
            }
            else
            {
                sbtext.Append(".suofang{display:inline-block;}");
            }
            /*是否显示余额*/
            if (!modelfs.showYuee)
            {
                sbtext.Append(".yue1{display:none;}");
            }
            else
            {
                sbtext.Append(".yue1{display:inline-block;}");
            }
            /*是否显示钟点房时间*/
            if (!modelfs.Showzdftime)
            {
                sbtext.Append(".stime{display:none;}");
            }
            else
            {
                sbtext.Append(".stime{display:inline-block;}");
            }
            /*是否显示预到时间*/
            if (!modelfs.Showbooktime)
            {
                sbtext.Append(".yudao{display:none;}");
            }
            else {
                sbtext.Append(".yudao{display:inline-block;}");
            }

            /*lccio*/
            if (!modelfs.showLFico)
            {
                sbtext.Append(".lccio{display:none;}");
            }
            else
            {
                sbtext.Append(".lccio{display:inline-block;}");
            }
            /*lccio*/
            if (!modelfs.showLFico)
            {
                sbtext.Append(".lccio{display:none;}");
            }
            else
            {
                sbtext.Append(".lccio{display:inline-block;}");
            }
            /*是否显示月租房图标*/
            if (!modelfs.Showyz)
            {
                sbtext.Append(".yuezhu{display:none;}");
            }
            else {
                sbtext.Append(".yuezhu{display:inline-block;}");
            }
            /*是否显示免费房*/
            if (!modelfs.Showmf)
            {
                sbtext.Append(".free{display:none;}");
            }
            else
            {
                sbtext.Append(".free{display:inline-block;}");
            }
            /*是否显示钟点房*/
            if (!modelfs.Showzdf)
            {
                sbtext.Append(".zdf{display:none;}");
            }
            else
            {
                sbtext.Append(".zdf{display:inline-block;}");
            }
            File.WriteAllText(Server.MapPath("~/style/toom.css"), sbtext.ToString());
            
        }
    }
}