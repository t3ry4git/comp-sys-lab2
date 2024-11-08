﻿using comp_sys_lab2;
using Task = comp_sys_lab2.Task;

static (List<Task> tasks, List<Processor> processors) Process(List<Task> tasks, List<Processor> processors, List<int> table)
{
    foreach (var task in tasks)
    {
        int curStage = Convert.ToInt32(task.Stage) - 1;
        if (curStage != -1)
        {
            if (((task.ID > 0 && tasks[Convert.ToInt32(task.ID) - 1].Stage < 3) || task.ID == 0)
                && processors[table[curStage]].Target.Stub)
            {
                processors[table[curStage]].Target = task;
                task.Stage -= processors[table[curStage]].Performance;
            }
        }
    }
    return (tasks, processors);
}

// Set params
const int processorCount = 3;
int taskCount = 0;
uint tick = 0;
bool twoTables = false;
List<List<int>> tables = [];
// Variant 2
tables.Add([0, 0, 1, 2, 2, 0, 0, 2]);
// Variant 3
tables.Add([0, 1, 2, 2, 0, 1, 2, 0]);
Random random = new();

Console.Write("\nInput task count( > 0): ");
do
{
    taskCount = Convert.ToInt32(Console.ReadLine());
    if (taskCount <= 0)
        Console.WriteLine("Incorrect task count value, try again");
} while (taskCount <= 0);


ConsoleKey info = ConsoleKey.Help;
do
{
    Console.Write("\nUse two tables(y/n): ");
    info = Console.ReadKey().Key;
    if (info is not (ConsoleKey.N or ConsoleKey.Y))
        Console.WriteLine("Try again...");
} while (info is not (ConsoleKey.N or ConsoleKey.Y));
if (info == ConsoleKey.Y)
    twoTables = true;
Console.WriteLine();


// Create Processors
Task StubTask = new(0, 0, 0, true);
List<Processor> processors = [];
for (uint i = 0; i < processorCount; i++)
    processors.Add(new Processor(i, 1, StubTask));

//Create Tasks
List<Task> tasks = [];
for (uint i = 0; i < taskCount; i++)
    tasks.Add(new Task(i, 8, 8, false));


// Work-on
while (tasks.Count > 0 && !tasks.All(item => item.Stage == 0))
{
    (List<Task> tasks, List<Processor> processors) result;
    result = twoTables ? Process(tasks, processors, tables[random.Next(0, tables.Count)]) : Process(tasks, processors, tables[0]);

    Console.Write($" {tick} |");
    foreach (Processor processor in processors)
    {
        Console.Write("\t" + processor.ToString());
        processor.Target = StubTask;
    }
    Console.WriteLine();
    tick++;
}
Console.WriteLine($"Count of ticks: {tick}");

// Exit
do
    Console.WriteLine("\nPress Q to exit");
while (Console.ReadKey().Key != ConsoleKey.Q);

namespace comp_sys_lab2
{
    class Task(uint ID, uint Complexity, uint Stage, bool Stub)
    {
        public uint ID = ID;
        public uint Complexity = Complexity;
        public uint Stage = Stage;
        public bool Stub = Stub;
    }
    class Processor(uint ID, uint Performance, Task Target)
    {
        public uint ID = ID;
        public uint Performance = Performance;
        public Task Target = Target;

        public override string ToString() => !Target.Stub ? $"[{ID}|{Target.Stage}]" : $"[{ID}|-]";
    }
}