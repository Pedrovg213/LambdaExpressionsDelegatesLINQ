using System.Linq;
using Prototype03.Entities;

namespace Prototype03 {
   internal class Program {
      static void Main( string[ ] args ) {

         List<Product> products = new List<Product>();

         products.Add( new Product( "Tv" , 900.00 ) );
         products.Add( new Product( "Mouse" , 50.00 ) );
         products.Add( new Product( "Tablet" , 350.00 ) );
         products.Add( new Product( "HD Case" , 80.90 ) );

         // func
         List<string> resultString01 = products.Select(NameUpper).ToList();
         resultString01.ForEach( p => Console.WriteLine( p ) );
         Console.WriteLine();

         Func<Product, string> func01 = NameUpper;
         List<string> resultString02 = products.Select(func01).ToList();
         resultString02.ForEach( p => Console.WriteLine( p ) );
         Console.WriteLine();

         Func<Product, string> func02 = p => p.Name.ToUpper();
         List<string> resultString03 = products.Select(func02).ToList();
         resultString03.ForEach( p => Console.WriteLine( p ) );
         Console.WriteLine();

         List<string> resultString04 = products.Select(p => p.Name.ToUpper()).ToList();
         resultString04.ForEach( p => Console.WriteLine( p ) );
         Console.WriteLine();

         // predicate
         products.RemoveAll( ProductTest );
         foreach ( Product pro in products )
            Console.WriteLine( pro );
         Console.WriteLine();

         // action
         products.ForEach( UpdatePrice );
         foreach ( Product pro in products )
            Console.WriteLine( pro );
         Console.WriteLine();

         products.ForEach( p => p.Price += p.Price * .1 );
         products.ForEach( p => Console.WriteLine( p ) );
         Console.WriteLine();

         Action<Product> action01 = UpdatePrice;
         Action<Product> action02 = p => p.Price += p.Price * .1;

         products.ForEach( action01 );
         products.ForEach( action02 );
         products.ForEach( p => Console.WriteLine( p ) );

      }


      static string NameUpper( Product _product ) {

         return ( _product.Name.ToUpper() );

      }
      static bool ProductTest( Product _product ) {

         return ( _product.Price >= 100 );

      }
      static void UpdatePrice( Product _product ) {

         _product.Price += _product.Price * .1;

      }
   }
}