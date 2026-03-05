using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsClient
{
    public class ClsClient
    {

        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalPurchaseValue { get; set; }
        
        public ClsClient(string clientName, string phone, string email, int totalOrders, decimal totalPurchaseValue)
        {
            ClientName = clientName;
            Phone = phone;
            Email = email;
            TotalOrders = totalOrders;
            TotalPurchaseValue = totalPurchaseValue;
        }

        public ClsClient()
        {

        }
    }
}
