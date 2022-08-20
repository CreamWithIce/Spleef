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
    // Sets the width and height of the floor in a 2d array
    // For each index in the 2d array it creates an instance of a tile
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
                // Checks if there is an object at the index and checks if the player is touching that location and that it hasn't had a rigidbody assigned to it then it assigns a rb
                // And sets the drag on the rb
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
                // If the floor tile is below the despawn level then it destroys the tile
                if(floor[x,z] != null){
                    if(floor[x,z].transform.position.y <= despawnLevel)
                        Destroy(floor[x,z]);
                }
            }
        }
    }
}
