using UnityEngine;

public class EnemyGeneratorTrigger : MonoBehaviour
{
    //�G�̃v���p�u
    [SerializeField] GameObject _enemyPrefab;
    //�G�������Ԃ̐ݒ�
    [SerializeField, Range(0, 10)] float interval = 5.0f;
    //�^�C�}�[
    float _timer;
    //
    private void Start()
    {
        _timer = interval;
    }
    void FixedUpdate()
    {
        _timer += Time.deltaTime;
        if (_timer >= interval)
        {
            GameObject enemy = GameObject.Instantiate(_enemyPrefab, transform.position, transform.rotation);
            _timer = 0;
        }
    }


}
