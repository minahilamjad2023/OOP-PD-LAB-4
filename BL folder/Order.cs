using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BA.BL
{
    public class Order
    {
        private int TotalNoOfPerson;
        private int TotalAmount;
        private int OrderNo;
        private DateTime OrderDate;
        private string Name;
        private List<ServiceItems> OrderItems;

        public Order(int TotalNoOfPerson = 0, int TotalAmount = 0, int OrderNo = 0, DateTime OrderDate = new DateTime(), string Name = "")
        {
            this.TotalNoOfPerson = TotalNoOfPerson;
            this.TotalAmount = TotalAmount;
            this.OrderNo = OrderNo;
            this.OrderDate = OrderDate;
            this.Name = Name;
        }

        public string getName()
        {
            return Name;
        }

        public void setName(string Name)
        {
            this.Name = Name;
        }

        public List<ServiceItems> getOrderItems()
        {
            return OrderItems;
        }

        public void setOrderItems(List<ServiceItems> OrderItems)
        {
            this.OrderItems = OrderItems;
        }

        public int getTotalNoOfPerson()
        {
            return TotalNoOfPerson;
        }
        public int getTotalAmount()
        {
            return TotalAmount;
        }
        public int getOrderNo()
        {
            return OrderNo;
        }
        public DateTime getOrderDate()
        {
            return OrderDate;
        }
        public void setTotalNoOfPerson(int TotalNoOfPerson)
        {
            this.TotalNoOfPerson = TotalNoOfPerson;
        }
        public void setTotalAmount(int TotalAmount)
        {
            this.TotalAmount = TotalAmount;
        }
        public void setOrderNo(int OrderNo)
        {
            this.OrderNo = OrderNo;
        }
        public void setOrderDate(DateTime OrderDate)
        {
            this.OrderDate = OrderDate;
        }
    }

}
