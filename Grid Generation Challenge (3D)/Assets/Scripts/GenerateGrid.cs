using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    public float gridSize = 5;
    public float spacing = 5f;
    public GameObject cube;
    private GameObject[] cubeList;
    private GameObject changeCubeColor;

    //----------------------------------------------------------------------------------------
    private void Start()
    {
        InitGrid(spacing);
    }
    //----------------------------------------------------------------------------------------
    public void setSize(float size = 5)
    {
        gridSize = (int)size;
        InitGrid(spacing);
    }
    //----------------------------------------------------------------------------------------
    public void InitGrid(float distance)
    {
       spacing = distance;
       for(int x = 0; x < gridSize; x++)
        {
            for(int z = 0; z < gridSize; z++)
            {
               changeCubeColor = Instantiate(cube, new Vector3(x * spacing, 0f, z * spacing), Quaternion.identity);
                if(changeCubeColor.GetComponent<Renderer>() != null)
                {
                    changeCubeColor.GetComponent<Renderer>().material.SetColor("_Color", new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)255));
                }
            }
            RealTimeGridGeneration();
        }
        cubeList = GameObject.FindGameObjectsWithTag("cube");
    }
    //----------------------------------------------------------------------------------------
    public void RealTimeGridGeneration()
    {
        if(cubeList != null)
        {
            foreach(GameObject go in cubeList)
            {
                Destroy(go);
            }
        }
    }
    //----------------------------------------------------------------------------------------
}
