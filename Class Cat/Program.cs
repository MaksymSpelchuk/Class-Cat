using System;


    public enum Gender
    {
        Male,
        Female
    }

    public class Cat
    {
        public string Name { get; }
        public Gender Gender { get; }

        private double _energy;

        public double Energy
        {
            get => _energy;
            private set
            {
                if (value < MinEnergy)
                    throw new Exception("Not enough energy to jump");
                _energy = value > MaxEnergy ? MaxEnergy : value;
            }
        }

        public static readonly double MaxEnergy = 20;
        public static readonly double MinEnergy = 0;
        public static readonly double SleepEnergyGain = 10;
        public static readonly double JumpEnergyDrain = 0.5;

        public Cat(string name, Gender gender)
        {
            Name = name;
            Gender = gender;
            Energy = MaxEnergy; 
        }

        public void Jump()
        {
            Energy -= JumpEnergyDrain;
        }

        public void Sleep()
        {
            Energy += SleepEnergyGain;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cat myCat = new Cat("Whiskers", Gender.Male);

            Console.WriteLine($"Cat {myCat.Name}, Gender: {myCat.Gender}, Energy: {myCat.Energy}");

            myCat.Jump();
            Console.WriteLine($"After Jump: Energy = {myCat.Energy}");

            myCat.Sleep();
            Console.WriteLine($"After Sleep: Energy = {myCat.Energy}");
        }
    }

