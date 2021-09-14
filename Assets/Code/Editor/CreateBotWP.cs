using System;
using UnityEngine;
namespace Code.Editor
{
   
        public sealed class CreateBotWP : MonoBehaviour
        {
            [SerializeField] private GameObject _prefab;
            private DrawPath _rootWayPoint;

            public void InstantiateObj(Vector3 pos)
            {
                if (!_rootWayPoint)
                {
                    _rootWayPoint = new GameObject("WayPoint").AddComponent<DrawPath>();
                }

                if (_prefab != null)
                {
                    Instantiate(_prefab, pos, Quaternion.identity, _rootWayPoint.transform);
                }
                else
                {
                    throw new Exception($"No {typeof(CreateBotWP)} on {gameObject.name}");
                }
            }
        }
}
