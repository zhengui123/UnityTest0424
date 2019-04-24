using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyType
{
    Enemy0,
    Enemy1
}
public class AITest : MonoBehaviour
{
    public EnemyType enemyType = EnemyType.Enemy0;
    public GameObject player;

    private int ENEMY_NORMAL = 0; //敌人正常
    private int ENEMY_RUN = 1; // 敌人跑 
    private int ENEMY_HIT = 2; //敌人攻击

    private int state;//敌人自身状态；
    void Start()
    {
        state = ENEMY_NORMAL;
        if (player == null)
            player = GameObject.Find("Player");
    }

    void Update ()
	{
	    switch (enemyType)
	    {
            case EnemyType.Enemy0:
                Enemy0();
                break;
            case EnemyType.Enemy1:
                Enemy1();
                break;
	    }
	}

    public void Enemy0()
    {
        transform.LookAt(player.transform);
    }

    public void Enemy1()
    {
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * 0.05f);
    }

}
