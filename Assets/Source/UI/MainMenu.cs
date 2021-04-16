using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.UI
{
    public class MainMenu : Menu
    {
        protected override void HandleOption()
        {
            switch (Selected)
            {
                case 0:
                    SceneManager.LoadScene("Level1");
                    break;
                case 1:
                    Application.Quit();
                    break;
            }
        }
    }
}
