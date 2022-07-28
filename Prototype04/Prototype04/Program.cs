using System.Linq;

namespace Prototype04 {
   internal class Program {
      static void Main( string[ ] args ) {

         // Specify the data source
         int[] numbers = new int[] { 2, 3, 4, 5, 6 };

         // Define the query expression
         IEnumerable<int> result = numbers.
            Where(i => i % 2 == 0).
            Select(i => i * 10);

         // Execute the query
         foreach ( int i in result )
            Console.WriteLine( i );

      }
   }
}