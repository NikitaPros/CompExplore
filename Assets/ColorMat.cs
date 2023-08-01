using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMat : MonoBehaviour
{
    
    public Material mat;
    public int ID;
    public PCAccessories pc;
    public void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
   
    public void Update()
    {
        ColorEdit();
    }
    public void ColorEdit()
    {
        if(pc.mouseOnObjeckt[ID].activeMove)
        {
            pc.MaterialColor(mat);
        }      
    }
}
