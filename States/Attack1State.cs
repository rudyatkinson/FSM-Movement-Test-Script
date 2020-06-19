using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1State : State
{
    private bool animationDeactivated = true;
    private string lastAnimation;

    public override void StateActivated()
    {
        base.StateActivated();
        CharacterCoroutine.i.StartRoutine("attack1");
    }

    public override void Update()
    {
        
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public override string Animation()
    {
        if (animationDeactivated)
        {
            lastAnimation = "attack" + Random.Range(1, 3).ToString();
            animationDeactivated = false;
            return lastAnimation;

        }
        else
        {
            animationDeactivated = true;
            return lastAnimation;
        }
         
    }
}
