using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MouseOnObjeckt : MonoBehaviour
{
    public bool activeMove; 
   

    public void OnMouseEnter()
    {
        activeMove = true;
    }
    public void OnMouseExit()
    {
        activeMove =false;
    }

}
