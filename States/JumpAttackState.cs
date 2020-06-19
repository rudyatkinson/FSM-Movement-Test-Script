using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttackState : State
{
    public override void StateActivated()
    {
        base.StateActivated();
        CharacterControl.i.rig.gravityScale = 5;
    }

    public override void Update()
    {

    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            CharacterControl.i.attack1.Invoke();
            CharacterControl.i.StateChange(CharacterControl.i.idleState);
        }
    }

    public override string Animation()
    {
        return "jumpAttack2";
    }
}
