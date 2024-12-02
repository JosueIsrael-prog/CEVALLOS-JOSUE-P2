using System;
using System.IO;

namespace CevallosJosueExamenP2
{
    public partial class RecargaTelefonicaPage : ContentPage
    {
        public RecargaTelefonicaPage()
        {
            InitializeComponent();
        }

        private async void OnRecargarClicked(object sender, EventArgs e)
        {
            // Validar los campos
            string numero = NumeroTelefono.Text;
            string nombre = NombreUsuario.Text;

            if (string.IsNullOrWhiteSpace(numero) || string.IsNullOrWhiteSpace(nombre))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

            // Guardar los datos en un archivo
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RecargaDatos.txt");
            File.WriteAllText(filePath, $"Nombre: {nombre}\nN�mero: {numero}");

            // Mostrar un mensaje de confirmaci�n
            await DisplayAlert("�xito", "La recarga fue exitosa.", "OK");

            // Actualizar la etiqueta con los datos
            UltimaRecargaLabel.Text = $"�ltima recarga:\nNombre: {nombre}\nN�mero: {numero}";

            // Limpiar los campos
            NumeroTelefono.Text = string.Empty;
            NombreUsuario.Text = string.Empty;
        }
    }
}