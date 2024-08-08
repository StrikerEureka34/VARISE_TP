using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
public abstract class TowerBase : MonoBehaviour
{
    public GameObject currentEnemyTarget;
    public Enemy enemy;
    public Tower1 tower1;
    public Tower2 tower2;
    public Health health;
    

    public float towerRange = 200f;
    protected virtual void Update()
    {
        if (currentEnemyTarget == null)
        { 
            Vector3 towerPosition = transform.position;
            Collider[] colliders = Physics.OverlapSphere(towerPosition, towerRange);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject != null && (collider.gameObject.CompareTag("enemy") || collider.gameObject.CompareTag("goob")))
                {
                    currentEnemyTarget = collider.gameObject;
                    /*health.points += 10;
                    Debug.Log("point=" + health.points);*/
                }
            }
        }

    }
}

