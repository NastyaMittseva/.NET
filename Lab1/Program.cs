using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        public static void Main()
        {
            // Вызов абстрактной фабрики №1
            AircraftFactory airbus_aircraft = new AirbusFactory();
            Client c1 = new Client(airbus_aircraft);
            c1.Run();
            // Вызов абстрактной фабрики №2     
            AircraftFactory boeing_factory = new BoeingFactory();
            Client c2 = new Client(boeing_factory);
            c2.Run();

            // Вызов абстрактной фабрики №3     
            AircraftFactory embraer_factory = new EmbraerFactory();
            Client c3 = new Client(embraer_factory);
            c3.Run();

            Console.Read();
        }

        // Класс абстрактной фабрики
        abstract class AircraftFactory
        {
            public abstract AbstractAircraft CreateAircraft();
            public abstract AbstractEngine CreateEngine();
        }

        // Класс фабрики №1
        class AirbusFactory : AircraftFactory
        {
            public override AbstractAircraft CreateAircraft()
            {
                return new AirbusAircraft();
            }
            public override AbstractEngine CreateEngine()
            {
                return new AirbusEngine();
            }
        }

        // Класс фабрики №2
        class BoeingFactory : AircraftFactory
        {
            public override AbstractAircraft CreateAircraft()
            {
                return new BoeingAircraft();
            }
            public override AbstractEngine CreateEngine()
            {
                return new BoeingEngine();
            }
        }

        // Класс фабрики №3
        class EmbraerFactory : AircraftFactory
        {
            public override AbstractAircraft CreateAircraft()
            {
                return new EmbraerAircraft();
            }
            public override AbstractEngine CreateEngine()
            {
                return new EmbraerEngine();
            }
        }

        // Абстрактный класс продукта А
        abstract class AbstractAircraft
        {
            public abstract void MaxSpeed(AbstractEngine engine);
        }

        // Абстрактный класс продукта В
        abstract class AbstractEngine
        {
             //public int max_speed;
             private int max_speed;
             public int Max_speed
             {
                get
                {
                    return max_speed;
                }
                set
                {
                    max_speed = value;
                }
             }
        }

        // Первый класс продукта типа А
        class AirbusAircraft : AbstractAircraft
        {
            public override void MaxSpeed(AbstractEngine engine)
            {
                Console.WriteLine("Макcимальная скорость самолета Airbus: " +engine.Max_speed.ToString() + " км/ч");
            }
        }

        // Первый класс продукта типа В
        class AirbusEngine : AbstractEngine
        {
            public AirbusEngine()
            {
                Max_speed = 871;
            }
        }

        // Второй класс продукта типа А
        class BoeingAircraft : AbstractAircraft
        {
            public override void MaxSpeed(AbstractEngine engine)
            {
                Console.WriteLine("Макcимальная скорость самолета Boeing: " +engine.Max_speed.ToString() + " км/ч");
            }
        }

        // Второй класс продукта типа В
        class BoeingEngine : AbstractEngine
        {
            public BoeingEngine()
            {
                Max_speed = 988;
            }
        }

        // Третий класс продукта типа А
        class EmbraerAircraft : AbstractAircraft
        {
            public override void MaxSpeed(AbstractEngine engine)
            {
                Console.WriteLine("Макcимальная скорость самолета Embraer: " + engine.Max_speed.ToString() + " км/ч");
            }
        }

        // Третий класс продукта типа В
        class EmbraerEngine : AbstractEngine
        {
            public EmbraerEngine()
            {
                Max_speed = 834;
            }
        }
        // Класс клиента, в котором происходит взаимодействие между объектами
        class Client
        {
            private AbstractAircraft abstractAircraft;
            private AbstractEngine abstractEngine;
            // Конструктор
            public Client(AircraftFactory aircraft_factory)
            {
                abstractAircraft = aircraft_factory.CreateAircraft();
                abstractEngine = aircraft_factory.CreateEngine();
            }
            public void Run()
            {
                abstractAircraft.MaxSpeed(abstractEngine);
            }
        } 
    }
}
