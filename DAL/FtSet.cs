using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CdHotelManage.DAL
{
    /// <summary>
    /// 数据访问类:FtSet
    /// </summary>
    public partial class FtSet
    {
        public FtSet()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FtSet");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CdHotelManage.Model.FtSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FtSet(");
            strSql.Append("Lwidth,Lhieght,Lfontf,Fontsize,Lmargin,Backcolor,Bordercolor,showType,showPrice,orderLC,ftNum,zzShowType,zzShowPrice,showFormTime,showLFico,showBmico,showyjb,showday,daynum,showyue,moneyNum,showcf,showThem,Themtext,showMember,memberText,showXy,showYuli,yuliDay,showDayTime,dayNumYl,showxz,showSf,showYuee,Showzdftime,Showbooktime,Showzf,Showlc,showPeoNum,showRk,showWupi,Showyz,Showmf,Showzdf,Beiy,Beiy2,numSize,numColor,fxSize,fxColor,yueSize,yueColor,nameSize,nameColor,priceSize,priceColor,TotimeSize,TotimeColor,zdSize,zdColor,icoColor)");
            strSql.Append(" values (");
            strSql.Append("@Lwidth,@Lhieght,@Lfontf,@Fontsize,@Lmargin,@Backcolor,@Bordercolor,@showType,@showPrice,@orderLC,@ftNum,@zzShowType,@zzShowPrice,@showFormTime,@showLFico,@showBmico,@showyjb,@showday,@daynum,@showyue,@moneyNum,@showcf,@showThem,@Themtext,@showMember,@memberText,@showXy,@showYuli,@yuliDay,@showDayTime,@dayNumYl,@showxz,@showSf,@showYuee,@Showzdftime,@Showbooktime,@Showzf,@Showlc,@showPeoNum,@showRk,@showWupi,@Showyz,@Showmf,@Showzdf,@Beiy,@Beiy2,@numSize,@numColor,@fxSize,@fxColor,@yueSize,@yueColor,@nameSize,@nameColor,@priceSize,@priceColor,@TotimeSize,@TotimeColor,@zdSize,@zdColor,@icoColor)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Lwidth", SqlDbType.Int,4),
					new SqlParameter("@Lhieght", SqlDbType.Int,4),
					new SqlParameter("@Lfontf", SqlDbType.NVarChar,50),
					new SqlParameter("@Fontsize", SqlDbType.Int,4),
					new SqlParameter("@Lmargin", SqlDbType.Int,4),
					new SqlParameter("@Backcolor", SqlDbType.NVarChar,50),
					new SqlParameter("@Bordercolor", SqlDbType.NVarChar,50),
					new SqlParameter("@showType", SqlDbType.Bit,1),
					new SqlParameter("@showPrice", SqlDbType.Bit,1),
					new SqlParameter("@orderLC", SqlDbType.Bit,1),
					new SqlParameter("@ftNum", SqlDbType.Int,4),
					new SqlParameter("@zzShowType", SqlDbType.Bit,1),
					new SqlParameter("@zzShowPrice", SqlDbType.Bit,1),
					new SqlParameter("@showFormTime", SqlDbType.Bit,1),
					new SqlParameter("@showLFico", SqlDbType.Bit,1),
					new SqlParameter("@showBmico", SqlDbType.Bit,1),
					new SqlParameter("@showyjb", SqlDbType.Bit,1),
					new SqlParameter("@showday", SqlDbType.Bit,1),
					new SqlParameter("@daynum", SqlDbType.Int,4),
					new SqlParameter("@showyue", SqlDbType.Bit,1),
					new SqlParameter("@moneyNum", SqlDbType.Int,4),
					new SqlParameter("@showcf", SqlDbType.Bit,1),
					new SqlParameter("@showThem", SqlDbType.Bit,1),
					new SqlParameter("@Themtext", SqlDbType.NVarChar,10),
					new SqlParameter("@showMember", SqlDbType.Bit,1),
					new SqlParameter("@memberText", SqlDbType.NVarChar,10),
					new SqlParameter("@showXy", SqlDbType.Bit,1),
					new SqlParameter("@showYuli", SqlDbType.Bit,1),
					new SqlParameter("@yuliDay", SqlDbType.Bit,1),
					new SqlParameter("@showDayTime", SqlDbType.Bit,1),
					new SqlParameter("@dayNumYl", SqlDbType.Int,4),
					new SqlParameter("@showxz", SqlDbType.Bit,1),
					new SqlParameter("@showSf", SqlDbType.Bit,1),
					new SqlParameter("@showYuee", SqlDbType.Bit,1),
					new SqlParameter("@Showzdftime", SqlDbType.Bit,1),
					new SqlParameter("@Showbooktime", SqlDbType.Bit,1),
					new SqlParameter("@Showzf", SqlDbType.Bit,1),
					new SqlParameter("@Showlc", SqlDbType.Bit,1),
					new SqlParameter("@showPeoNum", SqlDbType.Bit,1),
					new SqlParameter("@showRk", SqlDbType.Bit,1),
					new SqlParameter("@showWupi", SqlDbType.Bit,1),
					new SqlParameter("@Showyz", SqlDbType.Bit,1),
					new SqlParameter("@Showmf", SqlDbType.Bit,1),
					new SqlParameter("@Showzdf", SqlDbType.Bit,1),
					new SqlParameter("@Beiy", SqlDbType.Bit,1),
					new SqlParameter("@Beiy2", SqlDbType.Bit,1),
					new SqlParameter("@numSize", SqlDbType.Int,4),
					new SqlParameter("@numColor", SqlDbType.NVarChar,10),
					new SqlParameter("@fxSize", SqlDbType.Int,4),
					new SqlParameter("@fxColor", SqlDbType.NVarChar,10),
					new SqlParameter("@yueSize", SqlDbType.Int,4),
					new SqlParameter("@yueColor", SqlDbType.NVarChar,10),
					new SqlParameter("@nameSize", SqlDbType.Int,4),
					new SqlParameter("@nameColor", SqlDbType.NVarChar,10),
					new SqlParameter("@priceSize", SqlDbType.Int,4),
					new SqlParameter("@priceColor", SqlDbType.NVarChar,10),
					new SqlParameter("@TotimeSize", SqlDbType.Int,4),
					new SqlParameter("@TotimeColor", SqlDbType.NVarChar,10),
					new SqlParameter("@zdSize", SqlDbType.Int,4),
					new SqlParameter("@zdColor", SqlDbType.NVarChar,10),
					new SqlParameter("@icoColor", SqlDbType.Int,4)};
            parameters[0].Value = model.Lwidth;
            parameters[1].Value = model.Lhieght;
            parameters[2].Value = model.Lfontf;
            parameters[3].Value = model.Fontsize;
            parameters[4].Value = model.Lmargin;
            parameters[5].Value = model.Backcolor;
            parameters[6].Value = model.Bordercolor;
            parameters[7].Value = model.showType;
            parameters[8].Value = model.showPrice;
            parameters[9].Value = model.orderLC;
            parameters[10].Value = model.ftNum;
            parameters[11].Value = model.zzShowType;
            parameters[12].Value = model.zzShowPrice;
            parameters[13].Value = model.showFormTime;
            parameters[14].Value = model.showLFico;
            parameters[15].Value = model.showBmico;
            parameters[16].Value = model.showyjb;
            parameters[17].Value = model.showday;
            parameters[18].Value = model.daynum;
            parameters[19].Value = model.showyue;
            parameters[20].Value = model.moneyNum;
            parameters[21].Value = model.showcf;
            parameters[22].Value = model.showThem;
            parameters[23].Value = model.Themtext;
            parameters[24].Value = model.showMember;
            parameters[25].Value = model.memberText;
            parameters[26].Value = model.showXy;
            parameters[27].Value = model.showYuli;
            parameters[28].Value = model.yuliDay;
            parameters[29].Value = model.showDayTime;
            parameters[30].Value = model.dayNumYl;
            parameters[31].Value = model.showxz;
            parameters[32].Value = model.showSf;
            parameters[33].Value = model.showYuee;
            parameters[34].Value = model.Showzdftime;
            parameters[35].Value = model.Showbooktime;
            parameters[36].Value = model.Showzf;
            parameters[37].Value = model.Showlc;
            parameters[38].Value = model.showPeoNum;
            parameters[39].Value = model.showRk;
            parameters[40].Value = model.showWupi;
            parameters[41].Value = model.Showyz;
            parameters[42].Value = model.Showmf;
            parameters[43].Value = model.Showzdf;
            parameters[44].Value = model.Beiy;
            parameters[45].Value = model.Beiy2;
            parameters[46].Value = model.numSize;
            parameters[47].Value = model.numColor;
            parameters[48].Value = model.fxSize;
            parameters[49].Value = model.fxColor;
            parameters[50].Value = model.yueSize;
            parameters[51].Value = model.yueColor;
            parameters[52].Value = model.nameSize;
            parameters[53].Value = model.nameColor;
            parameters[54].Value = model.priceSize;
            parameters[55].Value = model.priceColor;
            parameters[56].Value = model.TotimeSize;
            parameters[57].Value = model.TotimeColor;
            parameters[58].Value = model.zdSize;
            parameters[59].Value = model.zdColor;
            parameters[60].Value = model.icoColor;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CdHotelManage.Model.FtSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FtSet set ");
            strSql.Append("Lwidth=@Lwidth,");
            strSql.Append("Lhieght=@Lhieght,");
            strSql.Append("Lfontf=@Lfontf,");
            strSql.Append("Fontsize=@Fontsize,");
            strSql.Append("Lmargin=@Lmargin,");
            strSql.Append("Backcolor=@Backcolor,");
            strSql.Append("Bordercolor=@Bordercolor,");
            strSql.Append("showType=@showType,");
            strSql.Append("showPrice=@showPrice,");
            strSql.Append("orderLC=@orderLC,");
            strSql.Append("ftNum=@ftNum,");
            strSql.Append("zzShowType=@zzShowType,");
            strSql.Append("zzShowPrice=@zzShowPrice,");
            strSql.Append("showFormTime=@showFormTime,");
            strSql.Append("showLFico=@showLFico,");
            strSql.Append("showBmico=@showBmico,");
            strSql.Append("showyjb=@showyjb,");
            strSql.Append("showday=@showday,");
            strSql.Append("daynum=@daynum,");
            strSql.Append("showyue=@showyue,");
            strSql.Append("moneyNum=@moneyNum,");
            strSql.Append("showcf=@showcf,");
            strSql.Append("showThem=@showThem,");
            strSql.Append("Themtext=@Themtext,");
            strSql.Append("showMember=@showMember,");
            strSql.Append("memberText=@memberText,");
            strSql.Append("showXy=@showXy,");
            strSql.Append("showYuli=@showYuli,");
            strSql.Append("yuliDay=@yuliDay,");
            strSql.Append("showDayTime=@showDayTime,");
            strSql.Append("dayNumYl=@dayNumYl,");
            strSql.Append("showxz=@showxz,");
            strSql.Append("showSf=@showSf,");
            strSql.Append("showYuee=@showYuee,");
            strSql.Append("Showzdftime=@Showzdftime,");
            strSql.Append("Showbooktime=@Showbooktime,");
            strSql.Append("Showzf=@Showzf,");
            strSql.Append("Showlc=@Showlc,");
            strSql.Append("showPeoNum=@showPeoNum,");
            strSql.Append("showRk=@showRk,");
            strSql.Append("showWupi=@showWupi,");
            strSql.Append("Showyz=@Showyz,");
            strSql.Append("Showmf=@Showmf,");
            strSql.Append("Showzdf=@Showzdf,");
            strSql.Append("Beiy=@Beiy,");
            strSql.Append("Beiy2=@Beiy2,");
            strSql.Append("numSize=@numSize,");
            strSql.Append("numColor=@numColor,");
            strSql.Append("fxSize=@fxSize,");
            strSql.Append("fxColor=@fxColor,");
            strSql.Append("yueSize=@yueSize,");
            strSql.Append("yueColor=@yueColor,");
            strSql.Append("nameSize=@nameSize,");
            strSql.Append("nameColor=@nameColor,");
            strSql.Append("priceSize=@priceSize,");
            strSql.Append("priceColor=@priceColor,");
            strSql.Append("TotimeSize=@TotimeSize,");
            strSql.Append("TotimeColor=@TotimeColor,");
            strSql.Append("zdSize=@zdSize,");
            strSql.Append("zdColor=@zdColor,");
            strSql.Append("icoColor=@icoColor");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@Lwidth", SqlDbType.Int,4),
					new SqlParameter("@Lhieght", SqlDbType.Int,4),
					new SqlParameter("@Lfontf", SqlDbType.NVarChar,50),
					new SqlParameter("@Fontsize", SqlDbType.Int,4),
					new SqlParameter("@Lmargin", SqlDbType.Int,4),
					new SqlParameter("@Backcolor", SqlDbType.NVarChar,50),
					new SqlParameter("@Bordercolor", SqlDbType.NVarChar,50),
					new SqlParameter("@showType", SqlDbType.Bit,1),
					new SqlParameter("@showPrice", SqlDbType.Bit,1),
					new SqlParameter("@orderLC", SqlDbType.Bit,1),
					new SqlParameter("@ftNum", SqlDbType.Int,4),
					new SqlParameter("@zzShowType", SqlDbType.Bit,1),
					new SqlParameter("@zzShowPrice", SqlDbType.Bit,1),
					new SqlParameter("@showFormTime", SqlDbType.Bit,1),
					new SqlParameter("@showLFico", SqlDbType.Bit,1),
					new SqlParameter("@showBmico", SqlDbType.Bit,1),
					new SqlParameter("@showyjb", SqlDbType.Bit,1),
					new SqlParameter("@showday", SqlDbType.Bit,1),
					new SqlParameter("@daynum", SqlDbType.Int,4),
					new SqlParameter("@showyue", SqlDbType.Bit,1),
					new SqlParameter("@moneyNum", SqlDbType.Int,4),
					new SqlParameter("@showcf", SqlDbType.Bit,1),
					new SqlParameter("@showThem", SqlDbType.Bit,1),
					new SqlParameter("@Themtext", SqlDbType.NVarChar,10),
					new SqlParameter("@showMember", SqlDbType.Bit,1),
					new SqlParameter("@memberText", SqlDbType.NVarChar,10),
					new SqlParameter("@showXy", SqlDbType.Bit,1),
					new SqlParameter("@showYuli", SqlDbType.Bit,1),
					new SqlParameter("@yuliDay", SqlDbType.Bit,1),
					new SqlParameter("@showDayTime", SqlDbType.Bit,1),
					new SqlParameter("@dayNumYl", SqlDbType.Int,4),
					new SqlParameter("@showxz", SqlDbType.Bit,1),
					new SqlParameter("@showSf", SqlDbType.Bit,1),
					new SqlParameter("@showYuee", SqlDbType.Bit,1),
					new SqlParameter("@Showzdftime", SqlDbType.Bit,1),
					new SqlParameter("@Showbooktime", SqlDbType.Bit,1),
					new SqlParameter("@Showzf", SqlDbType.Bit,1),
					new SqlParameter("@Showlc", SqlDbType.Bit,1),
					new SqlParameter("@showPeoNum", SqlDbType.Bit,1),
					new SqlParameter("@showRk", SqlDbType.Bit,1),
					new SqlParameter("@showWupi", SqlDbType.Bit,1),
					new SqlParameter("@Showyz", SqlDbType.Bit,1),
					new SqlParameter("@Showmf", SqlDbType.Bit,1),
					new SqlParameter("@Showzdf", SqlDbType.Bit,1),
					new SqlParameter("@Beiy", SqlDbType.Bit,1),
					new SqlParameter("@Beiy2", SqlDbType.Bit,1),
					new SqlParameter("@numSize", SqlDbType.Int,4),
					new SqlParameter("@numColor", SqlDbType.NVarChar,10),
					new SqlParameter("@fxSize", SqlDbType.Int,4),
					new SqlParameter("@fxColor", SqlDbType.NVarChar,10),
					new SqlParameter("@yueSize", SqlDbType.Int,4),
					new SqlParameter("@yueColor", SqlDbType.NVarChar,10),
					new SqlParameter("@nameSize", SqlDbType.Int,4),
					new SqlParameter("@nameColor", SqlDbType.NVarChar,10),
					new SqlParameter("@priceSize", SqlDbType.Int,4),
					new SqlParameter("@priceColor", SqlDbType.NVarChar,10),
					new SqlParameter("@TotimeSize", SqlDbType.Int,4),
					new SqlParameter("@TotimeColor", SqlDbType.NVarChar,10),
					new SqlParameter("@zdSize", SqlDbType.Int,4),
					new SqlParameter("@zdColor", SqlDbType.NVarChar,10),
					new SqlParameter("@icoColor", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.Lwidth;
            parameters[1].Value = model.Lhieght;
            parameters[2].Value = model.Lfontf;
            parameters[3].Value = model.Fontsize;
            parameters[4].Value = model.Lmargin;
            parameters[5].Value = model.Backcolor;
            parameters[6].Value = model.Bordercolor;
            parameters[7].Value = model.showType;
            parameters[8].Value = model.showPrice;
            parameters[9].Value = model.orderLC;
            parameters[10].Value = model.ftNum;
            parameters[11].Value = model.zzShowType;
            parameters[12].Value = model.zzShowPrice;
            parameters[13].Value = model.showFormTime;
            parameters[14].Value = model.showLFico;
            parameters[15].Value = model.showBmico;
            parameters[16].Value = model.showyjb;
            parameters[17].Value = model.showday;
            parameters[18].Value = model.daynum;
            parameters[19].Value = model.showyue;
            parameters[20].Value = model.moneyNum;
            parameters[21].Value = model.showcf;
            parameters[22].Value = model.showThem;
            parameters[23].Value = model.Themtext;
            parameters[24].Value = model.showMember;
            parameters[25].Value = model.memberText;
            parameters[26].Value = model.showXy;
            parameters[27].Value = model.showYuli;
            parameters[28].Value = model.yuliDay;
            parameters[29].Value = model.showDayTime;
            parameters[30].Value = model.dayNumYl;
            parameters[31].Value = model.showxz;
            parameters[32].Value = model.showSf;
            parameters[33].Value = model.showYuee;
            parameters[34].Value = model.Showzdftime;
            parameters[35].Value = model.Showbooktime;
            parameters[36].Value = model.Showzf;
            parameters[37].Value = model.Showlc;
            parameters[38].Value = model.showPeoNum;
            parameters[39].Value = model.showRk;
            parameters[40].Value = model.showWupi;
            parameters[41].Value = model.Showyz;
            parameters[42].Value = model.Showmf;
            parameters[43].Value = model.Showzdf;
            parameters[44].Value = model.Beiy;
            parameters[45].Value = model.Beiy2;
            parameters[46].Value = model.numSize;
            parameters[47].Value = model.numColor;
            parameters[48].Value = model.fxSize;
            parameters[49].Value = model.fxColor;
            parameters[50].Value = model.yueSize;
            parameters[51].Value = model.yueColor;
            parameters[52].Value = model.nameSize;
            parameters[53].Value = model.nameColor;
            parameters[54].Value = model.priceSize;
            parameters[55].Value = model.priceColor;
            parameters[56].Value = model.TotimeSize;
            parameters[57].Value = model.TotimeColor;
            parameters[58].Value = model.zdSize;
            parameters[59].Value = model.zdColor;
            parameters[60].Value = model.icoColor;
            parameters[61].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FtSet ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FtSet ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.FtSet GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,Lwidth,Lhieght,Lfontf,Fontsize,Lmargin,Backcolor,Bordercolor,showType,showPrice,orderLC,ftNum,zzShowType,zzShowPrice,showFormTime,showLFico,showBmico,showyjb,showday,daynum,showyue,moneyNum,showcf,showThem,Themtext,showMember,memberText,showXy,showYuli,yuliDay,showDayTime,dayNumYl,showxz,showSf,showYuee,Showzdftime,Showbooktime,Showzf,Showlc,showPeoNum,showRk,showWupi,Showyz,Showmf,Showzdf,Beiy,Beiy2,numSize,numColor,fxSize,fxColor,yueSize,yueColor,nameSize,nameColor,priceSize,priceColor,TotimeSize,TotimeColor,zdSize,zdColor,icoColor from FtSet ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            CdHotelManage.Model.FtSet model = new CdHotelManage.Model.FtSet();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CdHotelManage.Model.FtSet DataRowToModel(DataRow row)
        {
            CdHotelManage.Model.FtSet model = new CdHotelManage.Model.FtSet();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["Lwidth"] != null && row["Lwidth"].ToString() != "")
                {
                    model.Lwidth = int.Parse(row["Lwidth"].ToString());
                }
                if (row["Lhieght"] != null && row["Lhieght"].ToString() != "")
                {
                    model.Lhieght = int.Parse(row["Lhieght"].ToString());
                }
                if (row["Lfontf"] != null)
                {
                    model.Lfontf = row["Lfontf"].ToString();
                }
                if (row["Fontsize"] != null && row["Fontsize"].ToString() != "")
                {
                    model.Fontsize = int.Parse(row["Fontsize"].ToString());
                }
                if (row["Lmargin"] != null && row["Lmargin"].ToString() != "")
                {
                    model.Lmargin = int.Parse(row["Lmargin"].ToString());
                }
                if (row["Backcolor"] != null)
                {
                    model.Backcolor = row["Backcolor"].ToString();
                }
                if (row["Bordercolor"] != null)
                {
                    model.Bordercolor = row["Bordercolor"].ToString();
                }
                if (row["showType"] != null && row["showType"].ToString() != "")
                {
                    if ((row["showType"].ToString() == "1") || (row["showType"].ToString().ToLower() == "true"))
                    {
                        model.showType = true;
                    }
                    else
                    {
                        model.showType = false;
                    }
                }
                if (row["showPrice"] != null && row["showPrice"].ToString() != "")
                {
                    if ((row["showPrice"].ToString() == "1") || (row["showPrice"].ToString().ToLower() == "true"))
                    {
                        model.showPrice = true;
                    }
                    else
                    {
                        model.showPrice = false;
                    }
                }
                if (row["orderLC"] != null && row["orderLC"].ToString() != "")
                {
                    if ((row["orderLC"].ToString() == "1") || (row["orderLC"].ToString().ToLower() == "true"))
                    {
                        model.orderLC = true;
                    }
                    else
                    {
                        model.orderLC = false;
                    }
                }
                if (row["ftNum"] != null && row["ftNum"].ToString() != "")
                {
                    model.ftNum = int.Parse(row["ftNum"].ToString());
                }
                if (row["zzShowType"] != null && row["zzShowType"].ToString() != "")
                {
                    if ((row["zzShowType"].ToString() == "1") || (row["zzShowType"].ToString().ToLower() == "true"))
                    {
                        model.zzShowType = true;
                    }
                    else
                    {
                        model.zzShowType = false;
                    }
                }
                if (row["zzShowPrice"] != null && row["zzShowPrice"].ToString() != "")
                {
                    if ((row["zzShowPrice"].ToString() == "1") || (row["zzShowPrice"].ToString().ToLower() == "true"))
                    {
                        model.zzShowPrice = true;
                    }
                    else
                    {
                        model.zzShowPrice = false;
                    }
                }
                if (row["showFormTime"] != null && row["showFormTime"].ToString() != "")
                {
                    if ((row["showFormTime"].ToString() == "1") || (row["showFormTime"].ToString().ToLower() == "true"))
                    {
                        model.showFormTime = true;
                    }
                    else
                    {
                        model.showFormTime = false;
                    }
                }
                if (row["showLFico"] != null && row["showLFico"].ToString() != "")
                {
                    if ((row["showLFico"].ToString() == "1") || (row["showLFico"].ToString().ToLower() == "true"))
                    {
                        model.showLFico = true;
                    }
                    else
                    {
                        model.showLFico = false;
                    }
                }
                if (row["showBmico"] != null && row["showBmico"].ToString() != "")
                {
                    if ((row["showBmico"].ToString() == "1") || (row["showBmico"].ToString().ToLower() == "true"))
                    {
                        model.showBmico = true;
                    }
                    else
                    {
                        model.showBmico = false;
                    }
                }
                if (row["showyjb"] != null && row["showyjb"].ToString() != "")
                {
                    if ((row["showyjb"].ToString() == "1") || (row["showyjb"].ToString().ToLower() == "true"))
                    {
                        model.showyjb = true;
                    }
                    else
                    {
                        model.showyjb = false;
                    }
                }
                if (row["showday"] != null && row["showday"].ToString() != "")
                {
                    if ((row["showday"].ToString() == "1") || (row["showday"].ToString().ToLower() == "true"))
                    {
                        model.showday = true;
                    }
                    else
                    {
                        model.showday = false;
                    }
                }
                if (row["daynum"] != null && row["daynum"].ToString() != "")
                {
                    model.daynum = int.Parse(row["daynum"].ToString());
                }
                if (row["showyue"] != null && row["showyue"].ToString() != "")
                {
                    if ((row["showyue"].ToString() == "1") || (row["showyue"].ToString().ToLower() == "true"))
                    {
                        model.showyue = true;
                    }
                    else
                    {
                        model.showyue = false;
                    }
                }
                if (row["moneyNum"] != null && row["moneyNum"].ToString() != "")
                {
                    model.moneyNum = int.Parse(row["moneyNum"].ToString());
                }
                if (row["showcf"] != null && row["showcf"].ToString() != "")
                {
                    if ((row["showcf"].ToString() == "1") || (row["showcf"].ToString().ToLower() == "true"))
                    {
                        model.showcf = true;
                    }
                    else
                    {
                        model.showcf = false;
                    }
                }
                if (row["showThem"] != null && row["showThem"].ToString() != "")
                {
                    if ((row["showThem"].ToString() == "1") || (row["showThem"].ToString().ToLower() == "true"))
                    {
                        model.showThem = true;
                    }
                    else
                    {
                        model.showThem = false;
                    }
                }
                if (row["Themtext"] != null)
                {
                    model.Themtext = row["Themtext"].ToString();
                }
                if (row["showMember"] != null && row["showMember"].ToString() != "")
                {
                    if ((row["showMember"].ToString() == "1") || (row["showMember"].ToString().ToLower() == "true"))
                    {
                        model.showMember = true;
                    }
                    else
                    {
                        model.showMember = false;
                    }
                }
                if (row["memberText"] != null)
                {
                    model.memberText = row["memberText"].ToString();
                }
                if (row["showXy"] != null && row["showXy"].ToString() != "")
                {
                    if ((row["showXy"].ToString() == "1") || (row["showXy"].ToString().ToLower() == "true"))
                    {
                        model.showXy = true;
                    }
                    else
                    {
                        model.showXy = false;
                    }
                }
                if (row["showYuli"] != null && row["showYuli"].ToString() != "")
                {
                    if ((row["showYuli"].ToString() == "1") || (row["showYuli"].ToString().ToLower() == "true"))
                    {
                        model.showYuli = true;
                    }
                    else
                    {
                        model.showYuli = false;
                    }
                }
                if (row["yuliDay"] != null && row["yuliDay"].ToString() != "")
                {
                    if ((row["yuliDay"].ToString() == "1") || (row["yuliDay"].ToString().ToLower() == "true"))
                    {
                        model.yuliDay = true;
                    }
                    else
                    {
                        model.yuliDay = false;
                    }
                }
                if (row["showDayTime"] != null && row["showDayTime"].ToString() != "")
                {
                    if ((row["showDayTime"].ToString() == "1") || (row["showDayTime"].ToString().ToLower() == "true"))
                    {
                        model.showDayTime = true;
                    }
                    else
                    {
                        model.showDayTime = false;
                    }
                }
                if (row["dayNumYl"] != null && row["dayNumYl"].ToString() != "")
                {
                    model.dayNumYl = int.Parse(row["dayNumYl"].ToString());
                }
                if (row["showxz"] != null && row["showxz"].ToString() != "")
                {
                    if ((row["showxz"].ToString() == "1") || (row["showxz"].ToString().ToLower() == "true"))
                    {
                        model.showxz = true;
                    }
                    else
                    {
                        model.showxz = false;
                    }
                }
                if (row["showSf"] != null && row["showSf"].ToString() != "")
                {
                    if ((row["showSf"].ToString() == "1") || (row["showSf"].ToString().ToLower() == "true"))
                    {
                        model.showSf = true;
                    }
                    else
                    {
                        model.showSf = false;
                    }
                }
                if (row["showYuee"] != null && row["showYuee"].ToString() != "")
                {
                    if ((row["showYuee"].ToString() == "1") || (row["showYuee"].ToString().ToLower() == "true"))
                    {
                        model.showYuee = true;
                    }
                    else
                    {
                        model.showYuee = false;
                    }
                }
                if (row["Showzdftime"] != null && row["Showzdftime"].ToString() != "")
                {
                    if ((row["Showzdftime"].ToString() == "1") || (row["Showzdftime"].ToString().ToLower() == "true"))
                    {
                        model.Showzdftime = true;
                    }
                    else
                    {
                        model.Showzdftime = false;
                    }
                }
                if (row["Showbooktime"] != null && row["Showbooktime"].ToString() != "")
                {
                    if ((row["Showbooktime"].ToString() == "1") || (row["Showbooktime"].ToString().ToLower() == "true"))
                    {
                        model.Showbooktime = true;
                    }
                    else
                    {
                        model.Showbooktime = false;
                    }
                }
                if (row["Showzf"] != null && row["Showzf"].ToString() != "")
                {
                    if ((row["Showzf"].ToString() == "1") || (row["Showzf"].ToString().ToLower() == "true"))
                    {
                        model.Showzf = true;
                    }
                    else
                    {
                        model.Showzf = false;
                    }
                }
                if (row["Showlc"] != null && row["Showlc"].ToString() != "")
                {
                    if ((row["Showlc"].ToString() == "1") || (row["Showlc"].ToString().ToLower() == "true"))
                    {
                        model.Showlc = true;
                    }
                    else
                    {
                        model.Showlc = false;
                    }
                }
                if (row["showPeoNum"] != null && row["showPeoNum"].ToString() != "")
                {
                    if ((row["showPeoNum"].ToString() == "1") || (row["showPeoNum"].ToString().ToLower() == "true"))
                    {
                        model.showPeoNum = true;
                    }
                    else
                    {
                        model.showPeoNum = false;
                    }
                }
                if (row["showRk"] != null && row["showRk"].ToString() != "")
                {
                    if ((row["showRk"].ToString() == "1") || (row["showRk"].ToString().ToLower() == "true"))
                    {
                        model.showRk = true;
                    }
                    else
                    {
                        model.showRk = false;
                    }
                }
                if (row["showWupi"] != null && row["showWupi"].ToString() != "")
                {
                    if ((row["showWupi"].ToString() == "1") || (row["showWupi"].ToString().ToLower() == "true"))
                    {
                        model.showWupi = true;
                    }
                    else
                    {
                        model.showWupi = false;
                    }
                }
                if (row["Showyz"] != null && row["Showyz"].ToString() != "")
                {
                    if ((row["Showyz"].ToString() == "1") || (row["Showyz"].ToString().ToLower() == "true"))
                    {
                        model.Showyz = true;
                    }
                    else
                    {
                        model.Showyz = false;
                    }
                }
                if (row["Showmf"] != null && row["Showmf"].ToString() != "")
                {
                    if ((row["Showmf"].ToString() == "1") || (row["Showmf"].ToString().ToLower() == "true"))
                    {
                        model.Showmf = true;
                    }
                    else
                    {
                        model.Showmf = false;
                    }
                }
                if (row["Showzdf"] != null && row["Showzdf"].ToString() != "")
                {
                    if ((row["Showzdf"].ToString() == "1") || (row["Showzdf"].ToString().ToLower() == "true"))
                    {
                        model.Showzdf = true;
                    }
                    else
                    {
                        model.Showzdf = false;
                    }
                }
                if (row["Beiy"] != null && row["Beiy"].ToString() != "")
                {
                    if ((row["Beiy"].ToString() == "1") || (row["Beiy"].ToString().ToLower() == "true"))
                    {
                        model.Beiy = true;
                    }
                    else
                    {
                        model.Beiy = false;
                    }
                }
                if (row["Beiy2"] != null && row["Beiy2"].ToString() != "")
                {
                    if ((row["Beiy2"].ToString() == "1") || (row["Beiy2"].ToString().ToLower() == "true"))
                    {
                        model.Beiy2 = true;
                    }
                    else
                    {
                        model.Beiy2 = false;
                    }
                }
                if (row["numSize"] != null && row["numSize"].ToString() != "")
                {
                    model.numSize = int.Parse(row["numSize"].ToString());
                }
                if (row["numColor"] != null)
                {
                    model.numColor = row["numColor"].ToString();
                }
                if (row["fxSize"] != null && row["fxSize"].ToString() != "")
                {
                    model.fxSize = int.Parse(row["fxSize"].ToString());
                }
                if (row["fxColor"] != null)
                {
                    model.fxColor = row["fxColor"].ToString();
                }
                if (row["yueSize"] != null && row["yueSize"].ToString() != "")
                {
                    model.yueSize = int.Parse(row["yueSize"].ToString());
                }
                if (row["yueColor"] != null)
                {
                    model.yueColor = row["yueColor"].ToString();
                }
                if (row["nameSize"] != null && row["nameSize"].ToString() != "")
                {
                    model.nameSize = int.Parse(row["nameSize"].ToString());
                }
                if (row["nameColor"] != null)
                {
                    model.nameColor = row["nameColor"].ToString();
                }
                if (row["priceSize"] != null && row["priceSize"].ToString() != "")
                {
                    model.priceSize = int.Parse(row["priceSize"].ToString());
                }
                if (row["priceColor"] != null)
                {
                    model.priceColor = row["priceColor"].ToString();
                }
                if (row["TotimeSize"] != null && row["TotimeSize"].ToString() != "")
                {
                    model.TotimeSize = int.Parse(row["TotimeSize"].ToString());
                }
                if (row["TotimeColor"] != null)
                {
                    model.TotimeColor = row["TotimeColor"].ToString();
                }
                if (row["zdSize"] != null && row["zdSize"].ToString() != "")
                {
                    model.zdSize = int.Parse(row["zdSize"].ToString());
                }
                if (row["zdColor"] != null)
                {
                    model.zdColor = row["zdColor"].ToString();
                }
                if (row["icoColor"] != null && row["icoColor"].ToString() != "")
                {
                    model.icoColor = int.Parse(row["icoColor"].ToString());
                }
            }
            return model;
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

