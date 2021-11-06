using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionPlayer : MonoBehaviour
{

    public bool quest; //  отображает название квеста на экране;
    public string MissionText; // название квеста;
    public string ObjectTag; // тэг объекта;
    public bool MissionObjects; //отображает собран предмет или нет;
    public int Money; // количество денег;


    void OnGUI()
    {

        if (quest)
        {
            GUI.Label(new Rect(20, 80, 300, 30), " " + MissionText); // значение названия квеста будет браться из скрипта Misson Bot;
            if (MissionObjects)
            { // если предмет собран;
                GUI.Label(new Rect(150, 80, 200, 30), "[Предмет собран]"); // выводит надпись;
            }
        }
        GUI.Label(new Rect(20, 100, 100, 30), "Деньги: " + Money); // отображает количество денег на экране;
    }

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
