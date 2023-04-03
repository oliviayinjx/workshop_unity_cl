using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    //----------01 Variables-----------//
    float cubeSize = 2.5f;
    bool spaceIsPressed = false;
    /* Transform, Rigidbody c*/

    //----------02 Public & Private-----------//
    public int cubeCount = 4;
    public Vector3 origin;
    public GameObject cube;
    private float disX = 8f;

    /*
     * these are bunch lines of code that is commented out
     */

    //----------03 Array & List-----------// 
    private GameObject[] shapesArray = new GameObject[4];
    private List<GameObject> shapesList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] shapes = new GameObject[cubeCount];
        cube.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //----------04 for loop-----------//
        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 cubePosition = origin + new Vector3(disX * i, 0, 0);
            //----------05 Instantiate()-----------//
            shapesList.Add(Instantiate(cube, cubePosition, Quaternion.identity)); //Quaternion.identity = no rotation

            //----------06 Get Component<>()-----------//
            shapesList[i].GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //----------07 If Statement-----------//
        //----------08 GetKeyDown-----------//
        if (Input.GetKeyDown(KeyCode.D))
        {
            for (int i = 0; i < shapesList.Count; i++)
            {
                Destroy(shapesList[i]);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceIsPressed = true;

            Debug.Log("space button is pressed down, add gravity");

            for (int i = 0; i < shapesList.Count; i++)
            {
                shapesList[i].GetComponent<Rigidbody>().useGravity = enabled;
            }
        }
    }


}
