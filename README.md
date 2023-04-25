# Basic-Unity-Finite-State-Machine

A very basic example of a Finite State Machine in Unity

Uses the simplest implementation of an FSM using OOP:

 - An abstract class with 2 basic abstract methods that simulate Start() and Update() (from MonoBehaviour). Has a container for OnTriggerEnter(), another useful MonoBehaviour method

 - 3 Example concrete states: Ready, Caution, and Finished. Ready and Caution take in a lerp number that specifies how fast the color should flash - this creates a clear visual distinction between states.

NOTE: OnGUI() is a MonoBehaviour method, so for demonstrative purposes, lives in the FSM Manager script. The abstract class could inherit from Monobehaviour instead, which would allow OnGUI() to be drawn from other scripts (they would need to be instantiated somewhere as a caveat). 

Additionaly, functionality not relying on OnGUI() could be used to demonstrate a state change, but I like the simplicity of OnGUI() and prefer it.
