using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _targetToFollow;
    [SerializeField] private Rigidbody _targetRigidbody;
    [SerializeField] private PlayerMoveSound _moveSound;
    
    [Range(5,20)]
    [SerializeField] private int _smoothingPoints = 10;
    private List<Vector3> _velocitiesList = new List<Vector3>();

    private void Start()
    {
        for (int i = 0; i < _smoothingPoints; i++)
        {
            _velocitiesList.Add(Vector3.zero);
        }
    }

    private void Update()
    {

        if (Mathf.Abs(_velocitiesList[_velocitiesList.Count - 1].magnitude) - Mathf.Abs(_velocitiesList[0].magnitude) > 0.0001f)
        {
            _moveSound.IncreaseSound();
        }

        else if (Mathf.Abs(_velocitiesList[_velocitiesList.Count - 1].magnitude) - Mathf.Abs(_velocitiesList[0].magnitude) < 0.0001f)
        {
            _moveSound.DecreaseSound();
        }
    }

    private void LateUpdate()
    {
        if (Mathf.Abs(Vector3.SqrMagnitude(CountVectorsSum() - Vector3.zero)) > 0.001)
        {
            ChangeTransform(CountVectorsSum());
        }
        else
        {
            ChangeTransform(Vector3.forward);
        }
    }

    private void FixedUpdate()
    {
        AggregatePositions();
    }

    private void ChangeTransform(Vector3 direction)
    {
        transform.position = _targetToFollow.position;
        Quaternion rotation = Quaternion.Lerp(
            transform.rotation, 
            Quaternion.LookRotation(direction), 
            Time.deltaTime * 10f
        );

        transform.rotation = rotation;
    }

    private void AggregatePositions()
    {
        _velocitiesList.Add(_targetRigidbody.velocity);
        _velocitiesList.RemoveAt(0);
    }

    private Vector3 CountVectorsSum()
    {
        Vector3 vector3Sum = Vector3.zero;
        foreach (var vector3 in _velocitiesList)
        {
            vector3Sum += vector3;
        }

        return vector3Sum;
    }
}
