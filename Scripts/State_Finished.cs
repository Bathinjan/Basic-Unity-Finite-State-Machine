using UnityEngine;

// The "finished" state will cause the cube to turn red; it will not flash

public class State_Finished : AbstractState
{
    public override void EnterState(StateMachineManager machine)
    {
        Debug.Log("Finished state initiated");
    }

    public override void UpdateState(StateMachineManager machine)
    {
        // keep the cube at a solid red
        machine.cubeRenderer.material.color = Color.red;
    }

    // functionality I ultimately did not use
    public override void OnCollisionEnter(StateMachineManager machine) {}
}