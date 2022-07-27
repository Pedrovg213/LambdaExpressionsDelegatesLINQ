using Prototype01.Entities;

namespace Prototype01 {
   internal class Program {
      static void Main( string[ ] args ) {

         List<Product> products = new List<Product>();

         products.Add( new Product( "TV" , 900.00 ) );
         products.Add( new Product( "Notebook" , 1200.00 ) );
         products.Add( new Product( "Tablet" , 450.00 ) );

         // Lambda
         products.Sort( ( p1 , p2 ) => p1.Name.ToUpper().CompareTo( p2.Name.ToUpper() ) );

         foreach ( Product p in products )
            Console.WriteLine( p );

      }
      static int CompareProducts( Product _product01 , Product _product02 ) {

         return ( _product01.Name.ToUpper().CompareTo( _product02.Name.ToUpper() ) );

      }
   }
}