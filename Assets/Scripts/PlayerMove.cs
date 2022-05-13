using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private GameObject _cameraCenter;
    [SerializeField] private float _torqueValue;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = 500f;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddTorque(_cameraCenter.transform.right * (Input.GetAxis("Vertical") * _torqueValue));
        _rigidbody.AddTorque(-_cameraCenter.transform.forward * (Input.GetAxis("Horizontal") * _torqueValue));
    }
}
