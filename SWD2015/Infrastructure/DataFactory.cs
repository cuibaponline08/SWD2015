using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015
{
    public static class DataFactory
    {
        public static int AVAILABLE_PRODUCT { get { return 1; } }
        public static int DAYS_FOR_NEW_PRODUCT { get { return 15; } }
        public static int DAYS_FOR_HOT_PRODUCT { get { return 30; } }
        public static int NUMBER_OF_NEW_PRODUCT { get { return 15; } }
        public static int SOLD_ORDER_STATUS_ID { get { return 5; } }
        public static int PURCHASED_ORDER_STATUS_ID { get { return 2; } }
        public static int NEW_PURCHASED_ORDER_STATUS_ID { get { return 0; } }
        public static int NEW_SOLD_ORDER_STATUS_ID { get { return 3; } }
    }
}