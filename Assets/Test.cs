using UnityEngine;

public class Test : MonoBehaviour
{
    public float spinSpeed = 500f;     // 初始旋轉速度
    public float deceleration = 200f;  // 減速率
    private float currentSpeed = 0f;   // 當前旋轉速度
    private bool isSpinning = false;   // 是否正在旋轉
    private bool isDecelerating = false; // 是否正在減速

    void Update()
    {
        // 滑鼠左鍵點擊 → 開始旋轉
        if (Input.GetMouseButtonDown(0))
        {
            isSpinning = true;
            isDecelerating = false;
            currentSpeed = spinSpeed;
        }

        // 空白鍵 → 開始減速
        if (Input.GetKeyDown(KeyCode.Space) && isSpinning)
        {
            isDecelerating = true;
        }

        // 若正在旋轉
        if (isSpinning)
        {
            // 減速邏輯
            if (isDecelerating)
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);

                // 當速度歸零 → 停止旋轉
                if (currentSpeed <= 0.01f)
                {
                    currentSpeed = 0f;
                    isSpinning = false;
                    isDecelerating = false;
                }
            }

            // 執行旋轉
            transform.Rotate(Vector3.forward, currentSpeed * Time.deltaTime);
        }
    }
}