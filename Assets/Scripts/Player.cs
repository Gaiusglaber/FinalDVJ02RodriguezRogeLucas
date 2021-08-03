using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDestructible
{
    public delegate void OnDestroyed();
    public event OnDestroyed OnPlayerDestroyed;
    public delegate void Following();
    public event Following OnFollowingPlayer;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    public GameObject explotionPrefab;

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    [SerializeField]public Vector3 Spawnpoint;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private Rigidbody playerspeed;
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;
    private void Start()
    {
        Spawnpoint = transform.position;
    }
    private void FixedUpdate()
    {
        if (GameManager.GetInstance() != null && !GameManager.GetInstance().pause)
        {
            GetInput();
            HandleMotor();
            HandleSteering();
        }
        else
        {
            playerspeed.velocity = new Vector3(0,0,0);
        }
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }
    // Update is called once per frame
    void Update()
    {
        if ((this.transform.rotation.x >0.9f || this.transform.rotation.x < -0.9f))
            Destroy(gameObject);
        OnFollowingPlayer?.Invoke();
    }
    void OnDisable()
    {
        SceneManagment.GetInstance().distance = transform.position.x+ transform.position.z;
        Destroy();
        OnPlayerDestroyed?.Invoke();
    } 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bomb"))
        {
            Destroy(gameObject);
        }
    }
    public void Destroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        Instantiate(explotionPrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
    }
}
