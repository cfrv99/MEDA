using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.BlogPage.Entities
{
    public class RuleFiles
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public RuleType Type { get; set; }
    }

    public enum RuleType
    {
        Ferman = 0,
        Qanunvericilik = 1,
        Qerarlar = 2,
        Serencamlar = 3,
        Metodik_Gorushler = 4
    }
}
