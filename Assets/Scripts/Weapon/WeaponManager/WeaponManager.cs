using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //Singleton
    public static WeaponManager instance{get; private set;}
    private void Awake() {
        if(instance != null){
            Debug.LogError("More than one weapon manager scripts");
            return;
        }
        instance = this;
    }

    //To notify scripts when player attacks/shoots
    private List<IOnAttack> onAttackListeners = new List<IOnAttack>();
    public void AddOnAttackListener(IOnAttack listener){
        onAttackListeners.Add(listener);
    }
    public void RemoveOnAttackListener(IOnAttack listener){
        onAttackListeners.Remove(listener);
    }
    void NotifyWhenPlayerAttacks(){
        foreach(IOnAttack listener in onAttackListeners){
            listener.OnAttack();
        }
    }

    private GameObject player;
    private WeaponBase equippedWeapon;
    private PlayerBasicStats playerStats;

    private float shootForce, currReloadTime, maxReloadTime;
    private float atkPower, atkSpeed, atkInterval = 0; //How quickly the bullets are shot. 1 bullet per second or more
    private int remainingBullets;

    [SerializeField]private DisplayReload reloadDisplay;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        RecordWeaponData();
        //Datas such as setting available num of bullets equal to max bullets should be done only once at the start/ at reload so
        RecordOneTimeWeaponData();
    }

    void RecordWeaponData(){
        //Get the equipped weapon for its data from the player if haven't got it already
        equippedWeapon = player.GetComponent<WeaponHolder>().GetEquippedWeapon();
        playerStats = PlayerBasicStats.instance;
        
        //Set some data into variables for easier understanding
        shootForce = equippedWeapon.shootForce;
        atkSpeed = equippedWeapon.atkSpeed * playerStats.GetAtkSpeed();
        atkPower = equippedWeapon.atkPower * playerStats.GetAtkPower();
        maxReloadTime = equippedWeapon.reloadTime * (1/playerStats.GetReloadSpeed());
    }

    void RecordOneTimeWeaponData(){
        remainingBullets = equippedWeapon.maxNumOfBullets;
        ResetReloadTimer();
    }

    //Reset the bullet reload to max
    void ResetReloadTimer(){
        currReloadTime = maxReloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Just manage reloading and stuff
        ManageReloadTimer();
        //Set timer to be able to shoot next bullet
        atkInterval -= Time.deltaTime*atkSpeed;//Faster atk speed means more bullets shot per min
        //When trying to shoot
        if((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && remainingBullets > 0){
            if(CanShoot()){
                //Activate the effects of the weapon
                ActivateWeapon();
                NotifyWhenPlayerAttacks();
                //Things to do after weapon is activated... such as reset atk interval, reload maybe etc
                atkInterval = 1;
                remainingBullets--;//Consume a bullet
            }
        }
    }

    void ManageReloadTimer(){
        if(currReloadTime <= 0){
            //If weapon is upgraded/changed then set the latest data's values
            RecordWeaponData();
            ResetReloadTimer();
            //Reset remaining bullets to max after being reloaded
            remainingBullets = equippedWeapon.maxNumOfBullets;
        }
        if(remainingBullets <= 0){
            if(currReloadTime == maxReloadTime){
                //Display the weapon being reloaded to the user
                reloadDisplay.Reloaded(currReloadTime);
            }
            currReloadTime -= Time.deltaTime;
        }
    }

    bool CanShoot(){
        if(atkInterval <= 0) return true;
        else return false;
    }

    public void ActivateWeapon(float angle = 0, GameObject bullet = null, float dmgMultiplier = 1){
        //Slight randomness
        angle += Random.Range(-1f,1f)*3;

        //Get the direction to shoot at
        Vector2 shootDir = ConvertAngleToVector(transform.eulerAngles.z+angle);

        
        if(bullet == null){
            //Set default bullet type based on weapon
            bullet = equippedWeapon.bullet;
        }
        //Shoot from the tip of the gun
        Rigidbody2D bulletRb = Instantiate(bullet, (Vector2)transform.position + shootDir*0.5f, Quaternion.identity).GetComponent<Rigidbody2D>();
        bulletRb.AddForce(shootDir*shootForce, ForceMode2D.Impulse);
        bulletRb.transform.localEulerAngles = new Vector3(0,0, transform.eulerAngles.z+90);
        //Set the multiplier for bullet dmg
        bulletRb.GetComponent<DamageEnemy>().SetPlayerAtkStat(atkPower);
        bulletRb.GetComponent<DamageEnemy>().SetDmgMultiplier(dmgMultiplier);

        Vector2 ConvertAngleToVector(float angle){
            angle += 90;
            Vector2 vector = new Vector2(Mathf.Cos(angle*Mathf.Deg2Rad), Mathf.Sin(angle*Mathf.Deg2Rad));
            return vector;
        }
    }

    public WeaponBase GetWeaponData(){
        return equippedWeapon;
    }
}
