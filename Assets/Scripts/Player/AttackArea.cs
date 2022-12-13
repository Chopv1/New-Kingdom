using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private float playerAttack;
    private float enemieAttack;

    public float PlayerAttack { get => playerAttack; set => playerAttack = value; }
    public float EnemieAttack { get => enemieAttack; set => enemieAttack = value; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Enemy>() && GetComponentInParent<Player>())
        {
            PlayerAttack = GetComponentInParent<Player>().AttackDamage;
            other.GetComponent<Enemy>().Damage(PlayerAttack);
        }
        if (other.GetComponent<Player>())
        {
            EnemieAttack = GetComponentInParent<Enemy>().AttackDamage;
            other.GetComponent<Player>().Damage(EnemieAttack);
        }
    }
}
