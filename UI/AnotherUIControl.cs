using UnityEngine;

public class AnotherUIControl : MonoBehaviour
{
    public float targetY = 125f;      // 목표 위치
    public float moveSpeed = 10f;     // 내려오는 기본 속도
    public float smoothTime = 0.15f;  // 목표 근처에서 감속되는 부드러움 정도

    private float velocity = 0f;
    private bool isMoving = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Vector3 currentPos = transform.localPosition;

            // SmoothDamp를 사용하되, 거리가 가깝기 때문에 smoothTime을 짧게 잡습니다.
            float newY = Mathf.SmoothDamp(currentPos.y, targetY, ref velocity, smoothTime, moveSpeed);

            transform.localPosition = new Vector3(currentPos.x, newY, currentPos.z);

            // 도착 판정 (차이가 0.01보다 작아지면)
            if (Mathf.Abs(newY - targetY) < 0.01f)
            {
                transform.localPosition = new Vector3(currentPos.x, targetY, currentPos.z);
                isMoving = false;
                velocity = 0f;
                Debug.Log("125 지점 안착!");
            }
        }
    }

    public void AnotherUIMove()
    {
        isMoving = true;
        velocity = 0f;
    }
}
