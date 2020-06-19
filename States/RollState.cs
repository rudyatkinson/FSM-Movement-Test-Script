using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState : State
{
    public override void StateActivated()
    {
        base.StateActivated();
        CharacterCoroutine.i.StartRoutine("roll");
        CharacterControl.i.rig.gravityScale = 5;
    }

    public override void Update()
    {
        if(CharacterControl.i.transform.eulerAngles.y == 180)
        {
            CharacterControl.i.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * (CharacterControl.i.MovementSpeed() * CharacterControl.i.RollingSpeed());
        }
        else
        {
            CharacterControl.i.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * (CharacterControl.i.MovementSpeed() * CharacterControl.i.RollingSpeed());
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public override string Animation()
    {
        return "roll";
    }
}
