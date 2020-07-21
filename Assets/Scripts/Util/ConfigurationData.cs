using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData {
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 200;
    static float lifetimeBall = 10;
    static float timeMinimunSpawn = 5;
    static float timeMaximunSpawn = 10;
    static int pointsStandarBlock = 2;
    static int pointsBonusBlock = 10;
    static int pointsPickupBlock = 5;
    static float probabilitiesStandarBlock = 50;
    static float probabilitiesBonusBlock = 75;
    static float probabilitiesFreezerBlock = 90;
    static float probabilitiesSpeedupBlock = 100;
    static int numberOfBallsPerGame = 20;
    static float durationEffectFreezer = 2;
    static float durationEffectSpeedup = 3;
    static float effectSpeedup = 2;

    #endregion

    #region Properties

    public float PaddleMoveUnitsPerSecond { get { return paddleMoveUnitsPerSecond; } }

    public float BallImpulseForce { get { return ballImpulseForce; } }

    public float LifetimeBall { get {return lifetimeBall; } }

    public float TimeMinimunSpawn { get {return timeMinimunSpawn; } }

    public float TimeMaximunSpawn { get {return timeMaximunSpawn; } }

    public int PointsStandarBlock { get {return pointsStandarBlock; } }

    public int PointsBonusBlock { get {return pointsBonusBlock; } }

    public int PointsPickupBlock { get {return pointsPickupBlock; } }

    public float ProbabilitiesStandarBlock { get { return probabilitiesStandarBlock; } }

    public float ProbabilitiesBonusBlock { get { return probabilitiesBonusBlock; } }

    public float ProbabilitiesFreezerBlock { get { return probabilitiesFreezerBlock; } }

    public float ProbabilitiesSpeedupBlock { get { return probabilitiesSpeedupBlock; } }

    public int NumberOfBallsPerGame { get {return numberOfBallsPerGame; } }

    public float DurationEffectFreezer { get { return durationEffectFreezer; } }

    public float DurationEffectSpeedup { get { return durationEffectSpeedup; } }

    public float EffectSpeedup { get { return effectSpeedup; } }
    
    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData() {
        StreamReader file = null;
        try
        {
            file = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            string names = file.ReadLine();
            string values = file.ReadLine();

            SetConfigurationDataFields(values);
        }
        catch (Exception) { }
        finally {
            if (file != null)
            {
                file.Close();
            }
        }
    }

    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    static void SetConfigurationDataFields(string csvValues)
    {
        string[] values = csvValues.Split(',');
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        lifetimeBall = float.Parse(values[2]);
        timeMinimunSpawn = float.Parse(values[3]);
        timeMaximunSpawn = float.Parse(values[4]);
        pointsStandarBlock = int.Parse(values[5]);
        pointsBonusBlock = int.Parse(values[6]);
        pointsPickupBlock = int.Parse(values[7]);
        probabilitiesStandarBlock = float.Parse(values[8]);
        probabilitiesBonusBlock = float.Parse(values[9]);
        probabilitiesFreezerBlock = float.Parse(values[10]);
        probabilitiesSpeedupBlock = float.Parse(values[11]);
        numberOfBallsPerGame = int.Parse(values[12]);
        durationEffectFreezer = float.Parse(values[13]);
        durationEffectSpeedup = float.Parse(values[14]);
        effectSpeedup = float.Parse(values[15]);
    }
    #endregion
}