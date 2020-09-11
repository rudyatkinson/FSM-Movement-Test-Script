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
    
    /// <summary>
    ///  <para>When the character attack, attack1 must be invoke.</para>
    ///  <para>Each attack type of character use same.</para>
    /// </summary>
    private void DamageWithAttack1()
    {
#if DEBUG_attack1Raycast
        Debug.Log("DamageWithAttack1 working.");
#endif
        CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
        Vector2 position;
        Vector2 direction;
        if (transform.eulerAngles.y == 180)
        {
            position = new Vector2(transform.position.x + (-collider.bounds.size.x / 2), transform.position.y + collider.bounds.size.y / 2);
            direction = Vector2.left;
        }
            
        else
        {
            position = new Vector2(transform.position.x + collider.bounds.size.x / 2, transform.position.y + collider.bounds.size.y / 2);
            direction = Vector2.right;
        }
        RaycastHit2D hit = Physics2D.Raycast(position, direction, 1f);
        if(hit && hit.collider.gameObject.tag == "Enemy")
        {
#if DEBUG_attack1Raycast
            Debug.Log("Enemy damaged.");
#endif
        }
    }
}
