using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator _animator;
    float _horizontal = 0;
    float _vertical = 0;
    [SerializeField] float _rotateSpeed = 1;
    [SerializeField] float _moveSpeed = 1;
    [SerializeField] float _jumpPower = 1;
    Rigidbody _rb;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        if(_horizontal != 0)
        {
            //キャラクターの回転
            var rotation = transform.localEulerAngles;
            rotation.y += _horizontal * _rotateSpeed;
            transform.localEulerAngles = rotation;
        }
        if( _vertical != 0)
        {
            //キャラクターの前後移動
            var local = transform.forward * _vertical * _moveSpeed;
            _rb.velocity = new Vector3(local.x, _rb.velocity.y, local.z);
        }
        if(Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(new Vector3(0,_jumpPower,0),ForceMode.Impulse);
        }
    }
}
