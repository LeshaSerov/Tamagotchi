using System;
using System.Threading;

namespace Tamagotchi
{
     abstract class AbstractAnimal : IAnimal
     {
          //Таймеры
          private Timer thirsting;//жажда
          private Timer starving;//голод
          private Timer boring;//скука
          private Timer dirtying;//грязь
          private Timer sleeping;//сон
          private Timer die;//смерть

          //Состояние Персонажа 
          private bool isStarving;//Голодный
          private bool isThirsy;//Жаждущий
          private bool isBoring;//Скучающий
          private bool isDirty;//Грязный
          private bool isIsomnia;//Бессоница
          private bool isDied;//Мертв

          public bool isAlive() { return !isDied; }

          //Интервалы времени
          private readonly TimeSpan timeToStarving = TimeSpan.FromSeconds(15); //Время до голода
          private readonly TimeSpan timeToThirsy = TimeSpan.FromSeconds(20); //Время до жажды
          private readonly TimeSpan timeToBoring = TimeSpan.FromSeconds(10); //Время до скуки
          private readonly TimeSpan timeToDirty = TimeSpan.FromSeconds(30); //Время до загрязнения
          private readonly TimeSpan timeToSleep = TimeSpan.FromSeconds(60); //Время до недосыпания
          private readonly TimeSpan timeToDie = TimeSpan.FromSeconds(25); //Время до смерти

          //Основные переменные
          public string Name { get; }//Имя
          public double Age { get; set; }//Возраст

          //Переопределяемые типы!
          public abstract void Speak();

          //Основные методы
          public void Eat()
          {
               die.Dispose();
               isStarving = false;
               starving.Change(timeToStarving, Timeout.InfiniteTimeSpan);
          }//Накормить
          public void Drink()
          {
               die.Dispose();
               isThirsy = false;
               thirsting.Change(timeToThirsy, Timeout.InfiniteTimeSpan);
          }//Напоить
          public void Play()
          {
               die.Dispose();
               isBoring = false;
               boring.Change(timeToBoring, Timeout.InfiniteTimeSpan);
          }//Поиграть
          public void Clean()
          {
               die.Dispose();
               isDirty = false;
               dirtying.Change(timeToDirty, Timeout.InfiniteTimeSpan);
          }//Убрать
          public void Sleep()
          {
               die.Dispose();
               isIsomnia = false;
               sleeping.Change(timeToSleep, Timeout.InfiniteTimeSpan);
          }//Уложить Спать
          public void Die()
          {
               isDied = true;
          }

          //Конструктор
          public AbstractAnimal(string name)
          {
               starving = new Timer(StartStarving, $"{name}, начал голодать", timeToStarving, Timeout.InfiniteTimeSpan);
               boring = new Timer(StartBoring, $"{name}, начал скучать", timeToBoring, Timeout.InfiniteTimeSpan);
               thirsting = new Timer(GetThirsty, $"{name}, начал умирать от жажды", timeToThirsy, Timeout.InfiniteTimeSpan);
               dirtying = new Timer(SufferFromDirt, $"{name}, страдает от грязи", timeToDirty, Timeout.InfiniteTimeSpan);
               sleeping = new Timer(SufferFromLackOfSleep, $"{name}, страдает бессоницей", timeToSleep, Timeout.InfiniteTimeSpan);
               die = new Timer(GetThirsty, null, TimeSpan.FromMinutes(5), Timeout.InfiniteTimeSpan);
               this.Name = name;
          }

          //Методы Конструктора
          private Timer dies(string state)
          { 
               return new Timer(KillAnimal, state, timeToDie, Timeout.InfiniteTimeSpan);
          }
          private void KillAnimal(object? state)
          {
               Console.WriteLine(state?.ToString());
               Die();
          }
          private void StartStarving(object state)
          {
               isStarving = true;
               die = dies($"{Name}, умер от голода");
               Console.WriteLine(state?.ToString());
          }
          private void SufferFromLackOfSleep(object state)
          {
               isIsomnia = true;
               die = dies($"{Name}, умер от бессоницы");
               Console.WriteLine(state?.ToString());
          }
          private void SufferFromDirt(object state)
          {
               isDirty = true;
               die = dies($"{Name}, умер от грязи");
               Console.WriteLine(state?.ToString());
          }
          private void GetThirsty(object state)
          {
               isThirsy = true;
               die = dies($"{Name}, умер от жажды");
               Console.WriteLine(state?.ToString());
          }
          private void StartBoring(object state)
          {
               isBoring = true;
               die = dies($"{Name}, умер от скуки");
               Console.WriteLine(state?.ToString());
          }
     }
}