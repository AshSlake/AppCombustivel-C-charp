namespace AppCombustivel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //array com as marcas
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
            picker_marca.ItemsSource = marcas;
        }
        private void button_clicked(object sender, EventArgs e)
        {
            
            try
            {
                string marcaSelecionada = (string)picker_marca.SelectedItem;
                string modelo = txt_modelo.Text;
                double etanol = Convert.ToDouble(txt_etanol.Text);
                double gasolina = Convert.ToDouble(txt_gasolina.Text);

                string msg = "";

                if (etanol <= (gasolina * 0.7))
                {
                    msg = "O Etanol está compensando mais para seu " + marcaSelecionada + " " + modelo + ".";
                }
                else
                {
                    msg = "A Gasolina está compensando mais para seu " + marcaSelecionada + " " + modelo + ".";
                }

                DisplayAlert("Resultado", msg, "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }

}
