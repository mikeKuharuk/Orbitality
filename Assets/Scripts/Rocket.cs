using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class Rocket : MonoBehaviour,IRocket
{
    private int damage = 10;
    public int GetDamageCount() => damage;
    
    void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
    
    /// <summary>
    /// Set off rocket when it flies away from playground
    /// </summary>
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
