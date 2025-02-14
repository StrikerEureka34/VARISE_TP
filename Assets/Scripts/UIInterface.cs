using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInterface : MonoBehaviour {

    public GameObject rocketTurret;
    public GameObject gattlingTurret;
    public GameObject flamerTurret;
    public GameObject turretMenu;
    public TMPro.TMP_Text WaveText;
    GameObject focusObj;
    private GameObject itemPrefab;
    public Button slowSpeed;
    public Button mediumSpeed;
    public Button fastSpeed;
    private GameObject selectedTurret;

    void Start() {
        slowSpeed.onClick.AddListener(SlowSpeedClicked);
        mediumSpeed.onClick.AddListener(MediumSpeedClicked);
        fastSpeed.onClick.AddListener(FastSpeedClicked);

    }
    void SlowSpeedClicked()
    {
        LevelManager.onSpeedchange(1);
    }

    void MediumSpeedClicked()
    {
        LevelManager.onSpeedchange(5);
    }

    void FastSpeedClicked()
    {
        LevelManager.onSpeedchange(7);
    }
    public void CreateRocket()
    {
        itemPrefab = rocketTurret;
        CreateItemforButton();
    }

    public void CreateGattling()
    {
        itemPrefab= gattlingTurret;
        CreateItemforButton();

    }
    public void CreateFlamer()
    {
        itemPrefab= flamerTurret;
        CreateItemforButton();

    }
    public void CloseTurretMenu()
    {
        turretMenu.SetActive(false);
    }
    public void DestroyTurret()
    {
        Destroy(selectedTurret);
        turretMenu.SetActive(false);
    }

    void CreateItemforButton()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out hit)) return;

        focusObj = Instantiate(itemPrefab, hit.point, itemPrefab.transform.rotation);
        focusObj.GetComponent<Collider>().enabled = false;
    }


    void Update() {
        if (LevelManager.wavesEmitted < LevelManager.numberOfWaves)
            WaveText.text = (LevelManager.wavesEmitted + 1) + "  of  " + LevelManager.numberOfWaves;

        if (Input.GetMouseButtonDown(0)) {

            /* RaycastHit hit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

             if (!Physics.Raycast(ray, out hit)) return;

             focusObj = Instantiate(cubeTurret, hit.point, cubeTurret.transform.rotation);
             focusObj.GetComponent<Collider>().enabled = false;*/
            if (EventSystem.current.IsPointerOverGameObject()) return;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit)
                && hit.collider.gameObject.CompareTag("turret"))
            {
                turretMenu.transform.position = Input.mousePosition;
                turretMenu.SetActive(true);
                selectedTurret = hit.collider.gameObject;

            }
        } else if (focusObj && Input.GetMouseButton(0)) {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out hit)) return;

            focusObj.transform.position = hit.point;
        } else if (focusObj && Input.GetMouseButtonUp(0)) {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)
                && hit.collider.gameObject.CompareTag("platform")
                && hit.normal.Equals(new Vector3(0.0f, 1.0f, 0.0f))) {

                hit.collider.gameObject.tag = "occupied";
                focusObj.transform.position = new Vector3(
                    hit.collider.gameObject.transform.position.x,
                    focusObj.transform.position.y,
                    hit.collider.gameObject.transform.position.z);
                focusObj.GetComponent<Collider>().enabled = true;
            } else {

                Destroy(focusObj);
            }

            focusObj = null;
        }
    }
}
