using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleWand : MonoBehaviour
{
    public Sprite fullSprite;
    public Sprite emptySprite;

    public void Fill() {
        gameObject.GetComponent<Image>().sprite = fullSprite;
    }

    public void Empty() {
        gameObject.GetComponent<Image>().sprite = emptySprite;
    }
}
