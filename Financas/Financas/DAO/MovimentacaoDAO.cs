using Financas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Financas.Models;

namespace Financas.DAO
{
    public class MovimentacaoDAO
    {
        private FinancasContexto context;

        public MovimentacaoDAO(FinancasContexto context)
        {
            this.context = context;
        }

        public void Adiciona(Movimentacao movimentacao)
        {
            context.Movimentacoes.Add(movimentacao);
            context.SaveChanges();
        }

        public IList<Movimentacao> Lista()
        {
            return context.Movimentacoes.ToList();
        }

        public  IList<Movimentacao> BuscaporUsuario(int? usuarioId)
        {
            return context.Movimentacoes.Where(m => m.UsuarioId == usuarioId).ToList();
            
        }

        internal IList<Movimentacao> Busca(BuscaMovimendacoesModel model)
        {
            IQueryable<Movimentacao> busca = context.Movimentacoes;
            if (model.ValorMinimo.HasValue)
            {
                busca = busca.Where(m => m.Valor >= model.ValorMinimo);
            }
            if (model.ValorMaximo.HasValue)
            {
                busca = busca.Where(m => m.Valor <= model.ValorMaximo);
            }
            if (model.DataMinima.HasValue)
            {
                busca = busca.Where(m => m.Data >= model.DataMinima);
            }
            if (model.DataMaxima.HasValue)
            {
                busca = busca.Where(m => m.Data <= model.DataMaxima);
            }
            if (model.Tipo.HasValue)
            {
                busca = busca.Where(m => m.Tipo == model.Tipo);
            }
            if (model.UsuarioId.HasValue)
            {
                busca = busca.Where(m => m.UsuarioId == model.UsuarioId);
            }

            return busca.ToList();

        }
    }
}