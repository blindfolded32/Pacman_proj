using System.Collections;
using UnityEngine;


public class CameraController : ICameraController
{
    private readonly ICameraView _cameraView;
    private ICameraModel _cameraModel;
    private float _duration = 0.85f;


    public CameraController(ICameraView cameraView, ICameraModel cameraModel)
    {
        _cameraView = cameraView;
        _cameraModel = cameraModel;
   }

    public void Shake() => Shake(_duration);

    private void Shake(float duration)
    {
        Debug.Log("Shake it");
        Quaternion originalRotation = _cameraView.Camera.transform.localRotation;
        _cameraView.ChildCourutine(ShakingCamera(duration));
        _cameraView.Camera.transform.localRotation = originalRotation;
    }



    IEnumerator ShakingCamera(float duration)
    {
        float timeLeft = Time.time;
        while ((timeLeft + duration) > Time.time)
        {
            Debug.Log("Shake");
            _cameraView.Camera.transform.localRotation = new Quaternion(_cameraView.Camera.transform.localRotation.x, UnityEngine.Random.Range(-0.02f, 0.02f), UnityEngine.Random.Range(-0.02f, 0.02f), 1.0f);
            yield return new WaitForSeconds(0.025f);

        }
    }

    public void OnInit()
    {
       
    }

 
}
