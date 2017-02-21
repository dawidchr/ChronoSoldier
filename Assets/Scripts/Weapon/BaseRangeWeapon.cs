using UnityEngine;

public class BaseRangeWeapon : BaseWeapon {

    [SerializeField]
    float lifeTime;

    float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= lifeTime)
            Destroy(this.gameObject);
    }
}
