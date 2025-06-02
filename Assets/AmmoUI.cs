using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    private TextMeshProUGUI textAmmo;
    private void Start()
    {
        textAmmo = GetComponent<TextMeshProUGUI>();
    }
    public void ActualizarTextoAmmo(int ammo)
    {
        textAmmo.text ="Ammo: "+ammo;
    }
}