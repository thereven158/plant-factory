using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapHandler : MonoBehaviour
{
    
    public GameObject Max;
    
    public void Maximize()
    {
        Max.SetActive(true);
    }

    public void Minimize()
    {
        Max.SetActive(false);
    }
}
