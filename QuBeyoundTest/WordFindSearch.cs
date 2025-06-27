using QuBeyoundTest.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QuBeyoundTest
{
    public class WordFindSearch : IWordFindSearch
    {
        private readonly List<string> _rows;
        private readonly List<string> _columns;
        private readonly IEnumerable<string> _matrix;

        public WordFindSearch(IEnumerable<string> matrix)
        {
            _matrix = matrix;
          
            _rows = _matrix.ToList();
            if (_rows.Count == 0)
                throw new ArgumentException("Matrix cannot be empty.");

            int columnCount = _rows[0].Length;//Get Column length
        
            _columns = new List<string>();
            for (int col = 0; col < columnCount; col++)
            {
                _columns.Add(new string(_rows.Select(row => row[col]).ToArray()));// get Column by Col (from 0 to N=9)
            }
           
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var words = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            int initial_count=0;

            foreach (var word in wordstream)
            {
                if (string.IsNullOrWhiteSpace(word)) continue;

                bool existsInRow = _rows.Any(r => r.Contains(word, StringComparison.OrdinalIgnoreCase)) || _columns.Any(c => c.Contains(word, StringComparison.OrdinalIgnoreCase));

                if (existsInRow)
                {
                    words.TryAdd(word, initial_count);
                    words[word]++;
                    Console.WriteLine(" " + word + " : " + words[word]);
                }
               
              

            }
            if (words.Count > 0)
            {
                return words.OrderByDescending(x => x.Value).Take(10).Select(s => s.Key);
            }
            else {
                 return new List<string>() { "empty" };
            }
           

        }

      


    }
}
