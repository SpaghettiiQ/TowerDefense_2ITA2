using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform currentWaypoint;
    [SerializeField] private float speed;

    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        currentWaypoint = WaypointProvider.Instance.GetNextWaypoint();

        StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));

            animator.SetBool("Attack", true);

            yield return new WaitForSeconds(1f);

        }
    }

    void Update()
    {
        var direction = currentWaypoint.position - transform.position;
        var movement = direction.normalized * speed * Time.deltaTime;

        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.Translate(movement);

        animator.SetInteger("State", 2);

        if(Vector3.Distance(currentWaypoint.position, transform.position) < 0.01f)
        {
            currentWaypoint = WaypointProvider.Instance.GetNextWaypoint(currentWaypoint);
            if(currentWaypoint == null)
            {
                // TODO - odebrat hr��i HP?
                Destroy(gameObject);
            }
        }
    }
}
