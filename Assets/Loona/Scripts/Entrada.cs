using UnityEngine;
using System.Collections;

public class Entrada : MonoBehaviour {

    private float vertical;
    private float horizontal;
    private Vector3 touchDeltaPosition;
    private Camera _camera;
    private Vector3 mousePos;
	private bool flag = true;
    public float TouchTime;
	private GameObject GameController;
	[SerializeField] private GameObject Controller;
	private GameObject player;
	public float movimentPorcentReduction;
    // Use this for initialization
    void Start () {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		//GameController = GameObject.FindGameObjectWithTag ("GameController");
		player = GameObject.FindGameObjectWithTag ("Player");
		InvokeRepeating ("Update2", 0, 0.001f);
		Controller = GameObject.FindGameObjectWithTag ("GameController");
	}
 
	void Update2()
	{
		//<!--captura as coordenadas do toque-->
		//horizontal = Input.GetAxis("Horizontal");
		//vertical = Input.GetAxis("Vertical");
		if (Input.GetButtonDown ("Fire1"))
		{
			if (flag)
			{
				flag = false;

				mousePos = Input.mousePosition;
				//mousePos.z = 0;
				//mousePos = _camera.ScreenToWorldPoint(mousePos);
					//ScreenToWorldPoint (mousePos);
				//GameController.GetComponent<Crescer>().MassAddUp(player,movimentPorcentReduction);

				if(player.gameObject.transform.localScale.x <= 0.2)
				{
					Controller.GetComponent<FimDeJogo>().Morrer();
				}
				player.transform.localScale -= new Vector3(movimentPorcentReduction,movimentPorcentReduction,1);
				Camera.main.orthographicSize = Camera.main.orthographicSize - movimentPorcentReduction/2;



				horizontal = mousePos.x - (int) Screen.width / 2;
				vertical = mousePos.y - (int) Screen.height / 2;
				
				//Debug.Log ("horizontal: " + horizontal + "vertical: " + vertical);
				//Debug.Log ("largura/altura da tela: " + Screen.width + "/ " + Screen.height);
				//move a gosma de acordo com a entrada
				GetComponent<Movimentacao>().Mover(horizontal, vertical, ForceMode2D.Impulse);
				
				//atira massa de acordo com a entrada
				//Debug.Log("antes de atirar!1");
				GetComponent<Tiro>().Atirar(horizontal, vertical, ForceMode2D.Force);
                //Debug.Log("x/y:" + mousePos.x + "/" + mousePos.y);
                Invoke("SetFlag", TouchTime);
			}
		}
		/*if (Input.touchCount == 1) {
			if(Input.GetTouch(0).phase == TouchPhase.Ended)
			{
				mousePos = _camera.ScreenToWorldPoint (Input.GetTouch(0).position);
				//touchDeltaPosition = Input.GetTouch(0).position;
				
				//horizontal = touchDeltaPosition.x;
				//vertical = touchDeltaPosition.y;
				horizontal = mousePos.x;
				vertical = mousePos.y;
				
				Debug.Log ("horizontal: " + horizontal + "vertical: " + vertical);
				
				//move a gosma de acordo com a entrada
				GetComponent<Movimentacao> ().Mover (horizontal, vertical, ForceMode2D.Impulse);
				
				//atira massa de acordo com a entrada
				//Debug.Log("antes de atirar!1");
				GetComponent<Tiro> ().Atirar (horizontal, vertical, ForceMode2D.Force);

				//iniciar thread aqui para deixar flag true depois de alguns segundos
				//flag = false;
			}

		}*/
	}

	// Update is called once per frame
    void Update()
    {
        
    }
    void SetFlag() {
         this.flag= true;
    }
}
