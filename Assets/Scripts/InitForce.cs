using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitForce : MonoBehaviour
{
    [SerializeField] private Vector3 InitiateForce;
    [SerializeField] private Vector3 InitiateRotation;
    [SerializeField] private bool applyRotation = false;
    [SerializeField] private bool applyForce = true;
    [SerializeField] private float rotationAngle = 30;
    void Start()
    {
        if(applyForce)
        GetComponent<Rigidbody>().AddForce(InitiateForce);
        if (!applyRotation) this.enabled = false;
    }

    /// <summary>
    /// For now applyRotation is of everywhere because of Canvas todo: Rework gameobject hierarchy 
    /// </summary>
    void Update()
    {
        // Spin the object around the world origin at 20 degrees/second.
        transform.RotateAround(transform.position, InitiateRotation, rotationAngle * Time.deltaTime);
    }

}
