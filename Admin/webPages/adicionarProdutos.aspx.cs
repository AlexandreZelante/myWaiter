using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myWaiter.Admin.Controller;
using myWaiter.Admin.Model;

namespace myWaiter.Admin.webPages
{
    public partial class adicionarProdutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtDesc_Prod.Text != "" && txtNome_Prod.Text != "" && txtPreco.Text != "" && txtQtd.Text != "" && FileUpload.HasFile)
            {
                int i;
                int qtd;
                double preco;
                string spreco = txtPreco.Text;
                bool verif = false;
                if (!Int32.TryParse(txtQtd.Text, out qtd))
                {
                    lblMsg2.Text = "A quantidade deve ser em números inteiros";
                }
                else if (!Double.TryParse(txtPreco.Text, out preco))
                {
                    lblMsg2.Text = "O preço deve ser somente numérico e use vírgula ( , ) ao invés de ponto ( . ) para separar as casas decimais";
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg2.Text = "";
                    for (i = 0; i <= txtPreco.Text.Length - 1; i++)
                    {
                        if (spreco[i] == '.')
                        {
                            lblMsg.Text = "O preço deve ser somente numérico e use vírgula ( , ) ao invés de ponto ( . ) para separar as casas decimais";
                            verif = true;
                        }
                    }
                    if (verif == true) { }
                    else
                    {
                        ProdutoController pc = new ProdutoController();
                        Produto p = new Produto();
                        spreco = preco.ToString("F");
                        preco = Convert.ToDouble(spreco);
                        p.nome_Produto = txtNome_Prod.Text.Trim();
                        p.categoria_Produto = ddlCat.SelectedValue;
                        p.descricao_Produto = txtDesc_Prod.Text.Trim();
                        //p.DispProd = 1;
                        p.preco_produto = Convert.ToDouble(preco);
                        p.prioridade_Produto = ddlPrior.SelectedIndex;
                        p.quantidade_Produto = Convert.ToInt32(txtQtd.Text);
                        if (p.quantidade_Produto > 0)
                        {
                            p.disponibilidade_Produto = 1;
                        }
                        else
                        {
                            p.disponibilidade_Produto = 0;
                        }
                        string nomeArq = FileUpload.FileName;
                        string caminho = @"~/imagens_Produto/" + nomeArq;
                        FileUpload.PostedFile.SaveAs(Server.MapPath(caminho));
                        p.imagem = caminho;
                        pc.cadastrarProduto(p);
                        
                    }
                }
            }
            else
            {
                lblMsg.Text = "Todos os campos são obrigatórios";
            }
            
        
        }
    }
}