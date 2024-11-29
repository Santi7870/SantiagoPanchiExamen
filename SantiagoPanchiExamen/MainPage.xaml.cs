using System;
using System.IO;
using Microsoft.Maui.Controls;
using SantiagoPanchiExamen; 

namespace SantiagoPanchiExamen
{
    public partial class MainPage : ContentPage
    {
        private RecargaModel _recargaModel;

        public MainPage()
        {
            InitializeComponent();

            _recargaModel = new RecargaModel();

            BindingContext = _recargaModel;

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

            string filePath = Path.Combine(FileSystem.AppDataDirectory, "SantiagoPanchi.txt");
            File.WriteAllText(filePath, recargaInfo); 

            await DisplayAlert("Éxito", "Recarga realizada exitosamente", "OK");

            nameEntry.Text = string.Empty;
            phoneEntry.Text = string.Empty;

            _recargaModel.UltimaRecarga = recargaInfo;
        }

        private void LoadLastRecarga()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "SantiagoPanchi.txt");

            if (File.Exists(filePath))
            {
                string lastRecarga = File.ReadAllText(filePath);

                _recargaModel.UltimaRecarga = lastRecarga;
            }
            else
            {
                _recargaModel.UltimaRecarga = "No hay recargas anteriores.";
            }
        }
    }
}







