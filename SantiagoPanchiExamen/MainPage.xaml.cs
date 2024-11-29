using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace SantiagoPanchiExamen
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadLastRecarga();
        }

        private async void OnRecargaButtonClicked(object sender, EventArgs e)
        {
            string nombre = nameEntry.Text;
            string telefono = phoneEntry.Text;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono))
            {
                await DisplayAlert("Error", "Por favor, ingrese nombre y teléfono.", "OK");
                return;
            }

            string recargaInfo = $"Nombre: {nombre}\nTeléfono: {telefono}\nFecha: {DateTime.Now}\n";

            string filePath = Path.Combine(FileSystem.AppDataDirectory, "recargas.txt");
            File.AppendAllText(filePath, recargaInfo);

            await DisplayAlert("Éxito", "Recarga realizada exitosamente", "OK");

            lastRecargaLabel.Text = $"Última recarga:\n{recargaInfo}";
            lastRecargaLabel.IsVisible = true;

            LoadAllRecargas();
        }

        private void LoadLastRecarga()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "recargas.txt");

            if (File.Exists(filePath))
            {
                string allRecargas = File.ReadAllText(filePath);
                lastRecargaLabel.Text = $"Última recarga:\n{allRecargas}";
                lastRecargaLabel.IsVisible = true;
            }
            else
            {
                lastRecargaLabel.Text = "No hay recargas anteriores.";
                lastRecargaLabel.IsVisible = false;
            }
        }

        private void LoadAllRecargas()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "recargas.txt");

            if (File.Exists(filePath))
            {
                string allRecargas = File.ReadAllText(filePath);
                lastRecargaLabel.Text = $"Historial de recargas:\n{allRecargas}";
                lastRecargaLabel.IsVisible = true;
            }
            else
            {
                lastRecargaLabel.Text = "No hay recargas anteriores.";
                lastRecargaLabel.IsVisible = false;
            }
        }
    }
}



