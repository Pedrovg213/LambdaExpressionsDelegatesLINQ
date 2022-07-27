
namespace Prototype02.Service {
   internal class CalculationService {

      public static double Max( double _x , double _y ) {

         return ( _x > _y ) ? _x : _y;

      }
      public static void ShowMax( double _x , double _y ) {

         Console.WriteLine( Max( _x , _y ) );

      }
      public static void ShowSum( double _x , double _y ) {

         Console.WriteLine( Sum( _x , _y ) );

      }
      public static double Sum( double _x , double _y ) {

         return ( _x + _y );

      }
      public static double Square( double _x ) {

         return ( _x * _x );

      }
   }
}
