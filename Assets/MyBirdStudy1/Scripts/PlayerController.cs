using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 5f;
    public GameObject bird;
    public float rotationSpeed = 1f;
    private Vector3 birdRotain;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Ready();
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.IsStart = true;
            Jump();
        }
        // 상승 중일 때는 30도, 하강 중일 때는 -90도로 제한
        //float targetRotationZ = 0f;

        //if (rb.velocity.y > 0)
        //{
        //    // 상승 중일 때 최대 30도까지
        //    targetRotationZ = 30f;
        //}
        //else if (rb.velocity.y < 0)
        //{
        //    // 하강 중일 때 최대 -90도까지
        //    targetRotationZ = -90f;
        //}

        //// 현재 z축 회전값을 부드럽게 보간
        //float newZRotation = Mathf.LerpAngle(transform.rotation.eulerAngles.z, targetRotationZ, Time.deltaTime * rotationSpeed);

        //// 새로운 z축 회전 적용
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newZRotation);

        float degree = 0;
        if (rb.velocity.y > 0f)
        {
            degree = rotationSpeed;
        }
        else
        {
            degree = -rotationSpeed;
        }

        float rotationZ = Mathf.Clamp(birdRotain.z + degree, -90f, 30f);
        birdRotain = new Vector3(0f, 0f, rotationZ);
        transform.eulerAngles = birdRotain;
    }
    void Jump()
    {
        // y 축으로만 velocity 설정하여 점프
        Debug.Log("JUMP");
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void Ready()
    {
        if (GameManager.IsStart == true) return;
        if (rb.velocity.y < 0)
            rb.velocity = Vector2.up * 0.3f;
    }

}
