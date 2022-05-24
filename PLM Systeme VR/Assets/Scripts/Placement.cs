using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    private GameObject CD_Drive;
    private GameObject CD;
    private GameObject USB;
    private GameObject USB_port;
    private GameObject PC_box;// outside


    private GameObject HDD;
    private GameObject SSD;
    private GameObject CPU;
    private GameObject RAM_1;
    private GameObject RAM_2;
    private GameObject RAM_3;
    private GameObject GPU;


    private GameObject AM4_socket;
    private Transform AM4_socketTransform;
    private Transform AM4_socketTransformDistance;

    private GameObject PCIe_slot1;
    private Transform PCIe_slot1Transform;
    private Transform PCIe_slot1TransformDistance;

    private GameObject PCIe_slot2;
    private Transform PCIe_slot2Transform;
    private Transform PCIe_slot2TransformDistance;

    private GameObject PCIe_slot3;
    private Transform PCIe_slot3Transform;
    private Transform PCIe_slot3TransformDistance;

    private GameObject DIMMSlot;
    private Transform DIMMSlotTransform;
    private Transform DIMMSlotTransformDistance;

    private GameObject SATA_connectors;
    private Transform SATA_connectorsTransform;
    private Transform SATA_connectorsTransformDistance;

    private Dictionary<GameObject, GameObject> partsByPort = new Dictionary<GameObject, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        DIMMSlot = GameObject.Find("DIMMSlot");
        HDD = GameObject.Find("HDD");
        SSD = GameObject.Find("SSD");
        CPU = GameObject.Find("CPU");
        RAM_1 = GameObject.Find("RAM 1");
        RAM_2 = GameObject.Find("RAM 2");
        RAM_3 = GameObject.Find("RAM 3");
        CD_Drive = GameObject.Find("CD Drive");
        CD = GameObject.Find("CD");
        USB = GameObject.Find("USB");
        USB_port = GameObject.Find("USB port");
        PC_box = GameObject.Find("PC box");
        AM4_socket = GameObject.Find("AM4 socket");
        PCIe_slot1 = GameObject.Find("PCIe slot1");
        PCIe_slot2 = GameObject.Find("PCIe slot2");
        PCIe_slot3 = GameObject.Find("PCIe slot3");
        GPU = GameObject.Find("GPU");
        SATA_connectors = GameObject.Find("SATA connectors");

        partsByPort.Add(DIMMSlot, GPU);
        partsByPort.Add(SATA_connectors, SSD);
        partsByPort.Add(AM4_socket, CPU);
        //connect.Add(CD_Drive, CD);
        //connect.Add(USB_port, USB);
        partsByPort.Add(PCIe_slot1, RAM_1);
        partsByPort.Add(PCIe_slot2, RAM_2);
        partsByPort.Add(PCIe_slot3, RAM_3);

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void SnapCheck(GameObject gameObject)
    {
        Vector2 objDistance = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        GameObject value = null;
        // foreach

        foreach(KeyValuePair<GameObject, GameObject> pair in partsByPort)
        {
            if(pair.Value == gameObject &&
                (Vector2.Distance(pair.Key.transform.position, objDistance) >= -1.0f 
                || Vector2.Distance(pair.Key.transform.position, objDistance) <= 1.0f))
            { 
                    gameObject.transform.position = pair.Key.transform.position;
            }   
        }
    }
}

