using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_UI_manager : MonoBehaviour
{
    public Text Distance;
    public Slider Tension;

    public Text FishName;
    public Text FishRarity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateUI(scr_fish fish)
    {
        Distance.text = fish.dist.ToString() + "m";
        Tension.value = fish.tens;
    }

    public void revealFish(scr_fish fish)
    {
        FishName.text = fish.fishName;
        FishRarity.text = fish.fishRarity;
    }

}
