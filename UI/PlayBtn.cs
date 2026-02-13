using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UIElements;

public class PlayBtn : MonoBehaviour
{
    private Sprite[] loadingSprites;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        loadingSprites = new Sprite[9];
        for (int i = 0; i < 9; i++)
        {
            loadingSprites[i] = Resources.Load<Sprite>("UI/Loading/" + (i + 1));
        }

        StartCoroutine(LoadingCoroutineEnd());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        StartCoroutine(LoadingCoroutineStart());
    }

    public IEnumerator LoadingCoroutineStart()
    {
        GameObject loadingObj = GameObject.Find("LoadingSprite");

        //loadingObj.SetActive(true);

        SpriteRenderer sr = loadingObj.GetComponent<SpriteRenderer>();

        for (int i = 0; i < 5; i++) 
        {
            
            if (loadingSprites[i] != null)
            {
                sr.sortingOrder = 5;
                sr.sprite = loadingSprites[i];
            }
            
            yield return new WaitForSeconds(0.2f);
        }

        SceneManager.LoadScene(1);
    }

    public IEnumerator LoadingCoroutineEnd()
    {
        GameObject loadingObj = GameObject.Find("LoadingSprite");
        SpriteRenderer sr = loadingObj.GetComponent<SpriteRenderer>();

        for (int i = 4; i < 9; i++) 
        {
            if (loadingSprites[i] != null)
            {
                sr.sortingOrder = 5;
                sr.sprite = loadingSprites[i];
                loadingObj.GetComponent<Transform>().position = new Vector3(0,0,0);
            }
            
            yield return new WaitForSeconds(0.2f);
        }

        //loadingObj.SetActive(false);

        sr.sortingOrder = -3;
    }

    public IEnumerator LoadingCoroutineToMainMenu()
    {
        GameObject loadingObj = GameObject.Find("LoadingSprite");

        //loadingObj.SetActive(true);

        SpriteRenderer sr = loadingObj.GetComponent<SpriteRenderer>();

        for (int i = 0; i < 5; i++) 
        {
            
            if (loadingSprites[i] != null)
            {
                sr.sortingOrder = 5;
                sr.sprite = loadingSprites[i];
            }
            
            yield return new WaitForSeconds(0.2f);
        }

        SceneManager.LoadScene(0);
    }

    public void BackToMainMenu()
    {
        //GameObject manager = GameObject.Find("GameManager");
        //manager.GetComponent<ControlAdmob>().ShowInterstitial();
        StartCoroutine(LoadingCoroutineToMainMenu());
    }
}
