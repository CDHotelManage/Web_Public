using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CdHotelManage.Web.Admin.Toroom
{
    public partial class ToRooms2 : System.Web.UI.Page
    {
        BLL.room_number fmnumber = new BLL.room_number();
        public string stwhere
        {

            get { return (string)ViewState["stwhere"]; }

            set { ViewState["stwhere"] = value; }

        }
        public int ids
        {

            get { return (int)ViewState["ids"]; }

            set { ViewState["ids"] = value; }

        }
        BLL.floor_manage fmlc = new BLL.floor_manage();
        BLL.room_type fxBll = new BLL.room_type();
        BLL.room_state fmft = new BLL.room_state();
        BLL.occu_infor fmmx = new BLL.occu_infor();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                AllBind();
            }
        }
        public void AllBind()
        {
            BindFTCX();
            Bind1();
            Bind2();
            Bind3();
            Bind4();
            Bind5();
            Bind6();
            Bind7();
            Bind9();
            Bind10();
            Bind8();
            Bind11();
            Bind12();
            Bind13();
            Bind14();
            Bind15();
            Bind16();
            Bind17();
            Bind18();
            Bind19();
            Bind20();
            Bind21();
            Bind22();
            Bind23();
            Bindleft();
            Bind101();
            Bind28();
            Bind25();
            
        }
        /// <summary>
        /// 房态方法显示
        /// </summary>
        public void BindFTCX()
        {
            DataSet dt = fmft.GetList(" room_state_id not in(6)");

            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                dr["remark"] = fmnumber.GetRecordCount(" Rn_state=" + dr["room_state_id"] + "").ToString();
            }
            Repeaterft.DataSource = dt;
            Repeaterft.DataBind();
        }
        /// <summary>
        /// 设置样式方法2
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetClassDiv(int state)
        {
            string FtName = "";
            if (state != 0)
            {
                FtName = fmft.GetModel(state).room_state_name;

            }
            if (FtName == "在住房")
            {
                Style = "bgorange ztspan01";
            }
            else if (FtName == "干净房" || state == 0)
            {
                Style = "bgblue ztspan01";
            }
            else if (FtName == "将到房")
            {
                Style = "bggreen ztspan01";
            }
            else if (FtName == "脏房")
            {
                Style = "bggray_q ztspan01";
            }
            else if (FtName == "自用房") 
            {
                Style = "zyf ztspan01";
            }
            else if (FtName == "脏住房")
            {
                Style = "zzf ztspan01";
            }
            else if (FtName == "取消")
            {
                Style = "quxiao ztspan01";
            }
            else
            {
                Style = "bggray_s ztspan01";
            }
            return Style;
        }
        public void Bind1() 
        {
            ul1.InnerHtml = "";
            string Divli = "";
            string img = "";
            string sjsj = "";
            int count = 0;
            DataSet dt = fmnumber.GetList(" Rn_roomNum in('F-02','A-20','A-18','A-16','A-15' ) order by Rn_roomNum desc");
            foreach (DataRow dr in dt.Tables[0].Rows) 
            {
                string Names = "";
                if ((dr["Rn_state"]) == null || dr["Rn_state"].ToString() == "")
                {
                    dr["Rn_state"] = "0";
                }
                string FtNames = fmft.GetModel(Convert.ToInt32(dr["Rn_state"])).room_state_name;
                GetClass(Convert.ToInt32(dr["Rn_state"]));
                if (FtNames == "干净房")
                {

                    sjsj = "ondblclick=\"ShowTab('在住房信息'," + dr["id"].ToString() + ",0)\"";
                }
                else
                {
                    sjsj = "";
                }
                if (FtNames == "在住房")
                {
                    try
                    {
                        string a = dr["Rn_roomNum"].ToString();
                        Names = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + dr["Rn_roomNum"].ToString() + "'").occ_name;
                        dr["id"] = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + dr["Rn_roomNum"].ToString() + "'").occ_id;
                    }
                    catch { }
                }
                string b = dr["Rn_roomNum"].ToString();
                string Room_suods = fmnumber.GetModelList(" Rn_roomNum='" + b + "'")[0].Room_suod.ToString().Trim();
                if (Room_suods == "是")
                {
                    img = "锁定";
                }
                else
                {
                    img = "";
                }
                if (count == 0)
                {
                    Divli += "<li rooms=" + dr["Rn_roomNum"].ToString() + " id=" + Convert.ToInt32(dr["id"].ToString()) + " state=" + Convert.ToInt32(dr["Rn_state"]) + " " + sjsj + "   class='bgblue left01roomb " + Style + "' >" + dr["Rn_roomNum"].ToString() + "&nbsp;&nbsp;" + img + "</li>";

                }
                else 
                {
                    Divli += "<li rooms=" + dr["Rn_roomNum"].ToString() + " id=" + Convert.ToInt32(dr["id"].ToString()) + " state=" + Convert.ToInt32(dr["Rn_state"]) + " " + sjsj + "  class='" + Style + "'>" + dr["Rn_roomNum"].ToString() + "&nbsp;&nbsp;" + img + "</li>";

                }
                count++;
            }
            ul1.InnerHtml = Divli;
        }
        public void Bind2()
        {
            ul2.InnerHtml = "";
            DataSet dt = fmnumber.GetList(" Rn_roomNum in('A-13','A-12','A-10','A-09','A-06','A-03','A-01' ) order by Rn_roomNum desc");
            ul2.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bind3()
        {
            ul3.InnerHtml = "";
            DataSet dt = fmnumber.GetList(10, " Rn_roomNum not in('F-01','F-02') and Rn_room=6", "Rn_roomNum");
            ul3.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bind4()
        {
            ul4.InnerHtml = "";
            string img = "";
            string sjsj = "";
            string Divli = "<li class='bcolorcs'>厕所</li>";
            DataSet dt = fmnumber.GetList(10, " Rn_roomNum  in('A-17','A-19')", "Rn_roomNum");
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                string Names = "";
                if ((dr["Rn_state"]) == null || dr["Rn_state"].ToString() == "")
                {
                    dr["Rn_state"] = "0";
                }
                string FtNames = fmft.GetModel(Convert.ToInt32(dr["Rn_state"])).room_state_name;
                GetClass(Convert.ToInt32(dr["Rn_state"]));
                if (FtNames == "干净房")
                {

                    sjsj = "ondblclick=\"ShowTab('在住房信息'," + dr["id"].ToString() + ",0)\"";
                }
                else
                {
                    sjsj = "";
                }
                if (FtNames == "在住房")
                {
                    try
                    {
                        string a = dr["Rn_roomNum"].ToString();
                        Names = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + dr["Rn_roomNum"].ToString() + "'").occ_name;
                        dr["id"] = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + dr["Rn_roomNum"].ToString() + "'").occ_id;
                    }
                    catch { }
                }
                string b = dr["Rn_roomNum"].ToString();
                string Room_suods = fmnumber.GetModelList(" Rn_roomNum='" + b + "'")[0].Room_suod.ToString().Trim();
                if (Room_suods == "是")
                {
                    img = "锁定";
                }
                else
                {
                    img = "";
                }
                Divli += "<li rooms=" + dr["Rn_roomNum"].ToString() + " id=" + Convert.ToInt32(dr["id"].ToString()) + " state=" + Convert.ToInt32(dr["Rn_state"]) + " " + sjsj + " class='" + Style + "'>" + dr["Rn_roomNum"].ToString() + "&nbsp;&nbsp;" + img + "</li>";

            }
            ul4.InnerHtml = Divli;

        }
        public void Bind5()
        {
            ul5.InnerHtml = "";
            DataSet dt = fmnumber.GetList(" Rn_roomNum in('A-11','A-08','A-07','A-05','A-02') order by Rn_roomNum desc");
            ul5.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bind6()
        {
            ul6.InnerHtml = "";
            DataSet dt = fmnumber.GetList(5, " right(Rn_roomNum,1)%2 !=0 and Rn_roomNum like 'B-%'", "Rn_roomNum desc");
            ul6.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bind7()
        {
            ul7.InnerHtml = "";
            DataSet dt = fmnumber.GetList(5, " right(Rn_roomNum,1)%2 =0 and Rn_roomNum like 'B-%'", "Rn_roomNum desc");
            ul7.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bind9()
        {
            ul9.InnerHtml = "";
            DataSet dt = fmnumber.GetList(8, " right(Rn_roomNum,1)%2 !=0 and right(Rn_roomNum,2)<17  and Rn_roomNum like 'B-%'", "Rn_roomNum desc");
            ul9.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bind10()
        {
            ul10.InnerHtml = "";
            DataSet dt = fmnumber.GetList(8, " right(Rn_roomNum,1)%2 =0 and right(Rn_roomNum,2)<22 and Rn_roomNum like 'B-%'", "Rn_roomNum desc");

            ul10.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bind8()
        {
            ul8.InnerHtml = "";
            DataSet dt = fmnumber.GetList(5, " right(Rn_roomNum,1)%2 !=0 and Rn_roomNum like 'C-%'", "Rn_roomNum desc");
            ul8.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bind11()
        {
            ul11.InnerHtml = "";
            DataSet dt = fmnumber.GetList(8, " right(Rn_roomNum,1)%2 !=0  and right(Rn_roomNum,2)<17 and Rn_roomNum like 'C-%'", "Rn_roomNum desc");
            ul11.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bind12()
        {
            ul12.InnerHtml = "";
            DataSet dt = fmnumber.GetList(5, " right(Rn_roomNum,1)%2 =0 and Rn_roomNum like 'C-%'", "Rn_roomNum desc");
            ul12.InnerHtml = aa(dt.Tables[0].Rows);
        }
        public void Bind13()
        {
            ul13.InnerHtml = "";
            DataSet dt = fmnumber.GetList(8, " right(Rn_roomNum,1)%2 =0 and right(Rn_roomNum,2)<22 and Rn_roomNum like 'C-%'", "Rn_roomNum desc");
            ul13.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bind14()
        {
            ul15.InnerHtml = "";
            DataSet dt = fmnumber.GetList(" Rn_roomNum in('D-16','D-15','D-13') order by Rn_roomNum desc");
            ul15.InnerHtml = aa(dt.Tables[0].Rows);
        }
        public void Bind15()
        {
            ul14.InnerHtml = "";
         
            DataSet dt = fmnumber.GetList(" Rn_roomNum in('D-09','D-07','D-06','D-03','D-01' ) order by Rn_roomNum desc");
            ul14.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bind16()
        {
            ul16.InnerHtml = "";
            DataSet dt = fmnumber.GetList(9, "  Rn_roomNum like 'E-%'", "Rn_roomNum asc");
            ul16.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bind17()
        {
            ul17.InnerHtml = "";
            DataSet dt = fmnumber.GetList(" Rn_roomNum in('F-15','F-16','F-19','F-20','F-21','F-22','F-26','F-27' ) order by Rn_roomNum asc");
            ul17.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bind18()
        {
            ul18.InnerHtml = "";
            DataSet dt = fmnumber.GetList(" Rn_roomNum in('F-17','F-18','F-25','F-23','F-25','F-50','F-38','F-35','F-32' ) order by Room_sort asc ");
            ul18.InnerHtml = aa(dt.Tables[0].Rows);
            ;
        }
        public void Bind19()
        {

            ul19.InnerHtml = "";
            string Divli = "";
            string img = "";
            string sjsj = "";
            int count = 0;
    
            DataSet dt = fmnumber.GetList(" Rn_roomNum in('F-51','F-39','F-37','F-36','F-33','F-31','F-30','F-29','D-12' ) order by Rn_roomNum desc");

            //ul19.InnerHtml = aa(dt.Tables[0].Rows);

            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                string Names = "";
                if ((dr["Rn_state"]) == null || dr["Rn_state"].ToString() == "")
                {
                    dr["Rn_state"] = "0";
                }
                string FtNames = fmft.GetModel(Convert.ToInt32(dr["Rn_state"])).room_state_name;
                GetClass(Convert.ToInt32(dr["Rn_state"]));
                if (FtNames == "干净房")
                {

                    sjsj = "ondblclick=\"ShowTab('在住房信息'," + dr["id"].ToString() + ",0)\"";
                }
                else
                {
                    sjsj = "";
                }
                if (FtNames == "在住房")
                {
                    try
                    {
                        string a = dr["Rn_roomNum"].ToString();
                        Names = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + dr["Rn_roomNum"].ToString() + "'").occ_name;
                        dr["id"] = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + dr["Rn_roomNum"].ToString() + "'").occ_id;
                    }
                    catch { }
                }
                string b = dr["Rn_roomNum"].ToString();
                string Room_suods = fmnumber.GetModelList(" Rn_roomNum='" + b + "'")[0].Room_suod.ToString().Trim();
                if (Room_suods == "是")
                {
                    img = "锁定";
                }
                else
                {
                    img = "";
                }
                if (count == 8)
                {
                    Divli += "<li rooms=" + dr["Rn_roomNum"].ToString() + " id=" + Convert.ToInt32(dr["id"].ToString()) + " state=" + Convert.ToInt32(dr["Rn_state"]) + " " + sjsj + "   class='bgblue topmargin " + Style + "' >" + dr["Rn_roomNum"].ToString() + "&nbsp;&nbsp;" + img + "</li>";

                }
                else
                {
                    Divli += "<li rooms=" + dr["Rn_roomNum"].ToString() + " id=" + Convert.ToInt32(dr["id"].ToString()) + " state=" + Convert.ToInt32(dr["Rn_state"]) + " " + sjsj + "  class='" + Style + "'>" + dr["Rn_roomNum"].ToString() + "&nbsp;&nbsp;" + img + "</li>";

                }
                count++;
            }
            ul19.InnerHtml = Divli;

        }
        public void Bind20()
        {
            ul20.InnerHtml = "";
            DataSet dt = fmnumber.GetList(" Rn_roomNum in('D-11','D-10','D-08','D-05','D-02') order by Rn_roomNum desc");
            ul20.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bind21()
        {
            ul21.InnerHtml = "";
            DataSet dt = fmnumber.GetList(" Rn_roomNum in('E-37','E-36','E-35','E-30','E-30','E-29','E-28','E-27','E-26') order by Rn_roomNum desc");
            ul21.InnerHtml = aa(dt.Tables[0].Rows);
        }
        public void Bind22()
        {
            ul22.InnerHtml = "";

            DataSet dt = fmnumber.GetList(" Rn_roomNum in('E-39','E-38 ','E-33','E-31','E-13','E-16','E-19','E-20') order by Room_sort asc");
            ul22.InnerHtml = aa(dt.Tables[0].Rows);
        }
       
        public void Bind23()
        {
            ul23.InnerHtml = "";
            DataSet dt = fmnumber.GetList(" Rn_roomNum in('E-11','E-12','E-15','E-17','E-18','E-21','E-22','E-23') order by Rn_roomNum asc");
            ul23.InnerHtml = aa(dt.Tables[0].Rows);
           
        }
        public void Bind101()
        {
            ul101.InnerHtml = "";
            DataSet dt = fmnumber.GetList(" Rn_roomNum in('F-01') ");
            ul101.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bind28()
        {
            ul28.InnerHtml = "";
            DataSet dt = fmnumber.GetList(" Rn_roomNum in('F-28') ");
            ul28.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bind25()
        {
            ul25.InnerHtml = "";
            DataSet dt = fmnumber.GetList(" Rn_roomNum in('E-25') ");
            ul25.InnerHtml = aa(dt.Tables[0].Rows);

        }
        public void Bindleft()
        {
            ulLeft.InnerHtml = "";
            string Divli = "<li class='bgblue left01roomb'>物业办公室</li>";
            string img = "";
            string sjsj = "";
            DataSet dt = fmnumber.GetList(" Rn_roomNum in('101','102') order by Rn_roomNum desc");
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                string Names = "";
                if ((dr["Rn_state"]) == null || dr["Rn_state"].ToString() == "")
                {
                    dr["Rn_state"] = "0";
                }
                string FtNames = fmft.GetModel(Convert.ToInt32(dr["Rn_state"])).room_state_name;
                GetClass(Convert.ToInt32(dr["Rn_state"]));
                if (FtNames == "干净房")
                {

                    sjsj = "ondblclick=\"ShowTab('在住房信息'," + dr["id"].ToString() + ",0)\"";
                }
                else
                {
                    sjsj = "";
                }
                if (FtNames == "在住房")
                {
                    try
                    {
                        string a = dr["Rn_roomNum"].ToString();
                        Names = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + dr["Rn_roomNum"].ToString() + "'").occ_name;
                        dr["id"] = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + dr["Rn_roomNum"].ToString() + "'").occ_id;
                    }
                    catch { }
                }
                string b = dr["Rn_roomNum"].ToString();
                string Room_suods = fmnumber.GetModelList(" Rn_roomNum='" + b + "'")[0].Room_suod.ToString().Trim();
                if (Room_suods == "是")
                {
                    img = "锁定";
                }
                else
                {
                    img = "";
                }

                Divli += "<li rooms=" + dr["Rn_roomNum"].ToString() + " id=" + Convert.ToInt32(dr["id"].ToString()) + " state=" + Convert.ToInt32(dr["Rn_state"]) + " " + sjsj + "  class='left01roomb " + Style + "'>" + dr["Rn_roomNum"].ToString() + "&nbsp;&nbsp;" + img + "</li>";

               
                
            }
            ulLeft.InnerHtml = Divli;

        }
        public string aa(DataRowCollection drs)
        {
            string Divli = "";
            string img = "";
            string sjsj = "";
            foreach (DataRow dr in drs)
            {
                string Names = "";
                if ((dr["Rn_state"]) == null || dr["Rn_state"].ToString() == "")
                {
                    dr["Rn_state"] = "0";
                }
                string FtNames = fmft.GetModel(Convert.ToInt32(dr["Rn_state"])).room_state_name;
                GetClass(Convert.ToInt32(dr["Rn_state"]));
                if (FtNames == "干净房")
                {

                    sjsj = "ondblclick=\"ShowTab('在住房信息'," + dr["id"].ToString() + ",0)\"";
                }
                else
                {
                    sjsj = "";
                }
                if (FtNames == "在住房")
                {
                    try
                    {
                        string a = dr["Rn_roomNum"].ToString();
                        Names = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + dr["Rn_roomNum"].ToString() + "'").occ_name;
                        dr["id"] = fmmx.GetModels(" where occ_with='否' and state_id=0 and room_number='" + dr["Rn_roomNum"].ToString() + "'").occ_id;
                    }
                    catch { }
                }
                string b = dr["Rn_roomNum"].ToString();
                string Room_suods = fmnumber.GetModelList(" Rn_roomNum='" + b + "'")[0].Room_suod.ToString().Trim();
                if (Room_suods == "是")
                {
                    img = "锁定";
                }
                else
                {
                    img = "";
                }
                Divli += "<li rooms=" + dr["Rn_roomNum"].ToString() + " id=" + Convert.ToInt32(dr["id"].ToString()) + " state=" + Convert.ToInt32(dr["Rn_state"]) + " " + sjsj + " class='" + Style + "'>" + dr["Rn_roomNum"].ToString() + "&nbsp;&nbsp;" + img + "</li>";
            }
            return Divli;
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        string Style = "";
      //  string ListYJ = "";
        
        /// <summary>
        /// 设置右键菜单
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetClass(int state)
        {
            string FtName = "";
            if (state != 0)
            {
                FtName = fmft.GetModel(state).room_state_name;

            }

            if (FtName == "在住房")
            {
                Style = "bgorange";
            }
            else if (FtName == "干净房" || state == 0)
            {
                Style = "bgblue";
            }
            else if (FtName == "将到房")
            {
                Style = "bggreen";
            }
            else if (FtName == "脏房")
            {
                Style = "bggray_q";
            }
            else if (FtName == "脏住房")
            {
                Style = "zhang_zf";
            }
            else if (FtName == "自用房")
            {
                Style = "pink_zyf";
            }
            else
            {
                Style = "bggray_s";
            }
            return Style;
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string SQl = "";
            string roomNum = hidRoom.Value;
            string a = hidNumber.Value;
            if (hidNumber.Value == "0")
            {
                //脏房
                SQl = "update room_number set Rn_state=4 where id=" + roomNum + "";

            }
            //if (hidNumber.Value == "1")
            //{
            //    //维修
            //    SQl = "update room_number set Rn_state=5 where id=" + roomNum + "";

            //}
            if (hidNumber.Value == "2")
            {
                //空房
                SQl = "update room_number set Rn_state=3 where id=" + roomNum + "";

            }

            if (hidNumber.Value == "3")
            {
                //锁定
                SQl = "update room_number set Room_suod='是' where id=" + roomNum + "";
            }
            if (hidNumber.Value == "4")
            {
                //没有锁定
                SQl = "update room_number set Room_suod='否' where id=" + roomNum + "";
            }
            if (hidNumber.Value == "5")
            {
                //脏住房
                SQl = "update room_number set Rn_state=7 where id='" + roomNum + "'";
            }
            if (hidNumber.Value == "6")
            {
                //干净房
                SQl = "update room_number set Rn_state=2 where id=" + roomNum + "";
            }
            if (hidNumber.Value == "7")
            {
                //自用房
                SQl = "update room_number set Rn_state=8 where id=" + roomNum + "";
            }
            fmnumber.Updates(SQl);
            AllBind();
        }
        /// <summary>
        /// 撤销入主
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        BLL.goods_account fmgood = new BLL.goods_account();
        protected void btncx_Click(object sender, EventArgs e)
        {
            string a = txt_ids.Value;
            string orderby = fmmx.GetModel(Convert.ToInt32(a)).order_id;
            string Sql = "update goods_account set ga_sfacount='是' where ga_occuid='" + orderby + "'";
            string str2 = "update room_number set Rn_state=3 where Rn_roomNum='" + fmmx.GetModel(Convert.ToInt32(a)).room_number + "'";
            string STRSQL = " update occu_infor set state_id=10 where occ_id='" + a + "'";
            if (fmnumber.Updates(str2) && fmmx.Updates(STRSQL) && fmgood.Updates(Sql))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('撤销入账成功');</script>");

                AllBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('撤销入账失败');</script>");

            }
        }
        public string GetFX(int id)
        {
            BLL.room_type rtbll = new BLL.room_type();

            Model.room_type model = rtbll.GetModel(Convert.ToInt32(id.ToString()));

            return model.room_name;
        }
    }
}