using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BA.BL
{
    public class ServiceItems
    {
        private string Type;
        private string Name;
        private string Item;
        private string Price;
        private int ID;

        public ServiceItems(int id = 0, string type = "", string name = "", string item = "", string price = "")
        {
            this.ID = id;
            this.Type = type;
            this.Name = name;
            this.Item = item;
            this.Price = price;
        }

        public int getID()
        {
            return ID;
        }

        public void setID(int id)
        {
             this.ID = id;
        }

        public string getPrice()
        {
            return Price;
        }

        public void setPrice(string price)
        {
             this.Price = price;
        }

        public string getName()
        {
            return Name;
        }

        public void setName(string name)
        {
             this.Name = name;
        }

        public void setItem(string item)
        {
             this.Item = item;
        }

        public string getItem()
        {
            return Item;
        }

        public void setType(string type)
        {
             this.Type = type;
        }

        public string getType()
        {
            return Type;
        }

    }
}
