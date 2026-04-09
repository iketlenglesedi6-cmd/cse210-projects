using System;

class Program
{
    // Creativity:
    // Added a level system that awards a new level for each 1,000 points earned.
    // Added a milestone goal type that tracks progress toward a larger target and
    // awards points for each recorded amount plus a completion bonus at the end.
    // Added quest-style presentation with rank titles, achievement badges, and
    // a more game-like console interface to make progress feel more rewarding.
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
