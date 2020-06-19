//#define DEBUG_attack1Raycast
//#define DEBUG_stateChange

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class CharacterControl : MonoBehaviour
{
    private static CharacterControl _i;
    public static CharacterControl i { get { return _i; } }

    private void Awake()
    {
        if (_i == null)
            _i = this;
    }

    public Rigidbody2D rig { get; private set; }
    Animator anim;
    [SerializeField]
    [Range(5f, 20f)]
    float movementSpeed = 10;
    [SerializeField]
    [Range(1f,4f)]
    float rollingSpeed = 2f;

    /// <summary>
    /// <para>Current state contains StateActivation, Update, OnColllisionEnter2D and Animation functions for each state.</para>
    /// <para>StateChange function changes the current state with next one.</para>
    /// </summary>
    public State currentState { get; private set; }
    
    //This states contains specific situations.
    public readonly State idleState = new IdleState();
    public readonly State runState = new RunState();
    public readonly State rollState = new RollState();
    public readonly State jumpState = new JumpState();
    public readonly State jumpAttackState = new JumpAttackState();
    public readonly State attack1State = new Attack1State();

    private AnimationClip rollingAnim;
    public AnimationClip RollingAnim { get { return rollingAnim; } }
    private AnimationClip attack1Anim;
    public AnimationClip Attack1Anim { get { return attack1Anim; } }

    public UnityEvent attack1 { get; private set; }

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        currentState = idleState;
        currentState.StateActivated();

        rollingAnim = (AnimationClip)AssetDatabase.LoadAssetAtPath("Assets/Animations/Player/roll.anim", typeof(AnimationClip));
        attack1Anim = (AnimationClip)AssetDatabase.LoadAssetAtPath("Assets/Animations/Player/attack1.anim", typeof(AnimationClip));

        if(attack1 == null)
        {
            attack1 = new UnityEvent();
        }
        attack1.AddListener(DamageWithAttack1);
    }

    /// <summary>
    /// <para>Update function executes current state's update function.</para>
    /// <para>So, no need to package em all in same script.</para>
    /// <para>Scripts for each state already exists.</para>
    /// <para>Same for OnCollisionEnter2D</para>
    /// </summary>
    void Update()
    {
        currentState.Update();
#if DEBUG_attack1Raycast
        CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
        Vector2 position;
        if (transform.eulerAngles.y == 180)
            position = new Vector2(transform.position.x + (-collider.bounds.size.x / 2), transform.position.y);
        else
            position = new Vector2(transform.position.x + collider.bounds.size.x / 2, transform.position.y);
        Debug.DrawLine(transform.position, position);
#endif
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(collision);
    }

    ///<summary>
    ///<para>Changes current state.</para>
    ///<param name="state">State: Enter whatever state you want it to work.</param>
    ///</summary>
    public void StateChange(State state)
    {
        string oldAnimation = currentState.Animation();
        currentState = state;
        currentState.StateActivated();
        ChangeAnimation(currentState.Animation(), oldAnimation);
#if DEBUG_stateChange
        Debug.Log("Old State: " + oldAnimation + "\n"
                + "Current State: " + currentState.Animation());
#endif
    }

    private void ChangeAnimation(string newAnimation, string oldAnimation)
    {
        anim.SetBool(oldAnimation, false);
        anim.SetBool(newAnimation, true);
    }

    /// <summary>
    ///  <para>When the character attacks, attack1 must be invoke.</para>
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

    public float MovementSpeed() { return movementSpeed; }
    public float RollingSpeed() { return rollingSpeed; }
    public Rigidbody2D Rigidbody() { return rig; }
}
