using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 2.0f; // Độ nhạy của camera
    public Transform playerBody; // Đối tượng player

    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Khóa con trỏ chuột trong game
    }

    private void Update()
    {
        // Lấy giá trị di chuyển của chuột
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Tính toán sự thay đổi góc quay theo trục Y (quay tròn)
        playerBody.Rotate(Vector3.up * mouseX);

        // Tính toán sự thay đổi góc quay theo trục X (quay lên/xuống)
        xRotation += mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Giới hạn góc quay theo trục X

        // Quay camera theo góc tính toán
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
