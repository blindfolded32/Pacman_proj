using System.IO;
using UnityEngine;

public class JsonActions<T> : IActionInterface<T>
{
    public void Save(T data, string path = null)
    {
        File.WriteAllText(path, JsonUtility.ToJson(data));
        Debug.Log(data);
    }

    public T Load(string path = null) => JsonUtility.FromJson<T>(File.ReadAllText(path));
}
