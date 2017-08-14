using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Caelum.Stella.CSharp.Http;

namespace ConsultaCEP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o CEP:");
            string cep = Console.ReadLine();
            string result = GetEndereco(cep);

            var endereco = new ViaCEP().GetEndereco(cep);
            Console.WriteLine(string.Format("CEP: {0}, Logradouro: {1}",endereco.CEP, endereco.Logradouro));
            Console.WriteLine(string.Format("Complemento: {0}, Bairro: {1}", endereco.Complemento, endereco.Bairro));
            Console.WriteLine(string.Format("Cidade: {0}, Estado: {1}", endereco.Localidade, endereco.UF));
            Console.ReadKey();
        }

        private static string GetEndereco(string cep)
        {
            try
            {
                string url = "https://viacep.com.br/ws/" + cep + "/json/";
                string result = new HttpClient().GetStringAsync(url).Result;
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("CEP Inválido");
                Console.ReadKey();
            }

            return cep;
        }
    }
}
