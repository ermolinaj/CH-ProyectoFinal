
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float cameraSensibility;
    [SerializeField] GameObject waterDropType;

    private CharacterController cc;
    [SerializeField] private Transform cameraFollowTarget;

    // Start is called before the first frame update
    void Start()
    {
        if (movementSpeed == 0)
            Debug.Log("Player Speed is set to 0, you will not perceive movement");

        cc = GetComponent<CharacterController>();
        cameraFollowTarget = this.transform.GetChild(0);
        
        //Assuming  y = 0 is ground position and position changes on y will only be posible by terrain traversal (character doesn't jump), initialize character on ground level.
        transform.Translate(transform.position.x, 0, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
            Move(Vector3.forward);
        if(Input.GetKey(KeyCode.A))
            Move(Vector3.left);
        if(Input.GetKey(KeyCode.S))
            Move(Vector3.back);
        if(Input.GetKey(KeyCode.D))
            Move(Vector3.right);


        if(Input.GetMouseButton(3))
            RotateCameraAround();
        else
            RotatePlayerAround();
        if(Input.GetMouseButtonUp(3))
            cameraFollowTarget.transform.rotation = new Quaternion();

        if(Input.GetMouseButton(0))
        {
            ShootHose();
        }
        

    }

    void Move(Vector3 direction)
    {
        cc.Move(transform.TransformDirection(direction) * movementSpeed * Time.deltaTime);
    }

    void RotateCameraAround()
    {
        cameraFollowTarget.transform.eulerAngles += cameraSensibility * new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
    }

    void RotatePlayerAround()
    {
        //this.transform.eulerAngles += cameraSensibility * new Vector3(0, Input.GetAxis("Mouse X"), 0);
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * cameraSensibility, 0));
    }

    void ShootHose()
    {
        Instantiate(waterDropType, transform.TransformDirection(this.transform.GetChild(1).transform.position), this.transform.rotation);
    }

}
