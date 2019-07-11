namespace Shopping_Online.Contracts.TransferObjects
{
    public class OrderTransferObject
    {
        public string UserName { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public string ShippingType { get; set; }

        public override string ToString()
        {
            return $"{this.UserName} {this.ProductName} {this.Quantity} {this.ShippingType}";
        }
    }
}