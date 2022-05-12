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
    }

    private void FixedUpdate()
    {
        _rigidbody.AddTorque(Input.GetAxis("Vertical") * _cameraCenter.transform.right * _torqueValue);
        _rigidbody.AddTorque(Input.GetAxis("Horizontal") * -_cameraCenter.transform.forward * _torqueValue);
    }

    private void SetDirection()
    {
    }
}
