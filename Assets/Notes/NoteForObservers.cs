/*
    This note will specity which scripts are listening/observing to which script
    Observer script ->Target script being observed

    //LEVEL UPS 
    Interface name: IOnLevelUp                           
    PlayerBasicStats -> PlayerLevelManager to increase basic stats slightly when leveling up every time


    //ON DAMAGE RECEIVED 
    Interface name: IWhenDamaged
    KnockbackOnDamage -> HealthManager(of player) to knockback nearby enemies whenever player takes damage

    //ON DEATH
    Interface name: IOnDeath
    DropResources -> EnemyHpManager to drop resources such as exp/level points when dead

*/
