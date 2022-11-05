using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Vector3 playerStartPosition = Vector3.up;

    public static GameObject player;

    public GameObject prefabPlayer;
    public bool playerHasBeenInitilised = false;

    public static GameObject Player { get => player;}

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
