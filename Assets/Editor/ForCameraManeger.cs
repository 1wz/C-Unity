using UnityEditor;
using UnityEngine;
namespace Geekbrains
{
    [CustomEditor(typeof(CameraManager))]
    public class CameraManagerEditor : UnityEditor.Editor
    {
        private bool _isPressButtonOk;
        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();
            CameraManager testTarget = (CameraManager)target;

            GUILayout.Label("��������, ������������ ���������� �����\n��������, ��� ������� ������������� ������ ������");
            testTarget.RadiusOfCamera = EditorGUILayout.Slider(testTarget.RadiusOfCamera, 1f, 10f);
            GUILayout.Label("���� ������ ������");
            testTarget.Power = EditorGUILayout.Slider(testTarget.Power, 0.001f, 0.1f);
            GUILayout.Label("����� ������ ������");
            testTarget.TimeScale = EditorGUILayout.Slider(testTarget.TimeScale, 0.05f, 5f);
        }
    }
}
