using System.Numerics;
using TMPro;
using UnityEngine;

public class CheckStatusBtn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        DiceTxtLeft = GameObject.Find("DiceTxtLeft");
        DiceTxtRight = GameObject.Find("DiceTxtRight");
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Camera mainCamera = Camera.main; 

    GameObject gameManager;
    GameObject mainCamera;
    GameObject DiceTxtLeft;
    GameObject DiceTxtRight;

    public void SetCameraToCheckStatus()
    {
        SetStatusTxt();
        mainCamera.GetComponent<Transform>().position = new UnityEngine.Vector3(23,0,-10);
    }

    public void SetCameraToMain()
    {
        mainCamera.GetComponent<Transform>().position = new UnityEngine.Vector3(0,0,-10);
    }

    void SetStatusTxt()
    {
        float AllRate = gameManager.GetComponent<DiceScoring>().rate1+
        gameManager.GetComponent<DiceScoring>().rate2+
        gameManager.GetComponent<DiceScoring>().rate3+
        gameManager.GetComponent<DiceScoring>().rate4+
        gameManager.GetComponent<DiceScoring>().rate5+
        gameManager.GetComponent<DiceScoring>().rate6;

        DiceTxtLeft.GetComponent<TextMeshProUGUI>().text = 
        "Worth - 1	:	"+gameManager.GetComponent<DiceScoring>().worth1+
        "\nWorth - 2	:	"+gameManager.GetComponent<DiceScoring>().worth2+
        "\nWorth - 3	:	"+gameManager.GetComponent<DiceScoring>().worth3+
        "\nWorth - 4	:	"+gameManager.GetComponent<DiceScoring>().worth4+
        "\nWorth - 5	:	"+gameManager.GetComponent<DiceScoring>().worth5+
        "\nWorth - 6	:	"+gameManager.GetComponent<DiceScoring>().worth6+
        "\nRate   - 1     :     " + (gameManager.GetComponent<DiceScoring>().rate1 / AllRate * 100).ToString("F1") + "%" +
        "\nRate   - 2     :     " + (gameManager.GetComponent<DiceScoring>().rate2 / AllRate * 100).ToString("F1") + "%" +
        "\nRate   - 3     :     " + (gameManager.GetComponent<DiceScoring>().rate3 / AllRate * 100).ToString("F1") + "%" +
        "\nRate   - 4     :     " + (gameManager.GetComponent<DiceScoring>().rate4 / AllRate * 100).ToString("F1") + "%" +
        "\nRate   - 5     :     " + (gameManager.GetComponent<DiceScoring>().rate5 / AllRate * 100).ToString("F1") + "%" +
        "\nRate   - 6     :     " + (gameManager.GetComponent<DiceScoring>().rate6 / AllRate * 100).ToString("F1") + "%";

        DiceTxtRight.GetComponent<TextMeshProUGUI>().text = 
        "6-High		:	x"+gameManager.GetComponent<DiceScoring>().magnifHigh+
        "\nPair			:	x"+gameManager.GetComponent<DiceScoring>().magnifPair+
        "\nTwo-Pair		:	x"+gameManager.GetComponent<DiceScoring>().magnif2Pair+
        "\nTriple			:	x"+gameManager.GetComponent<DiceScoring>().magnifTriple+
        "\nFour of a Kind	:	x"+gameManager.GetComponent<DiceScoring>().magnif4Card+
        "\nFullHouse		:	x"+gameManager.GetComponent<DiceScoring>().magnifFullhouse+
        "\nSmall-Straight	:	x"+gameManager.GetComponent<DiceScoring>().magnifSmSt+
        "\nBig-Straight		:	x"+gameManager.GetComponent<DiceScoring>().magnifBigSt+
        "\nYatch			:	x"+gameManager.GetComponent<DiceScoring>().magnifYatch+
        "\nThreePair		:	x"+gameManager.GetComponent<DiceScoring>().magnif3Pair+
        "\nDoubleTriple	:	x"+gameManager.GetComponent<DiceScoring>().magnifDbTrp+
        "\n4-2Fullhouse	:	x"+gameManager.GetComponent<DiceScoring>().magnif42Fh+
        "\n6Straight		:	x"+gameManager.GetComponent<DiceScoring>().magnif6St+
        "\n6DiceYatch		:	x"+gameManager.GetComponent<DiceScoring>().magnif6Yatch;
    }

    public void EndGameAndToMainMenu()
    {
        
    }
}
