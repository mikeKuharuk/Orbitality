using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private const float Acceleration = 10;
    private HashSet<Rigidbody> affectedBodies = new HashSet<Rigidbody>();
    private Rigidbody componentRigidbody;

    private void Start()
    {
        componentRigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Add to the list rigidbodies on which this planets affect with gravity when it in radius
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            affectedBodies.Add(other.attachedRigidbody);
        }
    }

    /// <summary>
    /// Remove from the list rigidbodies on which this planets affect with grabity when it leaves radius
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            affectedBodies.Remove(other.attachedRigidbody);
        }
    }

    /// <summary>
    /// Attract planets with gravity
    /// </summary>
    private void FixedUpdate()
    {
        foreach (Rigidbody body in affectedBodies)
        {
            Vector3 forceDirection = (transform.position - body.position).normalized;
            float distance = (transform.position - body.position).magnitude;
            float strength = Acceleration * body.mass * componentRigidbody.mass / (distance * distance);

            body.AddForce(forceDirection * strength);
        }
    }
}