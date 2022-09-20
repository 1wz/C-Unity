using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField]
    Text Score;
    [SerializeField]
    PlayerAbstract Player;
    [SerializeField]
    CameraShake CameraWithShake;

    List<IDestroy> DestroyBonuses;
    void Start()
    {
        //создадим список всех исчезающих бонусов
        DestroyBonuses =new List<IDestroy>(GetComponentsInChildren<IDestroy>());

        //во все бонусы начисл€ющие очки передадим ссылку на IU
        IScore[] ScoreBonuses = GetComponentsInChildren<Score>();
        foreach(var S in ScoreBonuses)
        {
            S.DetectText(Score);
        }

        //во все смертельные ловушки передадим методы выполн€ющиес€ при смерти
        Die[] die= GetComponentsInChildren<Die>();
        foreach(var d in die)
        {
            d.ondie += Reload;
            d.ondie +=Player.Die;
            d.ondie += CameraWithShake.Shake;
        }
    }

    public void Reload()
    {
        //возвращаем все исчезнувшие бонусы
        foreach (var D in DestroyBonuses)
        {

            //перехватываем ошибку, если во врем€ плэймода программист удалил объект из иерархии
            try
            {
                D.Reload();
            }
            catch(MissingReferenceException mis)
            {
                Debug.Log("больше так не делай");
                DestroyBonuses.Remove(D);
                Reload();
                return;
            }

        }

        //обнул€ем счет
        Score.text = "0";
    }
}
