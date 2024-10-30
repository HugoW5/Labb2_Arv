using System.Reflection.Emit;

namespace Labb2_Arv
{
	internal class Program
	{
		static void Main(string[] args)
		{

			Animal[] animals = {
			new Dog("Bulldog"),
			new Salmon(5),
			new PufferFish(10)
			};

			foreach (var animal in animals)
			{
				Console.WriteLine(animal.ToString());
				animal.Move();
				animal.Eat();
				animal.MakeSound();
                Console.WriteLine("----------------------");
			}
			PufferFish pufferFish = new PufferFish(20.0);
			pufferFish.PuffUp(5);
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
		public bool IsPoisonous { get; set; } = true;
		public Fish()
		{
			base.Species = "N/A";
			base.MovementType = "swim";
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
			IsPoisonous = false;
			Diet = "Small Fish";
		}
		public override void Move()
		{
			Console.Write(Species + " ");
			base.Move();
		}
		public override void Eat()
		{
			Console.Write(Species + " ");
			base.Eat();
		}
	}

	class PufferFish : Fish
	{
		public double Volume { get; set; } = 5;
		public PufferFish(double volume)
		{
			Species = "Pufferfish";
			base.Speed = 3;
			WaterType = "Saltwater";
			IsPredator = true;
			IsPoisonous = true;
			Diet = "Seaweed";
			Volume = volume;
		}
		public override void Move()
		{
			Console.Write(Species + " ");
			base.Move();
		}
		public override void Eat()
		{
			Console.Write(Species + " ");
			base.Eat();
		}
		public void PuffUp(double increaseVolume)
		{
			Volume += increaseVolume;
			Console.WriteLine($"Pufferfish volume increased: +{increaseVolume}cm3");
		}
	}
}
