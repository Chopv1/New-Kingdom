using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<GameObject> m_AllEnemies;

    public List<GameObject> AllEnemies { get => m_AllEnemies; }


    private void Awake()
    {
        m_AllEnemies= new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void RemoveEnemy(GameObject a_enemy)
    {
        AllEnemies.Remove(a_enemy);
    }
    
    public void AddEnemy(GameObject a_enemy)
    {
        AllEnemies.Add(a_enemy);
    }
}
