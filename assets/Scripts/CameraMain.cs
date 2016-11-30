using UnityEngine;
using System.Collections;

public class CameraMain : MonoBehaviour {

    //Valores que se deciden desde el menu
    //public int movementspeed = 100;
    private float speedY = 7f;
    private float speedX = 1.7f;
    private float marginWidth = 1f;
    private float marginHeight = 5f;
    private float marginHeightBot = 2f;
    private float verticalOffset = 2f;
    private float horizontalOffset = 3f;
    private float cameraOffset = 10f;
    public GameObject Birgin;
    //Valores que se deciden desde el menu

    private Vector3 posBirgin;
    private Vector3 cameraPosition;
    private CharacterController controller;
    private bool moveCamXd = false;
    private bool moveCamYd = false;
    private bool moveCamXi = false;
    private bool moveCamYi = false;
    private bool cameraRun = false;
    private bool isMenu = false;
    private float runFactor = 1;
    private int Still = 0;

    public GameObject ingameMenu;

    // Use this for initialization
    void Start () {
        Birgin = GameObject.FindGameObjectWithTag("Player");
        cameraPosition = new Vector3(Birgin.transform.position.x, Birgin.transform.position.y + verticalOffset, Birgin.transform.position.z - cameraOffset);
        transform.position = cameraPosition;
        controller = Birgin.GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isMenu)
            {
                Instantiate(ingameMenu);
            }
            isMenu = !isMenu;
        }
        if (Still == 0)
        {
            //CORRECCIONS CAMERA - segueix fins al centre del personatge
            posBirgin = Birgin.transform.position;
            if (cameraPosition.x > (posBirgin.x + marginWidth))
            {
                moveCamXd = true;
            }
            if (moveCamXd)
            {
                cameraPosition.x = cameraPosition.x - 0.05f * speedX;
                transform.Translate(0.05f * -1 * speedX, 0.0f, 0.0f);
                if (cameraPosition.x < posBirgin.x)
                {
                    moveCamXd = false;
                }
            }
            if (cameraPosition.x < (posBirgin.x - marginWidth /*+ horizontalOffset*/))
            {
                moveCamXi = true;
            }
            if (moveCamXi)
            {
                cameraPosition.x = cameraPosition.x + 0.05f * speedX;
                transform.Translate(0.05f * speedX, 0.0f, 0.0f);
                if (cameraPosition.x > posBirgin.x /*+ horizontalOffset*/)
                {
                    moveCamXi = false;
                }
            }
            if (cameraPosition.y < (posBirgin.y - marginHeight) || cameraPosition.y < (posBirgin.y /*- (marginHeightBot)*/) && controller.isGrounded || (cameraPosition.y != Birgin.transform.position.y + verticalOffset) && controller.isGrounded)
            {
                moveCamYi = true;
            }
            if (moveCamYi)
            {
                cameraPosition.y = cameraPosition.y + 0.02f * speedY;
                transform.Translate(0.0f, 0.02f * speedY, 0.0f);
                if (cameraPosition.y > posBirgin.y)
                {
                    moveCamYi = false;
                }
            }
            if (cameraPosition.y > (posBirgin.y + marginHeightBot))
            {
                moveCamYd = true;
            }
            if (moveCamYd)
            {
                if (cameraPosition.y > posBirgin.y + 2.5f || cameraRun)
                {
                    cameraPosition.y = cameraPosition.y - 0.02f * speedY * runFactor;
                    transform.Translate(0.0f, 0.02f * -1 * speedY * runFactor, 0.0f);
                    cameraRun = true;
                    runFactor = runFactor + 3.0f * Time.deltaTime;
                }
                else {
                    cameraPosition.y = cameraPosition.y - 0.02f * speedY;
                    transform.Translate(0.0f, 0.02f * -1 * speedY, 0.0f);
                }
                if (cameraPosition.y < posBirgin.y + verticalOffset)
                {
                    moveCamYd = false;
                    cameraRun = false;
                    runFactor = 1f;
                }
            }
            //CORRECCIONS CAMERA - segueix fins al centre del personatge
        }
        else
        {
            if (Still == 1) {
                //NOTHING
            }
        }
    }
    void CameraStill() {
        Still = 1;
        cameraOffset = -13f;
        cameraPosition.z = cameraPosition.z - cameraOffset;
        transform.Translate(GameObject.FindWithTag("LookAt").transform.position.x - transform.position.x, GameObject.FindWithTag("LookAt").transform.position.y - transform.position.y, cameraPosition.z);
        Debug.Log("Quedate QUIETO!!");
    }
    void CameraNotStill()
    {
        if (Still != 0) { 
            Still = 0;
            cameraOffset = 10f;
            cameraPosition = new Vector3(Birgin.transform.position.x, Birgin.transform.position.y + verticalOffset, Birgin.transform.position.z - cameraOffset);
            transform.position = cameraPosition;
            //cameraPosition.z = cameraPosition.z - cameraOffset;
            //transform.Translate(0.0f, 0.0f, -cameraPosition.z);
            Debug.Log("MUEVANSEE!!");
        }
    }

}
