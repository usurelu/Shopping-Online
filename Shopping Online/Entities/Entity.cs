namespace Shopping_Online.Entities
{
    public class Entity : IEntity
    {
        private int ID;

        public int GetID()
        {
            return this.ID;
        }

        public void SetID(int id)
        {
            this.ID = id;
        }
    }
}