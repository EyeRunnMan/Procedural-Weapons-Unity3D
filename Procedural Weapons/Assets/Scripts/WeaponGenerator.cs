using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGenerator : MonoBehaviour
{
    //var :: body parts list
    //var :: barrel part list
    //var :: stock part list
    //var :: handle part list
    //var :: scope part list 
    //var :: magzine part list

    public List<GameObject> weaponBodyTypes;
    public List<GameObject> weaponBarrelTypes;
    public List<GameObject> weaponStockTypes;
    public List<GameObject> weaponHandleTypes;
    public List<GameObject> weaponScopeTypes;
    public List<GameObject> weaponMagzineTypes;

    public List<Material> weaponSkinMaterials;


    private int currentBodyId;
    private int currentBarrelId;
    private int currentStockId;
    private int currentHandleId;
    private int currentScopeId;
    private int currentMagzineId;

    private int currentSkinId;

    GameObject prevWeapon=null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        int totalBodyTypes =weaponBodyTypes.Count;
        int totalBarelTypes = weaponBarrelTypes.Count;
        int totalStockTypes = weaponStockTypes.Count;
        int totalHandleTypes = weaponHandleTypes.Count;
        int totalScopeTypes = weaponScopeTypes.Count;
        int totalMagzineTypes = weaponMagzineTypes.Count;

        int totalSkinTypes = weaponSkinMaterials.Count;


        if (Input.GetKey(KeyCode.Space))
        {
            if (prevWeapon != null)
            {
                Destroy(prevWeapon);
            }
            
            currentBodyId = Random.Range(0, totalBodyTypes );
            currentBarrelId = Random.Range(0, totalBarelTypes);
            currentStockId = Random.Range(0, totalStockTypes );
            currentHandleId = Random.Range(0, totalHandleTypes);
            currentScopeId = Random.Range(0, totalScopeTypes );
            currentMagzineId = Random.Range(0, totalMagzineTypes );

            currentSkinId = Random.Range(0, totalSkinTypes - 1);

            

            GameObject currWeaponBody =Instantiate( weaponBodyTypes[currentBodyId]);

            Transform barrelSocket = currWeaponBody.transform.Find("BarrelSocket");
            Transform stockSocket = currWeaponBody.transform.Find("StockSocket");
            Transform scopeSocket = currWeaponBody.transform.Find("ScopeSocket");
            Transform magzineSocket = currWeaponBody.transform.Find("MagzineSocket");
            Transform handleSocket = currWeaponBody.transform.Find("HandleSocket");

            GameObject currWeaponBarrel = Instantiate(weaponBarrelTypes[currentBarrelId], barrelSocket.position, Quaternion.EulerAngles(0, 0, 0), currWeaponBody.transform);
            GameObject currWeaponStock = Instantiate(weaponStockTypes[currentStockId], stockSocket.position, Quaternion.EulerAngles(0, 0, 0), currWeaponBody.transform);
            GameObject currWeaponHandle = Instantiate(weaponHandleTypes[currentHandleId], handleSocket.position, Quaternion.EulerAngles(0, 0, 0), currWeaponBody.transform);
            GameObject currWeaponScope = Instantiate(weaponScopeTypes[currentScopeId], scopeSocket.position, Quaternion.EulerAngles(0, 0, 0), currWeaponBody.transform);
            GameObject currWeaponMagzine = Instantiate(weaponMagzineTypes[currentMagzineId], magzineSocket.position, Quaternion.EulerAngles(0, 0, 0), currWeaponBody.transform);

            Material currWeaponSkin = weaponSkinMaterials[currentSkinId];

            /*       currWeaponBarrel.transform.parent = currWeaponBody.transform;
                   currWeaponStock.transform.parent = currWeaponBody.transform;
                   currWeaponScope.transform.parent = currWeaponBody.transform;
                   currWeaponMagzine.transform.parent = currWeaponBody.transform;
                   currWeaponHandle.transform.parent = currWeaponBody.transform;*/

            /* currWeaponBarrel.transform.position = new Vector3(10, 10, 10);
             currWeaponScope.transform.position = new Vector3(10, 10, 10);
             currWeaponMagzine.transform.position = new Vector3(10, 10, 10);
             currWeaponHandle.transform.position = new Vector3(10, 10, 10);
             currWeaponStock.transform.position = new Vector3(10, 10, 10);*/

            currWeaponBarrel.transform.Rotate(-currWeaponBody.transform.eulerAngles, Space.World);
            currWeaponScope.transform.Rotate(-currWeaponBody.transform.eulerAngles,Space.World);
            currWeaponMagzine.transform.Rotate(-currWeaponBody.transform.eulerAngles, Space.World);
            currWeaponHandle.transform.Rotate(-currWeaponBody.transform.eulerAngles, Space.World);
            currWeaponStock.transform.Rotate(-currWeaponBody.transform.eulerAngles, Space.World);

            currWeaponBarrel.transform.Rotate(Vector3.right,180);
            currWeaponScope.transform.Rotate(Vector3.right, 180);
            currWeaponMagzine.transform.Rotate(Vector3.right, 180);
            currWeaponHandle.transform.Rotate(Vector3.right, 180);
            currWeaponStock.transform.Rotate(Vector3.right, 180);

            currWeaponBody.GetComponent<Renderer>().material = weaponSkinMaterials[Random.Range(0, totalSkinTypes - 1)];
            currWeaponBarrel.GetComponent<Renderer>().material = weaponSkinMaterials[Random.Range(0, totalSkinTypes - 1)];
            currWeaponHandle.GetComponent<Renderer>().material = weaponSkinMaterials[Random.Range(0, totalSkinTypes - 1)];
            currWeaponMagzine.GetComponent<Renderer>().material = weaponSkinMaterials[Random.Range(0, totalSkinTypes - 1)];
            currWeaponScope.GetComponent<Renderer>().material = weaponSkinMaterials[Random.Range(0, totalSkinTypes - 1)];
            currWeaponStock.GetComponent<Renderer>().material = weaponSkinMaterials[Random.Range(0, totalSkinTypes - 1)];

            currWeaponBody.transform.parent = transform;
            currWeaponBody.transform.rotation = transform.rotation;
            prevWeapon = currWeaponBody;

        }

    }
}
