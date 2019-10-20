using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

static public class EventManager {

	static List<Block> addPointsInvokers = new List<Block>();
	static List<UnityAction<int>> addPointsListeners = new List <UnityAction<int>> ();
	static List<Ball> countBallsInvokers = new List<Ball> ();
	static List<UnityAction> countBallsListeners = new List<UnityAction> ();
	static List<Ball> spawnBallsInvokers = new List<Ball> ();
	static List<UnityAction> spawnBallsListeners = new List<UnityAction> ();
	static List<Block> blockDestroyedInvokers = new List<Block>();
	static List<UnityAction> blockDestroyedListeners = new List<UnityAction> ();
	static List<PickupBlock> freezerInvokers = new List<PickupBlock>(); 
	static List<UnityAction> freezerListeners = new List<UnityAction>();
	static List<PickupBlock> speedupInvokers = new List<PickupBlock>(); 
	static List<UnityAction> speedupListeners = new List<UnityAction>();
	static List<HUD> gameOverInvokers = new List<HUD>();
	static List<UnityAction> gameOverListeners = new List<UnityAction> ();

	//Freezer Event support
	public static void AddFreezerInvoker(PickupBlock script){
		freezerInvokers.Add(script);
		foreach (UnityAction listener in freezerListeners) {
			script.AddFreezerEffectListener (listener);
		}
	}

	public static void AddFreezerListener(UnityAction listener){
		freezerListeners.Add (listener);
		foreach (PickupBlock invoker in freezerInvokers){
			invoker.AddFreezerEffectListener (listener);
		}
	}

	// Speedup Event support
	public static void AddSpeedupInvoker(PickupBlock script){
		speedupInvokers.Add (script);
		foreach (UnityAction listener in speedupListeners) {
			script.AddSpeedupEffectListener (listener); 
		}
	}
		
	public static void AddSpeedupListener(UnityAction listener){
		speedupListeners.Add (listener);
		foreach (PickupBlock invoker in speedupInvokers) {
			invoker.AddSpeedupEffectListener (listener);
		}
	}

	// AddPoints event support
	public static void AddPointsInvoker (Block script){
		addPointsInvokers.Add (script);
		foreach (UnityAction<int> listener in addPointsListeners) {
			script.AddpointAddedListener (listener);
		}
	}

	public static void AddPointListener(UnityAction<int> listener){
		addPointsListeners.Add (listener);
		foreach (Block invoker in addPointsInvokers){
			invoker.AddpointAddedListener (listener);
		}
	}

	//Balls counting event support
	public static void AddCountBallsInvoker(Ball script){
		countBallsInvokers.Add (script);
		foreach (UnityAction listener in countBallsListeners) {
			script.AddCountBallsListener (listener);
		}
	}
		
	public static void AddCountBallsListener (UnityAction listener){
		countBallsListeners.Add(listener);
		foreach (Ball invoker in countBallsInvokers) {
			invoker.AddCountBallsListener(listener);
		}
	}

	// Spaw Balls event support
	public static void AddSpawnBallsListener(UnityAction listener){
		spawnBallsListeners.Add (listener);
		foreach (Ball invoker in spawnBallsInvokers) {
			invoker.AddSpawnBallsListener (listener);
		}
	}

	public static void AddSpawnBallsInvoker(Ball script){
		spawnBallsInvokers.Add (script);
		foreach (UnityAction listener in spawnBallsListeners){
			script.AddSpawnBallsListener (listener);
		}
	}

	public static void GameOverInvoker(HUD hud){
		gameOverInvokers.Add (hud);
		foreach (UnityAction listener in gameOverListeners) {
			hud.AddGameOverListener (listener);
		}
	}

	public static void GameOverListener(UnityAction listener){
		gameOverListeners.Add (listener);
		foreach (HUD invoker in gameOverInvokers) {
			invoker.AddGameOverListener (listener);
		}
	}

	public static void BlockDestroyedInvoker(Block script){
		blockDestroyedInvokers.Add (script);
		foreach (UnityAction listener in blockDestroyedListeners) {
			script.AddBlockDestroyedListener (listener);
		}
	}

	public static void BlockDestroyedListener(UnityAction listener){
		blockDestroyedListeners.Add (listener);
		foreach (Block invoker in blockDestroyedInvokers) {
			invoker.AddBlockDestroyedListener (listener);
		}
	}
}
