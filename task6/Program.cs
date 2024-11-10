using System;
namespace FactoryMethodAndFacadeExample
{
    //абстрактний клас творця, який має абстрактний метод FactoryMethod, що приймає тип продукта
    public abstract class Creator
    {
        public abstract Product FactoryMethod(int type);
    }

    public class ConcreteCreator : Creator
    {
        public override Product FactoryMethod(int type)
        {
            switch (type)
            {
                //повертає об'єкт A, якщо type==1
                case 1: return new ConcreteProductA();
                //повертає об'єкт B, якщо type==2  
                case 2: return new ConcreteProductB();
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

    public abstract class Product { } //абстрактний клас продукт

    //конкретні продукти з різною реалізацією
    public class ConcreteProductA : Product { }

    public class ConcreteProductB : Product { }

    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // "Subsystem ClassA" 
    class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine(" SubSystemOne Method");
        }
    }

    // Subsystem ClassB" 
    class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine(" SubSystemTwo Method");
        }
    }


    // Subsystem ClassC" 
    class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine(" SubSystemThree Method");
        }
    }
    // Subsystem ClassD" 
    class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine(" SubSystemFour Method");
        }
    }
    // "Facade" 
    class Facade
    {
        SubSystemOne one;
        SubSystemTwo two;
        SubSystemThree three;
        SubSystemFour four;

        public Facade()
        {
            one = new SubSystemOne();
            two = new SubSystemTwo();
            three = new SubSystemThree();
            four = new SubSystemFour();
        }

        public void MethodA()
        {
            Console.WriteLine("\nMethodA() ---- ");
            one.MethodOne();
            two.MethodTwo();
            four.MethodFour();
        }

        public void MethodB()
        {
            Console.WriteLine("\nMethodB() ---- ");
            two.MethodTwo();
            three.MethodThree();
        }
    }
    class MainApp
    {
        static void Main()
        {
            Console.WriteLine("FactoryMethod pattern");
            //створюємо творця
            Creator creator = new ConcreteCreator();
            for (int i = 1; i <= 2; i++)
            {
                //створюємо спочатку продукт з типом 1, потім з типом 2
                var product = creator.FactoryMethod(i);
                Console.WriteLine("Where id = {0}, Created {1} ", i, product.GetType());
            }
            Console.WriteLine("Facade pattern");
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();

            Console.ReadKey();
        }
    }
}

