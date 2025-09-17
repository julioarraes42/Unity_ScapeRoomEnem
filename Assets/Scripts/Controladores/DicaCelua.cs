using UnityEngine;

public class DicaCelua : MonoBehaviour
{
    public GameObject[] banners;
    public Camera mainCamera;

    private void Update()
    {
        // Os banners sempre olham para a câmera principal
        foreach (var banner in banners)
        {
            banner.transform.LookAt(mainCamera.transform);
        }
    }

}
