using Entitas.Unity;
using UnityEngine;
public class CollisionReporter: MonoBehaviour
{
    public string targetTag;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(targetTag)) {
            var link = gameObject.GetEntityLink();
            var targetLink = collision.gameObject.GetEntityLink();

            // Pools.sharedInstance.input.CreateEntity()
                // .AddCollision(link.entity, targetLink.entity);
        }
    }
}