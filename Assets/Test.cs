using UnityEngine;

public class Test : MonoBehaviour
{
    public float spinSpeed = 500f;     // ��l����t��
    public float deceleration = 200f;  // ��t�v
    private float currentSpeed = 0f;   // ��e����t��
    private bool isSpinning = false;   // �O�_���b����
    private bool isDecelerating = false; // �O�_���b��t

    void Update()
    {
        // �ƹ������I�� �� �}�l����
        if (Input.GetMouseButtonDown(0))
        {
            isSpinning = true;
            isDecelerating = false;
            currentSpeed = spinSpeed;
        }

        // �ť��� �� �}�l��t
        if (Input.GetKeyDown(KeyCode.Space) && isSpinning)
        {
            isDecelerating = true;
        }

        // �Y���b����
        if (isSpinning)
        {
            // ��t�޿�
            if (isDecelerating)
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);

                // ��t���k�s �� �������
                if (currentSpeed <= 0.01f)
                {
                    currentSpeed = 0f;
                    isSpinning = false;
                    isDecelerating = false;
                }
            }

            // �������
            transform.Rotate(Vector3.forward, currentSpeed * Time.deltaTime);
        }
    }
}