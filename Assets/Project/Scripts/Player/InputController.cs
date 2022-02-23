using UnityEngine;

public class InputController : MonoBehaviour
{
    public float VerticalInput 
    {
        get
        {
            #if UNITY_EDITOR || UNITY_STANDALONE
            return ProcessKeyboardInput();
            #else 
            return ProcessGameButtonsInput();
            #endif
        } 
    }

    [SerializeField] private GameButton _moveUpButton;
    [SerializeField] private GameButton _moveDownButton;

    private float ProcessKeyboardInput()
    {
        return Input.GetAxisRaw("Vertical");
    }

    private float ProcessGameButtonsInput()
    {
        float input = 0;
        if(_moveUpButton.IsHolding == _moveDownButton.IsHolding) input = 0;
        else if(_moveUpButton.IsHolding) input = 1;
        else input = -1;
        return input;
    }
}
