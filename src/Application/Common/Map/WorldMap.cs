// <copyright file="WorldMap.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp.Common.Map;

using ColliderApp.Common.Exceptions;
using ColliderApp.Common.Utils;


internal class WorldMap {
    private const char StartCharacter = 'S';
    private const char EndCharacter = 'E';
    private const char ObstacleCharacter = '#';

    private readonly int mapCode;
    private readonly string[] mapData;

    /// <summary>
    /// Initializes a new instance of the <see cref="WorldMap"/> class.
    /// </summary>
    /// <param name="mapCode"></param>
    /// <param name="mapData"></param>
    public WorldMap(
        int mapCode,
        string[] mapData) {

        this.mapCode = mapCode; // TODO: Validate
        this.mapData = mapData; // TODO: Validate
    }

    public int MapCode {
        get { return mapCode; }
    }

    public Point FindStartPosition() {
        int row = -1;
        int column = -1;

        while (column < 0 && (row + 1) < mapData.Length) {
            row += 1;
            column = mapData[row].IndexOf(StartCharacter);
        }

        if (column < 0) {
            throw new StartingPositionNotFoundException();
        }

        return new Point(column, row);
    }

    public bool EndingExistsAt(Point position) {
        return CharAt(position) == EndCharacter;
    }

    public bool ObstacleExistsAt(Point position) {
        return CharAt(position) == ObstacleCharacter;
    }

    public char CharAt(Point position) {
        return mapData[position.Y][position.X];
    }
}
