using System;
using System.Collections.Generic;

namespace Opgave1
{
    class Program
    {
        //Bil listen
        static List<CarHandler.Car> cars = new List<CarHandler.Car>();

        //Hovedmenu
        private static void MainMenu()
        {
            Console.WriteLine("Hej og velkommen til biladministrationen version 1997");
            Console.WriteLine("Du har nu to muligheder:");
            Console.WriteLine("Indtast en bil (1)");
            Console.WriteLine("Se informationer om alle biler (2)");
            Console.WriteLine("Søg efter et bilmærke (3)");
            Console.Write("Tast dit ønske: ");
        }
        //Tilføj en bil
        private static void AddCar()
        {
            Console.WriteLine("Du valgte at oprette en bil");
            Console.Write("Indtast mærke: ");
            string carMake = Console.ReadLine();

            Console.Write("Indtast model: ");
            string carModel = Console.ReadLine();

            Console.Write("Indtast årgang: ");
            int.TryParse(Console.ReadLine(), out int carYear);

            Console.Write("Indtast farve: ");
            string carColour = Console.ReadLine();

            //Hvis årgangen er større end det nuværende år eller mindre end 1886 får brugeren en fejlbesked 
            try
            {
                CarHandler.Car car = new CarHandler.Car(carMake, carModel, carYear, carColour);
                cars.Add(car);
                AttemptToStart(carYear);
                Console.WriteLine($"Du har indtastet en ny bil med disse informationer: {car.ToString()}");
            }
            catch(Exception)
            {
                Console.WriteLine("Året er enten før at bilen blev opfundet, eller i fremtiden. Prøv igen");
            }
            Console.ReadLine();
            Console.Clear();
        }

        //Se bilernes information
        private static void CarInfo()
        {
            Console.WriteLine("Alle bilers information:\n");
            int i = 0;
            foreach(CarHandler.Car car in cars)
            {
                Console.WriteLine(car);
                i++;
            }
            if(i == 0)
            {
                Console.WriteLine("Der er ingen biler endnu.");
            }
            Console.ReadLine();
            Console.Clear();
        }

        //Søg efter bilmærke
        private static void SearchForMake()
        {
            Console.Write("Skriv bilmærket du vil søge på: ");
            string input = Console.ReadLine().ToLower();
            int i = 0;
            Console.WriteLine("Resultatet af din søgning: \n");
            foreach(CarHandler.Car car in cars)
            {
                if(car.Make.ToLower() == input)
                {
                    Console.WriteLine(car);
                    i++;
                }
            }
            if(i == 0)
            {
                Console.WriteLine("Ingen biler med dette mærke findes");
            }
            Console.ReadLine();
            Console.Clear();
        }
        private static bool AttemptToStart(int productionYear)
        {
            bool willStart = false;
            Random starts = new Random();
            int chanceOfStart = 0;
            //Jo ældre bilen er, jo mindre sandsynlighed er der for at den vil starte
            for(int i = 0; willStart == false; i++)
            {
                if(productionYear < 2020 && productionYear > 2000)
                {
                    chanceOfStart = starts.Next(1, 2);
                }
                else if(productionYear < 2000 && productionYear > 1980)
                {
                    chanceOfStart = starts.Next(1, 3);
                }
                else if(productionYear < 1980 && productionYear > 1960)
                {
                    chanceOfStart = starts.Next(1, 5);
                }
                else if(productionYear < 1960 && productionYear > 1940)
                {
                    chanceOfStart = starts.Next(1, 8);
                }
                else
                {
                    chanceOfStart = starts.Next(1, 15);
                }
                if(chanceOfStart == 1)
                {
                    willStart = true;
                    Console.WriteLine($"Bilen brugte {i + 1} forsøg for at starte");
                    return true;
                }
                else
                {
                    willStart = false;
                }
                if(i >= 15)
                {
                    Console.WriteLine("Bilen kunne ikke starte");
                    return false;
                }
            }
            return false;
        }

        private static void Main()
        {
            while(true)
            { 
                MainMenu();
                string input = Console.ReadLine();

                if(input == "1")
                {
                    AddCar();
                }
                else if(input == "2")
                {
                    CarInfo();
                }
                else if(input == "3")
                {
                    SearchForMake();
                }
                else
                {
                    Console.WriteLine("Ugyldigt input! Prøv igen");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
