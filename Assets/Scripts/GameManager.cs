using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum AlienType { ALIEN_ZAKO, ALIEN_GOEI, ALIEN_BOSS}

    [SerializeField] protected Transform formationContent;
    [SerializeField] protected GameObject[] alienFormations;
    [SerializeField] protected GameObject[] alienKinds;

    protected int activeStage = 0;
    protected int aliensCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject currentFormation = MountAlienFormation(activeStage);
        CreateAliensInFormation(currentFormation.transform);
    }

    private void Update() {

    }

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

}
