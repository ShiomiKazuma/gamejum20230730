using UnityEngine;

public class WalkEnemy : MonoBehaviour
{
    //�ǐՂ���v���C���[��ǉ�
    GameObject _player;
    //�ǐՂ���X�s�[�h
    [SerializeField,Range(0,100)] float _enemySpeed = 1;
    [SerializeField] float _deathTimer = 10.0f;
    float _timer;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
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

        if(_deathTimer > _timer)
        {
            Destroy(gameObject);
        }
    }
}
