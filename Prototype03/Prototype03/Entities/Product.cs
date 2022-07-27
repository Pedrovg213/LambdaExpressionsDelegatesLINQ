using System.Globalization;

namespace Prototype03.Entities {
   internal class Product {

      public string Name {
         get; set;
      }
      public double Price {
         get; set;
      }


      public Product( string _name , double _price ) {

         Name = _name;
         Price = _price;

      }


      public override string ToString( ) {
         return $"{Name}, {Price.ToString( "F2" , CultureInfo.InvariantCulture )}";
      }
   }
}
