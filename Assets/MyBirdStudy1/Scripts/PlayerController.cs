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
        // ��� ���� ���� 30��, �ϰ� ���� ���� -90���� ����
        //float targetRotationZ = 0f;

        //if (rb.velocity.y > 0)
        //{
        //    // ��� ���� �� �ִ� 30������
        //    targetRotationZ = 30f;
        //}
        //else if (rb.velocity.y < 0)
        //{
        //    // �ϰ� ���� �� �ִ� -90������
        //    targetRotationZ = -90f;
        //}

        //// ���� z�� ȸ������ �ε巴�� ����
        //float newZRotation = Mathf.LerpAngle(transform.rotation.eulerAngles.z, targetRotationZ, Time.deltaTime * rotationSpeed);

        //// ���ο� z�� ȸ�� ����
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
        // y �����θ� velocity �����Ͽ� ����
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
