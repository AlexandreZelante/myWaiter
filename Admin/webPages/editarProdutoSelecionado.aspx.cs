using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using myWaiter.Admin.Model;
using myWaiter.Admin.Controller;

namespace myWaiter.Admin.webPages
{
    public partial class editarProdutoSelecionado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["idProd"].ToString()) == 0 || Session["idProd"] == null)
            {
                Response.Redirect("editarProdutos.aspx");
            }
            else
            {
                ProdutoController p = new ProdutoController();
                imgProd.ImageUrl = p.getImg((int)Session["idProd"]);
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            int i;
            int qtd;
            string sQtd;
            double preco = 0;
            string spreco;
            bool verif = false;
            string nomeProd;
            string descProd;
            string categoria;
            string fileUp;
            string caminho;
            int prior;

            //nomeProd
            if (txtNome_Prod.Text.Length != 0)
            {
                nomeProd = txtNome_Prod.Text.Trim();
            }
            else
            {
                nomeProd = Session["nomeProd"].ToString();
            }

            //descProd
            if (txtDesc_Prod.Text.Length != 0)
            {
                descProd = txtDesc_Prod.Text.Trim();
            }
            else
            {
                descProd = Session["descProd"].ToString();
            }

            //ddlCat
            categoria = ddlCat.SelectedValue.ToString();

            //txtPreco
            if (txtPrecoProd.Text.Length != 0)
            {
                spreco = txtPrecoProd.Text.Trim();
            }
            else
            {
                spreco = Session["precoProd"].ToString();
            }

            //txtQtd
            if (txtQtdProd.Text.Length != 0)
            {
                sQtd = txtQtdProd.Text.Trim();
            }
            else
            {
                sQtd = Session["qtdProd"].ToString();
            }

            //fileUpload
            if (FileUpload.HasFile == true)
            {
                fileUp = FileUpload.FileName;
                caminho = @"~/imagens_Produto/" + fileUp;
                FileUpload.PostedFile.SaveAs(Server.MapPath(caminho));
            }
            else
            {
                caminho = imgProd.ImageUrl;
            }

            //ddlPrior
            prior = Convert.ToInt32(ddlPrior.SelectedValue);
            
            

                if (!Int32.TryParse(sQtd, out qtd))
                {
                    lblMsg2.Text = "A quantidade deve ser em números inteiros";
                    verif = true;
                }
                else if (!Double.TryParse(spreco, out preco))
                {
                    lblMsg2.Text = "O preço deve ser somente numérico e use vírgula ( , ) ao invés de ponto ( . ) para separar as casas decimais";
                    verif = true;
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg2.Text = "";
                }
                if (txtPrecoProd.Text.Trim() != "")
                {
                    for (i = 0; i <= txtPrecoProd.Text.Length - 1; i++)
                    {
                        if (spreco[i] == '.')
                        {
                            lblMsg.Text = "O preço deve ser somente numérico e use vírgula ( , ) ao invés de ponto ( . ) para separar as casas decimais";
                            verif = true;
                        }
                    }
                }
                if (verif == true) { }
                else
                {
                    ProdutoController pc = new ProdutoController();
                    Produto p = new Produto();
                    p.nome_Produto = nomeProd;
                    p.categoria_Produto = categoria;
                    p.descricao_Produto = descProd;
                    //p.DispProd = 1;
                    p.preco_produto = preco;
                    p.prioridade_Produto = prior;
                    p.quantidade_Produto = qtd;
                    int id = Convert.ToInt32(Session["idProd"].ToString());
                    p.id_Produto = id;
                    if (p.quantidade_Produto > 0)
                    {
                        p.disponibilidade_Produto = 1;
                    }
                    else
                    {
                        p.disponibilidade_Produto = 0;
                    }
                    
                    p.imagem = caminho;
                    pc.editarProduto(p);
                
            }
        }
    
    }
}