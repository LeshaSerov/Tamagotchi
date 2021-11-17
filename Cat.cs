using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
     internal class Cat : AbstractAnimal
     {
          public Cat(string name) : base(name) { }
          public override void Speak()
          {
               Console.WriteLine("Мяу!");
          }

     }
}