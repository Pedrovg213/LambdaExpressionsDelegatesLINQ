using Prototype02.Service;

namespace Prototype02 {

   // delegate
   delegate double BinaryNumericOperation( double _n1 , double _n2 );

   internal class Program {
      static void Main( string[ ] args ) {

         double a = 10;
         double b = 12;

         // delegate
         BinaryNumericOperation sum = CalculationService.Sum;
         BinaryNumericOperation max = new BinaryNumericOperation(CalculationService.Max);

         Console.WriteLine( sum.Invoke( a , b ) );
         Console.WriteLine( max( a , b ) );

      }
   }
}