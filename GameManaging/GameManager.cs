using System;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public int rollCount;
    public int silverCount;
    public int useSilverCount;
    bool ClickTime = false;
    float time;
    public GameObject dice1,dice2,dice3,dice4,dice5,dice6;
    public bool gameStartbool = false;
    public int silver = 20;

    public int stage = 1;

    public int statusChangeCount;
    public int round = 1;
    public int goalSilver = 100;

    // Update is called once per frame
    void Update()
    {
        if (ClickTime == true)
        {
            time += Time.deltaTime;
            if (time >= 1.5)
            {
                ClickTime = false;
                time = 0;
            }
        }
    }

    public void StageOrRoundUp()
    {
        if (round >= 5)
        {
            if (silver >= goalSilver)
            {
                if (stage>5)
                {
                    SetCameraEnd();
                }
                else
                {
                    round = 1;
                    stage++;                    
                }

            }
            else
            {
                SetCameraEnd();
            }
        }
        else
        {
            round++;
        }

        goalSilver = Convert.ToInt32(Math.Pow(stage, 1.5) * 100);
    }

    public GameObject rollTxt;
    public GameObject gainTxt;
    public GameObject statChgTxt;
    public GameObject CheckStatTxt;
    public GameObject StatusTxt;
    public void SetBtnText()
    {
        rollTxt.GetComponent<TextMeshProUGUI>().text = "Roll Cost : "+stage*stage+"silver";
        gainTxt.GetComponent<TextMeshProUGUI>().text = GetComponent<DiceScoring>().diceRewardName + "Get " + Convert.ToInt32(GetComponent<DiceScoring>().diceRewardPoint) + "Silver";
        statChgTxt.GetComponent<TextMeshProUGUI>().text = "Status Change \nCost : "+stage*stage*5+"silver";
        CheckStatTxt.GetComponent<TextMeshProUGUI>().text = "Check My Status";
        StatusTxt.GetComponent<TextMeshProUGUI>().text = 
        "Stage  	: 	"+stage+
        "\nRound	:	"+round+
        "\nSilver		:	"+silver+
        "\nGoal		:	"+goalSilver;
    }
    public void GainBtnActive()
    {
        if (ClickTime == false)
        {
            ClickTimeTrue();
            silver += Convert.ToInt32(GetComponent<DiceScoring>().diceRewardPoint);
            silverCount += Convert.ToInt32(GetComponent<DiceScoring>().diceRewardPoint);
            StageOrRoundUp();
            AllDiceUnlock();
            dice1.GetComponent<DiceNum>().SetDiceUnlock();
            dice2.GetComponent<DiceNum>().SetDiceUnlock();
            dice3.GetComponent<DiceNum>().SetDiceUnlock();
            dice4.GetComponent<DiceNum>().SetDiceUnlock();
            dice5.GetComponent<DiceNum>().SetDiceUnlock();
            dice6.GetComponent<DiceNum>().SetDiceUnlock();
            GetComponent<PlayerController>().RollAllDice();            
        }

    }

    GameObject mainCamera;

    public void StatusChangeBtnActive()
    {
        if (silver >= stage*stage*5)
        {
            silver -= stage*stage*5;
            StatusChange();
            mainCamera = GameObject.Find("Main Camera");
            mainCamera.GetComponent<Transform>().position = new Vector3(-25,15,-10);
        }
    }

    public void BackToMain()
    {
        SetBtnText();
        mainCamera = GameObject.Find("Main Camera");
        mainCamera.GetComponent<Transform>().position = new Vector3(0,0,-10);
    }
    public void AgreeStatusChange()
    {
        var diceScoring = GetComponent<DiceScoring>();

        var map = new Dictionary<string, Action<int>> {
            // worth
            { "worth1", delta => diceScoring.worth1 += delta },
            { "worth2", delta => diceScoring.worth2 += delta },
            { "worth3", delta => diceScoring.worth3 += delta },
            { "worth4", delta => diceScoring.worth4 += delta },
            { "worth5", delta => diceScoring.worth5 += delta },
            { "worth6", delta => diceScoring.worth6 += delta },

            // rate
            { "rate1", delta => diceScoring.rate1 += delta },
            { "rate2", delta => diceScoring.rate2 += delta },
            { "rate3", delta => diceScoring.rate3 += delta },
            { "rate4", delta => diceScoring.rate4 += delta },
            { "rate5", delta => diceScoring.rate5 += delta },
            { "rate6", delta => diceScoring.rate6 += delta },

            // magnif (배수/보너스 계열)
            { "magnifPair",    delta => diceScoring.magnifPair    += delta },
            { "magnif2Pair",   delta => diceScoring.magnif2Pair   += delta },
            { "magnifTriple",  delta => diceScoring.magnifTriple  += delta },
            { "magnif4Card",   delta => diceScoring.magnif4Card   += delta },
            { "magnifFullhouse", delta => diceScoring.magnifFullhouse += delta },
            { "magnifSmSt",    delta => diceScoring.magnifSmSt    += delta },
            { "magnifBigSt",   delta => diceScoring.magnifBigSt   += delta },
            { "magnifYatch",   delta => diceScoring.magnifYatch   += delta },
            { "magnif3Pair",   delta => diceScoring.magnif3Pair   += delta },
            { "magnifDbTrp",   delta => diceScoring.magnifDbTrp   += delta },
            { "magnif42Fh",    delta => diceScoring.magnif42Fh    += delta },
            { "magnif6St",     delta => diceScoring.magnif6St     += delta },
            { "magnif6Yatch",  delta => diceScoring.magnif6Yatch  += delta },
        };

        // 적용
        foreach (var (fieldName, delta) in randomList)
        {
            if (map.ContainsKey(fieldName))
                map[fieldName](delta);
        }

        GetComponent<DiceScoring>().CheckLow();

        BackToMain();
    }
    public void AllDiceUnlock()
    {
        dice1.GetComponent<DiceNum>().DiceLock = false;
        dice2.GetComponent<DiceNum>().DiceLock = false;
        dice3.GetComponent<DiceNum>().DiceLock = false;
        dice4.GetComponent<DiceNum>().DiceLock = false;
        dice5.GetComponent<DiceNum>().DiceLock = false;
        dice6.GetComponent<DiceNum>().DiceLock = false;
    }

    public void ClickTimeTrue()
    {
        ClickTime = true;
    }

    public void SetCameraEnd()
    {
        GameObject manager = GameObject.Find("GameManager");
        manager.GetComponent<ControlAdmob>().ShowInterstitial();

        GameObject mainCamera = GameObject.Find("Main Camera");

        GameObject EndGameTxt = GameObject.Find("EndGameTxt");
        useSilverCount = silverCount - silver + 20;
        EndGameTxt.GetComponent<TextMeshProUGUI>().text = 
        "Total Roll			: 	"+rollCount+
        "\nTotal Silver 			: 	"+silverCount+
        "\nTotal Used Silver 		: 	"+useSilverCount+
        "\nTotal Status Change 	: 	"+statusChangeCount;

        mainCamera.GetComponent<Transform>().position = new Vector3(-25,0,-10);
    }

    List<(string,int)> randomList;

    int count;

    public void StatusChange()
    {
        statusChangeCount++;

        List<string> specs = new List<string>() 
        {
        "worth1","worth2","worth3","worth4","worth5","worth6",
        "rate1","rate2","rate3","rate4","rate5","rate6",
        "magnifPair","magnif2Pair","magnifTriple","magnif4Card","magnifFullhouse","magnifSmSt","magnifBigSt","magnifYatch"
        ,"magnif3Pair","magnifDbTrp","magnif42Fh","magnif6St","magnif6Yatch"
        };

        System.Random rand = new System.Random();
        count = rand.Next(1,4);

        int randNum1 = rand.Next(-3,4);
        int randNum2 = 0;
        int randNum3 = 0;
        if (count > 1)
        {
            randNum2 = rand.Next(-3,4);
        }
        
        if (count > 2)
        {
            randNum3 = rand.Next(-3,4);
        }

        int stringRand1 = rand.Next(1,specs.Count+1);
        int stringRand2 = rand.Next(1,specs.Count+1);
        int stringRand3 = rand.Next(1,specs.Count+1);

        string rand1 = specs[stringRand1];
        string rand2 = "";
        string rand3 = "";
        if (count > 1)
        {
            rand2 = specs[stringRand2];
        }

        if (count > 2)
        {
            rand3 = specs[stringRand3];
        }
        
        randomList = new List<(string,int)> {(rand1,randNum1),(rand2,randNum2),(rand3,randNum3)};
        
        GameObject statusChangeTxt = GameObject.Find("StatusChangeTxt");

        string s = CheckString(randomList[0].Item1);
        int va = randomList[0].Item2;

        if (count == 1)
        {
            statusChangeTxt.GetComponent<TextMeshProUGUI>().text =
            "Do you Want to Change your Status?\n\n"
            + s + " + ("    // string만 함수에 전달
            + va+")";
        }
        else if (count == 2)
        {
            statusChangeTxt.GetComponent<TextMeshProUGUI>().text =
            "Do you Want to Change your Status?\n\n"
            + s + " + (" 
            + va + ")"+"\n"
            +CheckString(randomList[1].Item1) + " + (" 
            +randomList[1].Item2+")";
        }
        else if (count == 3)
        {
            statusChangeTxt.GetComponent<TextMeshProUGUI>().text =
            "Do you Want to Change your Status?\n\n"
            + s +" + ("   // string만 함수에 전달
            + va + ")"+"\n"
            +CheckString(randomList[1].Item1) +" + ("
            +randomList[1].Item2+ ")"+"\n"
            +CheckString(randomList[2].Item1) +" + ("
            +randomList[2].Item2 + ")";
        }

    }

    string CheckString(string str)
    {
        if (str == "worth1")
        {
            return "Value of Dice Face 1";
        }
        else if (str == "worth2")
        {
            return "Value of Dice Face 2";
        }
        else if (str == "worth3")
        {
            return "Value of Dice Face 3";
        }
        else if (str == "worth4")
        {
            return "Value of Dice Face 4";
        }
        else if (str == "worth5")
        {
            return "Value of Dice Face 5";
        }
        else if (str == "worth6")
        {
            return "Value of Dice Face 6";
        }
        else if (str == "rate1")
        {
            return "Chance of Dice Face 1";
        }
        else if (str == "rate2")
        {
            return "Chance of Dice Face 2";
        }
        else if (str == "rate3")
        {
            return "Chance of Dice Face 3";
        }
        else if (str == "rate4")
        {
            return "Chance of Dice Face 4";
        }
        else if (str == "rate5")
        {
            return "Chance of Dice Face 5";
        }
        else if (str == "rate6")
        {
            return "Chance of Dice Face 6";
        }
        else if (str == "magnifPair")
        {
            return "One Pair Multiplier";
        }
        else if (str == "magnif2Pair")
        {
            return "Two Pair Multiplier";   
        }
        else if (str == "magnifTriple")
        {
            return "Triple Multiplier";
        }
        else if (str == "magnif4Card")
        {
            return "Four of a Kind Multiplier";
        }
        else if (str == "magnifFullhouse")
        {
            return "Full House Multiplier";
        }
        else if (str == "magnifSmSt")
        {
            return "Small Straight Multiplier";
        }
        else if (str == "magnifBigSt")
        {
            return "Big Straight Multiplier";
        }
        else if (str == "magnifYatch")
        {
            return "Yatch Multiplier";
        }
        else if (str == "magnif3Pair")
        {
            return "Three Pair Multiplier";
        }
        else if (str == "magnifDbTrp")
        {
            return "Double Triple Multiplier";
        }
        else if (str == "magnif42Fh")
        {
            return "4-2 Full house Multiplier";
        }
        else if (str == "magnif6St")
        {
            return "6 - Straight Multiplier";
        }
        else if (str == "magnif6Yatch")
        {
            return "6 Dice Yatch Multiplier";
        }
        else
        {
            return "";
        }
    }

}
