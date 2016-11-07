using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.NetworkInformation;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Management;
using System.Configuration;
namespace CdHotelManage.Web.Admin
{
    public partial class login : System.Web.UI.Page,System.Web.SessionState.IRequiresSessionState
    {
        public string userid = "";
        CdHotelManage.BLL.AccountsUsersBLL aubll = new BLL.AccountsUsersBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            //PhysicalAddress ds = adapters[0].GetPhysicalAddress();
            //byte[] s = ds.GetAddressBytes();
            //StringBuilder sb = new StringBuilder(); 
            //for (int i = 0; i < s.Length; i++)
            //{ // 以十六进制格式化 
            //    sb.Append(s[i].ToString("X2"));
            //    if (i != s.Length - 1)
            //    {
            //        sb.Append("-");
            //    }
            //}
            //获取硬盘ID 
            //try
            //{
            //    String HDid = "";
            //    ManagementClass mc = new ManagementClass("Win32_DiskDrive");
            //    ManagementObjectCollection moc = mc.GetInstances();
            //    foreach (ManagementObject mo in moc)
            //    {
            //        HDid = (string)mo.Properties["Model"].Value;
            //    }
            //    moc = null;
            //    mc = null;
            //    string sts = HDid;
            //    string config = ConfigurationManager.AppSettings["ConnectionString1"];
            //    SqlConnection conn = new SqlConnection(config);
            //    DataSet dst = new DataSet();
            //    using (SqlDataAdapter da = new SqlDataAdapter("select * from LogMac where MAC='" + sts + "'", conn))
            //    {
            //        da.Fill(dst);
            //    }
            //    if (dst.Tables[0].Rows.Count > 0)
            //    {

            //    }
            //    else
            //    {
            //        Response.Write("请联系川度!!");
            //        Response.End();
            //    }
            //}
            //catch (Exception ex)
            //{
            //     Response.Write("请联系川度!!");
            //     Response.End();
            //}
        }

        private void ToPage()
        {
            if (Request.QueryString["returnurl"] != null)
            {
                CdHotelManage.Model.AccountsUsers user = aubll.GetModel(userid);
                user.Phone = GetIP();
                user.Email = DateTime.Now.ToString();
                aubll.Update(user);
                string returnurl = Request.QueryString["returnurl"].ToString();
                Response.Redirect(returnurl);
            }
            else
            {
                CdHotelManage.Model.AccountsUsers user = aubll.GetModel(userid);
                if (Request.Browser.Cookies == true)
                {
                    if (Request.Cookies["ip"] == null)
                    {
                        HttpCookie ip = new HttpCookie("ip");
                        ip.Value = user.Phone;
                        ip.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(ip);
                        Request.Cookies.Set(ip);
                    }
                }

                if (Request.Browser.Cookies == true)
                {
                    if (Request.Cookies["date"] == null)
                    {
                        HttpCookie date = new HttpCookie("date");
                        date.Value = user.Email;
                        date.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(date);
                        Request.Cookies.Set(date);
                    }
                }
                user.Phone = GetIP();
                user.Email = DateTime.Now.ToString();
                aubll.Update(user);
                Response.Redirect("/Admin/index.aspx");
            }
        }

        //获取IP地址
        private string GetIP()
        {
            
            string _user_ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == _user_ip || _user_ip == String.Empty)
            {
                _user_ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == _user_ip || _user_ip == String.Empty)
            {
                _user_ip = System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            return _user_ip;

        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (Session["CheckCode"] != null)
                {
                    if (txtSN.Text == Session["CheckCode"].ToString())
                    {
                        CdHotelManage.Model.AccountsUsers User = aubll.CheckUser(this.txtName.Text.Trim(), this.txtPwd.Text.Trim());
                        if (User != null)
                        {
                            //Session["User"] = User;
                            string ubaseid = User.UserID;
                            HttpCookie cookie = new HttpCookie("User", ubaseid);
                            Response.Cookies.Add(cookie);
                            userid = User.UserID;
                            ToPage();
                        }
                        else
                        {
                            lblMessage.Text = "用户名或密码不正确！";
                        }
                    }
                    else
                    {
                        lblMessage.Text = "验证码错误！";
                        return;
                    }
                }
                else
                {
                    lblMessage.Text = "请输入验证码！";
                    return;
                }
            }
        }
        


        protected void btnNull_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPwd.Text = "";
            txtSN.Text = "";
        }
    }
}