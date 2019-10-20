using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides screen utilities
/// </summary>
public static class ZombieSprites
{
	public static Dictionary<SpritesName, Sprite> sprites;

	public static void Initialize()
	{
		sprites = new Dictionary<SpritesName, Sprite> ();
		sprites.Add (SpritesName.z1, Resources.Load<Sprite> ("sprites/z1"));
		sprites.Add (SpritesName.z2, Resources.Load<Sprite> ("sprites/z2"));
		sprites.Add (SpritesName.z3, Resources.Load<Sprite> ("sprites/z3"));
		sprites.Add (SpritesName.z4, Resources.Load<Sprite> ("sprites/z4"));
		sprites.Add (SpritesName.z5, Resources.Load<Sprite> ("sprites/z5"));
	}


	/// <summary>
	/// Zombie sprites.
	/// </summary>
	public enum SpritesName {
		z1,
		z2,
		z3,
		z4,
		z5
	}
}