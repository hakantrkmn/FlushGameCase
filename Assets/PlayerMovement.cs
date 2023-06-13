using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private FloatingJoystick _joystick;
    private Vector3 _direction;
    public float speed;
    public Animator animator;
    private void Start()
    {
        _joystick = EventManager.GetJoystick();
    }


    private void Update()
    {
        if (_joystick.Direction.magnitude > .1f)
        {
            _direction = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
            transform.position += ( Time.deltaTime*speed*_direction );
            transform.forward = _direction;
        }
      
        animator.SetFloat("Speed",_joystick.Direction.magnitude);
        
        
    }
}
