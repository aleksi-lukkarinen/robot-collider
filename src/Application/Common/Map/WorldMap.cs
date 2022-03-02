// <copyright file="WorldMap.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp;


internal class WorldMap {
    private const char CharStart = 'S';
    private const char CharEnd = 'E';
    private const char CharObstacle = '#';

    private readonly int mapCode;
    private readonly string[] mapData;

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
            column = mapData[row].IndexOf(CharStart);
        }

        if (column < 0) {
            throw new StartingPositionNotFoundException();
        }

        return new Point(column, row);
    }

    public bool EndingExistsAt(Point position) {
        return CharAt(position) == CharEnd;
    }

    public bool ObstacleExistsAt(Point position) {
        return CharAt(position) == CharObstacle;
    }

    public char CharAt(Point position) {
        return mapData[position.Y][position.X];
    }
}
