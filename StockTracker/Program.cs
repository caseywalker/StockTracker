using System;
using System.Collections.Generic;

namespace StockTracker
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Stock Purchase Tracker");

      //Creating a new dictionary that will hold reference to stocks listed on the NYSE
      var stocks = new Dictionary<string, string>();
      stocks.Add("GM", "General Motors");
      stocks.Add("CAT", "Caterpillar");
      stocks.Add("F", "Ford");
      stocks.Add("DE", "Deere & Company");
      stocks.Add("MSFT", "Microsoft Corporation");
      stocks.Add("AMD", "Advanced Micro Devices");
      stocks.Add("GME", "GameStop Corp.");
      stocks.Add("AMC", "AMC Entertainment Holdings, Inc");
      stocks.Add("HKIB", "AMTD International");
      stocks.Add("FIS", "Fidelity National Information Services, Inc");
      stocks.Add("JPM", "JPMorgan Chase & Co.");
      stocks.Add("WFC", "Wells Fargo & Company");

      //List of ValueTuples that represent stock purchases. Properties for ticker, total shares, and price. 
      List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();
      purchases.Add((ticker: "GM", shares: 150, price: 23.21));
      purchases.Add((ticker: "GM", shares: 32, price: 17.87));
      purchases.Add((ticker: "GM", shares: 80, price: 19.02));
      purchases.Add((ticker: "CAT", shares: 20, price: 208.35));
      purchases.Add((ticker: "F", shares: 300, price: 13.80));
      purchases.Add((ticker: "DE", shares: 10, price: 366.88));
      purchases.Add((ticker: "MSFT", shares: 15, price: 289.46));
      purchases.Add((ticker: "AMD", shares: 5, price: 110.11));
      purchases.Add((ticker: "GME", shares: 5, price: 151.77));
      purchases.Add((ticker: "AMC", shares: 52, price: 32.70));
      purchases.Add((ticker: "HKIB", shares: 1028, price: 6.20));
      purchases.Add((ticker: "FIS", shares: 28, price: 133.82));
      purchases.Add((ticker: "JPM", shares: 37, price: 157.50));
      purchases.Add((ticker: "WFC", shares: 73, price: 48.77));

      //Create a collection to hold all stock purchases, and then the total purchase price of every individual purchase.
      var portfolio = new Dictionary<string, double>();

      //Loop through each purchase that was made, so that we can create our portfolio
      //Since our Purchases Tuple destructured the values, we need to declare the var type and name
      foreach ((string ticker, int shares, double price) purchase in purchases)
      {
        var sum = 0d;
        //Since dictionaries require a unique key, we need to see if the portfolio already contains that key
        // If it does, then add to that key[ticker]'s total cost basis by adding shared * purchase price
        if (portfolio.ContainsKey(purchase.ticker))
        {
          sum = purchase.shares * purchase.price;
          portfolio[purchase.ticker] += sum;
        }
        else
        //If the key does not exist, then create a new dictionary pair for the ticker and total cost basis. 
        {
          sum = purchase.shares * purchase.price;
          portfolio.Add(purchase.ticker, sum);
        }
      }

      //create a variable that will show the total cost basis of ALL stocks purchsed. 
      var totalValue = 0d;

      //Now that all purchases are stored in the portfolio, we are going to display that data. 
      //Destructure the ticker and value in the dictionary/ key:value pairs in portfolio.
      foreach (var (tick, value) in portfolio)
      {
        //Add each stock's value to the total portfolio value for later use. 
        totalValue += value;
        //We want to display the stock name, not the ticker. Access our stock dictionary using the ticker key to display the stock name value.
        var stockName = stocks[tick];
        Console.WriteLine($"{stockName} : ${value}");
      }
      // Now we want to show the entire portfolio cost basis so that we can later compare total Profit/Loss. 
      Console.WriteLine($"\t Total Portfolio cost basis: {totalValue}");
    }
  }
}
