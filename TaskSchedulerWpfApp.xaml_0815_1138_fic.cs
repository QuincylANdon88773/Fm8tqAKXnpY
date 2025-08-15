// 代码生成时间: 2025-08-15 11:38:04
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TaskSchedulerWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<ScheduledTask> tasks = new List<ScheduledTask>();
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Schedules a new task to execute at a specified time.
        /// </summary>
        /// <param name="time">The time when the task should be executed.</param>
        /// <param name="action">The action to be performed when the task is executed.</param>
        private void ScheduleTask(DateTime time, Action action)
        {
            tasks.Add(new ScheduledTask(time, action));
        }

        /// <summary>
        /// Starts the task scheduler.
        /// </summary>
        private void StartScheduler()
        {
            cancellationTokenSource = new CancellationTokenSource();
            Task.Run(() => RunScheduler(cancellationTokenSource.Token));
        }

        /// <summary>
        /// Stops the task scheduler.
        /// </summary>
        private void StopScheduler()
        {
            cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// Runs the task scheduler in a loop, checking for any tasks that need to be executed.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the task if needed.</param>
        private void RunScheduler(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                foreach (var task in tasks.ToArray())
                {
                    if (task.IsTimeToExecute())
                    {
                        try
                        {
                            task.Execute();
                            tasks.Remove(task);
                        }
                        catch (Exception ex)
                        {
                            // Handle any exceptions that occur during task execution
                            Console.WriteLine($"Error executing task: {ex.Message}");
                        }
                    }
                }
                Thread.Sleep(1000); // Check every second
            }
        }
    }

    /// <summary>
    /// Represents a scheduled task with a specified execution time and action.
    /// </summary>
    public class ScheduledTask
    {
        public DateTime ExecutionTime { get; }
        public Action Action { get; }

        public ScheduledTask(DateTime executionTime, Action action)
        {
            ExecutionTime = executionTime;
            Action = action;
        }

        /// <summary>
        /// Checks if it's time to execute the task.
        /// </summary>
        /// <returns>True if it's time to execute, otherwise false.</returns>
        public bool IsTimeToExecute()
        {
            return DateTime.Now >= ExecutionTime;
        }

        /// <summary>
        /// Executes the task's action.
        /// </summary>
        public void Execute()
        {
            Action?.Invoke();
        }
    }
}
