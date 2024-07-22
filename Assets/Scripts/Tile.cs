using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public GameObject Player;

    int layerMask = 1 << 8;

    public string currentPosition;
    public string targetPosition = "4, 4";

    public bool current;
    public bool target = false;
    public bool selectable;
    public bool walkable = true;


    public Material currentTileTexture;
    public Material targetTileTexture;
    public Material selectableTileTexture;
    public Material walkableTileTexture;
    public Material obstacleTileTexture;

    //Needed for BFS
    public bool visited = false;
    public Tile parent = null;
    public int distance = 0;

    private int visitedTiles = 0;
    private bool startedBuilding = false;

    int xCoordinate = 0;
    int zCoordinate = 0;

    float timePassed = 0f;

    public List<string> adjacencyList = new List<string>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //AssignCoordinates();

        FindPlayerPosition();

        timePassed += Time.deltaTime;
        if (timePassed > 0.25f)
        {
            DLS();
            timePassed = 0f;
        }
    }

    public void ResetValues()
    {
        adjacencyList.Clear();

        current = false;
        target = false;
        selectable = false;

        //visited = false;
        parent = null;
        distance = 0;
    }

    public void FindNeighbors()
    {
        //ResetValues();
        /*
        if (Convert.ToInt32(targetPosition.transform.gameObject.name[0]) > Convert.ToInt32(currentPosition.transform.gameObject.name[0]))
        {
            CheckTile(Vector3.right);
        }

        if (Convert.ToInt32(targetPosition.transform.gameObject.name[0]) < Convert.ToInt32(currentPosition.transform.gameObject.name[0]))
        {
            CheckTile(Vector3.left);
        }

        if (Convert.ToInt32(targetPosition.transform.gameObject.name[3]) > Convert.ToInt32(currentPosition.transform.gameObject.name[3]))
        {
            CheckTile(Vector3.right);
        }

        if (Convert.ToInt32(targetPosition.transform.gameObject.name[3]) < Convert.ToInt32(currentPosition.transform.gameObject.name[3]))
        {
            CheckTile(Vector3.left);
        }
        */

        switch(Random.Range(0, 4))
        {
            case 3:
                CheckTile(Vector3.forward);
                break;
            case 2:
                CheckTile(Vector3.back);
                break;
            case 1:
                CheckTile(Vector3.left);
                break;
            default:
                CheckTile(Vector3.right);
                break;
        }
            
            

    }

    
    public void CheckTile(Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, layerMask))
        {
            if (Physics.Raycast(this.transform.position, direction, out hit, 0.75f))
            {
                Tile travelToTile = hit.transform.gameObject.GetComponent<Tile>();

                if (hit.transform.gameObject != null && this.gameObject.name == currentPosition && travelToTile.visited == false)
                {
                    //adjacencyList.Add(hit.transform.gameObject.name);
                    if (currentPosition != targetPosition) Player.transform.position = new Vector3(hit.transform.position.x, 1f, hit.transform.position.z);
                    
                    visited = true;

                    Debug.Log(hit.transform.position.x + ", " + hit.transform.position.z);
                    this.GetComponent<Renderer>().material = selectableTileTexture;
                }
            }
        }
    }
    

    public void FindPlayerPosition()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, Vector3.up, out hit, layerMask))
        {

            Debug.DrawRay(transform.position, Vector3.up * hit.distance, Color.yellow);
            currentPosition = this.transform.gameObject.name;
            //Debug.Log(currentPosition);
        }
    }

    public void DLS()
    {
        FindNeighbors();
    }
}
