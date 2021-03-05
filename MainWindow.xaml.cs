using Newtonsoft.Json;
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
using System.ComponentModel;
using TodoList.Классы;

namespace TodoList
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";
        private BindingList<TodoModel> todoDataList;
        private FileIOService fileIOService;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fileIOService = new FileIOService(PATH);
            try
            {
                todoDataList = fileIOService.Load_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            
            // подключаем источник инфы
            dgTodoList.ItemsSource = todoDataList;
            todoDataList.ListChanged += TodoList_ListChanged;
        }

        private void TodoList_ListChanged(object sender, ListChangedEventArgs e)
        {
            //  изменения вводтя только при изменения , добавление или удаления строк
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted ||
                e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    fileIOService.Save_Data(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
            
        }
    }
}
