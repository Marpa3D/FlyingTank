using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Tank
{
    // —крипт игрока от ¬€чеслава Ўарова
    protected override void Move()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _rigitbody.velocity = direction.normalized * _moveSpeed;
    }

    private void Update()
    {
        Move();
        SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
