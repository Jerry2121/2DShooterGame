using UnityEngine;

public class PlayerExample : MonoBehaviour {

    public float moveSpeed;
    public Joystick joystick;
    public Joystick joystick2;
    public Vector3 joyStartPos;
    public GameObject handle;
    private void Start()
    {
        joyStartPos = handle.transform.position;
    }
    void Update () 
	{
        Vector3 moveVector = (transform.right * joystick.Horizontal + transform.up * joystick.Vertical).normalized;
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
        Vector3 rotateVector = (transform.right * joystick2.Horizontal*180 + transform.up * joystick2.Vertical*180);
        /*if x < 0 y == 0
         * looking right
         * rotate 90 degrees clockwise
         * if x > 0 y == 0
         * looking left
         * rotate 90 degrees counterclockwise
         * if y < 0
         * looking down
         * rotate 180 degrees
         * if y > 0
         * looking up
         * rotate 0 degrees
         * 
         * */
        Vector3 foo = (handle.transform.position - joyStartPos).normalized;
        if (foo.magnitude == 1)
        {
            transform.forward = foo;
            transform.Rotate(new Vector3(0, 90, 90));
            //transform.rotation = Quaternion.Euler(rotateVector);


        }
    }
}