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

            string filePath = Path.Combine(FileSystem.AppDataDirectory, "recarga.txt");
            File.WriteAllText(filePath, recargaInfo);

            await DisplayAlert("Éxito", "Recarga realizada exitosamente", "OK");

            nameEntry.Text = string.Empty;
            phoneEntry.Text = string.Empty;

            spanchi_lastRecargaLabel.Text = $"Última recarga:\n{recargaInfo}";
            spanchi_lastRecargaLabel.IsVisible = true;
        }

        private void LoadLastRecarga()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "recarga.txt");

            if (File.Exists(filePath))
            {
                string lastRecarga = File.ReadAllText(filePath);
                spanchi_lastRecargaLabel.Text = $"Última recarga:\n{lastRecarga}";
                spanchi_lastRecargaLabel.IsVisible = true;
            }
            else
            {
                spanchi_lastRecargaLabel.Text = "No hay recargas anteriores.";
                spanchi_lastRecargaLabel.IsVisible = false;
            }
        }
    }
}






