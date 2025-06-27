using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuBeyoundTest.Interface
{
    public interface IWordFindSearch
    {
        public IEnumerable<string> Find(IEnumerable<string> wordstream);
    }
}
