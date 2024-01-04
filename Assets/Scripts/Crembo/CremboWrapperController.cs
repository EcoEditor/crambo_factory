using System;
using UnityEngine;


namespace CremboFactory
{
    public class CremboWrapperController : MonoBehaviour
    {
        [SerializeField] private GameModel model;
        [SerializeField] private float wrappingSpeedThreshold = 30f;
        [SerializeField] private float wrappingDuration = 10f;

        private float _startTime;
        private float _endTime;
	public GameObject Crambo;
	private Vector3 direction = Vector3.forward;
    public float damping = 2f;
    public float speed;
	public Transform target;
    private float move = 0f;
    private float sum_move = 0f;
    public float wrapped_threashold = 150f;
    public float max_move = 1.2f;

    public float initializeDelay = 10f;

    public int wrapped_crambo_count = 0;
    public int crambo_missed_count = 0;

    public GameObject wrapped_crambo;
    public GameObject exploed_crambo;
    public Animator crambo_wrap_anim;
    public Animator crambo_exploed_anim;
    public float timeRemaining = 30f;

        private void Awake()
        {
            MessagingSystem.CremboWrapStarted += OnCremboWrapStarted;
            MessagingSystem.RotationSpeed += OnRotationSpeed;
        }

        private void OnDestroy()
        {
            MessagingSystem.RotationSpeed -= OnRotationSpeed;
        }

        private void OnCremboWrapStarted(bool didStart)
        {
            if (didStart)
            {
                _startTime = Time.time;
            } else
            {
                _endTime = Time.time;
            }
        }

        private void OnRotationSpeed(float rotationSpeed)
        {
        Debug.Log(rotationSpeed);

		Vector3 velocity = rotationSpeed * direction;
		Crambo.GetComponent<Rigidbody>().velocity = velocity;
            if (rotationSpeed > wrappingSpeedThreshold)
            {
                Debug.Log("Rotation is TOO FAST! FAILED");
                MessagingSystem.FailedCremboWrapping?.Invoke();
            }
        }

        void Update () {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            if (timeRemaining < 1)
            {
                crambo_creashed();
            }

		    if (!Input.GetMouseButton(0)){
                crambo_wrap_anim.speed = 0f;
            }
		    if(Input.GetAxis("Mouse X")<0 && Input.GetMouseButton(0))
		    {
                move = Mathf.Abs(Input.GetAxis("Mouse X")  * speed);
			    Crambo.transform.Rotate(0, 0, -move );
                if(move>max_move)
                {
                    crambo_creashed();
                }
                else{
                    crambo_wrap_anim.speed = 3f;
                    sum_move += move;
                    Debug.Log($"sum move is {sum_move}");
                }
		    }
	        else if(Input.GetAxis("Mouse X")>0 && Input.GetMouseButton(0))
		    {
                move = Mathf.Abs(Input.GetAxis("Mouse X")  * speed);
			    Crambo.transform.Rotate(0, 0, move);
                if(move>max_move)
                {
                    print("DID CRASH");
                    crambo_creashed();

                }
                else{
                    crambo_wrap_anim.speed = 3f;
                    sum_move += move;
                    Debug.Log($"sum move is {sum_move}");
                }
		    }
            else if(sum_move>wrapped_threashold){
                crambo_wrapped();
            }
		    else  
		    {
                crambo_wrap_anim.speed = 0f;
			    var rotation = Quaternion.LookRotation(target.position - transform.position);
			    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
		    }
	    }

    private void crambo_wrapped()
    {
        if(wrapped_crambo.activeSelf)
        {
            model.IncreaseWrappedCrembo();
            wrapped_crambo.SetActive(false);
            Invoke(nameof(inital_crambo), initializeDelay);
        }
        
    }
    private void crambo_creashed()
    {
        if(wrapped_crambo.activeSelf)
        {
            model.IncreaseMissedCrembo();
            wrapped_crambo.SetActive(false);
            exploed_crambo.SetActive(true);
            Invoke(nameof(inital_crambo), initializeDelay);
        }
        
    }

    private void inital_crambo()
    {
        if(wrapped_crambo.activeSelf == false)
        {
            exploed_crambo.SetActive(false);
            wrapped_crambo.SetActive(true);
            crambo_wrap_anim.Update(0f);
            crambo_exploed_anim.Update(0f);
            timeRemaining = 30f;
            sum_move = 0f;
            Crambo.transform.rotation = Quaternion.identity;

        }
        
    }
        
    }
}
