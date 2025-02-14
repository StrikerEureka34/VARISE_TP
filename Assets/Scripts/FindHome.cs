using UnityEngine;
using UnityEngine.AI;

public class FindHome : MonoBehaviour {

    public Transform destination;
    NavMeshAgent ai;

    void Start() {

        ai = GetComponent<NavMeshAgent>();
        ai.SetDestination(destination.position);
    }


    void Update() {

        if (ai.remainingDistance < 1.5f && ai.hasPath) {

            LevelManager.RemoveEnemy();
            ai.ResetPath();
            Destroy(this.gameObject, 0.01f);
        }
    }
}
