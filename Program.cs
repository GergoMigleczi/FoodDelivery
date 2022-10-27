using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FoodDelivery
{
    struct Delivery
    {
        public int dayOfTheWeek;
        public int deliveryOfTheDay;
        public int distance;

        public Delivery(int dayOfTheWeek, int deliveryOfTheDay, int distance)
        {
            this.dayOfTheWeek = dayOfTheWeek;
            this.deliveryOfTheDay = deliveryOfTheDay;
            this.distance = distance;
        }
    }
    class FoodDelivery
    {
        static List<Delivery> Deliveries = new List<Delivery>();

        //Read the txt file and store the data
        //The txt file contains information of a week of delivery
        //The order of the information might not be the same as the actual order of the deliveries 
        static void Task1()
        {
            StreamReader sr = new StreamReader("tavok.txt");
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split();
                int dayOfTheWeek = int.Parse(line[0]);
                int deliveryOfTheDay = int.Parse(line[1]);
                int distance = int.Parse(line[2]);

                Delivery row = new Delivery(dayOfTheWeek, deliveryOfTheDay, distance);
                Deliveries.Add(row);
            }
            sr.Close();
        }

        //Print the distance of the first delivery of the week. 
        static void Task2()
        {
            Console.WriteLine("Task 2");

            int min = 8;
            foreach (Delivery row in Deliveries) // The first day of the week on which the worker has delivered. 
            {
                if (row.dayOfTheWeek < min)
                    min = row.dayOfTheWeek;
            }
            foreach (Delivery row in Deliveries)
            {
                if (row.dayOfTheWeek == min && row.deliveryOfTheDay == 1)
                {
                    Console.WriteLine($"First delivery of the week was {row.distance} km");
                }
            }
        }

        //Print the distance of the last delivery of the week
        static void Task3()
        {
            Console.WriteLine("Task");
            int mostDeliveries = 0;
            int lastDelivery = 0;
            foreach (Delivery row in Deliveries)
            {
                if (row.dayOfTheWeek > mostDeliveries)
                    mostDeliveries = row.dayOfTheWeek;
            }
            foreach (Delivery row in Deliveries)
            {
                if (row.dayOfTheWeek == mostDeliveries)
                    if (row.deliveryOfTheDay > lastDelivery)
                        lastDelivery = row.deliveryOfTheDay;
            }
            foreach (Delivery row in Deliveries)
            {
                if (row.dayOfTheWeek == mostDeliveries && row.deliveryOfTheDay == lastDelivery)
                {
                    Console.WriteLine($"The last delivery of the week was {row.distance} km");
                }
            }
        }

        //It is sure that the worker has at least one day of rest a week. Print the days on which teh worker did not work.
        static void Task4()
        {
            Console.WriteLine("Task 4");
            List<int> days = new List<int>();
            foreach (Delivery row in Deliveries)
            {
                if (!days.Contains(row.dayOfTheWeek))
                    days.Add(row.dayOfTheWeek);
            }
            int[] week = { 1, 2, 3, 4, 5, 6, 7 };
            List<int> didNotWork = new List<int>();
            foreach (int item in days)
            {
                foreach (int i in week)
                {
                    if (!days.Contains(i) && !didNotWork.Contains(i))
                    {
                        didNotWork.Add(i);
                    }
                }
            }
            foreach (int item in didNotWork)
            {
                Console.WriteLine($"The employee did not work on the day number {item}.");
            }
        }

        //Print the number of the day on which the most delivery has happened
        static void Task5()
        {
            Console.WriteLine("Task 5");
            int mostDeliveries = 0;
            foreach (Delivery row in Deliveries)
            {
                if (row.deliveryOfTheDay > mostDeliveries)
                    mostDeliveries = row.deliveryOfTheDay;
            }
            foreach (Delivery row in Deliveries)
            {
                if (row.deliveryOfTheDay == mostDeliveries)
                    Console.WriteLine($"Day number {row.dayOfTheWeek} was the busiest day.");
            }
        }

        //Print the total distance of the deliveries per day
        static void Task6()
        {
            Console.WriteLine("Task 6");
            int[] week = { 1, 2, 3, 4, 5, 6, 7 };

            foreach (int i in week)
            {
                int totalDistance = 0;
                foreach (Delivery row in Deliveries)
                {
                    if (row.dayOfTheWeek == i)
                    {
                        totalDistance += row.distance;
                    }
                }
                Console.WriteLine($"{i}. day of the week: {totalDistance} km. ");
            }
        }

        //Calculate the price of a delivery that the user writes on the console
        /*
            1 – 2 km 500 Ft
            3 – 5 km 700 Ft
            6 – 10 km 900 Ft
            11 – 20 km 1 400 Ft
            21 – 30 km 2 000 Ft
        */
        static void Task7()
        {
            Console.WriteLine("Task 7");
            Console.WriteLine("Distance of the delivery in km:");
            int distance = int.Parse(Console.ReadLine());

            if (distance > 0 && distance <= 2)
            {
                Console.WriteLine($"For {distance} km you earn 500 Ft");
            }
            else if (distance <= 5)
            {
                Console.WriteLine($"For {distance} km you earn 700 Ft ");
            }
            else if (distance <= 10)
            {
                Console.WriteLine($"For {distance} km you earn 900 Ft ");
            }
            else if (distance <= 20)
            {
                Console.WriteLine($"For {distance} km you earn 1400 Ft ");
            }
            else if (distance <= 30)
            {
                Console.WriteLine($"For {distance} km you earn 2000 Ft ");
            }


        }

        //Calculate the price of each delivery in the txt file. List it in a txt file named dijazas.txt and order it by days and the delivery of the day. 
        static void Task8()
        {
            Console.WriteLine("Task 8 - dijazas.txt");
            StreamWriter sw = new StreamWriter("dijazas.txt");
            int[] week = { 1, 2, 3, 4, 5, 6, 7 };
            foreach (int i in week)
            {
                int orderOfDeliveries = 1;
                foreach (Delivery row in Deliveries)
                {
                    if (row.dayOfTheWeek == i && row.deliveryOfTheDay == orderOfDeliveries)
                    {
                        orderOfDeliveries++;
                        if (row.distance > 0 && row.distance <= 2)
                        {
                            sw.WriteLine($"{i}. day of the week {row.deliveryOfTheDay}. delivery: 500 Ft");
                        }
                        else if (row.distance <= 5)
                        {
                            sw.WriteLine($"{i}. day of the week {row.deliveryOfTheDay}. delivery: 700 Ft");
                        }
                        else if (row.distance <= 10)
                        {
                            sw.WriteLine($"{i}. day of the week {row.deliveryOfTheDay}. delivery: 900 Ft");
                        }
                        else if (row.distance <= 20)
                        {
                            sw.WriteLine($"{i}. day of the week {row.deliveryOfTheDay}. delivery: 1400 Ft");
                        }
                        else if (row.distance <= 30)
                        {
                            sw.WriteLine($"{i}. day of the week {row.deliveryOfTheDay}. delivery: 2000 Ft");
                        }

                    }
                }
            }
            sw.Flush();
            sw.Close();
        }

        //Calculate how much the employee earned throughout the week.
        static void Task9()
        {
            Console.WriteLine("Task 9");
            int income = 0;
            foreach (Delivery row in Deliveries)
            {
                if (row.distance > 0 && row.distance <= 2)
                {
                    income += 500;
                }
                else if (row.distance <= 5)
                {
                    income += 700;
                }
                else if (row.distance <= 10)
                {
                    income += 900;
                }
                else if (row.distance <= 20)
                {
                    income += 1400;
                }
                else if (row.distance <= 30)
                {
                    income += 2000;
                }
            }
            Console.WriteLine($"The employee has earnt {income} Ft");
        }
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Task7();
            Task8();
            Task9();
            Console.ReadKey();
        }
    }
}
