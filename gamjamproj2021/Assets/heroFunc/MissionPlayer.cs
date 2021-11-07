using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionPlayer : MonoBehaviour
{

    public bool quest; //  отображает название квеста на экране;
    public string MissionText; // название квеста;
    public string ObjectTag; // тэг объекта;
    public bool MissionObjects; //отображает собран предмет или нет;
    public int Point; // количество денег;
    public float timersecond; //Время выполнения квеста
    

    void Update()
    {

    }

    void OnGUI()
    {

        if (quest)
        {
            GUI.Label(new Rect(20, 80, 300, 30), " " + MissionText); // значение названия квеста будет браться из скрипта Misson Bot;
            timersecond -= Time.deltaTime;
            var time = Mathf.Round(timersecond).ToString();
            GUI.Label(new Rect(20, 120, 100, 30), "Время: " + time);

            if(timersecond <= 0.1f)
            {
                Destroy(gameObject);
            }

            if (MissionObjects)
            { // если предмет собран;
                GUI.Label(new Rect(150, 80, 200, 30), "[Предмет собран]"); // выводит надпись;
            }
        }
        GUI.Label(new Rect(20, 100, 100, 30), "Уважение: " + Point); // отображает количество денег на экране;
    }

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}


   
}
