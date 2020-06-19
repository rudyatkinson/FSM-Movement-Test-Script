using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    public override void StateActivated()
    {
        base.StateActivated();
    }

    public override void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal > 0 || moveHorizontal < 0)
        {
            Vector2 movement = new Vector2(moveHorizontal, 0);
            CharacterControl.i.transform.position += new Vector3(movement.x, movement.y, 0) * Time.deltaTime * CharacterControl.i.MovementSpeed();

            if (moveHorizontal < 0)
            {
                CharacterControl.i.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (moveHorizontal > 0)
            {
                CharacterControl.i.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CharacterControl.i.StateChange(CharacterControl.i.rollState);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CharacterControl.i.StateChange(CharacterControl.i.jumpState);
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                CharacterControl.i.StateChange(CharacterControl.i.attack1State);
            }
        }
        else
        {
            CharacterControl.i.StateChange(CharacterControl.i.idleState);
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public override string Animation()
    {
        return "run";
    }
}
