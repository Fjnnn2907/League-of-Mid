using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    public float rotationSpeed = 10f; // Tốc độ xoay của Skybox
    public Light lightSource; // Đèn ánh sáng (gán trong Inspector)
    public float minIntensity = 0.25f; // Cường độ ánh sáng tối thiểu
    public float maxIntensity = 1f; // Cường độ ánh sáng tối đa
    public float intensityChangeSpeed = 0.5f; // Tốc độ thay đổi cường độ ánh sáng

    private bool increasing = true; // Điều kiện kiểm tra tăng/giảm ánh sáng

    void Update()
    {
        // Xoay Skybox dựa trên thời gian
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);

        // Thay đổi cường độ ánh sáng
        Day();
    }

    public void Day()
    {
        if (lightSource == null)
        {
            Debug.LogError("Light source chưa được gán!");
            return;
        }

        if (increasing)
        {
            lightSource.intensity += Time.deltaTime * intensityChangeSpeed;
            if (lightSource.intensity >= maxIntensity)
            {
                increasing = false; // Đổi sang giảm
            }
        }
        else
        {
            lightSource.intensity -= Time.deltaTime * intensityChangeSpeed;
            if (lightSource.intensity <= minIntensity)
            {
                increasing = true; // Đổi sang tăng
            }
        }
    }
}
