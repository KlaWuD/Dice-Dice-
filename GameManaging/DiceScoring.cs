using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class DiceScoring : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetPatternWorth();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string nowPatternString;

    public int nowPatternValue;

    public int magnifHigh = 0;
    public int magnifPair = 2;
    public int magnif2Pair = 2;
    public int magnifTriple = 4;
    public int magnif4Card = 16;
    public int magnifFullhouse = 10;
    public int magnifSmSt = 6;
    public int magnifBigSt = 12;
    public int magnifYatch = 50;
    public int magnif3Pair = 6;
    public int magnifDbTrp = 24;
    public int magnif42Fh = 14;
    public int magnif6St = 20;
    public int magnif6Yatch = 90;
    public DiceNum dice1, dice2, dice3, dice4, dice5, dice6;
    public bool sixDice = true;
    public string diceRewardName;
    public float diceRewardPoint;
    public string nowPatternName;
    public bool isStraight = false;

    public float worth1, worth2, worth3, worth4, worth5, worth6;
    public float rate1, rate2, rate3, rate4, rate5, rate6;
    public void nowPattern()
    {
        
    }

    public void CheckLow()
    {
        if (rate1 < 20)
        {
            rate1 = 20;
        }
        if (rate2 < 20)
        {
            rate2 = 20;
        }
        if (rate3 < 20)
        {
            rate3 = 20;
        }
        if (rate4 < 20)
        {
            rate4 = 20;
        }
        if (rate5 < 20)
        {
            rate5 = 20;
        }
        if (rate6 < 20)
        {
            rate6 = 20;
        }
        if (worth1 < 1)
        {
            worth1 = 1;
        }
        if (worth2 < 1)
        {
            worth2 = 1;
        }
        if (worth3 < 1)
        {
            worth3 = 1;
        }
        if (worth4 < 1)
        {
            worth4 = 1;
        }
        if (worth5 < 1)
        {
            worth5 = 1;
        }
        if (worth6 < 1)
        {
            worth6 = 1;
        }
        if(magnifHigh > 0)
        {
            magnifHigh = 0;
        }
        if(magnifPair<1)
        {
        magnifPair = 2;
        }
        if(magnif2Pair < 1)
        {
        magnif2Pair = 2;
        }
        if(magnifTriple < 1)
        {
        magnifTriple = 4;
        }
        if(magnif4Card < 1)
        {
        magnif4Card = 16;
        }
        if(magnifFullhouse < 1)
        {
        magnifFullhouse = 10;
        }
        if(magnifSmSt < 1)
        {
        magnifSmSt = 6;
        }
        if(magnifBigSt < 1)
        {
        magnifBigSt = 12;
        }
        if(magnifYatch < 1)
        {
        magnifYatch = 50;
        }
        if(magnif3Pair < 1)
        {
        magnif3Pair = 6;
        }
        if(magnifDbTrp < 1)
        {
        magnifDbTrp = 24;
        }
        if(magnif42Fh < 1)
        {
        magnif42Fh = 14;
        }
        if(magnif6St < 1)
        {
        magnif6St = 20;
        }
        if(magnif6Yatch < 1)
        {
        magnif6Yatch = 90;
        }
    }
    public void SetPatternWorth()
    {
        magnifHigh = 0;
        magnifPair = 2;
        magnif2Pair = 2;
        magnifTriple = 4;
        magnif4Card = 16;
        magnifFullhouse = 10;
        magnifSmSt = 6;
        magnifBigSt = 12;
        magnifYatch = 50;
        magnif3Pair = 6;
        magnifDbTrp = 24;
        magnif42Fh = 14;
        magnif6St = 20;
        magnif6Yatch = 90;
        worth1 = 1;
        worth2 = 2;
        worth3 = 3;
        worth4 = 4;
        worth5 = 5;
        worth6 = 6;
        rate1 = 100;        
        rate2 = 100;
        rate3 = 100;
        rate4 = 100;
        rate5 = 100;
        rate6 = 100;
    }

    public void CheckPoint()
    {
        List<int> nums = new List<int>();
        int[] numsCount = new int[7];
        isStraight = false;

        nums.Add(dice1.DiceNumber);
        nums.Add(dice2.DiceNumber);
        nums.Add(dice3.DiceNumber);
        nums.Add(dice4.DiceNumber);
        nums.Add(dice5.DiceNumber);
        
        if (sixDice == true) 
        {
            nums.Add(dice6.DiceNumber);
        }

        foreach (int n in nums)
        {
            if (n >= 1 && n <= 6) numsCount[n]++;
        }
       
        // 6-Straight
        if (numsCount[1] == 1 && numsCount[2] == 1 && numsCount[3] == 1 && 
            numsCount[4] == 1 && numsCount[5] == 1 && numsCount[6] == 1)
        {
            SetPattern("123456 - Six Straight!", "magnif6St", GetWorth(6), "magnif6St");
            isStraight = true;
        }
        // Six Dice Yatch
        else if (numsCount.Any(c => c >= 6))
        {
            int n = System.Array.IndexOf(numsCount, numsCount.Max());
            SetPattern(n + " - Six Dice Yatch!", "magnif6Yatch", GetWorth(n), "magnif6Yatch");
        }
        // Yatch
        else if (numsCount.Any(c => c >= 5))
        {
            int n = System.Array.LastIndexOf(numsCount, numsCount.Max());
            SetPattern(n + " - Yatch!", "magnifYatch", GetWorth(n), "magnifYatch");
        }
        // Big Straight
        else if (numsCount[2] >= 1 && numsCount[3] >= 1 && numsCount[4] >= 1 && numsCount[5] >= 1 && numsCount[6] >= 1)
        {
            SetPattern("6 - BigStraight", "magnifBigSt", GetWorth(6), "magnifBigSt");
            isStraight = true;
        }
        // Big Straight
        else if (numsCount[1] >= 1 && numsCount[2] >= 1 && numsCount[3] >= 1 && numsCount[4] >= 1 && numsCount[5] >= 1)
        {
            SetPattern("5 - BigStraight", "magnifBigSt", GetWorth(5), "magnifBigSt");
            isStraight = true;
        }
        // Double Triple
        else if (numsCount.Count(c => c >= 3) >= 2)
        {
            List<int> dtNums = new List<int>();
            for(int i=1; i<=6; i++) if(numsCount[i] >= 3) dtNums.Add(i);
            float p = (GetWorth(dtNums[0]) + GetWorth(dtNums[1])) * GetMagnif("magnifDbTrp") / 2f;
            diceRewardName = string.Join("", dtNums) + " - DoubleTriple";
            diceRewardPoint = p;
            nowPatternName = "magnifDbTrp";
        }
        // 4-2Fullhouse
        else if (numsCount.Any(c => c == 4) && numsCount.Any(c => c == 2))
        {
            int threeN = System.Array.IndexOf(numsCount, 4);
            int twoN = System.Array.IndexOf(numsCount, 2);
            diceRewardName = $"{threeN}{twoN} 4-2 Full House";
            diceRewardPoint = (GetWorth(threeN) * GetMagnif("magnif42Fh") * 1.2f) + (GetWorth(twoN) * GetMagnif("magnifFullhouse") * 0.6f);
            nowPatternName = "magnif42Fh";
        }
        // Fullhouse
        else if (numsCount.Any(c => c == 3) && numsCount.Any(c => c == 2))
        {
            int threeN = System.Array.IndexOf(numsCount, 3);
            int twoN = System.Array.IndexOf(numsCount, 2);
            diceRewardName = $"{threeN}{twoN} Full House";
            diceRewardPoint = (GetWorth(threeN) * GetMagnif("magnifFullhouse") * 0.6f) + (GetWorth(twoN) * GetMagnif("magnifFullhouse") * 0.4f);
            nowPatternName = "magnifFullhouse";
        }
        // Three Pair
        else if (numsCount.Count(c => c >= 2) >= 3)
        {
            nowPatternName = "magnif3Pair";
            List<int> triplePairs = new List<int>();
            for (int i = 1; i <= 6; i++)
            {
                if (numsCount[i] >= 2) triplePairs.Add(i);
            }
            triplePairs.Sort();

            float p = (GetWorth(triplePairs[0]) + GetWorth(triplePairs[1]) + GetWorth(triplePairs[2])) 
                    * GetMagnif("magnif3Pair");
            
            diceRewardName = string.Join("", triplePairs) + " - TriplePair";
            diceRewardPoint = p;
        }
        // Four of a Kind
        else if (numsCount.Any(c => c >= 4))
        {
            int n = System.Array.LastIndexOf(numsCount, numsCount.Where(c => c >= 4).Max());
            SetPattern(n + " - Four of a Kind", "magnif4Card", GetWorth(n), "magnif4Card");
        }

        // Triple
        else if (numsCount.Any(c => c >= 3))
        {
            int n = System.Array.LastIndexOf(numsCount, numsCount.Where(c => c >= 3).Max());
            SetPattern(n + " - Triple", "magnifTriple", GetWorth(n), "magnifTriple");
        }
        // Small Straight
        else if ((numsCount[1] >= 1 && numsCount[2] >= 1 && numsCount[3] >= 1 && numsCount[4] >= 1) ||
                (numsCount[2] >= 1 && numsCount[3] >= 1 && numsCount[4] >= 1 && numsCount[5] >= 1) ||
                (numsCount[3] >= 1 && numsCount[4] >= 1 && numsCount[5] >= 1 && numsCount[6] >= 1))
        {
            int highN = 4;
            if (numsCount[3] >= 1 && numsCount[4] >= 1 && numsCount[5] >= 1 && numsCount[6] >= 1) highN = 6;
            else if (numsCount[2] >= 1 && numsCount[3] >= 1 && numsCount[4] >= 1 && numsCount[5] >= 1) highN = 5;

            SetPattern(highN + " - SmallStraight", "magnifSmSt", GetWorth(highN), "magnifSmSt");
            isStraight = true;
        }
        // Two Pair
        else if (numsCount.Count(c => c >= 2) >= 2)
        {
            nowPatternName = "magnif2Pair";
            List<int> pairNums = new List<int>();
            for (int i = 1; i <= 6; i++)
            {
                if (numsCount[i] >= 2) pairNums.Add(i);
            }
            pairNums.Sort();

            float p = (GetWorth(pairNums[0]) + GetWorth(pairNums[1])) * GetMagnif("magnif2Pair");
            
            diceRewardName = string.Join("", pairNums) + " - TwoPair";
            diceRewardPoint = p;
        }
        // One Pair
        else if (numsCount.Any(c => c >= 2))
        {
            nowPatternName = "magnifPair";
            int pairN = System.Array.LastIndexOf(numsCount, numsCount.Max(c => c >= 2 ? c : 0));
            
            diceRewardName = pairN + " - OnePair";
            diceRewardPoint = GetWorth(pairN) * GetMagnif("magnifPair");
        }
        // [One Pair & High Card]
        else 
        {
        nowPatternName = "magnifHigh";
            // 6번 눈부터 거꾸로 내려오며 있는 숫자를 찾음
            int highN = 1;
            for (int i = 6; i >= 1; i--)
            {
                if (numsCount[i] > 0)
                {
                    highN = i;
                    break;
                }
            }

            diceRewardName = highN + " - High";
            diceRewardPoint = GetWorth(highN) * GetMagnif("magnifHigh");
        }

        UpdateUI();
    }

    float GetWorth(int n) 
    {
        if (n == 1) return worth1;
        if (n == 2) return worth2;
        if (n == 3) return worth3;
        if (n == 4) return worth4;
        if (n == 5) return worth5;
        return worth6;
    }

    void SetPattern(string name, string pattern, float worth, string magnifKey) 
    {
        diceRewardName = name;
        nowPatternName = pattern;
        diceRewardPoint = GetMagnif(magnifKey) * worth;
    }

    // 이 부분은 GameManager나 특정 데이터 스크립트에서 배율을 가져오도록 설정하세요
    float GetMagnif(string key) 
    {
        if (key == "magnif6Yatch")
        {
            return magnif6Yatch;
        }
        else if(key == "magnif6St")
        {
            return magnif6St;
        }
        else if(key == "magnif42Fh")
        {
            return magnif42Fh;
        }
        else if(key == "magnifDbTrp")
        {
            return magnifDbTrp;
        }
        else if(key == "magnif3Pair")
        {
            return magnif3Pair;
        }
        else if(key == "magnifYatch")
        {
            return magnifYatch;
        }
        else if(key == "magnifBigSt")
        {
            return magnifBigSt;
        }
        else if(key == "magnifSmSt")
        {
            return magnifSmSt;
        }
        else if(key == "magnifFullhouse")
        {
            return magnifFullhouse;
        }
        else if(key == "magnif4Card")
        {
            return magnif4Card;
        }
        else if(key == "magnifTriple")
        {
            return magnifTriple;
        }
        else if(key == "magnif2Pair")
        {
            return magnif2Pair;
        }
        else if(key == "magnifPair")
        {
            return magnifPair;
        }
        else
        {
            return magnifHigh;
        }
    }

    void UpdateUI() 
    {
        // Tag로 찾는 대신 인스펙터에서 할당해서 쓰는 것이 훨씬 빠릅니다.
        // gainButtonText.text = diceRewardName + "(으)로 획득하기";
        // gainMesoText.text = "획득 메소 : " + Mathf.FloorToInt(diceRewardPoint) + "메소";
    }
}
