using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common
{
    public interface HashKeyProvider
    {
        public int CreateKey(Movie item,MovieCollection table);
    }
}
