using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    private List<GameObject> m_AllEnemies;
    [SerializeField] private GameObject[] enemyPrefabs;
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

    public void SpawnEnemies(int enemy) 
    {
        GameObject newEnemy = (GameObject)Instantiate(enemyPrefabs[0], new Vector3(4.5f, .1f, 2.5f), Quaternion.identity);
        AddEnemy(newEnemy);
        newEnemy.transform.parent = this.transform;
        /*for(int i=0; i<=enemy; i++)
        {
        }*/
    }
}
