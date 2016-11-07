using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading;


namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class makecard : BasePage
    {

        //--------------------
        //打开USB
        [DllImport("proRFL.dll", EntryPoint = "initializeUSB")]
        public static extern int initializeUSB(byte aType);
        //蜂鸣器
        [DllImport("proRFL.dll", EntryPoint = "Buzzer")]
        public static extern int Buzzer(byte flagusb, int sc);

        //读DLL版本号
        [DllImport("proRFL.dll", EntryPoint = "GetDLLVersion")]
        public static extern int GetDLLVersion(byte[] aType);
        //读卡数据
        [DllImport("proRFL.dll", EntryPoint = "ReadCard")]
        public static extern int ReadCard(byte flagusb, byte[] carddata);
        //注销卡片
        [DllImport("proRFL.dll", EntryPoint = "CardErase")]
        public static extern int CardErase(byte aType, int coid, byte[] carddata);
        //挂失卡
        //int __stdcall LimitCard(uchar d12,int dlsCoID,uchar CardNo,uchar dai,uchar BDate[10],uchar LCardNo[4],uchar *cardHexStr)

        [DllImport("proRFL.dll", EntryPoint = "LimitCard")]//挂失卡片
        public static extern int LimitCard(byte flagusb, int dlscoid, byte cardno, byte dai, char[] BDate, byte[] LcardNo, byte[] cardbuf);

        //客人卡
        //int __stdcall GuestCard(uchar fUSB,int dlsCoID,uchar CardNo,uchar dai,uchar LLock,uchar pdoors,uchar BDate[10],uchar EDate[10],uchar RoomNo[8],uchar *cardHexStr)
        [DllImport("proRFL.dll", EntryPoint = "GuestCard")]
        public static extern int GuestCard(byte flagusb, int dlscoid, byte cardno, byte dai, byte llock, byte pdoors, char[] BDate, char[] EDate, char[] RoomNo, byte[] cardhexstr);
        //读卡类型
        [DllImport("proRFL.dll", EntryPoint = "GetCardTypeByCardDataStr")]
        public static extern int GetCardTypeByCardDataStr(byte[] carddata, byte[] cardtype);
        //读取客人卡锁号
        //int __stdcall GetGuestLockNoByCardDataStr(int dlsCoID,unsigned char *CardDataStr,unsigned char *LockNo)
        [DllImport("proRFL.dll", EntryPoint = "GetGuestLockNoByCardDataStr")]
        public static extern int GetGuestLockNoByCardDataStr(int dlscoid, byte[] carddata, byte[] lockno);
        //读取客人离店时间
        //int __stdcall GetGuestETimeByCardDataStr(int dlsCoID,unsigned char *CardDataStr,unsigned char *LockNo)
        [DllImport("proRFL.dll", EntryPoint = "GetGuestETimeByCardDataStr")]
        public static extern int GetGuestETimeByCardDataStr(int dlscoid, byte[] carddata, byte[] ETime);

        byte flagUSB;
        byte[] carddata = new byte[128];

        BLL.occu_infor bllocc = new BLL.occu_infor();
        
        BLL.SysParameter bllsys = new BLL.SysParameter();
        Model.SysParamter modelsys = new Model.SysParamter();

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

        private string GetSuoNumber() {
            BLL.SuoRoom bllrn = new BLL.SuoRoom();
            List<Model.SuoRoom> listron = bllrn.GetModelList("RoomNumber='" + hidroom.Value + "'");
            if (listron.Count > 0) {
                return listron[0].SuoMa;
            }
            return "";
        }

        private bool IsBack()
        {
            BLL.SuoSys bllss = new BLL.SuoSys();
            List<Model.SuoSys> listsys = bllss.GetModelList("SuoTypeName='" + modelsys.MarkSuo + "'");
            if (listsys.Count > 0) {
                return listsys[0].IsBackSuo;
            }
            return false;
        }

        protected string GetRealModel(int id) {
            BLL.real_mode bllrm = new BLL.real_mode();
            return bllrm.GetModel(id).real_mode_name;
        }

        private bool IsComm()
        {
            BLL.SuoSys bllss = new BLL.SuoSys();
            List<Model.SuoSys> listsys = bllss.GetModelList("SuoTypeName='" + modelsys.MarkSuo + "'");
            if (listsys.Count > 0)
            {
                return listsys[0].IsComm;
            }
            return false;
        }


        protected void Button3_Click(object sender, EventArgs e) {
            int st;
            st = initializeUSB(flagUSB);
            Thread.Sleep(400);//建议延时400毫秒，等待硬件响应
            if (st != 0)
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('打开USB端口失败!');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('打开USB端口成功!');</script>");

            }
        }

        #region 注销
        /// <summary>
        /// 注销
        /// </summary>
        protected void Zx(object sender, EventArgs e)
        {
            bool tr;
            int i,st;
            string datastr = "";
            byte[] cardbuf = new byte [128];
            int dlscoid;
            dlscoid =GetHotelBs();//酒店标识
            tr = rdcard();
            if (tr)
            {
                st = CardErase(flagUSB,dlscoid,cardbuf);
                Thread.Sleep(800);//建议延时800毫秒，等待硬件响应
                if (st == 0)
                {
                    if (flagUSB == 1)
                    {
                        Buzzer(flagUSB,50);
                    }
                    for (i = 0; i < 38; i++)
                        datastr = datastr + ((char)carddata[i]).ToString();
                  ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('注销卡片成功！');</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('注销卡片失败！');</script>");
                }          

            }
        }
        
        #endregion
        #region 开卡
        /// <summary>
        /// 开卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool tr;
                int i, st;
                int dlscoid;
                byte cardno;
                byte dai;
                byte llock;
                byte pdoors;
                string datastr = "";
                string lockstr, BDatestr, EDatestr;
                byte[] cardbuf = new byte[128];

                char[] roomno = new char[8];
                char[] BDate = new char[10];
                char[] EDate = new char[10];



                lockstr = GetSuoNumber();//锁号
                if (lockstr != "")
                {

                    for (i = 0; i < 8; i++)
                    {
                        roomno[i] = Convert.ToChar(lockstr.Substring(i, 1));
                    }

                    BDatestr = DateTime.Now.ToString("yyMMddHHmm");//发卡时间必须取当前时间
                    for (i = 0; i < 10; i++)
                    {
                        BDate[i] = Convert.ToChar(BDatestr.Substring(i, 1));
                    }

                    // EDatestr = dateTimePicker1.Value.ToString("yyMMdd") + dateTimePicker2.Value.ToString("HHmm");//有效时间
                    EDatestr = Convert.ToDateTime(ydTime.InnerText).ToString("yyMMddHHmm");
                    for (i = 0; i < 10; i++)
                    {
                        EDate[i] = Convert.ToChar(EDatestr.Substring(i, 1));
                    }
                    dlscoid = GetHotelBs();//酒店标识



                    //cardno = Convert.ToByte(cardNumber.Value);  //卡号 0..15循环
                    cardno = Convert.ToByte(0);

                    //dai = Convert.ToByte(textBox4.Text);   //屏蔽前卡标志 0..255递增循环
                    //客人代，0--255，用于后卡覆盖前卡，一般情况下固定为0
                    dai = 0;


                    if (IsBack()) llock = 1;  //开反锁标志
                    else llock = 0;


                    if (IsComm()) pdoors = 1;  //开反锁标志
                    else pdoors = 0;

                    //pdoors = 0;//此参数固定为0；
                    tr = rdcard();
                    if (tr)//制作客人卡
                    {
                        st = GuestCard(flagUSB, dlscoid, cardno, dai, llock, pdoors, BDate, EDate, roomno, cardbuf);
                        Thread.Sleep(800);//建议延时800毫秒，等待硬件响应
                        if (st == 0)
                        {
                            if (flagUSB == 1)
                            {
                                Buzzer(flagUSB, 50);
                            }
                            for (i = 0; i < 38; i++)
                                datastr = datastr + ((char)carddata[i]).ToString();
                            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('发宾客卡成功！');if(confirm('开房成功，是否打印入住单')){PrintRZ(" + hidorder.Value + ");}else{ShowTabs('房态图');}</script>");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('发宾客卡失败1！');if(confirm('开房成功，是否打印入住单')){PrintRZ(" + hidorder.Value + ");}else{ShowTabs('房态图');}</script>");
                        }

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('发宾客卡失败,卡片无效！');if(confirm('开房成功，是否打印入住单')){PrintRZ(" + hidorder.Value + ");}else{ShowTabs('房态图');}</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('请设置该房间锁号！锁号" + lockstr + "!!!!');if(confirm('开房成功，是否打印入住单')){PrintRZ(" + hidorder.Value + ");}else{ShowTabs('房态图');}</script>");
                }
            }
            catch (Exception ex)
            {
                 ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('开卡失败');if(confirm('开房成功，是否打印入住单')){PrintRZ(" + hidorder.Value + ");}else{ShowTabs('房态图');}</script>");
            }
        } 
        #endregion

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

        public override void SonLoad()
        {
            modelsys = bllsys.GetModel(1);
            if (!IsPostBack)
            {
                string odrdersid = Request.QueryString["orders"];
                hidorder.Value = odrdersid;
                List<Model.occu_infor> listocc = bllocc.GetModelList("order_id='" + odrdersid + "'");
                if (listocc.Count > 0)
                {
                    markTime.InnerText = listocc[0].occ_time.ToString();
                    ydTime.InnerText = listocc[0].depar_time.ToString();
                    hidroom.Value = listocc[0].room_number;
                    name.InnerText = listocc[0].occ_name;
                    Span1.InnerText = GetRealName(listocc[0].real_mode_id);
            //         string BDatestr = DateTime.Now.ToString("yyMMddHHmm");//发卡时间必须取当前时间
            //string EDatestr = DateTime.Now.AddDays(1).ToString("yyMMddHHmm");

                    BDate.Value = DateTime.Now.ToString("yyMMddHHmm");//发卡时间必须取当前时间
                    EDate.Value = Convert.ToDateTime(listocc[0].depar_time).ToString("yyMMddHHmm");//结束时间
                    LockNo.Value = GetSuoNumber();//锁号
                    if (IsBack()) LLockHid.Value = "1";  //开反锁标志
                    else LLockHid.Value = "0";

                    if (IsComm()) pdoorsHid.Value = "1";  //开反锁标志
                    else pdoorsHid.Value = "0";
                }
            }
        }


        /// <summary>
        /// 读取开房方式
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetRealName(int id) {
            BLL.real_mode bllrm = new BLL.real_mode();
            return bllrm.GetModel(id).real_mode_name;
        }
    }
}