using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Akm : Weapon
{
    [SerializeField] private int _magazineSize;
    [SerializeField] private float _reloadLastTime;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public override void AddAmmoBox(int ammoCount)
    {
        MaxBullet = MaxBullet + ammoCount;
    }

    public override void Reload()
    {
        int remainBulletCount = 0;

        if (MaxBullet > 0)
        {
            if (CurrentMagazineBulletsCount == 0)
            {
                MaxBullet -= _magazineSize;
                AudioSource.PlayOneShot(Reloading);
                CurrentMagazineBulletsCount = _magazineSize;
            }
            else
            {
                if (MaxBullet < CurrentMagazineBulletsCount)
                {
                    remainBulletCount = _magazineSize - CurrentMagazineBulletsCount;

                    if (MaxBullet > remainBulletCount)
                    {
                        MaxBullet -= remainBulletCount;
                        AudioSource.PlayOneShot(Reloading);
                        CurrentMagazineBulletsCount += remainBulletCount;
                    }
                    else
                    {
                        CurrentMagazineBulletsCount += MaxBullet;
                        AudioSource.PlayOneShot(Reloading);
                        MaxBullet = 0;
                    }
                }
                else
                {
                    remainBulletCount = _magazineSize - CurrentMagazineBulletsCount;
                    MaxBullet -= remainBulletCount;
                    AudioSource.PlayOneShot(Reloading);
                    CurrentMagazineBulletsCount += remainBulletCount;
                }
            }
        }
        else
        {
            AudioSource.PlayOneShot(EmptyMagazine);
        }
    }

    public override void Shoot()
    {
        if (CurrentMagazineBulletsCount > 0)
        {
            AudioSource.PlayOneShot(OneShot);
            CreateSleeve();
            Bullet bullet = Instantiate(Prefab, ShootPointPosition.position, transform.rotation);
            CurrentMagazineBulletsCount--;
        }
        else
        {
            Reload();
        }
    }

    private void CreateSleeve()
    {
        Sleeve sleeve = Instantiate(BulletTipsPrefabs, DropTips.position, transform.rotation);
        AudioSource.PlayOneShot(SleeveDrop);
    }
}
