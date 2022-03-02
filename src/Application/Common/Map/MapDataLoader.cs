// <copyright file="MapDataLoader.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp;

using System.IO;
using System.Reflection;


internal class MapDataLoader {
    private readonly string relativePathToMapDataFile;

    /// <summary>
    /// Initializes a new instance of the <see cref="MapDataLoader"/> class.
    /// </summary>
    /// <param name="relativePathToMapDataFile"></param>
    public MapDataLoader(string relativePathToMapDataFile) {
        this.relativePathToMapDataFile = relativePathToMapDataFile;
    }

    public WorldMap Load() {
        /* TODO: Check the existence of and the access rights to the data file */

        Assembly assembly = Assembly.GetExecutingAssembly();

        string? assemblyPath = Path.GetDirectoryName(assembly.Location);
        if (assemblyPath == null) {
            assemblyPath = string.Empty;
        }

        string fullPath = Path.Combine(assemblyPath, relativePathToMapDataFile);

        string[] lines = File.ReadAllLines(fullPath);

        /* TODO: Validate the content of the data file */

        int mapCode = int.Parse(lines.First().Trim());
        string[] mapContent =
            lines.Skip(1).Select(s => s.Trim()).Where(s => s.Length > 0).ToArray();

        return new(mapCode, mapContent);
    }
}
