using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTerrain : MonoBehaviour
{
    public const float maxRenderDistance=500f;

    public int width=10;
    public int height=10;

    public float yAxisHeight = 0f;
    
    int chuncksVisibleInViewDst;

    public string seed;
    public bool useRandomSeed;

    public int chunkSize = 1;


    [Range(0,100)]
    public int mapFillPercent;
   

    Dictionary<Vector2,drawObject> objectDict = new Dictionary<Vector2,drawObject>();
    List<drawObject> objectVisibleLastUpdate = new List<drawObject>();

    public GameObject object1;

    public Transform player;

    public static Vector2 playerPos;

    void Start(){
        chuncksVisibleInViewDst = Mathf.RoundToInt(maxRenderDistance/chunkSize);
    }

    void Update(){
        playerPos = new Vector2(player.position.x, player.position.z);
        GenerateMap();
    }
    void GenerateMap(){
        for(int i = 0; i < objectVisibleLastUpdate.Count;i++){
            objectVisibleLastUpdate[i].SetVisible(false);
        }
        objectVisibleLastUpdate.Clear();
        
        randomFillMap();
        
    }

    void randomFillMap(){
        System.Random NumberGenerator = new System.Random();
        int RandNum = NumberGenerator.Next(0,1679439);
        
        seed = RandNum.ToString();
        System.Random rand = new System.Random(seed.GetHashCode());

        int currentChunckCoordX = Mathf.RoundToInt(playerPos.x/chunkSize);
        int currentChunckCoordY = Mathf.RoundToInt(playerPos.y/chunkSize);

        for(int x = -width; x < width; x++){
            for(int z = -height; z < height; z++){
                //Vector2 viewedChunckCoord = new Vector2(currentChunckCoordX,currentChunckCoordY);
                Vector2 viewedChunckCoord = new Vector2(x+currentChunckCoordX,z+currentChunckCoordY);
                if(objectDict.ContainsKey(viewedChunckCoord)){
                    objectDict[viewedChunckCoord].UpdateChunck();
                    if(objectDict[viewedChunckCoord].IsVisible()){

                        objectVisibleLastUpdate.Add(objectDict[viewedChunckCoord]);
                    }
                }
                else{
                    int numberGen = (rand.Next(0,100) < mapFillPercent)? 1:0;
                    objectDict.Add(viewedChunckCoord, new drawObject (viewedChunckCoord,chunkSize,object1,numberGen,yAxisHeight));
                }
            }
            
        }
    }

    public class drawObject{

        Vector2 position;
        Bounds bounds;
        public GameObject meshObj;
        int randomNumber;
        Vector3 pos3D;
        bool visible;

        MeshRenderer meshRenderer;
        MeshFilter meshFilter;

        public drawObject(Vector2 coord, int size, GameObject object1,int number,float yAxis){

            position = coord * size;
            pos3D = new Vector3(position.x,yAxis,position.y);
            bounds = new Bounds(position,Vector2.one * size);

            if(number == 1){
                meshObj = Instantiate(object1,pos3D,Quaternion.identity);
                SetVisible(false);
            }
            else{
                meshObj=null;
            }
            
            
        }
       
        public void UpdateChunck(){
            bool visible;
            float viewerDstFromNearestEdge;
           
            viewerDstFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance(playerPos));
            visible = viewerDstFromNearestEdge <= maxRenderDistance;
            SetVisible(visible);
        }

        public void SetVisible(bool visible){
            if(meshObj != null)
                meshObj.SetActive(visible);
        }

        public bool IsVisible(){
            if(meshObj != null)
                // Returns a bool if the object is visible
                return meshObj.activeSelf;
            else{
                return false;
            }
        }
    }
}
