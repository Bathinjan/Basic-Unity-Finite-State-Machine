using UnityEngine;

// The "caution" state will cause the cube to flash yellow at a faster pace than at the "ready" state

public class State_Caution : AbstractState
{
    // Instance variable
    float lerpValue; 

    public override void EnterState(StateMachineManager machine)
    {
        Debug.Log("Caution state initiated");
    }

    public override void UpdateState(StateMachineManager machine)
    {
        // establish the lerp value as increasing over time
        lerpValue += Time.deltaTime / machine.cautionLerpDuration;
        
        // Have the cube flash yellow at a faster pace ( use Color.Lerp() )
        if (lerpValue < 1)
        {
            machine.cubeRenderer.material.color = Color.Lerp(Color.black, machine.cautionColor, lerpValue);
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
