using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Geekbrains
{
    public sealed class Radar : MonoBehaviour
    {
        private Transform CenterPos;
        public float _mapScale = 1;
        public List<RadarObject> RadObjects = new List<RadarObject>();
        static public Action<GameObject, Image> RegisterRadarObject;
        static public Action<GameObject> RemoveRadarObject;

        private void OnValidate()
        {
            RegisterRadarObject += Register;
            RemoveRadarObject += Remove;
        }
        private void Awake()
        {

            CenterPos =Resources.Load<GameObject>("RadarReferencePoint").transform;
        }
        public void Register(GameObject o, Image i)
        {
            Image image = Instantiate(i);
            RadObjects.Add(new RadarObject { Owner = o, Icon = image });
        }
        public void Remove(GameObject o)
        {
            List<RadarObject> newList = new List<RadarObject>();
            foreach (RadarObject t in RadObjects)
            {
                if (t.Owner == o)
                {
                    Destroy(t.Icon);
                    continue;
                }
                newList.Add(t);
            }
            RadObjects.RemoveRange(0, RadObjects.Count);
            RadObjects.AddRange(newList);
        }
        private void DrawRadarDots()
        {
                foreach (RadarObject radObject in RadObjects)
                {
                    Vector3 radarPos = (radObject.Owner.transform.position - CenterPos.position)*_mapScale;
                    radObject.Icon.transform.SetParent(transform);
                    radObject.Icon.transform.position = new Vector3(radarPos.x,radarPos.z, 0) + transform.position;
                }
        }
private void Update()
{
    if (Time.frameCount % 2 == 0)
    {
        DrawRadarDots();
                //Debug.Log(RadObjects.Count);
    }
}
}
public sealed class RadarObject
{
    public Image Icon;
    public GameObject Owner;
}
}
