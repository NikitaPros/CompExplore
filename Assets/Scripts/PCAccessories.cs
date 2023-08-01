using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PCAccessories : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] parent;

    [HideInInspector] public ColorMat[] colorMat;
    [HideInInspector] public GameObject[] originals;
    [HideInInspector] public MouseOnObjeckt[] mouseOnObjeckt;
    [HideInInspector] public bool open;
    
    int m;
    int c;
    public void Start()
    {
        originals = new GameObject[prefabs.Length];
        colorMat = new ColorMat[prefabs.Length];
        mouseOnObjeckt = new MouseOnObjeckt[prefabs.Length];
        Spawner();     
    }
    public void Spawner()
    {
        for(int i = 0; i < prefabs.Length; i++)
        {           
            originals[i] = Instantiate(prefabs[i], parent[i]);

            if (originals[i].GetComponent<MouseOnObjeckt>())
            {  
                
                mouseOnObjeckt[i] = originals[i].GetComponent<MouseOnObjeckt>();
                mouseOnObjeckt[i].ID = m;
                mouseOnObjeckt[i].pc = this;
                m += 1;
            }
            if (originals[i].GetComponent<ColorMat>())
            {
                
                colorMat[i] = originals[i].GetComponent<ColorMat>();
                colorMat[i].ID = c;
                colorMat[i].pc = this;
                c += 1;
            }
        }    
    }
    public void StartAnim(int ID)
    {
        if(Input.GetMouseButtonDown(0))
        {
            open = !open;      
            originals[ID].GetComponent<Animator>().SetBool("Open", open);
            mouseOnObjeckt[ID].locked = open;
            
        }     
    }
    public void MaterialColor(Material mat)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Material mymat = mat;
            if (open)
            {
                Color colorRed = new Color(191, 10, 0, 0);
                mymat.SetColor("_EmissionColor", colorRed / 100.0f);
            }
            else
            {
                Color colorGreen = new Color(0, 191, 108, 0);
                mymat.SetColor("_EmissionColor", colorGreen / 100.0f);
            }
        }
        
    }

    /*public GameObject socetPref;
    public GameObject ozuPref;
    public GameObject socketRamka;

    [HideInInspector] public GameObject socetOrig;
    [HideInInspector] public Transform socetParent;
    [HideInInspector] public Animator socetAnim;
    [HideInInspector] public GameObject ozuOrig;
    [HideInInspector] public Transform ozuParent;
    [HideInInspector] public Animator ozuAnim;

    [HideInInspector] public GameObject socketRamkaOrig;
    public void Start()
    {
        WhyObject();
        SpawnAccessories();
    }
    public void SpawnAccessories()
    {
        if(socetOrig == false)
        {
            socetOrig = Instantiate(socetPref, socetParent);
            socetAnim = socetOrig.GetComponent<Animator>();
            socketRamkaOrig = Instantiate(socketRamka, socetParent);
        }    
        if(ozuOrig == false)
        {
            ozuOrig = Instantiate(ozuPref, ozuParent);
            ozuAnim = ozuOrig.GetComponent<Animator>();
        }
       
    }
    public void WhyObject()
    {
        socetParent = GameObject.FindGameObjectWithTag("Socket").transform;
        ozuParent = GameObject.FindGameObjectWithTag("Ozu").transform;  
    }*/
}
