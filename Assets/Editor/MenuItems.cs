using UnityEditor;


public class MenuItems
{
    [MenuItem("Меню/Пункт меню №1 ")]
    private static void MenuOption()
    {
        EditorWindow.GetWindow(typeof(MyWindow), false, "Подсчет объектов");
    }

}
