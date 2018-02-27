using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Collections;

namespace sys_prog_hw1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum sortBy { id, name, threads};
        public MainWindow()
        {
            InitializeComponent();          
            AllProcess = Process.GetProcesses().ToList();
            AddElements(sortBy.id);
                   
        }

        static bool AscHandlerID = true;
        static bool AscHandlerName = true;
        static bool AscHandlerThreads = true;
        List<Process> AllProcess = new List<Process>();
        List<MyProcess> myProcesses = new List<MyProcess>();

        public void AddElements(sortBy s)
        {
            myProcesses = new List<MyProcess>();
            switch (s)
            {
                case sortBy.id:
                    if (AscHandlerID)
                    {
                        foreach (var item in AllProcess.OrderBy(p => p.Id))
                        {
                            myProcesses.Add(new MyProcess { IdProcess = item.Id, NameProcess = item.ProcessName, ThreadsCount = item.Threads.Count });
                        }
                        AscHandlerID = !AscHandlerID;
                    }
                    else
                    {
                        foreach (var item in AllProcess.OrderByDescending(p => p.Id))
                        {
                            myProcesses.Add(new MyProcess { IdProcess = item.Id, NameProcess = item.ProcessName, ThreadsCount = item.Threads.Count });
                        }
                        AscHandlerID = !AscHandlerID;
                    }
                    break;
                case sortBy.name:
                    if (AscHandlerName)
                    {
                        foreach (var item in AllProcess.OrderBy(p => p.ProcessName))
                        {
                            myProcesses.Add(new MyProcess { IdProcess = item.Id, NameProcess = item.ProcessName, ThreadsCount = item.Threads.Count });
                        }
                        AscHandlerName = !AscHandlerName;
                    }
                    else
                    {
                        foreach (var item in AllProcess.OrderByDescending(p => p.ProcessName))
                        {
                            myProcesses.Add(new MyProcess { IdProcess = item.Id, NameProcess = item.ProcessName, ThreadsCount = item.Threads.Count });
                        }
                        AscHandlerName = !AscHandlerName;
                    }
                    break;
                case sortBy.threads:
                    if (AscHandlerThreads)
                    {
                        foreach (var item in AllProcess.OrderBy(p => p.Threads.Count))
                        {
                            myProcesses.Add(new MyProcess { IdProcess = item.Id, NameProcess = item.ProcessName, ThreadsCount = item.Threads.Count });
                        }
                        AscHandlerThreads = !AscHandlerThreads;
                    }
                    else
                    {
                        foreach (var item in AllProcess.OrderByDescending(p => p.Threads.Count))
                        {
                            myProcesses.Add(new MyProcess { IdProcess = item.Id, NameProcess = item.ProcessName, ThreadsCount = item.Threads.Count });
                        }
                        AscHandlerThreads = !AscHandlerThreads;
                    }
                    break;
                default:
                    break;
            }
            for (int i = 0; i < myProcesses.Count; i++)
            {
                this.ProcessHandler.Items.Add(myProcesses[i]);
            }            
        }

        private void IdClick(object sender, RoutedEventArgs e)
        {
            this.ProcessHandler.Items.Clear();
            AddElements(sortBy.id);
        }
        private void NameClick(object sender, RoutedEventArgs e)
        {
            this.ProcessHandler.Items.Clear();
            AddElements(sortBy.name);
        }

        private void ThreadsClick(object sender, RoutedEventArgs e)
        {
            this.ProcessHandler.Items.Clear();
            AddElements(sortBy.threads);
        }
    }
}
