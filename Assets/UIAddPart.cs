using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAddPart : MonoBehaviour
{
    private GameObject player;
    private GameObject MManager;
    private GameObject m_Gate;
    public Vector3 SpawnMapPoint;

    public GameObject Gate { get => m_Gate; set => m_Gate = value; }

    private void Start()
    {
        MManager = MapManager.Instance;
        player = PlayerManager.Player;
    }

    public void AddPart(GameObject a_part)
    {
        if(MManager.GetComponent<MapManager>().CreateNewPart(a_part, SpawnMapPoint))
        {
            Destroy(m_Gate);
        }
        Annuler();
    }
    public void Annuler()
    {
        gameObject.SetActive(false);
        player.GetComponent<PlayerMouvement>().enabled = true;
    }
}
