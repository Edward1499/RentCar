using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Model : BaseEntity
    {
        public string Description { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
