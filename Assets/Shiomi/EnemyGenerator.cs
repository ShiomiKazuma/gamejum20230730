using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //�G�̃v���p�u
    [SerializeField] GameObject _enemyPrefab;
    //�G�������Ԃ̐ݒ�
    [SerializeField, Range(0,10)] float interval = 5.0f;
    //�^�C�}�[
    float _timer;
    [SerializeField] Transform[] _transform;
    private void Start()
    {
        _timer = interval;
    }
    void FixedUpdate() 
    {
        _timer += Time.deltaTime;
        if(_timer >= interval)
        {
            int random = Random.Range(0,_transform.Length);
            GameObject enemy = GameObject.Instantiate(_enemyPrefab, _transform[random].position,transform.rotation);
            _timer = 0;
        }
    }
}
