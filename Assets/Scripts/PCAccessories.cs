using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCAccessories : MonoBehaviour
{
    public GameObject socetPref;
    public GameObject ozuPref;
    public GameObject socketWorkPref;

    [HideInInspector] public GameObject socetOrig;
    [HideInInspector] public Transform socetParent;
    [HideInInspector] public Animator socetAnim;
    [HideInInspector] public GameObject ozuOrig;
    [HideInInspector] public Transform ozuParent;

    [HideInInspector] public GameObject socketWorkOrig;
    [HideInInspector] public Transform socketWorkParent;

    ItemeMove itemMove;


    public void Start()
    {
        WhyObject();
        SpawnAccessories();
    }
    public void Update()
    {
        AccessoriesWork();
    }

    public void SpawnAccessories()
    {
        if(socetOrig == false)
        {
            socetOrig = Instantiate(socetPref, socetParent);
            socetAnim = socetOrig.GetComponent<Animator>();
        }    
        if(ozuOrig == false)
        {
            ozuOrig = Instantiate(ozuPref, ozuParent);
        }
       
    }
    public void WhyObject()
    {
        socetParent = GameObject.FindGameObjectWithTag("Socket").transform;
        ozuParent = GameObject.FindGameObjectWithTag("Ozu").transform;
        socketWorkParent = GameObject.FindGameObjectWithTag("SocketWork").transform;
        itemMove = GameObject.FindGameObjectWithTag("Tools").GetComponent<ItemeMove>();
    }
    public void AccessoriesWork()
    {
        if (itemMove.locked)
        {
            if (socketWorkOrig == false)
            {
                socketWorkOrig = Instantiate(socketWorkPref, socketWorkParent);
            }
        }
    }
}
