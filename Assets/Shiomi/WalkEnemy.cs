using UnityEngine;

public class WalkEnemy : MonoBehaviour
{
    //追跡するプレイヤーを追加
    [SerializeField] GameObject _player;
    //追跡するスピード
    [SerializeField,Range(0,100)] float _enemySpeed = 1;
    private void FixedUpdate()
    {
        //方向を決める
        Vector3 dir = (_player.transform.position - this.transform.position).normalized;
        //移動方向とスピードを決定する
        transform.position += dir * _enemySpeed * Time.deltaTime;
        //正面を向く
        if(dir.magnitude > 0)
        {
            dir.y = 0;
            transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}
