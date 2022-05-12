using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _targetToFollow;
    
    
    void Update()
    {
        transform.position = _targetToFollow.position;
    }
    
    
}
