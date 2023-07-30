using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator _animator;
    float _horizontal = 0;
    float _vertical = 0;
    [SerializeField] float _rotateSpeed = 1;
    [SerializeField] float _moveSpeed = 1;
    [SerializeField] float _jumpPower = 1;
    [SerializeField] float _attackInterval = 1;
    float _attackTimer = 0;
    Rigidbody _rb;
    GameObject _attackRange;
    public bool _isGrounded { get; set; } = false;
    Vector3 _initialPosition = default;
    void Start()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();
        _attackRange = transform.GetChild(1).gameObject;
        _attackRange.SetActive(false);
        _rb = GetComponent<Rigidbody>();
        _attackTimer = _attackInterval + 1;
        _initialPosition = transform.position;
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        //�L�����N�^�[�̉�]
        if (_horizontal != 0)
        {
            var rotation = transform.localEulerAngles;
            rotation.y += _horizontal * _rotateSpeed;
            transform.localEulerAngles = rotation;
        }
        //�L�����N�^�[�̑O��ړ�
        if ( _vertical != 0)
        {
            var local = transform.forward * _vertical * _moveSpeed;
            _rb.velocity = new Vector3(local.x, _rb.velocity.y, local.z);
        }
        //�L�����N�^�[�̃W�����v
        if(Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb.AddForce(new Vector3(0,_jumpPower,0),ForceMode.Impulse);
        }
        //�U��
        if (Input.GetButtonDown("Fire1") && _attackTimer > _attackInterval)
        {
            StartCoroutine(Attack(1));
            _attackTimer = 0;
        }
        //����������Ə����n�_�ɖ߂�
        if (transform.position.y < -50)
            transform.position = _initialPosition;
        _attackTimer += Time.deltaTime;
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
    //�Q�[���}�l�[�W���[�Ăяo��
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.PlayerDamage();
        }
    }
    private void LateUpdate()
    {
        // �A�j���[�V�����𐧌䂷��
        if (_animator)
        {
            //X������velocity�̐�Βl
            //m_anim.SetFloat("SpeedX", Mathf.Abs(m_rb.velocity.x));
            //Y������velocity
            _animator.SetFloat("SpeedY", _rb.velocity.y);
            _animator.SetBool("IsGrounded", _isGrounded);
        }
    }
    /// <summary>
    /// �U�������B��莞�ԃg���K�[���o��������
    /// </summary>
    /// <param name="time">�o�����������鎞��</param>
    /// <returns></returns>
    IEnumerator Attack(float time)
    {
        float timer = 0;
        _attackRange.SetActive(true);
        while (timer < time)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        _attackRange.SetActive(false);
        yield break;
    }
}
