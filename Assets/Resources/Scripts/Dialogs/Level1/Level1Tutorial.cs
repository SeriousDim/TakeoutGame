using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Tutorial : AbstractTutorial
{
    public GameObject dialogManager;

    private Level1Dialog dialogs;

    private void Start()
    {
        base.Start();

        dialogs = dialogManager.GetComponent<Level1Dialog>();
    }

    public void StartTutorial()
    {
        ShowWindow(true);
        header.text = "Управляй Грирменом";
        text.text = "Нажимайте на <color=#0000ffff>стрелки</color>, чтобы двигаться. " +
            "Чтобы подобрать <color=#0000ffff>мусор</color>, просто подойдите к нему и он " +
            "подберется сам, если есть место в <color=#0000ffff>инвентаре</color>.";

        SetButtonListener(() => Tutorial1_1());
    }

    public void Tutorial1_1()
    {
        text.text = "Инвентарь находится сверху слева. Сейчас там пока 5 ячеек. " +
            "<color=#0000ffff>Нажмите</color> на " +
            "ячейку, чтобы выбрать её. Нажмите на <color=#0000ffff>кнопку с " +
            "крестиком</color>, чтобы выкинуть выбранный мусор из инвентаря. Не " +
            "забудьте за ним вернуться Мусорить не хорошо...";

        SetButtonListener(() => Tutorial1_2());
    }

    public void Tutorial1_2()
    {
        text.text = "Используйте " + Blue("кнопки с вертикальными стрелками") +
            ", чтобы забираться по лестницам и прыгать.";

        SetButtonListener(() => CloseOnClick());
    }

    // после истории мусора
    public void Tutorial2()
    {
        ShowWindow(true);
        header.text = "Мусор";
        text.text = "У некоторого мусора есть своя история. Вернитесь к " +
            Blue("бачку для бумаги") + ". Подойдите к бачку, выберите мусор и нажмите " +
            "на кнопку над бачком, чтобы сделать мир чище.";

        SetButtonListener(() => CloseOnClick());
    }

    // когда мусор выкинут
    public void Tutorial3_1()
    {
        ShowWindow(true);
        header.text = "Лайкоины";
        text.text = "За выброшенный мусор начисляют " + Blue("лайкоины") + " - особую валюту. За нее " +
            "можно будет покупать вещи, развивать персонажа, а также увеличивать " + Blue("популярность") +
            "идеи Гринмена.";

        SetButtonListener(() => Tutorial3_3());
    }

    public void Tutorial3_2()
    {
        text.text = "Если ты выкинул мусор не в тот бачок, то лайкоины  уменьшаются. " +
            "Каждый тип мусора имеет свою цену в лайкоинах.";

        SetButtonListener(() => Tutorial3_3());
    }

    public void Tutorial3_3()
    {
        text.text = "Заработай как можно больше лайкоинов на уровне. Лайкоины можно собирать и при " +
            "перепрохождении уровня.";

        SetButtonListener(() => { CloseOnClick();  dialogs.Branch3(); });
    }

    // при подходе к рекламе
    public void TutorialAdvert()
    {
        ShowWindow(true);
        header.text = "Популярность и реклама";
        text.text = "Нажмите на " + Blue("рекламу") + ", чтобы привлечь внимание. Находите " + 
            Blue("места ") + "на уровнях, где можно разрекламировать Гринмена. Это будет увеличивать " +
            "популярность его идеи среди людей.";

        SetButtonListener(() => CloseOnClick());
    }

    // осталось 3 мусора
    public void TutorialThreeLeft()
    {
        ShowWindow(true);
        header.text = "Осталось 3 мусора";
        text.text = "Когда мусора останется мало, игра вам об этом скажет. Но всегда могут быть " +
            "сюрпризы...";

        SetButtonListener(() => CloseOnClick());
    }

    // найден секретный мусор
    public void TutorialSecret()
    {
        ShowWindow(true);
        header.text = "Секреты";
        text.text = "Собирайте " + Blue("коллекционный мусор") + ". В будущшем его можно будет " +
            Blue("починить, разобрать ") + "или " + Blue("продать.") + "Всегда внимательно " +
            "исследуйте уровень.";

        SetButtonListener(() => CloseOnClick());
    }

    // скрытые лайкоины найдены
    public void TutorialHidden()
    {
        ShowWindow(true);
        header.text = "Лайкоины";
        text.text = "Лайкоины также могут быть скрыты на уровне. Всегда внимательно исследуйте уровень.";

        SetButtonListener(() => CloseOnClick());
    }

}
