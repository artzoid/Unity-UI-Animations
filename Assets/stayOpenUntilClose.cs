using UnityEngine;
using UnityEngine.UI;

public class AnimatorParameterSet : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    // Create an array of button configurations
    [System.Serializable]  // This makes the class show up in Inspector
    public class ButtonConfig
    {
        public Button button;
        public string parameterName;
    }
    
    [SerializeField] private ButtonConfig[] buttonConfigs;

    private void Start()
    {
        // Set all parameters to true initially
        foreach (var config in buttonConfigs)
        {
            animator.SetBool(config.parameterName, true);
            
            // Add listeners to each button
            if (config.button != null)
            {
                // Using lambda to pass the parameter name
                config.button.onClick.AddListener(() => OnButtonClick(config.parameterName));
            }
            else
            {
                Debug.LogWarning($"Button reference not set for parameter {config.parameterName}!");
            }
        }
    }

    private void OnButtonClick(string paramName)
    {
        animator.SetBool(paramName, false);
    }

    private void OnDestroy()
    {
        // Clean up all listeners
        foreach (var config in buttonConfigs)
        {
            if (config.button != null)
            {
                config.button.onClick.RemoveListener(() => OnButtonClick(config.parameterName));
            }
        }
    }
}