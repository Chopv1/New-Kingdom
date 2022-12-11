using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private float attack = 20f;

    public float Attack { get => attack; set => attack = value; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().Damage(attack);
        }
    }
}
