namespace Tamagotchi
{
     interface IAnimal
     {
          public string Name { get; }
          public double Age { get; set; }

          void Eat();
          void Drink();
          void Play();
          void Clean();
          void Sleep();
          void Speak();
          void Die();

     }
}