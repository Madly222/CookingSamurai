using UnityEngine;

public class InputUtils : MonoBehaviour
{
    public static Vector3 ScreenToWorld(Camera camera, Vector3 position)
    {
        position.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(position);
        //return  camera.ScreenToWorldPoint(new Vector3(position.x, position.y, camera.nearClipPlane));
    }
}
