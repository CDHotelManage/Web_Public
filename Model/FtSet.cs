using System;
namespace CdHotelManage.Model
{
    /// <summary>
    /// FtSet:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class FtSet
    {
        public FtSet()
        { }
        #region Model
        private int _id;
        private int _lwidth;
        private int _lhieght;
        private string _lfontf;
        private int _fontsize;
        private int? _lmargin;
        private string _backcolor;
        private string _bordercolor;
        private bool _showtype;
        private bool _showprice;
        private bool _orderlc;
        private int _ftnum;
        private bool _zzshowtype;
        private bool _zzshowprice;
        private bool _showformtime;
        private bool _showlfico;
        private bool _showbmico;
        private bool _showyjb;
        private bool _showday;
        private int? _daynum;
        private bool _showyue;
        private int? _moneynum;
        private bool _showcf;
        private bool _showthem;
        private string _themtext;
        private bool _showmember;
        private string _membertext;
        private bool _showxy;
        private bool _showyuli;
        private bool _yuliday;
        private bool _showdaytime;
        private int? _daynumyl;
        private bool _showxz;
        private bool _showsf;
        private bool _showyuee;
        private bool _showzdftime;
        private bool _showbooktime;
        private bool _showzf;
        private bool _showlc;
        private bool _showpeonum;
        private bool _showrk;
        private bool _showwupi;
        private bool _showyz;
        private bool _showmf;
        private bool _showzdf;
        private bool _beiy;
        private bool _beiy2;
        private int? _numsize;
        private string _numcolor;
        private int? _fxsize;
        private string _fxcolor;
        private int? _yuesize;
        private string _yuecolor;
        private int? _namesize;
        private string _namecolor;
        private int? _pricesize;
        private string _pricecolor;
        private int? _totimesize;
        private string _totimecolor;
        private int? _zdsize;
        private string _zdcolor;
        private int? _icocolor;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Lwidth
        {
            set { _lwidth = value; }
            get { return _lwidth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Lhieght
        {
            set { _lhieght = value; }
            get { return _lhieght; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Lfontf
        {
            set { _lfontf = value; }
            get { return _lfontf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Fontsize
        {
            set { _fontsize = value; }
            get { return _fontsize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Lmargin
        {
            set { _lmargin = value; }
            get { return _lmargin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Backcolor
        {
            set { _backcolor = value; }
            get { return _backcolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Bordercolor
        {
            set { _bordercolor = value; }
            get { return _bordercolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showType
        {
            set { _showtype = value; }
            get { return _showtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showPrice
        {
            set { _showprice = value; }
            get { return _showprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool orderLC
        {
            set { _orderlc = value; }
            get { return _orderlc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ftNum
        {
            set { _ftnum = value; }
            get { return _ftnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool zzShowType
        {
            set { _zzshowtype = value; }
            get { return _zzshowtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool zzShowPrice
        {
            set { _zzshowprice = value; }
            get { return _zzshowprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showFormTime
        {
            set { _showformtime = value; }
            get { return _showformtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showLFico
        {
            set { _showlfico = value; }
            get { return _showlfico; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showBmico
        {
            set { _showbmico = value; }
            get { return _showbmico; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showyjb
        {
            set { _showyjb = value; }
            get { return _showyjb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showday
        {
            set { _showday = value; }
            get { return _showday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? daynum
        {
            set { _daynum = value; }
            get { return _daynum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showyue
        {
            set { _showyue = value; }
            get { return _showyue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? moneyNum
        {
            set { _moneynum = value; }
            get { return _moneynum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showcf
        {
            set { _showcf = value; }
            get { return _showcf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showThem
        {
            set { _showthem = value; }
            get { return _showthem; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Themtext
        {
            set { _themtext = value; }
            get { return _themtext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showMember
        {
            set { _showmember = value; }
            get { return _showmember; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string memberText
        {
            set { _membertext = value; }
            get { return _membertext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showXy
        {
            set { _showxy = value; }
            get { return _showxy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showYuli
        {
            set { _showyuli = value; }
            get { return _showyuli; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool yuliDay
        {
            set { _yuliday = value; }
            get { return _yuliday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showDayTime
        {
            set { _showdaytime = value; }
            get { return _showdaytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? dayNumYl
        {
            set { _daynumyl = value; }
            get { return _daynumyl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showxz
        {
            set { _showxz = value; }
            get { return _showxz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showSf
        {
            set { _showsf = value; }
            get { return _showsf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showYuee
        {
            set { _showyuee = value; }
            get { return _showyuee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Showzdftime
        {
            set { _showzdftime = value; }
            get { return _showzdftime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Showbooktime
        {
            set { _showbooktime = value; }
            get { return _showbooktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Showzf
        {
            set { _showzf = value; }
            get { return _showzf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Showlc
        {
            set { _showlc = value; }
            get { return _showlc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showPeoNum
        {
            set { _showpeonum = value; }
            get { return _showpeonum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showRk
        {
            set { _showrk = value; }
            get { return _showrk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool showWupi
        {
            set { _showwupi = value; }
            get { return _showwupi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Showyz
        {
            set { _showyz = value; }
            get { return _showyz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Showmf
        {
            set { _showmf = value; }
            get { return _showmf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Showzdf
        {
            set { _showzdf = value; }
            get { return _showzdf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Beiy
        {
            set { _beiy = value; }
            get { return _beiy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Beiy2
        {
            set { _beiy2 = value; }
            get { return _beiy2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? numSize
        {
            set { _numsize = value; }
            get { return _numsize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string numColor
        {
            set { _numcolor = value; }
            get { return _numcolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? fxSize
        {
            set { _fxsize = value; }
            get { return _fxsize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fxColor
        {
            set { _fxcolor = value; }
            get { return _fxcolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? yueSize
        {
            set { _yuesize = value; }
            get { return _yuesize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string yueColor
        {
            set { _yuecolor = value; }
            get { return _yuecolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? nameSize
        {
            set { _namesize = value; }
            get { return _namesize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string nameColor
        {
            set { _namecolor = value; }
            get { return _namecolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? priceSize
        {
            set { _pricesize = value; }
            get { return _pricesize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string priceColor
        {
            set { _pricecolor = value; }
            get { return _pricecolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TotimeSize
        {
            set { _totimesize = value; }
            get { return _totimesize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TotimeColor
        {
            set { _totimecolor = value; }
            get { return _totimecolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? zdSize
        {
            set { _zdsize = value; }
            get { return _zdsize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zdColor
        {
            set { _zdcolor = value; }
            get { return _zdcolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? icoColor
        {
            set { _icocolor = value; }
            get { return _icocolor; }
        }
        #endregion Model

    }
}

