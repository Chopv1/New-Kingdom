using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    void Start()
    {
        UiManager.Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowUi(GameObject ui)
    {
        ui.SetActive(true);
    }

}
