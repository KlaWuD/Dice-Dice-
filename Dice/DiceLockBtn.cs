using UnityEngine;

public class DiceLockBrtn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DiceLockButtonClicked()
    {
        gameObject.GetComponentInParent<DiceNum>().DiceLocked();
    }
}
