public (bool, Vector3) CanClimb()
{
    if (falling) return (false, new Vector3());

    var scale = GetScale();
    var origin = new Vector3(
                          transform.position.x + scale * (boxCollider.bounds.extents.x - 2 * Eps),
                          transform.position.y - boxCollider.bounds.extents.y / 2,
                          transform.position.z);
    var direction = Vector3.right * scale;
    var maxDistance = boxCollider.bounds.size.x;

    RaycastHit obstacle;
    var collides = UnityEngine.Physics.Raycast(
                      origin, 
                      Vector3.right * scale, 
                      out obstacle, 
                      boxCollider.bounds.size.x);
    if (!collides) return (false, new Vector3())

    var hit = obstacle.collider;
    var lower = hit.bounds.max.y 
                < (boxCollider.bounds.center.y + boxCollider.bounds.extents.y / 2);
    if (!lower) return (false, new Vector3());

    var busy = UnityEngine.Physics.Raycast(
                    hit.bounds.center.WithY(hit.bounds.max.y),
                    Vector3.up,
                    boxCollider.bounds.size.y);
    if (busy) return (false, new Vector3());

    var target = new Vector3(
                    transform.position.x + scale * boxCollider.bounds.size.x,
                    hit.bounds.max.y + boxCollider.bounds.extents.y,
                    transform.position.z
      );
    return (true, target);
}
