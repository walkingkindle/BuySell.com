namespace BuySellDotCom.Core.Entities
{
    public class Listing
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Condition { get; set; }

        public string Address { get; set; }

        public int UserId { get; set; }

        public string ImageUrl { get; set; }

        public List<Tag> Tags { get; set; }

        public Category Category { get; set; }

        public List<Review> Reviews { get; set; }


       
    }
}
