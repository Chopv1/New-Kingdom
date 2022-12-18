using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static GameObject Instance;

    [SerializeField]
    public List<GameObject> AllMaps = new List<GameObject>();
    public List<GameObject> PlacedMap;
    public GameObject initialMap;
    public bool initialMapHasBeenInitaled = false;
    public PlayerManager playerManager;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this.gameObject;
        if (CreateNewPart(initialMap, Vector3.zero))
        {
            initialMapHasBeenInitaled=true;
            playerManager.InitilisePlayer();
        }
            
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CreateNewPart(GameObject a_newPart, Vector3 a_position)
    {
        GameObject newOne = Instantiate(a_newPart, a_position, Quaternion.identity);
        if(newOne)
        {
            newOne.transform.parent = gameObject.transform;
            PlacedMap.Add(a_newPart);
            return newOne;
        }

        return null;
    }
}
