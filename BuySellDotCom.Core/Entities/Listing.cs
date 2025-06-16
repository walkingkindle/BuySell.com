using BuySellDotCom.Core.BaseTypes;
using BuySellDotCom.Core.Enums;

namespace BuySellDotCom.Core.Entities
{
    public class Listing
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Currency Currency { get; set; }

        public Condition Condition { get; set; }

        public Address Address { get; set; }

        public int UserId { get; set; }

        public string ImageUrl { get; set; }

        public List<Tag> Tags { get; set; }

        public Category Category { get; set; }

        public List<Review> Reviews { get; set; }


       
    }
}
