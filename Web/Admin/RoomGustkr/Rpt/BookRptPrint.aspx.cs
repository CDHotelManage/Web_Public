using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

///打印预定新增凭条报表
namespace CdHotelManage.Web.Admin.Rpt
{
    public partial class AccountDay1 : System.Web.UI.Page
    {
        int ids;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ids = Convert.ToInt32(Request["id"]);
            }

            //将ID传值给报表
            ParameterFields paraFields = new ParameterFields();

            //声明Id参数
            ParameterField id = new ParameterField();

            //设置参数名称，必须和报表中的参数相符
            id.Name = "book_id";

            ParameterDiscreteValue VId = new ParameterDiscreteValue();
            
            //给参数赋值，到时候根据传过来的参数传ids 先测试 默认写死1
           // VId.Value = "14";

            VId.Value = ids;

            id.CurrentValues.Add(VId);


            //将该参数添加到该字段集合
            paraFields.Add(id);

            ReportDocument document = new ReportDocument();

            //加载报表
            document.Load(Server.MapPath("BookRptPrint.rpt"));

            //设置数据源
            this.CrystalReportViewer1.ReportSource = document;

            //将参数字段集合放入查看器控件
            this.CrystalReportViewer1.ParameterFieldInfo = paraFields;


            //定义链接信息
            TableLogOnInfo connectionInfo = new TableLogOnInfo();

            connectionInfo.ConnectionInfo.ServerName = "192.168.1.5";

            connectionInfo.ConnectionInfo.DatabaseName = "CdHotelManage";

            connectionInfo.ConnectionInfo.UserID = "sa";

            connectionInfo.ConnectionInfo.Password = "sa2015";


            //应用链接设置
            document.Database.Tables[0].ApplyLogOnInfo(connectionInfo);

            //数据绑定
            this.CrystalReportViewer1.DataBind();


        }
    }
}