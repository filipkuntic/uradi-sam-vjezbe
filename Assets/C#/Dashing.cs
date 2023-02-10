using UnityEngine;

public class Dashing : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    private Rigidbody rb;
    private PlayerMovement pm;

    [Header("Dashing")]
    public float dashForce;
    public float dashUpForce;
    public float dashDuration;

    [Header("Cooldown")]
    public float dashDelay;
    private float dashTimer;

    [Header("Input")]
    public KeyCode dashKey = KeyCode.LeftShift;

    bool canDash = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(pm.view.IsMine)
        {
            if (Input.GetKeyDown(dashKey) && pm.state == PlayerMovement.MovementState.air && canDash)
                Dash();

            if (dashTimer > 0)
                dashTimer -= Time.deltaTime;

            if (pm.isGrounded || pm.wallRunning)
                canDash = true;
        }
    }

    private void Dash()
    {
        if (dashTimer > 0 || pm.isGrounded) return;
        else dashTimer = dashDelay;

        pm.isDashing = true;
        canDash = false;
        Vector3 force = orientation.forward * dashForce + orientation.up * dashUpForce;
        pm.DoFov(64f);
        delayedForceToApply = force;
        Invoke(nameof(DelayedDashForce), .025f);

        Invoke(nameof(ResetDash), dashDuration);
    }

    Vector3 delayedForceToApply;
    void DelayedDashForce()
    {
        rb.velocity = new(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(delayedForceToApply, ForceMode.Impulse);
    }

    void ResetDash()
    {
        pm.DoFov(60f);
        pm.isDashing = false;
    }
}