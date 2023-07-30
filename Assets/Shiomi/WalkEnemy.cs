using UnityEngine;

public class WalkEnemy : MonoBehaviour
{
    //�ǐՂ���v���C���[��ǉ�
    [SerializeField] GameObject _player;
    //�ǐՂ���X�s�[�h
    [SerializeField,Range(0,100)] float _enemySpeed = 1;
    private void FixedUpdate()
    {
        //���������߂�
        Vector3 dir = (_player.transform.position - this.transform.position).normalized;
        //�ړ������ƃX�s�[�h�����肷��
        transform.position += dir * _enemySpeed * Time.deltaTime;
        //���ʂ�����
        if(dir.magnitude > 0)
        {
            dir.y = 0;
            transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}
