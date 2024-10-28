using System.Reflection.Emit;

namespace Labb2_Arv
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Salmon salmon = new Salmon(10);
			Dog dog = new Dog("Bulldog");
			Console.WriteLine(salmon.ToString());
			Console.WriteLine(dog.ToString());

		}
	}

	abstract class Animal
	{
		public string Species { get; set; } = "N/A";
		public string MovementType { get; set; } = "N/A";
		public double Speed { get; set; } = 0;
		public string Diet { get; set; } = "N/A";
		public string Sound { get; set; } = "N/A";
		public virtual void MakeSound()
		{
			Console.WriteLine(Sound);
		}
		public virtual void Move()
		{
			Console.WriteLine($"{MovementType}s at {Speed}km/h");
		}
		public virtual void Eat()
		{
			Console.WriteLine($"eats {Diet}");
		}
		public override string ToString()
		{
			string s = $"--{this.GetType().Name}--\n";

			foreach (var property in this.GetType().GetProperties())
			{
				s += $"{property.Name}: {property.GetValue(this)}\n";
			}
			return s;
		}
	}

	class Dog : Animal
	{
		public string Breed { get; set; } = "N/A";
		public Dog(string initialBreed)
		{
			base.Species = "Dog";
			base.MovementType = "Run";
			base.Diet = "Dog Food";
			base.Speed = 20;
			base.Sound = "Woof";
			Breed = initialBreed;
		}
		public override void Move()
		{
			Console.Write(Breed + " ");
			base.Move();
		}
		public override void Eat()
		{
			Console.Write(Breed + " ");
			base.Eat();
		}
		public void Sit()
		{
			Console.WriteLine("Dog is sitting");
		}
	}

	abstract class Fish : Animal
	{
		public string WaterType { get; set; } = "N/A";
		public bool IsPredator { get; set; } = true;
		public Fish()
		{
			base.Species = "N/A";
			base.MovementType = "Swin";
			base.Diet = "N/A";
			base.Speed = 0;
			base.Sound = "bolb-blob";
		}
	}

	class Salmon : Fish
	{
		public Salmon(int speed)
		{
			Species = "Salmon";
			base.Speed = speed;
			WaterType = "Freshwater";
			IsPredator = true;
			Diet = "Small Fish";
		}
		public override void Move()
		{
            Console.Write(Species);
			base.Move();
		}
		public override void Eat()
		{
			Console.Write(Species + " ");
			base.Eat();
		}
	}

}
