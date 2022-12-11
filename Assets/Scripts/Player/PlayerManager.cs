using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Vector3 playerStartPosition = Vector3.up;

    public static GameObject player;
    public static GameObject Player { get => player;}

    public GameObject prefabPlayer;
    public bool playerHasBeenInitilised = false;


    private void Start()
    {

    }
    private void Update()
    {
    }
    public void InitilisePlayer()
    {
        player = Instantiate(prefabPlayer, playerStartPosition, Quaternion.identity);
        player.transform.parent = gameObject.transform;
        playerHasBeenInitilised = true;
    }
}
