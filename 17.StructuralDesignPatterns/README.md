# Structural Design Patterns Homework
Homework: Select 3 structural design patterns and write a short description (about half page) for each of them, provide your own C# examples for their use and UML diagram or image of the pattern


### Examined structural design patterns:
1.   Composite
2.   Flyweight
3.   Bridge

## Composite

### Short Description
* **Summary**
    - The composite pattern describes that a group of objects is to be treated in the same way as a single instance of an object. The intent of a composite is to "compose" objects into tree structures to represent part-whole hierarchies. Implementing the composite pattern lets clients treat individual objects and compositions uniformly
* **Description**
    - When dealing with Tree-structured data, we often have to discriminate between a leaf-node and a branch. This makes code more complex, and therefore, error prone. The solution is an interface that allows treating complex and primitive objects uniformly. In object-oriented programming, a composite is an object designed as a composition of one-or-more similar objects, all exhibiting similar functionality. This is known as a "has-a" relationship between objects.The key concept is that you can manipulate a single instance of the object just as you would manipulate a group of them. The operations you can perform on all the composite objects often have a least common denominator relationship. For example, if defining a system to portray grouped shapes on a screen, it would be useful to define resizing a group of shapes to have the same effect (in some sense) as resizing a single shape.
* **Use**
    - Composite should be used when clients ignore the difference between compositions of objects and individual objects.If programmers find that they are using multiple objects in the same way, and often have nearly identical code to handle each of them, then composite is a good choice; it is less complex in this situation to treat primitives and composites as homogeneous.
    
### C# Example
~~~c#
using System;
using System.Collections.Generic;
 
namespace Composite.Structural
{
  class MainApp
  {
    static void Main()
    {
      // Create a tree structure
      Composite root = new Composite("root");
      root.Add(new Leaf("Leaf A"));
      root.Add(new Leaf("Leaf B"));
 
      Composite comp = new Composite("Composite X");
      comp.Add(new Leaf("Leaf XA"));
      comp.Add(new Leaf("Leaf XB"));
 
      root.Add(comp);
      root.Add(new Leaf("Leaf C"));
 
      // Add and remove a leaf
      Leaf leaf = new Leaf("Leaf D");
      root.Add(leaf);
      root.Remove(leaf);
 
      // Recursively display tree
      root.Display(1);
 
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Component' abstract class
  /// </summary>
  abstract class Component
  {
    protected string name;
 
    // Constructor
    public Component(string name)
    {
      this.name = name;
    }
 
    public abstract void Add(Component c);
    public abstract void Remove(Component c);
    public abstract void Display(int depth);
  }
 
  /// <summary>
  /// The 'Composite' class
  /// </summary>
  class Composite : Component
  {
    private List<Component> _children = new List<Component>();
 
    // Constructor
    public Composite(string name)
      : base(name)
    {
    }
 
    public override void Add(Component component)
    {
      _children.Add(component);
    }
 
    public override void Remove(Component component)
    {
      _children.Remove(component);
    }
 
    public override void Display(int depth)
    {
      Console.WriteLine(new String('-', depth) + name);
 
      // Recursively display child nodes
      foreach (Component component in _children)
      {
        component.Display(depth + 2);
      }
    }
  }
 
  /// <summary>
  /// The 'Leaf' class
  /// </summary>
  class Leaf : Component
  {
    // Constructor
    public Leaf(string name)
      : base(name)
    {
    }
 
    public override void Add(Component c)
    {
      Console.WriteLine("Cannot add to a leaf");
    }
 
    public override void Remove(Component c)
    {
      Console.WriteLine("Cannot remove from a leaf");
    }
 
    public override void Display(int depth)
    {
      Console.WriteLine(new String('-', depth) + name);
    }
  }
}
~~~

### UML Diagram
![Composite Pattern](http://www.dofactory.com/images/diagrams/net/composite.gif "Composite Design Pattern UML Diagram")


## Flyweight

### Short Description
* **Summary**
    - A flyweight is an object that minimizes memory use by sharing as much data as possible with other similar objects; it is a way to use objects in large numbers when a simple repeated representation would use an unacceptable amount of memory. Often some parts of the object state can be shared, and it is common practice to hold them in external data structures and pass them to the flyweight objects temporarily when they are used.
* **Use**
    - The Abstract Factory, Builder, and Prototype patterns can use Singletons in their implementation.
Facade objects are often singletons because only one Facade object is required.
State objects are often singletons.
Singletons are often preferred to global variables because they do not pollute the global namespace (or, in languages with namespaces, their containing namespace) with unnecessary variables and they permit lazy allocation and initialization, whereas global variables in many languages will always consume resources.
* **Implementation**
    - Implementation of a singleton pattern must satisfy the single instance and global access principles. It requires a mechanism to access the singleton class member without creating a class object and a mechanism to persist the value of class members among class objects. The singleton pattern is implemented by creating a class with a method that creates a new instance of the class if one does not exist. If an instance already exists, it simply returns a reference to that object. To make sure that the object cannot be instantiated any other way, the constructor is made private.
* **Problems**
    - Special consideration must be made in scenarios where Flyweight objects are created on multiple threads. If the list of values is finite and known in advance the Flyweights can be instantiated ahead of time and retrieved from a container on multiple threads with no contention. If Flyweights are instantiated on multiple threads there are two options:
        - Make Flyweight instantiation single threaded thus introducing contention and ensuring one instance per value.
        - Allow concurrent threads to create multiple Flyweight instances thus eliminating contention and allowing multiple instances per value. This option is only viable if the equality criterion is met.

### C# Example
~~~c#
using System;
using System.Collections;
 
namespace DoFactory.GangOfFour.Flyweight.Structural
{
  class MainApp
  {
    static void Main()
    {
      // Arbitrary extrinsic state
      int extrinsicstate = 22;
 
      FlyweightFactory factory = new FlyweightFactory();
 
      // Work with different flyweight instances
      Flyweight fx = factory.GetFlyweight("X");
      fx.Operation(--extrinsicstate);
 
      Flyweight fy = factory.GetFlyweight("Y");
      fy.Operation(--extrinsicstate);
 
      Flyweight fz = factory.GetFlyweight("Z");
      fz.Operation(--extrinsicstate);
 
      UnsharedConcreteFlyweight fu = new
        UnsharedConcreteFlyweight();
 
      fu.Operation(--extrinsicstate);
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'FlyweightFactory' class
  /// </summary>
  class FlyweightFactory
  {
    private Hashtable flyweights = new Hashtable();
 
    // Constructor
    public FlyweightFactory()
    {
      flyweights.Add("X", new ConcreteFlyweight());
      flyweights.Add("Y", new ConcreteFlyweight());
      flyweights.Add("Z", new ConcreteFlyweight());
    }
 
    public Flyweight GetFlyweight(string key)
    {
      return ((Flyweight)flyweights[key]);
    }
  }
 
  /// <summary>
  /// The 'Flyweight' abstract class
  /// </summary>
  abstract class Flyweight
  {
    public abstract void Operation(int extrinsicstate);
  }
 
  /// <summary>
  /// The 'ConcreteFlyweight' class
  /// </summary>
  class ConcreteFlyweight : Flyweight
  {
    public override void Operation(int extrinsicstate)
    {
      Console.WriteLine("ConcreteFlyweight: " + extrinsicstate);
    }
  }
 
  /// <summary>
  /// The 'UnsharedConcreteFlyweight' class
  /// </summary>
  class UnsharedConcreteFlyweight : Flyweight
  {
    public override void Operation(int extrinsicstate)
    {
      Console.WriteLine("UnsharedConcreteFlyweight: " +
        extrinsicstate);
    }
  }
}
~~~

### UML Diagram
![Flyweight Pattern](http://www.dofactory.com/images/diagrams/net/flyweight.gif "Flyweight Design Pattern UML Diagram")


## Bridge

### Short Description
* **Summary**
    - The bridge uses encapsulation, aggregation, and can use inheritance to separate responsibilities into different classes.When a class varies often, the features of object-oriented programming become very useful because changes to a program's code can be made easily with minimal prior knowledge about the program. The bridge pattern is useful when both the class and what it does vary often. The class itself can be thought of as the implementation and what the class can do as the abstraction. The bridge pattern can also be thought of as two layers of abstraction.
* **Implementation**(see UML diagram)
    - Abstraction (abstract class) - defines the abstract interface, maintains the Implementor reference.
    - RefinedAbstraction (normal class) - extends the interface defined by Abstraction.
    - Implementor (interface) - defines the interface for implementation classes.
    - ConcreteImplementor (normal class) - implements the Implementor interface.
* **Problems**
    - The bridge pattern is often confused with the adapter pattern.In fact, the bridge pattern is often implemented using the Adapter design pattern.

### C# Example
~~~c#
using System;
 
namespace DoFactory.GangOfFour.Bridge.Structural
{
  class MainApp
  {
    static void Main()
    {
      Abstraction ab = new RefinedAbstraction();
 
      // Set implementation and call
      ab.Implementor = new ConcreteImplementorA();
      ab.Operation();
 
      // Change implemention and call
      ab.Implementor = new ConcreteImplementorB();
      ab.Operation();
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Abstraction' class
  /// </summary>
  class Abstraction
  {
    protected Implementor implementor;
 
    // Property
    public Implementor Implementor
    {
      set { implementor = value; }
    }
 
    public virtual void Operation()
    {
      implementor.Operation();
    }
  }
 
  /// <summary>
  /// The 'Implementor' abstract class
  /// </summary>
  abstract class Implementor
  {
    public abstract void Operation();
  }
 
  /// <summary>
  /// The 'RefinedAbstraction' class
  /// </summary>
  class RefinedAbstraction : Abstraction
  {
    public override void Operation()
    {
      implementor.Operation();
    }
  }
 
  /// <summary>
  /// The 'ConcreteImplementorA' class
  /// </summary>
  class ConcreteImplementorA : Implementor
  {
    public override void Operation()
    {
      Console.WriteLine("ConcreteImplementorA Operation");
    }
  }
 
  /// <summary>
  /// The 'ConcreteImplementorB' class
  /// </summary>
  class ConcreteImplementorB : Implementor
  {
    public override void Operation()
    {
      Console.WriteLine("ConcreteImplementorB Operation");
    }
  }
}
~~~

### UML Diagram
![Singleton Pattern](http://www.dofactory.com/images/diagrams/net/bridge.gif "Singleton Design Pattern UML Diagram")
