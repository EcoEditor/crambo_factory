using System;
using UnityEngine;


namespace CremboFactory
{
    public class CremboWrapperController : MonoBehaviour
    {
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

    public int wrapped_crambo_count = 0;
    public int crambo_missed_count = 0;

    public GameObject wrapped_crambo;
    public GameObject exploed_crambo;
    public Animator crambo_wrap;
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
                if (_endTime - _startTime < wrappingDuration)
                {
                    
                }
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
		if (!Input.GetMouseButton(0)){
            crambo_wrap.speed = 0f;
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
                crambo_wrap.speed = 1f;
                sum_move += move;
            }

		}
	else if(Input.GetAxis("Mouse X")>0 && Input.GetMouseButton(0))
		{
            move = Mathf.Abs(Input.GetAxis("Mouse X")  * speed);
			Crambo.transform.Rotate(0, 0, move);
            if(move>max_move)
            {
                crambo_creashed();

            }
            else{
                crambo_wrap.speed = 1f;
                sum_move += move;

            }
            
		}
    else if(sum_move>wrapped_threashold){
        
        wrapped_crambo_count += 1;
        wrapped_crambo.SetActive(false);
    }
		else  
		{
            crambo_wrap.speed = 0f;
			var rotation = Quaternion.LookRotation(target.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
			print("boat straightening out");
			
		}
		
	}

    private void crambo_creashed()
    {
        crambo_missed_count += 1;
        wrapped_crambo.SetActive(false);
        exploed_crambo.SetActive(true);
    }

        
    }
}
