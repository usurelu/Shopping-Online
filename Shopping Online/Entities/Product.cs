using System;

namespace Shopping_Online.Entities
{
    public class Product : IEntity
    {
        private int ID;

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Product()
        {
            
        }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public int GetID()
        {
            return this.ID;
        }

        public void SetID(int id)
        {
            this.ID = id;
        }

        public override bool Equals(object obj)
        {
            if (obj is Product)
            {
                Product product = (Product)obj;
                return this.Name == product.Name
                    && this.Price == product.Price;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }

        public string ToFile()
        {
            return $"{this.Name}|{this.Price}{Environment.NewLine}";
        }
    }
}