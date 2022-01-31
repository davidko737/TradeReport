using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace TradeReportUnitTest
{
    [TestClass]
    public class UnitTest
    {
        static readonly string StartupPath = Environment.CurrentDirectory; 



        [TestMethod]
        public void AddTradeBnfA()
        {
            var trade = new Trade 
            { 
                TradeRef = "T-BNF-1", 
                ExecutionDate = DateTime.Parse("8 Apr 2020"),
                Maturity = DateTime.Parse("14 Jul 2021"),
                Qty = 1000000,
                BuySell = "B",
                Price = 1.187511,
                Desc = "30YR-US-Treasury",
                ProductId = 1,
                BrokerId = 1
            };
            Check(getOutputStr(trade), "BNF-BrokerA.csv");
        }

        [TestMethod]
        public void AddTradeBnfB()
        {
            var trade = new Trade
            {
                TradeRef = "T-BNF-1",
                ExecutionDate = DateTime.Parse("8 Apr 2020"),
                Maturity = DateTime.Parse("15 Jul 2021"),
                Qty = 5000000,
                BuySell = "S",
                Price = 0.143301,
                Desc = "10YR-US-NY GOV",
                ProductId = 1,
                BrokerId = 2
            };
            Check(getOutputStr(trade), "BNF-BrokerB.csv");
        }

        [TestMethod]
        public void AddTradeBnfC()
        {
            var trade = new Trade
            {
                TradeRef = "T-BNF-1",
                ExecutionDate = DateTime.Parse("8 Apr 2020"),
                Maturity = DateTime.Parse("15 Jul 2021"),
                Qty = 37000000,
                BuySell = "B",
                Price = 0.8542301,
                Desc = "5YR-CN-Treasury",
                ProductId = 1,
                BrokerId = 3
            };
            Check(getOutputStr(trade), "BNF-BrokerC.csv");
        }


        [TestMethod]
        public void AddTradeFxfA()
        {
            var trade = new Trade
            {
                TradeRef = "T-FXF-2",
                ExecutionDate = DateTime.Parse("8 Apr 2020"),
                Maturity = DateTime.Parse("14 Jul 2021"),
                Qty = 1060000,
                BuySell = "S",
                Price = 0.135591,
                Desc = "AUDNZD-FRD",
                ProductId = 2,
                BrokerId = 1
            };
            Check(getOutputStr(trade), "FXF-BrokerA.csv");
        }

        [TestMethod]
        public void AddTradeFxfB()
        {
            var trade = new Trade
            {
                TradeRef = "T-FXF-2",
                ExecutionDate = DateTime.Parse("8 Apr 2020"),
                Maturity = DateTime.Parse("16 Jun 2021"),
                Qty = 4020000,
                BuySell = "S",
                Price = 1.8328501,
                Desc = "AUDUSD-FRD",
                ProductId = 2,
                BrokerId = 2
            };
            Check(getOutputStr(trade), "FXF-BrokerB.csv");
        }

        [TestMethod]
        public void AddTradeFxfC()
        {
            var trade = new Trade
            {
                TradeRef = "T-FXF-2",
                ExecutionDate = DateTime.Parse("8 Apr 2020"),
                Maturity = DateTime.Parse("21 Aug 2022"),
                Qty = 15400000,
                BuySell = "S",
                Price = 1.1238201,
                Desc = "EURUSD-FRD",
                ProductId = 2,
                BrokerId = 3
            };
            Check(getOutputStr(trade), "FXF-BrokerC.csv");
        }




        [TestMethod]
        public void AddTradeIrsA()
        {
            var trade = new Trade
            {
                TradeRef = "T-IRS-3",
                ExecutionDate = DateTime.Parse("8 May 2020"),
                Maturity = DateTime.Parse("14 Jul 2021"),
                Qty = 1050000,
                BuySell = "S",
                Price = 0.065591,
                Desc = "IRS",
                ProductId = 3,
                BrokerId = 1
            };
            Check(getOutputStr(trade), "IRS-BrokerA.csv");
        }

        [TestMethod]
        public void AddTradeIrsB()
        {
            var trade = new Trade
            {
                TradeRef = "T-IRS-3",
                ExecutionDate = DateTime.Parse("1 Mar 2020"),
                Maturity = DateTime.Parse("15 Jul 2021"),
                Qty = 9000000,
                BuySell = "B",
                Price = 1.2128201,
                Desc = "IRS",
                ProductId = 3,
                BrokerId = 2
            };
            Check(getOutputStr(trade), "IRS-BrokerB.csv");
        }

        [TestMethod]
        public void AddTradeIrsC()
        {
            var trade = new Trade
            {
                TradeRef = "T-IRS-3",
                ExecutionDate = DateTime.Parse("7 Sep 2020"),
                Maturity = DateTime.Parse("15 Jul 2021"),
                Qty = 28000000,
                BuySell = "B",
                Price = 2.8542301,
                Desc = "IRS",
                ProductId = 3,
                BrokerId = 3
            };
            Check(getOutputStr(trade), "IRS-BrokerC.csv");
        }





        private string PathCombine(string path1, string path2)
        {
            if (Path.IsPathRooted(path2))
            {
                path2 = path2.TrimStart(Path.DirectorySeparatorChar);
                path2 = path2.TrimStart(Path.AltDirectorySeparatorChar);
            }

            return Path.Combine(path1, path2);
        }

        private void Check(string recordStr, string fileNameExpectedOut)
        {

            var expectOutput = File.ReadAllText(PathCombine(StartupPath, "/ExpectedOutput/" + fileNameExpectedOut));

            Console.WriteLine(recordStr);
            Console.WriteLine("========================");
            Console.WriteLine(expectOutput);

            Assert.AreEqual(expectOutput.Contains(recordStr), true);
        }


        public string getOutputStr(Trade trade)
        {
            // Please Note that it is a simplfited version
            // Real: Get the real data from a DB & create a DTO object to convert Trade to Report output 
            // You can see the logic in Main project :)
            //
            var productName = getProductName(trade.ProductId);
            var brokerName = getBrokerName(trade.BrokerId);

            var str = $"{trade.TradeRef}" +
                $",{trade.ProductId}" +
                $",{productName}," +
                $"{trade.BrokerId}," +
                $"{brokerName}," +
                $"{trade.ExecutionDate.ToString("yyyyMMdd")}," +
                $"{trade.Maturity.ToString("yyyyMMdd")}," +
                $"{trade.Qty}," +
                $"{trade.BuySell}," +
                $"{trade.Price}," +
                $"{trade.Desc}";

            return str;
        }

        public string getBrokerName(int id)
        {
            var brokerName = "";
            if (id == 1)
            {
                brokerName = "Broker-A";
            }
            else if (id == 2)
            {
                brokerName = "Broker-B";
            }
            else
            {
                brokerName = "Broker-C";
            }
            return brokerName;
        }

        public string getProductName(int id)
        {
            var productName = "";
            if (id == 1)
            {
                productName = "BNF";
            }
            else if (id == 2)
            {
                productName = "FXF";
            }
            else
            {
                productName = "IRS";
            }
            return productName;
        }
    }

    public class Trade
    {
        public string TradeRef { get; set; }
        public DateTime ExecutionDate { get; set; }
        public decimal Qty { get; set; }
        public string BuySell { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }
        public int ProductId { get; set; }
        public int BrokerId { get; set; }
        public DateTime Maturity { get; set; }
    }
}