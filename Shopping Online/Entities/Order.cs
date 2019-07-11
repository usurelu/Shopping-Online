namespace Shopping_Online.Entities
{
    public class Order : IEntity
    {
        private int ID;

        public User User { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public OrderShippingType ShippingType { get; set; }

        public Order()
        {
            
        }

        public Order(User user, Product product, int quantity, OrderShippingType shippingType)
        {
            this.User = user;
            this.Product = product;
            this.Quantity = quantity;
            this.ShippingType = shippingType;
        }

        public override string ToString()
        {
            return $"{this.User} {this.Product} {this.Quantity} {this.ShippingType}";
        }

        public void SetID(int ID)
        {
            this.ID = ID;
        }

        public int GetID()
        {
            return this.ID;
        }
    }
}