using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public enum AlienType { ALIEN_ZAKO, ALIEN_GOEI, ALIEN_BOSS}

    [Header("Waves")]
    [SerializeField] protected Transform formationContent;
    [SerializeField] protected GameObject[] alienFormations;
    [SerializeField] protected GameObject[] alienKinds;

    protected int activeStage = 0;
    protected int aliensCount = 0;

    [Header("Life")]
    [SerializeField] protected GameObject ship;
    [SerializeField] protected GameObject lifeIcon;
    [SerializeField] protected RectTransform lifeContainer;
    [Range(1, 3)]
    [SerializeField] protected int initialLife = 3;

    protected int life = 1;
    protected int maxLife = 3;

    [Header("Score")]
    [SerializeField] protected Text scoreText;
    [SerializeField] protected int pointsAlien = 10;

    protected int score = 0;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        life = initialLife;
        updateLifeUI();
        GameObject currentFormation = MountAlienFormation(activeStage);
        CreateAliensInFormation(currentFormation.transform);
    }

    private void Update() {

    }

    #region Waves

    protected GameObject MountAlienFormation(int activeFormation) {
        //Create the first formation of the list
        GameObject currentFormation = Instantiate<GameObject>(alienFormations[activeFormation]);
        //Set that parent is the object for formation of the aliens
        currentFormation.transform.SetParent(formationContent);
        //Set for the center
        currentFormation.transform.localPosition = Vector3.zero;
        //Wireframe on the scene
        return currentFormation;
    }

    protected void CreateAliensInFormation(Transform formation) {
        foreach(Transform item in formation) {
            GameObject alien = CreateAlienByType(item.GetComponent<AlienPositionFormationBehaviour>().alienType);
            alien.transform.SetParent(item);
            alien.transform.localPosition = Vector3.zero;
        }
        aliensCount = formation.childCount;
    }

    protected GameObject CreateAlienByType(AlienType alienType) {
        switch(alienType) {
            case AlienType.ALIEN_ZAKO:
                return Instantiate(alienKinds[0]);
            case AlienType.ALIEN_GOEI:
                return Instantiate(alienKinds[1]);
            default:
                return null;
        }
    }

    #endregion

    #region Collisions

    public void onShipHit(Collider2D collider) {
        Destroy(collider.gameObject);
        ship.GetComponent<Animator>().SetTrigger("hit");

        if (life == 0) {
            Time.timeScale = 0;
        }

        decreaseLife();
    }

    public void onAlienHit(GameObject alien, Collider2D collider) {

        Destroy(alien);

        Destroy(collider.gameObject);

        aliensCount--;

        increaseScore(pointsAlien);

        if(aliensCount == 0) {
            Destroy(formationContent.GetChild(0).gameObject);
            activeStage++;
            CreateAliensInFormation(MountAlienFormation(activeStage).transform);
        }

    }

    #endregion

    #region Life

    private void updateLifeUI() {
        for(int i = 0; i < life; i++) {
            GameObject lifeUI = Instantiate(lifeIcon);
            lifeUI.transform.SetParent(lifeContainer);
            lifeUI.transform.localScale = Vector3.one;
        }
    }

    private void decreaseLife() {
        if(life > 0) {
            life--;
            Destroy(lifeContainer.GetChild(0).gameObject);
        }
    }

    #endregion

    #region Score

    private void increaseScore(int points) {
        score += points;
        scoreText.text = maskPoints(score);
    }

    private string maskPoints(double points) {
        int count = 5;
        while ((points /= 10.0) >= 1)
            count--;
        string value = "";
        do {
            value += "0";
            count--;
        } while (count > 0);
        value += score.ToString();
        value += " ";
        return value;
    }

    #endregion

}
