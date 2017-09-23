using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.Utils;
using Dominio;
using Oracle.DataAccess.Client;
using System.Text;
using System.Data;

namespace livraria
{
    public partial class _Default : Viewgenerico
    {
        private Fornecedor forne = new Fornecedor();

        private void Pesquisar()
        {
            int evade = 0;
            string GRID = "<TABLE class='display' id='GridViewcat'><THEAD>{0}</THEAD><TBODY>{1}</TBODY></TABLE>";
            string tituloColunas = "<tr><th></th><th>Código</th><th>Nome</th><th>CNPJ</th><th>Numero</th><th>logradouro</th><th>Bairro</th><th>Cidade</th><th>CEP</th><th>UF</th><th>Complemento</th></tr>";
            string linha = "<tr><td> <a href='Default.aspx?cod={0}'>editar</a> ";
            linha += "<a href='Default.aspx?del={0}'>apagar</a></td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td></tr>";

            forne.ID = 0;
            Res = Commands["CONSULTAR"].Execute(forne);
            try
            {
                evade = Res.Entidades.Count;
            }
            catch
            {
                evade = 0;
            }
            StringBuilder conteudo = new StringBuilder();
            for (int i = 0; i < evade; i++)
            {
                forne = (Fornecedor)Res.Entidades.ElementAt(i);
                conteudo.AppendFormat(linha,
                    forne.ID.ToString(),
                    forne.Nome.ToString(),
                    forne.CNPJ.ToString(),
                    forne.ENDERECO.Numero.ToString(),
                    forne.ENDERECO.Logradouro,
                    forne.ENDERECO.Bairro,
                    forne.ENDERECO.Cidade,
                    forne.ENDERECO.Cep,
                    forne.ENDERECO.UF,
                    forne.ENDERECO.Complemento
                );

            }
            string tabelafinal = string.Format(GRID, tituloColunas, conteudo.ToString());
            divTable.InnerHtml = tabelafinal;
            forne.ID = 0;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    DataTable uf = new DataTable();
                    uf.Columns.Add(new DataColumn("id", typeof(int)));
                    uf.Columns.Add(new DataColumn("uf", typeof(string)));

                    // Populate the table with sample values.
                    uf.Rows.Add(ConverterDDL.CreateRow(1, "AC", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(2, "AL", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(3, "AM", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(4, "AP", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(5, "BA", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(6, "CE", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(7, "DF", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(8, "ES", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(9, "GO", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(10, "MA", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(11, "MG", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(12, "MS", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(13, "MT", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(14, "PA", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(15, "PB", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(16, "PE", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(17, "PI", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(18, "PR", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(19, "RJ", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(20, "RN", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(21, "RO", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(22, "RR", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(23, "RS", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(24, "SC", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(25, "SE", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(26, "SP", uf));
                    uf.Rows.Add(ConverterDDL.CreateRow(27, "TO", uf));
                    DropDownListcliuf.DataSource = uf;
                    DropDownListcliuf.DataBind();
                    Pesquisar();
                    if (!string.IsNullOrEmpty(Request.QueryString["cod"]))
                    {
                        forne.ID = Convert.ToInt32(Request.QueryString["cod"]);
                        Res = Commands["CONSULTAR"].Execute(forne);
                        forne = (Fornecedor)Res.Entidades.ElementAt(0);
                        txtcod.Text = Convert.ToString(forne.ID);
                        txtnome.Text = forne.Nome;
                        txtcnpj.Text = forne.CNPJ;
                        numero.Text = forne.ENDERECO.Numero;
                        logradouro.Text = forne.ENDERECO.Logradouro;
                        bairro.Text = forne.ENDERECO.Bairro;
                        cidade.Text = forne.ENDERECO.Cidade;
                        cep.Text = forne.ENDERECO.Cep;
                        complemento.Text = forne.ENDERECO.Complemento;
                        for (int i = 0; i < DropDownListcliuf.Items.Count; i++)
                        {
                            if (DropDownListcliuf.Items[i].Text == forne.ENDERECO.UF)
                                DropDownListcliuf.SelectedValue = DropDownListcliuf.Items[i].Value;
                        }
                    }
                    else
                    {
                        //verificr edição
                        if (!string.IsNullOrEmpty(Request.QueryString["del"]))
                        {

                            forne.ID = Convert.ToInt32(Request.QueryString["del"]);
                            Commands["EXCLUIR"].Execute(forne);
                            LabelErro.Text = Viewgenerico.Erro(Res.Msg);
                            Response.Redirect("Default.aspx");
                        }

                    }

                    //carregando caixa listagem

                }
            }
            catch (OracleException E)
            {
                // Response.Redirect("~/Default.aspx", false);
                throw E;
            }
        }

        protected void Novo_for_Click(object sender, EventArgs e)
        {
            forne.Nome = txtnome.Text;
            forne.CNPJ = txtcnpj.Text;
            forne.ENDERECO.Numero = numero.Text;
            forne.ENDERECO.Logradouro = logradouro.Text;
            forne.ENDERECO.Bairro = bairro.Text;
            forne.ENDERECO.Cidade = cidade.Text;
            forne.ENDERECO.Cep = cep.Text;
            forne.ENDERECO.UF = DropDownListcliuf.SelectedItem.Text;
            forne.ENDERECO.Complemento = complemento.Text;
            Res = Commands["SALVAR"].Execute(forne);
            LabelErro.Text = Viewgenerico.Erro(Res.Msg);
            txtcod.Text = "";
            txtnome.Text = "";
            txtcnpj.Text = "";
            cep.Text = "";
            logradouro.Text = "";
            bairro.Text = "";
            cidade.Text = "";
            numero.Text = "";
            complemento.Text = "";
            Pesquisar();
        }

        protected void Alterar_for_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtcod.Text))
            {
                forne.ID = Convert.ToInt32(txtcod.Text);
                forne.Nome = txtnome.Text;
                forne.CNPJ = txtcnpj.Text;
                forne.ENDERECO.Numero = numero.Text;
                forne.ENDERECO.Logradouro = logradouro.Text;
                forne.ENDERECO.Bairro = bairro.Text;
                forne.ENDERECO.Cidade = cidade.Text;
                forne.ENDERECO.Cep = cep.Text;
                forne.ENDERECO.UF = DropDownListcliuf.SelectedItem.Text;
                forne.ENDERECO.Complemento = complemento.Text;
                Res = Commands["ALTERAR"].Execute(forne);
                LabelErro.Text = Viewgenerico.Erro(Res.Msg);
                txtcod.Text = "";
                txtnome.Text = "";
                txtcnpj.Text = "";
                txtcod.Text = "";
                txtnome.Text = "";
                txtcnpj.Text = "";
                cep.Text = "";
                logradouro.Text = "";
                bairro.Text = "";
                cidade.Text = "";
                numero.Text = "";
                complemento.Text = "";
                Pesquisar();
            }
        }

        protected void Cancelar_for_Click(object sender, EventArgs e)
        {
            txtcod.Text = "";
            txtnome.Text = "";
            txtcnpj.Text = "";
            cep.Text = "";
            logradouro.Text = "";
            bairro.Text = "";
            cidade.Text = "";
            numero.Text = "";
            complemento.Text = "";
        }
        protected void Cep_TextChanged(object sender, EventArgs e)
        {
            if (cep.Text.Length == 8)
            {
                forne.ENDERECO.Cep = cep.Text;
                Res = Commands["CONSULTAR"].Execute(forne.ENDERECO);
                logradouro.Text = forne.ENDERECO.Logradouro;
                cep.Text = forne.ENDERECO.Cep;
                cidade.Text = forne.ENDERECO.Cidade;
                bairro.Text = forne.ENDERECO.Bairro;
                for (int i = 0; i < DropDownListcliuf.Items.Count; i++)
                {
                    if (DropDownListcliuf.Items[i].Text == forne.ENDERECO.UF)
                        DropDownListcliuf.SelectedValue = DropDownListcliuf.Items[i].Value;
                }


            }
        }

    }
}