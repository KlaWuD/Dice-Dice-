using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput;

    GameObject diceObj1, diceObj2, diceObj3, diceObj4, diceObj5, diceObj6;
    DiceNum diceScript1, diceScript2, diceScript3, diceScript4, diceScript5, diceScript6;

    public GameObject GameManager;

    // 이동 (WASD)
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveInput = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveInput = Vector2.zero;
        }

    }

    // 주사위 잠금 (숫자키 1~6)
    public void OnLockDice1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            diceObj1.GetComponent<DiceNum>().DiceLocked();
        }
    }
    public void OnLockDice2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            diceObj2.GetComponent<DiceNum>().DiceLocked();
        }
    }
    public void OnLockDice3(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            diceObj3.GetComponent<DiceNum>().DiceLocked();
        }
    }
    public void OnLockDice4(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            diceObj4.GetComponent<DiceNum>().DiceLocked();
        }
    }
    public void OnLockDice5(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            diceObj5.GetComponent<DiceNum>().DiceLocked();
        }
    }
    public void OnLockDice6(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            diceObj6.GetComponent<DiceNum>().DiceLocked();
        }
    }

    // 주사위 굴리기 (Space)
    public void OnRoll(InputAction.CallbackContext context)
    {
        if (context.performed) RollAllDice();
    }

    // 점수 획득 (Enter, NumEnter)
    public void OnGain(InputAction.CallbackContext context)
    {
        if (context.performed) Debug.Log("점수 획득!");
    }

    // 상태 변경 (V)
    public void OnStatusChange(InputAction.CallbackContext context)
    {
        if (context.performed) Debug.Log("상태 변경!");
    }

    DiceNum[] diceScripts;

    void Start()
    {
        diceScripts = new DiceNum[6];
        for (int i = 0; i < 6; i++)
        {
            GameObject diceObj = GameObject.Find("Dice" + (i+1));
            diceScripts[i] = diceObj.GetComponent<DiceNum>();
        }

        diceObj1 = GameObject.Find("Dice1");
        diceObj2 = GameObject.Find("Dice2");
        diceObj3 = GameObject.Find("Dice3");
        diceObj4 = GameObject.Find("Dice4");
        diceObj5 = GameObject.Find("Dice5");
        diceObj6 = GameObject.Find("Dice6");
    }

    void Update()
    {
        if (moveInput != Vector2.zero)
        {
            // 2D에서는 x, y축만 사용
            Vector3 direction = new Vector3(moveInput.x, moveInput.y, 0);
            transform.Translate(direction * Time.deltaTime * 5f);
        }

    }

    public void RollAllDice()
    {
        foreach (DiceNum dice in diceScripts)
        {
            StartCoroutine(dice.DiceSequenceCoroutine());
        }
    }

    public void UseSilverRollAllDice()
    {
        if (GetComponent<GameManager>().silver >= GetComponent<GameManager>().stage*GetComponent<GameManager>().stage)
        {
            RollAllDice();
            GetComponent<GameManager>().rollCount++;
            GetComponent<GameManager>().silver -= GetComponent<GameManager>().stage*GetComponent<GameManager>().stage;
        }
    }

}

