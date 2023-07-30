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
    [SerializeField] float _attackInterval = 1;
    float _attackTimer = 0;
    Rigidbody _rb;
    GameObject _attackRange;
    Queue<GameObject> _attackList = new Queue<GameObject>();
    void Start()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();
        _attackRange = transform.GetChild(1).gameObject;
        _attackRange.SetActive(false);
        _rb = GetComponent<Rigidbody>();
        _attackTimer = _attackInterval + 1;
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        //キャラクターの回転
        if (_horizontal != 0)
        {
            var rotation = transform.localEulerAngles;
            rotation.y += _horizontal * _rotateSpeed;
            transform.localEulerAngles = rotation;
        }
        //キャラクターの前後移動
        if ( _vertical != 0)
        {
            var local = transform.forward * _vertical * _moveSpeed;
            _rb.velocity = new Vector3(local.x, _rb.velocity.y, local.z);
        }
        //キャラクターのジャンプ
        if(Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(new Vector3(0,_jumpPower,0),ForceMode.Impulse);
        }
        //攻撃
        if (Input.GetButtonDown("Fire1") && _attackTimer > _attackInterval)
        {
            StartCoroutine(Attack(1));
            _attackTimer = 0;
        }
        _attackTimer += Time.deltaTime;
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    _attackList.Enqueue(other.gameObject);
    //}
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
    /// <summary>
    /// 攻撃処理。一定時間トリガーを出現させる
    /// </summary>
    /// <param name="time">出現させ続ける時間</param>
    /// <returns></returns>
    IEnumerator Attack(float time)
    {
        float timer = 0;
        _attackRange.SetActive(true);
        for (int i = 0; i < _attackList.Count; ++i)
        {
            if (_attackList.TryDequeue(out GameObject result))
            {
                if(result.CompareTag("Enemy"))
                {
                    Destroy(result.gameObject);
                }
            }
        }
        while (timer < time)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        _attackRange.SetActive(false);
        yield break;
    }
}
