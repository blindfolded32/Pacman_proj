using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// DZ MVC
    /// </summary>
    public sealed class MiniMap : MonoBehaviour
    {
        private Transform _player;
        private void Start()
        {
            var main = Camera.main;
            _player = main.transform;
            transform.parent = null;
            transform.rotation = Quaternion.Euler(90.0f, 0, 0);
            transform.position = _player.position + new Vector3(0, 5.0f, 0);

            var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");

            var component = GetComponent<Camera>();
            component.targetTexture = rt;
            component.depth = -5;
        }

        private void LateUpdate()
        {
            var newPosition = _player.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            transform.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
        }
    }

    #region MVC

    internal class MiniMapController //: ILateExecute
    {
        private readonly Transform _owner;
        private readonly Transform _target;

        public MiniMapController(Transform owner, Transform target)
        {
            _owner = owner;
            _target = target;
        }
        
        public void LateExecute()
        {
            var newPosition = _target.position;
            newPosition.y = _owner.position.y;
            _owner.position = newPosition;
            _owner.rotation = Quaternion.Euler(90, _target.eulerAngles.y, 0);
        }
    }

    internal class MiniMapInitialize// : IInitialization
    {
        private readonly Transform _owner;
        private readonly Transform _target;

        public MiniMapInitialize(Transform owner, Transform target)
        {
            _owner = owner;
            _target = target;
        }

        public void Initialization()
        {
            var main = Camera.main;
            _owner.parent = null;
            _owner.rotation = Quaternion.Euler(90.0f, 0, 0);
            _owner.position = _target.position + new Vector3(0, 5.0f, 0);

            var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");

            var component = _owner.GetComponent<Camera>();
            component.targetTexture = rt;
            component.depth = -5;
        }
    }

    #endregion

}