using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private Map.Cardinal gateCardinal;

    private GameObject player;
    private GameObject UIInteraction;
    private GameObject uiAddPartGO;
    private UIAddPart uiAddPart;
    private Map map;
    private bool canShowMenu = false;
    private UiManager uiManager;

    [SerializeField] private LayerMask layer;
    [SerializeField] private GameObject PositionOfTheNextMap;
    [SerializeField] private GameObject m_WallToDestroy;

    public GameObject WallToDestroy { get => m_WallToDestroy;}

    private void Start()
    {
        uiManager = UiManager.Instance;
        UIInteraction = uiManager.Interaction;
        uiAddPartGO = uiManager.MenuToShow;
        uiAddPart = uiManager.MenuToShow.GetComponent<UIAddPart>();
        player = PlayerManager.Player;
        UIInteraction.SetActive(false);
        uiAddPartGO.SetActive(false);
        map = GetComponentInParent<Map>();

    }
    private void Update()
    {
        if (canShowMenu && Input.GetKeyDown(KeyCode.E))
        {
            uiAddPart.SpawnMapPoint = PositionOfTheNextMap.transform.position;
            uiAddPart.Gate = this.gameObject;
            StatePlayerMovement(false);
            uiAddPartGO.SetActive(true);
        }
        CheckIfGateAlreadyHere();
    }

    public void CheckIfGateAlreadyHere()
    {
        Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
        RaycastHit hit;
        foreach (Vector3 direction in directions)
        {
            if (Physics.Raycast(transform.position, direction, out hit, 2, layer))
            {
                hit.collider.gameObject.GetComponentInParent<Map>().RemoveGate(hit.collider.gameObject);
                map.RemoveGate(this.gameObject);
                Destroy(hit.collider.gameObject.GetComponent<Gate>().WallToDestroy);
                Destroy(hit.collider.gameObject);
                Destroy(WallToDestroy);
                Destroy(gameObject);
                break;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            UIInteraction.SetActive(true);
            canShowMenu = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        UIInteraction.SetActive(false);
        StatePlayerMovement(true);
        canShowMenu = false;
    }

    public void StatePlayerMovement(bool a_state)
    {
        player.GetComponent<PlayerMouvement>().enabled = a_state;
    }

    public Map.Cardinal GetCardinal()
    {
        return gateCardinal;
    }
    
}
