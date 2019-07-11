using System;

namespace Shopping_Online.Entities
{
    public class User : IEntity
    {
        private int ID;

        public string Username { get; set; }

        public string Password { get; set; }

        public UserCategory Category { get; set; }

        public User()
        {
            
        }

        public User(string username, string password, UserCategory category)
        {
            this.Username = username;
            this.Password = password;
            this.Category = category;
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
            if (obj is User)
            {
                User user = (User) obj;
                return this.Username == user.Username 
                    && this.Password == user.Password;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.Username;
        }

        public string ToFile()
        {
            return $"{this.Username}|{this.Password}|{(int)this.Category}{Environment.NewLine}";
        }
    }
}