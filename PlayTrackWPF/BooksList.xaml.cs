using PlayTrackWPF.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PlayTrackWPF
{
    /// <summary>
    /// Lógica de interacción para BooksList.xaml
    /// </summary>
    public partial class BooksList : Window
    {
        public BooksList()
        {
            GetBooks();
            InitializeComponent();
        }

        public async Task<List<Books>> GetBooks()
        {
            List<Books> list = new List<Books>();
            string getAuthorsUrl = "api/Books/GetBooks";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Realizar la solicitud
                    httpClient.BaseAddress = new Uri("https://localhost:7065/");
                    var response = await httpClient.GetFromJsonAsync<List<Books>>(getAuthorsUrl);
                    list = response.ToList();
                    bookList.ItemsSource = list;
                }
                catch (HttpRequestException ex)
                {
                }
            }
            return list;
        }
    }
}
