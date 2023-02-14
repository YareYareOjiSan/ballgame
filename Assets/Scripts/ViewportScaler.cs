using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Camera))]
public class ViewportScaler : MonoBehaviour
{
    private Camera _camera;

    [Tooltip("Set the target aspect ratio.")]
    [SerializeField] private float _targetAspectRatio;

    private void Awake()
    {
        _camera = GetComponent<Camera>();

        if (Application.isPlaying)
            ScaleViewport();
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (_camera)
            ScaleViewport();
#endif
    }

    private void ScaleViewport()
    {
        // game window aspect ratio
        var windowaspect = Screen.width / (float)Screen.height;

       
        var scaleheight = windowaspect / _targetAspectRatio;

        if (scaleheight < 1)
        {
            var rect = _camera.rect;

            rect.width = 1;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1 - scaleheight) / 2;

            _camera.rect = rect;
        }
        else 
        {
            var scalewidth = 1 / scaleheight;

            var rect = _camera.rect;

            rect.width = scalewidth;
            rect.height = 1;
            rect.x = (1 - scalewidth) / 2;
            rect.y = 0;

            _camera.rect = rect;
        }
    }

}


//The script has a reference to a camera game object and a "targetAspectRatio" value.
//In the "Update" method, the script checks if the game is being run in the Unity editor
//(this check is surrounded by "#if UNITY_EDITOR" and "#endif" preprocessor directives).
//If the game is being run in the editor, the script calls the "ScaleViewport" method. The "ScaleViewport"
//method first gets the aspect ratio of the game window (the width of the window divided by the height of the window).
//Then it calculates the scale height of the viewport based on the "targetAspectRatio" value and the window aspect ratio. If the scale height is less than 1,
//the script scales the height of the viewport to the scale height and centers the viewport within the game window. If the scale height is greater than or equal to 1,
//the script scales the width of the viewport to the inverse of the scale height and centers the viewport within the game window.



