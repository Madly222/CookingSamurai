using System.Collections;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject itemDropper;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private Updating updating;
    
    [SerializeField] private GameObject lButton;
    [SerializeField] private GameObject rButton;

    public void OnButtonClick(bool isActive)
    {
        //ButtonSwitch(isActive);
    }

    private void ButtonSwitch(bool isActive)
    {
        lButton.SetActive(false);
        itemDropper.SetActive(false);
        updating.canSlice = false;
        rButton.SetActive(false);
        
        StartCoroutine(WaitRotate(cameraController.RotateCamera(isActive), isActive));
    }
    
    private IEnumerator WaitRotate(float timeCd, bool isActive)
    {
        yield return new WaitForSeconds(timeCd);
        lButton.SetActive(isActive);
        itemDropper.SetActive(isActive);
        updating.canSlice = isActive;
        rButton.SetActive(!isActive);
    }
    
}
