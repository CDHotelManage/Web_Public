using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdHotelManage.Web.Admin.Menus
{
    public partial class Billing : BasePage
    {
        BLL.SysParameter blls = new BLL.SysParameter();
        BLL.ExceedScheme blles = new BLL.ExceedScheme();
        Model.SysParamter model = null;
        Model.ExceedScheme modelday = new Model.ExceedScheme();
        Model.ExceedScheme modelEarly = new Model.ExceedScheme();

        /// <summary>
        /// 绑定参数
        /// </summary>
        private void Bind()
        {
            CancellMin.Value = model.CancellMin.ToString();
            IsDepost.Checked = model.IsDeposit;
            deposit.Value = model.Deposit.ToString();
            IsEarlyRoom1.Checked = model.IsEarlyRoom;
            EarlyStart.Value = model.EarlyStart.ToString();
            EarlyEnd.Value = model.EarlyEnd.ToString();
            EarlyOutTime.Value = model.EarlyOutTime.ToString();
            EarlyFee.Value = model.EarlyFee.ToString();
            EarlyFeeSel.Value = model.EarlyFeeSel.ToString();
            EarlyFeeTwo.Value = model.EarlyFeeTwo.ToString();
            EarlyOutTimes.Value = model.EarlyOutTimes.ToString();
            //EarlyFeeTwo.SelectedIndex = Convert.ToInt32(model.EarlyFeeTwo);
            DayOutTime.Value = model.DayOutTime.ToString();
            DayFee.SelectedIndex = Convert.ToInt32(model.DayFee);
            DayFeeTwo.Value = model.DayFeeTwo.ToString();
            DayTime.Value = model.DayTime.ToString();
            istype.Checked = model.Istype;
            ysTime.Value = model.YsTime.ToString();
            isOcczf.Checked = model.IsOcczf;
            isCy.Checked = model.IsCy;
            /*凌晨房*/

            GraceTimeEarly.Value = modelEarly.GraceTime.ToString();
            Earlyapart.Value = modelEarly.Earlyapart.ToString();
            EarlyapartAddP.Value = modelEarly.EarlyapartAddP.ToString();
            EarlyInsufficient.Value = modelEarly.EarlyInsufficient.ToString();
            EarlyInExceed.Value = modelEarly.EarlyInExceed.ToString();
            EarlyInAddPri.Value = modelEarly.EarlyInAddPri.ToString();
            GraceTimeEarly.Value = modelEarly.GraceTime.ToString();

            /*天房*/
            GraceTimeDay.Value = modelday.GraceTime.ToString();
            Dayapart.Value = modelday.Earlyapart.ToString();
            DayapartAddP.Value = modelday.EarlyapartAddP.ToString();
            DayInsufficient.Value = modelday.EarlyInsufficient.ToString();
            DayInExceed.Value = modelday.EarlyInExceed.ToString();
            DayInAddPri.Value = modelday.EarlyInAddPri.ToString();
            GraceTimeDay.Value = modelday.GraceTime.ToString();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Model.SysParamter modelsys = new Model.SysParamter();
            modelsys.id = 1;
            modelsys.CancellMin = Convert.ToInt32(CancellMin.Value);
            modelsys.IsDeposit = IsDepost.Checked;
            modelsys.Deposit = Convert.ToDecimal(deposit.Value);
            modelsys.IsEarlyRoom = IsEarlyRoom1.Checked;
            modelsys.EarlyStart = TimeSpan.Parse(EarlyStart.Value);
            modelsys.EarlyEnd = TimeSpan.Parse(EarlyEnd.Value);
            modelsys.EarlyOutTime = TimeSpan.Parse(EarlyOutTime.Value);
            modelsys.EarlyFee = Convert.ToInt32(EarlyFee.Value);
            modelsys.EarlyFeeSel = Convert.ToInt32(EarlyFeeSel.Value);
            modelsys.EarlyFeeTwo = Convert.ToInt32(EarlyFeeTwo.Value);
            modelsys.EarlyOutTimes = TimeSpan.Parse(EarlyOutTimes.Value);
            modelsys.DayOutTime = TimeSpan.Parse(DayOutTime.Value);
            modelsys.DayFee = Convert.ToInt32(DayFee.Value);
            modelsys.DayFeeTwo = TimeSpan.Parse(DayFeeTwo.Value);
            modelsys.DayTime = TimeSpan.Parse(DayTime.Value);
            modelsys.Istype = istype.Checked;
            modelsys.YsTime = TimeSpan.Parse(ysTime.Value);
            modelsys.IsOcczf = isOcczf.Checked;
            modelsys.IsCy = isCy.Checked;
            if (blls.Update(modelsys))
            {
                Model.ExceedScheme modele = new Model.ExceedScheme();
                modele.GraceTime = Convert.ToInt32(GraceTimeEarly.Value);
                modele.TypeRoom = 5;
                modele.Earlyapart = Convert.ToInt32(Earlyapart.Value);
                modele.EarlyapartAddP = Convert.ToInt32(EarlyapartAddP.Value);
                modele.EarlyInsufficient = Convert.ToInt32(EarlyInsufficient.Value);
                modele.EarlyInExceed = Convert.ToInt32(EarlyInExceed.Value);
                modele.EarlyInAddPri = Convert.ToInt32(EarlyInAddPri.Value);
                blles.Update(modele);
                Model.ExceedScheme modeld = new Model.ExceedScheme();
                modeld.GraceTime = Convert.ToInt32(GraceTimeDay.Value);
                modeld.TypeRoom = 1;
                modeld.Earlyapart = Convert.ToInt32(Dayapart.Value);
                modeld.EarlyapartAddP = Convert.ToInt32(DayapartAddP.Value);
                modeld.EarlyInsufficient = Convert.ToInt32(DayInsufficient.Value);
                modeld.EarlyInExceed = Convert.ToInt32(DayInExceed.Value);
                modeld.EarlyInAddPri = Convert.ToInt32(DayInAddPri.Value);
                blles.Update(modeld);
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('更新成功');</script>");
            }
        }

        public override void SonLoad()
        {
            if (!IsPostBack)
            {
                model = blls.GetModel(1);
                modelday = blles.GetModelList("TypeRoom=1")[0];
                modelEarly = blles.GetModelList("TypeRoom=5")[0];
                Bind();
            }
        }
    }
}