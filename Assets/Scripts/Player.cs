using UnityEngine;

public class Player : MonoBehaviour
{
    // Параметры персонажа
    public float speed = 5f;
    private Vector3 movement;

    void Update()
    {
        // Получение ввода от пользователя
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Объединение ввода в вектор движения
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Вызов метода для перемещения
        Move();
    }

    // Метод для перемещения персонажа
    void Move()
    {
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
