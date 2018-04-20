using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicatingEnemy : Enemy {

    public List<Enemy> SpawningEnemiesOnDeath;


    public override void DestroyEnemy()
    {
        foreach (Enemy enemy in SpawningEnemiesOnDeath)
        {
            Enemy newEnemy = Instantiate(enemy);
            newEnemy.gameObject.transform.position = this.transform.position;
            newEnemy.SetPlayer(base.player);
        }
        base.DestroyEnemy();
    }
}
