using System.Globalization;
using Prototype07.Entities;

namespace Prototype07 {
	internal class Program {
		static void Main( string[ ] args ) {

			// Inputs
			// file path
			Console.WriteLine( "Enter full file path:" );
			string filePath = Console.ReadLine();
			//C:\Users\pedro\Desktop\C# Estudo\Seção 17 - Espressões lambda, delegates, LINQ\LambdaExpressionsDelegatesLINQ\Prototype07\Prototype07\Files\Input File.txt
			
			// cut-off salary
			Console.Write( "Enter the cut-off salary value: " );
			double cutSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
			Console.WriteLine();

			// Processing
			List<Employee> employees = new List<Employee>();

			using ( StreamReader stream = File.OpenText( filePath ) ) {
				while ( !stream.EndOfStream ) {

					string[] infos = stream.ReadLine().Split(',');
					string name = infos[0];
					string email = infos[1];
					double salary = double.Parse(infos[2], CultureInfo.InvariantCulture);

					employees.Add( new Employee( name , email , salary ) );
				}
			}

			// Outputs
			Console.WriteLine( $"Email of people whose salary is more than ${cutSalary.ToString( "F2" , CultureInfo.InvariantCulture )}:" );
			IEnumerable<string> emails = employees.Where( e => e.Salary > cutSalary ).OrderBy( e => e.Email ).Select(e => e.Email);

			foreach ( string eml in emails )
				Console.WriteLine( eml );
			Console.WriteLine();

			double sumWithM = employees.Where(e => e.Name[0] == 'M').Sum(p => p.Salary);
			Console.Write( $"Sum of salary of people whose name starts with 'M': ${sumWithM.ToString( "F2" , CultureInfo.InvariantCulture )}" );
			Console.WriteLine();

		}
	}
}