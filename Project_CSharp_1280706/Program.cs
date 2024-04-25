using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project_CSharp_1280706
{
    public enum MCatagoryy { OTC =1, Antibiotic, AntiUlcer, AntiHistacin, Nsaids }
    internal class Program
    {
        static void Main(string[] args)
        {
            MedicineBase MB = new MedicineBase();


                MB.MADD(new Medicine { ID = 1, MName = "Napa", MCategory = MCatagoryy.OTC, SQuantity = 200, MPrice = 2000 });
                MB.MADD(new Medicine { ID = 2, MName = "NapaExtra", MCategory = MCatagoryy.OTC, SQuantity = 100, MPrice = 3000 });
                MB.MADD(new Medicine { ID = 3, MName = "Ciprocin", MCategory = MCatagoryy.Antibiotic, SQuantity = 1000, MPrice = 80000 });
                MB.MADD(new Medicine { ID = 4, MName = "Fimoxyl", MCategory = MCatagoryy.Antibiotic, SQuantity = 1000, MPrice = 10000 });
                MB.MADD(new Medicine { ID = 5, MName = "Sergel", MCategory = MCatagoryy.AntiUlcer, SQuantity = 1000, MPrice = 70000 });
                MB.MADD(new Medicine { ID = 6, MName = "Nexum", MCategory = MCatagoryy.AntiUlcer, SQuantity = 1000, MPrice = 20000 });
                MB.MADD(new Medicine { ID = 7, MName = "Alatrol", MCategory = MCatagoryy.AntiHistacin, SQuantity = 1000, MPrice = 4000 });
                MB.MADD(new Medicine { ID = 8, MName = "Rupa", MCategory = MCatagoryy.AntiHistacin, SQuantity = 1000, MPrice = 100000 });
                MB.MADD(new Medicine { ID = 9, MName = "Tory", MCategory = MCatagoryy.Nsaids, SQuantity = 1000, MPrice = 200000 });
                MB.MADD(new Medicine { ID = 10, MName = "Naprox", MCategory = MCatagoryy.Nsaids, SQuantity = 1000, MPrice = 30000 });
              


            var s1 = new Stock { ID = 1, SID = 101, SDate = DateTime.Parse("2022-05-20") };
            var s2 = new Stock { ID = 2, SID = 102, SDate = DateTime.Parse("2022-05-21") };
            var s3 = new Stock { ID = 3, SID = 103, SDate = DateTime.Parse("2022-05-22") };
            var s4 = new Stock { ID = 4, SID = 104, SDate = DateTime.Parse("2022-05-23") };
            var s5 = new Stock { ID = 5, SID = 105, SDate = DateTime.Parse("2022-05-24") };
            var s6 = new Stock { ID = 6, SID = 106, SDate = DateTime.Parse("2022-05-25") };
            var s7 = new Stock { ID = 7, SID = 107, SDate = DateTime.Parse("2022-05-26") };
            var s8 = new Stock { ID = 8, SID = 108, SDate = DateTime.Parse("2022-05-27") };
            var s9 = new Stock { ID = 9, SID = 109, SDate = DateTime.Parse("2022-05-28") };
            var s10 = new Stock { ID = 10, SID = 110, SDate = DateTime.Parse("2022-05-29") };
         
           

            StockBase SB = new StockBase();
            SB.MADD(s1);
            SB.MADD(s2);
            SB.MADD(s3);
            SB.MADD(s4);
            SB.MADD(s5);
            SB.MADD(s6);
            SB.MADD(s7);
            SB.MADD(s8);
            SB.MADD(s9);
            SB.MADD(s10);
         
           
           
            //Data Display
            var mb = MB.GetAll();
            var sb = SB.GetAll();
            Console.WriteLine("============================================All Medicine");
          //  Console.WriteLine($"ID MName\t\tMCategory\t\tSQuantity\t\tMPrice\n");
            mb.ForEach(m => Console.WriteLine($"ID : {m.ID} MName : {m.MName}, MCategory : {m.MCategory} ,SQuantity :{m.SQuantity}, MPrice :{m.MPrice}\n"));
            //JOIN
            var joinedData = from medicine in mb
                             join stock in sb on medicine.ID equals stock.ID
                             select new
                             {
                                 MedicineID = medicine.ID,
                                 MName = medicine.MName,
                                 MCategory = medicine.MCategory,
                                 SQuantity = medicine.SQuantity,
                                 MPrice = medicine.MPrice,
                                 SDate = stock.SDate
                             };

            // Display joined data
            Console.WriteLine("\n============================================Joined Data");
            joinedData.ToList().ForEach(j => Console.WriteLine($"MName: {j.MName} SDate: {j.SDate}\n"));


            Console.WriteLine("======================2. Where-Order by-Distinct-Top-Between-Operator");


            // WHERE CLAUSE
            var whereCategoryOTC = mb.Where(medicine => medicine.MCategory == MCatagoryy.OTC).ToList();
            Console.WriteLine("WHERE CLAUSE - Category OTC:");
            whereCategoryOTC.ForEach(medicine => Console.WriteLine($"Product: {medicine.MName}, Category: {medicine.MCategory}"));
            Console.WriteLine();

            // ORDER BY
            var orderByPriceDesc = mb.OrderByDescending(medicine => medicine.MPrice).ToList();
            Console.WriteLine("ORDER BY - Price Descending:");
            orderByPriceDesc.ForEach(medicine => Console.WriteLine($"Product: {medicine.MName}, Price: {medicine.MPrice}"));
            Console.WriteLine();

            // DISTINCT
            var distinctCategories = mb.Select(medicine => medicine.MCategory).Distinct().ToList();
            Console.WriteLine("DISTINCT - Medicine Categories:");
            distinctCategories.ForEach(category => Console.WriteLine($"Category: {category}"));
            Console.WriteLine();

            // TOP
            var top5ByQuantityDesc = mb.OrderByDescending(medicine => medicine.SQuantity).Take(5).ToList();
            Console.WriteLine("TOP - Top 5 by Quantity Descending:");
            top5ByQuantityDesc.ForEach(medicine => Console.WriteLine($"Product: {medicine.MName}, Quantity: {medicine.SQuantity}"));
            Console.WriteLine();

            // BETWEEN
            var betweenPrices = mb.Where(medicine => medicine.MPrice >= 2000 && medicine.MPrice <= 5000).ToList();
            Console.WriteLine("BETWEEN - Prices Between 2000 and 5000:");
            betweenPrices.ForEach(medicine => Console.WriteLine($"Product: {medicine.MName}, Price: {medicine.MPrice}"));
            Console.WriteLine();

            // AND
            var andCondition = mb.Where(medicine => medicine.MCategory == MCatagoryy.OTC && medicine.MPrice < 3000).ToList();
            Console.WriteLine("AND - Category OTC and Price < 3000:");
            andCondition.ForEach(medicine => Console.WriteLine($"Product: {medicine.MName}, Category: {medicine.MCategory}, Price: {medicine.MPrice}"));
            Console.WriteLine();

            // OR
            var orCondition = mb.Where(medicine => medicine.MCategory == MCatagoryy.OTC || medicine.MPrice <= 3000).ToList();
            Console.WriteLine("OR - Category OTC or Price <= 3000:");
            orCondition.ForEach(medicine => Console.WriteLine($"Product: {medicine.MName}, Category: {medicine.MCategory}, Price: {medicine.MPrice}"));
            Console.WriteLine();

            // NOT
            var notCondition = mb.Where(medicine => !(medicine.MCategory == MCatagoryy.OTC && medicine.MPrice >= 3000)).ToList();
            Console.WriteLine("NOT - Not (Category OTC and Price >= 3000):");
            notCondition.ForEach(medicine => Console.WriteLine($"Product: {medicine.MName}, Category: {medicine.MCategory}, Price: {medicine.MPrice}"));

            Console.WriteLine("==================3. Like & IN");

            // LIKE
            var likeCondition = mb.Where(medicine => medicine.MName.StartsWith("Nap")).ToList();
            Console.WriteLine("LIKE - Product Names starting with 'Nap':");
            likeCondition.ForEach(medicine => Console.WriteLine($"Product: {medicine.MName}, Category: {medicine.MCategory}"));
            Console.WriteLine();

            // IN
            var inCondition = mb.Where(medicine => new[] { MCatagoryy.OTC, MCatagoryy.Antibiotic }.Contains(medicine.MCategory)).ToList();
            Console.WriteLine("IN - Medicines in Categories 'OTC' or 'Antibiotic':");
            inCondition.ForEach(medicine => Console.WriteLine($"Product: {medicine.MName}, Category: {medicine.MCategory}"));
            Console.WriteLine();
            Console.WriteLine("=================4. Aggregate Functions");
            // SUM
            var totalQuantity = mb.Sum(medicine => medicine.SQuantity);
            Console.WriteLine($"SUM - Total Quantity: {totalQuantity}");
            Console.WriteLine();

            // AVG
            var averagePriceOTC = mb.Where(medicine => medicine.MCategory == MCatagoryy.AntiUlcer).Average(medicine => medicine.MPrice);
            Console.WriteLine($"AVG - Average Price for 'AntiUlcer' category: {averagePriceOTC}");
            Console.WriteLine();

            // MAX
            var maxPrice = mb.Max(medicine => medicine.MPrice);
            Console.WriteLine($"MAX - Maximum Price: {maxPrice}");
            Console.WriteLine();

            // MIN
            var minPrice = mb.Min(medicine => medicine.MPrice);
            Console.WriteLine($"MIN - Minimum Price: {minPrice}");
            Console.WriteLine();

            // COUNT
            var categoryOTCCount = mb.Count(medicine => medicine.MCategory == MCatagoryy.Nsaids);
            Console.WriteLine($"COUNT - Number of Medicines in 'Nsaids' category: {categoryOTCCount}");
            Console.WriteLine();
            Console.WriteLine("===============================5. Find product with date range");
            DateTime startDate = DateTime.Parse("2022-05-20");
            DateTime endDate = DateTime.Parse("2022-05-22");

            // Find products within the date range
            var productsInDateRange = from medicine in mb
                                      join stock in sb on medicine.ID equals stock.ID
                                      where stock.SDate >= startDate && stock.SDate <= endDate
                                      select medicine;
            productsInDateRange.ToList().ForEach(product => Console.WriteLine($"Product: {product.MName}, Date: {startDate} to {endDate}"));


            Console.ReadKey ();
        }
        
    }
}
