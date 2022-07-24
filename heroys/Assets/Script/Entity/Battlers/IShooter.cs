
using System.Collections;
using UnityEngine;

public interface IShooter 
{
  
   public void Shooting();
   public IEnumerator TypeAttackRange();
   public IEnumerator TypeAttackMelee();
   public void SpawnArrow();
   public void ChangeAttack();

}
