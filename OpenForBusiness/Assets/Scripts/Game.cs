using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Game : MonoBehaviour
{
    //Start variables declaration
    public Text ui, uiMulti1, uiMulti2, uiMulti3;
    public Text fillText1, fillText2, fillText3;
    public Image fillBar1, fillBar2, fillBar3;
    float startBar1,startBar2,startBar3 = 0;
    public int speedMultiplier1 = 1;
    public int speedMultiplier2 = 1;
    public int speedMultiplier3 = 1;
    public Text speed1, speed2, speed3;
    float endBar = 100;
    public Button thisButton1, thisButton2, thisButton3;
    public ArrayList Level1 = new ArrayList {111, 1111, 2222, 3333, 4444, 5555, 6666, 7337, 7777, 8123, 8234, 8400, 8500, 8700};
    public ArrayList Level2 = new ArrayList { 225, 950, 1800, 3600, 4600, 4700, 4900, 4950, 5000};
    public ArrayList Level3 = new ArrayList { 1310, 1850, 2450, 3050, 3150, 3300, 3350, 3400, 3450};
    //public ArrayList Test1 = new ArrayList {2, 3};
    //public ArrayList Test2 = new ArrayList { 4, 5 };
    //public ArrayList Test3 = new ArrayList { 6, 7 };
    //public ArrayList Test4 = new ArrayList{25, 50, 75, 100, 125, 150, 175, 200};
    //End of variables declaration

    //Increment amount of Musical Notes available
    public void Increment1(int clickID)
    { 
         GameManager.MusicalNotes += GameManager.multiplier1;
         StartCoroutine(fillBarAmount(clickID));  
    }
    public void Increment2(int clickID)
    {
        GameManager.MusicalNotes += GameManager.multiplier2;
        StartCoroutine(fillBarAmount(clickID));
    }  
    public void Increment3(int clickID)
    {
        GameManager.MusicalNotes += GameManager.multiplier3;
        StartCoroutine(fillBarAmount(clickID));
    }
    //End of Incrementation Functions

    //void Start()
    //{
    //    //int itemSize = Test1.Capacity - 1;
    //    //int lastItem = (int)Test1[2];
    //    Debug.Log(string.Format("Array Size: {0}", Test1.Count));
    //}

    //Increase multiplier by paying with musical notes 
    public void Buy(int yliaNum)
    {
        if (yliaNum == 1 && GameManager.MusicalNotes >= 25)
        {
            
            GameManager.multiplier1 += 25;
            GameManager.MusicalNotes -= 25;
            update1();
            }
        if (yliaNum == 2 && GameManager.MusicalNotes >= 125)
        {
            if (thisButton2.interactable == false)
            {
                thisButton2.interactable = true;
                GameManager.multiplier2 += 0;
                GameManager.MusicalNotes -= 125;
                update2();
            }
            else
            {
                GameManager.multiplier2 += 125;
                GameManager.MusicalNotes -= 125;
                update2();
            }
        }
        if (yliaNum == 3 && GameManager.MusicalNotes >= 1200)
        {
            if (thisButton3.interactable == false)
            {
                thisButton3.interactable = true;
                GameManager.multiplier3 += 0;
                GameManager.MusicalNotes -= 1200;
                update3();
            }
            else
            {
                GameManager.multiplier3 += 1250;
                GameManager.MusicalNotes -= 1200;
                update3();
            }
        }
        if (yliaNum == 4)
        {
            if (GameManager.MusicalNotes <= 0)
            {

            }
            else
            {
                GameManager.MusicalNotes -= GameManager.costPer1;
                GameManager.multiplier1 += GameManager.costPer1;
                update4();
            }
        }
        if (yliaNum == 5)
        {
            if (GameManager.MusicalNotes <= 0)
            {

            }
            else
            {
                GameManager.MusicalNotes -= GameManager.costPer2;
                GameManager.multiplier2 += GameManager.costPer2;
                update5();
            }
        }
        if (yliaNum == 6)
        {
            if (GameManager.MusicalNotes <= 0)
            {

            }
            else
            {
                GameManager.MusicalNotes -= GameManager.costPer3;
                GameManager.multiplier3 += GameManager.costPer3;
                update6();
            }
        }
    }
    
    //Passed ID number of clicked button and increase fillbar amount and increase filltext amount
    IEnumerator fillBarAmount(int barID)
    { 
        switch (barID)
        {
            case 1:
                //Debug.Log(string.Format("ArrayItem 0:Array Capacity: {0}", Test1.Capacity));
                //Debug.Log(string.Format("SpeedMultiplier1: {0}", speedMultiplier1));
                for (int s = 0; s < 5/speedMultiplier1; s++)
                {
                    thisButton1.interactable = false;
                    startBar1 = startBar1 + 20.0f;
                    fillBar1.fillAmount = (startBar1 / endBar) * speedMultiplier1;
                    fillText1.text = fillBar1.fillAmount * 100 + "%";
                    yield return new WaitForSeconds(1);
                }
                resetBar(fillBar1, fillText1);
                startBar1 = 0;
                thisButton1.interactable = true;
                update1();
                if (Level1.Count > 1)
                {
                    if (GameManager.multiplier1 >= (int)Level1[0] && GameManager.multiplier1 <= (int)Level1[1] && Level1.Count > 1)
                    {

                        // Debug.Log(string.Format("Array Capacity1: {0}", Test1.Count));
                        speedMultiplier1 += 1;
                        Level1.RemoveAt(0);
                        // Debug.Log(string.Format("Array Capacity1: {0}", Test1.Count));
                        
                    }
                    else
                    {

                        // Debug.Log(string.Format("Array Capacity3: {0}", Test1.Count));

                    }
                }
                else
                {
                    Debug.Log(string.Format("SpeedMultiplier1: {0}", speedMultiplier1));
                }
                break;

            case 2:
                //Debug.Log(string.Format("SpeedMultiplier2: {0}", speedMultiplier2));
                for (int t = 0; t < 5 / speedMultiplier2; t++)
                {
                    thisButton2.interactable = false;
                    startBar2 = startBar2 + 20.0f;
                    fillBar2.fillAmount = (startBar2 / endBar) * speedMultiplier2;
                    fillText2.text = fillBar2.fillAmount * 100 + "%";
                    yield return new WaitForSeconds(1);
                }
                resetBar(fillBar2, fillText2);
                startBar2 = 0;
                thisButton2.interactable = true;
                update2();
                if (Level2.Count > 1)
                {
                    if (GameManager.multiplier2 >= (int)Level2[0] && GameManager.multiplier2 <= (int)Level2[1] && Level2.Count > 1)
                    {

                        // Debug.Log(string.Format("Array Capacity1: {0}", Test1.Count));
                       
                        Level2.RemoveAt(0);
                        // Debug.Log(string.Format("Array Capacity1: {0}", Test1.Count));
                        
                    }
                    else
                    {

                        // Debug.Log(string.Format("Array Capacity3: {0}", Test1.Count));

                    }
                }
                else
                {
                    Debug.Log(string.Format("SpeedMultiplier2: {0}", speedMultiplier2));
                }
                break;
            
            case 3:
               // Debug.Log(string.Format("SpeedMultiplier3: {0}", speedMultiplier3));
                for (int r = 0; r < 5 / speedMultiplier3; r++)
                {
                    thisButton3.interactable = false;
                    startBar3 = startBar3 + 20.0f;
                    fillBar3.fillAmount = (startBar3 / endBar) * speedMultiplier3;
                    fillText3.text = fillBar3.fillAmount * 100 + "%";
                    yield return new WaitForSeconds(1);
                }
                resetBar(fillBar3, fillText3);
                startBar3 = 0;
                thisButton3.interactable = true;
                update3();
                if (Level3.Count > 1)
                {
                    if (GameManager.multiplier3 >= (int)Level3[0] && GameManager.multiplier3 <= (int)Level3[1] && Level3.Count > 1)
                    {

                        // Debug.Log(string.Format("Array Capacity1: {0}", Test1.Count));
                        speedMultiplier3 += 1;
                        Level3.RemoveAt(0);
                        // Debug.Log(string.Format("Array Capacity1: {0}", Test1.Count));
                        
                    }
                    else
                    {

                        // Debug.Log(string.Format("Array Capacity3: {0}", Test1.Count));

                    }
                }
                else
                {
                    Debug.Log(string.Format("SpeedMultiplier3: {0}", speedMultiplier3));
                }
                break;
        }
              
    }

    //Update text on the screen
    void update1()
    {
        ui.text = "Musical Notes :" + GameManager.MusicalNotes;
        if (Level1.Count > 1)
        {
            for (int i = 0; i < Level1.Count; i++)
            {
                if (GameManager.multiplier1 > (int)Level1[i])
                {
                    Level1.RemoveAt(i);
                    speedMultiplier1 += 1;
                    speed1.text = speedMultiplier1 + "";
                }
            }
            uiMulti1.text = GameManager.multiplier1 + "/" + Level1[0];
        }
        else 
        {
            uiMulti1.text = GameManager.multiplier1 + "";
            //Debug.Log(string.Format("Array update capacity: {0}", Level1.Count));
        }
    }
    void update2()
    {
        ui.text = "Musical Notes :" + GameManager.MusicalNotes;
        if (Level2.Count > 1)
        {
            for (int i = 0; i < Level2.Count; i++)
            {
                if (GameManager.multiplier2 > (int)Level2[i])
                {
                    Level2.RemoveAt(i);
                    speedMultiplier2 += 1;
                    speed2.text = speedMultiplier2 + "";
                }
            }
            uiMulti2.text = GameManager.multiplier2 + "/" + Level2[0];
        }
        else
        {
            uiMulti2.text = GameManager.multiplier2 + "";
            //Debug.Log(string.Format("Array update capacity: {0}", Level2.Count));
        }
    }
    void update3()
    {
        ui.text = "Musical Notes :" + GameManager.MusicalNotes;
        if (Level3.Count > 1)
        {
            for (int i = 0; i < Level3.Count; i++)
            {
                if (GameManager.multiplier3 > (int)Level3[i])
                {
                    Level3.RemoveAt(i);
                    speedMultiplier3 += 1;
                    speed3.text = speedMultiplier3 + "";
                }
            }
            uiMulti3.text = GameManager.multiplier3 + "/" + Level3[0];
        }
        else
        {
            uiMulti3.text = GameManager.multiplier3 + "";
           // Debug.Log(string.Format("Array update capacity: {0}", Level3.Count));
        }
    }
    void update4()
    {
        ui.text = "Musical Notes :" + GameManager.MusicalNotes;
        if (Level1.Count > 1)
        {
            for (int i = 0; i < Level1.Count; i++)
            {
                if (GameManager.multiplier1 > (int)Level1[i])
                {
                    Level1.RemoveAt(i);
                    speedMultiplier1 += 1;
                    speed1.text = speedMultiplier1 + "";
                }
            }
            uiMulti1.text = GameManager.multiplier1 + "/" + Level1[0];
        }
        else
        {
            uiMulti1.text = GameManager.multiplier1 + "";
            //Debug.Log(string.Format("Array update capacity: {0}", Level1.Count));
        }
    }
    void update5()
    {
        ui.text = "Musical Notes :" + GameManager.MusicalNotes;
        if (Level2.Count > 1)
        {
            for (int i = 0; i < Level2.Count; i++)
            {
                if (GameManager.multiplier2 > (int)Level2[i])
                {
                    Level2.RemoveAt(i);
                    speedMultiplier2 += 1;
                    speed2.text = speedMultiplier2 + "";
                }
            }
            uiMulti2.text = GameManager.multiplier2 + "/" + Level2[0];
        }
        else
        {
            uiMulti2.text = GameManager.multiplier2 + "";
           // Debug.Log(string.Format("Array update capacity: {0}", Level2.Count));
        }
    }
    void update6()
    {
        ui.text = "Musical Notes :" + GameManager.MusicalNotes;
        if (Level3.Count > 1)
        {
            for (int i = 0; i < Level3.Count; i++)
            {
                if (GameManager.multiplier3 > (int)Level3[i])
                {
                    Level3.RemoveAt(i);
                    speedMultiplier3 += 1;
                    speed3.text = speedMultiplier3 + "";
                }
            }
            uiMulti3.text = GameManager.multiplier3 + "/" + Level3[0];
        }
        else
        {
            uiMulti3.text = GameManager.multiplier3 + "";
           // Debug.Log(string.Format("Array update capacity: {0}", Level3.Count));
        }
    }
    
    //Resets Progress bar and Progress Text
    public void resetBar(Image fillbars ,Text fillText)
    {
        fillbars.fillAmount = 0;
        fillText.text = "0%";
    }
}
