using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;


public class PositionEnd : MonoBehaviour
{
    
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 rot;
    public bool activeMove;
    public bool locked;
    public bool triger;
    public int ID;
    public ItemeMove item;
    public string nameAccess;

    public void OnMouseEnter()
    {
        activeMove = true;

    }
    public void OnMouseExit()
    {
        activeMove = false;
    }
    private void Update()
    {
        if (activeMove)
        {
            rot = rotation.eulerAngles;
            item.MoveItems(triger, activeMove, ID, position, rot);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == nameAccess)
        {
            triger = true;          
        }
    }
   
}
