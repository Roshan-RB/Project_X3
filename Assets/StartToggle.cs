using UnityEngine;
using UnityEngine.UI;

public class StartToggle : MonoBehaviour
{
    public Gamelogic3 gameLogic; // Reference to the Gamelogic3 script
    public Toggle togglebutton;

    private void Start()
    {
        togglebutton = GetComponent<Toggle>();
        togglebutton.onValueChanged.AddListener(OnToggleValueChanged);
        //Debug.Log("toggle script started...");
    }

    private void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            //Debug.Log("toggle clicked");
            gameLogic.StartGame(); // Start the game when the Toggle is turned on
            //Debug.Log("StarGame called!!");

        }
    }
}
