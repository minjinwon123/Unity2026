using UnityEngine;
using UnityEngine.InputSystem;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;

    public float spawnDistance = 2f;
    public float shootPower = 2000f;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Transform cam = Camera.main.transform;

            // 카메라 앞에서 생성
            Vector3 spawnPos =
                cam.position + cam.forward * spawnDistance;

            // 생성
            GameObject bamsongi = Instantiate(
                bamsongiPrefab,
                spawnPos,
                Quaternion.identity
            );

            // 마우스 위치 기준 Ray
            Ray ray = Camera.main.ScreenPointToRay(
                Mouse.current.position.value
            );

            // Ray 방향으로 발사
            bamsongi.GetComponent<BamsongiController>()
                    .Shoot(ray.direction * shootPower);
        }
    }
}