using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace CdHotelManage.Web.Admin
{
    public class Helper
    {
        static BLL.infos bllin = new BLL.infos();
        static BLL.occu_infor blloi = new BLL.occu_infor();
        public static void AddRoom(string room) {
            //List<Model.occu_infor> listocc = blloi.GetModelList("state_id!=3 and room_number='" + room + "'");
            //if (listocc.Count > 0)
            //{
            //    List<Model.occu_infor> listocc1 = blloi.GetModelList("order_id='" + listocc[0].order_id + "'");
            //    foreach (Model.occu_infor item in listocc1)
            //    {
            //        Model.infos modelinfo = new Model.infos()
            //        {
            //            number = item.room_number,
            //            type = ""
            //        };
            //        bllin.Add(modelinfo);
            //    }
            //}
            //else
            //{
                Model.infos modelinfo = new Model.infos()
                {
                    number = room,
                    type = ""
                };
                bllin.Add(modelinfo);
            //}
        }

        /// <summary>
        /// 通过房号判断是否已开房
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public static bool IsOcc(string room) {
            List<Model.occu_infor> list = blloi.GetModelList("state_id=0 and room_number='" + room + "'");
            if (list != null && list.Count > 0) {
                return true;
            }
            return false;

        }
       static  BLL.goods_account bllga = new BLL.goods_account();
        public static bool IsJz(string occid) {
            List<Model.goods_account> listrg = bllga.GetModelList1("ga_occuid='" + occid + "' and ga_sfacount='是' and ga_Type in(6,4)");
            if (listrg != null) {
                if (listrg.Count > 0) {
                    return true;
                }
            }
            return false;
        }

        public static void AddRoom(string room,string remark)
        {
            //List<Model.occu_infor> listocc = blloi.GetModelList("state_id!=3 and room_number='" + room + "'");
            //if (listocc.Count > 0)
            //{
            //    List<Model.occu_infor> listocc1 = blloi.GetModelList("order_id='" + listocc[0].order_id + "'");
            //    foreach (Model.occu_infor item in listocc1)
            //    {
            //        Model.infos modelinfo = new Model.infos()
            //        {
            //            number = item.room_number,
            //            type = ""
            //        };
            //        bllin.Add(modelinfo);
            //    }
            //}
            //else
            //{
            Model.infos modelinfo = new Model.infos()
            {
                number = room,
                type = remark
            };
            bllin.Add(modelinfo);
            //}
        }

        public static void UpdateRoom(string room)
        {
           List<Model.room_number> listrn= bllrn.GetModelList("Rn_roomNum='" + room + "'");
           if (listrn.Count > 0) {
               Model.room_number modelrn = listrn[0];
               modelrn.Rn_Tobe=0;
               bllrn.Update(modelrn);
           }
        }
        static BLL.room_number bllrn = new BLL.room_number();
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encryption(string str) {
            System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                string c = str[i].ToString();
                string cs=string.Empty;
                MyDel1 m1 = new MyDel1(GetBase1);
                cs = m1(c,i);
                sbtext.Append(cs);
            }
            return sbtext.ToString();
        }




        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UEncryption(string str)
        {
            System.Text.StringBuilder sbtext = new System.Text.StringBuilder();
            for (int i = 0; i < str.Length; i++)
			{
                string c = str[i].ToString();
                string cs = string.Empty;
                MyDel1 m1 = new MyDel1(UGetBase1);
                cs = m1(c, i);
                sbtext.Append(cs);
			}
            return sbtext.ToString();
        }



        public static string UGetBase1(string c,int index)
        {
            string A = c.ToString();
            return Convert.ToChar(Convert.ToInt32(A.ToCharArray()[0]) - index).ToString();
        }
        public static string GetBase1(string c,int index)
        {
            string A = c.ToString();
            return Convert.ToChar(Convert.ToInt32(A.ToCharArray()[0]) + index).ToString();
        }
    }
    public delegate string MyDel1(string s,int index);
}