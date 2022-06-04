using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpleefFloorGenerator : MonoBehaviour
{

    public float despawnLevel = -10f;

    public float drag = 2f;
    public float boxCheckHeight;
    
    public int height,width;

    public int y = -1;

    public int size;

    GameObject[,] floor;
    bool check;
    public LayerMask playerMask;

    public GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        floor = new GameObject[width,height];
        for(int x = 0; x < width; x+=size){
            for(int z = 0; z < height; z+=size){
                floor[x,z] = Instantiate(tile,new Vector3(x,y,z),Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int x = 0; x < width; x+=size){
            for(int z = 0; z < height; z+=size){
                if(floor[x,z] != null){
                    if(Physics.CheckBox(
                        new Vector3(x,y,z), 
                        new Vector3(size,boxCheckHeight,size), 
                        Quaternion.identity, playerMask) 

                    && floor[x,z].GetComponent<Rigidbody>() == null){

                        floor[x,z].AddComponent<Rigidbody>();
                        Rigidbody Drag = floor[x,z].GetComponent<Rigidbody>();
                        Drag.drag = drag;
                    }
                }
                if(floor[x,z] != null){
                    if(floor[x,z].transform.position.y <= despawnLevel)
                        Destroy(floor[x,z]);
                }
            }
        }
    }
}
