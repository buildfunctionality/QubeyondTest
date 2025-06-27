using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Hosting;
using QuBeyoundTest;
using QuBeyoundTest.Interface;
using System.Collections;

Console.WriteLine("Find word test");

// set matrix 
IEnumerable matrix = new List<string>
        {
            "coldparkcs",
            "wgfedcbazt",
            "inightxoxo",
            "nucchillar",
            "dbedexyzwm",
            "lmnrstornw",
            "qwertyuioh",
            "knokfallsc",
            "raaawarmxa",
            "dogymcoldr"
        };


//initial examples ("chill", "cold" and "wind")

var host = Host.CreateDefaultBuilder()
          .ConfigureServices(services =>
          {
              services.AddSingleton<IWordFindSearch>(provider => new WordFindSearch((IEnumerable<string>)matrix));
          })
          .Build();

var stream = new List<string> { "chill", "cold", "wind", "ice", "storm", "hot", "warm", "fall", "car", "dog", "park" };
//var stream = new List<string> {  "factory" }; // not exiting word

//var finder = new WordFindSearch((IEnumerable<string>)matrix); without DI 
var finder = host.Services.GetRequiredService<IWordFindSearch>();// Get using DI 
var results = finder.Find(stream);

Console.WriteLine("Top 10 found words:");
foreach (var word in results)
{
    Console.WriteLine(word);
}

Console.ReadKey();

