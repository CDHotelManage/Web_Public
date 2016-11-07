using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class SysParamter
    {

        public SysParamter()
        { }
        #region Model
        private int _id;
        private int? _cancellmin;
        private bool _isdeposit;
        private decimal? _deposit;
        private bool _isearlyroom;
        private TimeSpan? _earlystart;
        private TimeSpan? _earlyend;
        private TimeSpan? _earlyouttime;
        private int? _earlyfee;
        private int? _earlyfeesel;
        private TimeSpan? _earlyouttimes;
        private int? _earlyfeetwo;
        private TimeSpan? _dayouttime;
        private int? _dayfee;
        private TimeSpan? _dayfeetwo;
        private TimeSpan? _daytime;
        public bool Istype { get; set; }
        public TimeSpan YsTime { get; set; }

        public bool IsOcczf { get; set; }
        public bool IsCy { get; set; }


        public string MarkSuo { get; set; }
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
        public int? CancellMin
        {
            set { _cancellmin = value; }
            get { return _cancellmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeposit
        {
            set { _isdeposit = value; }
            get { return _isdeposit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Deposit
        {
            set { _deposit = value; }
            get { return _deposit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsEarlyRoom
        {
            set { _isearlyroom = value; }
            get { return _isearlyroom; }
        }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan? EarlyStart
        {
            set { _earlystart = value; }
            get { return _earlystart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan? EarlyEnd
        {
            set { _earlyend = value; }
            get { return _earlyend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan? EarlyOutTime
        {
            set { _earlyouttime = value; }
            get { return _earlyouttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? EarlyFee
        {
            set { _earlyfee = value; }
            get { return _earlyfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? EarlyFeeSel
        {
            set { _earlyfeesel = value; }
            get { return _earlyfeesel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan? EarlyOutTimes
        {
            set { _earlyouttimes = value; }
            get { return _earlyouttimes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? EarlyFeeTwo
        {
            set { _earlyfeetwo = value; }
            get { return _earlyfeetwo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan? DayOutTime
        {
            set { _dayouttime = value; }
            get { return _dayouttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DayFee
        {
            set { _dayfee = value; }
            get { return _dayfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan? DayFeeTwo
        {
            set { _dayfeetwo = value; }
            get { return _dayfeetwo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan? DayTime
        {
            set { _daytime = value; }
            get { return _daytime; }
        }
        #endregion Model
    }
}
