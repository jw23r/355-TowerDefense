using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb {
    /// <summary>
    /// aims at target and destoys itself when hits an an enemy
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        Vector3 attackTarget;// stores dir to player
        public float speed = 50;// how fast it moves
        float time = .2f;
        // Start is called before the first frame update
        /// <summary>
        /// gets postion of enemy
        /// </summary>
        void Start()
        {
            attackTarget = Tower.enemyPostion;
        }

        // Update is called once per frame
        /// <summary>
        /// moves object towards player
        ///
        /// </summary>
        void Update()
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                Destroy(gameObject);
            }
            Vector3 dirToPlayer = (attackTarget - transform.position);
            transform.position += dirToPlayer.normalized * speed * Time.deltaTime;
            
        }
        /// <summary>
        /// destroys object when it hits enemy
        /// </summary>
        /// <param name="collider"></param>
        public void OnTriggerEnter(Collider collider)
        {
            if (collider.transform.tag == "Enemy") {
                Destroy(gameObject);
            }

        }
    }
}