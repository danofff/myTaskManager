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
    /// 

    public partial class MainWindow : Window
    {
        public enum sortBy { id, name, threads, memory};
        public MainWindow()
        {
            InitializeComponent();          
            AllProcess = Process.GetProcesses().ToList();
            AddElements(sortBy.id);            
        }

        static bool AscHandlerID = true;
        static bool AscHandlerName = true;
        static bool AscHandlerThreads = true;
        static bool AscHandlerMemory = true;
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
                            myProcesses.Add(new MyProcess { IdProcess = item.Id, NameProcess = item.ProcessName, ThreadsCount = item.Threads.Count,Memory=item.WorkingSet64/1024 });
                        }
                        AscHandlerID = !AscHandlerID;
                    }
                    else
                    {
                        foreach (var item in AllProcess.OrderByDescending(p => p.Id))
                        {
                            myProcesses.Add(new MyProcess { IdProcess = item.Id, NameProcess = item.ProcessName, ThreadsCount = item.Threads.Count, Memory = item.WorkingSet64 / 1024 });
                        }
                        AscHandlerID = !AscHandlerID;
                    }
                    break;
                case sortBy.name:
                    if (AscHandlerName)
                    {
                        foreach (var item in AllProcess.OrderBy(p => p.ProcessName))
                        {
                            myProcesses.Add(new MyProcess { IdProcess = item.Id, NameProcess = item.ProcessName, ThreadsCount = item.Threads.Count, Memory = item.WorkingSet64 / 1024 });
                        }
                        AscHandlerName = !AscHandlerName;
                    }
                    else
                    {
                        foreach (var item in AllProcess.OrderByDescending(p => p.ProcessName))
                        {
                            myProcesses.Add(new MyProcess { IdProcess = item.Id, NameProcess = item.ProcessName, ThreadsCount = item.Threads.Count, Memory = item.WorkingSet64 / 1024 });
                        }
                        AscHandlerName = !AscHandlerName;
                    }
                    break;
                case sortBy.threads:
                    if (AscHandlerThreads)
                    {
                        foreach (var item in AllProcess.OrderBy(p => p.Threads.Count))
                        {
                            myProcesses.Add(new MyProcess { IdProcess = item.Id, NameProcess = item.ProcessName, ThreadsCount = item.Threads.Count, Memory = item.WorkingSet64 / 1024 });
                        }
                        AscHandlerThreads = !AscHandlerThreads;
                    }
                    else
                    {
                        foreach (var item in AllProcess.OrderByDescending(p => p.Threads.Count))
                        {
                            myProcesses.Add(new MyProcess { IdProcess = item.Id, NameProcess = item.ProcessName, ThreadsCount = item.Threads.Count, Memory = item.WorkingSet64 / 1024 });
                        }
                        AscHandlerThreads = !AscHandlerThreads;
                    }
                    break;
                case sortBy.memory:
                    if (AscHandlerMemory)
                    {
                        foreach (var item in AllProcess.OrderBy(p => p.WorkingSet64))
                        {
                            myProcesses.Add(new MyProcess { IdProcess = item.Id, NameProcess = item.ProcessName, ThreadsCount = item.Threads.Count, Memory = item.WorkingSet64 / 1024 });
                        }
                        AscHandlerMemory = !AscHandlerMemory;
                    }
                    else
                    {
                        foreach (var item in AllProcess.OrderByDescending(p => p.WorkingSet64))
                        {
                            myProcesses.Add(new MyProcess { IdProcess = item.Id, NameProcess = item.ProcessName, ThreadsCount = item.Threads.Count, Memory = item.WorkingSet64 / 1024 });
                        }
                        AscHandlerMemory=!AscHandlerMemory;
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
        private void MemoryClick(object sender, RoutedEventArgs e)
        {
            this.ProcessHandler.Items.Clear();
            AddElements(sortBy.memory);
        }
        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            string findProcessName = FindTextBox.Text;
            if (String.IsNullOrEmpty(findProcessName))
            {
                MessageBox.Show("You didn't write process name");
            }
            else
            {
                for (int i = 0; i < ProcessHandler.Items.Count; i++)
                {
                    if (findProcessName.ToLower() == ((MyProcess)ProcessHandler.Items[i]).NameProcess.ToLower())
                    {
                        ProcessHandler.SelectedItem = ProcessHandler.Items[i];
                        ProcessHandler.ScrollIntoView(ProcessHandler.Items[i]);
                        ProcessHandler.Focus();
                        break;
                    }
                } 
            }                   
        }
        private void Kill_process_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Do you really want kill process?","Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            MyProcess pr = (MyProcess)ProcessHandler.SelectedItem;
            if (res == MessageBoxResult.Yes)
            {
                for (int i = 0; i < AllProcess.Count; i++)
                {
                    if (pr.IdProcess == AllProcess[i].Id)
                    {
                        AllProcess[i].Kill();                      
                        ProcessHandler.Items.Remove(pr);
                    }
                }
            }
        }
    }
}