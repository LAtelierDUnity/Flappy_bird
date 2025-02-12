using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void PlayGame()
    {
        SoundManager.instance.PlayLoadSoundScene();
        SceneManager.LoadScene(1);
    }

    public void RateGame()
    {

    }

    public void ShowLeaderBoard()
    {

    }

}
