using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuBeyoundTest.Interface;
using QuBeyoundTest;
using System;
using System.Collections.Generic;

public static class Setup
{
    public static IHost CreateHost(IEnumerable<string> matrix)
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<IWordFindSearch>(provider => new WordFindSearch(matrix));
            })
            .Build();
    }
}
