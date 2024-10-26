using System.Reflection.Emit;

namespace Labb2_Arv
{
	internal class Program
	{
		static void Main(string[] args)
		{
		}
	}

	abstract class Animal
	{
		public string Classification { get; set; }
		public string Breed { get; set; }
		public string MovementType { get; }
		public double Speed { get; set; }
		public string Diet { get; set; }
		public virtual void MakeSound()
		{
			Console.WriteLine("No Sound");
		}
		public virtual void Move()
		{
			Console.WriteLine($"{Breed} {MovementType}s at {Speed}km/h");
		}
		public virtual void Eat()
		{
			Console.WriteLine($"{Breed} eats {Diet}");
		}
	}

	abstract class Dog : Animal
	{
		public string Name { get; set; }
		public Dog() : base ()
		{

		}
	}



}
