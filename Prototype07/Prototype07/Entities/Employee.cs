
namespace Prototype07.Entities {
	internal class Employee {

		public string Name {
			get; set;
		}
		public string Email {
			get; set;
		}
		public double Salary {
			get; set;
		}


		public Employee( string _name , string _email , double _salary ) {

			Name = _name;
			Email = _email;
			Salary = _salary;

		}
	}
}
