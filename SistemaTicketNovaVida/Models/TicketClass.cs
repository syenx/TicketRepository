using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaTicketNovaVida.Models
{
    public class TicketClass
    {
        public int IdTicket { get; set; }
        public string TituloTiket { get; set; }
        public List<Item> ListaItem { get; set; }
        public string Descricao { get; set; }
    }
}