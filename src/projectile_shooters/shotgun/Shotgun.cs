using tdws.projectile_shooters.projectile_shooter;

namespace tdws.projectile_shooters.shotgun
{
  /// <summary>
  ///   A shotgun.
  /// </summary>
  public class Shotgun : ProjectileShooter
  {
    protected override void OverrideProperties()
    {
      ProjectilesPerShot = 5;
      SecondsBetweenShots = 0.5f;
      Ammo = 30;
      MagSize = 3;
      ProjectileShooterName = "Shotgun";
    }
  }
}