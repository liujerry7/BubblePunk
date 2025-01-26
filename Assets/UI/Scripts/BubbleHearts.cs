using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleHearts : MonoBehaviour
{
    public Image heartPrefab;
    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;

    private List<Image> hearts = new List<Image>();

    public void SetMaxHearts(int maxHearts)
    {
        Debug.Log("set max hearts");
        foreach(Image heart in hearts)
        {
            Destroy(heart.gameObject);

        }

        hearts.Clear();

        for (int i = 0; i < maxHearts; i++) {
            Image newHeart = Instantiate(heartPrefab, transform);
            newHeart.sprite = fullHeartSprite;
            hearts.Add(newHeart);
        } 
    }

    public void UpdateHearts(int health) 
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < health) 
            {
                hearts[i].sprite = fullHeartSprite;
            }
            else
            {
                hearts[i].sprite = emptyHeartSprite;
            }
        }
    }
}
