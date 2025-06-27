using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuBeyoundTest
{
    public class WordFindTest
    {
        private IEnumerable<string> _matrix;
        private IWordFindSearch _wordFindSearch;
        private IEnumerable matrix;

        public WordFindTest(IEnumerable matrix)
        {
            this.matrix = matrix;
        }

        public WordFindTest(IEnumerable<string> matrix, IWordFindSearch wordFindSearch)
        {
           _matrix = matrix;
           _wordFindSearch = wordFindSearch;
        }

        public IEnumerable<string> GetMatrix() {
            _wordFindSearch = new WordFindSearch(_matrix);

            var wordstream = new List<string>
            {
                "cold", "wind", "chill", "sun", "storm", "snow", "snow", "storm", "rain", "night", "cold"
            };
            _wordFindSearch.Find(wordstream);

            return _matrix;
        }
    }
}
