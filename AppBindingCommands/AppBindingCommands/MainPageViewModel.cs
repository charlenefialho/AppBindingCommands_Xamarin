using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace AppBindingCommands
{
    public class MainPageViewModel : INotifyPropertyChanged  // : -> herança ou implementação de uma interface
    {
       // # region <nome> #endregion

        private string name = string.Empty; //CTRL, R + E

        string displayName = string.Empty;

        string displayMessage = string.Empty;

        //Declaração de variavel usando o ICommand que interliga as propiedades da MainPage
        public ICommand CountCommand { get; }

        public ICommand ShowMessageCommand { get; } //declaração de como se fosse um "botão"  futuramente definindo sua função
       
        public ICommand CleanCommand { get; }

        public ICommand OptionCommand { get; }

        //Instanciamento no construtor onde indica que a variavel criada no ICommand está relacionada nas propiedades da MainPage
        public MainPageViewModel()
        {
            ShowMessageCommand = new Command(ShowMessage);
            CountCommand = new Command(async () => await CountCharacteres());
            CleanCommand = new Command(async () => await CleanConfirmation());
            OptionCommand = new Command(async() => await ShowOptions());
        }

        public async Task ShowOptions()
        {
            string result;

            result = await Application.Current.MainPage.DisplayActionSheet("Seleção", "selecione uma opção: ", "Cancelar", "Limpar", "Contar Caracteres", "Exibir Saudação");

            if(result != null)
            {
                if (result.Equals("Limpar"))
                    await CleanConfirmation();

                if(result.Equals("Contar Caracteres"))
                    await CountCharacteres();

                if(result.Equals("Exibir Saudação"))
                   ShowMessage();
            }
        }

        public async Task CleanConfirmation()
        {
            if(await Application.Current.MainPage.DisplayAlert("Confirmação", "Confirmar limpeza dos dados?", "Yes", "No"))
            {
                Name = String.Empty;
                DisplayMessage = String.Empty;
                OnPropertyChanged(name);
                OnPropertyChanged(DisplayMessage);

                await Application.Current.MainPage.DisplayAlert("Informação", "Limpeza realizada com sucesso", "Ok");
            }
        }
        public async Task CountCharacteres()
        {
            string nameLenght = string.Format("Seu nome tem {0} Letras",name.Length);


            await Application.Current.MainPage.DisplayAlert("Informação", nameLenght, "Ok");
        }

        public void ShowMessage()
        {
            //using using Xamarin.Forms;
            string dataProperty = Application.Current.Properties["dtAtual"].ToString();

            DisplayMessage = $"Boa noite {name}. Hoje é  {dataProperty}.";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

       

        //public string DisplayMessage { get => displayMessage; set => displayMessage = value; }
        //ou 
        public string DisplayMessage
        {
            get => displayMessage;
            set
            {
                if (displayMessage == null)
                    return;

                displayMessage = value;
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        //identação Ctrl, K + D
        public string Name
        {
            get { return name; }   //get { return name;} = get => name;
            //set => name = value; 
            set
            {
                if (name == null)
                    return;
                name = value;
                OnPropertyChanged(nameof(Name));//nameof -> sinatxe para indicar qual propiedade vai modificar
                OnPropertyChanged(nameof(DisplayName));//OnPropertyChanged -> Para exibir/indicar a alteração do valor do atrbuto para exibir na tela
            }
        }


        public string DisplayName => $"Nome digitado: {Name}"; // Atalho: prop [TAB] + [TAB]

        
    }
}
