using System.Threading;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Code.Editor
{
    public class LoadingBeh
    {
        public sealed class TestEditorBehaviour : MonoBehaviour
        {
            public float Count = 42;
            public int Step = 2;
            private void Start()
            {
#if UNITY_EDITOR
                for (var i = 0; i < Count; i++)
                {
                    EditorUtility.DisplayProgressBar("Loading", $" % {i}",
                        i / Count);
                    Thread.Sleep(Step * 100);
                }
                EditorUtility.ClearProgressBar();
                var isPressed = EditorUtility.DisplayDialog("Choose your desteny", @"What pill? ", "Red", "Blue");
                if (isPressed)
                {
                    EditorApplication.isPaused = true;
                }
#endif
            }
        }
    }
}