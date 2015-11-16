using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

    private float vertical;
    private float horizontal;
    private Vector3 mousePos;
    private Vector3 DeltaMovement;
	private bool flag = true;
    public float TouchTime = 0.5f;
    [SerializeField] private float TouchTimeDelayMax = 0.1f;
	private GameObject SceneAspectsController;
    public string SceneAspectsControllerTag = "SceneAspectsController";
    private GameObject player;
    [SerializeField] private string PlayerTag = "Player";
    public float movimentPorcentReduction = 0.05f;
    private GameObject PauseButton;
    [SerializeField] private string PauseButtonTag = "PauseButton";
    private float PauseButtonRange; //30f
    public GameObject TouchFeedBackPrefab;
    private GameObject TouchFeedBackObject;
    public float TimeToDestroyTouchFeedBack = 0.1f;
    public float zTouchPosition = -4f;

    // Use this for initialization
    void Start () {
        SceneAspectsController = GameObject.FindGameObjectWithTag(SceneAspectsControllerTag);
		player = GameObject.FindGameObjectWithTag (PlayerTag);
		InvokeRepeating ("Update2", 0, 0.001f);
        PauseButton = GameObject.FindGameObjectWithTag(PauseButtonTag);
        PauseButtonRange = PauseButton.GetComponent<RectTransform>().rect.width;
    }
 
	void Update2()
	{
		if (Input.GetButtonDown ("Fire1"))
		{
            mousePos = Input.mousePosition;
            if (ButtonWasClicked(mousePos, PauseButton.gameObject.transform.position, PauseButtonRange))
            {
                return;
            }
            Invoke("CheckPinch", TouchTimeDelayMax);
			
		}
	}

    private void CheckPinch()
    {
        /*if (Input.touchCount == 2)
        {
            return;
        }*/
        if (flag)
        {
            if(SceneAspectsController.GetComponent<ButtonController>().GameIsPaused)
            {
                return;
            }
            flag = false;
            if (player.gameObject.transform.localScale.x <= 0.2)
            {
                SceneAspectsController.GetComponent<FimDeJogo>().Morrer();
            }
            player.transform.localScale -= new Vector3(movimentPorcentReduction, movimentPorcentReduction, 1);
            Camera.main.orthographicSize = Camera.main.orthographicSize - movimentPorcentReduction / 2;

            /*horizontal = mousePos.x - (int) Screen.width / 2 - player.transform.position.x;
            vertical = mousePos.y - (int) Screen.height / 2 - player.transform.position.y;
            */

            
            DeltaMovement = Camera.main.ScreenToWorldPoint(mousePos);
            horizontal = DeltaMovement.x - player.transform.position.x;
            vertical = DeltaMovement.y - player.transform.position.y;

            if (TouchFeedBackPrefab != null)
            {
                DeltaMovement.z = zTouchPosition;
                TouchFeedBackObject = Instantiate(TouchFeedBackPrefab) as GameObject;
                TouchFeedBackObject.transform.position = DeltaMovement;
                TouchFeedBackObject.AddComponent<DestroyByTime>();
                TouchFeedBackObject.GetComponent<DestroyByTime>().TimeToDestroy = TimeToDestroyTouchFeedBack;
                TouchFeedBackObject.GetComponent<DestroyByTime>().StartDestroying();
            }

            GetComponent<Movimentacao>().Mover(horizontal, vertical, ForceMode2D.Force);

            GetComponent<Tiro>().Atirar(horizontal, vertical, ForceMode2D.Force);

            Invoke("SetFlag", TouchTime);
        }
    }

    private bool ButtonWasClicked(Vector3 TouchPosition, Vector3 ButtonPosition, float ButtonSize)
    {
        if(TouchPosition.x < ButtonPosition.x - ButtonSize)
        {
            return false;
        }
        else if(TouchPosition.y < ButtonPosition.y - ButtonSize)
        {
            return false;
        }
        else if (TouchPosition.x > ButtonPosition.x + ButtonSize)
        {
            return false;
        }
        else if (TouchPosition.y > ButtonPosition.y + ButtonSize)
        {
            return false;
        }
        return true;
    }

    void SetFlag() {
         this.flag= true;
    }

}
