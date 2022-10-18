using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovariantContravariant
{

    public class Class
    {
        public override string ToString()
        {
            return "Class";
        }
    }

    public class childClass:Class
    {
        public override string ToString()
        {
            return "childClass";
        }
    }

    delegate Class CovariantDelegate();
    delegate void ContravariantDelegate(childClass cc);
    public static void Main()
    {

        CovariantDelegate covariantdelegate = func;
        childClass func() => new childClass();
        Debug.Log(covariantdelegate());//childClass

        ContravariantDelegate contravariantdelegate = func2;
        void func2(Class c) => Debug.Log(c);
        contravariantdelegate(new childClass());//childClass
    }

}

public class CovariantDelegate: MonoBehaviour
{
    private void Start()
    {
        CovariantContravariant.Main();
    }
}

