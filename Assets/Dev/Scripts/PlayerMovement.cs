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
            transform.forward = Vector3.Lerp(transform.forward, _direction, 20 * Time.deltaTime);
        }
      
        animator.SetFloat("Speed",Mathf.Lerp(animator.GetFloat("Speed"),_joystick.Direction.magnitude,10*Time.deltaTime));
        
        
    }
}
