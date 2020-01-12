using Godot;
using tdws.actors.monsters.abstract_monster;
using tdws.objects.projectiles.abstract_projectile;

namespace tdws.objects.projectiles.homing_projectile
{
  /// <summary>
  ///   A homing projectile.
  /// </summary>
  public class HomingProjectile : AbstractProjectile
  {
    /// <summary>
    ///   This constant is multiplied when turning towards a target.
    ///   0 will not turn it at all, 1 will turn it strongly.
    /// </summary>
    private const float TurnMultiplier = 0.3f;

    private Area2D _detectionArea;
    private AbstractMonster _target;

    protected override void OverrideProperties()
    {
      _detectionArea = GetNode("DetectionArea") as Area2D;
    }

    public override void _Process(float delta)
    {
      if (_target == null) return;

      var desiredDirection = _target.GetGlobalPosition() - GetGlobalPosition();
      Direction += desiredDirection.Normalized() * TurnMultiplier;
      Direction = Direction.Normalized();
    }

    private void OnDetectionAreaBodyExited(object body)
    {
      if (body == _target)
        _target = null;
    }

    public void OnDetectionAreaBodyEntered(object body)
    {
      if (body is AbstractMonster monster) _target = monster;
    }
  }
}