using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private float hp;
    private float maxHp = 100f;
    private float attack = 20f;
    private float range = 1f;
    private float expGiven;
    private int coinGiven;
    private int level;
    private Vector3 positionTarget = new Vector3(0,0,0);
    private EnemyManager m_EnemyManager;

    private void Awake()
    {
        hp = maxHp;
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.Player.transform.position = positionTarget;
        m_EnemyManager = GetComponentInParent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(PlayerManager.Player.transform);
        if (PlayerManager.Player.transform.position != positionTarget)
        {
            PlayerManager.Player.transform.position = positionTarget;
            transform.TransformDirection(positionTarget);
        }
    }
    public void Damage(float a_damageTaken)
    {
        hp -= a_damageTaken;
        Debug.Log("Damage taken");
        if(hp<=0f)
        {
            hp = 0f;
            m_EnemyManager.RemoveEnemy(gameObject);
            Destroy(gameObject);
        }
    }
}
