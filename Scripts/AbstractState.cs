using UnityEngine;

// This class functions as the abstract, "prototype" class or "blueprint" in the FSM model

// This abstract class (and its subclasses) SHOULD NOT derive from the Monobehavior class (at least in this example)
// (for enums you *would* inherit from Mono, but it starts to get really complicated)

// OOP Refrehser:
// This class also has the "abstract" keyword to denote that it is the prototype or "blueprint" class that the others inherit from

public abstract class AbstractState
{
    // Abstract methods made here MUST be defined in EACH subclass (error will be thrown otherwise)
    // They are written with this syntax: public abstract [return type] methodName(args);
    // They don't inclue the (), this tells the compiler not to treat it like a normal method
    
    // (note: abstract methods can't be private for the above reasons: public MUST be added)
    
    public abstract void EnterState(StateMachineManager machine);

    public abstract void UpdateState(StateMachineManager machine);

    // functionality I ultimately did not use
    // theoretically this could be used to trigger an event i.e. the player is nearby, etc
    // included it anyway to show how easy scalability is
    public abstract void OnCollisionEnter(StateMachineManager machine);
}
