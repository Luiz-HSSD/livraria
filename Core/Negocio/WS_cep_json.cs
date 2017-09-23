using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Core;
using Dominio;

using Newtonsoft.Json.Linq;
using System.Net;

namespace Core.Negocio
{
    class WS_cep_json : IStrategy
    {
        public string Processar(EntidadeDominio entidade)
        {
            try
            {
                Endereco end = (Endereco)entidade;
                string URL = "https://viacep.com.br/ws/" + end.Cep + "/json/unicode";
                WebClient client = new WebClient();
                string json = client.DownloadString(new Uri(URL));
                JObject jobject = JObject.Parse(json);
                // Recupera o objeto principal do json
               // end.Cep = (string)jobject["cep"];
                if(!String.IsNullOrEmpty((string)jobject["logradouro"]))
                    end.Logradouro = (string)jobject["logradouro"];
                if (!String.IsNullOrEmpty((string)jobject["bairro"]))
                    end.Bairro = (string)jobject["bairro"];
                if (!String.IsNullOrEmpty((string)jobject["localidade"]))
                end.Cidade = (string)jobject["localidade"];
                if (!String.IsNullOrEmpty((string)jobject["complemento"]))
                    end.Complemento = (string)jobject["complemento"];
                if (!String.IsNullOrEmpty((string)jobject["uf"]))
                    end.UF = (string)jobject["uf"];
                return null;
            }
            catch
            {
                return "Erro!";
            }

        }
    }
}
