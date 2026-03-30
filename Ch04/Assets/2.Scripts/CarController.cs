using UnityEngine;
using UnityEngine.InputSystem;  // 입력을 감지하는 데 필요!

public class CarController : MonoBehaviour
{
    float speed = 0;
    Vector2 startPos;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        // 스와이프의 길이를 구한다
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스를 클릭한 좌표
            startPos = Mouse.current.position.value;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = Input.mousePosition;
            float swipeLength = endPos.x - startPos.x;
            speed = swipeLength / 500.0f;
        }

        transform.Translate(this.speed, 0, 0);
        speed *= 0.98f;
    }
}
