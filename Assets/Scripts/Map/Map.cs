using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour
{
    public enum Cardinal { CENTER, NORTH, SOUTH, EAST, WEST, /*NORTHEST,NORTHWEST, SOUTHEST, SOUTHWEST,*/ NONE }
    
    private Cardinal mapCardinal;

    private GameObject m_NorthPart = null;
    private GameObject m_SouthPart = null;
    private GameObject m_EastPart = null;
    private GameObject m_WestPart = null;

    private string name;
    private float cost;
    private float kingdomExp;

    [SerializeField] private GameObject center;
    [SerializeField] private List<GameObject> gates = new List<GameObject>();

    public GameObject NorthPart { get => m_NorthPart; set => m_NorthPart = value; }
    public GameObject SouthPart { get => m_SouthPart; set => m_SouthPart = value; }
    public GameObject EastPart { get => m_EastPart; set => m_EastPart = value; }
    public GameObject WestPart { get => m_WestPart; set => m_WestPart = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(mapCardinal != Cardinal.CENTER || mapCardinal != Cardinal.NONE)
            CheckCardinal();
    }

    private void CheckCardinal()
    {

    }

    public void RemoveGate(GameObject a_gate)
    {
        gates.Remove(a_gate);
    }
    public int GetGatesCount()
    {
        return gates.Count();
    }
    public void SetMapCardinal(Cardinal a_cardinal)
    {
        mapCardinal = a_cardinal;
    }
    public Cardinal GetMapCardinal()
    {
        return mapCardinal;
    }
}
