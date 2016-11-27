using System;
using System.Web;
using System.Collections;
using System.ComponentModel;
using System.Web.SessionState;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.Security;
using LTP.Accounts.Bus;
using System.Collections.Generic;
using Lib.Web;

namespace CdHotelManage.Web 
{
	/// <summary>
	/// Global 的摘要说明。
	/// </summary>
	public class Global : LibWebApplication
    {
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}

        BLL.SysParameter bllsys = new BLL.SysParameter();

        int iHour = 00;
        int iMinute = 00;
        int iSecond = 00;
		protected void Application_Start(Object sender, EventArgs e)
		{
            Model.SysParamter modelsys = bllsys.GetModel(1);
            DateTime dtnow = DateTime.Now;
            DateTime dtstart = Convert.ToDateTime(dtnow.ToString("yyyy-MM-dd")).AddHours(modelsys.YsTime.Hours).AddMinutes(modelsys.YsTime.Minutes).AddSeconds(modelsys.YsTime.Seconds);
            List<Model.goods_account> listga = bllga.GetModelList1("ga_isys=0");
            foreach (Model.goods_account item in listga)
            {
                TimeSpan tso = Convert.ToDateTime(item.ga_date) - Convert.ToDateTime(dtstart);
                if (tso.TotalSeconds < 0) {
                    item.ga_isys = 1;
                    bllga.Update(item);
                }
            }
            NOshow();
           #region 默认蓝
            
            TimeSpan ts = modelsys.YsTime;
            iHour = ts.Hours;
            iMinute = ts.Minutes;
            iSecond = ts.Seconds;

            System.Timers.Timer aTimer = new System.Timers.Timer();

            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(aTimer_Elapsed);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
			Application["1xtop1_bgimage"]="images/top-1.gif"; //顶框背景图片
			Application["1xtop2_bgimage"]="images/top-2.gif"; //顶框背景图片
			Application["1xtop3_bgimage"]="images/top-3.gif"; //顶框背景图片
			Application["1xtop4_bgimage"]="images/top-4.gif"; //顶框背景图片
			Application["1xtop5_bgimage"]="images/top-5.gif"; //顶框背景图片
			Application["1xtopbj_bgimage"]="images/top-bj.gif"; //顶框背景图片
			Application["1xtopbar_bgimage"]="images/topbar_01.jpg"; //顶框工具条背景图片
			Application["1xfirstpage_bgimage"]="images/dbsx_01.gif"; //首页背景图片
			Application["1xforumcolor"]="#f0f4fb";
			Application["1xleft_width"]="204"; //左框架宽度
			Application["1xtree_bgcolor"]="#e3eeff"; //左框架树背景色
			Application["1xleft1_bgimage"]="images/left-1.gif"; 
			Application["1xleft2_bgimage"]="images/left-2.gif"; 
			Application["1xleft3_bgimage"]="images/left-3.gif"; 
			Application["1xleftbj_bgimage"]="images/left-bj.gif"; 
			Application["1xspliter_color"]="#6B7DDE"; //分隔块色
			Application["1xdesktop_bj"]="";//images/right-bj.gif
			Application["1xdesktop_bgimage"]="images/desktop_01.gif";//right.gif
			Application["1xtable_bgcolor"]="#F5F9FF"; //最外层表格背景
			Application["1xtable_bordercolorlight"]="#4F7FC9"; //中层表格亮边框
			Application["1xtable_bordercolordark"]="#D3D8E0"; //中层表格暗边框
			Application["1xtable_titlebgcolor"]="#E3EFFF"; //中层表格标题栏
			Application["1xform_requestcolor"]="#E78A29"; //表单中必填字段*颜色
			Application["1xfirstpage_topimage"]="images/top_01.gif";
			Application["1xfirstpage_bottomimage"]="images/bottom_01.gif";
			Application["1xfirstpage_middleimage"]="images/bg_01.gif";
            #endregion
            base.Application_Start(sender, e);
        }

        void aTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            int intHour = e.SignalTime.Hour;
            int intMinute = e.SignalTime.Minute;
            int intSecond = e.SignalTime.Second;

            // 设置 每天的00：00：00开始执行程序 
            if (intHour == iHour && intMinute == iMinute && intSecond == iSecond)
            {
                ClearCount();
            }
        }
        void ClearCount() {
            //List<Model.goods_account> listga = bllga.GetModelList1("ga_isys=0");
            bllga.Updates("update goods_account set ga_isys=1 where ga_isys=0");
            bllga.Updates("update goods_account set ga_Type=9 where ga_isys=1 and ga_Type=10");
            List<Model.occu_infor> listOci = blloi.GetModelList("state_id=0 and occ_with='否'");
            foreach (Model.occu_infor item in listOci)
            {
                DateTime dtli = Convert.ToDateTime(item.depar_time);
                DateTime dtnow = DateTime.Now;
                int days = dtnow.Day - dtli.Day;
                item.depar_time = dtli.AddDays(days);
                blloi.Update(item);
                
            }
            List<Model.room_number> listrn = bllrn.GetModelList("Rn_state=2");
            if (listrn.Count > 0)
            {
                foreach (Model.room_number modelrn in listrn)
                {
                    modelrn.Rn_state = 7;
                    if (blloi.GetModelList("room_number='" + modelrn.Rn_roomNum + "' and state_id=0").Count > 0)
                    {
                        bllrn.Update(modelrn);
                    }
                    Web.Admin.Helper.AddRoom(modelrn.Rn_roomNum);
                }
            }
            NOshow();
        }
        /*统计NOshow*/
        void NOshow() {
            BLL.book_room bllbr = new BLL.book_room();
            Model.SysParamter modelsys = bllsys.GetModel(1);
            DateTime dtnow = DateTime.Now;
            DateTime dtstart = Convert.ToDateTime(dtnow.ToString("yyyy-MM-dd")).AddHours(modelsys.YsTime.Hours).AddMinutes(modelsys.YsTime.Minutes).AddSeconds(modelsys.YsTime.Seconds);
            List<Model.book_room> listbr = bllbr.GetModelList("Accounts!='' and state_id=1");
            if (listbr.Count > 0) {
                foreach (Model.book_room item in listbr)
                {
                     TimeSpan tso = Convert.ToDateTime(item.time_to) - Convert.ToDateTime(dtstart);
                     if (tso.TotalSeconds < 0) {
                         Model.customer modelcus = bllcuns.GetAccounts(item.Accounts);
                         if (modelcus != null)
                         {
                             modelcus.NoShow += 1;
                             bllcuns.Update(modelcus);
                         }
                     }
                     item.state_id = 4;
                     bllbr.Update(item);
                }
            }
        }

        BLL.customer bllcuns = new BLL.customer();
        BLL.room_number bllrn = new BLL.room_number();
        BLL.goods_account bllga = new BLL.goods_account();
        BLL.occu_infor blloi = new BLL.occu_infor();

		protected void Session_Start(Object sender, EventArgs e)
		{
			Session["Style"]=1;
		}
		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
		}
		protected void Application_EndRequest(Object sender, EventArgs e)
		{
		}
		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
		}
		protected void Application_Error(Object sender, EventArgs e)
		{
			
		}
		protected void Session_End(Object sender, EventArgs e)
		{		
			
		}
		protected void Application_End(Object sender, EventArgs e)
		{
		}
			
		#region Web 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

