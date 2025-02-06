using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common
{
    public class MovieHashKeyProvider : HashKeyProvider
    {
        public int CreateKey(Movie item, MovieCollection table)
        {
            var chars = item.Title.ToCharArray();
            var total = 0;
            for (var i = 0; i < chars.Length; i++)
            {
                total += chars[i];
            }
            var squared = Math.Pow(total,2);
            var digits = (int) Math.Log10(squared) + 1;
            var mid = (int) (squared / Math.Pow(10, digits / 2)) % table.Size;
            return mid;
        }
    }
}
