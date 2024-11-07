using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTLLTW_webBanQuanAo
{
    public class ItemCart : Item
    {
        public int itemCartID;
        public int quantity;
        public string size;
        public string categoryName;
        public string userName;
        public ItemCart(int itemCartID, int id, string name, string image, int category, int price, int final_price, string description, string size, int quantity, string userName) : base(id, name, image, category, price, final_price, description)
        {
            this.itemCartID = itemCartID;
            this.size = size;
            this.quantity = quantity;
            this.userName = userName;
        }
        public string Size { get => size; set => size = value; }
        public int Quantity {  get => quantity; set => quantity = value;}
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public int ItemCartID {  get => itemCartID; set => itemCartID = value; }
        public string UserName { get => userName; set => userName = value; }   
    }
}