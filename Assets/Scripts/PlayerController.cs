using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private NavMeshAgent agent;
    private string vertical = "Vertical_P";
    private string horizontal = "Horizontal_P";
    private string verticalRotation = "VerticalRotation_P";
    private string horizontalRotation = "HorizontalRotation_P";
    private string triggerAxis = "RightTrigger_P";

    //Fire controls, added for completness sake. Might need to be moved

    private string PrimaryFire = "ButtonA_P";
    private string SpecialPower = "LeftTrigger_P";
    private string Reload = "ButtonA_P";
    public float trigger;

    private Player currentPlayer;

    private int currentController;
    private bool canTakeDamage = true;

    public PlayerClass playerClass;

    private bool paused = false;
    private Canvas menu;
    public UnityEngine.UI.Slider healthSlider;
    public UnityEngine.UI.Slider ammoSlider;

    public UnityEngine.UI.Text healthText;
    public UnityEngine.UI.Text ammoText;

    private int uiXPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        ReloadWeapon();
        Transform canvas = this.transform.Find("Canvas");
        Transform panel = canvas.Find("Panel");
        panel.transform.position = new Vector3(uiXPosition, 80, 0);
        healthSlider = panel.Find("Health").GetComponent<UnityEngine.UI.Slider>();
        Transform temp = panel.Find("Health").GetComponent<Transform>();
        temp = temp.Find("Fill Area").GetComponent<Transform>();
        healthText = temp.Find("Text").GetComponent<UnityEngine.UI.Text>();
        healthSlider.maxValue = playerClass.Health;
        healthText.text = playerClass.Health + " / " + playerClass.MaxHealth;

        ammoSlider = panel.Find("Ammo").GetComponent<UnityEngine.UI.Slider>();
        ammoSlider.maxValue = GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().getMaxAmmo();
        ammoSlider.value = GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().getCurrentAmmo();
        temp = panel.Find("Ammo").GetComponent<Transform>();
        temp = temp.Find("Fill Area").GetComponent<Transform>();
        ammoText = temp.Find("Text").GetComponent<UnityEngine.UI.Text>();

        ammoText.text = GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().getCurrentAmmo() + " / " + GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().getMaxAmmo();

        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Canvas>();
        menu.enabled = false;
    }

    public void SetUIPosition(int x)
    {
        uiXPosition = x;
    }

    public void SetController(int controller)
    {
        currentController = controller;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerClass.Health;
        ammoText.text = (int) GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().getCurrentAmmo() + " / " + (int) GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().getMaxAmmo();
        ammoSlider.value = GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().getCurrentAmmo();
        Vector3 move = new Vector3(Input.GetAxis(horizontal + currentController), Input.GetAxis(vertical + currentController), 0);
        transform.position += move * speed * Time.deltaTime;

        float angle = Mathf.Atan2(Input.GetAxis(horizontalRotation + currentController), Input.GetAxis(verticalRotation + currentController)) * Mathf.Rad2Deg;
        if (angle != 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        if (Input.GetButtonDown(Reload + currentController))
        {
            ReloadWeapon();
        }

        trigger = Input.GetAxis(triggerAxis + currentController);
        float leftTrigger = Input.GetAxis(SpecialPower + currentController);
        

        if (trigger != 0)
        {
            Shoot();
            
        }
        else
        {
            GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().StopFire();
        }

        if (leftTrigger != 0)
        {
            GetComponentInChildren<PlayerClass>().GetComponentInChildren<Power>().Activate();
        }
    }

    void Shoot()
    {
        GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().Fire();
    }


    void ReloadWeapon()
    {
        GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().Reload();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            StartCoroutine(TakeDamage());
        }
    }

    IEnumerator TakeDamage()
    {
        if (canTakeDamage)
        {
            canTakeDamage = false;
            playerClass.Health -= 10;
            healthText.text = playerClass.Health + " / " + playerClass.MaxHealth;


            if (playerClass.Health <= 0)
            {
                Destroy(gameObject);
            }

            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f); //make player transparent.
            yield return new WaitForSeconds(2f);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f); //remove transparency.
            canTakeDamage = true;
        }
    }
}