using System.Linq;
using Prototype05.Entities;

namespace Prototype05 {
   internal class Program {
      static void Main( string[ ] args ) {

         Category tools = new Category(1, "Tools", 2);
         Category computers = new Category(2, "Computers", 1);
         Category eletronics = new Category(3, "Eletronics", 1);

         List<Product> products = new List<Product>(){

            new Product(1, "Computer", 1100.0, computers),
            new Product(2, "Hammer", 90.0, tools),
            new Product(3, "TV", 1700.0, eletronics),
            new Product(4, "Notebook", 1300, computers),
            new Product(5, "Scissors", 2.0, tools),
            new Product(6, "Tablet", 700.0, computers),
            new Product(7, "Camera", 700.0, eletronics),
            new Product(8, "Printer", 350.0, eletronics),
            new Product(9, "MacBook", 1800.0, computers),
            new Product(10, "Sound Bar", 700.0, eletronics),
            new Product(11, "Level", 70.0, tools),
            new Product(12, "Saw", 80.0, tools)

         };

         //IEnumerable<Product> results01 = products.Where(p => p.category.tier == 1 && p.price < 900);
         IEnumerable<Product> results01 =
            from p in products
            where p.category.tier == 1 && p.price < 900
            select p;
         Print( "TIER 1 AND PRICE < 900:" , results01 );
         Console.WriteLine();

         //IEnumerable<string> results02 = products.Where(p => p.category.name == tools.name).Select(p => p.name);
         IEnumerable<string> results02 =
            from p in products
            where p.category.name == tools.name
            select p.name;
         Print( "NAMES OF PRODCTS FROM TOOLS:" , results02 );
         Console.WriteLine();

         //var results03 = products.Where(p => p.name.ToUpper()[0] == 'C').Select(p => new {p.name, p.price, _categoryName = p.category.name});
         var results03 =
            from p in products
            where p.name.ToUpper()[0] == 'C'
            select new {
               p.name,
               p.price,
               CategoryName = p.category.name
            };
         Print( "NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT:" , results03 );
         Console.WriteLine();


         //IEnumerable<Product> results04 = products.Where(p => p.category.tier == 1).OrderBy(p => p.price).ThenBy(p => p.name);
         IEnumerable<Product> results04 =
            from p in products
            where p.category.tier == 1
            orderby p.name
            orderby p.price
            select p;
         Print( "TIER 1 ORDER BY PRICE THAN BY NAME:" , results04 );
         Console.WriteLine();

         //IEnumerable<Product> results05 = products.OrderBy(p => p.category.name).ThenBy(p => p.price).ThenBy(p => p.name);
         IEnumerable<Product> results05 =
            from p in products
            orderby p.name
            orderby p.price
            orderby p.category.name
            select p;
         Print( "ORDER BY CATEGORY THAN BY PRICE AND FINALY BY NAME" , results05 );
         Console.WriteLine();

         //IEnumerable<Product> results06 = results04.Skip(2).Take(4);
         IEnumerable<Product> results06 =
            (from p in results05 select p).Skip(2).Take(4);
         Print( "TIER 1 ORDER BY PRICE THAN BY NAME SKIP 2 TAKE 4:" , results06 );
         Console.WriteLine();

         //Product results07 = products.First();
         Product results07 =
            (from p in products select p).First();
         Console.WriteLine( "FIST TEST 1: " + results07.ToString() );
         Console.WriteLine();

         //IEnumerable<Product> results08 = products.Where(p => p.price > 3000.0);
         IEnumerable<Product> results08 =
            from p in products
            where p.price > 3000
            select p;
         if ( results08.Count() < 1 )
            Console.WriteLine( "THE RESULT IS EMPTY" );
         else
            Print( "PRICE > 3000: " , results08 );
         Console.WriteLine();

         //Product? results09 = results08.FirstOrDefault();
         Product? results09 =
            (from p in products select p).FirstOrDefault();
         Console.WriteLine( "FIRST TEST 2: " + results09 );
         Console.WriteLine();

         //Product? results10 = products.Where(p => p.id == 3 ).SingleOrDefault();
         Product? results10 =
            (from p in products
             where p.id == 3
             select p).SingleOrDefault();
         Console.WriteLine( "SINGLE OR DEFAULT TEST 1: " + results10 );
         Console.WriteLine();

         //Product? results11 = products.Where(p => p.id == 30 ).SingleOrDefault();
         Product? results11 =
            (from p in products
             where p.id == 30
             select p).SingleOrDefault();
         Console.WriteLine( "SINGLE OR DEFAULT TEST 2: " + results11 );
         Console.WriteLine();

         //double results12 = products.Max(p => p.price);
         double results12 =
            (from p in products select p.price).Max();
         Console.WriteLine( "PRICE MAX: " + results12 );
         Console.WriteLine();

         //Product? results13 = products.Max();
         Product? results13 =
            (from p in products select p).Max();
         Console.WriteLine( "PRODUCT MAX: " + results13 );
         Console.WriteLine();

         //double results14 = products.Min(p => p.price);
         double results14 =
            (from p in products select p.price).Min();
         Console.WriteLine( "PRICE MIN: " + results14 );
         Console.WriteLine();

         //Product? results15 = products.Min();
         Product? results15 =
            (from p in products select p).Min();
         Console.WriteLine( "PRODUCT MIN: " + results15 );
         Console.WriteLine();

         //double results16 = products.Where(p => p.category.id == 1).Sum(p => p.price);
         double results16 =
            (from p in products
             where p.category.id == 1
             select p.price).Sum();
         Console.WriteLine( "CATEGORY 1 SUM PRICES: " + results16 );
         Console.WriteLine();

         //double results17 = products.Where(p => p.category.id == 1).Average(p => p.price);
         double results17 =
            (from p in products
             where p.category.id == 1
             select p.price).Average();
         Console.WriteLine( "CATEGORY 1 AVERAGE PRICES: " + results17 );
         Console.WriteLine();

         //double results18 = products.Where(p => p.category.id == 5).Select(p => p.price).DefaultIfEmpty(0).Average();
         double results18 =
            (from p in products
             where p.category.id == 5
             select p.price).DefaultIfEmpty(0).Average();
         Console.WriteLine( "EMPTY CATEGORY AVERAGE PRICES: " + results18 );
         Console.WriteLine();

         //double results19 = products.Where(p => p.category.id == 1).Select(p => p.price).Aggregate((x, y) => x + y);
         double results19 =
            (from p in products
             where p.category.id == 1
             select p.price).Aggregate((x, y) => x + y);
         Console.WriteLine( "CATEGORY 1 AGGREGATE SUM: " + results19 );
         Console.WriteLine();

         //double results20 = products.Where(p => p.category.id == 5).Select(p => p.price).Aggregate(0d, (x, y) => x + y);
         double results20 =
            (from p in products
             where p.category.id == 5
             select p.price).Aggregate(0d, (x,y) => x + y);
         Console.WriteLine( "EMPTY CATEGORY AGGREGATE SUM: " + results20 );
         Console.WriteLine();


         //IEnumerable<IGrouping<Category, Product>> results21 = products.GroupBy(p => p.category);
         IEnumerable<IGrouping<Category, Product>> results21 =
            from p in products
            group p by p.category;
         foreach ( IGrouping<Category , Product> group in results21 ) {

            Console.WriteLine( $"Category: {group.Key.name} :" );

            List<Product> order = group.OrderBy( p => p.name.ToUpper()[ 0 ] ).ThenBy(p => p.name.ToUpper()[1]).ToList();

            foreach ( Product pro in order )
               Console.WriteLine( pro.name );

            Console.WriteLine();

         }

      }
      static void Print<T>( string _message , IEnumerable<T> _collection ) {

         Console.WriteLine( _message );
         foreach ( T item in _collection )
            Console.WriteLine( item );

      }
   }
}