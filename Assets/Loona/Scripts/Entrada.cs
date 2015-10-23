using UnityEngine;
using System.Collections;

public class Entrada : MonoBehaviour {

    private float vertical;
    private float horizontal;
    private Vector3 mousePos;
	private bool flag = true;
    public float TouchTime = 0.5f;
	[SerializeField] private GameObject Controller;
    [SerializeField] private string GameControllerTag = "GameController";
    private GameObject player;
    [SerializeField] private string PlayerTag = "Player";
    public float movimentPorcentReduction = 0.1f;
    private GameObject PauseButton;
    [SerializeField] private string PauseButtonTag = "PauseButton";
    private float PauseButtonRange; //30f

    // Use this for initialization
    void Start () {
		Controller = GameObject.FindGameObjectWithTag (GameControllerTag);
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
			if (flag)
			{
				flag = false;

				if(player.gameObject.transform.localScale.x <= 0.2)
				{
					Controller.GetComponent<FimDeJogo>().Morrer();
				}
				player.transform.localScale -= new Vector3(movimentPorcentReduction,movimentPorcentReduction,1);
				Camera.main.orthographicSize = Camera.main.orthographicSize - movimentPorcentReduction/2;

				horizontal = mousePos.x - (int) Screen.width / 2;
				vertical = mousePos.y - (int) Screen.height / 2;
				
				GetComponent<Movimentacao>().Mover(horizontal, vertical, ForceMode2D.Force);

				GetComponent<Tiro>().Atirar(horizontal, vertical, ForceMode2D.Force);
                
                Invoke("SetFlag", TouchTime);
			}
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
