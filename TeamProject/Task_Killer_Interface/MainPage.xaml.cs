using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task_Killer;

namespace Task_Killer_Interface
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        User user = MainWindow.User;
        public Note note;
        private List<Task> tasks = new List<Task>();
        public MainPage()
        {
            InitializeComponent();
            UpdateNotes();
            UpdateTasks();
        }
    
        private void UpdateNotes()
        {
            notesBox.ItemsSource = null;
            notesBox.ItemsSource = user.Notes;
        }

        private void OnAddNoteClick(object sender, RoutedEventArgs e)
        {
            note = null;
            if (!string.IsNullOrEmpty(noteNameTextBox.Text))
            {
                Note newNote = new Note
                {
                    Name = noteNameTextBox.Text,
                    Text = noteTextBox.Text,
                    Creationdate = DateTime.Now
                };
                user.Notes.Add(newNote);
                MainWindow.Program.SaveDataJSON();
                UpdateNotes();
                Clear();
            }
            else
            {
                MessageBox.Show("Name is a required field", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void NotesBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (note != null) SaveNote();
            note = notesBox.SelectedItem as Note;
            noteTextBox.Text = note.Text;
            noteNameTextBox.Text = note.Name;
            UpdateNotes();
        }

        private void OnDeleteNoteClick(object sender, RoutedEventArgs e)
        {
            note = notesBox.SelectedItem as Note;
            user.Notes.Remove(note);
            Clear();
            MainWindow.Program.SaveDataJSON();
            UpdateNotes();
            note = null;
        }

        private void Clear()
        {
            noteTextBox.Clear();
            noteNameTextBox.Clear();
        }

        private void SaveNote()
        {
            note.Name = noteNameTextBox.Text;
            note.Text = noteTextBox.Text;
            note.Creationdate = DateTime.Now;
            MainWindow.Program.SaveDataJSON();
            note = null;
            Clear();
        }

        private void OnLogOutClick(object sender, RoutedEventArgs e)
        {
            if (note != null)
                SaveNote();
            MainWindow.User = null;
            Navigator.Default.Navigate(new Login());
        }

        private void OnNewTaskClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(taskTextBox.Text))
            {
                var task = new Task { DeadLine = DateTime.Now, IsDone = false, Text = taskTextBox.Text };
                user.Tasks.Add(task);
                MainWindow.Program.SaveDataJSON();
                UpdateTasks();
            }
        }

        private void TaskSource()
        {
            taskBox.ItemsSource = null;
            taskBox.ItemsSource = tasks;
        }

        private void UpdateTasks()
        {
            ClearList(tasks);
            if (startCalendar.SelectedDate == null && endCalendar.SelectedDate == null)
            {
                foreach (var task in user.Tasks)
                    tasks.Add(task);
                taskBox.ItemsSource = null;
                taskBox.ItemsSource = user.Tasks;
            }
            else 
            {
                if (startCalendar.SelectedDate == null && endCalendar.SelectedDate != null)
                {
                    foreach (var task in user.Tasks)
                        if (task.DeadLine.Date <= endCalendar.SelectedDate)
                            tasks.Add(task);
                    TaskSource();
                    return;
                }
                else if (endCalendar.SelectedDate == null && startCalendar.SelectedDate != null)
                {
                    foreach (var task in user.Tasks)
                        if (task.DeadLine.Date >= startCalendar.SelectedDate)
                            tasks.Add(task);
                    TaskSource();
                    return;
                }
                else
                {
                    foreach (var task in user.Tasks)
                        if (task.DeadLine.Date >= startCalendar.SelectedDate && task.DeadLine.Date <= endCalendar.SelectedDate)
                            tasks.Add(task);
                    TaskSource();
                    return;
                }
            }
        }
        
        private void ClearList(List<Task> list)
        {
            while (list.Count > 0)
            {
                list.RemoveAt(list.Count - 1);
            }
        }
        private void startCalendar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UpdateTasks();
        }

        private void endCalendar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UpdateTasks();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var task in tasks)
                if (task.IsDone == true)
                    user.Tasks.Remove(task);
            UpdateTasks();
        }
    }
}
