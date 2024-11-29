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

            // Aquí se genera el nombre del archivo basado en el nombre y apellido del usuario
            string fileName = $"{nombre.Replace(" ", "")}.txt"; // Ejemplo: SantiagoPanchi.txt
            string recargaInfo = $"Nombre: {nombre}\nTeléfono: {telefono}\nFecha: {DateTime.Now}";
            string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

            // Guardar información en el archivo
            File.WriteAllText(filePath, recargaInfo);

            // Mostrar mensaje de éxito
            await DisplayAlert("Éxito", "Recarga realizada exitosamente", "OK");

            // Recargar la página
            await Navigation.PushAsync(new MainPage());

            // Mostrar última recarga
            lastRecargaLabel.Text = $"Última recarga: {recargaInfo}";
            lastRecargaLabel.IsVisible = true;
        }
    }
}

