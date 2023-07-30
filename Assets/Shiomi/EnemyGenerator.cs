using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //敵のプレパブ
    [SerializeField] GameObject _enemyPrefab;
    //敵生成時間の設定
    [SerializeField, Range(0,10)] float interval = 5.0f;
    //タイマー
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
