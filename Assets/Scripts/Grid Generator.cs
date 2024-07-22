using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField]
    public int width, height, depth;

    public GameObject tilePrefab;
    public Material tileTexture;
    public Material targetTexture;

    int gapChance = 10; // 1 in 5 chance

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateGrid()
    {
        if(tilePrefab == null)
        {
            Debug.LogError("No Prefab Assignment");
            return;
        }

        //Create Grid

        for (int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                for (int z = 0; z < depth; z++)
                {
                    Vector3 position = new Vector3(x, y, z);

                    GameObject newTile = Instantiate(tilePrefab, position, Quaternion.identity);
                    newTile.transform.parent = transform;
                    newTile.tag = "Tile";
                    newTile.name = x + ", " + z;

                    if (x==4 && z==4)
                    {
                        newTile.GetComponent<Renderer>().material = targetTexture;
                    }
                    
                    else if(Random.Range(1, gapChance) == 1)
                    {
                        Destroy(newTile);
                    }
                }
            }
        }
    }

    public void ClearGrid()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject tile in tiles)
        {
            DestroyImmediate(tile);
        }
    }

    public void AssignMaterial()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        Material material = tileTexture; //Resources.Load<Material>("VioletTile");
        foreach(GameObject tile in tiles)
        {
            tile.GetComponent<Renderer>().material = material;
        }
    }

    public void AssignTileScript()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        Material material = tileTexture; //Resources.Load<Material>("VioletTile");
        foreach (GameObject tile in tiles)
        {
            tile.AddComponent<Tile>();
        }
    }

}
