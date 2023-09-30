using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBProducts.Common
{
    public static class Extensions
    {
        public static IEnumerable<T> ToPaged<T>(this IEnumerable<T> items , int page , int pagesize, out int rowcount) {
            rowcount = items.Count();
            if (page < 1) page = 1;
            if (page > Math.Ceiling((double)rowcount / pagesize)) page = (int)Math.Ceiling((double)rowcount / pagesize);
            if (page == 1)
            return items.Take(pagesize);
            else
            return items.Skip(page - 1 * pagesize).Take(pagesize);
        }
    }
}
