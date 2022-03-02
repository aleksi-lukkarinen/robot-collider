namespace ColliderApp {
    using System.IO;
    using System.Reflection;

    class MaximumStepsExceededException : Exception {
        public MaximumStepsExceededException(int maxAllowedSteps) 
            : base(CreateMessage(maxAllowedSteps)) { }

        private static String CreateMessage(int maxAllowedSteps) {
            return $"Invalid map: Maximum number of steps ({maxAllowedSteps}) exceeded during walk.";
        }
    }

    class StartingPositionNotFoundException : Exception {
        public StartingPositionNotFoundException()
            : base("Invalid map: Starting position was not found.") { }
    }

    public enum Direction {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3,
    };

    interface ITurningStrategy {
        Direction NextDirection(Direction currentDirection);
    }

    class RightTurnStrategy : ITurningStrategy {
        public Direction NextDirection(Direction currentDirection) {
            return currentDirection switch {
                Direction.Up => Direction.Right,
                Direction.Right => Direction.Down,
                Direction.Down => Direction.Left,
                _ => Direction.Up,
            };
        }
    }

    class Point {
        public Point(int x, int y) {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public Point Next(Direction direction) {
            return direction switch {
                Direction.Up => new Point(X, Y - 1),
                Direction.Right => new Point(X + 1, Y),
                Direction.Down => new Point(X, Y + 1),
                Direction.Left => new Point(X - 1, Y),

                _ => throw new NotImplementedException(),
            };
        }

        public override string ToString() {
            return $"({X}, {Y})";
        }
    }

    class Robot {
        private Robot(
            int steps,
            Point position, 
            Direction direction) {

            Steps = steps;
            Position = position;
            Direction = direction;
        }

        public Robot Advance() {
            int newSteps = Steps + 1;
            Point newPosition = Position.Next(Direction);

            return new Robot(newSteps, newPosition, Direction);
        }

        public Robot TurnTo(Direction newDirection) {
            return new Robot(Steps, Position, newDirection);
        }

        public override string ToString() {
            return $"[Robot: {Steps}, {Position}, {Direction}]";
        }

        public int Steps { get; }
        public Point Position { get; }
        public Direction Direction { get; }

        public static Robot Create(
            Point position, 
            Direction direction) {

            return new Robot(
                steps: 0, 
                position, 
                direction);
        }
    }

    class Collider {
        private const int MaxAllowedSteps = 999;

        private readonly WorldMap map;
        private readonly Direction startDirection;
        private readonly ITurningStrategy turningStrategy;

        private Robot robot;

        private readonly TextWriter outputStram;

        public Collider(
            WorldMap map,
            Direction startDirection,
            ITurningStrategy turningStrategy,
            TextWriter outputStram) {

            this.map = map;
            this.startDirection = startDirection;
            this.turningStrategy = turningStrategy;
            this.robot = NewRobot();

            this.outputStram = outputStram;
        }

        public void Execute() {
            CreateNewRobot();
            Walk();
            PrintResults();
        }

        private void CreateNewRobot() {
            robot = NewRobot();
        }

        private Robot NewRobot() {
            return Robot.Create(
                map.FindStartPosition(),
                startDirection);
        }

        private void Walk() {
            while (robot.Steps <= MaxAllowedSteps) {
                if (map.EndingExistsAt(robot.Position)) {
                    break;
                }

                outputStram.WriteLine($"{robot} @ {map.CharAt(robot.Position)}");

                TurnIfNecessary();
                robot = robot.Advance();
            }
        }

        private void PrintResults() {
            if (robot.Steps > MaxAllowedSteps) {
                throw new MaximumStepsExceededException(MaxAllowedSteps);
            }

            outputStram.WriteLine($"{robot} @ {map.CharAt(robot.Position)}");
            outputStram.WriteLine();
            outputStram.WriteLine($"Answer: {map.MapCode}:{robot.Steps}");
        }

        private void TurnIfNecessary() {
            if (NextPositionIsObstacle()) {
                Direction nextDirection = turningStrategy.NextDirection(robot.Direction);
                robot = robot.TurnTo(nextDirection);
            }
        }

        private bool NextPositionIsObstacle() {
            Point nextPosition = robot.Position.Next(robot.Direction);
            return map.ObstacleExistsAt(nextPosition);
        }
    }

    class WorldMap {
        private const char CharStart = 'S';
        private const char CharEnd = 'E';
        private const char CharObstacle = '#';

        private readonly int mapCode;
        private readonly String[] mapData;

        public WorldMap(
            int mapCode, 
            string[] mapData) {

            this.mapCode = mapCode; // TODO: Validate
            this.mapData = mapData; // TODO: Validate
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

        public Boolean EndingExistsAt(Point position) {
            return CharAt(position) == CharEnd;
        }

        public Boolean ObstacleExistsAt(Point position) {
            return CharAt(position) == CharObstacle;
        }

        public int MapCode {
            get { return mapCode; }
        }

        public char CharAt(Point position) {
            return mapData[position.Y][position.X];
        }
    }

    class MapDataLoader {
        private readonly string relativePathToMapDataFile;

        public MapDataLoader(string relativePathToMapDataFile) {
            this.relativePathToMapDataFile = relativePathToMapDataFile;
        }

        public WorldMap Load() {
            // TODO: Check the existence of and the access rights to the data file

            Assembly assembly = Assembly.GetExecutingAssembly();

            string? assemblyPath = Path.GetDirectoryName(assembly.Location);
            if (assemblyPath == null) {
                assemblyPath = string.Empty;
            }

            string fullPath = Path.Combine(assemblyPath, relativePathToMapDataFile);

            string[] lines = File.ReadAllLines(fullPath);

            // TODO: Validate the content of the data file

            int mapCode = int.Parse(lines.First().Trim());
            string[] mapContent = 
                lines.Skip(1).Select(s => s.Trim()).Where(s => s.Length > 0).ToArray();

            return new(mapCode, mapContent);
        }
    }

    public class App {
        const int RetValFailure = 1;

        public static void Main() {
            string DataFileName = @"Data\MapData.txt";
            Direction startDirection = Direction.Up;
            ITurningStrategy turningStrategy = new RightTurnStrategy();
            TextWriter outputStram = Console.Out;
            TextWriter errorStram = Console.Error;

            try {
                MapDataLoader mapDataLoader = new(DataFileName);
                WorldMap map = mapDataLoader.Load();
                Collider collider = new(map, startDirection, turningStrategy, outputStram);

                collider.Execute();
            }
            catch (Exception e) {
                if (e is MaximumStepsExceededException 
                    || e is StartingPositionNotFoundException) {

                    errorStram.WriteLine(e.Message);
                    Environment.Exit(RetValFailure);
                }

                throw;
            }
        }
    }
}