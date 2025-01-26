using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{
    public GameObject tutorial;
    public BubbleWand bubbleWand;
    public GameObject bubblePlatform;
    public int ammo = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammo > 0)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 offset = new Vector3(0, 0, 10);
                GameObject newPlatform = Instantiate(bubblePlatform, pos + offset, Quaternion.identity);
                ammo--;
                bubbleWand.Empty();
                SFXManager.Play("Pop");
                tutorial.SetActive(false);
            }
        }
    }

}
