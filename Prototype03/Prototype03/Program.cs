using Prototype03.Entities;

namespace Prototype03 {
   internal class Program {
      static void Main( string[ ] args ) {

         List<Product> products = new List<Product>();

         products.Add( new Product( "Tv" , 900.00 ) );
         products.Add( new Product( "Mouse" , 50.00 ) );
         products.Add( new Product( "Tablet" , 350.00 ) );
         products.Add( new Product( "HD Case" , 80.90 ) );

         // predicate
         products.RemoveAll( ProductTest );
         foreach ( Product pro in products )
            Console.WriteLine( pro );

      }

      static bool ProductTest( Product _product ) {

         return ( _product.Price >= 100 );

      }
   }
}