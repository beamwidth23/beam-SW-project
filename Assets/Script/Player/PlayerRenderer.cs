using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    [SerializeField]
    private Transform playerModel;

    [SerializeField]
    private ParticleSystem footStepEffect;
    private ParticleSystem.EmissionModule footEmission;
    private Animator animator;

    private void Awake()
    {
        footEmission = footStepEffect.emission;
        animator = GetComponent<Animator>();
    
    }

    public void OnMovement(float speed)
    {
        animator.SetFloat("moveSpeed", speed);
    }

    public void SpriteFlipX(float x)
    {
        Vector3 currenScale = playerModel.localScale;
        currenScale.x = x < 0 ? -1.5f : 1.5f;
        playerModel.localScale = currenScale;
    
    }
    public void OnFootStepEffect(bool isMoved)
    {
        footEmission.rateOverTime = isMoved == true ? 20 : 0;
    }
}
