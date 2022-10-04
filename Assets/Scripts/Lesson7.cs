using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lesson7 : MonoBehaviour
{

    void Start()
    {
        //2
        string s = "ehjjtyjtjtjkt";
        Debug.Log($"{s} consists of {s.StrLength()} characters");

        //3
        //a
        List<int> list1 = new List<int>(new int[] { 1, 2, 3, 4, 7, 454, 67, 4, 7, 43, 3, 3, 3, 0, 2, 1 });
        CountTheNumber<int>(list1);
        //b
        GameObject g1 = new GameObject();
        GameObject g2 = new GameObject();
        List<GameObject> list2 = new List<GameObject>(new GameObject[] { g1, g2, g2, g2 });
        CountTheNumber<GameObject>(list2);
        //c
        CountTheNumberLinq<int>(list1);
        CountTheNumberLinq<GameObject>(list2);


        //4a
        Dictionary<string, int> dict = new Dictionary<string, int>()
        {{"four",4 },{"two",2 },{ "one",1 },{"three",3 },};
        var d = dict.OrderBy(pair=>{return pair.Value;});
        foreach (var pair in d)
        {
            Debug.Log($"{pair.Key} - {pair.Value}");
        }


    }

    public void CountTheNumber<T>(List<T> list)
    {
        Dictionary<T, int> quantity = new Dictionary<T, int>();
        foreach(T e in list)
        {
            quantity.AddOrCout(e);
        }

        string s = "";
        foreach(var q in quantity)
        {
            s += $"\"{q.Key}\"-----------{q.Value}\n";
        }
        Debug.Log(s);
    }

    public void CountTheNumberLinq<T>(List<T> list)
    {


        Dictionary<T, int> quantity = new Dictionary<T, int>();
        foreach (T e in list)
        {
            quantity.AddQuantity<T>(e, list);
        }

        string s = "";
        foreach (var q in quantity)
        {
            s += $"\"{q.Key}\"-----------{q.Value}\n";
        }
        Debug.Log(s);
    }
}

public static class Rasshirenie
{
    public static int StrLength(this string salf)
    {
        return salf.Length;
    }

    public static void AddOrCout<T>(this Dictionary<T, int> self, T element)
    {
        if (self.ContainsKey(element)) self[element]++;
        else self.Add(element, 1);
    }

    public static void AddQuantity<T>(this Dictionary<T, int> self, T element, List<T> list)
    {
        if (!self.ContainsKey(element))
        {
            var numb = from n in list
                       where n.Equals(element)
                       select n;
            self.Add(element, numb.Count()); 
        }
    }
}
