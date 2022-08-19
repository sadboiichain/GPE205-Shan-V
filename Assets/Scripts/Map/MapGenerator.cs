using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //2d array to store map and locations
    private Room[,] grid;
    //array for possible rooms
    public GameObject[] gridPrefabs;
    //grid locations
    public int rows;
    public int cols;
    //room dimensions for ease of understanding
    public float roomWidth = 50.0f;
    public float roomHeight = 50.0f;

    public int mapSeed;
    public bool isDaily;//for checking if the daily map is used
    public bool isRandom;


    // Update is called once per frame
    void Awake()
    {
    GenerateMap();
    }

    public GameObject RandomRoom()
    {
        return gridPrefabs[UnityEngine.Random.Range(0, gridPrefabs.Length)];
    }

    public int DateToInt(DateTime dateToUse)
    {
        //add the date up and return it
        return dateToUse.Year + dateToUse.Month + dateToUse.Day + dateToUse.Hour + dateToUse.Minute + dateToUse.Second + dateToUse.Millisecond;
    }

    public void GenerateMap()
    {
        if(isDaily)
        {
            mapSeed = DateToInt(DateTime.Now.Date);
        }
        else if(isRandom)
        {
            mapSeed = DateToInt(DateTime.Now);
        }

        UnityEngine.Random.seed = mapSeed;
        
        //clear the grid, cols = x/row = y
        grid = new Room[cols,rows];
        
        //for each grid row
        for(int currentRow = 0; currentRow < rows; currentRow++)
        {   //for each column in that row
            for(int currentCol = 0; currentCol < cols; currentCol++)
            {
                //find the location
                float xPos = roomWidth * currentCol;
                float zPos = roomHeight * currentRow;
                Vector3 newPosition = new Vector3(xPos, 0.0f, zPos);

                //create a new grid at the location
                GameObject tempRoomObj = Instantiate(RandomRoom(), newPosition, Quaternion.identity);

                //set its parent
                tempRoomObj.transform.parent = this.transform;

                //give it a name
                tempRoomObj.name = "Room_" +currentCol+","+ currentRow;

                //Get the room obj
                Room tempRoom = tempRoomObj.GetComponent<Room>();

                //save to the current grid array
                grid[currentCol,currentRow] = tempRoom;

                if(currentRow == 0)//bottom
                {
                    tempRoom.doorNorth.SetActive(false);
                }
                else if(currentRow == rows-1)//top 
                {
                    //if we are on the top, open the south door
                    Destroy(tempRoom.doorSouth);
                }
                else//middle
                {
                    //destroy both
                    Destroy(tempRoom.doorNorth);
                    Destroy(tempRoom.doorSouth);
                }

                if(currentCol == 0)//east
                {
                    tempRoom.doorEast.SetActive(false);
                    //honestly unknown what this does
                }
                else if(currentCol == cols - 1)
                {
                    Destroy(tempRoom.doorWest);
                    
                }
                else
                {
                    Destroy(tempRoom.doorEast);
                    Destroy(tempRoom.doorWest);
                }
            }

        }
    }

    public void ChangeDaily(bool toggle)
    {
        isDaily = toggle;
    }

    public void ChangeRandom(bool toggle)
    {
        isRandom = toggle;
    }

    public void setSeed(int seed)
    {
        mapSeed = seed;
    }
}

