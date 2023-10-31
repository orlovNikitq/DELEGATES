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
