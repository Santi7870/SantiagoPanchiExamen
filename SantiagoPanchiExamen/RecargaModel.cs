using Microsoft.Maui.Controls;

namespace SantiagoPanchiExamen
{
    public class RecargaModel : BindableObject
    {
        private string _ultimaRecarga;

        public string UltimaRecarga
        {
            get => _ultimaRecarga;
            set
            {
                _ultimaRecarga = value;
                OnPropertyChanged(); 
            }
        }
    }
}


