using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField]private float force=100;

    /// <summary>
    /// Get Rocket from pool, shoot it
    /// </summary>
    public void Shoot()
    {
        var Rocket = RocketPool.Instance.GetRocket();
        Rocket.transform.position = transform.position;
        Rocket.SetActive(true);
        var rocketRB = Rocket.GetComponent<Rigidbody>();
        rocketRB.velocity= new Vector3();
        rocketRB.AddForce(transform.right*force);
    }
}

