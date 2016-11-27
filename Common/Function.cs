using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Xml;

namespace Common
{
    /// <summary>
    /// Function 的摘要说明
    /// </summary>
    public class Function
    {
        public static string VirtualPath = System.Web.VirtualPathUtility.ToAbsolute("~/");
        public static string FileVersion = "?v=2015120301";

        //private static readonly IPublisher PushPublisher = PublisherFlyweightFactory.New(ChannelType.Push.ToString());


        public static bool isDevelopment
        {
            get
            {
                var env = ConfigurationManager.AppSettings["env"];
                return env == "development";
            }
        }
        public static string WebUrl = ConfigurationManager.AppSettings["WebUrl"];
        public static string qiniuMDPicUrl = ConfigurationManager.AppSettings["QiniuMDPic"];
        public static string qiniuMDDocUrl = ConfigurationManager.AppSettings["QiniuMDDoc"];
        public static string qiniuMDFileUrl = ConfigurationManager.AppSettings["QiniuMDFile"];
        public static string inviteLimitCount = ConfigurationManager.AppSettings["InviteLimitCount"];



        // webchat配置 end
        public Function()
        {

            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 弹出式信息
        /// <summary>
        /// 弹出式信息
        /// </summary>
        public static void JSAlertString(string message, System.Web.HttpResponse response)
        {
            string strJS = "<script language=\"javascript\">alert('" + message + "');</script>";
            response.Write(strJS);
        }
        #endregion

        #region 弹出式信息并关闭该窗口
        /// <summary>
        /// 弹出式信息并关闭该窗口
        /// </summary>
        public static void JSAlertClosePage(string message, System.Web.HttpResponse response)
        {
            string strJS = "<script language=\"javascript\">alert('" + message + "');this.window.close();</script>";
            response.Write(strJS);
            response.End();
        }
        #endregion

        #region 弹出式信息并跳转至页面
        /// <summary>
        /// 弹出信息并跳转页面
        /// </summary>
        public static void JSAlertTurnPage(string message, string turnPage, System.Web.HttpResponse response)
        {
            string strJS = "<script language=\"javascript\">alert('" + message + "');window.location.href='" + turnPage + "';</script>";
            response.Write(strJS);
            response.End();
        }
        #endregion

        #region 字符串截取
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="length">允许的长度</param>
        /// <returns>符合长度的字符串</returns>
        public static string InterceptString(string sourceString, int length)
        {
            if (string.IsNullOrEmpty(sourceString))
                return string.Empty;
            else
            {
                if (sourceString.Length > length)
                    return sourceString.Substring(0, length - 1) + "...";
                else
                    return sourceString;
            }
        }
        #endregion

        #region XML节点相关方法
        /// <summary>
        /// 增加新节点
        /// </summary>
        public static void AppendXmlNode(System.Xml.XmlDocument xmlDoc, System.Xml.XmlNode sourceNode, string nodeName, string nodeValue)
        {
            System.Xml.XmlNode newNode = xmlDoc.CreateElement(nodeName);
            newNode.InnerText = nodeValue;

            sourceNode.AppendChild(newNode);
        }

        /// <summary>
        /// 增加节点属性
        /// </summary>
        public static void AppendXmlAttribute(System.Xml.XmlDocument xmlDoc, System.Xml.XmlNode sourceNode, string attributeName, string attributeValue)
        {
            System.Xml.XmlAttribute newAttribute = xmlDoc.CreateAttribute(attributeName);
            newAttribute.Value = attributeValue;

            sourceNode.Attributes.Append(newAttribute);
        }
        #endregion

        #region 去除指定字符串中的HTML标签相关代码函数
        public static string RemoveHtml(string strContent, string strTagName, int strType)
        {
            string pattern = "";
            string strResult = "";
            Regex exp;
            MatchCollection matchList;
            switch (strType)
            {
                case 1://去掉<a></a>中<a>标记的内容,保留<a>后面的所有代码
                    pattern = @"<" + strTagName + "([^>])*>";
                    exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
                    matchList = exp.Matches(strContent);
                    foreach (Match match in matchList)
                    {
                        if (match.Value.Length > 0)
                            strResult = match.Value;
                        strContent = strContent.Replace(strResult, "");
                        break;
                    }
                    break;

                case 2://去掉所有<a></a>两个标记的内容,保留<a>和</a>代码中间的代码
                    pattern = "<" + strTagName + "([^>])*>";
                    exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
                    matchList = exp.Matches(strContent);
                    foreach (Match match in matchList)
                    {
                        if (match.Value.Length > 0)
                            strResult = match.Value;
                        strContent = strContent.Replace(strResult, "");
                        break;
                    }
                    pattern = "</" + strTagName + "([^>])*>";
                    exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
                    matchList = exp.Matches(strContent);
                    foreach (Match match in matchList)
                    {
                        if (match.Value.Length > 0)
                            strResult = match.Value;
                        strContent = strContent.Replace(strResult, "");
                        break;
                    }
                    break;

                case 3://去掉所有<a></a>和两个标记之间的全部内容 
                    pattern = "<" + strTagName + "([^>])*>.*?</" + strTagName + "([^>])*>";
                    exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
                    matchList = exp.Matches(strContent);
                    foreach (Match match in matchList)
                    {
                        if (match.Value.Length > 0)
                            strResult = match.Value;
                        strContent = strContent.Replace(strResult, "");
                        break;
                    }
                    break;
            }
            return strContent;
        }
        /// <summary>
        /// 去掉HTML标记
        /// </summary>
        /// <param name="_html">HTML</param>
        /// <returns></returns>
        public static string RemoveHTMLTags(string _html)
        {
            //删除脚本
            _html = Regex.Replace(_html, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除样式
            _html = Regex.Replace(_html, @"<style[^>]*?>.*?</style>", "", RegexOptions.IgnoreCase);
            //删除HTML
            _html = Regex.Replace(_html, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            _html = Regex.Replace(_html, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            _html = Regex.Replace(_html, @"-->", "", RegexOptions.IgnoreCase);
            _html = Regex.Replace(_html, @"<!--.*", "", RegexOptions.IgnoreCase);
            _html = Regex.Replace(_html, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            _html = Regex.Replace(_html, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            _html = Regex.Replace(_html, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            _html = Regex.Replace(_html, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            _html = Regex.Replace(_html, @"&(nbsp|#160);", "", RegexOptions.IgnoreCase);
            _html = Regex.Replace(_html, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            _html = Regex.Replace(_html, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            _html = Regex.Replace(_html, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            _html = Regex.Replace(_html, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            _html = Regex.Replace(_html, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            _html.Replace("<", "");
            _html.Replace(">", "");
            _html.Replace("\r\n", "");
            return _html;
        }

        #endregion

        #region 页面追加CSS

        public static void LinkCSS(string url, System.Web.UI.Page page)
        {
            HtmlLink link = new HtmlLink();
            link.Attributes["href"] = url + FileVersion;
            link.Attributes["type"] = "text/css";
            link.Attributes["rel"] = "stylesheet";
            page.Header.Controls.Add(link);
        }
        public static void LinkCSS(IEnumerable<string> urls, System.Web.UI.Page page)
        {
            foreach (var url in urls)
            {
                LinkCSS(url, page);
            }
        }

        public static void LinkCSSContent(string css, System.Web.UI.Page page)
        {
            HtmlGenericControl style = new HtmlGenericControl();
            style.TagName = "style";
            style.Attributes.Add("type", "text/css");
            style.InnerHtml = css;
            page.Header.Controls.Add(style);
        }

        #endregion

        #region 页面追加JS

        public static void LinkJS(string url, System.Web.UI.Page page)
        {
            HtmlGenericControl script = new HtmlGenericControl("script");
            script.Attributes["type"] = "text/javascript";
            script.Attributes["src"] = url + FileVersion;
            page.Header.Controls.Add(script);
        }

        public static void LinkJSAtBottom(string url, System.Web.UI.Page page)
        {


            var scriptString = "<script type=\"text/javascript\" src=\"" + url + "\"></script>";

            page.ClientScript.RegisterStartupScript(typeof(string), scriptString, scriptString, false);

            //if (!Page.ClientScript.IsStartupScriptRegistered("myJsInclude"))
            //    Page.ClientScript.RegisterStartupScript(typeof(string), "myJsInclude", jsBlock, false);
        }


        public static void LinkJSContentAtBottom(string seaJs, System.Web.UI.Page page)
        {
            var scriptString = "<script  type=\"text/javascript\">" + seaJs + "</script>";
            page.ClientScript.RegisterStartupScript(typeof(string), scriptString, scriptString, false);
        }

        
        #endregion

        #region 页面头部写入脚本内容
        public static void WriteJS(string jsStr, System.Web.UI.Page page)
        {
            HtmlGenericControl script = new HtmlGenericControl("script");
            script.Attributes["type"] = "text/javascript";
            script.InnerText = jsStr;
            page.Header.Controls.Add(script);
        }
        #endregion

        #region 将XML保存为文件
        public static string SaveXMLFile(string sXML, string xmlFileName)
        {
            string absolutePath = HttpContext.Current.Server.MapPath("~/tempfiles/");
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(sXML);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            xmlDoc.Save(absolutePath + xmlFileName);
            return "tempfiles/" + xmlFileName;
        }
        #endregion

        #region 创建随机文件夹目录，并返回该目录名，如果存在则直接返回该目录名
        /// <summary>
        /// 创建随机文件夹目录，并返回该目录名
        /// </summary>
        public static string CreateRandomDirectoryFolder(string absolutePath)
        {
            System.Random random = new System.Random();
            string folderName = RandomCode(random, 5);
            bool exist = System.IO.Directory.Exists(absolutePath + "\\" + folderName);
            if (!exist)
            {
                System.IO.Directory.CreateDirectory(absolutePath + "\\" + folderName);
            }
            return folderName;

        }
        /// <summary>
        /// 创建目录下的文件夹，如果存在不创建
        /// </summary>
        public static void CreateDiretoryFolder(string absolutePath, string folderName)
        {
            bool exist = System.IO.Directory.Exists(absolutePath + "\\" + folderName);
            if (!exist)
            {
                System.IO.Directory.CreateDirectory(absolutePath + "\\" + folderName);
            }
        }

        /// <summary>
        /// 产生随机字符串
        /// </summary>
        private static string RandomCode(System.Random random, int digit)
        {
            string[] strArr = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
            string outstr = string.Empty;
            for (int i = 0; i < digit; i++)
            {
                outstr = outstr + strArr[random.Next(strArr.GetLowerBound(0), strArr.GetUpperBound(0))];
            }
            return outstr;
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="absolutePath"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static string CreateDirectoryFolderForAttachment(string absolutePath, string userName)
        {

            string folderName = DateTime.Now.ToString("yyyyMMddHHmmss");
            folderName = userName + "\\" + folderName;
            bool exist = System.IO.Directory.Exists(absolutePath + "\\" + folderName);
            if (exist)
            {
                return folderName;
            }
            else
            {
                System.IO.Directory.CreateDirectory(absolutePath + "\\" + folderName);
                return folderName;
            }
        }
        #endregion

        #region 密码规则验证
        /// <summary>
        /// 密码规则验证
        /// </summary>
        public static bool ValidatePassword(string str)
        {
            bool flag = false;
            if (str.Length >= 8 && str.Length <= 20 && Regex.IsMatch(str, @"[a-zA-Z]") && Regex.IsMatch(str, @"[0-9]"))
                flag = true;
            return flag;
        }
        #endregion

        #region 验证字符串是否是
        /// <summary>
        /// 验证字符串是否是GUID
        /// </summary>
        public static bool isGuid(string str)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(str))
            {
                try
                {
                    Guid g = new Guid(str);
                    result = true;
                }
                catch (Exception ex)
                { }
            }
            return result;
        }
        #endregion

        #region Email地址验证
        /// <summary>
        /// Email地址验证
        /// </summary>
        public static bool ValidateEmail(string strIn)
        {
            if (string.IsNullOrWhiteSpace(strIn))
                return false;
            return Regex.IsMatch(strIn, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)*\.[\w-]+$");
        }
        /// <summary>
        /// 判断是否是免费邮箱
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        //public static bool IsFreeEmail(string email)
        //{
        //    return MD.Business.Unit.RefusedDomains.Contains(new MD.Entity.DomainItem(email.Split('@')[1]));
        //}
        #endregion

        #region 手机号码验证
        /// <summary>
        /// 手机号码验证
        /// </summary>
        public static bool ValidateMobilePhone(string strIn)
        {
            if (string.IsNullOrEmpty(strIn))
            {
                return false;
            }
            return Regex.IsMatch(strIn, @"^(1[3-8]{1})\d{9}$");
        }
        #endregion

        #region 数字千位逗号
        public static string NumberComma(string number)
        {
            try
            {
                string format;
                if (number.Split('.').Length == 1)
                    format = "##,##0";
                else
                    format = "##,##0.00";
                return double.Parse(number).ToString(format);
            }
            catch
            {
                return number;
            }
        }
        #endregion

        

        #region 文件读取(csv,xls,txt)

        #region 读取csv文件
        /// <summary>
        /// 读取CVS文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="name">文件名称</param>
        /// <returns>DataTable</returns>
        public static DataTable ReadCVS(string filepath, string filename)
        {
            //string cvsDir = filepath;//要读取的CVS路径
            DataTable dt = new DataTable();
            if (filename.Trim().ToUpper().EndsWith("CSV"))//判断所要读取的扩展名
            {
                string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                    + filepath + ";Extended Properties='text;HDR=NO;FMT=Delimited'";//有列的读取
                string commandText = "select * from [" + filename + "]";//SQL语句
                OleDbConnection olconn = null;
                OleDbDataAdapter odp = null;
                try
                {
                    olconn = new OleDbConnection(connStr);
                    olconn.Open();
                    odp = new OleDbDataAdapter(commandText, olconn);
                    odp.Fill(dt);
                }
                catch
                { }
                finally
                {
                    //释放资源
                    if (olconn != null) { olconn.Close(); }
                    if (odp != null) { odp.Dispose(); odp = null; olconn.Dispose(); olconn = null; }
                }
            }
            return dt;
        }
        #endregion

        #region 读取Excel文件
        /// <summary>
        /// 读取Excel文件
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <param name="filename">文件名称</param>
        /// <returns>DataTable</returns>
        //public static DataTable ReadExcel(string filepath, string filename)
        //{
        //    DataTable table = new DataTable();
        //    if (filename.Trim().ToUpper().EndsWith("XLS") || filename.Trim().ToUpper().EndsWith("XLSX"))
        //    {
        //        Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(filepath + filename);
        //        Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];
        //        table = worksheet.Cells.ExportDataTable(0, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1);
        //    }
        //    return table;
        //}
        #region 通过组建读取
        ////读取EXCEL的方法   (用范围区域读取数据)
        //private static void OpenExcel(string strFileName)
        //{
        //    object missing = System.Reflection.Missing.Value;
        //    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//lauch excel application
        //    if (excel == null)
        //    {

        //    }
        //    else
        //    {
        //        excel.Visible = false; excel.UserControl = true;
        //        // 以只读的形式打开EXCEL文件
        //        Microsoft.Office.Interop.Excel.Workbook wb = excel.Application.Workbooks.Open(strFileName, missing, true, missing, missing, missing,
        //         missing, missing, missing, true, missing, missing, missing, missing, missing);
        //        //取得第一个工作薄
        //        Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets.get_Item(1);
        //        excel.Quit(); excel = null;
        //        Process[] procs = Process.GetProcessesByName("excel");
        //        foreach (Process pro in procs)
        //        {
        //            pro.Kill();//没有更好的方法,只有杀掉进程
        //        }
        //        GC.Collect();
        //    }
        //} 
        #endregion
        #endregion

        #region 读取txt文件
        /// <summary>
        /// 读取Txt文本文件
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <param name="filename">文件名称</param>
        /// <returns>文本信息</returns>
        public static string ReadTxt(string filepath, string filename)
        {
            //StreamReader sr = new StreamReader(filepath + filename); ;
            StreamReader sr = null;
            string txt = string.Empty;
            try
            {
                sr = new StreamReader(filepath + filename, Encoding.GetEncoding("GB2312"));
                txt = sr.ReadToEnd();
            }
            catch
            { }
            finally
            {
                if (sr != null) { sr.Close(); sr.Dispose(); sr = null; }
            }
            return txt;
        }
        #endregion

        #endregion

        #region 文件删除
        /// <summary>
        /// 删除文件操作
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileName">文件名称</param>
        public static void DeleteFile(string filePath, string fileName)
        {
            string destinationFile = filePath + fileName;
            //如果文件存在，删除文件
            if (File.Exists(destinationFile))
            {
                FileInfo fi = new FileInfo(destinationFile);
                if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                    fi.Attributes = FileAttributes.Normal;

                File.Delete(destinationFile);
            }
        }
        #endregion

        #region 文件拷贝
        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <param name="fromFilePath">文件的路径</param>
        /// <param name="toFilePath">文件要拷贝到的路径</param>
        public static bool CopyFile(string fromFilePath, string toFilePath)
        {
            try
            {
                if (File.Exists(fromFilePath))
                {
                    if (File.Exists(toFilePath))
                    {
                        File.Delete(toFilePath);
                    }
                    File.Copy(fromFilePath, toFilePath);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 文件下载

        //public static void FileDownload(string DownPath, string originalName, string fileExt = "", bool inline = false)
        //{
        //    HttpResponse Response = System.Web.HttpContext.Current.Response;
        //    HttpServerUtility Server = System.Web.HttpContext.Current.Server;

        //    if (string.IsNullOrEmpty(fileExt))
        //        fileExt = Path.GetExtension(DownPath);

        //    string mime = "application/octet-stream";
        //    switch (fileExt)
        //    {
        //        case ".doc":
        //            mime = "application/msword";
        //            break;
        //        case ".docx":
        //            mime = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        //            break;
        //        case ".ppt":
        //            mime = "application/vnd.ms-powerpoint";
        //            break;
        //        case ".pot":
        //            mime = "application/vnd.ms-powerpoint";
        //            break;
        //        case ".pps":
        //            mime = "application/vnd.ms-pps";
        //            break;
        //        case ".pptx":
        //            mime = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
        //            break;
        //        case ".xls":
        //            mime = "application/vnd.ms-excel";
        //            break;
        //        case ".xlsx":
        //            mime = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //            break;
        //        case ".pdf":
        //            mime = "application/pdf";
        //            break;
        //        case ".txt":
        //            mime = "text/plain";
        //            break;
        //        case ".rar":
        //            mime = "application/octet-stream";
        //            break;
        //        case ".zip":
        //            mime = "application/octet-stream";
        //            //mime = "application/x-zip-compressed";
        //            break;
        //    }

        //    Response.Clear();
        //    long contentLength;
        //    using (var fs = new FileStream(DownPath, FileMode.Open, FileAccess.Read))
        //    {
        //        contentLength = fs.Length;
        //        if (inline)
        //        {
        //            var enc = MD.Memcached.Utils.CacheClient.Get("attachment.encoding." + DownPath.GetHashCode()) as Encoding ?? Encoding.UTF8;
        //            if (fs.CanSeek)
        //            {
        //                var detector = new Ude.CharsetDetector();
        //                detector.Feed(fs);
        //                detector.DataEnd();
        //                if (!string.IsNullOrEmpty(detector.Charset))
        //                    enc = Encoding.GetEncoding(detector.Charset);
        //            }
        //            MD.Memcached.Utils.CacheClient.Add("attachment.encoding." + DownPath.GetHashCode(), enc);

        //            Response.ContentEncoding = enc;
        //            Response.Charset = enc.WebName;
        //        }
        //        else
        //        {
        //            Response.Charset = "utf-8";
        //        }
        //    }
        //    Response.Buffer = true;
        //    Response.HeaderEncoding = Encoding.UTF8;
        //    string agent = System.Web.HttpContext.Current.Request.UserAgent.ToUpper();
        //    if (agent.Contains("FIREFOX") || agent.Contains("SAFARI"))
        //        Response.AppendHeader("Content-Disposition",
        //            (inline ? "inline" : "attachment") + ";filename=\"" + originalName + "\"");
        //    else
        //        Response.AppendHeader("Content-Disposition",
        //            (inline ? "inline" : "attachment") + ";filename=\"" +
        //            HttpUtility.UrlEncode(originalName, System.Text.Encoding.UTF8) + "\"");
        //    Response.ContentType = mime;
        //    Response.AddHeader("Content-Length", contentLength.ToString(CultureInfo.InvariantCulture));
        //    Response.WriteFile(DownPath);
        //    Response.Flush();
        //    Response.Close();
        //    Response.End();
        //}

        #endregion

        #region 判断文件类型

        public static bool IsExtInList(string filename, List<string> fileExts)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                string ext = Path.GetExtension(FilterInvalidPathChars(filename));
                if (!string.IsNullOrEmpty(ext))
                {
                    ext = ext.ToLower();
                    return fileExts.Contains(ext);
                }
            }
            return false;
        }

        private static readonly List<string> pictureExts = new List<string> { ".jpg", ".gif", ".png", ".jpeg", ".bmp", ".svg", ".webp" };
        /// <summary>
        /// 判断是否是图片
        /// </summary>
        public static bool IsPicture(string filename)
        {
            return IsExtInList(filename, pictureExts);
        }

        private static readonly List<string> documentExts = new List<string> { ".doc", ".docx", ".ppt", ".pot", ".pps", ".pptx", ".xls", ".xlsx", ".pdf", ".tif", ".txt", ".mmap", ".vsd", ".psd", ".ai", ".md", ".dwt", ".dwg", ".dws", ".dxf", ".wps", ".dps", ".dpt", ".pps", ".et", ".xmind", ".cdr", ".project", ".key", ".numbers", ".pages", ".dwg", ".dxf", ".rp", ".pub", ".cal", ".3ds", ".max", ".indd", ".mpp", ".eml", ".log", ".dotx" };
        /// <summary>
        /// 判断是否是可转换文档
        /// </summary>
        public static bool IsDocument(string filename)
        {
            return IsExtInList(filename, documentExts);
        }

        private static readonly List<string> compressExts = new List<string> { ".zip", ".rar", ".7z", ".gz", ".bz2" };
        /// <summary>
        /// 判断是否是压缩文件
        /// </summary>
        public static bool IsCompressFile(string filename)
        {
            return IsExtInList(filename, compressExts);
        }

        private static readonly List<string> localViewExts = new List<string> { ".md", ".txt" };
        /// <summary>
        /// 判断是否是本地预览文件
        /// </summary>
        [Obsolete]
        public static bool IsLocalView(string filename)
        {
            return IsExtInList(filename, localViewExts);
        }

        private static readonly List<string> officeExts = new List<string> { ".doc", ".docx", ".dotx", ".dot", ".dotm", ".xls", ".xlsx", ".xlsm", ".xlm", ".xlsb", ".ppt", ".pptx", ".pps", ".ppsx", ".potx", ".pot", ".pptm", ".potm", ".ppsm", ".pdf" };
        /// <summary>
        /// 判断是否是Office文件
        /// </summary>
        public static bool IsOfficeFile(string filename)
        {
            return IsExtInList(filename, officeExts);
        }

        private static readonly List<string> codeExts = new List<string> { ".html", ".css", ".js", ".sql", ".aspx", ".json", ".jsp", ".do", ".jad", ".ser", ".srz", ".php", ".htm", ".cfm", ".pod", ".xml", ".atomsvc", ".jsf", ".abs", ".pl", ".cod", ".pou", ".luac", ".ejs", ".jse", ".rdf", ".asp", ".lib", ".asm", ".vcxproj", ".js", ".bas", ".arxml", ".hbs", ".fs", ".cms", ".cs", ".vls", ".smali", ".ss", ".scr", ".pyc", ".s", ".ave", ".lxk", ".pdb", ".mrl", ".axd", ".dvb", ".xla", ".src", ".v4e", ".asi", ".dtd", ".form", ".isa", ".spr", ".bat", ".sax", ".rss", ".fmb", ".cgi", ".aia", ".mzp", ".rcc", ".java", ".jdp", ".atp", ".ino", ".idb", ".mrc", ".ipb", ".graphml", ".prg", ".rss", ".mm", ".nupkg", ".py", ".xsd", ".cshtml", ".ws", ".rc", ".scs", ".tra", ".rfs", ".txml", ".c", ".vbp", ".bp", ".cpp", ".prl", ".phtml", ".mwp", ".lua", ".action", ".dwp", ".vlx", ".eaf", ".scb", ".vip", ".sh", ".xlm", ".csb", ".mc", ".cmake", ".resx", ".gypi", ".rbf", ".pyo", ".dpk", ".lss", ".gml", ".sxs", ".gcode", ".rpy", ".sln", ".bdt", ".fas", ".wbf", ".o", ".jsa", ".tcz", ".gnt", ".cpb", ".dep", ".wml", ".au3", ".cmd", ".as", ".liquid", ".pdml", ".aps", ".dbg", ".gp", ".vbs", ".txx", ".csx", ".textile", ".vbe", ".e", ".php3", ".cxx", ".r", ".a5r", ".sm", ".dlg", ".styl", ".bml", ".gbl", ".jsc", ".mac", ".mfa", ".pm", ".ebc", ".mo", ".cbp", ".scpt", ".csc", ".hx", ".rpg", ".pmp", ".asta", ".h", ".arb", ".ins", ".thtml", ".tpl", ".dbmdl", ".cbl", ".stm", ".ipr", ".uvproj", ".xjb", ".qry", ".luca", ".plx", ".wpk", ".xsl", ".fwx", ".ti", ".phl", ".cob", ".pyt", ".hkp", ".smm", ".sasf", ".lap", ".tpm", ".ptl", ".vd", ".dbp", ".cgx", ".xcp", ".mom", ".wbt", ".inc", ".svn", ".obr", ".vcproj", ".lsp", ".pag", ".jks", ".mrd", ".pas", ".h86", ".nvi", ".ats", ".ptx", ".vba", ".wdl", ".pbl", ".rbt", ".perl", ".sfx", ".dwt", ".isu", ".appxupload", ".bxml", ".ary", ".lst", ".dsr", ".dsd", ".vbw", ".vbi", ".cls", ".bmo", ".pbxproj", ".dcr", ".run", ".sct", ".vps", ".sal", ".bcc", ".lmp", ".lol", ".p", ".ptxml", ".wsdl", ".pxml", ".cc", ".f", ".ksh", ".bsc", ".trt", ".bal", ".dpr", ".vbproj", ".gcl", ".asc", ".odc", ".csproj", ".loc", ".dob", ".swift", ".dtx", ".irc", ".dqy", ".sqlproj", ".ctl", ".mg", ".pyw", ".pli", ".dbml", ".ssi", ".ash", ".msha", ".enml", ".acu", ".fxl", ".dsb", ".rptproj", ".mw", ".mhl", ".rb", ".coffee", ".wsf", ".jsx", ".akt", ".axs", ".brml", ".tmh", ".rdf", ".rpyc", ".pym", ".tcl", ".bsv", ".zero", ".htc", ".lpx", ".less", ".gss", ".bin", ".clm", ".vb", ".asz", ".exp", ".a2w", ".nbk", ".ml", ".wmw", ".xme", ".ppam", ".pkb", ".jacl", ".gyp", ".nas", ".rc2", ".rpo", ".rh", ".bpr", ".sbr", ".ssq", ".pbl", ".myapp", ".sca", ".tec", ".pdo", ".arq", ".script", ".bcp", ".x", ".mkb", ".dso", ".bxl", ".dfb", ".nsi", ".ipf", ".ips", ".ebm", ".rml", ".obj", ".m51", ".bb", ".l", ".sdl", ".jsdtscope", ".html5", ".vrp", ".mf", ".ctp", ".sami", ".jsonp", ".tdo", ".vce", ".din", ".cpz", ".pyx", ".cp", ".opv", ".mdp", ".xul", ".zpd", ".cla", ".ppa", ".tru", ".pun", ".jardesc", ".m", ".jml", ".seam", ".c", ".ino", ".ncb", ".mfl", ".hc", ".matlab", ".bgm", ".kst", ".xsc", ".rgs", ".ascx", ".ifp", ".mak", ".ulp", ".psm1", ".nt", ".airi", ".wiki", ".slim", ".cx", ".hs", ".agi", ".tgml", ".sas", ".vddproj", ".gch", ".agc", ".ccs", ".asmx", ".scm", ".mscr", ".dgml", ".s43", ".dfd", ".bzs", ".xslt", ".param", ".amw", ".cba", ".jl", ".mec", ".rws", ".kmt", ".xap", ".pch", ".apb", ".jade", ".txl", ".wxl", ".s5d", ".lds", ".nse", ".nbin", ".pbi", ".datasource", ".drc", ".lnp", ".hxproj", ".ebx", ".xtx", ".tea", ".factorypath", ".bsh", ".fdt", ".zsc", ".vup", ".gld", ".gsc", ".pjt", ".cs", ".ps1", ".devpak", ".brs", ".wxi", ".lmv", ".vxml", ".scss", ".ig", ".wfs", ".ncx", ".smw", ".vdproj", ".rob", ".vbx", ".f95", ".fsx", ".hlsl", ".poc", ".cfi", ".master", ".uix", ".moc", ".msil", ".nlc", ".bsh", ".jcs", ".ksc", ".xn", ".targets", ".odl", ".idl", ".vcp", ".aar", ".bpo", ".ocb", ".xaml", ".gfa", ".classpath", ".vap", ".c", ".phps", ".cos", ".s4e", ".tcz", ".cml", ".inc", ".j", ".qvs", ".ogr", ".pri", ".rrc", ".mcp", ".vssscc", ".dpd", ".astx", ".tsq", ".ppo", ".xcl", ".lml", ".sl", ".diff", ".jgs", ".fcg", ".pickle", ".bash", ".jtb", ".jav", ".gfe", ".tli", ".dfn", ".php2", ".xblr", ".mk", ".ahk", ".php2", ".php5", ".tk", ".qsc", ".cxe", ".a51", ".xfm", ".ane", ".htr", ".swg", ".vstemplate", ".resources", ".rbw", ".cg", ".f90", ".lnx", ".g1m", ".clw", ".owl", ".swt", ".twig", ".ghp", ".xda", ".ilk", ".mke", ".a", ".zpk", ".cspkg", ".xpb", ".cbs", ".zws", ".for", ".ogl", ".mediawiki", ".csp", ".dhtml", ".sxv", ".rule", ".wsdd", ".afb", ".eze", ".make", ".vc6", ".wsc", ".bbf", ".hpf", ".derp", ".ev3p", ".hdf", ".asax", ".c", ".exp", ".rvb", ".hoic", ".sct", ".iml", ".m6m", ".mvba", ".iap", ".pl7", ".kon", ".mel", ".frt", ".pjx", ".xin", ".tur", ".ide", ".mpm", ".mrs", ".ecorediag", ".re", ".rpj", ".dto", ".zbi", ".xui", ".bdh", ".xrc", ".mmb", ".gv", ".wxs", ".fus", ".abap", ".ump", ".gs", ".ebs", ".io", ".vbg", ".cgi", ".beam", ".svo", ".nk", ".hxp", ".npi", ".res", ".ppml", ".vim", ".dev", ".dsym", ".nhs", ".pro", ".pbp", ".amos", ".bxp", ".hom", ".uit", ".maki", ".bs2", ".ddp", ".4ge", ".orl", ".win32manifest", ".xbd", ".tkp", ".xpgt", ".wpm", ".dor", ".sass", ".clp", ".ogs", ".gls", ".appxsym", ".fgb", ".shit", ".lhs", ".fpi", ".phs", ".psl", ".ik", ".gs", ".nxc", ".dot", ".pnproj", ".cxs", ".prg", ".sb", ".rub", ".csh", ".kix", ".sma", ".ywl", ".cpr", ".lisp", ".hse", ".ox", ".aidl", ".appcache", ".history", ".fsi", ".xr", ".pdb", ".dfm", ".galaxy", ".egg", ".elc", ".tla", ".xib", ".sus", ".pspscript", ".sfm", ".awd", ".el", ".coveragexml", ".tag", ".rej", ".gsk", ".class", ".ipch", ".mc", ".m2r", ".coverage", ".wdk", ".4gl", ".vpc", ".proto", ".jsb", ".mxe", ".pl", ".aem", ".ecore", ".lbi", ".qcf", ".cobol", ".pba", ".ijs", ".rvt", ".hms", ".rpym", ".tem", ".jpage", ".vtm", ".saas", ".iss", ".bcf", ".ada", ".pp", ".groovy", ".pf2", ".wsh", ".exsd", ".dsp", ".hsm", ".common", ".psc1", ".plog", ".rdoc", ".scala", ".build", ".clips", ".ked", ".resjson", ".iss", ".applet", ".b", ".pf", ".cd", ".gus", ".qdl", ".zpl", ".scar", ".licx", ".lng", ".pem", ".hic", ".axb", ".pb", ".robo", ".chh", ".zh_tw", ".mmjs", ".jss", ".bbc", ".asp", ".cod", ".dpr", ".depend", ".brx", ".mly", ".fcgi", ".maml", ".okm", ".hxx", ".rts", ".tst", ".gml", ".php1", ".appxmanifest", ".psml", ".ph", ".psu", ".bsm", ".lpr", ".git", ".ghc", ".irobo", ".gc3", ".has", ".spt", ".gxl", ".rkt", ".ftn", ".hh", ".sc", ".tlh", ".phpt", ".textile", ".xmla", ".jak", ".exw", ".dxl", ".oqy", ".smd", ".dht", ".mdf", ".vsmacros", ".pas", ".scz", ".xsql", ".bet", ".tik", ".pro", ".dlg", ".rb", ".snippet", ".xoml", ".ldz", ".asp", ".jcl", ".pfx", ".d4", ".playground", ".deb", ".kex", ".scm", ".vdp", ".mod", ".applescript", ".rfx", ".ebs2", ".cshrc", ".sid", ".wax", ".sjc", ".configure", ".apt", ".cola", ".kbs", ".osg", ".a", ".mmh", ".mcml", ".lrs", ".avsi", ".csm", ".mnd", ".mst", ".sc", ".scb", ".rmn", ".mako", ".rc3", ".li", ".stl", ".tab", ".javajet", ".cl", ".mx", ".rbp", ".epl", ".sbh", ".res", ".zfd", ".mln", ".dsym", ".mp", ".sdi", ".glade", ".fasl", ".mss", ".mod", ".rbx", ".buildpath", ".spx", ".mqt", ".cfml", ".f77", ".rsp", ".ap", ".vmx", ".xtxt", ".usi", ".cfo", ".cls", ".simple", ".v3s", ".fxml", ".php4", ".aro", ".cnt", ".msc", ".dpk", ".js", ".vbscript", ".wdproj", ".login", ".abc", ".ls1", ".m4", ".svc", ".bdsproj", ".gml", ".pwo", ".kcl", ".lrf", ".xnf", ".bhs", ".policy", ".xcodeproj", ".sp", ".wdw", ".hla", ".greenfoot", ".ba_", ".ow", ".bml", ".wis", ".sbs", ".glf", ".reb", ".wod", ".erl", ".w", ".d", ".smx", ".pf1", ".creole", ".ms", ".mat", ".slogt", ".fountain", ".vpi", ".xys", ".aut", ".clw", ".dsq", ".turboc3", ".confluence", ".msl", ".nes", ".xlv", ".wdi", ".cuh", ".ahtml", ".inp", ".rexx", ".sts", ".wpj", ".as3", ".entitlements", ".mca", ".tml", ".xig", ".asf", ".lsp", ".udf", ".mtp", ".qac", ".go", ".a3x", ".mb", ".rqy", ".obj", ".pkh", ".goc", ".bur", ".mash", ".mbas", ".autoplay", ".m3", ".image", ".map", ".hp", ".atmn", ".awk", ".xl", ".~df", ".xhtm", ".cp", ".xamlx", ".htd", ".dcf", ".bpk", ".sdef", ".tsc", ".h2o", ".pom", ".11", ".aml", ".mdp", ".cr", ".ts0", ".ml", ".rnw", ".vc2", ".~pa", ".tql", ".xbl", ".dia", ".qx", ".kv", ".cpy", ".mingw32", ".rxs", ".sno", ".mdex", ".woa", ".mm", ".xbap", ".haml", ".kml", ".thor", ".prg", ".wsd", ".rbs", ".pjt", ".ptl", ".awl", ".jpd", ".graphmlz", ".hbx", ".itcl", ".pp", ".c", ".dbproj", ".pgml", ".bufferedimage", ".ttcn", ".vjp", ".dse", ".hpp", ". vjp", ".dse", ".hpp", ".robo", ".hxml", ".edml", ".ssc", ".gemfile", ".ps2", ".borland", ".zts", ".con", ".ebs", ".tikz", ".poix", ".jbi", ".msm", ".wbc", ".xmap", ".viw", ".dic", ".scm", ".lp", ".odh", ".dws", ".v", ".rsl", ".ixx", ".rbx", ".ex", ".s", ".alx", ".cxt", ".flm", ".hrl", ".clj", ".jcm", ".msvc", ".api_filters", ".tcsh", ".mvc", ".gobj", ".rake", ".ogx", ".b2d", ".dts", ".aplt", ".sas", ".nmk", ".mlsxml", ".dbo", ".dro", ".wmlc", ".smi", ".alg", ".rhtml", ".aex", ".asr", ".dpj", ".idb", ".lex", ".py", ".pcd", ".sym", ".s2s", ".yxx", ".asc", ".epj", ".ekm", ".j3d", ".cod", ".dba", ".avs", ".mss", ".l", ".dwarf", ".mingw", ".dg", ".pgm", ".lamp", ".wam", ".a86", ".cal", ".ii", ".mdf", ".scp", ".vc5", ".apg", ".es", ".ass", ".gsb", ".sf", ".cls", ".orc", ".yab", ".wml", ".zsh", ".ago", ".jsfl", ".ap", ".pf4", ".mex", ".psf", ".pike", ".ch", ".ebs", ".plx", ".t", ".mpx", ".e", ".cgvp", ".sltng", ".bsml", ".avc", ".ll", ".mix", ".pfa", ".was", ".pdl", ".vgc", ".akp", ".mls", ".jsxinc", ".pvs", ".i", ".vsprops", ".ps2xml", ".arnoldc", ".pika", ".mi", ".text", ".pxt", ".xsc", ".dml", ".v", ".sbml", ".h", ".pl1", ".bxb", ".a66", ".y", ".c", ".pde", ".pwn", ".sbi", ".ccbjs", ".c__", ".fgl", ".pls", ".wzs", ".f40", ".actionscript", ".pd", ".kpl", ".vc", ".osax", ".lit", ".pmod", ".acgi", ".mc", ".icl", ".pxl", ".cb", ".hal", ".grxml", ".sconstruct", ".rprofile", ".ods", ".4th", ".a2x", ".cel", ".netboot", ".fpc", ".mscr", ".ht4", ".jsh", ".wmls", ".csh", ".sxt", ".inc", ".csf", ".aso", ".e", ".vad", ".oplm", ".asproj", ".dml", ".vic", ".ocr", ".triple", ".cc", ".mem", ".egg", ".db", ".sjs", ".scptd", ".lo", ".xbc", ".psc2", ".fzs", ".hhh", ".tmo", ".b24", ".hsc", ".csp", ".fp", ".sc", ".spk", ".wcm", ".m4x", ".bps", ".dpr", ".csi", ".plc", ".frs", ".xlm_", ".pf0", ".il", ".armx", ".skp", ".sfl", ".bmml", ".cla", ".tal", ".is", ".rng", ".hxa", ".cod", ".hydra", ".mcr", ".dtml", ".dsa", ".llf", ".mml", ".ism", ".src", ".cfs", ".scp", ".txc", ".3rf", ".car", ".csml", ".ccxml", ".xojo_project", ".f", ".kb", ".p", ".ags", ".rb", ".pxd", ".dt", ".ice", ".unx", ".dcf", ".rsm", ".fdml", ".h", ".js", ".tokend", ".daemonscript", ".cs", ".db2", ".genmodel", ".par", ".dmc", ".ssc", ".asic", ".tilemap", ".gadgeprj", ".bms", ".abl", ".lasso", ".art", ".mcr", ".tpx", ".docstates", ".syp", ".exu", ".m", ".scx", ".asm", ".slt", ".mml", ".clu", ".pc", ".ipp", ".slackbuild", ".hrh", ".psl", ".alm", ".bml", ".vc4", ".neko", ".irbrc", ".mjk", ".bi", ".cya", ".scriptsuite", ".vc7", ".tiprogram", ".gst", ".ac", ".act", ".msh1xml", ".di", ".cvsrc", ".mfps", ".kl3", ".btproj", ".defi", ".h6h", ".v4s", ".pds", ".app", ".opx", ".dd", ".d", ".tpt", ".uih", ".sfp", ".aml", ".jsm", ".rex", ".sqldataprovider", ".tld", ".boo", ".axe", ".cp", ".src", ".bpt", ".cap", ".msdl", ".abs", ".imp", ".eek", ".wsym", ".mscr", ".jomproj", ".rapc", ".forth", ".qlc", ".cap", ".mtx", ".atp", ".vdm", ".fsproj", ".prx", ".msp", ".builder", ".ssml", ".4pk", ".ds", ".ju", ".xmljet", ".frj", ".ipproj", ".lds", ".lay", ".judo", ".c", ".csc", ".radius", ".cas", ".h__", ".icn", ".asbx", ".ssc", ".x", ".box", ".mdp", ".tps", ".pdl", ".gs", ".djg", ".a8s", ".wbs", ".lbj", ".btq", ".xlm4", ".2clk", ".cbq", ".adb", ".pgm", ".dwt", ".dfm", ".sit", ".spr", ".dms", ".trs", ".wix", ".dmb", ".qf", ".sml", ".eqn", ".aep", ".tu", ".nokogiri", ".dc", ".ic", ".osas", ".pdl", ".wch", ".owd", ".wixout", ".alb", ".sda", ".ebuild", ".pri", ".script", ".lols", ".kumac", ".mod", ".pxl", ".texinfo", ".vc1", ".rrh", ".ff", ".msl", ".epp", ".mli", ".generictest", ".wx", ".seman", ".vala", ".rpprj", ".gradle", ".c86", ".atm", ".tlc", ".zfs", ".tal", ".d2j", ".nqc", ".pxi", ".il", ".xmta", ".atl", ".tql", ".e", ".bli", ".wxs", ".es", ".fmt", ".xojo_binary_project", ".spt", ".oks", ".komodo", ".lwa", ".tpr", ".dgsl", ".mab", ".wsil", ".b", ".ll", ".19", ".pdb", ".m", ".anm", ".mbs", ".fxcproj", ".ebs", ".acm", ".adt", ".rakefile", ".qxm", ".msh2xml", ".bsd", ".ook", ".zasm", ".sar", ".vtml", ".dbheader", ".io", ".cma", ".rxs", ".xds", ".lpr", ".erb", ".hay", ".vss", ".for", ".hbz", ".m2", ".mpd", ".rb", ".wmc", ".amf", ".i", ".ad2", ".acr", ".codasite", ".mm", ".b", ".ccp", ".cu", ".pp1", ".ddb", ".dplt", ".rip" };
        /// <summary>
        /// 判断是否代码文件
        /// </summary>
        public static bool IsCodeFile(string filename)
        {
            return IsExtInList(filename, codeExts);
        }

        private static readonly List<string> convertableImageExts = new List<string> { ".psd", ".ai", ".eps", ".ico", ".cur" };
        /// <summary>
        /// 判断是否代码文件
        /// </summary>
        public static bool IsConvertableImageFile(string filename)
        {
            return IsExtInList(filename, convertableImageExts);
        }

        //过滤非法特殊字符
        public static string FilterInvalidPathChars(string filePath)
        {
            var invalidCharList = Path.GetInvalidPathChars().ToList();
            for (int i = filePath.Length - 1; i >= 0; i--)
            {
                if (invalidCharList.Contains(filePath[i]))
                    filePath = filePath.Remove(i, 1);
            }

            return filePath;
        }

        #endregion

        #region 去除字符串中的链接
        /// <summary>
        /// 去除字符串中的链接
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        //public static string RemoveLinkFromMessage(string Message)
        //{
        //    List<string> LinkSart = MD.Business.Common.getMappingString(Message, "<a", ">", 0);
        //    foreach (string LinkStr in LinkSart)
        //    {
        //        Message = Message.Replace("<a" + LinkStr + ">", "\"");
        //    }
        //    Message = Message.Replace("</a>", "\"");
        //    return Message.ToString();
        //}
        #endregion

        #region 去除所有在html元素中标记

        public static string STripHtmlTag(string strhtml)
        {
            string stroutput = strhtml;
            Regex regex = new Regex(@"<[^>]+>|</[^>]+>");
            stroutput = regex.Replace(stroutput, "");
            return stroutput;
        }

        #endregion

              

        #region 筛选DataTable里面的email
        /// <summary>
        /// 筛选DataTable里面的email，返回email@前面的部分中间用"|"隔开
        /// </summary>
        /// <param name="dt">Datatable</param>
        /// <param name="domain"></param>
        /// <returns></returns>
        //public static string ReadFiles(DataTable dt, MD.Entity.Project project)
        //{
        //    string emails = "";
        //    List<string> Domails = GetProjectDomains(project);
        //    List<string> mailList = new List<string>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        for (int i = 0; i < dt.Columns.Count; i++)
        //        {
        //            if (dr[i] != null && dr[i] != DBNull.Value)
        //            {
        //                string email = dr[i].ToString();
        //                if (MD.Business.Web.Function.ValidateEmail(email) && !mailList.Contains(email))
        //                {
        //                    if (project.License.LicenseType == MD.Enum.LicenseType.Free)
        //                    {
        //                        if (Domails.Contains(email.Substring(email.IndexOf("@") + 1)))
        //                        {
        //                            mailList.Add(email);
        //                            emails += email + "|";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        mailList.Add(email);
        //                        emails += email + "|";
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    return emails;
        //}
        #endregion

        #region 筛选文本里的email
        //根据文本框里的内容，筛选出本公司的email，用"|"隔开返回
        //public static string ReadMails(string content, MD.Entity.Project project)
        //{
        //    content = content.Replace("\r", "\n").Replace("\n", "|").
        //        Replace("\t", "|").Replace("  ", "").
        //        Replace(" ", "|").Replace(",", "|").
        //        Replace("<", "|").Replace(">", "|").
        //        Replace("[", "|").Replace("]", "|").
        //        Replace("【", "|").Replace("】", "|").
        //        Replace(":", "|");

        //    List<string> Domails = GetProjectDomains(project);
        //    string mails = "";
        //    List<string> list = new List<string>(content.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries));
        //    List<string> mailList = new List<string>();
        //    foreach (string item in list)
        //    {
        //        if (MD.Business.Web.Function.ValidateEmail(item) && !mailList.Contains(item))
        //        {
        //            if (project.License.LicenseType == MD.Enum.LicenseType.Free)
        //            {
        //                if (Domails.Contains(item.Substring(item.IndexOf("@") + 1)))
        //                {
        //                    mailList.Add(item);
        //                    mails += item + "|";
        //                }
        //            }
        //            else
        //            {
        //                mailList.Add(item);
        //                mails += item + "|";
        //            }
        //        }
        //    }
        //    return mails;
        //}
        #endregion

        #region 表情符替换
        public static string CreateFaceForMessage(string message)
        {
            List<string> faceArgs = new List<string>();
            faceArgs.Add("呵呵|wx_thumb.gif");
            faceArgs.Add("哈哈|hanx_thumb.gif");
            faceArgs.Add("泪|lei_thumb.gif");
            faceArgs.Add("糗|qiu_thumb.gif");
            faceArgs.Add("偷笑|tx_thumb.gif");
            faceArgs.Add("可爱|ka_thumb.gif");
            faceArgs.Add("得意|dy_thumb.gif");
            faceArgs.Add("花心|se_thumb.gif");
            faceArgs.Add("失望|ng_thumb.gif");
            faceArgs.Add("鼓掌|gz_thumb.gif");
            faceArgs.Add("疑问|yw_thumb.gif");
            faceArgs.Add("吐|tu_thumb.gif");
            faceArgs.Add("顶|qiao_thumb.gif");
            faceArgs.Add("握手|handshake.gif");
            faceArgs.Add("耶|yeah.gif");
            faceArgs.Add("Good|good.gif");
            faceArgs.Add("差劲|small.gif");
            faceArgs.Add("OK|ok.gif");
            faceArgs.Add("蛋糕|cake.gif");
            faceArgs.Add("心|heart.gif");
            faceArgs.Add("心碎|unheart.gif");
            faceArgs.Add("玫瑰|rose.gif");
            faceArgs.Add("礼物|gift.gif");
            faceArgs.Add("太阳|sun.gif");
            faceArgs.Add("威武|vw_thumb.gif");

            string facePath = VirtualPathUtility.ToAbsolute("~/") + "images/face/";
            string replaceStr = message;
            for (int i = 0; i < faceArgs.Count; i++)
            {
                string faceItem = faceArgs[i];
                string faceName = faceItem.Split('|')[0].ToLower();
                string faceImgUrl = faceItem.Split('|')[1];
                if (message.ToLower().Contains("[" + faceName + "]"))
                {
                    replaceStr = replaceStr.Replace("[" + faceName + "]", "<img alt=\"" + faceName + "\" width=\"22px\" height=\"22px\" align=\"absbottom\" src=\"" + facePath + faceImgUrl + "\"/>");
                }
            }
            return replaceStr;
        }
        #endregion

        #region 过滤定义的非法字符

        private static string[] filterStrs = new string[] { ",", "\\", "/", ":", "*", "'", "?", "\"", "<", ">", "|" };
        public static string FilterStr(string str)
        {
            foreach (string filterChar in filterStrs)
            {
                str = str.Replace(filterChar, string.Empty);
            }
            return str;
        }
        #endregion

        #region 将字符串分割成数组
        /// <summary>
        /// 将字符串分割成数组  lio 2012-3-13
        /// </summary>
        /// <param name="strSource"></param>
        /// <param name="strSplit"></param>
        /// <returns></returns>
        public static string[] StringSplit(string strSource, string strSplit)
        {
            string[] strtmp = new string[1]; int index = strSource.IndexOf(strSplit, 0); if (index < 0)
            { strtmp[0] = strSource; return strtmp; }
            else
            {
                strtmp[0] = strSource.Substring(0, index);
                return StringSplit(strSource.Substring(index + strSplit.Length), strSplit, strtmp);
            }
        }
        public static string[] StringSplit(string strSource, string strSplit, string[] attachArray)
        {
            string[] strtmp = new string[attachArray.Length + 1];
            attachArray.CopyTo(strtmp, 0); int index = strSource.IndexOf(strSplit, 0); if (index < 0)
            { strtmp[attachArray.Length] = strSource; return strtmp; }
            else
            {
                strtmp[attachArray.Length] = strSource.Substring(0, index); return StringSplit(strSource.Substring(index + strSplit.Length), strSplit, strtmp);
            }
        }
        #endregion

        #region 按字节数截取字符串
        /// <summary>
        /// 按字节数截取字符串
        /// </summary>
        public static string CutString(string source, int len)
        {
            string temp = string.Empty;
            if (System.Text.Encoding.Default.GetByteCount(source) <= len)
            {
                return source;
            }
            else
            {
                int t = 0;
                char[] q = source.ToCharArray();
                for (int i = 0; i < q.Length; i++)
                {
                    if ((int)q[i] >= 0x4E00 && (int)q[i] <= 0x9FA5)
                    {
                        temp += q[i];
                        t += 2;
                    }
                    else
                    {
                        temp += q[i];
                        t += 1;
                    }
                    if (t >= len - 3)
                        return temp + "...";
                }
                return temp;
            }
        }

        #endregion

        

        

        #region 获取网络主域名和绑定的二级域名的集合
        //public static List<string> GetProjectDomains(MD.Entity.Project project)
        //{
        //    List<string> domains = new List<string>();

        //    var projectSettings = MD.Caching.ProjectSettingCache.GetProjectSetting(project.ProjectID);

        //    if (!string.IsNullOrEmpty(projectSettings.BaseAuthenticationDomain))
        //    {
        //        domains.Add(projectSettings.BaseAuthenticationDomain);
        //    }
        //    if (!string.IsNullOrEmpty(projectSettings.ProjectAuthenticationDomain))
        //    {
        //        List<string> subDomains = new List<string>(projectSettings.ProjectAuthenticationDomain.ToLower().Split(new string[] { "|", "," }, StringSplitOptions.RemoveEmptyEntries));
        //        domains.AddRange(subDomains);
        //    }
        //    return domains;
        //}
        #endregion

        #region 根据URL获取网址的主域名
        /// <summary>
        /// 根据URL获取网址的主域名
        /// </summary>
        //public static string getRootDomain(string url)
        //{
        //    List<string> reList = new List<string>();
        //    if (!string.IsNullOrEmpty(url))
        //    {
        //        string regexExpression = "(?<Value>[\\w-]+\\.(com|net|org|gov|cc|biz|info|cn|co)\\b()*)";
        //        MD.Framework.AsynchronousRegex asyncRegex;
        //        Regex regex;
        //        MatchCollection matchs;
        //        try
        //        {
        //            // 异步正则对象
        //            asyncRegex = new MD.Framework.AsynchronousRegex(500);

        //            //构造正则对象
        //            regex = new System.Text.RegularExpressions.Regex(regexExpression);

        //            //匹配字符串
        //            matchs = asyncRegex.Matchs(regex, url);

        //            //匹配超时返回空列表
        //            if (!asyncRegex.IsTimeout)
        //            {
        //                //在匹配结果集中循环。
        //                foreach (Match match in matchs)
        //                {
        //                    System.Text.RegularExpressions.Group grp = match.Groups["Value"];
        //                    reList.Add(grp.Value);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }
        //    if (reList.Count > 0)
        //        return reList[0];
        //    else
        //        return string.Empty;

        //}
        #endregion

        #region 判断是否是移动设备
        /// <summary>
        /// 判断是否是移动设备
        /// </summary>
        //public static bool isMobileBrowser()
        //{
        //    return MD.Framework.Common.IsMobileDevice(System.Web.HttpContext.Current.Request);
        //}
        #endregion

        

        #region 获取反向代理之后的真实IP地址
        /// <summary>
        /// 获取真实IP地址
        /// </summary>
        public static string GetRealIPAddress()
        {
            return string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Headers.Get("X-Real-IP")) ? System.Web.HttpContext.Current.Request.UserHostAddress : System.Web.HttpContext.Current.Request.Headers["X-Real-IP"];
        }
        #endregion

        #region 验证验证码
        public static bool ValidateVerifyCode(string code)
        {
            var session = System.Web.HttpContext.Current.Session;
            if ((session != null) && (session["mdVerifyCode"] != null))
            {
                string verifycode = session["mdVerifyCode"].ToString();

                if (!string.IsNullOrWhiteSpace(verifycode) && code.ToLower() == verifycode.ToLower())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 获取某用户的未读数

        /// <summary>
        /// 获取某用户的未读数（提到我的+私信）
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static int GetUserUnReadCountWithMentionedAndMessage(string userID)
        {
            string ResponseData = null;
            string Url = System.Web.Configuration.WebConfigurationManager.AppSettings["MD.MQ.Servers"] + "/notification/get?key=" + userID;
            HttpWebRequest WebReq = WebRequest.Create(Url) as HttpWebRequest;
            WebReq.Method = "GET";
            WebReq.ServicePoint.Expect100Continue = false;
            WebReq.Timeout = 20000;

            StreamReader Reader = null;
            try
            {
                Reader = new StreamReader(WebReq.GetResponse().GetResponseStream());
                ResponseData = Reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                WebReq.GetResponse().GetResponseStream().Close();
                Reader.Close();
                Reader = null;
                WebReq = null;
            }
            finally
            {

                WebReq.GetResponse().GetResponseStream().Close();
                Reader.Close();
                Reader = null;
                WebReq = null;
            }

            if (string.IsNullOrEmpty(ResponseData))
                return 0;
            else
            {
                ResponseData = ResponseData.Replace("undefined(", "").Replace(")", "");
                JObject JObject = (JObject)JsonConvert.DeserializeObject(ResponseData);
                JArray JArray = (JArray)JObject["Users"];
                JObject = (JObject)JArray[0];

                return int.Parse(JObject["mentioned"].ToString()) + int.Parse(JObject["message"].ToString());
            }
        }
        #endregion

        #region 执行http请求

        /// <summary>
        /// POST方式发送得结果
        /// </summary>
        public static string DoPostRequest(string url, byte[] bData)
        {
            System.Net.HttpWebRequest hwRequest;
            System.Net.HttpWebResponse hwResponse;

            string strResult = string.Empty;
            try
            {
                hwRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                hwRequest.Timeout = 10000;
                hwRequest.Method = "POST";
                hwRequest.ContentType = "application/x-www-form-urlencoded";
                hwRequest.ContentLength = bData.Length;

                System.IO.Stream smWrite = hwRequest.GetRequestStream();
                smWrite.Write(bData, 0, bData.Length);
                smWrite.Close();

                hwResponse = (HttpWebResponse)hwRequest.GetResponse();
                System.Text.Encoding encode = Encoding.ASCII;
                if (hwResponse.CharacterSet.Contains("utf-8"))
                    encode = Encoding.UTF8;
                StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), encode);
                strResult = srReader.ReadToEnd();
                srReader.Close();
                hwResponse.Close();
            }
            catch (System.Exception err)
            {
            }

            return strResult;
        }

        /// <summary>
        /// GET方式发送得结果
        /// </summary>
        public static string DoGetRequest(string url)
        {
            HttpWebRequest hwRequest;
            HttpWebResponse hwResponse;

            string strResult = string.Empty;
            try
            {
                hwRequest = (System.Net.HttpWebRequest)WebRequest.Create(url);
                hwRequest.Timeout = 10000;
                hwRequest.Method = "GET";
                hwRequest.ContentType = "application/x-www-form-urlencoded";

                hwResponse = (HttpWebResponse)hwRequest.GetResponse();
                System.Text.Encoding encode = Encoding.ASCII;
                if (hwResponse.CharacterSet.Contains("utf-8"))
                    encode = Encoding.UTF8;
                StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), encode);
                strResult = srReader.ReadToEnd();
                srReader.Close();
                hwResponse.Close();
            }
            catch (System.Exception err)
            {

            }

            return strResult;
        }

        #endregion

        

        #region 判断是否支持html5(等待实现....)
        /// <summary>
        /// 判断是否支持html5
        /// </summary>
        public static bool isHtml5Browser()
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;

            bool isHtml5 = true;

            isHtml5 = Regex.IsMatch(request.Browser.Browser, "(?is)firefox|chrome|safari|opera");

            return isHtml5;
        }
        #endregion

        #region 集合转成搜索条件

        /// <summary>
        /// 集合转成搜索条件
        /// </summary>
        public static string ListToString<T>(List<T> list, char departChar)
        {
            string listStr = string.Empty;
            if (list != null && list.Count > 0)
            {
                foreach (T tType in list)
                {
                    if (!string.IsNullOrEmpty(tType.ToString().Trim()))
                        listStr += tType.ToString().Trim() + departChar.ToString();
                }
            }
            return listStr.Trim(departChar);
        }

        #endregion

        #region 获取登入后转跳链接

        /// <summary>
        /// 获取登入后转跳链接
        /// </summary>
        public static string GetRedirectUrl(string returnUrl)
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;

            string url = string.Empty;
            if (request.Url.ToString().Contains(".mingdao.com"))
            {
                url = Function.WebUrl;
            }
            else
            {
                url = request.Url.Scheme + "://" + request.Url.Authority + Function.VirtualPath;
                if (returnUrl.Contains("http"))//非法Url
                    returnUrl = string.Empty;
            }

            string indexPage = "chat";

            if (string.IsNullOrEmpty(returnUrl))
                url += indexPage;
            else
                url = returnUrl;

            return url;
        }

        #endregion

        #region 获取时间戳
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        #endregion

        #region AppSettingsHelper
        /// <summary>
        /// 读取AppSetting配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
        #endregion

        #region 手机验证码
        /// <summary>
        /// 发送手机验证码
        /// </summary>
        /// <param name="phoneNumber">手机号码</param>
        /// <param name="type">Enum 短信 或语音</param>
        /// <param name="message">短信开头语句</param>
        /// <param name="verifyCodeLength">验证码长度</param>
        /// <returns></returns>
        //public static bool SendVerifyCode(string phoneNumber, MD.Enum.VerifyCodeType type, string message, int verifyCodeLength)
        //{
        //    string code = string.Empty;
        //    Random rand = new Random();
        //    string msgStr = null;
        //    if (message == null)
        //    {
        //        msgStr = "明道欢迎你";
        //    }
        //    else
        //    {
        //        msgStr = message;
        //    }
        //    MD.SmsSender.Common.SendStatus status = MD.SmsSender.Common.SendStatus.Failed;
        //    if (type == MD.Enum.VerifyCodeType.SMS) //短信验证码
        //    {
        //        for (int i = 0; i < verifyCodeLength; i++)
        //            code += rand.Next(0, 10);

        //        MD.SmsSender.Sender sender = new MD.SmsSender.Sender(MD.SmsSender.Common.SendSP.YTWW);
        //        status = sender.SendMessage(phoneNumber, string.Format("{0}{1}", msgStr, code + "（您的验证代码），感谢您的使用，如需帮助请拨打 400-021-6464 "));
        //    }
        //    else if (type == MD.Enum.VerifyCodeType.Voice) //语音验证码
        //    {
        //        for (int i = 0; i < verifyCodeLength; i++)
        //            code += rand.Next(0, 10);

        //        MD.SmsSender.Yuntongxun yuntongxun = new MD.SmsSender.Yuntongxun();
        //        status = yuntongxun.SendVoiceVerifyCode(phoneNumber, code, 2);
        //    }

        //    //设置code缓存
        //    SetVerifyCodeCache(type, phoneNumber, code);

        //    if (status == MD.SmsSender.Common.SendStatus.Success)
        //        return true;
        //    else
        //        return false;
        //}
        /// <summary>
        /// 设置验证码memcache缓存
        /// </summary>
        //private static void SetVerifyCodeCache(MD.Enum.VerifyCodeType verifyCodeType, string mobilePhone, string code)
        //{
        //    string key = string.Empty;
        //    if (verifyCodeType == MD.Enum.VerifyCodeType.SMS)
        //        key = MD.Business.Project.GetCacheKey(MD.Enum.CacheKeyType.RegisterSMSVerify, mobilePhone, string.Empty);
        //    else
        //        key = MD.Business.Project.GetCacheKey(MD.Enum.CacheKeyType.RegisterVoiceVerify, mobilePhone, string.Empty);
        //    //30分钟
        //    MD.Memcached.Utils.CacheClient.Set(key, code, DateTime.Now.AddMinutes(30));
        //}
        /// <summary>
        /// 验证验证码
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <payanram name="codeNumber"></param>
        /// <returns></returns>
        //public static bool VerifyCode(string phoneNumber, string codeNumber)
        //{
        //    string smsKey = MD.Business.Project.GetCacheKey(MD.Enum.CacheKeyType.RegisterSMSVerify, phoneNumber, string.Empty);
        //    object smsCacheObj = MD.Memcached.Utils.CacheClient.Get(smsKey);
        //    string registerSMSCacheValue = string.Empty;
        //    if (smsCacheObj != null)
        //        registerSMSCacheValue = smsCacheObj as string;

        //    //语音code
        //    string voiceKey = MD.Business.Project.GetCacheKey(MD.Enum.CacheKeyType.RegisterVoiceVerify, phoneNumber, string.Empty);
        //    object voiceCacheObj = MD.Memcached.Utils.CacheClient.Get(voiceKey);
        //    string voiceCacheValue = string.Empty;
        //    if (voiceCacheObj != null)
        //        voiceCacheValue = voiceCacheObj as string;

        //    if (codeNumber.Equals(registerSMSCacheValue, StringComparison.OrdinalIgnoreCase) || codeNumber.Equals(voiceCacheValue, StringComparison.OrdinalIgnoreCase))
        //        return true;
        //    return false;
        //}
        #endregion

        #region 获取到期剩余的秒数
        public static uint GetDayLeftSeconds(int days = 1)
        {
            return Convert.ToUInt32((DateTime.Today.AddDays(days) - DateTime.Now).TotalSeconds);
        }
        #endregion

        #region 七牛文件 辅助方法

        /// <summary>
        /// 获取文件后缀
        /// </summary>
        /// <returns></returns>
        //public static string GetQiniuPictureName(MD.Enum.ImageGrade imageGrade, string fileName, string serverName)
        //{

        //    if (imageGrade != MD.Enum.ImageGrade.Original && !fileName.Contains("imageView2"))
        //    {
        //        var picParam = string.Empty;

        //        switch (imageGrade)
        //        {
        //            case MD.Enum.ImageGrade.Small:
        //                picParam = "?imageView2/1/w/130/h/90";
        //                break;
        //            case MD.Enum.ImageGrade.Middle:
        //                picParam = "?imageView2/1/w/470/h/312";
        //                break;
        //            case MD.Enum.ImageGrade.Large:
        //                picParam = "?imageView2/2/w/1280/h/800";
        //                break;
        //            default:
        //                break;
        //        }
        //        fileName += picParam;
        //    }
        //    return fileName;
        //}

        public static string GetQiniuPictureName(string url, uint mode, uint width, uint height, uint quality = 90)
        {
            if (url.Contains("qbox.me"))
            {
                if (url.Contains("?")) { url += "&"; }
                else { url += "?"; }
                url += "imageView2/" + mode + "/w/" + width + "/h/" + height + "/q/" + quality;
            }
            return url;
        }
        /// <summary>
        /// 替换成七牛server
        /// </summary>
        //public static string ReplaceToQiniuServerPath(string serverPath, MD.Enum.AttachmentType attachmentType)
        //{
        //    string pattern = "(http(s)?://file[1|2|3].mingdao.com)";
        //    Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
        //    if (regex.IsMatch(serverPath))
        //    {
        //        return regex.Replace(serverPath, attachmentType == MD.Enum.AttachmentType.Picture ? qiniuMDPicUrl : qiniuMDDocUrl);
        //    }
        //    return serverPath;
        //}

        #endregion

        #region 是否绑定微信
        //public static JObject CheckBindWeixin(string userID)
        //{
        //    string weiXinUrl = ConfigurationManager.AppSettings["WeiXinUrl"];
        //    string url = weiXinUrl + "/notification/get?u=" + userID;
        //    string responseData = MD.Business.Common.DoGetRequest(url);
        //    if (!string.IsNullOrEmpty(responseData))
        //    {
        //        return (JObject)JsonConvert.DeserializeObject(responseData);
        //    }
        //    return null;
        //}
        #endregion

        #region 递归获取城市名称  如：湖南省/株洲市/芦淞区

        //public static void GetGeographyList(MD.Entity.FixedData fixedData, List<string> geographyList)
        //{
        //    if (geographyList == null)
        //        geographyList = new List<string>();

        //    if (fixedData != null)
        //    {
        //        geographyList.Add(fixedData.Name);

        //        if (!string.IsNullOrEmpty(fixedData.ParentID))
        //        {
        //            var parentFixedData = MD.Business.Unit.GetGeographyDetail(fixedData.ParentID);
        //            GetGeographyList(parentFixedData, geographyList);
        //        }
        //    }
        //}

        #endregion

        #region ListHelper
        /// <summary>
        /// 泛型数据转换成分隔符字符串
        /// </summary>
        /// <param name="List">数组</param>
        /// <param name="includeBy">包含数据的字符</param>
        /// <param name="splitChar">分隔符</param>
        /// <returns></returns>
        public static string ListToStr<T>(List<T> List, string includeBy, string splitChar)
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in List)
            {
                sb.AppendFormat("{1}{0}{1},", item, includeBy);
            }

            return sb.ToString().Trim(char.Parse(splitChar));
        }

        #endregion

        #region 随机数字符串

        public static string GetRandomNumberStr(int count)
        {
            List<string> codeList = new List<string>();
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                codeList.Add(rand.Next(0, 10).ToString());
            }
            return string.Join("", codeList.ToArray());
        }

        #endregion

        

        #region 根据Attachment JSON创建对象集合

        [System.Obsolete]
        public static string GetJsObjValue(JObject obj, string key)
        {
            var token = obj.GetValue(key, StringComparison.InvariantCultureIgnoreCase);
            return token == null ? string.Empty : token.ToString();
        }

        

        #endregion


        #region 根据Url下载文件到本地

        public static void DownLoadFileByUrl(string url, string savePath, string fileName)
        {
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream reader = response.GetResponseStream();
            FileStream writer = new FileStream(savePath + fileName, FileMode.OpenOrCreate, FileAccess.Write);
            byte[] buff = new byte[512];
            int c = 0;
            while ((c = reader.Read(buff, 0, buff.Length)) > 0)
            {
                writer.Write(buff, 0, c);
            }
            writer.Close();
            writer.Dispose();
            reader.Close();
            reader.Dispose();
            response.Close();
        }

        #endregion



    }
}
