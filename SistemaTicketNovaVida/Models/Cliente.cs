using Crypt_DeCrypt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaTicketNovaVida.Models
{
    public class Cliente : DAO
    {

        public long IDCLIENTE { get; set; }
        public string NOME { get; set; }
        public string CNPJ { get; set; }
        public string RAZAO { get; set; }
        public string NOMEFANTASIA { get; set; }
        public bool ATIVO { get; set; }
        public DateTime DTINATIVO { get; set; }
        public decimal FEEMENSAL { get; set; }
        public int FGPJ { get; set; }
        public DateTime DTCRIACAO { get; set; }

       
      
    }
}