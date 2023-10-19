using TMPro;
using UnityEngine;

public class WeaponView : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI MagazineBulletsCount;
    [SerializeField] protected TextMeshProUGUI MaxBulletsCount;
    [SerializeField] private Weapon _currentWeapon;

    private void Start()
    {
        _currentWeapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        BulletsInformation();
    }

    public void BulletsInformation()
    {
        MagazineBulletsCount.text = _currentWeapon.CurrentMagazineBulletsCount.ToString();
        MaxBulletsCount.text = _currentWeapon.MaxBullet.ToString();
    }
}
