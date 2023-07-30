using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �ڒn����������PlayerMove�R���|�[�l���g�Ɍ��ʂ�n���N���X
/// </summary>
public class CheckGround : MonoBehaviour
{
    PlayerMove _playerMove;
    void Start()
    {
        _playerMove = transform.parent.GetComponent<PlayerMove>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _playerMove._isGrounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _playerMove._isGrounded = false;
    }
}
