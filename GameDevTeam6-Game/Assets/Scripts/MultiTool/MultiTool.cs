﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiTool : MonoBehaviour
{
    private ToolModes mode;
    int index;

    private MultiTool multiTool;
    private GameObject wheel;
    private Image topLeft;
    private Image topRight;
    private Image bottomLeft;
    private Image bottomRight;
    private Image currentImage;
    private Image selectedImage;

    private Color32 blue;
    private Color32 darkBlue;
    private Color32 white;


    private void Start() {
        mode = ToolModes.defaultMode;

        multiTool = FindObjectOfType<MultiTool>();
        wheel = GameObject.FindWithTag("wheel");
        topLeft = wheel.transform.Find("TopLeft").GetComponent<Image>();
        topRight = wheel.transform.Find("TopRight").GetComponent<Image>();
        bottomLeft = wheel.transform.Find("BottomLeft").GetComponent<Image>();
        bottomRight = wheel.transform.Find("BottomRight").GetComponent<Image>();

        currentImage = null;
        selectedImage = null;

        blue = new Color32(182, 205, 242, 190);
        darkBlue = new Color32(34, 90, 200, 190);
        white = new Color32(255, 255, 255, 190);
        resetColors();

        wheel.SetActive(false);
    }

    public ToolModes GetMode()
    {
        return mode;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            wheel.SetActive(true);
        }
        else if (Input.GetKeyUp("tab"))
        {
            wheel.SetActive(false);
            if (currentImage == topLeft)
            {
                mode = ToolModes.buildingMode;
            }
            else if (currentImage == topRight)
            {
                mode = ToolModes.farmMode;
            }
            else if (currentImage == bottomLeft)
            {
                mode = ToolModes.combatMode;
                Tutorial.Instance.TriggerDialogue(8);
            }
            else if (currentImage == bottomRight)
            {
                mode = ToolModes.defaultMode;
            }

        }

        if (Input.GetKey(KeyCode.Tab))
        {
            Vector2 viewportPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition);  //convert game object position to VievportPoint

            resetColors();
            if (viewportPoint.x > 0.5f && viewportPoint.y > 0.5f) {
                currentImage = topRight;
            } else if (viewportPoint.x < 0.5f && viewportPoint.y > 0.5f) {
                currentImage = topLeft;
            } else if (viewportPoint.x > 0.5f && viewportPoint.y < 0.5f) {
                currentImage = bottomRight;
            } else if (viewportPoint.x < 0.5f && viewportPoint.y < 0.5f) {
                currentImage = bottomLeft;
            } else {
                currentImage = null;
            }

            if (currentImage != null) {
                currentImage.color = blue;
            }
            if (selectedImage != null)
            {
                selectedImage.color = darkBlue;
            }
            if (Input.GetMouseButtonDown(0))
            {
                selectedImage = currentImage;
            }
        }
    }

    private void resetColors()
    {
        topLeft.color = white;
        topRight.color = white;
        bottomLeft.color = white;
        bottomRight.color = white;
        if (selectedImage != null)
        {
            selectedImage.color = darkBlue;
        }
    }
}

public enum ToolModes
{
    defaultMode,
    buildingMode,
    farmMode,
    combatMode
}