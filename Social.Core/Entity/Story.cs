using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Entity
{
    public class Story : BaseEntity
    {
        public string StoryUrl { get; set; }
        public int Likes { get; set; }
    }
}
