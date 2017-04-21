using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class editImage : MonoBehaviour
{

    public Texture2D original;

    private float horizontalSpeed = 10.0F;
    private float verticalSpeed = 10.0F;

    private bool isMove = false;
    private bool isHover = false;

    private int x, y, s;
    public GameObject Main;
    public GameObject Browser;
    // Use this for initialization
    void Start()
    {
        Renew();
    }


    public void Hover(bool b)
    {
        isHover = b;
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isMove = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMove = false;
        }
        

        if (isMove && isHover)
        {

            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");

            if (inBorder(h, v))
            {

                transform.localPosition = new Vector2(transform.localPosition.x + h, transform.localPosition.y + v);
                x = (int)transform.localPosition.x - s / 2 + original.width / 2;
                y = (int)transform.localPosition.y - s / 2 + original.height / 2;
            }
        }

    }

    private bool inBorder(float h, float v)
    {

        if (
                ((transform.localPosition.x + original.width / 2 + h) > s / 2) &&
                ((transform.localPosition.x + s / 2 + h) < original.width / 2) &&

                ((transform.localPosition.y + original.height / 2 + v) > s / 2) &&
                ((transform.localPosition.y + s / 2 + v) < original.height / 2)

            )
            return true;
        else
            return false;

    }

    public void Crop()
    {
        
        Texture2D tex = original;

        x = (int)transform.localPosition.x - s / 2 + original.width / 2;
        y = (int)transform.localPosition.y - s / 2 + original.height / 2;

        Texture2D result = new Texture2D(s, s);
        Color[] colors = tex.GetPixels(x, y, s, s);
        result.SetPixels(colors);
        result.Apply();

        TextureScale.Bilinear(result, 256, 256);

        GameObject.Find("ImageMaker").SetActive(false);
        Main.SetActive(true);

        //GameObject.Find("Crop").GetComponent<editImage>().original = avatarImage;

        GameObject.Find("Avatar").GetComponent<Image>().sprite = Sprite.Create(result, new Rect(0.0f, 0.0f, 256, 256), new Vector2(0.5f, 0.5f), 100.0f);


    }

    public void Plus()
    {

        if (inBorder(5, 5))
        {
            s += 5;
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2(s, s);
        }

    }

    public void Minus()
    {
        if (s > 50)
        {
            s -= 5;
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2(s, s);
        }

    }

    internal void Renew()
    {
        transform.localPosition = new Vector2(0, 0);
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(256, 256);

        s = (int)transform.GetComponent<RectTransform>().rect.height;
        x = (int)transform.localPosition.x - s / 2 + original.width / 2;
        y = (int)transform.localPosition.y - s / 2 + original.height / 2;
    }
}
