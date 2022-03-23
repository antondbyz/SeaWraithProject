using UnityEngine;

public interface ISpawnable
{
    void Spawn(Vector2 position);

    void Disappear();
}
