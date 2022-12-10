using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private GameObject player;
    private GameObject UIInteraction;
    private GameObject MenuToShow;
    [SerializeField]
    private GameObject PositionOfTheNextMap;
    private bool canShowMenu = false;

    public LayerMask layer;

    UiManager uiManager;
    private void Start()
    {
        uiManager = UiManager.Instance;
        UIInteraction = uiManager.Interaction;
        MenuToShow = uiManager.MenuToShow;
        player = PlayerManager.Player;
        UIInteraction.SetActive(false);
        MenuToShow.SetActive(false);

    }
    private void Update()
    {
        if (canShowMenu && Input.GetKeyDown(KeyCode.E))
        {
            MenuToShow.GetComponent<UIAddPart>().SpawnMapPoint = PositionOfTheNextMap.transform.position;
            MenuToShow.GetComponent<UIAddPart>().Gate = this.gameObject;
            StatePlayerMovement(false);
            MenuToShow.SetActive(true);
        }
        CheckIfGateAlreadyHere();
    }

    public void CheckIfGateAlreadyHere()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 2, layer))
        {
            Destroy(hit.collider.gameObject);
            Destroy(gameObject);
        }
        else if (Physics.Raycast(transform.position, Vector3.back, out hit, 2, layer))
        {
            Destroy(hit.collider.gameObject);
            Destroy(gameObject);
        }
        else if (Physics.Raycast(transform.position, Vector3.left, out hit, 2, layer))
        {
            Destroy(hit.collider.gameObject);
            Destroy(gameObject);
        }
        else if (Physics.Raycast(transform.position, Vector3.right, out hit, 2, layer))
        {
            Destroy(hit.collider.gameObject);
            Destroy(gameObject);
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
}
