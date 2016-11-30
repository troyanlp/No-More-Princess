using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    public int number;
    public int actualLevel = 1;
    public int maxLevel = 1;
    public int numHearts = 3;
    public int hp = 6;
    public int typeSword = 1;
    public int arrows = 7;
    public bool hasPotion = true;
    public GameObject pj;
    public bool isPaused = false;
    public bool isVideogame = false;
    public bool isVideo = false;
    public bool final = false;

    // Static singleton instance
    private static Singleton instance;


    // Static singleton property
    public static Singleton Instance
    {
        // Here we use the ?? operator, to return 'instance' if 'instance' does not equal null
        // otherwise we assign instance to a new component and return that
        get { return instance ?? (instance = new GameObject("Singleton").AddComponent<Singleton>()); }
    }

    // Instance method, this method can be accesed through the singleton instance
    public void DoSomeAwesomeStuff()
    {
        Debug.Log("I'm doing awesome stuff");
    }


    public void save()
    {
        Birgin_Controller pj = GameObject.FindGameObjectWithTag("Player").GetComponent<Birgin_Controller>();

        PlayerPrefs.SetInt("actualLevel", actualLevel);
        PlayerPrefs.SetInt("maxLevel", maxLevel);
        PlayerPrefs.SetInt("hp", pj.hp);
        PlayerPrefs.SetInt("numHearts", pj.numCors);
        PlayerPrefs.SetInt("ammo", pj.ammo);
        if (pj.hasPotion)
        {
            PlayerPrefs.SetInt("hasPotion", 1);
        }
        else
        {
            PlayerPrefs.SetInt("hasPotion", 0);
        }
        
        PlayerPrefs.Save();
    }

    public void load()
    {
        Birgin_Controller pj = GameObject.FindGameObjectWithTag("Player").GetComponent<Birgin_Controller>();

        //Cursor.visible = false;
        actualLevel = PlayerPrefs.GetInt("actualLevel");
        maxLevel = PlayerPrefs.GetInt("maxLevel");
        pj.hp = PlayerPrefs.GetInt("hp");
        pj.numCors = PlayerPrefs.GetInt("numHearts");
        pj.ammo = PlayerPrefs.GetInt("ammo");
        if (PlayerPrefs.GetInt("hasPotion") == 1)
        {
            pj.hasPotion = true;
        }
        else
        {
            pj.hasPotion = false;
        }


        //

    }

    public void setActualLevel(int lvl) {
        actualLevel = lvl;
        PlayerPrefs.SetInt("actualLevel", actualLevel);
        PlayerPrefs.Save();
    }

    public void setZeroLevel()
    {
        actualLevel = 0;
    }

    public void setNewGame()
    {
        actualLevel = 1;
        maxLevel = 1;
        //Poner valores por defecto
        PlayerPrefs.SetInt("actualLevel", actualLevel);
        PlayerPrefs.SetInt("maxLevel", maxLevel);
        PlayerPrefs.SetInt("hp", 6);
        PlayerPrefs.SetInt("numHearts", 3);
        PlayerPrefs.SetInt("ammo", 7);
        PlayerPrefs.SetInt("hasPotion", 0);
        PlayerPrefs.Save();
    }

    public void nextLevel()
    {
        switch (actualLevel)
        {
            case 1:
                if (maxLevel == 1)
                {
                    maxLevel = 2;
                }
                actualLevel = 2;
                SceneManager.LoadScene("Level 2");
                
            break;
            case 2:
                if (maxLevel == 2)
                {
                    maxLevel = 3;
                }
                actualLevel = 3;
                SceneManager.LoadScene("Level 3");
                break;
        }
        save();
    }

    public int getUnlockedLevel()
    {
        return maxLevel;
    }

    public int getActualLevel()
    {
        return actualLevel;
    }

    public void print()
    {
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            Debug.Log("INFORMACIÓN!");
            Debug.Log("------------");
            Debug.Log("actualLevel = " + actualLevel);
            Debug.Log("maxLevel = " + maxLevel);
            Debug.Log("hp = " + hp);


        }
    }

}
