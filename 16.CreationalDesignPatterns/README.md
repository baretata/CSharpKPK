# Creational Design Patterns Homework
Homework: Select 3 creational design patterns and write a short description (about half page) for each of them, provide your own C# examples for their use and UML diagram or image of the pattern


### Examined creational design patterns:
1.   Signleton
2.   Builder
3.   Abstract Factory

## Singleton

### Short Description
* **Summary**
    - In software engineering, the singleton pattern is a design pattern that restricts the instantiation of a class to one object. This is useful when exactly one object is needed to coordinate actions across the system. The concept is sometimes generalized to systems that operate more efficiently when only one object exists, or that restrict the instantiation to a certain number of objects. 
* **Use**
    - The Abstract Factory, Builder, and Prototype patterns can use Singletons in their implementation.
Facade objects are often singletons because only one Facade object is required.
State objects are often singletons.
Singletons are often preferred to global variables because they do not pollute the global namespace (or, in languages with namespaces, their containing namespace) with unnecessary variables and they permit lazy allocation and initialization, whereas global variables in many languages will always consume resources.
* **Implementation**
    - Implementation of a singleton pattern must satisfy the single instance and global access principles. It requires a mechanism to access the singleton class member without creating a class object and a mechanism to persist the value of class members among class objects. The singleton pattern is implemented by creating a class with a method that creates a new instance of the class if one does not exist. If an instance already exists, it simply returns a reference to that object. To make sure that the object cannot be instantiated any other way, the constructor is made private.
* **Problems**
    - The singleton pattern must be carefully constructed in multi-threaded applications. If two threads are to execute the creation method at the same time when a singleton does not yet exist, they both must check for an instance of the singleton and then only one should create the new one.

### C# Example
~~~c#
using System;
 
namespace Singleton.Structural
{
  class MainApp
  {
    static void Main()
    {
      Singleton s1 = Singleton.Instance();
      Singleton s2 = Singleton.Instance();
 
      // Test for same instance
      if (s1 == s2)
      {
        Console.WriteLine("Objects are the same instance");
      }
 
      Console.ReadKey();
    }
  }
 
  class Singleton
  {
    private static Singleton _instance;
 
    protected Singleton()
    {
    }
 
    public static Singleton Instance()
    {
      // Uses lazy initialization.
      // Note: this is not thread safe.
      if (_instance == null)
      {
        _instance = new Singleton();
      }
 
      return _instance;
    }
  }
}
~~~

### UML Diagram
![Singleton Pattern](http://4.bp.blogspot.com/-mmHtXLirrEY/U1jpDIr_jiI/AAAAAAAACL4/eW_nMjihd5Q/s320/singleton.png "Singleton Design Pattern UML Diagram")


## Builder

### Short Description
* **Summary**
    - The builder pattern is an object creation software design pattern. Unlike the abstract factory pattern and the factory method pattern whose intention is to enable polymorphism, the intention of the builder pattern is to find a solution to the telescoping constructor anti-pattern[citation needed]. The telescoping constructor anti-pattern occurs when the increase of object constructor parameter combination leads to an exponential list of constructors. Instead of using numerous constructors, the builder pattern uses another object, a builder, that receives each initialization parameter step by step and then returns the resulting constructed object at once.
* **Use**
    - Builder - Abstract interface for creating objects (product).
    - Concrete Builder - Provides implementation for Builder. It is an object able to construct other objects. Constructs and assembles parts to build the objects.
* **Implementation**
    - Builder often builds a Composite. Often, designs start out using Factory Method (less complicated, more customizable, subclasses proliferate) and evolve toward Abstract Factory, Prototype, or Builder (more flexible, more complex) as the designer discovers where more flexibility is needed. Sometimes creational patterns are complementary: Builder can use one of the other patterns to implement which components are built. Builders are good candidates for a fluent interface.

### C# Example
~~~c#
using System;
using System.Collections.Generic;
 
namespace Builder.Structural
{
  public class MainApp
  {
    public static void Main()
    {
      // Create director and builders
      Director director = new Director();
 
      Builder b1 = new ConcreteBuilder1();
      Builder b2 = new ConcreteBuilder2();
 
      // Construct two products
      director.Construct(b1);
      Product p1 = b1.GetResult();
      p1.Show();
 
      director.Construct(b2);
      Product p2 = b2.GetResult();
      p2.Show();
 
      Console.ReadKey();
    }
  }
 
  class Director
  {
    // Builder uses a complex series of steps
    public void Construct(Builder builder)
    {
      builder.BuildPartA();
      builder.BuildPartB();
    }
  }
 
  /// <summary>
  /// The 'Builder' abstract class
  /// </summary>
  abstract class Builder
  {
    public abstract void BuildPartA();
    public abstract void BuildPartB();
    public abstract Product GetResult();
  }
 
  /// <summary>
  /// The 'ConcreteBuilder1' class
  /// </summary>
  class ConcreteBuilder1 : Builder
  {
    private Product _product = new Product();
 
    public override void BuildPartA()
    {
      _product.Add("PartA");
    }
 
    public override void BuildPartB()
    {
      _product.Add("PartB");
    }
 
    public override Product GetResult()
    {
      return _product;
    }
  }
 
  /// <summary>
  /// The 'ConcreteBuilder2' class
  /// </summary>
  class ConcreteBuilder2 : Builder
  {
    private Product _product = new Product();
 
    public override void BuildPartA()
    {
      _product.Add("PartX");
    }
 
    public override void BuildPartB()
    {
      _product.Add("PartY");
    }
 
    public override Product GetResult()
    {
      return _product;
    }
  }
 
  /// <summary>
  /// The 'Product' class
  /// </summary>
  class Product
  {
    private List<string> _parts = new List<string>();
 
    public void Add(string part)
    {
      _parts.Add(part);
    }
 
    public void Show()
    {
      Console.WriteLine("\nProduct Parts -------");
      foreach (string part in _parts)
        Console.WriteLine(part);
    }
  }
}
~~~

### UML Diagram
![Builder Pattern](http://www.dofactory.com/images/diagrams/net/builder.gif "Builder Design Pattern UML Diagram")


## Abstract Factory

### Short Description
* **Summary**
    - The abstract factory pattern provides a way to encapsulate a group of individual factories that have a common theme without specifying their concrete classes.In normal usage, the client software creates a concrete implementation of the abstract factory and then uses the generic interface of the factory to create the concrete objects that are part of the theme. The client doesn't know (or care) which concrete objects it gets from each of these internal factories, since it uses only the generic interfaces of their products.This pattern separates the details of implementation of a set of objects from their general usage and relies on object composition, as object creation is implemented in methods exposed in the factory interface.
* **Use**
    - The factory determines the actual concrete type of object to be created, and it is here that the object is actually created.However, the factory only returns an abstract pointer to the created concrete object.This insulates client code from object creation by having clients ask a factory object to create an object of the desired abstract type and to return an abstract pointer to the object.
    - As the factory only returns an abstract pointer, the client code (that requested the object from the factory) does not know — and is not burdened by — the actual concrete type of the object that was just created. However, the type of a concrete object (and hence a concrete factory) is known by the abstract factory.
    
### C# Example
~~~c#
using System;
 
namespace AbstractFactory.Structural
{
  class MainApp
  {
    public static void Main()
    {
      // Abstract factory #1
      AbstractFactory factory1 = new ConcreteFactory1();
      Client client1 = new Client(factory1);
      client1.Run();
 
      // Abstract factory #2
      AbstractFactory factory2 = new ConcreteFactory2();
      Client client2 = new Client(factory2);
      client2.Run();
 
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'AbstractFactory' abstract class
  /// </summary>
  abstract class AbstractFactory
  {
    public abstract AbstractProductA CreateProductA();
    public abstract AbstractProductB CreateProductB();
  }
 
  /// <summary>
  /// The 'ConcreteFactory1' class
  /// </summary>
  class ConcreteFactory1 : AbstractFactory
  {
    public override AbstractProductA CreateProductA()
    {
      return new ProductA1();
    }
    public override AbstractProductB CreateProductB()
    {
      return new ProductB1();
    }
  }
 
  /// <summary>
  /// The 'ConcreteFactory2' class
  /// </summary>
  class ConcreteFactory2 : AbstractFactory
  {
    public override AbstractProductA CreateProductA()
    {
      return new ProductA2();
    }
    public override AbstractProductB CreateProductB()
    {
      return new ProductB2();
    }
  }
 
  /// <summary>
  /// The 'AbstractProductA' abstract class
  /// </summary>
  abstract class AbstractProductA
  {
  }
 
  /// <summary>
  /// The 'AbstractProductB' abstract class
  /// </summary>
  abstract class AbstractProductB
  {
    public abstract void Interact(AbstractProductA a);
  }
 
 
  /// <summary>
  /// The 'ProductA1' class
  /// </summary>
  class ProductA1 : AbstractProductA
  {
  }
 
  /// <summary>
  /// The 'ProductB1' class
  /// </summary>
  class ProductB1 : AbstractProductB
  {
    public override void Interact(AbstractProductA a)
    {
      Console.WriteLine(this.GetType().Name +
        " interacts with " + a.GetType().Name);
    }
  }
 
  /// <summary>
  /// The 'ProductA2' class
  /// </summary>
  class ProductA2 : AbstractProductA
  {
  }
 
  /// <summary>
  /// The 'ProductB2' class
  /// </summary>
  class ProductB2 : AbstractProductB
  {
    public override void Interact(AbstractProductA a)
    {
      Console.WriteLine(this.GetType().Name +
        " interacts with " + a.GetType().Name);
    }
  }
 
  /// <summary>
  /// The 'Client' class. Interaction environment for the products.
  /// </summary>
  class Client
  {
    private AbstractProductA _abstractProductA;
    private AbstractProductB _abstractProductB;
 
    // Constructor
    public Client(AbstractFactory factory)
    {
      _abstractProductB = factory.CreateProductB();
      _abstractProductA = factory.CreateProductA();
    }
 
    public void Run()
    {
      _abstractProductB.Interact(_abstractProductA);
    }
  }
}
~~~

### UML Diagram

![Abstract Factory Pattern](http://www.dofactory.com/images/diagrams/net/abstract.gif "Abstract Factory Design Pattern UML Diagram")
