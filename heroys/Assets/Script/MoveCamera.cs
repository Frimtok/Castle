using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private float dragSpeed = 0.01f;
    private float timeDragStarted;
    private Vector3 previousPosition = Vector3.zero;
    public float MaxSpeedX;
    public float MaxSpeedY;

    void Update()
    {
        //тут может быть какое то условие, например на проверку состояния игры.
        //if (GameManager.CurrentGameState == GameState.Playing)
        //{
        //Нажимаем на экран
        if (Input.GetMouseButtonDown(0))
        {
            timeDragStarted = Time.time;
            dragSpeed = 0f;
            previousPosition = Input.mousePosition;
        }
        //перемещение 
        else if (Input.GetMouseButton(0) && Time.time - timeDragStarted > 0.05f)
        {
            //Вычисляем расстояние  между начальными и текущими координатам
            Vector3 input = Input.mousePosition;
            float deltaX = (previousPosition.x - input.x) * dragSpeed;
            float deltaY = (previousPosition.y - input.y) * dragSpeed;
            //Смотрим границы по X
            float newX = Mathf.Clamp(transform.position.x + deltaX, 0, MaxSpeedX);
            //Смотрим границы по Y
            float newY = Mathf.Clamp(transform.position.y + deltaY, 0, MaxSpeedY);
            //Задаем новые координаты для камеры
            transform.position = new Vector3(
                newX,
                newY,
                transform.position.z);

            previousPosition = input;
            //для маленьких изменений увеличиваем 
            if (dragSpeed < 0.1f) dragSpeed += 0.002f;
        }
        // }
    }
}
