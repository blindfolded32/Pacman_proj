using UnityEditor;
using UnityEngine;
namespace Code.Editor
{
    public class TestEditorWindow : EditorWindow
    {
        public static GameObject ObjectInstantiate;
        public string _nameObject = "HW Editor Only";
        public bool _groupEnabled;
        public bool _randomColor = true;
        public int _countObject = 1;
        public float _radius = 10;

        private void OnGUI()
        {
            GUILayout.Label("Config", EditorStyles.boldLabel);
            ObjectInstantiate =
               EditorGUILayout.ObjectField("What to paste",
                     ObjectInstantiate, typeof(GameObject), true)
                  as GameObject;
            _nameObject = EditorGUILayout.TextField("Object name", _nameObject);
            _groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки",
               _groupEnabled);
            _randomColor = EditorGUILayout.Toggle("randomize colour", _randomColor);
            _countObject = EditorGUILayout.IntSlider("Count",
               _countObject, 1, 100);
            _radius = EditorGUILayout.Slider("Radius of placement", _radius, 10, 50);
            EditorGUILayout.EndToggleGroup();
            var button = GUILayout.Button("Create");
            if (button)
            {
                if (ObjectInstantiate)
                {
                    GameObject root = new GameObject("Dirty Objects");
                    for (int i = 0; i < _countObject; i++)
                    {
                        float angle = i * Mathf.PI * 2 / _countObject;
                        Vector3 pos = new Vector3(Mathf.Cos(angle), 0,
                                         Mathf.Sin(angle)) * _radius;
                        GameObject temp = Instantiate(ObjectInstantiate, pos,
                           Quaternion.identity);
                        temp.name = _nameObject + "(" + i + ")";
                        temp.transform.parent = root.transform;
                        var tempRenderer = temp.GetComponent<Renderer>();
                        if (tempRenderer && _randomColor)
                        {
                            tempRenderer.material.color = Random.ColorHSV();
                        }
                    }
                }
            }
        }
    }
}