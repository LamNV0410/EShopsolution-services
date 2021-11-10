using System;
using System.Collections.Generic;
using System.Linq;

namespace EshopSolution.Extensions.Enums
{
    public class ESortDirection : Enumeration
    {
        public static readonly ESortDirection Descending = new ESortDirection(1, "DESC");
        public static readonly ESortDirection Ascending = new ESortDirection(2, "DESC");
        public ESortDirection(int id, string name) : base(id, name)
        {
        }
        public static IEnumerable<ESortDirection> List() => new[] { Descending, Ascending };
        public static ESortDirection FromName(string name)
        {
            var moduleName = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            return moduleName;
        }

        public static ESortDirection From(int id)
        {
            var moduleName = List().SingleOrDefault(s => s.Id == id);

            return moduleName;
        }
    }
}
