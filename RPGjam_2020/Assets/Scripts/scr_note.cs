using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_note : MonoBehaviour
{
    public scr_player player_script;
    public GameObject next_button;
    public GameObject back_button;
    public GameObject letter;
    public GameObject list;
    public Text caught;
    public Text caughtNumber;

    // Start is called before the first frame update
    void OnEnable()
    {
        player_script.StartReading();
        DisplayProgress();
    }

    public void KillNote()
    {
        player_script.StopReading();
        gameObject.SetActive(false);
    }

    public void GoToPageTwo()
    {
        next_button.SetActive(false);
        letter.SetActive(false);

        back_button.SetActive(true);
        list.SetActive(true);
    }

    public void GoToPageOne()
    {
        back_button.SetActive(false);
        list.SetActive(false);

        next_button.SetActive(true);
        letter.SetActive(true);
    }

    public void DisplayProgress()
    {
        caught.text = string.Empty;
        caughtNumber.text = string.Empty;

        if (PlayerPrefs.GetInt("Tuna", 0) > 0)
        {
            caught.text += "Caught & Tagged!" + "\n";
            if (PlayerPrefs.GetInt("Tuna", 0) > 1)
            {
                caughtNumber.text += "x" + PlayerPrefs.GetInt("Tuna", 0) + "\n";
            } else
            {
                caughtNumber.text += "\n";
            }
        } else
        {
            caught.text += "\n";
            caughtNumber.text += "\n";
        }

        if (PlayerPrefs.GetInt("Sailfish", 0) > 0)
        {
            caught.text += "Caught & Tagged!" + "\n";
            if (PlayerPrefs.GetInt("Sailfish", 0) > 1)
            {
                caughtNumber.text += "x" + PlayerPrefs.GetInt("Sailfish", 0) + "\n";
            } else
            {
                caughtNumber.text += "\n";
            }
        } else
        {
            caught.text += "\n";
            caughtNumber.text += "\n";
        }

        if (PlayerPrefs.GetInt("Mackerel", 0) > 0)
        {
            caught.text += "Caught & Tagged!" + "\n";
            if (PlayerPrefs.GetInt("Mackerel", 0) > 1)
            {
                caughtNumber.text += "x" + PlayerPrefs.GetInt("Mackerel", 0) + "\n";
            } else
            {
                caughtNumber.text += "\n";
            }
        } else
        {
            caught.text += "\n";
            caughtNumber.text += "\n";
        }

        if (PlayerPrefs.GetInt("Rockfish", 0) > 0)
        {
            caught.text += "Caught & Tagged!" + "\n";
            if (PlayerPrefs.GetInt("Rockfish", 0) > 1)
            {
                caughtNumber.text += "x" + PlayerPrefs.GetInt("Rockfish", 0) + "\n";
            } else
            {
                caughtNumber.text += "\n";
            }
        } else
        {
            caught.text += "\n";
            caughtNumber.text += "\n";
        }

        if (PlayerPrefs.GetInt("Amberjack", 0) > 0)
        {
            caught.text += "Caught & Tagged!" + "\n";
            if (PlayerPrefs.GetInt("Amberjack", 0) > 1)
            {
                caughtNumber.text += "x" + PlayerPrefs.GetInt("Amberjack", 0) + "\n";
            } else
            {
                caughtNumber.text += "\n";
            }
        } else
        {
            caught.text += "\n";
            caughtNumber.text += "\n";
        }

        if (PlayerPrefs.GetInt("Snapper", 0) > 0)
        {
            caught.text += "Caught & Tagged!" + "\n";
            if (PlayerPrefs.GetInt("Snapper", 0) > 1)
            {
                caughtNumber.text += "x" + PlayerPrefs.GetInt("Snapper", 0) + "\n";
            } else
            {
                caughtNumber.text += "\n";
            }
        } else
        {
            caught.text += "\n";
            caughtNumber.text += "\n";
        }

        if (PlayerPrefs.GetInt("Marlin", 0) > 0)
        {
            caught.text += "Caught & Tagged!" + "\n";
            if (PlayerPrefs.GetInt("Marlin", 0) > 1)
            {
                caughtNumber.text += "x" + PlayerPrefs.GetInt("Marlin", 0) + "\n";
            } else
            {
                caughtNumber.text += "\n";
            }
        } else
        {
            caught.text += "\n";
            caughtNumber.text += "\n";
        }

        if (PlayerPrefs.GetInt("Tarpon", 0) > 0)
        {
            caught.text += "Caught & Tagged!" + "\n";
            if (PlayerPrefs.GetInt("Tarpon", 0) > 1)
            {
                caughtNumber.text += "x" + PlayerPrefs.GetInt("Tarpon", 0) + "\n";
            } else
            {
                caughtNumber.text += "\n";
            }
        } else
        {
            caught.text += "\n";
            caughtNumber.text += "\n";
        }

        if (PlayerPrefs.GetInt("Swordfish", 0) > 0)
        {
            caught.text += "Caught & Tagged!" + "\n";
            if (PlayerPrefs.GetInt("Swordfish", 0) > 1)
            {
                caughtNumber.text += "x" + PlayerPrefs.GetInt("Swordfish", 0) + "\n";
            } else
            {
                caughtNumber.text += "\n";
            }
        } else
        {
            caught.text += "\n";
            caughtNumber.text += "\n";
        }

        if (PlayerPrefs.GetInt("MahiMahi", 0) > 0)
        {
            caught.text += "Caught & Tagged!" + "\n";
            if (PlayerPrefs.GetInt("MahiMahi", 0) > 1)
            {
                caughtNumber.text += "x" + PlayerPrefs.GetInt("MahiMahi", 0) + "\n";
            } else
            {
                caughtNumber.text += "\n";
            }
        } else
        {
            caught.text += "\n";
            caughtNumber.text += "\n";
        }

        if (PlayerPrefs.GetInt("Lingcod", 0) > 0)
        {
            caught.text += "Caught & Tagged!" + "\n";
            if (PlayerPrefs.GetInt("Lingcod", 0) > 1)
            {
                caughtNumber.text += "x" + PlayerPrefs.GetInt("Lingcod", 0) + "\n";
            } else
            {
                caughtNumber.text += "\n";
            }
        } else
        {
            caught.text += "\n";
            caughtNumber.text += "\n";
        }

        if (PlayerPrefs.GetInt("Barracuda", 0) > 0)
        {
            caught.text += "Caught & Tagged!" + "\n";
            if (PlayerPrefs.GetInt("Barracuda", 0) > 1)
            {
                caughtNumber.text += "x" + PlayerPrefs.GetInt("Barracuda", 0) + "\n";
            } else
            {
                caughtNumber.text += "\n";
            }
        } else
        {
            caught.text += "\n";
            caughtNumber.text += "\n";
        }

    }
}
