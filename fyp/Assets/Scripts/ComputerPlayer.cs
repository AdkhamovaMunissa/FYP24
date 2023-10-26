using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerPlayer : MonoBehaviour
{
    public Image[] boxes;
    public Sprite crossImage;
    public Sprite tickImage;
    public int counter = 0;
    public int[] cellValues;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<9; i++)
        {
            boxes[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked in update");
        }
    }

    public void PlaceCross() {
        bool placed = false;
        int index = -1;
        while(!placed && counter < 8)
        {
            // index = Random.Range(0, 9);
            index = GetMoveIndex();
            if(!boxes[index].enabled)
            {
                boxes[index].enabled = true;
                boxes[index].sprite = crossImage;
                cellValues[index] = 0;
                placed = true;
                counter++;
                Debug.Log("Computer player: " + index);
            }    
        }
        
        
    }

    int GetMoveIndex()
    {
        for(int i=0; i<9; i++)
        {

        }
        for(int i=0; i<9; i++)
        {
            if(!boxes[i].enabled)
            {
                return i;
            }
            else if(ReferenceEquals(boxes[i].sprite, tickImage))
            {
                Debug.Log("Tick is here");
            }
        }
        return 9;
    }

    // private void OnMouseDown() {
    //     image.sprite = images[1];
    //     Debug.Log("Clicked");
    //     computerPlayer.PlaceCross();
    // }
}
