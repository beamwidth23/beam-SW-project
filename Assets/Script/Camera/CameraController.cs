using UnityEngine;

public class CameraController : MonoBehaviour
{
   [SerializeField]
   private StageData stageData;

   private void LateUpdate()
   {
        Vector3 position = transform.position;

        position.x = Mathf.Clamp(position.x, stageData.CameraLimitMin.x,
            stageData.CameraLimitMax.x);
<<<<<<< HEAD
        position.y = Mathf.Clamp(position.y, stageData.CameraLimitMin.y,
=======
        position.y = Mathf.Clamp(position.y, stageData.cameraLimitMin.y,
>>>>>>> 9a96f984d014df9fb86685c45e00ebf704c98260
            stageData.CameraLimitMax.y);

        transform.position = position;
   }
}
