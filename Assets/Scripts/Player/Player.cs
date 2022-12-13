using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject attackArea;
    private SphereCollider attackAreaCollider;
    private bool attacking = false;
    private float timer = 0f;
    private float attackCouldown = 0.25f;
    private float hp;
    private float maxHp = 100f;
    private float range = 1f;
    private float totalExp;
    private int level;
    private float attackDamage = 20f;

    public float AttackDamage { get => attackDamage; set => attackDamage = value; }

    // Start is called before the first frame update
    void Start()
    {
        attackArea.SetActive(false);
        attackAreaCollider = attackArea.GetComponent<SphereCollider>();
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if(attacking)
        {
            timer += Time.deltaTime;
            if(timer>attackCouldown)
            {
                attacking = false;
                attackArea.SetActive(attacking);
                timer = 0f;
            }
        }
    }

    private void Attack()
    {
        attacking= true;
        attackArea.SetActive(attacking);
    }

    public void Damage(float a_attaque)
    {
        Debug.Log("Attacked player");
        hp -= a_attaque;
        if(hp<=0f)
        {
            Debug.Log("GameOver");
        }
    }
}
