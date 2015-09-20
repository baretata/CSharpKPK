# Behavioral Design Patterns Homework
Homework: Select 3 behavioral design patterns and write a short description (about half page) for each of them, provide your own C# examples for their use and UML diagram or image of the pattern


### Examined behavioral design patterns:
1.   Strategy
2.   Command
3.   Observer
4.   Specification

## Strategy

### Short Description
* **Summary**
    - The strategy pattern defines a family of algorithms, encapsulates each algorithm, and makes the algorithms interchangeable within that family.Strategy lets the algorithm vary independently from clients that use it.
* **Description**
    - A class that performs validation on incoming data may use a strategy pattern to select a validation algorithm based on the type of data, the source of the data, user choice, or other discriminating factors. These factors are not known for each case until run-time, and may require radically different validation to be performed. The validation strategies, encapsulated separately from the validating object, may be used by other validating objects in different areas of the system (or even different systems) without code duplication.
    
### C# Example
~~~c#
using System;
 
namespace Strategy.Behavioral
{
  class MainApp
  {
    static void Main()
    {
      Context context;
 
      // Three contexts following different strategies
      context = new Context(new ConcreteStrategyA());
      context.ContextInterface();
 
      context = new Context(new ConcreteStrategyB());
      context.ContextInterface();
 
      context = new Context(new ConcreteStrategyC());
      context.ContextInterface();
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Strategy' abstract class
  /// </summary>
  abstract class Strategy
  {
    public abstract void AlgorithmInterface();
  }
 
  /// <summary>
  /// A 'ConcreteStrategy' class
  /// </summary>
  class ConcreteStrategyA : Strategy
  {
    public override void AlgorithmInterface()
    {
      Console.WriteLine(
        "Called ConcreteStrategyA.AlgorithmInterface()");
    }
  }
 
  /// <summary>
  /// A 'ConcreteStrategy' class
  /// </summary>
  class ConcreteStrategyB : Strategy
  {
    public override void AlgorithmInterface()
    {
      Console.WriteLine(
        "Called ConcreteStrategyB.AlgorithmInterface()");
    }
  }
 
  /// <summary>
  /// A 'ConcreteStrategy' class
  /// </summary>
  class ConcreteStrategyC : Strategy
  {
    public override void AlgorithmInterface()
    {
      Console.WriteLine(
        "Called ConcreteStrategyC.AlgorithmInterface()");
    }
  }
 
  /// <summary>
  /// The 'Context' class
  /// </summary>
  class Context
  {
    private Strategy _strategy;
 
    // Constructor
    public Context(Strategy strategy)
    {
      this._strategy = strategy;
    }
 
    public void ContextInterface()
    {
      _strategy.AlgorithmInterface();
    }
  }
}
~~~

### UML Diagram
![Strategy Pattern](http://www.dofactory.com/images/diagrams/net/strategy.gif "Strategy Design Pattern UML Diagram")


## Command

### Short Description
* **Summary**
    - Command pattern is a behavioral design pattern in which an object is used to encapsulate all information needed to perform an action or trigger an event at a later time. This information includes the method name, the object that owns the method and values for the method parameters.
* **Description**
    - Four terms always associated with the command pattern are command, receiver, invoker and client. A command object knows about receiver and invokes a method of the receiver. Values for parameters of the receiver method are stored in the command. The receiver then does the work. An invoker object knows how to execute a command, and optionally does bookkeeping about the command execution. The invoker does not know anything about a concrete command, it knows only about command interface. Both an invoker object and several command objects are held by a client object. The client decides which commands to execute at which points. To execute a command, it passes the command object to the invoker object.
    - Using command objects makes it easier to construct general components that need to delegate, sequence or execute method calls at a time of their choosing without the need to know the class of the method or the method parameters. Using an invoker object allows bookkeeping about command executions to be conveniently performed, as well as implementing different modes for commands, which are managed by the invoker object, without the need for the client to be aware of the existence.
* **Used for**
    - GUI buttons and menu items
    - Multi-level undo 
    - Parallel Processing 
    - Networking  
    - Macro recording 

### C# Example
~~~c#
using System;
 
namespace Command.Behavioral
{
  class MainApp
  {
    static void Main()
    {
      // Create receiver, command, and invoker
      Receiver receiver = new Receiver();
      Command command = new ConcreteCommand(receiver);
      Invoker invoker = new Invoker();
 
      // Set and execute command
      invoker.SetCommand(command);
      invoker.ExecuteCommand();
 
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Command' abstract class
  /// </summary>
  abstract class Command
  {
    protected Receiver receiver;
 
    // Constructor
    public Command(Receiver receiver)
    {
      this.receiver = receiver;
    }
 
    public abstract void Execute();
  }
 
  /// <summary>
  /// The 'ConcreteCommand' class
  /// </summary>
  class ConcreteCommand : Command
  {
    // Constructor
    public ConcreteCommand(Receiver receiver) :
      base(receiver)
    {
    }
 
    public override void Execute()
    {
      receiver.Action();
    }
  }
 
  /// <summary>
  /// The 'Receiver' class
  /// </summary>
  class Receiver
  {
    public void Action()
    {
      Console.WriteLine("Called Receiver.Action()");
    }
  }
 
  /// <summary>
  /// The 'Invoker' class
  /// </summary>
  class Invoker
  {
    private Command _command;
 
    public void SetCommand(Command command)
    {
      this._command = command;
    }
 
    public void ExecuteCommand()
    {
      _command.Execute();
    }
  }
}
~~~

### UML Diagram
![Command Pattern](http://www.dofactory.com/images/diagrams/net/command.gif "Command Design Pattern UML Diagram")


## Observer

### Short Description
* **Summary**
    - The observer is a design pattern in which an object, called the subject, maintains a list of its dependents, called observers, and notifies them automatically of any state changes, usually by calling one of their methods. It is mainly used to implement distributed event handling systems. The Observer pattern is also a key part in the familiar model–view–controller (MVC) architectural pattern.The observer pattern is implemented in numerous programming libraries and systems, including almost all GUI toolkits.
* **Description**
    - Define an object that is the "keeper" of the data model and/or business logic (the Subject). Delegate all "view" functionality to decoupled and distinct Observer objects. Observers register themselves with the Subject as they are created. Whenever the Subject changes, it broadcasts to all registered Observers that it has changed, and each Observer queries the Subject for that subset of the Subject's state that it is responsible for monitoring.
* **Problems**
    - The observer pattern can cause memory leaks, known as the lapsed listener problem, because in basic implementation it requires both explicit registration and explicit deregistration, as in the dispose pattern, because the subject holds strong references to the observers, keeping them alive. This can be prevented by the subject holding weak references to the observers.

### C# Example
~~~c#
using System;
using System.Collections.Generic;
 
namespace Observer.Behavioral
{
  class MainApp
  {
    static void Main()
    {
      // Configure Observer pattern
      ConcreteSubject s = new ConcreteSubject();
 
      s.Attach(new ConcreteObserver(s, "X"));
      s.Attach(new ConcreteObserver(s, "Y"));
      s.Attach(new ConcreteObserver(s, "Z"));
 
      // Change subject and notify observers
      s.SubjectState = "ABC";
      s.Notify();
 
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Subject' abstract class
  /// </summary>
  abstract class Subject
  {
    private List<Observer> _observers = new List<Observer>();
 
    public void Attach(Observer observer)
    {
      _observers.Add(observer);
    }
 
    public void Detach(Observer observer)
    {
      _observers.Remove(observer);
    }
 
    public void Notify()
    {
      foreach (Observer o in _observers)
      {
        o.Update();
      }
    }
  }
 
  /// <summary>
  /// The 'ConcreteSubject' class
  /// </summary>
  class ConcreteSubject : Subject
  {
    private string _subjectState;
 
    // Gets or sets subject state
    public string SubjectState
    {
      get { return _subjectState; }
      set { _subjectState = value; }
    }
  }
 
  /// <summary>
  /// The 'Observer' abstract class
  /// </summary>
  abstract class Observer
  {
    public abstract void Update();
  }
 
  /// <summary>
  /// The 'ConcreteObserver' class
  /// </summary>
  class ConcreteObserver : Observer
  {
    private string _name;
    private string _observerState;
    private ConcreteSubject _subject;
 
    // Constructor
    public ConcreteObserver(
      ConcreteSubject subject, string name)
    {
      this._subject = subject;
      this._name = name;
    }
 
    public override void Update()
    {
      _observerState = _subject.SubjectState;
      Console.WriteLine("Observer {0}'s new state is {1}",
        _name, _observerState);
    }
 
    // Gets or sets subject
    public ConcreteSubject Subject
    {
      get { return _subject; }
      set { _subject = value; }
    }
  }
}
~~~

### UML Diagram
![Observer Pattern](http://www.dofactory.com/images/diagrams/net/observer.gif "Observer Design Pattern UML Diagram")


## Specification

### Short Description
* **Summary**
    - The specification pattern is a particular software design pattern, whereby business rules can be recombined by chaining the business rules together using boolean logic.
* **Description**
    - A specification pattern outlines a business rule that is combinable with other business rules. In this pattern, a unit of business logic inherits its functionality from the abstract aggregate Composite Specification class. The Composite Specification class has one function called IsSatisfiedBy that returns a boolean value. After instantiation, the specification is "chained" with other specifications, making new specifications easily maintainable, yet highly customizable business logic. Furthermore upon instantiation the business logic may, through method invocation or inversion of control, have its state altered in order to become a delegate of other classes such as a persistence repository.
    
### C# Example
~~~c#
namespace Specification.Behavioral
{
  public interface ISpecification
  {
    bool IsSatisfiedBy(object candidate);
    ISpecification And(ISpecification other);
    ISpecification Or(ISpecification other);
    ISpecification Not();
  }

  public abstract class CompositeSpecification : ISpecification 
  {
    public abstract bool IsSatisfiedBy(object candidate);

    public ISpecification And(ISpecification other) 
    {
        return new AndSpecification(this, other);
    }

    public ISpecification Or(ISpecification other) 
    {
        return new OrSpecification(this, other);
    }

    public ISpecification Not() 
    {
       return new NotSpecification(this);
    }
  }

  public class AndSpecification : CompositeSpecification 
  {
    private ISpecification One;
    private ISpecification Other;

    public AndSpecification(ISpecification x, ISpecification y) 
    {
        One = x;
        Other = y;
    }

    public override bool IsSatisfiedBy(object candidate) 
    {
        return One.IsSatisfiedBy(candidate) && Other.IsSatisfiedBy(candidate);
    }
  }

  public class OrSpecification : CompositeSpecification
  {
    private ISpecification One;
    private ISpecification Other;

    public OrSpecification(ISpecification x, ISpecification y) 
    {
        One = x;
        Other = y;
    }

    public override bool IsSatisfiedBy(object candidate) 
    {
        return One.IsSatisfiedBy(candidate) || Other.IsSatisfiedBy(candidate);
    }
  }

  public class NotSpecification : CompositeSpecification 
  {
    private ISpecification Wrapped;

    public NotSpecification(ISpecification x) 
    {
        Wrapped = x;
    }

    public override bool IsSatisfiedBy(object candidate) 
    {
        return !Wrapped.IsSatisfiedBy(candidate);
    }
  }
}
~~~

### UML Diagram
![Specification Pattern](https://morshedanwar.files.wordpress.com/2012/11/specification_uml_v2_thumb1.png?w=596&h=357 "Specification Design Pattern UML Diagram")