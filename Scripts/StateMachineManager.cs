using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script acts as the "context" in the FSM model
// The context passes data to states, so it should inherit from MonoBehavior

public class StateMachineManager : MonoBehaviour
{
    // Lerp Settings
    [Header("Lerp Settings")]
    public float readyLerpDuration;
    public float cautionLerpDuration;

    // Color Settings
    [Header("Color Settings")]
    public Color readyColor;
    public Color cautionColor;
    public Color finishedColor;

    // Reference to Renderer of the object this script lives on
    [HideInInspector] public Renderer cubeRenderer;

    // Create a container for the current / active state
    AbstractState currentState;

    // Instantiate each of the four concrete states
    public State_Ready readyState = new State_Ready();
    public State_Caution cautionState = new State_Caution();
    public State_Finished finishedState = new State_Finished();

    void Start()
    {   
        // set the initial state to the "ready" state
        currentState = readyState;

        // Trigger the "enter state" method
        // "this" refers to the current script: the StateMachineManager
        // As seen in the abstract class, the context (or StateMachineManager) is needed as an arg to pass data in b/w states
        currentState.EnterState(this);

        // Fetch the Renderer component of this game object, so that the cube can change colors
        cubeRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        // runs whatever update conditions are set to the specified state
        currentState.UpdateState(this);
    }

    // Command that lets us decide what triggers a switch state
    // Should pass in a reference to the Abstract class
    public void SwitchState(AbstractState state)
    {
        // set the current state to the passed in state
        currentState = state;

        // have new state run its Enter State method
        state.EnterState(this);
    }

    // TL;DR : The below code is for demonstrative purposes only
    // I've placed the state transitions in the context / "manager" script
    // So that you can push buttons -> trigger the event
    // (OnGUI inherits from MonoBehavior, so it must live here. Otherwise the GUI buttons won't draw in the subclasses.)
    // In reality, these state transitions would be handled within each separate state itself based on conditions it checks internally
    // You could also have the abstract class inherit from MonoBehaviour
    void OnGUI()
    {
        if (GUI.Button (new Rect(0, 0, 75, 25), "Ready") )
        {
            SwitchState(readyState);
        }

        if (GUI.Button (new Rect(0, 40, 75, 25), "Caution") )
        {
            SwitchState(cautionState);
        }

        if (GUI.Button (new Rect(0, 80, 75, 25), "Finished") )
        {
            SwitchState(finishedState);
        }
    }
}
