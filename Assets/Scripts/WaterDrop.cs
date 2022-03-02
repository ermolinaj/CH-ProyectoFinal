using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    [SerializeField] float timeLeft = 2;
    [SerializeField] int speed = 3;
    [SerializeField] float fallingSpeed; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            transform.Translate(transform.TransformDirection(new Vector3(0, -1 * fallingSpeed, 1) * speed * Time.deltaTime));
        }
        else
            Destroy(gameObject);
            
    }

    void LateUpdate() 
    {
        
    }
}
