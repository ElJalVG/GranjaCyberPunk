﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject pantallaInventario;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SwichPantallaInventario();
        }
    }
    public void SwichPantallaInventario()
    {
        pantallaInventario.SetActive(!pantallaInventario.activeSelf);
    }
}
