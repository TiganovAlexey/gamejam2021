using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionBot : MonoBehaviour
{

    public bool quest; //переменная, которая обозначает взят квест или нет;
    public bool vis; // переменная, которая будет отображать диалог между персонажами;
    public string missionText; // Текст который будет отображать наименование квеста;
    public string missionTag; //Тэг объекта, который необходимо принести;
    private MissionPlayer MP; // подключаем скрипт MissionPlayer;


    // Start is called before the first frame update
    void Start()
    {
        MP = GameObject.FindGameObjectWithTag("Player").GetComponent<MissionPlayer>(); // определяем что скрипт MissionPlayer будет находится на персонаже с тэгом player;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject MissionTagScanner = GameObject.FindGameObjectWithTag("Player"); // персонаж у которого берем квест будет взаимодействовать только с тем объектом у которого тэг Player;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if ((transform.position - MissionTagScanner.transform.position).sqrMagnitude < 8 * 8)
            {
                vis = true; // переменная vis принимает значение true;
            }
        }
    }
    void OnGUI()
    {
        if (vis) // если переменная равна true;
        {
            if (!quest) // и если квест еще не взят;
            {
                GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 300, 300), "Квест"); // то на экране отображается окно с названием Квест;
                GUI.Label(new Rect((Screen.width - 300) / 2 + 5, (Screen.height - 300) / 2 + 15, 290, 250), "Принеси мне сферу"); // и текстом который описывает квест;
                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "Ок")) // при нажатии на кнопку Ok;
                {
                    quest = true; // квест взят;
                    MP.quest = true; // отображает название квеста на экране;
                    MP.MissionText = "Принести сферу"; // текст квеста;
                    MP.ObjectTag = missionTag; // тэг объекта который необходимо принести;
                    vis = false; // все диалоговые окна закрываются;
                }
            }
            else
            { // если же квест уже взят;
                GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 300, 300), "Квест");
                GUI.Label(new Rect((Screen.width - 300) / 2 + 5, (Screen.height - 300) / 2 + 15, 290, 250), "Принес?"); //то описание квеста меняется на другой текст;
                if (MP.MissionObjects) // если вы уже подобрали объект;
                {
                    if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "Да")) // то появится кнопка да, при нажатии на которую;
                    {
                        quest = false; // переменная квест принимает значение false, т.е. не взят ;
                        MP.quest = false; // название квеста не будет отображаться на экране ;
                        MP.MissionText = ""; // убирается название квеста;
                        MP.ObjectTag = ""; // обнуляется тэг объекта;
                        MP.MissionObjects = false; // объект считается не подобранным;
                        MP.Point = MP.Point + 1; //добавление денег за выполнение квеста;
                        vis = false; // диалоговое окно закрывается;
                    }
                }
                else
                { // если вы еще не подобрали объект;
                    if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "Нет")) // то вместо кнопки да, будет кнопка нет;
                    {
                        MP.Point = MP.Point - 1;
                        vis = false; // при нажатии на которую, окно просто закроется;
                    }
                  
                }
            }
        }
    }
}
