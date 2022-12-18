using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAddPart : MonoBehaviour
{
    private GameObject player;
    private GameObject m_Gate;
    public Vector3 SpawnMapPoint;

    [SerializeField] private MapManager MManager;
    public GameObject Gate { get => m_Gate; set => m_Gate = value; }

    private void Start()
    {
        player = PlayerManager.Player;
    }

    public void AddPart(GameObject a_part)
    {
        Map map = Gate.GetComponentInParent<Map>();
        map.RemoveGate(Gate);
        Map.Cardinal gateCard = Gate.GetComponent<Gate>().GetCardinal();
        if(gateCard == Map.Cardinal.EAST)
        {
            map.EastPart = MManager.CreateNewPart(a_part, SpawnMapPoint);
            map.EastPart.GetComponent<Map>().WestPart = map.gameObject;
        }
        else if(gateCard == Map.Cardinal.WEST)
        {
            map.WestPart = MManager.CreateNewPart(a_part, SpawnMapPoint);
            map.WestPart.GetComponent<Map>().EastPart = map.gameObject;
        }
        else if (gateCard == Map.Cardinal.NORTH)
        {
            map.NorthPart = MManager.CreateNewPart(a_part, SpawnMapPoint);
            map.NorthPart.GetComponent<Map>().SouthPart = map.gameObject;

        }
        else if (gateCard == Map.Cardinal.SOUTH)
        { 
            map.SouthPart = MManager.CreateNewPart(a_part, SpawnMapPoint);
            map.SouthPart.GetComponent<Map>().NorthPart = map.gameObject;
        }


        if(map.GetMapCardinal()!= Map.Cardinal.CENTER && map.GetGatesCount()==0)
           map.SetMapCardinal(Map.Cardinal.NONE);

        Annuler();
    }
    public void Annuler()
    {
        gameObject.SetActive(false);
        player.GetComponent<PlayerMouvement>().enabled = true;
    }
}
