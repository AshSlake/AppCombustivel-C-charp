
namespace AppCombustivel
{
    // Classe principal da página, herda de ContentPage (estrutura básica de uma página no MAUI/Xamarin)
    public partial class MainPage : ContentPage
    {
        // Construtor da MainPage, executado ao iniciar a página
        public MainPage()
        {
            InitializeComponent(); // Inicializa os componentes visuais definidos no XAML

            // Criação de uma lista de marcas de carro para popular o Picker (lista suspensa)
            // Usar um array ou lista facilita a manutenção e adição de novas marcas
            List<string> marcas = new List<string>
            {
                "Chevrolet",
                "Ford",
                "Fiat",
                "Volkswagen",
                "Honda",
                "Toyota",
                "Nissan",
                "Hyundai",
                "Kia",
                "Renault"
            };

            // Define a lista de marcas como fonte de dados do Picker chamado 'picker_marca'
            picker_marca.ItemsSource = marcas;
        }

        // Evento acionado quando o botão da interface é clicado
        private void button_clicked(object sender, EventArgs e)
        {
            try
            {
                // Obtém a marca selecionada pelo usuário no Picker
                string marcaSelecionada = (string)picker_marca.SelectedItem;

                // Obtém o modelo do carro informado pelo usuário
                string modelo = txt_modelo.Text;

                // Tratamento de erro caso o usuario não use valores numericos
                if (!double.TryParse(txt_etanol.Text, out double etanol))
                {
                    DisplayAlert("Erro", "Por favor, insira um valor numérico válido para o preço do etanol.", "OK");
                    return;
                }
                if (!double.TryParse(txt_gasolina.Text, out double gasolina))
                {
                    DisplayAlert("Erro", "Por favor, insira um valor numérico válido para o preço da gasolina.", "OK");
                    return;
                }

                string msg = "";

                // Lógica para determinar qual combustível é mais vantajoso
                // Se o preço do etanol for menor ou igual a 70% do preço da gasolina, compensa usar etanol
                if (etanol <= (gasolina * 0.7))
                {
                    msg = "O Etanol está compensando mais para seu " + marcaSelecionada + " " + modelo + ".";
                }
                else
                {
                    msg = "A Gasolina está compensando mais para seu " + marcaSelecionada + " " + modelo + ".";
                }

                // Exibe uma mensagem de alerta com o resultado para o usuário
                DisplayAlert("Resultado", msg, "OK");
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro caso ocorra alguma exceção (como valor inválido nos campos)
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
