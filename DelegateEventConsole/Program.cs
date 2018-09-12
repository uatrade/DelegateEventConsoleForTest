using System;


namespace DelegateEventConsole
{
    delegate void Firstdeleg();
    delegate void Second(int x, int y);
    delegate void Third(string info);
    class Program
    {
        class ATM
        {
            Firstdeleg _del;
            Third _thirdDel;
            public event Third Added;
            public event Third Withdrowned;
            int total;

            public ATM(Firstdeleg firstdeleg, Third third)
            {
                _del = firstdeleg;
                _thirdDel = third;
            }

            public void Add(int num)
            {
                total += num;
                _del();
                _thirdDel(num.ToString()); //через delegat
                Added(num.ToString());
            }
            public void Withdrawn(int num)
            {
                total -= num;
                _del();
                _thirdDel(num.ToString());   //через delegate
                Withdrowned(num.ToString()); //через event
            }                
        }

        class Info
        {
            public void Display()
            {
                Console.WriteLine("Выполнена операция");
                
            }
            public void DisplayInfo(string info)
            {
                Console.WriteLine($"Выполнена операция на {info} грн.");
            }
        }

        static void Main(string[] args)
        {
            Info info = new Info();
            Firstdeleg delDisplay = info.Display;
            Third delThird = info.DisplayInfo;
            ATM aTM = new ATM(delDisplay, delThird);

            
            aTM.Added += info.DisplayInfo;
            aTM.Withdrowned += info.DisplayInfo;
            


            aTM.Add(150);
            aTM.Withdrawn(50);

        }
    }
}
