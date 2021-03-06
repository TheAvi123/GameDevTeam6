﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    public Sprite plantImg2;
    public Sprite plantImg3;
    public Sprite plantImg4;
    public Sprite plantImg5;

    private int stages;
    private string species;
    private bool[] arrFruits = new bool[5];
    private int countFruits;

    void Start()
    {
        /* SpriteRenderer renderer = GetComponent<SpriteRenderer>();
         Sprite plantImage = renderer.sprite;*/
        //plantBehav.planting("species1");
    }

    public Plants(string species)
    {
        this.species = species;
        stages = 1;
        countFruits = 0;
        bool[] arrFruits = new bool[] { false, false, false, false, false }; //set max fruit per plant to be 5 (subject to change)
    }

    public int getStages()
    {
        return stages;
    }

    public void setStages(int st)
    {
        stages = st;

        switch(stages)
        {
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = plantImg2;
                break;
            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = plantImg3;
                break;
            case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = plantImg4;
                break;
            case 5:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = plantImg5;
                break;
            default:
                break;
        }
    }

    public void setArrFruits(int index, bool exists)
    {
        arrFruits[index] = exists;
    }

    public int getCountFruits()
    {
        return countFruits;
    }

    public void setCountFruits(int countFruits)
    {
        this.countFruits = countFruits;
    }


 }
