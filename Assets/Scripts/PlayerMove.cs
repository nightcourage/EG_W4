using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private GameObject _cameraCenter;
    [SerializeField] private float _torqueValue;
    [SerializeField] private Ground _ground;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = 500f;
    }

    private void Update()
    {
        _rigidbody.position = new Vector3(
            Mathf.Clamp(transform.position.x, 0, _ground.GroundX),
            Mathf.Clamp(transform.position.y, 0, 15), 
            Mathf.Clamp(transform.position.z, 0, _ground.GroundZ));
    }

    private void FixedUpdate()
    {

        _rigidbody.AddTorque(_cameraCenter.transform.right * (Input.GetAxis("Vertical") * _torqueValue));
        _rigidbody.AddTorque(-_cameraCenter.transform.forward * (Input.GetAxis("Horizontal") * _torqueValue));
    }
}
