using UnityEngine;

// The "Ready" state will cause the cube to flash green at a slow pace

public class State_Ready : AbstractState
{
    // Instance variable
    float lerpValue;

    public override void EnterState(StateMachineManager machine)
    {
        Debug.Log("Ready state initiated");
    }

    public override void UpdateState(StateMachineManager machine)
    {
        // establish the lerp value as increasing over time
        lerpValue += Time.deltaTime / machine.readyLerpDuration;
        
        // Have the cube flash green at a slow pace ( use Color.Lerp() )
        if (lerpValue < 1)
        {
            machine.cubeRenderer.material.color = Color.Lerp(Color.black, machine.readyColor, lerpValue);
        }

        if (lerpValue > 1)
        {
            // set color back to black
            machine.cubeRenderer.material.color = Color.black;
            // reset lerp value
            lerpValue = 0;
        }    
    }

    // functionality I ultimately did not use
    public override void OnCollisionEnter(StateMachineManager machine) {}
}
