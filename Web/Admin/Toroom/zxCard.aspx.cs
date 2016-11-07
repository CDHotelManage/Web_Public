using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Runtime.InteropServices;

namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class zxCard : System.Web.UI.Page
    {
        //注销卡片
        [DllImport("proRFL.dll", EntryPoint = "CardErase")]
        public static extern int CardErase(byte aType, int coid, byte[] carddata);

        //蜂鸣器
        [DllImport("proRFL.dll", EntryPoint = "Buzzer")]
        public static extern int Buzzer(byte flagusb, int sc);


        //读卡数据
        [DllImport("proRFL.dll", EntryPoint = "ReadCard")]
        public static extern int ReadCard(byte flagusb, byte[] carddata);

        protected string GetRealModel(int id)
        {
            BLL.real_mode bllrm = new BLL.real_mode();
            return bllrm.GetModel(id).real_mode_name;
        }
        BLL.occu_infor bllocc = new BLL.occu_infor();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                string odrdersid = Request.QueryString["ga_sfacount"];
                hidorder.Value = odrdersid;
                List<Model.occu_infor> listocc = bllocc.GetModelList("order_id='" + odrdersid + "'");
                if (listocc.Count > 0)
                {
                    markTime.InnerText = listocc[0].occ_time.ToString();
                    ydTime.InnerText = listocc[0].depar_time.ToString();
                    hidroom.Value = listocc[0].room_number;
                    name.InnerText = listocc[0].occ_name;
                    Span1.InnerText = GetRealModel(listocc[0].real_mode_id);
                }
            }
        }
        byte flagUSB;
        byte[] carddata = new byte[128];
        protected void btnSave_Click(object sender, EventArgs e) {
            //ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('注销卡片成功！');if(confirm('结账成功，是否打结账单')){ PrintRZ(" + hidorder.Value + ");}else{ShowTabs('房态图');}</script>");
            bool tr;
            int i, st;
            string datastr = "";
            byte[] cardbuf = new byte[128];
            int dlscoid;
            dlscoid = GetHotelBs();//酒店标识
            tr = rdcard();

            if (tr)
            {
                st = CardErase(flagUSB, dlscoid, cardbuf);
                Thread.Sleep(800);//建议延时800毫秒，等待硬件响应
                if (st == 0)
                {
                    if (flagUSB == 1)
                    {
                        Buzzer(flagUSB, 50);
                    }
                    for (i = 0; i < 38; i++)
                        datastr = datastr + ((char)carddata[i]).ToString();
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('注销卡片成功！');if(confirm('结账成功，是否打结账单')){ PrintRZ(" + hidorder.Value + ");}else{ShowTabs('房态图');}</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('注销卡片失败！');if(confirm('结账成功，是否打结账单')){ PrintRZ(" + hidorder.Value + ");}else{ShowTabs('房态图');}</script>");
                }
            }
            else {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('注销卡片失败！');if(confirm('结账成功，是否打结账单')){ PrintRZ(" + hidorder.Value + ");}else{ShowTabs('房态图');}</script>");
            }
        }

        private int GetHotelBs()//获取酒店标识
        {
            bool tr;
            int i = 0;
            string datastr = "";
            string coid = "";
            tr = rdcard();
            if (tr)
            {
                for (i = 0; i < 38; i++)
                    datastr = datastr + ((char)carddata[i]).ToString();
                coid = datastr.Substring(8, 6);
                i = Convert.ToInt32(coid.Substring(0, 2), 16) * 65536 + Convert.ToInt32(coid.Substring(2, 4), 16) % 16383;
                datastr = datastr.Substring(24, 8);
                if (datastr == "FFFFFFFF")
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('此卡为空白卡，请换一张能够开门的卡！');</script>");
                }
            }
            return i;

        }

        public bool rdcard()//判断有效卡片是否存在
        {
            int st, i;
            string datastr = "";
            st = ReadCard(flagUSB, carddata);
            if (st != 0)
            {
                //MessageBox.Show("读卡失败:" + st.ToString());
                return false;

            }
            else
            {
                for (i = 0; i < 6; i++)
                    datastr = datastr + ((char)carddata[i]).ToString();
                if (datastr != "551501")
                {
                    //MessageBox.Show("发卡器感应区没有读到有效卡：" + datastr);
                    return false;
                }
            }
            return true;

        }
    }
}