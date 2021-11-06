using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionObject : MonoBehaviour
{
    private MissionPlayer MP; // опять подключаем скрипт MissionPlayer;

    // Start is called before the first frame update
    void Start()
    {
        MP = GameObject.FindGameObjectWithTag("Player").GetComponent<MissionPlayer>();
    }

    void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0)) // если при нажатии на правую кнопку мыши;
        {
            if (MP.ObjectTag == gameObject.tag) // и при том что тэг объекта равен тому значению которое написано в ObjectTag;
            {
                MP.MissionObjects = true; // то переменная принимает значение true, т.е. считается что предмет собран; 
                Destroy(gameObject); // и удаляем этот объект со сцены; 
            }
        }
    }
}
