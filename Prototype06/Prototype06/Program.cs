using System.Globalization;
using Prototype06.Entities;

namespace Prototype06 {
	internal class Program {
		static void Main( string[ ] args ) {

			// Input
			Console.WriteLine( "Enter full file path:" );
			string filePath = Console.ReadLine();
			// C:\Users\pedro\Desktop\C# Estudo\Seção 17 - Espressões lambda, delegates, LINQ\LambdaExpressionsDelegatesLINQ\Prototype06\Prototype06\Files\in.txt

			List<Product> products = new List<Product>();

			using ( StreamReader stream = File.OpenText( filePath ) ) {
				while ( !stream.EndOfStream ) {

					string[] infos = stream.ReadLine().Split(',');
					string name = infos[0];
					double price = double.Parse(infos[1], CultureInfo.InvariantCulture);

					products.Add( new Product( name , price ) );
				}
			}

			double avg = products.Select(p => p.Price).DefaultIfEmpty(0).Average();
			Console.WriteLine( $"Average price: {avg.ToString( "F2" , CultureInfo.InvariantCulture )}" );

			IEnumerable<string> names = products.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);
			foreach ( string n in names )
				Console.WriteLine( n );
		}
	}
}