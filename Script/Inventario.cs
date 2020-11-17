using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    
    public bool tieneOro;
    public GameObject oro;
    // Start is called before the first frame update
    void Start()
    {
        
        tieneOro = PlayerPrefs.GetString("ItemUno", "No") == "Si";
    }

    // Update is called once per frame
    void Update()
    {
        
        oro.SetActive(tieneOro);

        tieneOro = PlayerPrefs.GetString("Oro", "No") == "Si";
    }
}
