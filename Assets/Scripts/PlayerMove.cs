using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /*
    int layerMask = 1 << 8;

    public string currentPosition = "0, 0";
    public string targetPosition = "9, 0";

    private int totalCells;
    private int visitedCells = 0;
    private bool startedBuilding = false;
    

    // Start is called before the first frame update
    void Start()
    {
        GridGenerator gridGenerator = FindObjectOfType<GridGenerator>();
        totalCells = gridGenerator.width * gridGenerator.height * gridGenerator.depth;
    }

    // Update is called once per frame
    void Update()
    {
        Tile tile = FindObjectOfType<Tile>();

        FindCurrentPosition();
        tile.FindNeighbors(0);

        Debug.Log(tile.adjacencyList);
    }

    */


    /*

    public void DepthFirstSearch()
    {
        if(visitedCells < totalCells)
        {
            if (startedBuilding)
            {

            }

            else
            {
                //currentPosition = Random.Range(0, totalCells);
                //Cells[currentPosition].visited = true;
                //visitedCells++;
                //startedBuilding = true;
            }
        }
    }

    */
}
