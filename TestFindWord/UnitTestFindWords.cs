using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuBeyoundTest.Interface;

namespace TestFindWord
{
    public class UnitTestFindWords 
    {
        [Fact]
        public void TestGetTop10WordsSuccess()
        {

            var matrix = new List<string>
            {
                "coldwindch",
                "hgfedcrazn",
                "onightaori",
                "sunchillag",
                "abcdexyzih",
                "lmnrstuvnt",
                "qwertyuiop",
                "snowfallsz",
                "rainxfallz",
                "stormcloud"
            };

         
            IHost host = Setup.CreateHost(matrix);

            var finder = host.Services.GetRequiredService<IWordFindSearch>();

            var words = new List<string>
            {
                "cold", "wind", "chill", "sun", "cloud", "fall", "snow", "storm", "rain", "night", "park"
            };


            var found = finder.Find(words).ToList();

            Assert.Contains("cold", found);
            Assert.Contains("wind", found);
            Assert.Contains("storm", found);
            Assert.Contains("sun", found);
            Assert.Contains("snow", found);
            Assert.Contains("rain", found);
            Assert.Contains("night", found);         
            Assert.Contains("cloud", found);
            Assert.Contains("chill", found);


            Assert.Equal(10, found.Count <= 10 ? found.Count : 10);
        }

        [Fact]
        public void TestGetTop10WordsNotFound()
        {

            var matrix = new List<string>
            {
                "coldwindcher",
                "hgfedcraznrr",
                "onightaoriyy",
                "sunchillagrr",
                "abcdexyzihvb",
                "lmnrstuvntry",
                "qwertyuiopuj",
                "snowfallszer",
                "rainxfallzom",
                "teidfdjahrty",
                "raincloudnot",
                "givetestarca"
            };

            IHost host = Setup.CreateHost(matrix);

            var finder = host.Services.GetRequiredService<IWordFindSearch>();

            var words = new List<string>
            {
                "cold", "wind", "chill", "sun", "cloud", "fall", "snow", "storm", "rain", "night", "park"
            };

            var found = finder.Find(words).ToList();

            Assert.DoesNotContain("wet", found);
            Assert.DoesNotContain("dry", found);
            Assert.DoesNotContain("google", found);
            Assert.DoesNotContain("jupiter", found);
            Assert.DoesNotContain("moon", found);
            Assert.DoesNotContain("xbox", found);
            Assert.DoesNotContain("steam", found);
            Assert.DoesNotContain("coffe", found);
            Assert.DoesNotContain("jam", found);
            Assert.DoesNotContain("square", found);


            Assert.Equal(10, found.Count <= 10 ? found.Count : 10);
        }
    }
}


