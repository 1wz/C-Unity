using UnityEditor;


public class MenuItems
{
    [MenuItem("����/����� ���� �1 ")]
    private static void MenuOption()
    {
        EditorWindow.GetWindow(typeof(MyWindow), false, "������� ��������");
    }

}
