﻿using PlayTrackWPF.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
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

namespace PlayTrackWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            GetAuthors();
            GetCategorys();
            InitializeComponent();
        }

        public async Task<List<Author>> GetAuthors()
        {
            List<Author> list = new List<Author>();

            string getAuthorsUrl = "api/Authors/GetAuthors";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Realizar la solicitud
                    httpClient.BaseAddress = new Uri("https://localhost:7065/");
                   var response = await httpClient.GetFromJsonAsync<List<Author>>(getAuthorsUrl);
                   list = response.ToList();
                    cbAuthorId.ItemsSource = list;

                }
                catch (HttpRequestException ex)
                {
                    // Si se produce una excepción, manejar el error según corresponda
                    txtResponse.Content = $"Error: {ex.Message}";
                    txtResponse.Visibility = Visibility.Visible;
                }
            }

            return list;
        }

        public async Task<List<Category>> GetCategorys()
        {
            List<Category> list = new List<Category>();

            string getCategorysUrl = "api/Categorys/GetCategorys";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Realizar la solicitud
                    httpClient.BaseAddress = new Uri("https://localhost:7065/");
                    var response = await httpClient.GetFromJsonAsync<List<Category>>(getCategorysUrl);
                    list = response.ToList();
                    cbCategoryId.ItemsSource = list;

                }
                catch (HttpRequestException ex)
                {
                    // Si se produce una excepción, manejar el error según corresponda
                    txtResponse.Content = $"Error: {ex.Message}";
                    txtResponse.Visibility = Visibility.Visible;
                }
            }

            return list;
        }
        private async void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            //construir modelo
            Book book = new Book
            {
                LibroID = Convert.ToInt16(txtId.Text),
                Titulo = txtTitle.Text,
                AutorID = 2,
                CategoriaID = 2,
                AnioPublicacion = Convert.ToInt16(txtPublishYear.Text),
            };

            string jsonBody = JsonSerializer.Serialize(book);
            //cambiar url dependiendo el el puerto del localhost
            string addBookUrl = "https://localhost:7065/api/Books/Add";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Realizar la solicitud
                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    // Realizar la solicitud POST y obtener la respuesta
                    HttpResponseMessage response = await httpClient.PostAsync(addBookUrl, content);

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        txtResponse.Content = jsonResponse;
                        txtResponse.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        // Si la solicitud no fue exitosa, manejar el error según corresponda
                        // Por ejemplo, mostrar el código de estado en un TextBox llamado txtResponse:
                        txtResponse.Content = $"Error: {response.StatusCode}";
                        txtResponse.Visibility = Visibility.Visible;
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Si se produce una excepción, manejar el error según corresponda
                    txtResponse.Content = $"Error: {ex.Message}";
                    txtResponse.Visibility = Visibility.Visible;
                }
            }
            txtResponse.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BooksList booksList = new BooksList();
            booksList.Show();
        }
    }
}
