using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void StateActivated()
    {
        base.StateActivated();
        CharacterControl.i.rig.gravityScale = 2;
    }

    public override void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            CharacterControl.i.StateChange(CharacterControl.i.runState);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            CharacterControl.i.StateChange(CharacterControl.i.rollState);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CharacterControl.i.StateChange(CharacterControl.i.jumpState);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            CharacterControl.i.StateChange(CharacterControl.i.attack1State);
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public override string Animation()
    {
        return "idle";
    }
}
