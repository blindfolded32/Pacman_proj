using UnityEngine;

public class MiniMapController : IMiniMapController
    {
        private readonly Transform _owner;
        private readonly Transform _target;

        private IMinimapModel _minimapModel;
        private IMinimapView _minimapView;
        public MiniMapController(Transform owner, Transform target, IMinimapModel minimapModel, IMinimapView minimapView)
        {
            _owner = owner;
            _target = target;
            _minimapModel = minimapModel;
           _minimapView = minimapView;
        }
        
        public void OnLateExecute()
        {
            var newPosition = _target.position;
            newPosition.y = _owner.position.y;
            _owner.position = newPosition;
            _owner.rotation = Quaternion.Euler(90, _target.eulerAngles.y, 0);
        }
    }
