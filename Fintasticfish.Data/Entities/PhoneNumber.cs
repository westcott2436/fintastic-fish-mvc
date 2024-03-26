using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintasticFish.Data.Entities
{
    public class PhoneNumber
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public int PhoneNumberTypeId { get; set; }

        public virtual PhoneNumberType PhoneNumberType { get; set; }
    }
}
