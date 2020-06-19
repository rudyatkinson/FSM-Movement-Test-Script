#define DEBUG_stateChanging

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class State : MonoBehaviour
{
    /// <summary>
    /// <para>This will be executed after state change.</para>
    /// </summary>
    public virtual void StateActivated()
    {
#if DEBUG_stateChanging
        Debug.Log("State değişti.");
#endif
    }

    public virtual void Update()
    {
        
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public virtual string Animation()
    {
        return "";
    }
}
