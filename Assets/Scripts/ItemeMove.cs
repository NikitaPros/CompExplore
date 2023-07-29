using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ItemeMove : MonoBehaviour
{
    public GameObject procPref;
    public float dis = 10f;
    public Button socketLock;

    [HideInInspector] public GameObject procOrig;
    [HideInInspector] public Transform procParent;
    [HideInInspector] public bool activeMove = true;
    [HideInInspector] public bool locked;
   

    MouseOnObjeckt _mouseOnObjeckt;
    PCAccessories pcAcces;    
    Image imageBtn;

    public void Start()
    {
        
        SpawnItem();        
        socketLock.onClick.AddListener(SocketLock);      
    }
    void Update()
    {
        MoveItems();
        ColorGade();      
    }

    public void SpawnItem()
    {
        procParent = GameObject.FindGameObjectWithTag("Processor").transform;
        pcAcces = GameObject.FindGameObjectWithTag("Motherboard").GetComponent<PCAccessories>();
        procOrig = Instantiate(procPref, procParent);
        _mouseOnObjeckt = procOrig.GetComponent<MouseOnObjeckt>();
    }
    public void MoveItems ()
    {
        activeMove = _mouseOnObjeckt.activeMove;

        if (locked)
        {
            if (Input.GetMouseButton(0))
            {
                if (activeMove)
                {
                    Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dis);
                    Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
                    procOrig.transform.position = objPos;
                }
            }
        }
        
    }
    public void SocketLock()
    {       
        locked = !locked;
        
        pcAcces.socetAnim.SetBool("Open", locked);      
    }
    public void ColorGade()
    {
        imageBtn = socketLock.gameObject.GetComponent<Image>();
        if (locked) imageBtn.color = new Color(0.18f, 0.94f, 0.16f, 0.25f);
        else imageBtn.color = new Color(0.94f, 0.17f, 0.16f, 0.25f);
    }

    
}
