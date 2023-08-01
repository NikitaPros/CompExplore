using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class ItemeMove : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] parents;

    [HideInInspector] public GameObject[] originals;
    [HideInInspector] public PositionEnd[] positionEnd;
    
    public float dis;
    public float rotSpeed = 20;

    PCAccessories pc;
    PlayerLook look;
    Vector2 turn;

    public void Start()
    {
        originals = new GameObject[prefabs.Length];
        positionEnd = new PositionEnd[prefabs.Length];
        pc = GameObject.FindGameObjectWithTag("Motherboard").GetComponent<PCAccessories>();
        look = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerLook>();
        Spawner();
    }
    public void Spawner()
    {
        for(int i = 0; i < prefabs.Length; i++)
        {           
            originals[i] = Instantiate(prefabs[i], parents[i]);

            originals[i].AddComponent<PositionEnd>();
            originals[i].AddComponent<Rigidbody>().isKinematic = true;
            originals[i].GetComponent<PositionEnd>().position = originals[i].transform.localPosition;
            originals[i].GetComponent<PositionEnd>().rotation = originals[i].transform.localRotation;
            originals[i].GetComponent<PositionEnd>().nameAccess = parents[i].tag;
            originals[i].transform.localPosition = new Vector3(0, 0, 0);
            originals[i].transform.localRotation = Quaternion.identity;


            positionEnd[i] = originals[i].GetComponent<PositionEnd>();
            positionEnd[i].ID = i;
            positionEnd[i].item = this;
        }
    }   
    public void MoveItems(bool triger, bool activeMove, int ID, Vector3 position, Vector3 rotation)
    {
        look.lockLook = false;

        if (pc.mouseOnObjeckt[ID].locked)
        {
            if (activeMove)
            {
                if (Input.GetMouseButton(0))
                {
                    Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dis);
                    Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
                    originals[ID].transform.position = objPos;
                    if (Input.GetMouseButton(1))
                    {
                        look.lockLook = true;

                        /*float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
                        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

                        originals[ID].transform.RotateAround(Vector3.up, -rotX);
                        originals[ID].transform.RotateAround(Vector3.right, rotY);*/

                        turn.x += Input.GetAxis("Mouse X") * rotSpeed;
                        turn.y += Input.GetAxis("Mouse Y") * rotSpeed;

                        originals[ID].transform.localRotation = Quaternion.Euler(-turn.y, -turn.x, 0);    
                    }
                    else
                    {
                        originals[ID].transform.localRotation = Quaternion.identity;
                        turn = new Vector2(0, 0);
                    }
                }             
            }
            if(triger)
            {
                originals[ID].transform.localPosition = position;
                originals[ID].transform.localRotation = Quaternion.Euler(rotation);
            }        
        }
    }

    /*public GameObject procPref;
    public GameObject procWorkPref;
    public GameObject procRamka;
    public float dis = 10f;
  
    bool activeMove = true;
    bool locked;
    bool socetBool;

    GameObject procOrig;
    GameObject procWorkOrig;
    GameObject procRamkaOrig;
    Transform procParent;
    Transform procWorkParent;
    PCAccessories pcAcces;
    PositionEnd prosPos;
    public void Start()
    {       
        SpawnItem();                    
    }
    void Update()
    {
        Main();
    }
    public void Main()
    {       
        activeMove = procOrig.GetComponent<MouseOnObjeckt>().activeMove;
        socetBool = pcAcces.socetOrig.GetComponent<MouseOnObjeckt>().activeMove;

        if(procOrig.GetComponent<PositionEnd>().triger)
        {
            procOrig.transform.localPosition = procOrig.GetComponent<PositionEnd>().position;
            if(procOrig.transform.localPosition == procOrig.GetComponent<PositionEnd>().position)
            {
                if(locked == false)
                {
                    procWorkOrig = Instantiate(procWorkPref, procWorkParent);
                    procOrig.GetComponent<PositionEnd>().triger = false;
                }
            }
        }
        MoveItems();
        SocketLock();
    }

    public void SpawnItem()
    {
        procParent = GameObject.FindGameObjectWithTag("Processor").transform;
        procWorkParent = GameObject.FindGameObjectWithTag("SocketWork").transform;
        pcAcces = GameObject.FindGameObjectWithTag("Motherboard").GetComponent<PCAccessories>();
        procOrig = Instantiate(procPref, procParent);
        procRamkaOrig = Instantiate(procRamka, procParent);


    }
    public void MoveItems ()
    {    
        if (locked)
        {
            if (Input.GetMouseButton(0))
            {
                if (activeMove)
                {
                    Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dis);
                    Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
                    procOrig.transform.position = objPos;

                    Material mymat = procRamkaOrig.GetComponent<Renderer>().material;
                    Color colorRed = new Color(191, 10, 0, 0);
                    mymat.SetColor("_EmissionColor", colorRed / 100.0f);
                }     
            }
        }       
    }
    public void SocketLock()
    {
        if (socetBool)
        {
            if (Input.GetMouseButtonDown(0))
            {
                locked = !locked;
                pcAcces.socetAnim.SetBool("Open", locked);
                Material mymat = pcAcces.socketRamkaOrig.GetComponent<Renderer>().material;
                if (locked)
                {
                    Color colorRed = new Color(191, 10, 0, 0);
                    mymat.SetColor("_EmissionColor", colorRed / 100.0f);
                }else
                {
                    Color colorGreen = new Color(0, 191, 108, 0);
                    mymat.SetColor("_EmissionColor", colorGreen / 100.0f);
                }

                
               
            }
        }          
    }
    */
}
