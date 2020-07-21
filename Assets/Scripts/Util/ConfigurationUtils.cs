using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils {
    static ConfigurationData configurationData;
    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond { get { return configurationData.PaddleMoveUnitsPerSecond; } }

    public static float BallImpulseForce { get { return configurationData.BallImpulseForce; } }

    public static float LifetimeBall { get { return configurationData.LifetimeBall; } }

    public static float TimeMinimunSpawn { get { return configurationData.TimeMinimunSpawn; } }

    public static float TimeMaximunSpawn { get { return configurationData.TimeMaximunSpawn; } }

    public static int PointsStandarBlock { get { return configurationData.PointsStandarBlock; } }

    public static int PointsBonusBlock { get { return configurationData.PointsBonusBlock; } }

    public static int PointsPickupBlock { get { return configurationData.PointsPickupBlock; } }

    public static float ProbabilitiesStandarBlock { get { return configurationData.ProbabilitiesStandarBlock; } }

    public static float ProbabilitiesBonusBlock { get { return configurationData.ProbabilitiesBonusBlock; } }

    public static float ProbabilitiesFreezerBlock { get { return configurationData.ProbabilitiesFreezerBlock; } }

    public static float ProbabilitiesSpeedupBlock { get { return configurationData.ProbabilitiesSpeedupBlock; } }

    public static int NumberOfBallsPerGame { get { return configurationData.NumberOfBallsPerGame; } }

    public static float DurationEffectFreezer { get { return configurationData.DurationEffectFreezer; } }

    public static float DurationEffectSpeedup { get { return configurationData.DurationEffectSpeedup; } }
    
    public static float EffectSpeedup { get { return configurationData.EffectSpeedup; } }

    #endregion Properties

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize() {
        configurationData = new ConfigurationData();
    }

}