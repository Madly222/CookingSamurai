using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NpcUiController : MonoBehaviour
{
    [SerializeField] private List<Image> foodToClaimImage;
    [SerializeField] private Material dialogBox;

    public void ChangeDialogBox(Sprite newImage)
    {
        dialogBox.mainTexture = newImage.texture;
    }
    
    public void ChangeTextureItem(int id, Sprite sprite)
    {
        foodToClaimImage[id].transform.parent.gameObject.SetActive(true);
        foodToClaimImage[id].sprite = sprite;
        foodToClaimImage[id].color = Color.gray;
    }

    public void DisableBoxes()
    {
        foreach (var t in foodToClaimImage)
            t.transform.parent.gameObject.SetActive(false);
    }

    public void RestartColors()
    {
        foreach (var image in foodToClaimImage)
                image.color = Color.gray;
    }
    
    public void ChangeTextureColor(int id)
    {
        foodToClaimImage[id].color = Color.white;
    }
}
