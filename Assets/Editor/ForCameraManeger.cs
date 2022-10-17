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

            GUILayout.Label("ѕараметр, определ€ющий рассто€ние между\nигроками, при котором увеличиваетс€ высота камеры");
            testTarget.RadiusOfCamera = EditorGUILayout.Slider(testTarget.RadiusOfCamera, 1f, 10f);
            GUILayout.Label("—ила тр€ски камеры");
            testTarget.Power = EditorGUILayout.Slider(testTarget.Power, 0.001f, 0.1f);
            GUILayout.Label("¬рем€ тр€ски камеры");
            testTarget.TimeScale = EditorGUILayout.Slider(testTarget.TimeScale, 0.05f, 5f);
        }
    }
}
