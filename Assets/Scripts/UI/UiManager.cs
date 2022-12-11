using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [SerializeField]
    private GameObject m_Interaction;
    [SerializeField]
    private GameObject m_MenuToShow;

    public GameObject Interaction { get => m_Interaction; }
    public GameObject MenuToShow { get => m_MenuToShow; }

    void Awake()
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
