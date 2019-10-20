using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
	#region fields

	public static ConfigurationData configurationData;

	#endregion

	#region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
		get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

	/// <summary>
	/// Gets the ball impulse force.
	/// </summary>
	/// <value>The ball impulse force.</value>
	public static float BallImpulseForce
	{
		get { return configurationData.BallImpulseForce; }
	}

	/// <summary>
	/// Gets the ball lifetime.
	/// </summary>
	/// <value>The ball lifetime.</value>
	public static float BallLifetime
	{
		get { return configurationData.BallLifetime; }
	}

	/// <summary>
	/// Gets the ball lifetime.
	/// </summary>
	/// <value>The ball lifetime.</value>
	public static float BallDelay
	{
		get { return configurationData.BallDelay; }
	}

	/// <summary>
	/// Gets the minimum spawntime.
	/// </summary>
	/// <value>The minimum spawntime.</value>
	public static float MinSpawntime
	{
		get { return configurationData.MinSpawnTime; }
	}

	/// <summary>
	/// Gets the max spawn time.
	/// </summary>
	/// <value>The max spawn time.</value>
	public static float MaxSpawnTime
	{
		get { return configurationData.MaxSpawnTime; }
	}

	/// <summary>
	/// Gets the std block point.
	/// </summary>
	/// <value>The std block point.</value>
	public static int StdBlockPoint
	{
		get { return configurationData.StdBlockPoint; }
	}

	/// <summary>
	/// Gets the bonus block point.
	/// </summary>
	/// <value>The bonus block point.</value>
	public static int BonusBlockPoint
	{
		get { return configurationData.BonusBlockPoint; }
	}

	/// <summary>
	/// Gets the pickup block point.
	/// </summary>
	/// <value>The pickup block point.</value>
	public static int PickupBlockPoint
	{
		get { return configurationData.PickupBlockPoint; }
	}

	/// <summary>
	/// Gets the balls per game.
	/// </summary>
	/// <value>The balls per game.</value>
	public static int BallsPerGame
	{
		get { return configurationData.BallsPerGame; }
	}

	/// <summary>
	/// Gets the freeze time.
	/// </summary>
	/// <value>The freeze time.</value>
	public static float FreezeTime
	{
		get { return configurationData.FreezeTime; }
	}

	public static float SpeedupTime
	{
		get { return configurationData.SpeedupTime; }
	}


	#endregion
    
	#region methods
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
		configurationData = new ConfigurationData();
    }

	#endregion

}
