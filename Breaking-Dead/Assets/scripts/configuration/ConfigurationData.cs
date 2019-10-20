using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

	StreamReader input;

    const string ConfigurationDataFileName = "ConfigurationData.csv";
	Dictionary<ConfigurationDataValueNames, float> values = new Dictionary<ConfigurationDataValueNames, float>();

    // configuration data
    float paddleMoveUnitsPerSecond = 8;
    float ballImpulseForce = 3;
	float ballLifetime = 10; 
	float ballDelay = 1;
	float minSpawnTime = 5;
	float maxSpawnTime = 10;
	int stdBlockPoint = 10; 
	int bonusBlockPoint = 100;
	int pickupBlockPoint = 1;
	float stdBlocks = 0.8f;
	float bonusBlocks = 0.1f;
	float pickupBlocks = 0.1f; 
	int ballsPerGame = 20;
	float freezeTime = 2;
	float speedupTime = 2;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
		get { return values[ConfigurationDataValueNames.paddleMoveUnitsPerSecond]; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
		get { return values[ConfigurationDataValueNames.ballImpulseForce]; }    
    }

	/// <summary>
	/// Gets the ball Lifetime.
	/// </summary>
	/// <value>The ball impulse force.</value>
	public float BallLifetime
	{
		get { return values[ConfigurationDataValueNames.ballLifetime]; }    
	}

	/// <summary>
	/// Gets the ball Delay.
	/// </summary>
	/// <value>The ball lifetime.</value>
	public float BallDelay
	{
		get { return values[ConfigurationDataValueNames.ballDelay]; }    
	}

	/// <summary>
	/// Gets the minimum spawn time.
	/// </summary>
	/// <value>The minimum spawn time.</value>
	public float MinSpawnTime
	{
		get { return values[ConfigurationDataValueNames.minSpawnTime]; }    
	}

	/// <summary>
	/// Gets the max spawn time.
	/// </summary>
	/// <value>The max spawn time.</value>
	public float MaxSpawnTime
	{
		get { return values[ConfigurationDataValueNames.maxSpawnTime]; }    
	}

	/// <summary>
	/// Gets the std block point.
	/// </summary>
	/// <value>The std block point.</value>
	public int StdBlockPoint
	{
		get { return (int)values[ConfigurationDataValueNames.stdBlockPoint]; }    
	}

	/// <summary>
	/// Gets the bonus block point.
	/// </summary>
	/// <value>The bonus block point.</value>
	public int BonusBlockPoint
	{
		get { return (int)values[ConfigurationDataValueNames.bonusBlockPoint]; }    
	}

	/// <summary>
	/// Gets the pickup block point.
	/// </summary>
	/// <value>The pickup block point.</value>
	public int PickupBlockPoint
	{
		get { return (int)values[ConfigurationDataValueNames.pickupBlockPoint]; }    
	}

	/// <summary>
	/// Gets the std blocks.
	/// </summary>
	/// <value>The std blocks.</value>
	public float StdBlocks {
		get { return values[ConfigurationDataValueNames.stdBlocks];}
	}

	/// <summary>
	/// Gets the bonus blocks.
	/// </summary>
	/// <value>The bonus blocks.</value>
	public float BonusBlocks {
		get { return values[ConfigurationDataValueNames.bonusBlocks]; }
	}

	/// <summary>
	/// Gets the pickup blocks.
	/// </summary>
	/// <value>The pickup blocks.</value>
	public float PickupBlocks {
		get { return values[ConfigurationDataValueNames.pickupBlocks]; }
	}

	/// <summary>
	/// Gets the balls per game.
	/// </summary>
	/// <value>The balls per game.</value>
	public int BallsPerGame
	{
		get { return (int)values[ConfigurationDataValueNames.ballsPerGame]; }    
	}

	/// <summary>
	/// Gets the freeze time.
	/// </summary>
	/// <value>The freeze time.</value>
	public float FreezeTime
	{
		get { return values[ConfigurationDataValueNames.freezeTime]; }    
	}

	/// <summary>
	/// Gets the speedup time.
	/// </summary>
	/// <value>The speedup time.</value>
	public float SpeedupTime
	{
		get { return values[ConfigurationDataValueNames.speedupTime]; }    
	}

	#endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
		SetDefault ();
//		try{
//			input = File.OpenText (Path.Combine (Application.streamingAssetsPath, ConfigurationDataFileName));
//			readInput();
//		} catch (Exception e){
//			
//			Debug.Log(e);
//		} finally {
//			if (input != null) {
//				input.Close ();
//			}
//		}
    }

	void readInput(){

		string currentLine = input.ReadLine ();
		while (currentLine != null) {
			string[] tokens = currentLine.Split (',');
			ConfigurationDataValueNames valueName = (ConfigurationDataValueNames)Enum.Parse (typeof(ConfigurationDataValueNames), tokens [0]);
			values.Add (valueName, float.Parse (tokens [1]));
			currentLine = input.ReadLine ();
		}
	}

	void SetDefault(){

		//foreach
		values.Clear();
		values.Add(ConfigurationDataValueNames.paddleMoveUnitsPerSecond, paddleMoveUnitsPerSecond);
		values.Add(ConfigurationDataValueNames.ballImpulseForce, ballImpulseForce);
		values.Add(ConfigurationDataValueNames.ballLifetime, ballLifetime);
		values.Add (ConfigurationDataValueNames.ballDelay, ballDelay);
		values.Add(ConfigurationDataValueNames.minSpawnTime, minSpawnTime);
		values.Add(ConfigurationDataValueNames.maxSpawnTime, maxSpawnTime);
		values.Add(ConfigurationDataValueNames.stdBlockPoint, stdBlockPoint);
		values.Add(ConfigurationDataValueNames.bonusBlockPoint, bonusBlockPoint);
		values.Add(ConfigurationDataValueNames.pickupBlockPoint, pickupBlockPoint);
		values.Add(ConfigurationDataValueNames.stdBlocks, stdBlocks);
		values.Add(ConfigurationDataValueNames.bonusBlocks, bonusBlocks);
		values.Add(ConfigurationDataValueNames.pickupBlocks, pickupBlocks);
		values.Add(ConfigurationDataValueNames.ballsPerGame, ballsPerGame);
		values.Add(ConfigurationDataValueNames.freezeTime, freezeTime);
		values.Add(ConfigurationDataValueNames.speedupTime, speedupTime);
	}

    #endregion
}
