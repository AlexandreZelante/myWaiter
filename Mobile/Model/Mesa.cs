using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myWaiter.Mobile.Model
{
    public class Mesa
    {
        public int id_Mesa { get; set; }
        public int status_Mesa { get; set; }
        public string loginMesa { get; set; }
        public string senhaMesa { get; set; }
        public int permissaoUser { get; set; }

        public Mesa(int id, int status, string login, string senha, int permissao)
        {
            this.id_Mesa = id;
            this.status_Mesa = status;
            this.loginMesa = login;
            this.senhaMesa = senha;
            this.permissaoUser = permissao;
        }

    }
}