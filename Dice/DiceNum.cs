using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class DiceNum : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static Sprite DiceSpriteOne;
    public static Sprite DiceSpriteTwo;
    public static Sprite DiceSpriteThr;
    public static Sprite DiceSpriteFur;
    public static Sprite DiceSpriteFiv;
    public static Sprite DiceSpriteSix;
    public bool Rollin;
    private SpriteRenderer spriteRenderer;

    public Sprite[][] diceSprites;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        DiceSpriteOne = Resources.Load<Sprite>("DiceEyesBasic/주사위1");
        DiceSpriteTwo = Resources.Load<Sprite>("DiceEyesBasic/주사위2");
        DiceSpriteThr = Resources.Load<Sprite>("DiceEyesBasic/주사위3");
        DiceSpriteFur = Resources.Load<Sprite>("DiceEyesBasic/주사위4");
        DiceSpriteFiv = Resources.Load<Sprite>("DiceEyesBasic/주사위5");
        DiceSpriteSix = Resources.Load<Sprite>("DiceEyesBasic/주사위6");
    
        diceSprites = new Sprite[1][]; // 예: 2가지 버전

        diceSprites[0] = new Sprite[6]; // 기본 버전
        diceSprites[0][0] = DiceSpriteOne;
        diceSprites[0][1] = DiceSpriteTwo;
        diceSprites[0][2] = DiceSpriteThr;
        diceSprites[0][3] = DiceSpriteFur;
        diceSprites[0][4] = DiceSpriteFiv;
        diceSprites[0][5] = DiceSpriteSix;

        if (gameObject.name == "Dice6")
        {
            //off
        }

        if (gameObject.name == "Dice1")
        {
            KeyBtn = "1";
        }
        else if (gameObject.name == "Dice2")
        {
            KeyBtn = "2";
        }
        else if (gameObject.name == "Dice3")
        {
            KeyBtn = "3";
        }
        else if (gameObject.name == "Dice4")
        {
            KeyBtn = "4";
        }
        else if (gameObject.name == "Dice5")
        {
            KeyBtn = "5";
        }
        else if (gameObject.name == "Dice6")
        {
            KeyBtn = "6";
        }

        StartCoroutine(DiceSequenceCoroutine());
    }

    public int DiceNumber = 0; 

    public bool DiceLock = false;

    public int DicePointPlus = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GameManager;

    public void ChangeSprite(Sprite sprite)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = sprite;
        }
    }

    public void DiceRoll()
    {
        float rate1 = GameObject.Find("GameManager").GetComponent<DiceScoring>().rate1;
        float rate2 = GameObject.Find("GameManager").GetComponent<DiceScoring>().rate2;
        float rate3 = GameObject.Find("GameManager").GetComponent<DiceScoring>().rate3;
        float rate4 = GameObject.Find("GameManager").GetComponent<DiceScoring>().rate4;
        float rate5 = GameObject.Find("GameManager").GetComponent<DiceScoring>().rate5;
        float rate6 = GameObject.Find("GameManager").GetComponent<DiceScoring>().rate6;

        int randNum = UnityEngine.Random.Range(1,Convert.ToInt32(rate1+rate2+rate3+rate4+rate5+rate6));

        if (randNum <= rate1)
        {
            DiceNumber = 1;   
        } 
        else if (randNum <= rate1+rate2)
        {
            DiceNumber = 2;
        }
        else if (randNum <= rate1+rate2+rate3)
        {
            DiceNumber = 3;
        }
        else if (randNum <= rate1+rate2+rate3+rate4)
        {
            DiceNumber = 4;
        }
        else if (randNum <= rate1+rate2+rate3+rate4+rate5)
        {
            DiceNumber = 5;
        }
        else if (randNum <= rate1+rate2+rate3+rate4+rate5+rate6)
        {
            DiceNumber = 6;
        }

        Debug.Log("Dice Roll! " +gameObject.name + " : "+DiceNumber);
    }

    public void SetDiceSprite()
    {
        if (DiceNumber == 1)
        {
            ChangeSprite(DiceSpriteOne);
        }
        else if (DiceNumber == 2)
        {
            ChangeSprite(DiceSpriteTwo);
        }
        else if (DiceNumber == 3)
        {
            ChangeSprite(DiceSpriteThr);
        }
        else if (DiceNumber == 4)
        {
            ChangeSprite(DiceSpriteFur);
        }
        else if (DiceNumber == 5)
        {
            ChangeSprite(DiceSpriteFiv);
        }
        else if (DiceNumber == 6)
        {
            ChangeSprite(DiceSpriteSix);
        }
    }

    public IEnumerator DiceSequenceCoroutine()
    {
        if (DiceLock == false)
        {
            for (int i = 0; i < 10; i++) 
            {
                // diceSprites[0]에 있는 6개의 스프라이트 중 하나를 무작위로 선택
                int randomIdx = UnityEngine.Random.Range(0, 6); 
                spriteRenderer.sprite = diceSprites[0][randomIdx];
                
                yield return new WaitForSeconds(0.1f); // 0.1초 간격으로 교체
            }

            // 연출이 끝난 후 실제 값 결정
            DiceRoll();
            SetDiceSprite();
            GameManager.GetComponent<DiceScoring>().CheckPoint();
            GameManager.GetComponent<GameManager>().SetBtnText();
        }
    }

    public string KeyBtn;
    public void DiceLocked()
    {
        TextMeshProUGUI btnText;
        UnityEngine.UI.Image btnImg;
        btnText = GetComponentInChildren<TextMeshProUGUI>();
        btnImg = GetComponentInChildren<UnityEngine.UI.Image>();
        if (DiceLock == true)
        {
            DiceLock = false;
            Debug.Log(gameObject.name + " is UnLocked!");
            btnImg.color = new Color(58/255f,185/255f,243/255f,1f);
            //btnText.text = "Unlock Key("+KeyBtn+")";
            btnText.text = "Unlock";
        }
        else
        {
            DiceLock = true;
            Debug.Log(gameObject.name + " is Locked!");
            btnImg.color = new Color(243/255f,124/255f,58/255f,1f);
            //btnText.text = "Locked Key("+KeyBtn+")";
            btnText.text = "Locked";
        }
    }

    public void SetDiceUnlock()
    {
        TextMeshProUGUI btnText;
        UnityEngine.UI.Image btnImg;
        btnText = GetComponentInChildren<TextMeshProUGUI>();
        btnImg = GetComponentInChildren<UnityEngine.UI.Image>();
        DiceLock = false;
        Debug.Log(gameObject.name + " is UnLocked!");
        btnImg.color = new Color(58/255f,185/255f,243/255f,1f);
        //btnText.text = "Unlock Key("+KeyBtn+")";
        btnText.text = "Unlock";
    }
}
