using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collider : MonoBehaviour
{
    public GameObject player;
    public GameObject UIToShow;
    public GameObject MenuToShow;

    UiManager uiManager;
    private void Start()
    {
        uiManager = UiManager.Instance;
        player = PlayerManager.player;
        UIToShow.SetActive(false);
        MenuToShow.SetActive(false);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            UIToShow.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                MenuToShow.SetActive(true);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        UIToShow.SetActive(false);
    }
}
