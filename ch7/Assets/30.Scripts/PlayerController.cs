using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 8f;

    // 마우스 감도
    public float mouseSensitivity = 200f;

    // 플레이어 카메라
    public Transform playerCamera;

    private CharacterController controller;

    // 상하 회전값
    private float xRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // 카메라 자동 연결
        if (playerCamera == null)
        {
            playerCamera = Camera.main.transform;
        }

        // 마우스 커서 숨기기 + 고정
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        Look();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move =
            transform.right * x +
            transform.forward * z;

        float currentSpeed = moveSpeed;

        // Shift 달리기
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }

        controller.Move(move * currentSpeed * Time.deltaTime);
    }

    void Look()
    {
        float mouseX =
            Input.GetAxis("Mouse X") *
            mouseSensitivity *
            Time.deltaTime;

        float mouseY =
            Input.GetAxis("Mouse Y") *
            mouseSensitivity *
            Time.deltaTime;

        // 위아래 시점 회전
        xRotation -= mouseY;

        // 시점 제한
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // 카메라 상하 회전
        playerCamera.localRotation =
            Quaternion.Euler(xRotation, 0f, 0f);

        // 플레이어 좌우 회전
        transform.Rotate(Vector3.up * mouseX);
    }
}