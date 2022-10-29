using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject player;
    Vector3 playerStartPosition = Vector3.up;

    public GameObject prefabPlayer;
    public bool playerHasBeenInitilised = false;

    private void Update()
    {
    }
    public void InitilisePlayer()
    {
        player = Instantiate(prefabPlayer, playerStartPosition, Quaternion.identity);
        playerHasBeenInitilised = true;
    }
}
