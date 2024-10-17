using UnityEngine;

public class Player : MonoBehaviour
{
    // ��������� ���������
    public float speed = 5f;
    private Vector3 movement;

    void Update()
    {
        // ��������� ����� �� ������������
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // ����������� ����� � ������ ��������
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // ����� ������ ��� �����������
        Move();
    }

    // ����� ��� ����������� ���������
    void Move()
    {
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
