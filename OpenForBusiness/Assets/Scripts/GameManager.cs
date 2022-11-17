using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int MusicalNotes;
    public static int multiplier1, multiplier2, multiplier3;
    public static int costPer1, costPer2, costPer3;
    
    
    // Start is called before the first frame update
    void Start()
    {
        multiplier1 = 1;
        multiplier2 = 1;
        multiplier3 = 1;
        MusicalNotes = 0;
        costPer1 = 1;
        costPer2 = 1;
        costPer3 = 1;
    


        //Debug.Log(string.Format("Multiplier: {0}", multiplier1));
    }

   
}
