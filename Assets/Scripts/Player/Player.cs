using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float hp;
    float maxHp = 100f;
    float attack = 20f;
    float range = 1f;
    float totalExp;
    int coin;
    int level;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Attack : " + mousePos);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, mousePos, out hit, range, 6))
        {
            Debug.Log("Hit");
            hit.collider.gameObject.GetComponent<Enemy>().Damage(attack);
        }
    }
}
