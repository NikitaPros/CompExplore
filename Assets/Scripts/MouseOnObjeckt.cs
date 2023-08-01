using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MouseOnObjeckt : MonoBehaviour
{
    public bool activeMove;
    public int ID;
    public PCAccessories pc;
    public bool locked;
    public void OnMouseEnter()
    {
        activeMove = true;
        
    }
    public void OnMouseExit()
    {
        activeMove =false;
    }
    public void Update()
    {
        if(activeMove)
        {
            pc.StartAnim(ID);
        }
    }

}
