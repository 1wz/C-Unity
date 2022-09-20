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
        //�������� ������ ���� ���������� �������
        DestroyBonuses =new List<IDestroy>(GetComponentsInChildren<IDestroy>());

        //�� ��� ������ ����������� ���� ��������� ������ �� IU
        IScore[] ScoreBonuses = GetComponentsInChildren<Score>();
        foreach(var S in ScoreBonuses)
        {
            S.DetectText(Score);
        }

        //�� ��� ����������� ������� ��������� ������ ������������� ��� ������
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
        //���������� ��� ����������� ������
        foreach (var D in DestroyBonuses)
        {

            //������������� ������, ���� �� ����� �������� ����������� ������ ������ �� ��������
            try
            {
                D.Reload();
            }
            catch(MissingReferenceException mis)
            {
                Debug.Log("������ ��� �� �����");
                DestroyBonuses.Remove(D);
                Reload();
                return;
            }

        }

        //�������� ����
        Score.text = "0";
    }
}
