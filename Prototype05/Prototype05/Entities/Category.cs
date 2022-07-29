
namespace Prototype05.Entities {
   internal class Category {

      public int id {
         get; set;
      }
      public string name {
         get; set;
      }
      public int tier {
         get; set;
      }


      public Category( int _id , string _name , int _tier ) {

         id = _id;
         name = _name;
         tier = _tier;

      }

   }
}
