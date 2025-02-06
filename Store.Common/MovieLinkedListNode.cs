using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common
{
    public class MovieLinkedListNode
    {
        public Movie Data {  get; set; }
        public MovieLinkedListNode Next { get; set; }
        public MovieLinkedListNode Previous { get; set; }
    }
}
