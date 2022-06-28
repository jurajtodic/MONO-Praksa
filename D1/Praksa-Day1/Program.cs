using System;
using System.Collections.Generic;


namespace Praksa_Day1
{
    abstract class Animal  
    {
        private string animalName;

        public void AnimalMessage()
        {
            Console.WriteLine("is an animal");
        }

        public abstract void PrintMessage();

        public string Name
        {
            get { return animalName; }
            set { animalName = value; }
        }
    }

    class Carnivore : Animal 
    {
        
        public override void PrintMessage()
        {
            Console.WriteLine("Hello from Carnivore class");
        }
    }

    class Herbivore : Animal
    {
        public override void PrintMessage()
        {
            Console.WriteLine("Hello from Herbivore class");
        }
    }

    interface IFish
    {
        void FishMessage();
    } 

    class Karp : IFish
    {
        public void FishMessage()
        {
            Console.WriteLine("Karp is a fish");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal myCarnivore = new Carnivore();
            Animal myHerbivore = new Herbivore();

            myCarnivore.PrintMessage();
            myHerbivore.PrintMessage();

            myCarnivore.Name = "Cheetah";
            myHerbivore.Name = "Buffalo";

            Karp myFish = new Karp();
            myFish.FishMessage();

            List<Animal> animals = new List<Animal>();
            animals.Add(myCarnivore);
            animals.Add(myHerbivore);

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.Name);
            }
        }
    }
}


