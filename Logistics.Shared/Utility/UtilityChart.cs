using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Utility {
    public class UtilityChart {
        public static string EnmuToStirng(int state) {
            string stateString = string.Empty;
            switch (state) {
                case 0:
                    stateString = "待寄出";
                    break;
                case 1:
                    stateString = "运输中"; break;
                case 2: 
                    stateString = "派送中";
                    break;
                case 3:
                    stateString = "已签收";
                    break;
                case 4:
                    stateString = "签收失败";
                    break;
                case 5:
                    stateString = "已退回";
                    break;
                case 6:
                    stateString = "待签收";
                    break;
                default:
                    break;
            }
            return stateString;
        }
        public static string DeliveryEnmuToString(int state)
        {
            string stateString = string.Empty;
            switch (state)
            {
                case 0:
                    stateString = "繁忙";
                    break;
                case 1:
                    stateString = "空闲";
                    break;
            }

            return stateString;
        }

        public static string GoodsStateToString(int state)
        {
            string stateString = string.Empty;  

            switch (state)
            {
                case 0:
                    stateString = "出库";
                    break;
                case 1:
                    stateString = "已入库";
                    break;
            }

            return stateString;
        }
    }
}
