using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerMoveSound : MonoBehaviour
{
    [SerializeField] private AudioSource _moveSound;

    public void IncreaseSound()
    {
        _moveSound.Play();
        _moveSound.volume = Mathf.Lerp(_moveSound.volume, 0.8f, Time.deltaTime);
    }

    public void DecreaseSound()
    {
        _moveSound.volume = Mathf.Lerp(_moveSound.volume, 0.01f, Time.deltaTime);
    }
}

// if ( Vector3.SqrMagnitude(_player.velocity - Vector3.zero) > 0.001f)
// {
//     _moveSound.Play();
//     _moveSound.volume = Mathf.Lerp(_moveSound.volume, 0.8f, Time.deltaTime);
//     // _moveSound.pitch = Random.Range(0.6f, 1.2f);
// }
// else
// {
//     _moveSound.volume = Mathf.Lerp(_moveSound.volume, 0, Time.deltaTime);
// }