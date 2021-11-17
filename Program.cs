using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
     internal class Program
     {
          static void StringToCommand(AbstractAnimal animal, ConsoleKey Key)
          {
               switch (Key)
               {
                    case ConsoleKey.D1:
                         animal.Eat();
                         Console.WriteLine($"{animal.Name}, покормлен");
                         break;
                    case ConsoleKey.D2:
                         animal.Drink();
                         Console.WriteLine($"{animal.Name}, напоен");
                         break;
                    case ConsoleKey.D3:
                         animal.Play();
                         Console.WriteLine($"{animal.Name}, поиграл");
                         break;
                    case ConsoleKey.D4:
                         animal.Sleep();
                         Console.WriteLine($"{animal.Name}, поспал");
                         break;
                    case ConsoleKey.D5:
                         animal.Clean();
                         Console.WriteLine($"{animal.Name}, снова чистый");
                         break;
                    case ConsoleKey.D6:
                         animal.Speak();
                         break;
                    default:
                         Console.WriteLine(" не понятно...");
                         break;
               }

          }

          static void Main()
          {
               Console.Write(" Введите имя кота: ");
               string a = Console.ReadLine();
               Cat ad = new Cat(a);
               Console.WriteLine(" 1 - есть \n 2 - вода \n 3 - играть \n 4 - спать \n 5 - чистить \n 6 - говорить");
               while (ad.isAlive())
               {
                    var key = Console.ReadKey(true).Key;
                    StringToCommand(ad, key);
               }    
          }
     }
}