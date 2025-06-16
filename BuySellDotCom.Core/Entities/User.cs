using BuySellDotCom.Core.BaseTypes;
using BuySellDotCom.Core.Enums;

namespace BuySellDotCom.Core.Entities
{
    public class User
    {
        public string Name { get; set; }

        public PhoneNumber PhoneNumber { get; set; }

        public Email EmailAddress { get; set; }

        public List<Listing> Listings { get; set; }

        public Address Address { get; set; }

        public int? Age { get; set; }

        public Gender Gender { get; set; }

    }


}
