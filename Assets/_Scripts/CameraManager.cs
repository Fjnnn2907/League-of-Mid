using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public Camera cam;
    public int speedMoveCam;
    protected bool useVirtualCamera = true;

    public float zoomSpeed = 20f; // Tốc độ zoom
    public float minFOV = 20f;   // FOV nhỏ nhất
    public float maxFOV = 65f;   // FOV lớn nhất

    private void Update()
    {
        this.Cam();
    }
    protected void Cam()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            useVirtualCamera = !useVirtualCamera;
            if (useVirtualCamera)
            {
                virtualCamera.gameObject.SetActive(true);
            }
            else
            {
                virtualCamera.gameObject.SetActive(false);
                cam.gameObject.SetActive(true);
            }
        }

        if (!useVirtualCamera)
        {
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;

            if (x < 10)
                cam.transform.position -= Vector3.right * Time.deltaTime * speedMoveCam;
            else if (x > Screen.width - 10)
                cam.transform.position -= Vector3.left * Time.deltaTime * speedMoveCam;

            if (y < 10)
                cam.transform.position -= Vector3.forward * Time.deltaTime * speedMoveCam;
            else if (y > Screen.height - 10)
                cam.transform.position -= Vector3.back * Time.deltaTime * speedMoveCam;
        }

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            cam.fieldOfView -= scrollInput * zoomSpeed;
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);

            virtualCamera.m_Lens.FieldOfView -= scrollInput * zoomSpeed;
            virtualCamera.m_Lens.FieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
        }
    }
}
