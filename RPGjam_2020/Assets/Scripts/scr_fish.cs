using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_fish : MonoBehaviour
{
    public string fishName;
    public string fishRarity;
    public string prefName;

    public SpriteRenderer darkened;
    public Sprite shown;

    public int dist;
    public int maxDist;

    public int energy;
    public int maxEnergy;

    public int tens;

    public bool escaped;
    public bool caught;
    public bool broke;
    public bool freed;


    public void GetReeled()
    {
        dist = dist - Random.Range(7,25);
        tens = tens + Random.Range(6,12);

        CheckEnd();
    }

    public void LetOut()
    {
        dist = dist + Random.Range(2,7);
        tens = tens - Random.Range(10,30);

        CheckEnd();
    }

    public bool SwimAway()
    {
        if (energy > 3)
        {
            energy = energy - 3;
            tens = tens + Random.Range(2,10);
            dist = dist + Random.Range(3,8);

            CheckEnd();
            return true;
        } else
        {
            energy = energy + Random.Range(1,3);
            tens = tens - Random.Range(2,8);

            CheckEnd();
            return false;
        }
    }

    public bool DiveDeep()
    {
        if (energy > 4)
        {
            energy = energy - 4;
            tens = tens + Random.Range(10, 20);
            dist = dist + Random.Range(1, 4);

            CheckEnd();
            return true;
        }
        else
        {
            energy = energy + Random.Range(1, 3);
            tens = tens - Random.Range(2, 8);

            CheckEnd();
            return false;
        }
    }

    public bool JukeSide()
    {
        if (energy > 4)
        {
            energy = energy - 4;
            tens = tens - Random.Range(15, 25);
            dist = dist - Random.Range(2, 6);

            CheckEnd();
            return true;
        }
        else
        {
            energy = energy + Random.Range(1, 3);
            tens = tens - Random.Range(2, 8);

            CheckEnd();
            return false;
        }
    }

    void CheckEnd()
    {
        if (dist < 1)
        {
            caught = true;
        }

        if (tens > 95)
        {
            escaped = true;
            broke = true;
        }

        if (tens < 5)
        {
            freed = true;
            escaped = true;
        }
    }

    public void FishCaught()
    {
        PlayerPrefs.SetInt(prefName, PlayerPrefs.GetInt(prefName, 0) + 1);
    }
}
