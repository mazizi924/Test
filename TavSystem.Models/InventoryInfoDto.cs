using System;
using System.Collections.Generic;
using System.Text;

namespace TavSystem.Models
{
    public class InventoryInfoDto
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int dlv { get; set; }//کالای ورودی
        public int inv { get; set; }//کالای فروخته شده
        public int Inventory => (dlv - inv);//موجودی
        public int MinInventory { get; set; }
        public string Status => (Inventory == MinInventory) ? "آماده سفارش" : ((Inventory < MinInventory)? "ناموجود":"موجود در انبار");        
    }
     
}
