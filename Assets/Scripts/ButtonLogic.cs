using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    private GameObject optionsmenu;
    private bool optionsBool;

    private void Awake()
    {
        optionsmenu = GameObject.FindGameObjectWithTag("Options");
        if (optionsmenu != null);
    }

    void BPlay()
    {
        //This is where I would change scenes if I had one
    }

    void BOptions()
    {
        if (optionsmenu == false)
        {

        }
    }
}
