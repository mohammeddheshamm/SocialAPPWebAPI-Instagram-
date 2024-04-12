using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Entity
{
    public class Post : BaseEntity
    {
        public string Description { get; set; }
        public string PostURL { get; set; }
        public int Likes { get; set; }
    }
}
