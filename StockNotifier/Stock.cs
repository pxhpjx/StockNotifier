using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockNotifier
{
    public class Stock
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string RealPrice { get; set; }
        public string ChangeAmount { get; set; }
        public string ChangePercentage { get; set; }
        public string MyAverageCost { get; set; }
    }
}
