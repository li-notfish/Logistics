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
                    stateString = "无信息";
                    break;
                case 1:
                    stateString = "正在运送"; break;
                case 2: 
                    stateString = "正在派送";
                    break;
                case 3:
                    stateString = "已接收";
                    break;
                case 4:
                    stateString = "签收失败";
                    break;
                case 5:
                    stateString = "已退回";
                    break;
                default:
                    break;
            }
            return stateString;
        }
    }
}
