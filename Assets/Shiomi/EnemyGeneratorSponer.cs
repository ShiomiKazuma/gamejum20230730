using UnityEngine;

public class EnemyGeneratorTrigger : MonoBehaviour
{
    //敵のプレパブ
    [SerializeField] GameObject _enemyPrefab;
    //敵生成時間の設定
    [SerializeField, Range(0, 10)] float interval = 5.0f;
    //タイマー
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
