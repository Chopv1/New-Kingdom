using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float hp;
    float maxHp = 100f;
    float attack = 20f;
    float range = 1f;
    float expGiven;
    int coinGiven;
    int level;

    EnemyManager m_EnemyManager;

    private void Awake()
    {
        hp = maxHp;
        m_EnemyManager = GetComponentInParent<EnemyManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float a_damageTaken)
    {
        hp -= a_damageTaken;
        Debug.Log("Damage taken");
        if(hp<=0f)
        {
            hp = 0f;
            //m_EnemyManager.RemoveEnemy(gameObject);
            Destroy(gameObject);
        }
    }
}
