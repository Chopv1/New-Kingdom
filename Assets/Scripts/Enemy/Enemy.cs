using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Stats
    private float hp;
    private float maxHp = 100f;
    private float attackDamage = 5f;
    private float attackRange = 0.25f;
    private float detectionRange = 25f;
    private float speed = 5f;
    private float expToGive;
    private int coinToGive;
    private int level;
    private float timeBetweenAttack = 0.5f;
    private bool isAttacking = false;
    private float timer = 0f;

    //IA
    private Vector3 positionTarget = new Vector3(0,0,0);
    private GameObject m_Player;
    private GameObject m_Target;
    private bool inRangeOfAttack = false;
    [SerializeField] private GameObject m_AttackArea;

    private EnemyManager m_EnemyManager;

    public float AttackDamage { get => attackDamage; set => attackDamage = value; }

    private void Awake()
    {
        hp = maxHp;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_Target = null;
        m_EnemyManager = GetComponentInParent<EnemyManager>();
        m_Player = PlayerManager.Player;
        m_AttackArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Target == null)
            SetTarget();
        else if (!inRangeOfAttack)
            Move();
        else
            Attack();
    }

    private void Attack()
    {
        if (isAttacking)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenAttack)
            {
                isAttacking = false;
                m_AttackArea.SetActive(isAttacking);
                timer = 0f;
            }
        }
        else
        {
            isAttacking = true;
            m_AttackArea.SetActive(isAttacking);
        }
        if (CheckIfTargettableAndAttackable(Physics.OverlapSphere(transform.position, attackRange), m_Target) == null)
        {
            inRangeOfAttack = false;
            m_AttackArea.SetActive(false);
        }
    }
    
    private void SetTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRange);

        m_Target = CheckIfTargettableAndAttackable(colliders, m_Target);
    }

    private void Move()
    {
        transform.LookAt(m_Target.transform);
        
        if (positionTarget != m_Target.transform.position)
            positionTarget = m_Target.transform.position;
        
        Vector3 direction = (positionTarget-transform.position).normalized * speed * Time.deltaTime;
        gameObject.transform.Translate(direction, Space.World);
        
        if(CheckIfTargettableAndAttackable(Physics.OverlapSphere(transform.position, attackRange), m_Target) != null)
            inRangeOfAttack= true;
    }
    private GameObject CheckIfTargettableAndAttackable(Collider[] a_collider, GameObject a_target)
    {
        GameObject toTarget = null;
        if(a_target==m_Player)
            foreach (Collider collider in a_collider)
                if (collider.gameObject == m_Player)
                {
                    toTarget = collider.gameObject;
                    break;
                }
        if (toTarget != m_Player)
            foreach (Collider collider in a_collider)
                if (collider.gameObject.layer == 8)
                    toTarget = collider.gameObject;
        return toTarget;
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
