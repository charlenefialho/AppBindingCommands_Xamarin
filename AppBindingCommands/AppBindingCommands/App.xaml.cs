using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBindingCommands
{
    public partial class App : Application
    {
        public App()
        {
            //properties é possivel armazenar uma variel sem precisar declarar ela
            //é usada para o reuso da variavel no app
            InitializeComponent();
            DateTime data = DateTime.Now;
            Application.Current.Properties["dtAtual"] = data;
            Application.Current.Properties["AcaoInicial"] = string.Format(" * App executado às {0}. \n", data);

            MainPage = new MainPage(); //contrução/instancia da mainPage
        }

        protected override void OnStart()//execução principal
        {
            Application.Current.Properties["AcaoStart"] =
                string.Format(" * App iniciado às {0}. \n", DateTime.Now);
        }

        protected override void OnSleep() //segundo plano
        {
            Application.Current.Properties["AcaoSleep"] =
                string.Format(" * App em segundo plano às {0}. \n", DateTime.Now);
        }

        protected override void OnResume()//consegue voltar a coletar informações ao estado "on Start" ->voltar ao estado em que estava(reativar).
        {
            Application.Current.Properties["AcaoResume"] =
                string.Format(" * App reativado às {0}. \n", DateTime.Now);
        }
    }
}
