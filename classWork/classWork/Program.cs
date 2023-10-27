//using MyApp;
//using System;
//using System.Runtime.InteropServices;
//using System.Transactions;

//namespace MyApp // Note: actual namespace depends on the project name.
//{
//    class Program
//    {
//        delegate void RaceDelegate(Car car);
//        static void Main(string[] args)
//        {

//            SportsCar sportsCar = new SportsCar("Ferrari", 150);
//            PassengerCar passengerCar = new PassengerCar("Toyota", 120);
//            Truck truck = new Truck("Volvo", 80);
//            Bus bus = new Bus("Mercedes", 60);

//            Console.WriteLine("Все автомобили выходят на старт.");
//            RaceDelegate race = (car) =>
//            {
//                Random random = new Random();
//                int distance = 0;

//                while (distance < 100)
//                {
//                    car.Move();
//                    distance += random.Next(car.Speed - 5, car.Speed + 5);                 
//                }
//            };

//            race(sportsCar);
//            race(passengerCar);
//            race(truck);
//            race(bus);

//            Car[] cars = { sportsCar, passengerCar, truck, bus };
//            Car winner = cars[0];

//            for (int i = 1; i < cars.Length; i++)
//            {
//                if (cars[i].Speed > winner.Speed)
//                {
//                    winner = cars[i];
//                }
//            }

//            Console.WriteLine($"{winner.Name} пришел к финишу и победил!");

//            Console.ReadLine();
//        }

//        abstract class Car
//        {
//            public string Name { get; set; }
//            public int Speed { get; set; }

//            public Car(string name, int speed)
//            {
//                Name = name;
//                Speed = speed;
//            }

//            public abstract void Move();
//        }

//        class SportsCar : Car
//        {
//            public SportsCar(string name, int speed) : base(name, speed) { }

//            public override void Move()
//            {
//                Console.WriteLine($"{Name} (Спорткар) движется со скоростью {Speed} км/ч.");
//            }
//        }

//        class PassengerCar : Car
//        {
//            public PassengerCar(string name, int speed) : base(name, speed) { }

//            public override void Move()
//            {
//                Console.WriteLine($"{Name} (Легковой автомобиль) движется со скоростью {Speed} км/ч.");
//            }
//        }

//        class Truck : Car
//        {
//            public Truck(string name, int speed) : base(name, speed) { }

//            public override void Move()
//            {
//                Console.WriteLine($"{Name} (Грузовой автомобиль) движется со скоростью {Speed} км/ч.");
//            }
//        }

//        class Bus : Car
//        {
//            public Bus(string name, int speed) : base(name, speed) { }

//            public override void Move()
//            {
//                Console.WriteLine($"{Name} (Автобус) движется со скоростью {Speed} км/ч.");
//            }
//        }
//    }
//}
using System;

namespace MyApp
{
    class Program
    {
        delegate void CarMoveEventHandler(Car car);
        static void Main(string[] args)
        {
            Car[] cars = {
                new SportsCar("Спортивный автомобиль", new Random().Next(1, 10)),
                new Sedan("Легковой автомобиль", new Random().Next(1, 10)),
                new Truck("Грузовик", new Random().Next(1, 10)),
                new Bus("Автобус", new Random().Next(1, 10))
            };

            CarMoveEventHandler carMoveEvent = car =>
            {
                car.Move();
                Console.WriteLine($"{car.Name} на позиции {car.Position}");

                if (car.Position >= 100)
                {
                    Console.WriteLine($"{car.Name} пришел к финишу и выиграл гонку!");
                    return;
                }
            };

            while (true)
            {
                bool flag = true;

                foreach (var car in cars)
                {
                    carMoveEvent(car);

                    if (car.Position >= 100)
                    {
                        flag = false;
                        break; 
                    }
                }

                if (!flag)
                {
                    break; 
                }
            }
        }


        abstract class Car
        {
            public string Name { get; set; }
            public int Speed { get; set; }
            public int Position { get; set; }

            public Car(string name, int speed)
            {
                Name = name;
                Speed = speed;
                Position = 0;
            }

            public abstract void Move();
        }


        class SportsCar : Car
        {
            public SportsCar(string name, int speed) : base(name, speed) { }

            public override void Move()
            {
                Position += Speed;
            }
        }

        class Sedan : Car
        {
            public Sedan(string name, int speed) : base(name, speed) { }

            public override void Move()
            {
                Position += Speed;
            }
        }

        class Truck : Car
        {
            public Truck(string name, int speed) : base(name, speed) { }

            public override void Move()
            {
                Position += Speed;
            }
        }

        class Bus : Car
        {
            public Bus(string name, int speed) : base(name, speed) { }

            public override void Move()
            {
                Position += Speed;
            }
        }
    }
}