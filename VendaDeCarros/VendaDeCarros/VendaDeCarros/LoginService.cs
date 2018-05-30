using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VendaDeCarros.Models;
using Xamarin.Forms;

namespace VendaDeCarros
{
    public class LoginService
    {
        public async Task FazerLogin(Login login)
        {
            
                using (var client = new HttpClient())
                {
                    var camposFormulario = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("email", login.Email),
                        new KeyValuePair<string, string>("senha", login.Senha)
                    });
                    client.BaseAddress = new Uri("https://aluracar.herokuapp.com/login");

                HttpResponseMessage resultado = null;

                try
                {
                    resultado = await client.PostAsync("/login", camposFormulario);
                }
                catch
                {
                    MessagingCenter.Send<LoginException>(new LoginException("@Ocorreu um erro de comunicação com o servidor" +
                        "Por favor, verfique a sua conexão, e tente novamente mais tarde"), "FalhaLogin");

                }
                if (resultado.IsSuccessStatusCode)
                {
                    var conteudoResultado = await resultado.Content.ReadAsStringAsync();
                    ResultadoLogin result = JsonConvert.DeserializeObject<ResultadoLogin>(conteudoResultado);
                    MessagingCenter.Send<Usuario>(result.Usuario, "Sucesso");
                }
                else
                    MessagingCenter.Send<LoginException>(new LoginException("Usuario ou senha incorretos"), "FalhaLogin");
                }
            

        }
    }

    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {

        }
    }
}
