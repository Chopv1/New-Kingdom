using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private GameObject player;
    private GameObject UIToShow;
    private GameObject MenuToShow;
    [SerializeField]
    private GameObject PositionOfTheNextMap;
    private bool canShowMenu = false;

    UiManager uiManager;
    private void Start()
    {
        uiManager = UiManager.Instance;
        UIToShow = uiManager.Interaction;
        MenuToShow = uiManager.MenuToShow;
        player = PlayerManager.Player;
        UIToShow.SetActive(false);
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
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject == player)
        {
            UIToShow.SetActive(true);
            canShowMenu = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        UIToShow.SetActive(false);
        StatePlayerMovement(true);
        canShowMenu = false;
    }

    public void StatePlayerMovement(bool a_state)
    {
        player.GetComponent<PlayerMouvement>().enabled = a_state;
    }
}
