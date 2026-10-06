using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject{
    [SerializeField]
    private Vector2 cameraLimitMin;
    [SerializeField]
    private Vector2 cameraLimitMax;

    [SerializeField]
    private Vector3 cameraStarPoint;
    [SerializeField]
    private Vector2 playerStartPoint;

    public Vector2 CameraLimitMin => cameraLimitMin;
    public Vector2 CameraLimitMax => cameraLimitMax;
    public Vector3 CameraStarPoint => cameraStarPoint;
    public Vector2 PlayerStartPoint => playerStartPoint;
}
