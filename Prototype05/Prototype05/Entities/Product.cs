using System.Globalization;

namespace Prototype05.Entities {
   internal class Product : IComparable {

      public Category category {
         get; set;
      }
      public int id {
         get; set;
      }
      public string name {
         get; set;
      }
      public double price {
         get; set;
      }


      public Product( int _id , string _name , double _price , Category _category ) {

         id = _id;
         name = _name;
         price = _price;
         category = _category;

      }


      public int CompareTo( object? obj ) {

         if ( !( obj is Product ) )
            throw new Exception( "The obj in CompareTo() need to be a 'Product'" );

         return ( price.CompareTo( ( obj as Product ).price ) );

      }
      public override string ToString( ) {

         return (
            $"{id}, " +
            $"{name}, " +
            $"{price.ToString( "F2" , CultureInfo.InvariantCulture )}, " +
            $"{category.name}" );

      }
   }
}
